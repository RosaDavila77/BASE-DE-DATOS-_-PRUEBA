Imports System.Data.SqlClient
Imports System.Data ' Asegúrate de tener esta importación

Public Class Profesor_editar

    Public Event ProfesorEditado As EventHandler ' Evento para notificar a Profesor_vista

    Private _profesorID As Integer ' Variable para almacenar el ID del profesor que se está editando

    ' Constructor que recibe el ID del profesor a editar
    Public Sub New(profesorID As Integer)
        InitializeComponent()
        _profesorID = profesorID ' Guardamos el ID
    End Sub

    Private Sub Profesor_editar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboboxesProfesor() ' Primero carga las opciones de los ComboBoxes
        CargarDatosProfesorParaEdicion(_profesorID) ' Luego carga los datos del profesor para rellenar los controles
    End Sub

    Private Sub CargarComboboxesProfesor()
        cboGeneroProfesor.Items.Clear()
        cboGeneroProfesor.Items.Add("M")
        cboGeneroProfesor.Items.Add("F")
        cboGeneroProfesor.SelectedIndex = -1

        cboGradoAcademicoProfesor.Items.Clear()
        cboGradoAcademicoProfesor.Items.Add("Licenciado")
        cboGradoAcademicoProfesor.Items.Add("Magíster")
        cboGradoAcademicoProfesor.Items.Add("Doctor")
        cboGradoAcademicoProfesor.Items.Add("Bachiller")
        cboGradoAcademicoProfesor.SelectedIndex = -1

        ' ==========================================================
        ' MODIFICACIÓN CLAVE: Cargar el ComboBox de Estado en EDICIÓN
        ' ==========================================================
        cboEstadoProfesor.Items.Clear()
        cboEstadoProfesor.Items.Add("Activo")
        cboEstadoProfesor.Items.Add("Licencia")
        cboEstadoProfesor.Items.Add("Retirado")
        ' No se selecciona nada aquí, ya que el valor real del profesor se asignará en CargarDatosProfesorParaEdicion
        cboEstadoProfesor.SelectedIndex = -1
    End Sub


    Private Sub CargarDatosProfesorParaEdicion(id As Integer)
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                ' Consulta para obtener los datos del profesor por su ID
                Dim query As String = "SELECT ID_Profesor, Nombres, ApellidoPaterno, ApellidoMaterno, DNI, FechaNacimiento, Genero, Direccion, Celular, Email, Especialidad, GradoAcademico, FechaContratacion, Estado FROM Profesores WHERE ID_Profesor = @ID_Profesor"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID_Profesor", id)
                    connection.Open()

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Rellenar los campos del formulario con los datos del profesor
                            ' txtIDProfesor.Text = reader("ID_Profesor").ToString() ' NO se muestra el ID para editar, pero sí se carga para saber que existe.
                            txtNombresProfesor.Text = reader("Nombres").ToString()
                            txtApellidoPaternoProfesor.Text = reader("ApellidoPaterno").ToString()
                            txtApellidoMaternoProfesor.Text = reader("ApellidoMaterno").ToString()
                            txtDniProfesor.Text = reader("DNI").ToString()
                            dtpFechaNacimientoProfesor.Value = CDate(reader("FechaNacimiento"))

                            ' Asignar valor a cboGeneroProfesor
                            If Not reader.IsDBNull(reader.GetOrdinal("Genero")) Then
                                cboGeneroProfesor.SelectedItem = reader("Genero").ToString()
                            Else
                                cboGeneroProfesor.SelectedIndex = -1
                            End If

                            txtDireccionProfesor.Text = If(reader("Direccion") Is DBNull.Value, "", reader("Direccion").ToString())
                            txtCelularProfesor.Text = If(reader("Celular") Is DBNull.Value, "", reader("Celular").ToString())
                            txtEmailProfesor.Text = If(reader("Email") Is DBNull.Value, "", reader("Email").ToString())
                            txtEspecialidadProfesor.Text = reader("Especialidad").ToString()

                            ' Asignar valor a cboGradoAcademicoProfesor
                            If Not reader.IsDBNull(reader.GetOrdinal("GradoAcademico")) Then
                                cboGradoAcademicoProfesor.SelectedItem = reader("GradoAcademico").ToString()
                            Else
                                cboGradoAcademicoProfesor.SelectedIndex = -1
                            End If

                            dtpFechaContratacionProfesor.Value = CDate(reader("FechaContratacion"))

                            ' ==========================================================
                            ' MODIFICACIÓN CLAVE: Asignar el valor del Estado al ComboBox
                            ' ==========================================================
                            If Not reader.IsDBNull(reader.GetOrdinal("Estado")) Then
                                cboEstadoProfesor.SelectedItem = reader("Estado").ToString()
                            Else
                                cboEstadoProfesor.SelectedIndex = -1 ' O un valor predeterminado si lo prefieres
                            End If

                        Else
                            MessageBox.Show("No se encontraron datos para el profesor con el ID especificado.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close() ' Cerrar si no se encuentra
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al cargar los datos del profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close() ' Cerrar en caso de error
        End Try
    End Sub

    Private Sub btnActualizarProfesor_Click(sender As Object, e As EventArgs) Handles btnActualizarProfesor.Click
        ' Validación de campos obligatorios
        If String.IsNullOrWhiteSpace(txtNombresProfesor.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellidoPaternoProfesor.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellidoMaternoProfesor.Text) OrElse
           String.IsNullOrWhiteSpace(txtDniProfesor.Text) OrElse
           String.IsNullOrWhiteSpace(txtEspecialidadProfesor.Text) OrElse
           cboGeneroProfesor.SelectedIndex = -1 OrElse
           cboEstadoProfesor.SelectedIndex = -1 Then ' Aquí sí validamos el estado

            MessageBox.Show("Por favor, complete todos los campos obligatorios para Profesor.", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        Dim estado As String = cboEstadoProfesor.Text ' Obtenemos el estado del ComboBox

        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Using command As New SqlCommand("Profesores_Actualizar", connection) ' Usamos el SP de actualización
                    command.CommandType = CommandType.StoredProcedure

                    command.Parameters.AddWithValue("@ID_Profesor", _profesorID) ' Enviamos el ID del profesor a actualizar
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
                    command.Parameters.AddWithValue("@Estado", estado)

                    connection.Open()
                    Dim filasAfectadas As Integer = command.ExecuteNonQuery()

                    If filasAfectadas > 0 Then
                        ' MessageBox.Show("Profesor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'RaiseEvent ProfesorEditado(Me, EventArgs.Empty) ' Disparar evento para notificar al padre
                        'Me.Close() ' Cerrar el formulario de edición
                    Else
                        'HEREEEEEEEEEEEEEEEEEEEEEEEEEE
                        MessageBox.Show("Profesor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RaiseEvent ProfesorEditado(Me, EventArgs.Empty) ' Disparar evento para notificar al padre
                        Me.Close() ' Cerrar el formulario de edición
                    End If

                End Using
            End Using
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MessageBox.Show("Error: El DNI del profesor ya existe en la base de datos.", "Error de Duplicidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Error al actualizar el profesor: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class