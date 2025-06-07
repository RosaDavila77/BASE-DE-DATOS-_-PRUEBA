' Cursos.vb
Imports System.Data.SqlClient
Imports System.Data ' Asegúrate de tener este import para ParameterDirection

Public Class Cursos
    ' Define el evento que el formulario Cursos_vista escuchará para saber que debe refrescar
    Public Event CursoGuardado As EventHandler

    Private Sub Cursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Opcional: Limpiar o establecer valores por defecto al cargar el formulario
        txtNombreCurso.Text = ""
        cmbNivelEducativo.SelectedIndex = -1 ' Ningún ítem seleccionado al inicio
        txtGradoAsociado.Text = ""
        txtDescripcion.Text = ""
        nudHorasSemanales.Value = 0 ' Valor inicial para NumericUpDown
    End Sub

    Private Sub btnGuardarCurso_Click(sender As Object, e As EventArgs) Handles btnGuardarCurso.Click
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
            If nudHorasSemanales.Value <= 0 Then ' Ejemplo de validación para horas
                MessageBox.Show("Las Horas Semanales deben ser mayores que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim nombreCurso As String = txtNombreCurso.Text.Trim()
            Dim nivelEducativo As String = cmbNivelEducativo.Text.Trim() ' Obtener el texto del ComboBox

            Dim gradoAsociado As String = If(String.IsNullOrWhiteSpace(txtGradoAsociado.Text), Nothing, txtGradoAsociado.Text.Trim())
            Dim descripcion As String = If(String.IsNullOrWhiteSpace(txtDescripcion.Text), Nothing, txtDescripcion.Text.Trim())

            Dim horasSemanales As Decimal = nudHorasSemanales.Value ' Obtener el valor directamente del NumericUpDown

            ' --- 2. Conexión y Ejecución del Procedimiento Almacenado ---
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Using command As New SqlCommand("Cursos_Insertar", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@NombreCurso", nombreCurso)
                    command.Parameters.AddWithValue("@NivelEducativo", nivelEducativo)
                    command.Parameters.AddWithValue("@GradoAsociado", If(gradoAsociado Is Nothing, DBNull.Value, gradoAsociado))
                    command.Parameters.AddWithValue("@Descripcion", If(descripcion Is Nothing, DBNull.Value, descripcion))
                    command.Parameters.AddWithValue("@HorasSemanales", horasSemanales)
                    ' Tu SP Cursos_Insertar tiene @Estado VARCHAR(10) = 'ACTIVO'.
                    ' Si no lo envías aquí, se usará el valor por defecto 'ACTIVO' del SP.
                    ' Si prefieres enviarlo explícitamente desde la aplicación:
                    ' command.Parameters.AddWithValue("@Estado", "ACTIVO") 

                    ' >>>>>>>>>>>>> ESTA ES LA CLAVE DE LA CORRECCIÓN <<<<<<<<<<<<<
                    ' Declarar el parámetro de SALIDA @NuevoID
                    Dim paramNuevoID As New SqlParameter("@NuevoID", SqlDbType.Int)
                    paramNuevoID.Direction = ParameterDirection.Output
                    command.Parameters.Add(paramNuevoID)
                    ' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                    connection.Open()
                    command.ExecuteNonQuery()

                    ' Opcional: Puedes obtener el ID generado si lo necesitas aquí en el front-end
                    Dim nuevoIdGenerado As Integer = CInt(paramNuevoID.Value)
                    MessageBox.Show($"Curso guardado exitosamente con ID: {nuevoIdGenerado}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' --- 3. Notificar a Cursos_vista y cerrar el formulario ---
                    RaiseEvent CursoGuardado(Me, EventArgs.Empty)
                    Me.Close()
                End Using
            End Using

        Catch ex As SqlException
            If ex.Number = 2627 Then ' Violación de UNIQUE constraint (NombreCurso)
                MessageBox.Show("Ya existe un curso con el mismo Nombre. Por favor, ingrese un nombre único.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Error de base de datos al guardar el curso: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al guardar el curso: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class