Imports System.Data.SqlClient

Public Class Profesor ' Este es tu formulario de añadir Profesor

    Public Event ProfesorGuardado As EventHandler

    Private Sub Profesor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboboxesProfesor()
        LimpiarCamposProfesor()
    End Sub

    Private Sub CargarComboboxesProfesor()
        cboGeneroProfesor.Items.Clear()
        cboGeneroProfesor.Items.Add("M")
        cboGeneroProfesor.Items.Add("F")
        cboGeneroProfesor.SelectedIndex = -1 ' Ninguno seleccionado por defecto

        cboGradoAcademicoProfesor.Items.Clear()
        cboGradoAcademicoProfesor.Items.Add("Licenciado")
        cboGradoAcademicoProfesor.Items.Add("Magíster")
        cboGradoAcademicoProfesor.Items.Add("Doctor")
        cboGradoAcademicoProfesor.Items.Add("Bachiller")
        cboGradoAcademicoProfesor.SelectedIndex = -1
        ' Ya no necesitamos cargar cboEstadoProfesor aquí
    End Sub

    Private Sub btnGuardarProfesor_Click(sender As Object, e As EventArgs) Handles btnGuardarProfesor.Click
        ' Validación de campos obligatorios
        ' Eliminamos la validación para cboEstadoProfesor
        If String.IsNullOrWhiteSpace(txtNombresProfesor.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellidoPaternoProfesor.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellidoMaternoProfesor.Text) OrElse
           String.IsNullOrWhiteSpace(txtDniProfesor.Text) OrElse
           String.IsNullOrWhiteSpace(txtEspecialidadProfesor.Text) OrElse
           cboGeneroProfesor.SelectedIndex = -1 Then ' Eliminamos la validación de estado

            MessageBox.Show("Por favor, complete todos los campos obligatorios para Profesor (Nombres, Apellidos, DNI, Especialidad, Género).", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim nombres As String = txtNombresProfesor.Text
        Dim apellidoPaterno As String = txtApellidoPaternoProfesor.Text
        Dim apellidoMaterno As String = txtApellidoMaternoProfesor.Text
        Dim dni As String = txtDniProfesor.Text
        Dim fechaNacimiento As Date = dtpFechaNacimientoProfesor.Value
        Dim genero As Char = CChar(cboGeneroProfesor.SelectedItem.ToString())
        Dim direccion As Object = If(String.IsNullOrWhiteSpace(txtDireccionProfesor.Text), DBNull.Value, txtDireccionProfesor.Text)
        Dim celular As Object = If(String.IsNullOrWhiteSpace(txtCelularProfesor.Text), DBNull.Value, txtCelularProfesor.Text)
        Dim email As Object = If(String.IsNullOrWhiteSpace(txtEmailProfesor.Text), DBNull.Value, txtEmailProfesor.Text)
        Dim especialidad As String = txtEspecialidadProfesor.Text
        Dim gradoAcademico As Object = If(cboGradoAcademicoProfesor.SelectedIndex = -1, DBNull.Value, cboGradoAcademicoProfesor.Text)
        Dim fechaContratacion As Date = dtpFechaContratacionProfesor.Value

        ' === MODIFICACIÓN CLAVE: Asignar el estado "Activo" directamente ===
        Dim estado As String = "Activo"

        Dim nuevoProfesorID As Integer = 0

        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Using command As New SqlCommand("Profesores_Insertar", connection)
                    command.CommandType = CommandType.StoredProcedure

                    command.Parameters.AddWithValue("@Nombres", nombres)
                    command.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno)
                    command.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno)
                    command.Parameters.AddWithValue("@DNI", dni)
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento)
                    command.Parameters.AddWithValue("@Genero", genero)
                    command.Parameters.AddWithValue("@Direccion", direccion)
                    command.Parameters.AddWithValue("@Celular", celular)
                    command.Parameters.AddWithValue("@Email", email)
                    command.Parameters.AddWithValue("@Especialidad", especialidad)
                    command.Parameters.AddWithValue("@GradoAcademico", gradoAcademico)
                    command.Parameters.AddWithValue("@FechaContratacion", fechaContratacion)
                    command.Parameters.AddWithValue("@Estado", estado) ' Aquí se envía "Activo"

                    Dim idParam As New SqlParameter("@NuevoID", SqlDbType.Int)
                    idParam.Direction = ParameterDirection.Output
                    command.Parameters.Add(idParam)

                    connection.Open()
                    command.ExecuteNonQuery()
                    nuevoProfesorID = CInt(idParam.Value)

                    MessageBox.Show($"Profesor guardado exitosamente con ID: {nuevoProfesorID}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    RaiseEvent ProfesorGuardado(Me, EventArgs.Empty)
                    Me.Close()

                End Using
            End Using
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MessageBox.Show("Error: El DNI del profesor ya existe en la base de datos.", "Error de Duplicidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Error al guardar el profesor: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCamposProfesor()
        txtNombresProfesor.Clear()
        txtApellidoPaternoProfesor.Clear()
        txtApellidoMaternoProfesor.Clear()
        txtDniProfesor.Clear()
        dtpFechaNacimientoProfesor.Value = DateTime.Now
        cboGeneroProfesor.SelectedIndex = -1
        txtDireccionProfesor.Clear()
        txtCelularProfesor.Clear()
        txtEmailProfesor.Clear()
        txtEspecialidadProfesor.Clear()
        cboGradoAcademicoProfesor.SelectedIndex = -1
        dtpFechaContratacionProfesor.Value = DateTime.Now
        ' === MODIFICACIÓN CLAVE: Eliminamos la referencia a cboEstadoProfesor ===
        ' cboEstadoProfesor.SelectedIndex = 0 ' Ya no es necesario aquí
        txtNombresProfesor.Focus()
    End Sub

    ' Si tienes un botón "Cerrar" o "Cancelar"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class