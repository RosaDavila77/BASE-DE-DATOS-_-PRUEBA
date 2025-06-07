' Cursos_editar.vb
Imports System.Data.SqlClient
Imports System.Data ' Añade esta importación si no la tienes

Public Class Cursos_editar
    ' Define el evento que el formulario Cursos_vista escuchará para saber que debe refrescar
    Public Event CursoEditado As EventHandler

    Private _idCurso As Integer ' Almacena el ID del curso que se está editando

    ' Constructor: Recibe el ID del curso seleccionado desde Cursos_vista
    Public Sub New(idCurso As Integer)
        InitializeComponent()
        _idCurso = idCurso ' Guarda el ID para usarlo en CargarDatosCurso y GuardarCambios
    End Sub

    Private Sub Cursos_editar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Asegúrate de que los ComboBoxes tengan sus ítems antes de cargar los datos
        CargarComboboxesCurso() ' NUEVO MÉTODO para cargar los ComboBoxes (similar a Profesor_editar)
        CargarDatosCurso(_idCurso) ' Cargar los datos del curso al cargar el formulario
    End Sub

    ' NUEVO MÉTODO: Para cargar los ítems de los ComboBoxes (similar a Profesor_editar)
    Private Sub CargarComboboxesCurso()
        cmbNivelEducativo.Items.Clear()
        cmbNivelEducativo.Items.Add("Inicial")
        cmbNivelEducativo.Items.Add("Primaria")
        cmbNivelEducativo.Items.Add("Secundaria")
        cmbNivelEducativo.Items.Add("Superior")
        cmbNivelEducativo.SelectedIndex = -1 ' No seleccionar nada por defecto

        cmbEstado.Items.Clear()
        cmbEstado.Items.Add("ACTIVO")
        cmbEstado.Items.Add("INACTIVO")
        cmbEstado.SelectedIndex = -1 ' No seleccionar nada por defecto
    End Sub

    Private Sub CargarDatosCurso(id As Integer)
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                ' === CAMBIO CLAVE: USAR UNA CONSULTA SQL DIRECTA EN LUGAR DE UN PROCEDIMIENTO ALMACENADO ===
                Dim query As String = "SELECT ID_Curso, NombreCurso, NivelEducativo, GradoAsociado, Descripcion, HorasSemanales, Estado FROM Cursos WHERE ID_Curso = @ID_Curso"
                Using command As New SqlCommand(query, connection)
                    ' command.CommandType = CommandType.StoredProcedure ' <--- ¡QUITAMOS ESTA LÍNEA! Ya no es un SP.
                    command.Parameters.AddWithValue("@ID_Curso", id)

                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    If reader.Read() Then
                        ' No se interactúa con txtID_Curso aquí
                        txtNombreCurso.Text = reader("NombreCurso").ToString()

                        If Not reader("NivelEducativo") Is DBNull.Value Then
                            ' Usamos SelectedItem para ComboBoxes después de cargarlos
                            cmbNivelEducativo.SelectedItem = reader("NivelEducativo").ToString()
                        Else
                            cmbNivelEducativo.SelectedIndex = -1
                        End If

                        txtGradoAsociado.Text = If(reader("GradoAsociado") Is DBNull.Value, "", reader("GradoAsociado").ToString())
                        txtDescripcion.Text = If(reader("Descripcion") Is DBNull.Value, "", reader("Descripcion").ToString())

                        If Not reader("HorasSemanales") Is DBNull.Value Then
                            nudHorasSemanales.Value = CDec(reader("HorasSemanales"))
                        Else
                            nudHorasSemanales.Value = 0
                        End If

                        If Not reader("Estado") Is DBNull.Value Then
                            ' Usamos SelectedItem para ComboBoxes después de cargarlos
                            cmbEstado.SelectedItem = reader("Estado").ToString()
                        Else
                            cmbEstado.SelectedIndex = -1
                        End If
                    Else
                        MessageBox.Show("No se encontraron datos para el curso con el ID especificado.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Close()
                    End If

                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al cargar los datos del curso para edición: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub btnGuardarCambios_Click(sender As Object, e As EventArgs) Handles btnGuardarCambios.Click
        Try
            ' --- 1. Validación de Entrada ---
            If String.IsNullOrWhiteSpace(txtNombreCurso.Text) Then
                MessageBox.Show("El Nombre del Curso es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If cmbNivelEducativo.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cmbNivelEducativo.Text) Then
                MessageBox.Show("Debe seleccionar un Nivel Educativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If nudHorasSemanales.Value <= 0 Then
                MessageBox.Show("Las Horas Semanales deben ser mayores que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If cmbEstado.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cmbEstado.Text) Then
                MessageBox.Show("Debe seleccionar un Estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim nombreCurso As String = txtNombreCurso.Text.Trim()
            Dim nivelEducativo As String = cmbNivelEducativo.Text.Trim()
            Dim gradoAsociado As String = If(String.IsNullOrWhiteSpace(txtGradoAsociado.Text), Nothing, txtGradoAsociado.Text.Trim())
            Dim descripcion As String = If(String.IsNullOrWhiteSpace(txtDescripcion.Text), Nothing, txtDescripcion.Text.Trim())
            Dim horasSemanales As Decimal = nudHorasSemanales.Value
            Dim estado As String = cmbEstado.Text.Trim()

            ' --- 2. Conexión y Ejecución del Procedimiento Almacenado de ACTUALIZACIÓN (ESTO SIGUE IGUAL) ---
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Using command As New SqlCommand("Cursos_Actualizar", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID_Curso", _idCurso) ' Usamos el ID original guardado en _idCurso
                    command.Parameters.AddWithValue("@NombreCurso", nombreCurso)
                    command.Parameters.AddWithValue("@NivelEducativo", nivelEducativo)
                    command.Parameters.AddWithValue("@GradoAsociado", If(gradoAsociado Is Nothing, DBNull.Value, gradoAsociado))
                    command.Parameters.AddWithValue("@Descripcion", If(descripcion Is Nothing, DBNull.Value, descripcion))
                    command.Parameters.AddWithValue("@HorasSemanales", horasSemanales)
                    command.Parameters.AddWithValue("@Estado", estado)

                    connection.Open()
                    Dim filasAfectadas As Integer = command.ExecuteNonQuery()

                    If filasAfectadas > 0 Then

                    Else
                        'MessageBox.Show("No se encontró el curso para actualizar. Puede que haya sido eliminado por otro usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '
                        MessageBox.Show("Cambios guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' --- 3. Notificar a Cursos_vista y cerrar el formulario ---
                        RaiseEvent CursoEditado(Me, EventArgs.Empty)
                        Me.Close()
                    End If
                End Using
            End Using
        Catch ex As SqlException
            If ex.Number = 2627 Then ' Violación de UNIQUE constraint (NombreCurso)
                MessageBox.Show("Ya existe otro curso con el mismo Nombre. Por favor, ingrese un nombre único.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Error de base de datos al guardar cambios: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al guardar cambios: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class