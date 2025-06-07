' Cursos_vista.vb
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text ' Necesario para StringBuilder

Public Class Cursos_vista

    Private Sub Cursos_vista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                connection.Open()
                MessageBox.Show("¡Conexión a la base de datos exitosa para Formulario de Cursos!", "Conexión Establecida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As SqlException
            MessageBox.Show($"Error al conectar con SQL Server:{Environment.NewLine}{ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al intentar conectar:{Environment.NewLine}{ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        CargarCursosEnDataGridView()

        ' Configurar el texto de sugerencia para la búsqueda
        txtBusquedaCurso_Leave(Nothing, Nothing) ' Llamada inicial para establecer el texto de sugerencia
    End Sub

    Private Sub CargarCursosEnDataGridView()
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                ' Consulta SQL para cargar todas las columnas relevantes de la tabla Cursos
                Using command As New SqlCommand("SELECT ID_Curso, NombreCurso, NivelEducativo, GradoAsociado, Descripcion, HorasSemanales, Estado FROM Cursos", connection)
                    connection.Open()
                    Dim dataAdapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    dgvCursos.DataSource = Nothing
                    dgvCursos.DataSource = dataTable
                    dgvCursos.Refresh()

                    ' Autoajustar las columnas para mejor visualización
                    dgvCursos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                    dgvCursos.AllowUserToAddRows = False ' Para que no se muestre la fila vacía al final

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al cargar cursos: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===================================================
    ' Lógica para el Botón "Añadir Curso"
    ' ===================================================

    Private Sub btnAñadir_curso_Click(sender As Object, e As EventArgs) Handles btnAñadir_curso.Click
        Dim formAnadir As New Cursos()
        AddHandler formAnadir.CursoGuardado, AddressOf Me.OnCursoGuardado
        formAnadir.ShowDialog()
    End Sub

    Private Sub OnCursoGuardado(sender As Object, e As EventArgs)
        CargarCursosEnDataGridView()
        MessageBox.Show("¡El DataGridView ha sido actualizado con el nuevo curso!", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' =================================================================
    ' Manejo de Clics en las Columnas del DataGridView (Editar/Eliminar)
    ' =================================================================

    Private Sub dgvCursos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCursos.CellContentClick
        ' Asegúrate de que no es la fila de encabezado ni una fila nueva vacía
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvCursos.Rows.Count Then
            Dim columnaClicada As DataGridViewColumn = dgvCursos.Columns(e.ColumnIndex)

            ' Usamos los nuevos nombres exactos de las columnas de botón
            If columnaClicada.Name = "ColEliminar" Then
                HandleEliminarCurso(e.RowIndex)
            ElseIf columnaClicada.Name = "ColEditar" Then
                HandleEditarCurso(e.RowIndex)
            End If
        End If
    End Sub

    ' =========================================
    ' Lógica de Eliminación de Cursos
    ' =========================================

    Private Sub HandleEliminarCurso(rowIndex As Integer)
        Dim idCursoAEliminar As Integer
        Try
            ' Obtenemos el ID del curso de la fila clicada.
            ' Asumimos que la columna 'ID_Curso' existe y contiene el ID numérico.
            If dgvCursos.Rows(rowIndex).Cells("ID_Curso").Value IsNot DBNull.Value Then
                idCursoAEliminar = CInt(dgvCursos.Rows(rowIndex).Cells("ID_Curso").Value)
            Else
                MessageBox.Show("El ID del curso no es válido en la fila seleccionada. No se puede eliminar.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al obtener el ID del curso para eliminar: {ex.Message}{Environment.NewLine}Asegúrese de que la columna 'ID_Curso' exista en el DataGridView y contenga valores numéricos.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim resultado As DialogResult = MessageBox.Show($"¿Está seguro que desea eliminar el curso con ID: {idCursoAEliminar}? Esta acción no se puede deshacer.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            Try
                Using connection As New SqlConnection(DbConnection.GetConnectionString())
                    Using command As New SqlCommand("Cursos_Eliminar", connection)
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@ID_Curso", idCursoAEliminar)

                        connection.Open()
                        Dim filasAfectadas As Integer = command.ExecuteNonQuery()

                        If filasAfectadas > 0 Then

                        Else
                            'MessageBox.Show("No se encontró el curso con el ID especificado en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            MessageBox.Show("Curso eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            CargarCursosEnDataGridView() ' Recargar el DataGridView para actualizar visualmente
                        End If
                    End Using
                End Using
            Catch ex As SqlException
                If ex.Number = 547 Then
                    MessageBox.Show("Error: No se puede eliminar el curso porque tiene registros relacionados (ej. inscripciones, asignaciones).", "Error de Integridad Referencial", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show($"Error de base de datos al eliminar el curso: {ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Ocurrió un error inesperado al eliminar el curso: {ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ===================================
    ' Lógica de Edición de Cursos
    ' ===================================

    Private Sub HandleEditarCurso(rowIndex As Integer)
        Dim idCursoAEditar As Integer
        Try
            ' Obtenemos el ID del curso de la fila clicada.
            ' Asumimos que la columna 'ID_Curso' existe y contiene el ID numérico.
            If dgvCursos.Rows(rowIndex).Cells("ID_Curso").Value IsNot DBNull.Value Then
                idCursoAEditar = CInt(dgvCursos.Rows(rowIndex).Cells("ID_Curso").Value)
            Else
                MessageBox.Show("El ID del curso no es válido en la fila seleccionada. No se puede editar.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al obtener el ID del curso para editar: {ex.Message}{Environment.NewLine}Asegúrese de que la columna 'ID_Curso' exista en el DataGridView y contenga valores numéricos.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim formEditar As New Cursos_editar(idCursoAEditar)
        AddHandler formEditar.CursoEditado, AddressOf Me.OnCursoEditado
        formEditar.ShowDialog()
    End Sub

    Private Sub OnCursoEditado(sender As Object, e As EventArgs)
        CargarCursosEnDataGridView()
        MessageBox.Show("¡El DataGridView ha sido actualizado con los cambios del curso!", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============================
    ' Lógica para la Búsqueda
    ' ============================

    Private Sub btnBuscarCurso_Click(sender As Object, e As EventArgs) Handles btnBuscarCurso.Click
        Dim terminoBusqueda As String = txtBusquedaCurso.Text.Trim()

        If String.IsNullOrWhiteSpace(terminoBusqueda) OrElse terminoBusqueda = "Buscar ID, Nombre del Curso, Descripción" Then
            CargarCursosEnDataGridView()
        Else
            RealizarBusquedaCursos(terminoBusqueda)
        End If
    End Sub

    Private Sub RealizarBusquedaCursos(termino As String)
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Dim queryBuilder As New System.Text.StringBuilder()
                queryBuilder.Append("SELECT ID_Curso, NombreCurso, NivelEducativo, GradoAsociado, Descripcion, HorasSemanales, Estado FROM Cursos WHERE ")

                Dim whereConditions As New List(Of String)
                Dim isNumeric As Boolean = False
                Dim numericValue As Integer

                If Integer.TryParse(termino, numericValue) Then
                    isNumeric = True
                End If

                whereConditions.Add("NombreCurso LIKE @TerminoText")
                whereConditions.Add("Descripcion LIKE @TerminoText")
                whereConditions.Add("NivelEducativo LIKE @TerminoText")
                whereConditions.Add("GradoAsociado LIKE @TerminoText")
                whereConditions.Add("Estado LIKE @TerminoText")

                If isNumeric Then
                    whereConditions.Add("ID_Curso = @TerminoExactNumeric")
                    whereConditions.Add("HorasSemanales = @TerminoExactNumericDecimal")
                End If

                queryBuilder.Append(String.Join(" OR ", whereConditions))

                Using command As New SqlCommand(queryBuilder.ToString(), connection)
                    command.Parameters.AddWithValue("@TerminoText", "%" & termino & "%")

                    If isNumeric Then
                        command.Parameters.AddWithValue("@TerminoExactNumeric", numericValue)
                        command.Parameters.AddWithValue("@TerminoExactNumericDecimal", CDec(numericValue))
                    End If

                    connection.Open()
                    Dim dataAdapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    dgvCursos.DataSource = Nothing
                    dgvCursos.DataSource = dataTable
                    dgvCursos.Refresh()
                    dgvCursos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                    dgvCursos.AllowUserToAddRows = False


                    If dataTable.Rows.Count = 0 Then
                        MessageBox.Show("No se encontraron cursos que coincidan con la búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================================
    ' Lógica para el Texto de Sugerencia en la Búsqueda
    ' ============================================================

    Private Sub txtBusquedaCurso_Enter(sender As Object, e As EventArgs) Handles txtBusquedaCurso.Enter
        If txtBusquedaCurso.Text = "Buscar ID, Nombre del Curso, Descripción" Then
            txtBusquedaCurso.Text = ""
            txtBusquedaCurso.ForeColor = System.Drawing.SystemColors.WindowText
        End If
    End Sub

    Private Sub txtBusquedaCurso_Leave(sender As Object, e As EventArgs) Handles txtBusquedaCurso.Leave
        If String.IsNullOrWhiteSpace(txtBusquedaCurso.Text) Then
            txtBusquedaCurso.Text = "Buscar ID, Nombre del Curso, Descripción"
            txtBusquedaCurso.ForeColor = System.Drawing.SystemColors.GrayText
        End If
    End Sub

    ' ==============================================
    ' Botón Cerrar
    ' ==============================================

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Form1.Show()
        Me.Close()
    End Sub

End Class