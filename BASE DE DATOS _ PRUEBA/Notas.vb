' Horario_vista.vb
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text ' Necesario para StringBuilder
Public Class Notas
    Private Sub Notas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                connection.Open()
            End Using
        Catch ex As SqlException
            MessageBox.Show($"Error al conectar con SQL Server:{Environment.NewLine}{ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al intentar conectar:{Environment.NewLine}{ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        LlenarDataGridView()
    End Sub

    Private Sub LlenarDataGridView()
        Try
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                Dim query As String = "SELECT  
                                N.ID_Nota,  
                                CONCAT(A.Nombres, ' ', A.ApellidoPaterno, ' ', A.ApellidoMaterno) AS NombreCompleto,  
                                A.GradoAcademico,  
                                C.NombreCurso,  
                                N.Parcial,  
                                N.Final,  
                                N.PC1,  
                                N.PC2,  
                                N.PC3,  
                                CAST(  
                                    (N.Parcial * 0.3) +  
                                    (N.Final * 0.3) +  
                                    ((N.PC1 + N.PC2 + N.PC3) / 3.0 * 0.4)  
                                AS DECIMAL(5,2)) AS PromedioFinal  
                               FROM Notas N  
                               INNER JOIN Alumnos A ON N.ID_Alumno = A.ID_Alumno  
                               INNER JOIN Curso C ON N.ID_Curso = C.ID_Curso  
                               WHERE A.GradoAcademico = C.GradoAsociado"

                Using command As New SqlCommand(query, connection)
                    Dim dataAdapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    ' Enlazar DataGridView con los datos
                    DgvNotas.DataSource = dataTable
                    DgvNotas.Refresh()

                    ' Configurar DataGridView
                    DgvNotas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                    DgvNotas.AllowUserToAddRows = False
                    DgvNotas.Columns("FK_ID_Alumno").Visible = False
                    DgvNotas.Columns("FK_ID_Curso").Visible = False
                End Using
            End Using
        Catch ex As SqlException
            MessageBox.Show($"Error al conectar con SQL Server:{Environment.NewLine}{ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error inesperado al intentar conectar:{Environment.NewLine}{ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class