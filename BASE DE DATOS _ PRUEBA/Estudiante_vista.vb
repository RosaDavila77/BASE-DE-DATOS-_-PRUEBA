Imports System.Data.SqlClient
Imports System.Data
Imports System.Text ' Necesario para StringBuilder

Public Class Estudiante_vista

    Private Sub Estudiante_vista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                connection.Open()
                MessageBox.Show("¡Conexión a la base de datos exitosa para el Formulario de Estudiantes!", "Conexión Establecida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As SqlException
            MessageBox.Show($"Error al conectar con SQL Server:{Environment.NewLine}{ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al intentar conectar:{Environment.NewLine}{ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        CargarComboboxesEstudiante()
        CargarEstudiantesEnDataGridView()

        ' Configurar el texto de sugerencia para la búsqueda
        txtBusquedaEstudiante_Leave(Nothing, Nothing) ' Llamada inicial para establecer el texto de sugerencia
    End Sub

    Private Sub CargarEstudiantesEnDataGridView(Optional gradoFiltro As String = "Todos", Optional seccionFiltro As String = "Todas", Optional terminoBusqueda As String = "")
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Dim queryBuilder As New System.Text.StringBuilder()
                queryBuilder.Append("SELECT A.ID_Alumno, A.Nombres, A.ApellidoPaterno, A.ApellidoMaterno, A.FechaNacimiento, A.DNI, A.Genero, A.Direccion, A.GradoAcademico, A.Seccion, A.Estado, A.FechaInscripcion, ")
                queryBuilder.Append("AP.Nombres AS ApoderadoNombres, AP.ApellidoPaterno AS ApoderadoApellidoPaterno, AP.DNI AS ApoderadoDNI ")
                queryBuilder.Append("FROM Alumnos AS A LEFT JOIN Apoderados AS AP ON A.FK_ApoderadoID = AP.ID_Apoderado")

                Dim whereConditions As New List(Of String)
                Dim isNumeric As Boolean = False
                Dim numericValue As Integer

                ' Indicadores para saber si se aplicó algún filtro real
                Dim filtroAplicado As Boolean = False

                ' Aplicar filtro por Grado
                ' Ahora verificamos si el valor de gradoFiltro es diferente al texto por defecto "Grado"
                If gradoFiltro <> "Todos" AndAlso gradoFiltro <> "Grado" Then
                    whereConditions.Add("A.GradoAcademico = @Grado")
                    filtroAplicado = True
                End If

                ' Aplicar filtro por Sección
                ' Ahora verificamos si el valor de seccionFiltro es diferente al texto por defecto "Seccion"
                If seccionFiltro <> "Todas" AndAlso seccionFiltro <> "Seccion" Then
                    whereConditions.Add("A.Seccion = @Seccion")
                    filtroAplicado = True
                End If

                ' Aplicar filtro por término de búsqueda (si se proporciona)
                If Not String.IsNullOrWhiteSpace(terminoBusqueda) AndAlso terminoBusqueda <> "Buscar Nombres, Apellidos, ID" Then
                    If Integer.TryParse(terminoBusqueda, numericValue) Then
                        isNumeric = True
                    End If

                    Dim searchConditions As New List(Of String)
                    searchConditions.Add("A.Nombres LIKE @TerminoText")
                    searchConditions.Add("A.ApellidoPaterno LIKE @TerminoText")
                    searchConditions.Add("A.ApellidoMaterno LIKE @TerminoText")
                    searchConditions.Add("AP.Nombres LIKE @TerminoText") ' Buscar también en nombre del apoderado
                    searchConditions.Add("AP.ApellidoPaterno LIKE @TerminoText") ' Buscar también en apellido del apoderado

                    If isNumeric Then
                        searchConditions.Add("A.ID_Alumno = @TerminoExactNumeric")
                        searchConditions.Add("A.DNI = @TerminoExactString") ' DNI es VARCHAR, pero puede ser numérico
                        searchConditions.Add("AP.DNI = @TerminoExactString") ' DNI apoderado es VARCHAR, pero puede ser numérico
                    Else
                        searchConditions.Add("A.DNI LIKE @TerminoText")
                        searchConditions.Add("AP.DNI LIKE @TerminoText")
                    End If
                    whereConditions.Add($"({String.Join(" OR ", searchConditions)})")
                    filtroAplicado = True ' Se aplicó un filtro de búsqueda
                End If

                If whereConditions.Any() Then
                    queryBuilder.Append(" WHERE ")
                    queryBuilder.Append(String.Join(" AND ", whereConditions))
                End If

                Using command As New SqlCommand(queryBuilder.ToString(), connection)
                    If gradoFiltro <> "Todos" AndAlso gradoFiltro <> "Grado" Then
                        command.Parameters.AddWithValue("@Grado", gradoFiltro)
                    End If
                    If seccionFiltro <> "Todas" AndAlso seccionFiltro <> "Seccion" Then
                        command.Parameters.AddWithValue("@Seccion", seccionFiltro)
                    End If
                    If Not String.IsNullOrWhiteSpace(terminoBusqueda) AndAlso terminoBusqueda <> "Buscar Nombres, Apellidos, ID" Then
                        command.Parameters.AddWithValue("@TerminoText", "%" & terminoBusqueda & "%")
                        If isNumeric Then
                            command.Parameters.AddWithValue("@TerminoExactNumeric", numericValue)
                            command.Parameters.AddWithValue("@TerminoExactString", terminoBusqueda)
                        End If
                    End If

                    connection.Open()
                    Dim dataAdapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    dgvEstudiantes.DataSource = Nothing
                    dgvEstudiantes.DataSource = dataTable
                    dgvEstudiantes.Refresh()

                    dgvEstudiantes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                    dgvEstudiantes.AllowUserToAddRows = False

                    ' Mostrar mensaje solo si se aplicó un filtro real y no se encontraron resultados
                    If dataTable.Rows.Count = 0 AndAlso filtroAplicado Then
                        MessageBox.Show("No se encontraron estudiantes que coincidan con los filtros y/o la búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al cargar estudiantes: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' =========================================================
    ' LÓGICA PARA EL BOTON AÑADIR ESTUDIANTE
    ' =========================================================


    Private Sub btnAnadirEstudiante_Click(sender As Object, e As EventArgs) Handles btnAnadirEstudiante.Click
        ' Creamos una instancia del formulario Estudiante para añadir un nuevo alumno
        Dim formAnadirEstudiante As New Estudiante()

        ' Nos suscribimos al evento que Estudiante disparará cuando se guarde el alumno
        AddHandler formAnadirEstudiante.AlumnoGuardado, AddressOf Me.OnAlumnoGuardado

        ' Mostramos el formulario de manera modal
        formAnadirEstudiante.ShowDialog()
    End Sub

    ' Manejador del evento cuando un alumno ha sido guardado/editado en Estudiante
    Private Sub OnAlumnoGuardado(sender As Object, e As EventArgs)
        CargarEstudiantesEnDataGridView() ' Recargar los datos para ver los cambios
        MessageBox.Show("¡El DataGridView ha sido actualizado con el nuevo/modificado estudiante!", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub



    ' =========================================================
    ' Manejo de Clics en las Columnas del DataGridView (Editar/Eliminar)
    ' =========================================================


    Private Sub dgvEstudiantes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEstudiantes.CellContentClick
        ' Asegúrate de que no es la fila de encabezado ni una fila nueva vacía
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvEstudiantes.Rows.Count Then
            Dim columnaClicada As DataGridViewColumn = dgvEstudiantes.Columns(e.ColumnIndex)

            ' Usa los nombres exactos de las columnas de botón
            If columnaClicada.Name = "colEliminar" Then
                HandleEliminarEstudiante(e.RowIndex)
            ElseIf columnaClicada.Name = "colEditar" Then
                HandleEditarEstudiante(e.RowIndex)
            End If
        End If
    End Sub


    '=========================================================
    ' **Lógica de Eliminación de Estudiantes**
    ' =========================================================


    Private Sub HandleEliminarEstudiante(rowIndex As Integer)
        Dim idAlumnoAEliminar As Integer
        Try
            ' Obtenemos el ID del alumno de la fila clicada.
            If dgvEstudiantes.Rows(rowIndex).Cells("ID_Alumno").Value IsNot DBNull.Value Then
                idAlumnoAEliminar = CInt(dgvEstudiantes.Rows(rowIndex).Cells("ID_Alumno").Value)
            Else
                MessageBox.Show("El ID del alumno no es válido en la fila seleccionada. No se puede eliminar.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al obtener el ID del alumno para eliminar: {ex.Message}{Environment.NewLine}Asegúrese de que la columna 'ID_Alumno' exista en el DataGridView y contenga valores numéricos.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim resultado As DialogResult = MessageBox.Show($"¿Está seguro que desea eliminar al estudiante con ID: {idAlumnoAEliminar}? Esta acción no se puede deshacer.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            Try
                Using connection As New SqlConnection(DbConnection.GetConnectionString())
                    Using command As New SqlCommand("Alumnos_Eliminar", connection)
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@ID_Alumno", idAlumnoAEliminar)

                        connection.Open()
                        Dim filasAfectadas As Integer = command.ExecuteNonQuery()

                        If filasAfectadas > 0 Then
                            'Metodo opcional
                        Else
                            'MessageBox.Show("No se encontró el estudiante con el ID especificado en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            MessageBox.Show("Estudiante eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            CargarEstudiantesEnDataGridView() ' Recargar el DataGridView para actualizar visualmente
                        End If
                    End Using
                End Using
            Catch ex As SqlException
                If ex.Number = 547 Then ' Error de integridad referencial
                    MessageBox.Show("Error: No se puede eliminar el estudiante porque tiene registros relacionados (ej. inscripciones a cursos, pagos).", "Error de Integridad Referencial", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show($"Error de base de datos al eliminar el estudiante: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Ocurrió un error inesperado al eliminar el estudiante: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub




    ' =========================================================
    ' **Lógica de Edición de Estudiantes**
    ' =========================================================


    'Para la edición, usamos el mismo formulario `Estudiante` pero con un constructor que recibe el ID. Esto es similar a cómo `Profesor_editar` y `Cursos_editar` funcionaban.

    Private Sub HandleEditarEstudiante(rowIndex As Integer)
        Dim idAlumnoAEditar As Integer
        Try
            ' Obtenemos el ID del alumno de la fila clicada.
            If dgvEstudiantes.Rows(rowIndex).Cells("ID_Alumno").Value IsNot DBNull.Value Then
                idAlumnoAEditar = CInt(dgvEstudiantes.Rows(rowIndex).Cells("ID_Alumno").Value)
            Else
                MessageBox.Show("El ID del alumno no es válido en la fila seleccionada. No se puede editar.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al obtener el ID del alumno para editar: {ex.Message}{Environment.NewLine}Asegúrese de que la columna 'ID_Alumno' exista en el DataGridView y contenga valores numéricos.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Creamos una instancia del formulario 'Estudiante' (asumiendo que tiene un constructor para edición)
        Dim formEditarEstudiante As New Estudiante(idAlumnoAEditar)

        ' Nos suscribimos a su evento de edición para saber cuándo refrescar el DataGridView
        AddHandler formEditarEstudiante.AlumnoGuardado, AddressOf Me.OnAlumnoGuardado

        formEditarEstudiante.ShowDialog() ' Mostrar el formulario de edición
    End Sub





    ' =========================================================
    ' ## **Lógica para la Búsqueda de Estudiantes**
    ' =========================================================




    Private Sub btnBuscarEstudiante_Click(sender As Object, e As EventArgs) Handles btnBuscarEstudiante.Click
        Dim terminoBusqueda As String = txtBusquedaEstudiante.Text.Trim()

        ' Obtener los valores de los ComboBox, si es el texto por defecto, pasamos "Todos" o "Todas"
        Dim selectedGrado As String = If(cboGrado.Text = cboGrado.Tag.ToString(), "Todos", cboGrado.Text.Trim())
        Dim selectedSeccion As String = If(cboSeccion.Text = cboSeccion.Tag.ToString(), "Todas", cboSeccion.Text.Trim())

        CargarEstudiantesEnDataGridView(selectedGrado, selectedSeccion, terminoBusqueda)
    End Sub




    Private Sub RealizarBusquedaEstudiantes(termino As String)
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Dim queryBuilder As New System.Text.StringBuilder()
                queryBuilder.Append("SELECT A.ID_Alumno, A.Nombres, A.ApellidoPaterno, A.ApellidoMaterno, A.FechaNacimiento, A.DNI, A.Genero, A.Direccion, A.GradoAcademico, A.Seccion, A.Estado, A.FechaInscripcion, ")
                queryBuilder.Append("AP.Nombres AS ApoderadoNombres, AP.ApellidoPaterno AS ApoderadoApellidoPaterno, AP.DNI AS ApoderadoDNI ")
                queryBuilder.Append("FROM Alumnos AS A LEFT JOIN Apoderados AS AP ON A.FK_ApoderadoID = AP.ID_Apoderado WHERE ")

                Dim whereConditions As New List(Of String)
                Dim isNumeric As Boolean = False
                Dim numericValue As Integer

                If Integer.TryParse(termino, numericValue) Then
                    isNumeric = True
                End If

                ' Condiciones de búsqueda para campos de texto (con LIKE para coincidencias parciales)
                whereConditions.Add("A.Nombres LIKE @TerminoText")
                whereConditions.Add("A.ApellidoPaterno LIKE @TerminoText")
                whereConditions.Add("A.ApellidoMaterno LIKE @TerminoText")
                whereConditions.Add("AP.Nombres LIKE @TerminoText") ' Buscar también en nombre del apoderado
                whereConditions.Add("AP.ApellidoPaterno LIKE @TerminoText") ' Buscar también en apellido del apoderado

                ' Manejo específico para ID_Alumno y DNI (si es numérico, búsqueda exacta)
                If isNumeric Then
                    whereConditions.Add("A.ID_Alumno = @TerminoExactNumeric")
                    whereConditions.Add("A.DNI = @TerminoExactString") ' DNI es VARCHAR, pero puede ser numérico
                    whereConditions.Add("AP.DNI = @TerminoExactString") ' DNI apoderado es VARCHAR, pero puede ser numérico
                Else
                    whereConditions.Add("A.DNI LIKE @TerminoText")
                    whereConditions.Add("AP.DNI LIKE @TerminoText")
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

                    dgvEstudiantes.DataSource = Nothing
                    dgvEstudiantes.DataSource = dataTable
                    dgvEstudiantes.Refresh()
                    dgvEstudiantes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                    dgvEstudiantes.AllowUserToAddRows = False


                    If dataTable.Rows.Count = 0 Then
                        MessageBox.Show("No se encontraron estudiantes que coincidan con la búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' =========================================================
    ' **Lógica para el Texto de Sugerencia en la Búsqueda**
    ' =========================================================



    Private Sub txtBusquedaEstudiante_Enter(sender As Object, e As EventArgs) Handles txtBusquedaEstudiante.Enter
        If txtBusquedaEstudiante.Text = "Buscar Nombres, Apellidos, ID" Then
            txtBusquedaEstudiante.Text = ""
            txtBusquedaEstudiante.ForeColor = System.Drawing.SystemColors.WindowText
        End If
    End Sub

    Private Sub txtBusquedaEstudiante_Leave(sender As Object, e As EventArgs) Handles txtBusquedaEstudiante.Leave
        If String.IsNullOrWhiteSpace(txtBusquedaEstudiante.Text) Then
            txtBusquedaEstudiante.Text = "Buscar Nombres, Apellidos, ID"
            txtBusquedaEstudiante.ForeColor = System.Drawing.SystemColors.GrayText
        End If
    End Sub



    ' =========================================================
    ' **Botón Cerrar**
    ' =========================================================


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        ' Asumiendo que Form1 es tu menú principal
        Form1.Show()
        Me.Close()
    End Sub









    '===================================
    ' FILTROS DE GRADO Y SECCION
    '=================================

    Private Sub CargarComboboxesEstudiante()

        ' Cargar Grados Académicos
        cboGrado.Items.Clear()
        cboGrado.Items.Add("Todos") ' Esta será la primera opción en la lista desplegable
        cboGrado.Items.Add("Inicial - 3 años")
        cboGrado.Items.Add("Inicial - 4 años")
        cboGrado.Items.Add("Inicial - 5 años")
        cboGrado.Items.Add("1ro Primaria")
        cboGrado.Items.Add("2do Primaria")
        cboGrado.Items.Add("3ro Primaria")
        cboGrado.Items.Add("4to Primaria")
        cboGrado.Items.Add("5to Primaria")
        cboGrado.Items.Add("6to Primaria")
        cboGrado.Items.Add("1ro Secundaria")
        cboGrado.Items.Add("2do Secundaria")
        cboGrado.Items.Add("3ro Secundaria")
        cboGrado.Items.Add("4to Secundaria")
        cboGrado.Items.Add("5to Secundaria")

        ' Establecer el texto por defecto y el índice de selección inicial
        cboGrado.Text = "Grado" ' <--- Nuevo: Texto por defecto visible
        cboGrado.Tag = "Grado" ' <--- Nuevo: Usaremos Tag para saber si es el texto por defecto
        cboGrado.ForeColor = System.Drawing.SystemColors.GrayText ' Color de texto de sugerencia


        ' Cargar Secciones
        cboSeccion.Items.Clear()
        cboSeccion.Items.Add("Todas") ' Esta será la primera opción en la lista desplegable
        cboSeccion.Items.Add("A")
        cboSeccion.Items.Add("B")
        cboSeccion.Items.Add("C")
        cboSeccion.Items.Add("D")

        ' Establecer el texto por defecto y el índice de selección inicial
        cboSeccion.Text = "Seccion" ' <--- Nuevo: Texto por defecto visible
        cboSeccion.Tag = "Seccion" ' <--- Nuevo: Usaremos Tag para saber si es el texto por defecto
        cboSeccion.ForeColor = System.Drawing.SystemColors.GrayText ' Color de texto de sugerencia
    End Sub







    Private Sub cboGrado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrado.SelectedIndexChanged
        ' Si el texto actual es el texto por defecto "Grado", no hacemos nada (evita un disparo indeseado al inicio)
        If cboGrado.Text = cboGrado.Tag.ToString() Then Return

        Dim selectedGrado As String = cboGrado.Text.Trim()
        Dim selectedSeccion As String = cboSeccion.Text.Trim()
        Dim searchTerm As String = txtBusquedaEstudiante.Text.Trim()

        CargarEstudiantesEnDataGridView(selectedGrado, selectedSeccion, searchTerm)
    End Sub

    Private Sub cboSeccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSeccion.SelectedIndexChanged
        ' Si el texto actual es el texto por defecto "Seccion", no hacemos nada (evita un disparo indeseado al inicio)
        If cboSeccion.Text = cboSeccion.Tag.ToString() Then Return

        Dim selectedGrado As String = cboGrado.Text.Trim()
        Dim selectedSeccion As String = cboSeccion.Text.Trim()
        Dim searchTerm As String = txtBusquedaEstudiante.Text.Trim()

        CargarEstudiantesEnDataGridView(selectedGrado, selectedSeccion, searchTerm)
    End Sub












End Class