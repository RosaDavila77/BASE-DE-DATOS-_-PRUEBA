Imports System.Data.SqlClient
Imports System.Data

Public Class Estudiante
    Public Event AlumnoGuardado As EventHandler

    ' Propiedad para saber si estamos editando o añadiendo
    Private _esEdicion As Boolean
    Private _alumnoID As Integer ' Solo se usará en modo edición

    ' Propiedades para almacenar los datos del alumno (temporalmente)
    Public Property Nombres As String
    Public Property ApellidoPaterno As String
    Public Property ApellidoMaterno As String
    Public Property FechaNacimiento As Date
    Public Property DNI As String
    Public Property Genero As String
    Public Property Direccion As String
    Public Property Distrito As String
    Public Property Provincia As String
    Public Property Departamento As String
    Public Property TelefonoCasa As String
    Public Property Celular As String
    Public Property Email As String
    Public Property GradoAcademico As String
    Public Property Seccion As String
    Public Property Estado As String ' Para edición, permite cambiar el estado
    Public Property FechaInscripcion As Date
    Public Property FK_ApoderadoID As Integer ' Para almacenar el ID del apoderado si ya existe

    ' Propiedades para almacenar los datos del apoderado (temporalmente)
    Public Property ApoderadoNombres As String
    Public Property ApoderadoApellidoPaterno As String
    Public Property ApoderadoApellidoMaterno As String
    Public Property ApoderadoDNI As String
    Public Property ApoderadoParentesco As String
    Public Property ApoderadoCelular As String
    Public Property ApoderadoEmail As String
    Public Property ApoderadoDireccion As String
    Public Property ApoderadoDistrito As String
    Public Property ApoderadoProvincia As String
    Public Property ApoderadoDepartamento As String

    ' Constructor para añadir un nuevo alumno
    Public Sub New()
        InitializeComponent()
        _esEdicion = False ' Estamos en modo añadir
        ' Inicializar fechas con valores por defecto o actuales
        dtpFechaNacimiento.Value = DateTime.Now.AddYears(-6) ' Ej: un niño de 6 años
        dtpFechaInscripcion.Value = DateTime.Now

        ' Ocultar el ComboBox de Estado y su label cuando se añade un nuevo alumno
        cboEstado.Visible = False
        lblEstado.Visible = False ' Asumiendo que tienes un Label llamado lblEstado
    End Sub

    ' Constructor para editar un alumno existente
    Public Sub New(alumnoID As Integer)
        InitializeComponent()
        _esEdicion = True
        _alumnoID = alumnoID

        ' Mostrar el ComboBox de Estado y su label cuando se edita un alumno
        cboEstado.Visible = True
        lblEstado.Visible = True ' Asumiendo que tienes un Label llamado lblEstado

        CargarDatosAlumnoParaEdicion(alumnoID)
    End Sub

    Private Sub Estudiante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboboxesEstudiante()
        ' En modo edición, los datos se cargaron en el constructor.
        ' En modo añadir, los controles ya se ocultaron/mostraron según corresponda.
        If Not _esEdicion Then
            ' Para añadir, el estado siempre será "Activo", no hay que mostrarlo ni seleccionarlo.
            ' El cboEstado se ocultó en el constructor New().
        Else
            ' Para edición, el cboEstado ya se mostró en el constructor New(alumnoID).
            ' Aquí solo aseguramos que el valor cargado esté seleccionado.
            If Not String.IsNullOrEmpty(Estado) Then
                cboEstado.SelectedItem = Estado
            End If
        End If
    End Sub

    Private Sub CargarComboboxesEstudiante()
        cboGenero.Items.Clear()
        cboGenero.Items.Add("M")
        cboGenero.Items.Add("F")
        cboGenero.SelectedIndex = -1 ' No seleccionar nada por defecto

        cboGradoAcademico.Items.Clear()
        cboGradoAcademico.Items.Add("Inicial - 3 años")
        cboGradoAcademico.Items.Add("Inicial - 4 años")
        cboGradoAcademico.Items.Add("Inicial - 5 años")
        cboGradoAcademico.Items.Add("1ro Primaria")
        cboGradoAcademico.Items.Add("2do Primaria")
        cboGradoAcademico.Items.Add("3ro Primaria")
        cboGradoAcademico.Items.Add("4to Primaria")
        cboGradoAcademico.Items.Add("5to Primaria")
        cboGradoAcademico.Items.Add("6to Primaria")
        cboGradoAcademico.Items.Add("1ro Secundaria")
        cboGradoAcademico.Items.Add("2do Secundaria")
        cboGradoAcademico.Items.Add("3ro Secundaria")
        cboGradoAcademico.Items.Add("4to Secundaria")
        cboGradoAcademico.Items.Add("5to Secundaria")
        cboGradoAcademico.SelectedIndex = -1

        cboSeccion.Items.Clear()
        cboSeccion.Items.Add("A")
        cboSeccion.Items.Add("B")
        cboSeccion.Items.Add("C")
        cboSeccion.Items.Add("D")
        cboSeccion.SelectedIndex = -1

        ' El ComboBox de Estado solo se carga y se usa si estamos en modo edición
        If _esEdicion Then
            cboEstado.Items.Clear()
            cboEstado.Items.Add("Activo")
            cboEstado.Items.Add("Suspendido")
            cboEstado.Items.Add("Graduado")
            cboEstado.SelectedIndex = -1
        End If
    End Sub

    Private Sub CargarDatosAlumnoParaEdicion(id As Integer)
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                ' Consulta para obtener los datos del alumno y su apoderado
                Dim query As String = "SELECT A.*, AP.Nombres AS ApoderadoNombres, AP.ApellidoPaterno AS ApoderadoApellidoPaterno, AP.ApellidoMaterno AS ApoderadoApellidoMaterno, AP.DNI AS ApoderadoDNI, AP.Parentesco, AP.Celular AS ApoderadoCelular, AP.Email AS ApoderadoEmail, AP.Direccion AS ApoderadoDireccion, AP.Distrito AS ApoderadoDistrito, AP.Provincia AS ApoderadoProvincia, AP.Departamento AS ApoderadoDepartamento " &
                                      "FROM Alumnos AS A LEFT JOIN Apoderados AS AP ON A.FK_ApoderadoID = AP.ID_Apoderado WHERE A.ID_Alumno = @ID_Alumno"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID_Alumno", id)
                    connection.Open()

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Cargar datos del alumno en los controles
                            txtNombres.Text = reader("Nombres").ToString()
                            txtApellidoPaterno.Text = reader("ApellidoPaterno").ToString()
                            txtApellidoMaterno.Text = reader("ApellidoMaterno").ToString()
                            dtpFechaNacimiento.Value = CDate(reader("FechaNacimiento"))
                            txtDNI.Text = If(reader("DNI") Is DBNull.Value, "", reader("DNI").ToString())
                            If Not reader.IsDBNull(reader.GetOrdinal("Genero")) Then cboGenero.SelectedItem = reader("Genero").ToString()
                            txtDireccion.Text = If(reader("Direccion") Is DBNull.Value, "", reader("Direccion").ToString())
                            txtDistrito.Text = If(reader("Distrito") Is DBNull.Value, "", reader("Distrito").ToString())
                            txtProvincia.Text = If(reader("Provincia") Is DBNull.Value, "", reader("Provincia").ToString())
                            txtDepartamento.Text = If(reader("Departamento") Is DBNull.Value, "", reader("Departamento").ToString())
                            txtTelefonoCasa.Text = If(reader("TelefonoCasa") Is DBNull.Value, "", reader("TelefonoCasa").ToString())
                            txtCelular.Text = If(reader("Celular") Is DBNull.Value, "", reader("Celular").ToString())
                            txtEmail.Text = If(reader("Email") Is DBNull.Value, "", reader("Email").ToString())
                            If Not reader.IsDBNull(reader.GetOrdinal("GradoAcademico")) Then cboGradoAcademico.SelectedItem = reader("GradoAcademico").ToString()
                            If Not reader.IsDBNull(reader.GetOrdinal("Seccion")) Then cboSeccion.SelectedItem = reader("Seccion").ToString()
                            If Not reader.IsDBNull(reader.GetOrdinal("Estado")) Then cboEstado.SelectedItem = reader("Estado").ToString()
                            dtpFechaInscripcion.Value = CDate(reader("FechaInscripcion"))
                            FK_ApoderadoID = If(reader("FK_ApoderadoID") Is DBNull.Value, 0, CInt(reader("FK_ApoderadoID"))) ' Guarda el ID del apoderado existente

                            ' Cargar datos del apoderado en las propiedades (no en controles visibles aquí)
                            ApoderadoNombres = If(reader("ApoderadoNombres") Is DBNull.Value, "", reader("ApoderadoNombres").ToString())
                            ApoderadoApellidoPaterno = If(reader("ApoderadoApellidoPaterno") Is DBNull.Value, "", reader("ApoderadoApellidoPaterno").ToString())
                            ApoderadoApellidoMaterno = If(reader("ApoderadoApellidoMaterno") Is DBNull.Value, "", reader("ApoderadoApellidoMaterno").ToString())
                            ApoderadoDNI = If(reader("ApoderadoDNI") Is DBNull.Value, "", reader("ApoderadoDNI").ToString())
                            ApoderadoParentesco = If(reader("Parentesco") Is DBNull.Value, "", reader("Parentesco").ToString())
                            ApoderadoCelular = If(reader("ApoderadoCelular") Is DBNull.Value, "", reader("ApoderadoCelular").ToString())
                            ApoderadoEmail = If(reader("ApoderadoEmail") Is DBNull.Value, "", reader("ApoderadoEmail").ToString())
                            ApoderadoDireccion = If(reader("ApoderadoDireccion") Is DBNull.Value, "", reader("ApoderadoDireccion").ToString())
                            ApoderadoDistrito = If(reader("Distrito") Is DBNull.Value, "", reader("Distrito").ToString())
                            ApoderadoProvincia = If(reader("Provincia") Is DBNull.Value, "", reader("Provincia").ToString())
                            ApoderadoDepartamento = If(reader("Departamento") Is DBNull.Value, "", reader("Departamento").ToString())

                        Else
                            MessageBox.Show("No se encontraron datos para el estudiante con el ID especificado.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al cargar los datos del estudiante para edición: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    ' Método para recopilar los datos de los controles y guardarlos en las propiedades
    Private Sub RecopilarDatosAlumno()
        Nombres = txtNombres.Text.Trim()
        ApellidoPaterno = txtApellidoPaterno.Text.Trim()
        ApellidoMaterno = txtApellidoMaterno.Text.Trim()
        FechaNacimiento = dtpFechaNacimiento.Value
        DNI = If(String.IsNullOrWhiteSpace(txtDNI.Text), Nothing, txtDNI.Text.Trim())
        Genero = cboGenero.Text.Trim()
        Direccion = If(String.IsNullOrWhiteSpace(txtDireccion.Text), Nothing, txtDireccion.Text.Trim())
        Distrito = If(String.IsNullOrWhiteSpace(txtDistrito.Text), Nothing, txtDistrito.Text.Trim())
        Provincia = If(String.IsNullOrWhiteSpace(txtProvincia.Text), Nothing, txtProvincia.Text.Trim())
        Departamento = If(String.IsNullOrWhiteSpace(txtDepartamento.Text), Nothing, txtDepartamento.Text.Trim())
        TelefonoCasa = If(String.IsNullOrWhiteSpace(txtTelefonoCasa.Text), Nothing, txtTelefonoCasa.Text.Trim())
        Celular = If(String.IsNullOrWhiteSpace(txtCelular.Text), Nothing, txtCelular.Text.Trim())
        Email = If(String.IsNullOrWhiteSpace(txtEmail.Text), Nothing, txtEmail.Text.Trim())
        GradoAcademico = cboGradoAcademico.Text.Trim()
        Seccion = cboSeccion.Text.Trim()

        ' El estado se maneja diferente según el modo
        If _esEdicion Then
            Estado = cboEstado.Text.Trim() ' En edición, toma el valor del ComboBox
        Else
            Estado = "Activo" ' Al añadir, siempre es 'Activo'
        End If

        FechaInscripcion = dtpFechaInscripcion.Value
    End Sub

    ' Método para rellenar los controles con los datos almacenados en las propiedades
    Public Sub RellenarControlesDesdePropiedades()
        txtNombres.Text = Nombres
        txtApellidoPaterno.Text = ApellidoPaterno
        txtApellidoMaterno.Text = ApellidoMaterno
        dtpFechaNacimiento.Value = FechaNacimiento
        txtDNI.Text = DNI
        cboGenero.SelectedItem = Genero
        txtDireccion.Text = Direccion
        txtDistrito.Text = Distrito
        txtProvincia.Text = Provincia
        txtDepartamento.Text = Departamento
        txtTelefonoCasa.Text = TelefonoCasa
        txtCelular.Text = Celular
        txtEmail.Text = Email
        cboGradoAcademico.SelectedItem = GradoAcademico
        cboSeccion.SelectedItem = Seccion

        ' Rellenar el estado solo si está visible (modo edición)
        If cboEstado.Visible Then
            cboEstado.SelectedItem = Estado
        End If

        dtpFechaInscripcion.Value = FechaInscripcion
        ' Los datos del apoderado no se muestran aquí, solo se guardan en las propiedades
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        ' --- 1. Validar campos del alumno ---
        If String.IsNullOrWhiteSpace(txtNombres.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellidoPaterno.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellidoMaterno.Text) OrElse
           dtpFechaNacimiento.Value >= DateTime.Now OrElse
           cboGenero.SelectedIndex = -1 OrElse
           cboGradoAcademico.SelectedIndex = -1 OrElse
           cboSeccion.SelectedIndex = -1 Then
            MessageBox.Show("Por favor, complete todos los campos obligatorios del estudiante (Nombres, Apellidos, Fecha de Nacimiento, Género, Grado, Sección).", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- 2. Recopilar datos del alumno en las propiedades ---
        RecopilarDatosAlumno()

        ' --- 3. Abrir el formulario Apoderados, pasando los datos actuales del apoderado ---
        Dim formApoderados As New Apoderados(Me) ' Pasamos una referencia a este formulario
        formApoderados.Show()
        Me.Hide() ' Ocultamos este formulario (no lo cerramos)
    End Sub

    ' Método para guardar tanto el alumno como el apoderado
    ' Este método será llamado desde el formulario Apoderados cuando se presione "Guardar"
    Public Function GuardarAlumnoYApoderado() As Boolean
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                connection.Open()
                Dim transaction As SqlTransaction = connection.BeginTransaction()

                Try
                    Dim apoderadoId As Integer = FK_ApoderadoID ' Usa el ID existente si es edición y ya había un apoderado

                    ' VALIDAR SI HAY DATOS DE APODERADO ANTES DE INTENTAR INSERTAR/ACTUALIZAR
                    If String.IsNullOrWhiteSpace(ApoderadoNombres) OrElse String.IsNullOrWhiteSpace(ApoderadoApellidoPaterno) OrElse
                       String.IsNullOrWhiteSpace(ApoderadoApellidoMaterno) OrElse String.IsNullOrWhiteSpace(ApoderadoDNI) Then
                        MessageBox.Show("No se pueden guardar el estudiante y el apoderado: Los datos del apoderado son incompletos o faltan.", "Error de Datos del Apoderado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        transaction.Rollback()
                        Return False
                    End If

                    If apoderadoId = 0 Then ' Si no hay apoderado asociado (o es un nuevo alumno)
                        ' --- Insertar nuevo apoderado ---
                        Using commandApoderado As New SqlCommand("Apoderados_Insertar", connection, transaction)
                            commandApoderado.CommandType = CommandType.StoredProcedure
                            commandApoderado.Parameters.AddWithValue("@Nombres", ApoderadoNombres)
                            commandApoderado.Parameters.AddWithValue("@ApellidoPaterno", ApoderadoApellidoPaterno)
                            commandApoderado.Parameters.AddWithValue("@ApellidoMaterno", ApoderadoApellidoMaterno)
                            commandApoderado.Parameters.AddWithValue("@DNI", ApoderadoDNI)
                            commandApoderado.Parameters.AddWithValue("@Parentesco", ApoderadoParentesco)
                            commandApoderado.Parameters.AddWithValue("@Celular", If(String.IsNullOrWhiteSpace(ApoderadoCelular), DBNull.Value, ApoderadoCelular))
                            commandApoderado.Parameters.AddWithValue("@Email", If(String.IsNullOrWhiteSpace(ApoderadoEmail), DBNull.Value, ApoderadoEmail))
                            commandApoderado.Parameters.AddWithValue("@Direccion", If(String.IsNullOrWhiteSpace(ApoderadoDireccion), DBNull.Value, ApoderadoDireccion))
                            commandApoderado.Parameters.AddWithValue("@Distrito", If(String.IsNullOrWhiteSpace(ApoderadoDistrito), DBNull.Value, ApoderadoDistrito))
                            commandApoderado.Parameters.AddWithValue("@Provincia", If(String.IsNullOrWhiteSpace(ApoderadoProvincia), DBNull.Value, ApoderadoProvincia))
                            commandApoderado.Parameters.AddWithValue("@Departamento", If(String.IsNullOrWhiteSpace(ApoderadoDepartamento), DBNull.Value, ApoderadoDepartamento))

                            Dim paramNuevoIDApoderado As New SqlParameter("@NuevoID", SqlDbType.Int)
                            paramNuevoIDApoderado.Direction = ParameterDirection.Output
                            commandApoderado.Parameters.Add(paramNuevoIDApoderado)

                            commandApoderado.ExecuteNonQuery()
                            apoderadoId = CInt(paramNuevoIDApoderado.Value)
                        End Using
                    Else ' Si ya existe un apoderado, actualizarlo
                        Using commandApoderado As New SqlCommand("Apoderados_Actualizar", connection, transaction)
                            commandApoderado.CommandType = CommandType.StoredProcedure
                            commandApoderado.Parameters.AddWithValue("@ID_Apoderado", apoderadoId)
                            commandApoderado.Parameters.AddWithValue("@Nombres", ApoderadoNombres)
                            commandApoderado.Parameters.AddWithValue("@ApellidoPaterno", ApoderadoApellidoPaterno)
                            commandApoderado.Parameters.AddWithValue("@ApellidoMaterno", ApoderadoApellidoMaterno)
                            commandApoderado.Parameters.AddWithValue("@DNI", ApoderadoDNI)
                            commandApoderado.Parameters.AddWithValue("@Parentesco", ApoderadoParentesco)
                            commandApoderado.Parameters.AddWithValue("@Celular", If(String.IsNullOrWhiteSpace(ApoderadoCelular), DBNull.Value, ApoderadoCelular))
                            commandApoderado.Parameters.AddWithValue("@Email", If(String.IsNullOrWhiteSpace(ApoderadoEmail), DBNull.Value, ApoderadoEmail))
                            commandApoderado.Parameters.AddWithValue("@Direccion", If(String.IsNullOrWhiteSpace(ApoderadoDireccion), DBNull.Value, ApoderadoDireccion))
                            commandApoderado.Parameters.AddWithValue("@Distrito", If(String.IsNullOrWhiteSpace(ApoderadoDistrito), DBNull.Value, ApoderadoDistrito))
                            commandApoderado.Parameters.AddWithValue("@Provincia", If(String.IsNullOrWhiteSpace(ApoderadoProvincia), DBNull.Value, ApoderadoProvincia))
                            commandApoderado.Parameters.AddWithValue("@Departamento", If(String.IsNullOrWhiteSpace(ApoderadoDepartamento), DBNull.Value, ApoderadoDepartamento))

                            commandApoderado.ExecuteNonQuery()
                        End Using
                    End If

                    ' --- Insertar o actualizar Alumno ---
                    Dim alumnoCommandName As String = If(_esEdicion, "Alumnos_Actualizar", "Alumnos_Insertar")
                    Using commandAlumno As New SqlCommand(alumnoCommandName, connection, transaction)
                        commandAlumno.CommandType = CommandType.StoredProcedure
                        If _esEdicion Then
                            commandAlumno.Parameters.AddWithValue("@ID_Alumno", _alumnoID)
                            commandAlumno.Parameters.AddWithValue("@Estado", Estado) ' El estado se puede actualizar en edición
                            commandAlumno.Parameters.AddWithValue("@FK_ApoderadoID", apoderadoId) ' Puede actualizarse o mantenerse
                        Else
                            commandAlumno.Parameters.AddWithValue("@Estado", "Activo") ' Por defecto 'Activo' al añadir
                            commandAlumno.Parameters.AddWithValue("@FK_ApoderadoID", apoderadoId)
                        End If

                        commandAlumno.Parameters.AddWithValue("@Nombres", Nombres)
                        commandAlumno.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno)
                        commandAlumno.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno)
                        commandAlumno.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento)
                        commandAlumno.Parameters.AddWithValue("@DNI", If(DNI Is Nothing, DBNull.Value, DNI))
                        commandAlumno.Parameters.AddWithValue("@Genero", Genero)
                        commandAlumno.Parameters.AddWithValue("@Direccion", If(Direccion Is Nothing, DBNull.Value, Direccion))
                        commandAlumno.Parameters.AddWithValue("@Distrito", If(Distrito Is Nothing, DBNull.Value, Distrito))
                        commandAlumno.Parameters.AddWithValue("@Provincia", If(Provincia Is Nothing, DBNull.Value, Provincia))
                        commandAlumno.Parameters.AddWithValue("@Departamento", If(Departamento Is Nothing, DBNull.Value, Departamento))
                        commandAlumno.Parameters.AddWithValue("@TelefonoCasa", If(TelefonoCasa Is Nothing, DBNull.Value, TelefonoCasa))
                        commandAlumno.Parameters.AddWithValue("@Celular", If(Celular Is Nothing, DBNull.Value, Celular))
                        commandAlumno.Parameters.AddWithValue("@Email", If(Email Is Nothing, DBNull.Value, Email))
                        commandAlumno.Parameters.AddWithValue("@GradoAcademico", GradoAcademico)
                        commandAlumno.Parameters.AddWithValue("@Seccion", Seccion)

                        If Not _esEdicion Then ' Si es un nuevo alumno, el ID se genera
                            Dim paramNuevoIDAlumno As New SqlParameter("@NuevoID", SqlDbType.Int)
                            paramNuevoIDAlumno.Direction = ParameterDirection.Output
                            commandAlumno.Parameters.Add(paramNuevoIDAlumno)
                        End If

                        commandAlumno.ExecuteNonQuery()
                    End Using

                    transaction.Commit()
                    MessageBox.Show("Estudiante y Apoderado guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RaiseEvent AlumnoGuardado(Me, EventArgs.Empty)
                    Return True

                Catch ex As SqlException
                    transaction.Rollback()
                    If ex.Number = 2627 Then ' Violación de UNIQUE constraint (DNI de Alumno o Apoderado)
                        MessageBox.Show("Error: El DNI ingresado para el Alumno o el Apoderado ya existe en la base de datos. Por favor, verifique.", "Error de Duplicidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show($"Error de base de datos al guardar: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    Return False
                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show($"Ocurrió un error inesperado al guardar: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error de conexión al intentar guardar: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class