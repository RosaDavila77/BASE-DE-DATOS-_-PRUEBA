<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Profesor
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNombresProfesor = New System.Windows.Forms.TextBox()
        Me.txtApellidoPaternoProfesor = New System.Windows.Forms.TextBox()
        Me.txtApellidoMaternoProfesor = New System.Windows.Forms.TextBox()
        Me.txtDniProfesor = New System.Windows.Forms.TextBox()
        Me.txtDireccionProfesor = New System.Windows.Forms.TextBox()
        Me.txtCelularProfesor = New System.Windows.Forms.TextBox()
        Me.txtEmailProfesor = New System.Windows.Forms.TextBox()
        Me.txtEspecialidadProfesor = New System.Windows.Forms.TextBox()
        Me.dtpFechaContratacionProfesor = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaNacimientoProfesor = New System.Windows.Forms.DateTimePicker()
        Me.cboGeneroProfesor = New System.Windows.Forms.ComboBox()
        Me.btnGuardarProfesor = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboGradoAcademicoProfesor = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(338, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Información de Profesor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nombres"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(243, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Apellido Paterno"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(416, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Apellido Materno"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "DNI"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(243, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Fecha de nacimiento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 261)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 20)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Dirección"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(251, 261)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Sexo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(41, 336)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 20)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Celular"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(243, 336)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 20)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "E-mail"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(41, 422)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 20)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Especialidad"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(243, 422)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(137, 20)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Grado Académico"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(41, 514)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(168, 20)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Fecha de contratación"
        '
        'txtNombresProfesor
        '
        Me.txtNombresProfesor.Location = New System.Drawing.Point(45, 135)
        Me.txtNombresProfesor.Name = "txtNombresProfesor"
        Me.txtNombresProfesor.Size = New System.Drawing.Size(108, 26)
        Me.txtNombresProfesor.TabIndex = 20
        '
        'txtApellidoPaternoProfesor
        '
        Me.txtApellidoPaternoProfesor.Location = New System.Drawing.Point(247, 135)
        Me.txtApellidoPaternoProfesor.Name = "txtApellidoPaternoProfesor"
        Me.txtApellidoPaternoProfesor.Size = New System.Drawing.Size(108, 26)
        Me.txtApellidoPaternoProfesor.TabIndex = 21
        '
        'txtApellidoMaternoProfesor
        '
        Me.txtApellidoMaternoProfesor.Location = New System.Drawing.Point(420, 135)
        Me.txtApellidoMaternoProfesor.Name = "txtApellidoMaternoProfesor"
        Me.txtApellidoMaternoProfesor.Size = New System.Drawing.Size(108, 26)
        Me.txtApellidoMaternoProfesor.TabIndex = 22
        '
        'txtDniProfesor
        '
        Me.txtDniProfesor.Location = New System.Drawing.Point(45, 215)
        Me.txtDniProfesor.Name = "txtDniProfesor"
        Me.txtDniProfesor.Size = New System.Drawing.Size(108, 26)
        Me.txtDniProfesor.TabIndex = 23
        '
        'txtDireccionProfesor
        '
        Me.txtDireccionProfesor.Location = New System.Drawing.Point(45, 293)
        Me.txtDireccionProfesor.Name = "txtDireccionProfesor"
        Me.txtDireccionProfesor.Size = New System.Drawing.Size(108, 26)
        Me.txtDireccionProfesor.TabIndex = 24
        '
        'txtCelularProfesor
        '
        Me.txtCelularProfesor.Location = New System.Drawing.Point(45, 368)
        Me.txtCelularProfesor.Name = "txtCelularProfesor"
        Me.txtCelularProfesor.Size = New System.Drawing.Size(164, 26)
        Me.txtCelularProfesor.TabIndex = 25
        '
        'txtEmailProfesor
        '
        Me.txtEmailProfesor.Location = New System.Drawing.Point(247, 368)
        Me.txtEmailProfesor.Name = "txtEmailProfesor"
        Me.txtEmailProfesor.Size = New System.Drawing.Size(159, 26)
        Me.txtEmailProfesor.TabIndex = 26
        '
        'txtEspecialidadProfesor
        '
        Me.txtEspecialidadProfesor.Location = New System.Drawing.Point(45, 459)
        Me.txtEspecialidadProfesor.Name = "txtEspecialidadProfesor"
        Me.txtEspecialidadProfesor.Size = New System.Drawing.Size(143, 26)
        Me.txtEspecialidadProfesor.TabIndex = 27
        '
        'dtpFechaContratacionProfesor
        '
        Me.dtpFechaContratacionProfesor.Location = New System.Drawing.Point(43, 549)
        Me.dtpFechaContratacionProfesor.Name = "dtpFechaContratacionProfesor"
        Me.dtpFechaContratacionProfesor.Size = New System.Drawing.Size(165, 26)
        Me.dtpFechaContratacionProfesor.TabIndex = 30
        '
        'dtpFechaNacimientoProfesor
        '
        Me.dtpFechaNacimientoProfesor.Location = New System.Drawing.Point(247, 215)
        Me.dtpFechaNacimientoProfesor.Name = "dtpFechaNacimientoProfesor"
        Me.dtpFechaNacimientoProfesor.Size = New System.Drawing.Size(165, 26)
        Me.dtpFechaNacimientoProfesor.TabIndex = 31
        '
        'cboGeneroProfesor
        '
        Me.cboGeneroProfesor.FormattingEnabled = True
        Me.cboGeneroProfesor.Items.AddRange(New Object() {"M", "F"})
        Me.cboGeneroProfesor.Location = New System.Drawing.Point(247, 291)
        Me.cboGeneroProfesor.Name = "cboGeneroProfesor"
        Me.cboGeneroProfesor.Size = New System.Drawing.Size(83, 28)
        Me.cboGeneroProfesor.TabIndex = 32
        '
        'btnGuardarProfesor
        '
        Me.btnGuardarProfesor.Location = New System.Drawing.Point(502, 633)
        Me.btnGuardarProfesor.Name = "btnGuardarProfesor"
        Me.btnGuardarProfesor.Size = New System.Drawing.Size(97, 34)
        Me.btnGuardarProfesor.TabIndex = 34
        Me.btnGuardarProfesor.Text = "Guardar"
        Me.btnGuardarProfesor.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(399, 633)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 34)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboGradoAcademicoProfesor
        '
        Me.cboGradoAcademicoProfesor.FormattingEnabled = True
        Me.cboGradoAcademicoProfesor.Location = New System.Drawing.Point(262, 462)
        Me.cboGradoAcademicoProfesor.Name = "cboGradoAcademicoProfesor"
        Me.cboGradoAcademicoProfesor.Size = New System.Drawing.Size(137, 28)
        Me.cboGradoAcademicoProfesor.TabIndex = 35
        '
        'Profesor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 697)
        Me.Controls.Add(Me.cboGradoAcademicoProfesor)
        Me.Controls.Add(Me.btnGuardarProfesor)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboGeneroProfesor)
        Me.Controls.Add(Me.dtpFechaNacimientoProfesor)
        Me.Controls.Add(Me.dtpFechaContratacionProfesor)
        Me.Controls.Add(Me.txtEspecialidadProfesor)
        Me.Controls.Add(Me.txtEmailProfesor)
        Me.Controls.Add(Me.txtCelularProfesor)
        Me.Controls.Add(Me.txtDireccionProfesor)
        Me.Controls.Add(Me.txtDniProfesor)
        Me.Controls.Add(Me.txtApellidoMaternoProfesor)
        Me.Controls.Add(Me.txtApellidoPaternoProfesor)
        Me.Controls.Add(Me.txtNombresProfesor)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Profesor"
        Me.Text = "Form5"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtNombresProfesor As TextBox
    Friend WithEvents txtApellidoPaternoProfesor As TextBox
    Friend WithEvents txtApellidoMaternoProfesor As TextBox
    Friend WithEvents txtDniProfesor As TextBox
    Friend WithEvents txtDireccionProfesor As TextBox
    Friend WithEvents txtCelularProfesor As TextBox
    Friend WithEvents txtEmailProfesor As TextBox
    Friend WithEvents txtEspecialidadProfesor As TextBox
    Friend WithEvents dtpFechaContratacionProfesor As DateTimePicker
    Friend WithEvents dtpFechaNacimientoProfesor As DateTimePicker
    Friend WithEvents cboGeneroProfesor As ComboBox
    Friend WithEvents btnGuardarProfesor As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cboGradoAcademicoProfesor As ComboBox
End Class
