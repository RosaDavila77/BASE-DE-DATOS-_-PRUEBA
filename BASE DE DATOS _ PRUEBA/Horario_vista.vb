' Horario_vista.vb
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text ' Necesario para StringBuilder

Public Class Horario_vista

    ' Constante para el texto de sugerencia
    Private Const SUGGESTION_TEXT As String = "Buscar ID, Profesor, Curso"

    Private Sub Horario_vista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                connection.Open()
                ' Remuevo el MessageBox de conexión exitosa para evitar spam al usuario.
                ' MessageBox.Show("¡Conexión a la base de datos exitosa para el Formulario de Horario!", "Conexión Establecida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As SqlException
            MessageBox.Show($"Error al conectar con SQL Server:{Environment.NewLine}{ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al intentar conectar:{Environment.NewLine}{ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        CargarHorarioEnDataGridView()
        ' Configurar el texto de sugerencia para la búsqueda al cargar el formulario
        SetSearchBoxSuggestion()
    End Sub

    Private Sub CargarHorarioEnDataGridView()
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                ' Consulta SQL para cargar todas las columnas relevantes de la tabla Horarios,
                ' incluyendo Nombres de Curso y Profesor.
                Dim query As String = "SELECT H.ID_Horario, C.NombreCurso, " &
                                      "P.Nombres + ' ' + P.ApellidoPaterno AS NombreCompletoProfesor, " &
                                      "H.DiaSemana, H.HoraInicio, H.HoraFin, H.Salon, H.PeriodoAcademico, " &
                                      "H.FK_CursoID, H.FK_ProfesorID " & ' Incluir FKs para pasar a edición/eliminación
                                      "FROM Horarios AS H " &
                                      "JOIN Cursos AS C ON H.FK_CursoID = C.ID_Curso " &
                                      "JOIN Profesores AS P ON H.FK_ProfesorID = P.ID_Profesor"
                Using command As New SqlCommand(query, connection)
                    connection.Open()
                    Dim dataAdapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    dgvHorarios.DataSource = Nothing
                    dgvHorarios.DataSource = dataTable
                    dgvHorarios.Refresh()

                    ' Autoajustar las columnas para mejor visualización
                    dgvHorarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                    dgvHorarios.AllowUserToAddRows = False ' Para que no se muestre la fila vacía al final

                    ' Opcional: Ocultar columnas FK si no se necesitan directamente en la vista
                    If dgvHorarios.Columns.Contains("FK_CursoID") Then
                        dgvHorarios.Columns("FK_CursoID").Visible = False
                    End If
                    If dgvHorarios.Columns.Contains("FK_ProfesorID") Then
                        dgvHorarios.Columns("FK_ProfesorID").Visible = False
                    End If

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al cargar Horarios: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '====================================================
    ' Lógica para el Botón "Añadir Horario"
    '====================================================


    Private Sub btnAnadirHorario_Click(sender As Object, e As EventArgs) Handles btnAnadirHorario.Click
        ' Abrir el formulario Horario para añadir un nuevo horario
        Dim formAnadirHorario As New Horario()
        AddHandler formAnadirHorario.HorarioGuardado, AddressOf Me.OnHorarioGuardado
        formAnadirHorario.ShowDialog()
    End Sub

    Private Sub OnHorarioGuardado(sender As Object, e As EventArgs)
        CargarHorarioEnDataGridView()
        MessageBox.Show("¡El DataGridView de Horarios ha sido actualizado!", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    '====================================================
    ' Manejo de Clics en las Columnas del DataGridView (Editar/Eliminar)
    '====================================================



    Private Sub dgvHorarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHorarios.CellContentClick
        ' Asegúrate de que no es la fila de encabezado ni una fila nueva vacía
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvHorarios.Rows.Count Then
            Dim columnaClicada As DataGridViewColumn = dgvHorarios.Columns(e.ColumnIndex)

            ' Obtener el ID_Horario de la fila seleccionada
            Dim idHorarioSeleccionado As Integer = CInt(dgvHorarios.Rows(e.RowIndex).Cells("ID_Horario").Value)

            ' ¡CORREGIDO! Nombres de columna en minúsculas
            If columnaClicada.Name = "colEliminar" Then
                HandleEliminarHorario(idHorarioSeleccionado)
            ElseIf columnaClicada.Name = "colEditar" Then
                HandleEditarHorario(idHorarioSeleccionado)
            End If
        End If
    End Sub

    '====================================================
    ' Lógica de Eliminación de Horario
    '====================================================


    Private Sub HandleEliminarHorario(idHorario As Integer)
        Dim resultado As DialogResult = MessageBox.Show($"¿Está seguro que desea eliminar el horario con ID: {idHorario}? Esta acción no se puede deshacer.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            Try
                Using connection As New SqlConnection(DbConnection.GetConnectionString())
                    Using command As New SqlCommand("Horarios_Eliminar", connection) ' Asegúrate que este SP exista en tu DB
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@ID_Horario", idHorario)

                        connection.Open()
                        Dim filasAfectadas As Integer = command.ExecuteNonQuery()

                        If filasAfectadas > 0 Then
                            'hereeeeeee
                        Else
                            'MessageBox.Show("No se encontró el horario con el ID especificado en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            MessageBox.Show("Horario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            CargarHorarioEnDataGridView() ' Recargar el DataGridView para actualizar visualmente
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Ocurrió un error al eliminar el horario: {ex.Message}", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    '====================================================
    ' ## Lógica de Edición de Horario
    '====================================================


    Private Sub HandleEditarHorario(idHorario As Integer)
        ' Abrir el formulario Horario_editar (o Horario en modo edición) pasando el ID del horario
        Dim formEditarHorario As New Horario_editar(idHorario) ' Usamos un formulario Horario_editar separado
        AddHandler formEditarHorario.HorarioEditado, AddressOf Me.OnHorarioGuardado ' Usamos el mismo manejador de evento para refrescar
        formEditarHorario.ShowDialog()
    End Sub

    '====================================================
    ' ## Lógica para la Búsqueda
    '====================================================



    Private Sub btnBuscarHorario_Click(sender As Object, e As EventArgs) Handles btnBuscarHorario.Click
        Dim terminoBusqueda As String = txtBusquedaHorario.Text.Trim()

        ' Si el texto es el de sugerencia, o está vacío, recarga todo.
        If String.IsNullOrWhiteSpace(terminoBusqueda) OrElse terminoBusqueda = SUGGESTION_TEXT Then
            CargarHorarioEnDataGridView()
        Else
            RealizarBusquedaHorario(terminoBusqueda)
        End If
    End Sub

    Private Sub RealizarBusquedaHorario(termino As String)
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Dim queryBuilder As New System.Text.StringBuilder()
                queryBuilder.Append("SELECT H.ID_Horario, C.NombreCurso, " &
                                    "P.Nombres + ' ' + P.ApellidoPaterno AS NombreCompletoProfesor, " &
                                    "H.DiaSemana, H.HoraInicio, H.HoraFin, H.Salon, H.PeriodoAcademico, " &
                                    "H.FK_CursoID, H.FK_ProfesorID " &
                                    "FROM Horarios AS H " &
                                    "JOIN Cursos AS C ON H.FK_CursoID = C.ID_Curso " &
                                    "JOIN Profesores AS P ON H.FK_ProfesorID = P.ID_Profesor " &
                                    "WHERE ")

                Dim whereConditions As New List(Of String)
                Dim isNumeric As Boolean = False
                Dim numericValue As Integer

                If Integer.TryParse(termino, numericValue) Then
                    isNumeric = True
                End If

                ' Criterios de búsqueda por texto
                whereConditions.Add("C.NombreCurso LIKE @TerminoText")
                whereConditions.Add("P.Nombres LIKE @TerminoText")
                whereConditions.Add("P.ApellidoPaterno LIKE @TerminoText")
                whereConditions.Add("H.DiaSemana LIKE @TerminoText")
                whereConditions.Add("H.Salon LIKE @TerminoText")
                whereConditions.Add("H.PeriodoAcademico LIKE @TerminoText")

                ' Criterios de búsqueda por ID si es numérico
                If isNumeric Then
                    whereConditions.Add("H.ID_Horario = @TerminoExactNumeric")
                End If

                queryBuilder.Append(String.Join(" OR ", whereConditions))

                Using command As New SqlCommand(queryBuilder.ToString(), connection)
                    command.Parameters.AddWithValue("@TerminoText", "%" & termino & "%")

                    If isNumeric Then
                        command.Parameters.AddWithValue("@TerminoExactNumeric", numericValue)
                    End If

                    connection.Open()
                    Dim dataAdapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    dgvHorarios.DataSource = Nothing
                    dgvHorarios.DataSource = dataTable
                    dgvHorarios.Refresh()
                    dgvHorarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                    dgvHorarios.AllowUserToAddRows = False

                    ' Ocultar columnas FK si no se necesitan directamente en la vista
                    If dgvHorarios.Columns.Contains("FK_CursoID") Then
                        dgvHorarios.Columns("FK_CursoID").Visible = False
                    End If
                    If dgvHorarios.Columns.Contains("FK_ProfesorID") Then
                        dgvHorarios.Columns("FK_ProfesorID").Visible = False
                    End If

                    If dataTable.Rows.Count = 0 Then
                        MessageBox.Show("No se encontraron Horarios que coincidan con la búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al realizar la búsqueda de Horarios: {ex.Message}", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '====================================================
    ' ## Lógica para el Texto de Sugerencia en la Búsqueda
    '====================================================



    ' Método para establecer el texto de sugerencia
    Private Sub SetSearchBoxSuggestion()
        If String.IsNullOrWhiteSpace(txtBusquedaHorario.Text) OrElse txtBusquedaHorario.Text = SUGGESTION_TEXT Then
            txtBusquedaHorario.Text = SUGGESTION_TEXT
            txtBusquedaHorario.ForeColor = System.Drawing.SystemColors.GrayText
        End If
    End Sub

    Private Sub txtBusquedaHorario_Enter(sender As Object, e As EventArgs) Handles txtBusquedaHorario.Enter
        If txtBusquedaHorario.Text = SUGGESTION_TEXT Then
            txtBusquedaHorario.Text = ""
            txtBusquedaHorario.ForeColor = System.Drawing.SystemColors.WindowText
        End If
    End Sub

    Private Sub txtBusquedaHorario_Leave(sender As Object, e As EventArgs) Handles txtBusquedaHorario.Leave
        SetSearchBoxSuggestion() ' Llama al método para restablecer el texto de sugerencia
    End Sub

    '====================================================
    '     Botón Cerrar
    '====================================================


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        ' Asumo que Form1 es tu menú principal. Si no, ajusta aquí.
        Form1.Show()
        Me.Close()
    End Sub

End Class