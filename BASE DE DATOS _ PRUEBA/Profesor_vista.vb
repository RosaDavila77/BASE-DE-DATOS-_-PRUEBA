Imports System.Data.SqlClient
Imports System.Data
Imports System.Math
Public Class Profesor_vista

    Private Sub Profesor_vista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                connection.Open()
                MessageBox.Show("¡Conexión a la base de datos exitosa para Formulario de Profesores!", "Conexión Establecida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As SqlException
            MessageBox.Show($"Error al conectar con SQL Server:{Environment.NewLine}{ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al intentar conectar:{Environment.NewLine}{ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        CargarProfesoresEnDataGridView()

    End Sub


    Private Sub CargarProfesoresEnDataGridView()
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Using command As New SqlCommand("SELECT * FROM Profesores", connection)
                    connection.Open()
                    Dim dataAdapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    dgvProfesores.DataSource = dataTable
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al cargar profesores: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub






    Private Sub btnAñadir_profesor_Click(sender As Object, e As EventArgs) Handles btnAñadir_profesor.Click

        Dim formAnadir As New Profesor()
        AddHandler formAnadir.ProfesorGuardado, AddressOf Me.OnProfesorGuardado

        formAnadir.ShowDialog()

    End Sub



    Private Sub OnProfesorGuardado(sender As Object, e As EventArgs)
        CargarProfesoresEnDataGridView()
        MessageBox.Show("¡El DataGridView ha sido actualizado con el nuevo profesor!", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub



    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    ' =========================================================
    ' MANEJO DE CLICS EN LOS BOTONES DE LAS COLUMNAS DEL DATAGRIDVIEW
    ' =========================================================

    Private Sub dgvProfesores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProfesores.CellContentClick
        If e.RowIndex >= 0 Then
            Dim columnaClicada As DataGridViewColumn = dgvProfesores.Columns(e.ColumnIndex)
            If columnaClicada.Name = "colEliminar" Then
                HandleEliminarProfesor(e.RowIndex)

            ElseIf columnaClicada.Name = "colEditar" Then
                HandleEditarProfesor(e.RowIndex)
            End If
        End If
    End Sub



    ' =========================================================
    ' LÓGICA DE ELIMINACIÓN DE PROFESORES
    ' =========================================================

    Private Sub HandleEliminarProfesor(rowIndex As Integer)
        Dim idProfesorAEliminar As Integer


        Try
            ' Obtenemos el ID del profesor de la fila clicada.
            idProfesorAEliminar = CInt(dgvProfesores.Rows(rowIndex).Cells("ID_Profesor").Value)
        Catch ex As Exception
            MessageBox.Show("No se pudo obtener el ID del profesor para eliminar. Asegúrese de que la columna 'ID_Profesor' existe y es visible en el DataGridView.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim resultado As DialogResult = MessageBox.Show($"¿Está seguro que desea eliminar al profesor con ID: {idProfesorAEliminar}? Esta acción no se puede deshacer.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            Try
                Using connection As New SqlConnection(DbConnection.GetConnectionString())
                    Using command As New SqlCommand("Profesores_Eliminar", connection)
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@ID_Profesor", idProfesorAEliminar)

                        connection.Open()
                        Dim filasAfectadas As Integer = command.ExecuteNonQuery()

                        ' If filasAfectadas > 0 Then
                        MessageBox.Show("Profesor eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CargarProfesoresEnDataGridView()
                        'Else
                        'ERROR DE ACTUALIZACIÓN /CORERGIR
                        'MessageBox.Show("No se encontró el profesor con el ID especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        'End If
                    End Using
                End Using
            Catch ex As SqlException
                If ex.Number = 547 Then
                    MessageBox.Show("Error: No se puede eliminar el profesor porque tiene registros relacionados (ej. horarios).", "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show($"Error al eliminar el profesor: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Ocurrió un error inesperado al eliminar el profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub



    ' =========================================================
    ' LÓGICA DE EDICIÓN DE PROFESORES
    ' =========================================================

    Private Sub HandleEditarProfesor(rowIndex As Integer)
        Dim idProfesorAEditar As Integer
        Try
            ' Obtenemos el ID del profesor de la fila clicada.
            ' ¡IMPORTANTE! Asumo que tu columna de ID se llama 'ID_Profesor' en la base de datos y por ende en el DataGridView.
            idProfesorAEditar = CInt(dgvProfesores.Rows(rowIndex).Cells("ID_Profesor").Value)
        Catch ex As Exception
            MessageBox.Show("No se pudo obtener el ID del profesor para editar. Asegúrese de que la columna 'ID_Profesor' existe y es visible en el DataGridView.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Creamos una instancia del formulario 'Profesor_editar' y le pasamos el ID.
        Dim formEditar As New Profesor_editar(idProfesorAEditar)

        ' Nos suscribimos a su evento de edición para saber cuándo refrescar el DataGridView
        AddHandler formEditar.ProfesorEditado, AddressOf Me.OnProfesorEditado

        formEditar.ShowDialog() ' Mostrar el formulario de edición
    End Sub

    ' Manejador de eventos que se ejecuta cuando el formulario 'Profesor_editar' dispara ProfesorEditado
    Private Sub OnProfesorEditado(sender As Object, e As EventArgs)
        CargarProfesoresEnDataGridView() ' Recargar los datos en el DataGridView
        MessageBox.Show("¡El DataGridView ha sido actualizado con los cambios del profesor!", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub




    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''


    Private Sub btnCerrar_Click_1(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Form1.Show()
        Me.Close()
    End Sub




    Private Sub btnBUSCAR_Click(sender As Object, e As EventArgs) Handles btnBUSCAR.Click
        Dim terminoBusqueda As String = TXTbusqueda_profesor.Text.Trim()

        If String.IsNullOrWhiteSpace(terminoBusqueda) OrElse terminoBusqueda = "Buscar Nombres, Apellidos, ID, Especialidad" Then
            ' Si la caja de búsqueda está vacía o con el texto por defecto, muestra todos los profesores
            CargarProfesoresEnDataGridView()
        Else
            ' Si hay un término de búsqueda, realiza la búsqueda
            RealizarBusquedaProfesores(terminoBusqueda)
        End If
    End Sub



    'funcion de busqueda 

    Private Sub RealizarBusquedaProfesores(termino As String)
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Dim queryBuilder As New System.Text.StringBuilder()
                queryBuilder.Append("SELECT ID_Profesor, Nombres, ApellidoPaterno, ApellidoMaterno, DNI, FechaNacimiento, Genero, Direccion, Celular, Email, Especialidad, GradoAcademico, FechaContratacion, Estado FROM Profesores WHERE ")

                Dim whereConditions As New List(Of String)
                Dim isNumeric As Boolean = False
                Dim numericValue As Integer

                ' Intentamos parsear el término de búsqueda como un número entero
                If Integer.TryParse(termino, numericValue) Then
                    isNumeric = True
                End If

                ' --- Condiciones de búsqueda para campos de texto (siempre con LIKE para coincidencias parciales) ---
                whereConditions.Add("Nombres LIKE @TerminoText")
                whereConditions.Add("ApellidoPaterno LIKE @TerminoText")
                whereConditions.Add("ApellidoMaterno LIKE @TerminoText")
                whereConditions.Add("Especialidad LIKE @TerminoText")

                ' --- Manejo específico para ID_Profesor y DNI ---
                If isNumeric Then

                    whereConditions.Add("ID_Profesor = @TerminoExactNumeric")

                    whereConditions.Add("DNI = @TerminoExactString")
                Else
                    whereConditions.Add("DNI LIKE @TerminoText")
                End If

                ' Unimos todas las condiciones con OR
                queryBuilder.Append(String.Join(" OR ", whereConditions))

                Using command As New SqlCommand(queryBuilder.ToString(), connection)
                    ' Parámetro para las búsquedas LIKE (siempre con comodines)
                    command.Parameters.AddWithValue("@TerminoText", "%" & termino & "%")

                    If isNumeric Then
                        ' Parámetro para las búsquedas numéricas exactas
                        command.Parameters.AddWithValue("@TerminoExactNumeric", numericValue)
                        ' Parámetro para las búsquedas de string exactas (ej. DNI que es VARCHAR numérico)
                        command.Parameters.AddWithValue("@TerminoExactString", termino)
                    End If

                    connection.Open()
                    Dim dataAdapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    dgvProfesores.DataSource = Nothing
                    dgvProfesores.DataSource = dataTable
                    dgvProfesores.Refresh()

                    If dataTable.Rows.Count = 0 Then
                        MessageBox.Show("No se encontraron profesores que coincidan con la búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class