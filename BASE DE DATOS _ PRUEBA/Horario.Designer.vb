<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Horario
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnGuardarHorario = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtFKCursoID = New System.Windows.Forms.TextBox()
        Me.txtFKProfesorID = New System.Windows.Forms.TextBox()
        Me.txtSalon = New System.Windows.Forms.TextBox()
        Me.cboDiaSemana = New System.Windows.Forms.ComboBox()
        Me.txtPeriodoAcademico = New System.Windows.Forms.TextBox()
        Me.dtpHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(72, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(323, 96)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Información de Horario" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ID del curso"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "ID del profesor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(74, 268)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Dia de la semana" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(74, 349)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Hora de Inicio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(215, 349)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Hora de fin"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(74, 435)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Salon"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(74, 518)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Periodo Academico"
        '
        'btnGuardarHorario
        '
        Me.btnGuardarHorario.Location = New System.Drawing.Point(382, 609)
        Me.btnGuardarHorario.Name = "btnGuardarHorario"
        Me.btnGuardarHorario.Size = New System.Drawing.Size(97, 31)
        Me.btnGuardarHorario.TabIndex = 76
        Me.btnGuardarHorario.Text = "Guardar"
        Me.btnGuardarHorario.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(268, 609)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(97, 31)
        Me.btnCancelar.TabIndex = 75
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtFKCursoID
        '
        Me.txtFKCursoID.Location = New System.Drawing.Point(78, 150)
        Me.txtFKCursoID.Name = "txtFKCursoID"
        Me.txtFKCursoID.Size = New System.Drawing.Size(109, 26)
        Me.txtFKCursoID.TabIndex = 77
        '
        'txtFKProfesorID
        '
        Me.txtFKProfesorID.Location = New System.Drawing.Point(79, 225)
        Me.txtFKProfesorID.Name = "txtFKProfesorID"
        Me.txtFKProfesorID.Size = New System.Drawing.Size(109, 26)
        Me.txtFKProfesorID.TabIndex = 78
        '
        'txtSalon
        '
        Me.txtSalon.Location = New System.Drawing.Point(78, 474)
        Me.txtSalon.Name = "txtSalon"
        Me.txtSalon.Size = New System.Drawing.Size(142, 26)
        Me.txtSalon.TabIndex = 79
        '
        'cboDiaSemana
        '
        Me.cboDiaSemana.FormattingEnabled = True
        Me.cboDiaSemana.Items.AddRange(New Object() {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"})
        Me.cboDiaSemana.Location = New System.Drawing.Point(79, 306)
        Me.cboDiaSemana.Name = "cboDiaSemana"
        Me.cboDiaSemana.Size = New System.Drawing.Size(133, 28)
        Me.cboDiaSemana.TabIndex = 80
        '
        'txtPeriodoAcademico
        '
        Me.txtPeriodoAcademico.Location = New System.Drawing.Point(78, 541)
        Me.txtPeriodoAcademico.Name = "txtPeriodoAcademico"
        Me.txtPeriodoAcademico.Size = New System.Drawing.Size(142, 26)
        Me.txtPeriodoAcademico.TabIndex = 83
        '
        'dtpHoraFin
        '
        Me.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraFin.Location = New System.Drawing.Point(219, 386)
        Me.dtpHoraFin.Name = "dtpHoraFin"
        Me.dtpHoraFin.Size = New System.Drawing.Size(128, 26)
        Me.dtpHoraFin.TabIndex = 102
        '
        'dtpHoraInicio
        '
        Me.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraInicio.Location = New System.Drawing.Point(78, 386)
        Me.dtpHoraInicio.Name = "dtpHoraInicio"
        Me.dtpHoraInicio.Size = New System.Drawing.Size(128, 26)
        Me.dtpHoraInicio.TabIndex = 101
        '
        'Horario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 668)
        Me.Controls.Add(Me.dtpHoraFin)
        Me.Controls.Add(Me.dtpHoraInicio)
        Me.Controls.Add(Me.txtPeriodoAcademico)
        Me.Controls.Add(Me.cboDiaSemana)
        Me.Controls.Add(Me.txtSalon)
        Me.Controls.Add(Me.txtFKProfesorID)
        Me.Controls.Add(Me.txtFKCursoID)
        Me.Controls.Add(Me.btnGuardarHorario)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Horario"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnGuardarHorario As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents txtFKCursoID As TextBox
    Friend WithEvents txtFKProfesorID As TextBox
    Friend WithEvents txtSalon As TextBox
    Friend WithEvents cboDiaSemana As ComboBox
    Friend WithEvents txtPeriodoAcademico As TextBox
    Friend WithEvents dtpHoraFin As DateTimePicker
    Friend WithEvents dtpHoraInicio As DateTimePicker
End Class
