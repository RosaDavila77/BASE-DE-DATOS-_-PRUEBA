<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Horario_editar
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
        Me.txtPeriodoAcademico = New System.Windows.Forms.TextBox()
        Me.cboDiaSemana = New System.Windows.Forms.ComboBox()
        Me.txtSalon = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.btnGuardarCambios = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtNombreCurso = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombreProfesor = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtPeriodoAcademico
        '
        Me.txtPeriodoAcademico.Location = New System.Drawing.Point(53, 502)
        Me.txtPeriodoAcademico.Name = "txtPeriodoAcademico"
        Me.txtPeriodoAcademico.Size = New System.Drawing.Size(142, 26)
        Me.txtPeriodoAcademico.TabIndex = 98
        '
        'cboDiaSemana
        '
        Me.cboDiaSemana.FormattingEnabled = True
        Me.cboDiaSemana.Items.AddRange(New Object() {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"})
        Me.cboDiaSemana.Location = New System.Drawing.Point(54, 267)
        Me.cboDiaSemana.Name = "cboDiaSemana"
        Me.cboDiaSemana.Size = New System.Drawing.Size(133, 28)
        Me.cboDiaSemana.TabIndex = 95
        '
        'txtSalon
        '
        Me.txtSalon.Location = New System.Drawing.Point(53, 435)
        Me.txtSalon.Name = "txtSalon"
        Me.txtSalon.Size = New System.Drawing.Size(142, 26)
        Me.txtSalon.TabIndex = 94
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(49, 479)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 20)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Periodo Academico"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(49, 396)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 20)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "Salon"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(190, 310)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 20)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Hora de fin"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 310)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 20)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Hora de Inicio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 20)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Dia de la semana" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(77, -4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(323, 96)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Información de Horario" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dtpHoraInicio
        '
        Me.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraInicio.Location = New System.Drawing.Point(53, 348)
        Me.dtpHoraInicio.Name = "dtpHoraInicio"
        Me.dtpHoraInicio.Size = New System.Drawing.Size(128, 26)
        Me.dtpHoraInicio.TabIndex = 99
        '
        'dtpHoraFin
        '
        Me.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraFin.Location = New System.Drawing.Point(194, 348)
        Me.dtpHoraFin.Name = "dtpHoraFin"
        Me.dtpHoraFin.Size = New System.Drawing.Size(128, 26)
        Me.dtpHoraFin.TabIndex = 100
        '
        'btnGuardarCambios
        '
        Me.btnGuardarCambios.Location = New System.Drawing.Point(339, 574)
        Me.btnGuardarCambios.Name = "btnGuardarCambios"
        Me.btnGuardarCambios.Size = New System.Drawing.Size(97, 31)
        Me.btnGuardarCambios.TabIndex = 102
        Me.btnGuardarCambios.Text = "Guardar"
        Me.btnGuardarCambios.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(225, 574)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(97, 31)
        Me.btnCancelar.TabIndex = 101
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtNombreCurso
        '
        Me.txtNombreCurso.Location = New System.Drawing.Point(50, 115)
        Me.txtNombreCurso.Name = "txtNombreCurso"
        Me.txtNombreCurso.ReadOnly = True
        Me.txtNombreCurso.Size = New System.Drawing.Size(206, 26)
        Me.txtNombreCurso.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 20)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Nombre de profesor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Nombre de curso"
        '
        'txtNombreProfesor
        '
        Me.txtNombreProfesor.Location = New System.Drawing.Point(50, 180)
        Me.txtNombreProfesor.Name = "txtNombreProfesor"
        Me.txtNombreProfesor.ReadOnly = True
        Me.txtNombreProfesor.Size = New System.Drawing.Size(206, 26)
        Me.txtNombreProfesor.TabIndex = 106
        '
        'Horario_editar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 627)
        Me.Controls.Add(Me.txtNombreProfesor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombreCurso)
        Me.Controls.Add(Me.btnGuardarCambios)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.dtpHoraFin)
        Me.Controls.Add(Me.dtpHoraInicio)
        Me.Controls.Add(Me.txtPeriodoAcademico)
        Me.Controls.Add(Me.cboDiaSemana)
        Me.Controls.Add(Me.txtSalon)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Horario_editar"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPeriodoAcademico As TextBox
    Friend WithEvents cboDiaSemana As ComboBox
    Friend WithEvents txtSalon As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpHoraInicio As DateTimePicker
    Friend WithEvents dtpHoraFin As DateTimePicker
    Friend WithEvents btnGuardarCambios As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents txtNombreCurso As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNombreProfesor As TextBox
End Class
