Imports System.Data.SqlClient ' Asegúrate de tener esta importación

Public Class Apoderados
    Private _formularioEstudiante As Estudiante ' Referencia al formulario Estudiante

    ' Constructor que recibe la instancia del formulario Estudiante
    Public Sub New(formularioEstudiante As Estudiante)
        InitializeComponent()
        _formularioEstudiante = formularioEstudiante
    End Sub

    Private Sub Apoderados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Rellenar los campos del apoderado con los datos guardados en las propiedades de Estudiante
        ' Esto es crucial para la funcionalidad "Atrás" y "Editar"
        txtApoderadoNombres.Text = _formularioEstudiante.ApoderadoNombres
        txtApoderadoApellidoPaterno.Text = _formularioEstudiante.ApoderadoApellidoPaterno
        txtApoderadoApellidoMaterno.Text = _formularioEstudiante.ApoderadoApellidoMaterno
        txtApoderadoDNI.Text = _formularioEstudiante.ApoderadoDNI
        txtApoderadoParentesco.Text = _formularioEstudiante.ApoderadoParentesco
        txtApoderadoCelular.Text = If(String.IsNullOrWhiteSpace(_formularioEstudiante.ApoderadoCelular), "", _formularioEstudiante.ApoderadoCelular)
        txtApoderadoEmail.Text = If(String.IsNullOrWhiteSpace(_formularioEstudiante.ApoderadoEmail), "", _formularioEstudiante.ApoderadoEmail)
        txtApoderadoDireccion.Text = If(String.IsNullOrWhiteSpace(_formularioEstudiante.ApoderadoDireccion), "", _formularioEstudiante.ApoderadoDireccion)
        txtApoderadoDistrito.Text = If(String.IsNullOrWhiteSpace(_formularioEstudiante.ApoderadoDistrito), "", _formularioEstudiante.ApoderadoDistrito)
        txtApoderadoProvincia.Text = If(String.IsNullOrWhiteSpace(_formularioEstudiante.ApoderadoProvincia), "", _formularioEstudiante.ApoderadoProvincia)
        txtApoderadoDepartamento.Text = If(String.IsNullOrWhiteSpace(_formularioEstudiante.ApoderadoDepartamento), "", _formularioEstudiante.ApoderadoDepartamento)
    End Sub

    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        ' --- 1. Recopilar los datos del apoderado y guardarlos en las propiedades del formulario Estudiante ---
        _formularioEstudiante.ApoderadoNombres = txtApoderadoNombres.Text.Trim()
        _formularioEstudiante.ApoderadoApellidoPaterno = txtApoderadoApellidoPaterno.Text.Trim()
        _formularioEstudiante.ApoderadoApellidoMaterno = txtApoderadoApellidoMaterno.Text.Trim()
        _formularioEstudiante.ApoderadoDNI = txtApoderadoDNI.Text.Trim()
        _formularioEstudiante.ApoderadoParentesco = txtApoderadoParentesco.Text.Trim()
        _formularioEstudiante.ApoderadoCelular = If(String.IsNullOrWhiteSpace(txtApoderadoCelular.Text), Nothing, txtApoderadoCelular.Text.Trim())
        _formularioEstudiante.ApoderadoEmail = If(String.IsNullOrWhiteSpace(txtApoderadoEmail.Text), Nothing, txtApoderadoEmail.Text.Trim())
        _formularioEstudiante.ApoderadoDireccion = If(String.IsNullOrWhiteSpace(txtApoderadoDireccion.Text), Nothing, txtApoderadoDireccion.Text.Trim())
        _formularioEstudiante.ApoderadoDistrito = If(String.IsNullOrWhiteSpace(txtApoderadoDistrito.Text), Nothing, txtApoderadoDistrito.Text.Trim())
        _formularioEstudiante.ApoderadoProvincia = If(String.IsNullOrWhiteSpace(txtApoderadoProvincia.Text), Nothing, txtApoderadoProvincia.Text.Trim())
        _formularioEstudiante.ApoderadoDepartamento = If(String.IsNullOrWhiteSpace(txtApoderadoDepartamento.Text), Nothing, txtApoderadoDepartamento.Text.Trim())

        ' --- 2. Mostrar el formulario Estudiante y ocultar el actual ---
        _formularioEstudiante.RellenarControlesDesdePropiedades() ' Esto asegura que si se cambia algo en Estudiante y se regresa, no se pierda
        _formularioEstudiante.Show()
        Me.Close() ' Cerrar el formulario Apoderados
    End Sub

    Private Sub btnGuardarFinal_Click(sender As Object, e As EventArgs) Handles btnGuardarFinal.Click
        ' --- 1. Validar campos del apoderado ---
        If String.IsNullOrWhiteSpace(txtApoderadoNombres.Text) OrElse
           String.IsNullOrWhiteSpace(txtApoderadoApellidoPaterno.Text) OrElse
           String.IsNullOrWhiteSpace(txtApoderadoApellidoMaterno.Text) OrElse
           String.IsNullOrWhiteSpace(txtApoderadoDNI.Text) OrElse
           String.IsNullOrWhiteSpace(txtApoderadoParentesco.Text) Then
            MessageBox.Show("Por favor, complete todos los campos obligatorios del apoderado (Nombres, Apellidos, DNI, Parentesco).", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- 2. Recopilar los datos del apoderado y guardarlos en las propiedades del formulario Estudiante ---
        _formularioEstudiante.ApoderadoNombres = txtApoderadoNombres.Text.Trim()
        _formularioEstudiante.ApoderadoApellidoPaterno = txtApoderadoApellidoPaterno.Text.Trim()
        _formularioEstudiante.ApoderadoApellidoMaterno = txtApoderadoApellidoMaterno.Text.Trim()
        _formularioEstudiante.ApoderadoDNI = txtApoderadoDNI.Text.Trim()
        _formularioEstudiante.ApoderadoParentesco = txtApoderadoParentesco.Text.Trim()
        _formularioEstudiante.ApoderadoCelular = If(String.IsNullOrWhiteSpace(txtApoderadoCelular.Text), Nothing, txtApoderadoCelular.Text.Trim())
        _formularioEstudiante.ApoderadoEmail = If(String.IsNullOrWhiteSpace(txtApoderadoEmail.Text), Nothing, txtApoderadoEmail.Text.Trim())
        _formularioEstudiante.ApoderadoDireccion = If(String.IsNullOrWhiteSpace(txtApoderadoDireccion.Text), Nothing, txtApoderadoDireccion.Text.Trim())
        _formularioEstudiante.ApoderadoDistrito = If(String.IsNullOrWhiteSpace(txtApoderadoDistrito.Text), Nothing, txtApoderadoDistrito.Text.Trim())
        _formularioEstudiante.ApoderadoProvincia = If(String.IsNullOrWhiteSpace(txtApoderadoProvincia.Text), Nothing, txtApoderadoProvincia.Text.Trim())
        _formularioEstudiante.ApoderadoDepartamento = If(String.IsNullOrWhiteSpace(txtApoderadoDepartamento.Text), Nothing, txtApoderadoDepartamento.Text.Trim())

        ' --- 3. Llamar al método de guardado en el formulario Estudiante (que guardará ambos) ---
        If _formularioEstudiante.GuardarAlumnoYApoderado() Then
            Me.Close() ' Cerrar el formulario Apoderados si el guardado fue exitoso
            ' No cerramos _formularioEstudiante aquí, ya que se cerrará automáticamente si ShowDialog fue usado por Estudiante_vista
            ' Si Estudiante_vista lo mostró con Show(), entonces Estudiante_vista debería cerrarlo o simplemente se mantendrá oculto si lo cierras desde Apoderados
            ' Para asegurar que se cierre Estudiante después de guardar, podríamos añadir:
            ' _formularioEstudiante.Close()
            ' Sin embargo, si Estudiante_vista lo llamó con ShowDialog(), este .Close() no será necesario.
            ' Lo más limpio es que el formulario que lo llamó (Estudiante_vista) lo cierre después de que ShowDialog() regrese.
        End If
    End Sub
End Class