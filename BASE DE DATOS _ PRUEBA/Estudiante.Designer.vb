<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Estudiante
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.txtApellidoPaterno = New System.Windows.Forms.TextBox()
        Me.txtApellidoMaterno = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.cboGenero = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtTelefonoCasa = New System.Windows.Forms.TextBox()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpFechaInscripcion = New System.Windows.Forms.DateTimePicker()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtDistrito = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cboGradoAcademico = New System.Windows.Forms.ComboBox()
        Me.cboSeccion = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(219, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 20)
        Me.Label1.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(338, 774)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(97, 34)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(366, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Información de estudiante"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nombres"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Apellido Paterno"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(236, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Apellido Materno" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(43, 106)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(165, 26)
        Me.txtNombres.TabIndex = 9
        '
        'txtApellidoPaterno
        '
        Me.txtApellidoPaterno.Location = New System.Drawing.Point(47, 187)
        Me.txtApellidoPaterno.Name = "txtApellidoPaterno"
        Me.txtApellidoPaterno.Size = New System.Drawing.Size(133, 26)
        Me.txtApellidoPaterno.TabIndex = 10
        '
        'txtApellidoMaterno
        '
        Me.txtApellidoMaterno.Location = New System.Drawing.Point(240, 187)
        Me.txtApellidoMaterno.Name = "txtApellidoMaterno"
        Me.txtApellidoMaterno.Size = New System.Drawing.Size(165, 26)
        Me.txtApellidoMaterno.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Fecha de nacimiento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dtpFechaNacimiento
        '
        Me.dtpFechaNacimiento.Location = New System.Drawing.Point(43, 263)
        Me.dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        Me.dtpFechaNacimiento.Size = New System.Drawing.Size(148, 26)
        Me.dtpFechaNacimiento.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(236, 227)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "DNI"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(401, 227)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Sexo"
        '
        'txtDNI
        '
        Me.txtDNI.Location = New System.Drawing.Point(240, 263)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(133, 26)
        Me.txtDNI.TabIndex = 16
        '
        'cboGenero
        '
        Me.cboGenero.FormattingEnabled = True
        Me.cboGenero.Items.AddRange(New Object() {"Masculino (M)", "Femenino (F)"})
        Me.cboGenero.Location = New System.Drawing.Point(405, 261)
        Me.cboGenero.Name = "cboGenero"
        Me.cboGenero.Size = New System.Drawing.Size(83, 28)
        Me.cboGenero.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(39, 313)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 20)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Dirección"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(43, 481)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(131, 20)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Telefono de casa"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(228, 481)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 20)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Celular"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 540)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 20)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "E-mail"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(43, 613)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(137, 20)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Grado Academico"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(43, 341)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(285, 26)
        Me.txtDireccion.TabIndex = 23
        '
        'txtTelefonoCasa
        '
        Me.txtTelefonoCasa.Location = New System.Drawing.Point(47, 504)
        Me.txtTelefonoCasa.Name = "txtTelefonoCasa"
        Me.txtTelefonoCasa.Size = New System.Drawing.Size(133, 26)
        Me.txtTelefonoCasa.TabIndex = 24
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(232, 504)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(133, 26)
        Me.txtCelular.TabIndex = 25
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(47, 573)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(133, 26)
        Me.txtEmail.TabIndex = 26
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(460, 774)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(97, 34)
        Me.btnSiguiente.TabIndex = 28
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(228, 613)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 20)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Sección"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(50, 682)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 20)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Fecha inscripción"
        '
        'dtpFechaInscripcion
        '
        Me.dtpFechaInscripcion.Location = New System.Drawing.Point(47, 715)
        Me.dtpFechaInscripcion.Name = "dtpFechaInscripcion"
        Me.dtpFechaInscripcion.Size = New System.Drawing.Size(148, 26)
        Me.dtpFechaInscripcion.TabIndex = 34
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Location = New System.Drawing.Point(394, 423)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(133, 26)
        Me.txtDepartamento.TabIndex = 108
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(390, 390)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(112, 20)
        Me.Label30.TabIndex = 107
        Me.Label30.Text = "Departamento"
        '
        'txtProvincia
        '
        Me.txtProvincia.Location = New System.Drawing.Point(219, 423)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Size = New System.Drawing.Size(133, 26)
        Me.txtProvincia.TabIndex = 106
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(215, 390)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(72, 20)
        Me.Label31.TabIndex = 105
        Me.Label31.Text = "Provincia"
        '
        'txtDistrito
        '
        Me.txtDistrito.Location = New System.Drawing.Point(43, 423)
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.Size = New System.Drawing.Size(133, 26)
        Me.txtDistrito.TabIndex = 104
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(39, 390)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(59, 20)
        Me.Label32.TabIndex = 103
        Me.Label32.Text = "Distrito"
        '
        'cboGradoAcademico
        '
        Me.cboGradoAcademico.FormattingEnabled = True
        Me.cboGradoAcademico.Location = New System.Drawing.Point(45, 636)
        Me.cboGradoAcademico.Name = "cboGradoAcademico"
        Me.cboGradoAcademico.Size = New System.Drawing.Size(137, 28)
        Me.cboGradoAcademico.TabIndex = 109
        '
        'cboSeccion
        '
        Me.cboSeccion.FormattingEnabled = True
        Me.cboSeccion.Location = New System.Drawing.Point(223, 636)
        Me.cboSeccion.Name = "cboSeccion"
        Me.cboSeccion.Size = New System.Drawing.Size(78, 28)
        Me.cboSeccion.TabIndex = 110
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(43, 763)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(60, 20)
        Me.lblEstado.TabIndex = 111
        Me.lblEstado.Text = "Estado"
        '
        'cboEstado
        '
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(47, 793)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(121, 28)
        Me.cboEstado.TabIndex = 112
        '
        'Estudiante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 833)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cboSeccion)
        Me.Controls.Add(Me.cboGradoAcademico)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtProvincia)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtDistrito)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.dtpFechaInscripcion)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtCelular)
        Me.Controls.Add(Me.txtTelefonoCasa)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboGenero)
        Me.Controls.Add(Me.txtDNI)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpFechaNacimiento)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtApellidoMaterno)
        Me.Controls.Add(Me.txtApellidoPaterno)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Estudiante"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents txtApellidoPaterno As TextBox
    Friend WithEvents txtApellidoMaterno As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFechaNacimiento As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDNI As TextBox
    Friend WithEvents cboGenero As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents txtTelefonoCasa As TextBox
    Friend WithEvents txtCelular As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnSiguiente As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents dtpFechaInscripcion As DateTimePicker
    Friend WithEvents txtDepartamento As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtProvincia As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtDistrito As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents cboGradoAcademico As ComboBox
    Friend WithEvents cboSeccion As ComboBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents cboEstado As ComboBox
End Class
