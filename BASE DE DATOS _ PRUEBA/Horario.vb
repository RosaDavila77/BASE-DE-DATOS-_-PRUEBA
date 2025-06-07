' Horario.vb (Para Añadir)
Imports System.Data.SqlClient
Imports System.Data

Public Class Horario
    Public Event HorarioGuardado As EventHandler ' Evento para notificar que un horario ha sido guardado

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Horario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboboxesHorario()
        ' Configurar DateTimePickers para solo mostrar la hora
        dtpHoraInicio.Format = DateTimePickerFormat.Time
        dtpHoraInicio.ShowUpDown = True
        dtpHoraFin.Format = DateTimePickerFormat.Time
        dtpHoraFin.ShowUpDown = True

        ' Opcional: Establecer un valor por defecto para PeriodoAcademico si aplica (ej. año actual)
        ' txtPeriodoAcademico.Text = DateTime.Now.Year.ToString() & "-I"
    End Sub

    Private Sub CargarComboboxesHorario()
        ' Cargar Días de la Semana
        cboDiaSemana.Items.Clear()
        cboDiaSemana.Items.AddRange(New String() {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"})
        cboDiaSemana.SelectedIndex = -1
    End Sub

    Private Sub btnGuardarHorario_Click(sender As Object, e As EventArgs) Handles btnGuardarHorario.Click
        ' --- 1. Validación de Entrada ---
        Dim fkCursoID As Integer
        If Not Integer.TryParse(txtFKCursoID.Text.Trim(), fkCursoID) OrElse fkCursoID <= 0 Then
            MessageBox.Show("ID de Curso inválido. Debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fkProfesorID As Integer
        If Not Integer.TryParse(txtFKProfesorID.Text.Trim(), fkProfesorID) OrElse fkProfesorID <= 0 Then
            MessageBox.Show("ID de Profesor inválido. Debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

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
                ' ** VALIDACIÓN DE EXISTENCIA DE CURSO Y PROFESOR (NUEVO) **
                ' =========================================================================
                If Not ValidarExistencia("Cursos", "ID_Curso", fkCursoID, connection) Then
                    MessageBox.Show($"El ID de Curso '{fkCursoID}' no existe. Por favor, verifique.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                If Not ValidarExistencia("Profesores", "ID_Profesor", fkProfesorID, connection) Then
                    MessageBox.Show($"El ID de Profesor '{fkProfesorID}' no existe. Por favor, verifique.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' =========================================================================
                ' ** VALIDACIÓN DE SUPERPOSICIÓN DE HORARIO DEL PROFESOR **
                ' =========================================================================
                Dim overlappingProfesorQuery As String = "SELECT COUNT(*) FROM Horarios " &
                                                         "WHERE FK_ProfesorID = @ProfesorID " &
                                                         "AND DiaSemana = @DiaSemana " &
                                                         "AND PeriodoAcademico = @PeriodoAcademico " &
                                                         "AND ((@HoraInicio < HoraFin AND @HoraFin > HoraInicio) " &
                                                         "OR (@HoraInicio = HoraInicio AND @HoraFin = HoraFin))"

                Using overlappingCommand As New SqlCommand(overlappingProfesorQuery, connection)
                    overlappingCommand.Parameters.AddWithValue("@ProfesorID", fkProfesorID)
                    overlappingCommand.Parameters.AddWithValue("@DiaSemana", diaSemana)
                    overlappingCommand.Parameters.AddWithValue("@PeriodoAcademico", periodoAcademico)
                    overlappingCommand.Parameters.AddWithValue("@HoraInicio", horaInicio)
                    overlappingCommand.Parameters.AddWithValue("@HoraFin", horaFin)

                    Dim overlappingCount As Integer = CInt(overlappingCommand.ExecuteScalar())

                    If overlappingCount > 0 Then
                        MessageBox.Show("Este profesor ya tiene un horario asignado que se superpone con la hora y día especificados para este periodo académico. Por favor, elija otra hora o día.", "Conflicto de Horario del Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return ' No continuar con la inserción
                    End If
                End Using

                ' Si no hay superposición, proceder con la inserción
                Using command As New SqlCommand("Horarios_Insertar", connection) ' Usamos el SP que ya tienes
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@FK_CursoID", fkCursoID)
                    command.Parameters.AddWithValue("@FK_ProfesorID", fkProfesorID)
                    command.Parameters.AddWithValue("@DiaSemana", diaSemana)
                    command.Parameters.AddWithValue("@HoraInicio", horaInicio)
                    command.Parameters.AddWithValue("@HoraFin", horaFin)
                    command.Parameters.AddWithValue("@Salon", salon)
                    command.Parameters.AddWithValue("@PeriodoAcademico", periodoAcademico)

                    command.ExecuteNonQuery()

                    RaiseEvent HorarioGuardado(Me, EventArgs.Empty) ' Notificar al formulario padre
                    MessageBox.Show("Horario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End Using
            End Using
        Catch ex As SqlException
            If ex.Number = 2627 OrElse ex.Number = 2601 Then ' Violación de UNIQUE constraint (UQ_Horario_Salon_Dia_Hora)
                MessageBox.Show($"Error: Ya existe otra clase programada en el salón '{salon}' a la misma hora y día para este período académico. {Environment.NewLine}Detalle: {ex.Message}", "Conflicto de Salón", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Error de base de datos al guardar horario: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al guardar el horario: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidarExistencia(tableName As String, idColumn As String, idValue As Integer, connection As SqlConnection) As Boolean
        Dim query As String = $"SELECT COUNT(*) FROM {tableName} WHERE {idColumn} = @ID"
        Using cmd As New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@ID", idValue)
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class