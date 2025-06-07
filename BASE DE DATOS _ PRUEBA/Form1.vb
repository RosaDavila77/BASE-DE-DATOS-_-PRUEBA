Imports System.Data.SqlClient

Public Class Form1
    Private Sub btnAlumnos_Click(sender As Object, e As EventArgs) Handles btnAlumnos.Click
        Estudiante_vista.Show()
        Me.Hide()
    End Sub

    Private Sub btnProfesores_Click(sender As Object, e As EventArgs) Handles btnProfesores.Click
        Profesor_vista.Show()
        Me.Hide()
    End Sub

    Private Sub btnCursos_Click(sender As Object, e As EventArgs) Handles btnCursos.Click
        Cursos_vista.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Hasta pronto. EPIES")
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Intentamos abrir una conexión usando la cadena de tu módulo
            Using connection As New SqlConnection(DbConnection.GetConnectionString())
                connection.Open()
                MessageBox.Show("¡Conexión a la base de datos exitosa!", "Conexión Establecida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

        Catch ex As SqlException
            ' Si hay un error específico de SQL Server (ej. servidor no encontrado, credenciales incorrectas)
            MessageBox.Show($"Error al conectar con SQL Server:{Environment.NewLine}{ex.Message}{Environment.NewLine}Código de error: {ex.Number}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Si hay cualquier otro tipo de error
            MessageBox.Show($"Ocurrió un error inesperado al intentar conectar:{Environment.NewLine}{ex.Message}", "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHorarios_Click(sender As Object, e As EventArgs) Handles btnHorarios.Click
        Horario_vista.Show()
        Me.Hide()
    End Sub
    Private Sub btnNotas_Click(sender As Object, e As EventArgs) Handles btnNotas.Click
        Notas.Show()
        Me.Hide()
    End Sub
End Class