' Horario_editar.vb
Imports System.Data.SqlClient
Imports System.Data

Public Class Horario_editar
    Public Event HorarioEditado As EventHandler ' Evento para notificar que un horario ha sido editado

    Private _idHorario As Integer ' Almacena el ID del horario que se está editando
    Private _fkCursoIDOriginal As Integer ' Para mantener el FK_CursoID
    Private _fkProfesorIDOriginal As Integer ' Para mantener el FK_ProfesorID

    ' Constructor: Recibe el ID del horario seleccionado desde Horarios_vista
    Public Sub New(idHorario As Integer)
        InitializeComponent()
        _idHorario = idHorario ' Guarda el ID para usarlo
    End Sub

    Private Sub Horario_editar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar DateTimePickers para solo mostrar la hora
        dtpHoraInicio.Format = DateTimePickerFormat.Time
        dtpHoraInicio.ShowUpDown = True
        dtpHoraFin.Format = DateTimePickerFormat.Time
        dtpHoraFin.ShowUpDown = True

        ' Configurar los nuevos TextBoxes como de solo lectura
        txtNombreCurso.ReadOnly = True ' <--- NUEVO
        txtNombreProfesor.ReadOnly = True ' <--- NUEVO

        CargarComboboxesHorario() ' Cargar los ComboBoxes (Días)
        CargarDatosHorario(_idHorario) ' Cargar los datos del horario al cargar el formulario
    End Sub

    Private Sub CargarComboboxesHorario()
        ' Cargar Días de la Semana
        cboDiaSemana.Items.Clear()
        cboDiaSemana.Items.AddRange(New String() {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"})
        cboDiaSemana.SelectedIndex = -1
    End Sub

    Private Sub CargarDatosHorario(id As Integer)
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                ' Consulta SQL para obtener también el NombreCurso y los Nombres/ApellidoPaterno del Profesor
                Dim query As String = "SELECT H.FK_CursoID, H.FK_ProfesorID, H.DiaSemana, H.HoraInicio, H.HoraFin, H.Salon, H.PeriodoAcademico, " &
                                      "C.NombreCurso, P.Nombres, P.ApellidoPaterno " &
                                      "FROM Horarios AS H " &
                                      "JOIN Cursos AS C ON H.FK_CursoID = C.ID_Curso " &
                                      "JOIN Profesores AS P ON H.FK_ProfesorID = P.ID_Profesor " &
                                      "WHERE H.ID_Horario = @ID_Horario"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID_Horario", id)

                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    If reader.Read() Then
                        ' Almacenar los IDs originales (no se muestran, pero se necesitan para la actualización)
                        _fkCursoIDOriginal = CInt(reader("FK_CursoID"))
                        _fkProfesorIDOriginal = CInt(reader("FK_ProfesorID"))

                        ' Rellenar los TextBoxes de solo lectura con los nombres
                        txtNombreCurso.Text = reader("NombreCurso").ToString() ' <--- NUEVO
                        txtNombreProfesor.Text = $"{reader("Nombres")} {reader("ApellidoPaterno")}" ' <--- NUEVO

                        cboDiaSemana.SelectedItem = reader("DiaSemana").ToString()

                        Dim horaInicioTS As TimeSpan = CType(reader("HoraInicio"), TimeSpan)
                        Dim horaFinTS As TimeSpan = CType(reader("HoraFin"), TimeSpan)

                        dtpHoraInicio.Value = DateTime.Today.Date.Add(horaInicioTS)
                        dtpHoraFin.Value = DateTime.Today.Date.Add(horaFinTS)

                        txtSalon.Text = reader("Salon").ToString()
                        txtPeriodoAcademico.Text = reader("PeriodoAcademico").ToString()
                    Else
                        MessageBox.Show("No se encontraron datos para el horario con el ID especificado.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Close()
                    End If
                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al cargar los datos del horario para edición: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub



    ''Lógica del Botón "Guardar Cambios"




    Private Sub btnGuardarCambios_Click(sender As Object, e As EventArgs) Handles btnGuardarCambios.Click
        ' --- 1. Validación de Entrada ---
        If cboDiaSemana.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(cboDiaSemana.Text) Then
            MessageBox.Show("Debe seleccionar un Día de la Semana.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(txtSalon.Text) Then
            MessageBox.Show("El Salón es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(txtPeriodoAcademico.Text) Then
            MessageBox.Show("El Período Académico es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dtpHoraFin.Value <= dtpHoraInicio.Value Then
            MessageBox.Show("La hora de fin debe ser posterior a la hora de inicio.", "Error de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim diaSemana As String = cboDiaSemana.SelectedItem.ToString()
        Dim horaInicio As TimeSpan = dtpHoraInicio.Value.TimeOfDay
        Dim horaFin As TimeSpan = dtpHoraFin.Value.TimeOfDay
        Dim salon As String = txtSalon.Text.Trim()
        Dim periodoAcademico As String = txtPeriodoAcademico.Text.Trim()

        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                connection.Open()

                ' =========================================================================
                ' ** VALIDACIÓN DE SUPERPOSICIÓN DE HORARIO DEL PROFESOR (con exclusión del horario actual) **
                ' =========================================================================
                Dim overlappingProfesorQuery As String = "SELECT COUNT(*) FROM Horarios " &
                                                         "WHERE FK_ProfesorID = @ProfesorID " &
                                                         "AND DiaSemana = @DiaSemana " &
                                                         "AND PeriodoAcademico = @PeriodoAcademico " &
                                                         "AND ((@HoraInicio < HoraFin AND @HoraFin > HoraInicio) " &
                                                         "OR (@HoraInicio = HoraInicio AND @HoraFin = HoraFin)) " &
                                                         "AND ID_Horario <> @ID_HorarioParaExcluir" ' Excluir el propio horario en edición

                Using overlappingCommand As New SqlCommand(overlappingProfesorQuery, connection)
                    overlappingCommand.Parameters.AddWithValue("@ProfesorID", _fkProfesorIDOriginal) ' Usar el ID del profesor original
                    overlappingCommand.Parameters.AddWithValue("@DiaSemana", diaSemana)
                    overlappingCommand.Parameters.AddWithValue("@PeriodoAcademico", periodoAcademico)
                    overlappingCommand.Parameters.AddWithValue("@HoraInicio", horaInicio)
                    overlappingCommand.Parameters.AddWithValue("@HoraFin", horaFin)
                    overlappingCommand.Parameters.AddWithValue("@ID_HorarioParaExcluir", _idHorario) ' Usar el ID del horario que estamos editando

                    Dim overlappingCount As Integer = CInt(overlappingCommand.ExecuteScalar())

                    If overlappingCount > 0 Then
                        MessageBox.Show("Este profesor ya tiene un horario asignado que se superpone con la hora y día especificados para este periodo académico. Por favor, elija otra hora o día.", "Conflicto de Horario del Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return ' No continuar con la actualización
                    End If
                End Using

                ' Si no hay superposición, proceder con la actualización
                Using command As New SqlCommand("Horarios_Actualizar", connection) ' Usamos el SP de actualización
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID_Horario", _idHorario) ' ID del horario a actualizar
                    command.Parameters.AddWithValue("@FK_CursoID", _fkCursoIDOriginal) ' Usar el FK_CursoID original
                    command.Parameters.AddWithValue("@FK_ProfesorID", _fkProfesorIDOriginal) ' Usar el FK_ProfesorID original
                    command.Parameters.AddWithValue("@DiaSemana", diaSemana)
                    command.Parameters.AddWithValue("@HoraInicio", horaInicio)
                    command.Parameters.AddWithValue("@HoraFin", horaFin)
                    command.Parameters.AddWithValue("@Salon", salon)
                    command.Parameters.AddWithValue("@PeriodoAcademico", periodoAcademico)

                    Dim filasAfectadas As Integer = command.ExecuteNonQuery()

                    If filasAfectadas > 0 Then
                        'HEREEEEEEEEEEEEEEE
                    Else
                        MessageBox.Show("Cambios del horario guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RaiseEvent HorarioEditado(Me, EventArgs.Empty) ' Notificar al formulario padre
                        Me.Close()
                        'MessageBox.Show("No se encontró el horario para actualizar. Puede que haya sido eliminado por otro usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As SqlException
            If ex.Number = 2627 OrElse ex.Number = 2601 Then ' Violación de UNIQUE constraint (UQ_Horario_Salon_Dia_Hora)
                MessageBox.Show($"Error: Ya existe otra clase programada en el salón '{salon}' a la misma hora y día para este período académico. {Environment.NewLine}Detalle: {ex.Message}", "Conflicto de Salón", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Error de base de datos al guardar cambios: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al guardar cambios: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Lógica del Botón "Cancelar"

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class