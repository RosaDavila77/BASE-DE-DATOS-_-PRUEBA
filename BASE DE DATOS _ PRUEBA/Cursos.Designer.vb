<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cursos
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
        Me.txtNombreCurso = New System.Windows.Forms.TextBox()
        Me.cmbNivelEducativo = New System.Windows.Forms.ComboBox()
        Me.txtGradoAsociado = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.nudHorasSemanales = New System.Windows.Forms.NumericUpDown()
        Me.btnGuardarCurso = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.nudHorasSemanales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(297, 64)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Información de curso" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nombre de curso"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(42, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Nivel educativo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Grado Asociado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 308)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Descripción"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(42, 422)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Horas semanales"
        '
        'txtNombreCurso
        '
        Me.txtNombreCurso.Location = New System.Drawing.Point(46, 121)
        Me.txtNombreCurso.Name = "txtNombreCurso"
        Me.txtNombreCurso.Size = New System.Drawing.Size(208, 26)
        Me.txtNombreCurso.TabIndex = 14
        '
        'cmbNivelEducativo
        '
        Me.cmbNivelEducativo.FormattingEnabled = True
        Me.cmbNivelEducativo.Items.AddRange(New Object() {"Inicial", "Primaria", "Secundaria"})
        Me.cmbNivelEducativo.Location = New System.Drawing.Point(46, 197)
        Me.cmbNivelEducativo.Name = "cmbNivelEducativo"
        Me.cmbNivelEducativo.Size = New System.Drawing.Size(155, 28)
        Me.cmbNivelEducativo.TabIndex = 15
        '
        'txtGradoAsociado
        '
        Me.txtGradoAsociado.Location = New System.Drawing.Point(46, 269)
        Me.txtGradoAsociado.Name = "txtGradoAsociado"
        Me.txtGradoAsociado.Size = New System.Drawing.Size(155, 26)
        Me.txtGradoAsociado.TabIndex = 16
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(46, 331)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(384, 76)
        Me.txtDescripcion.TabIndex = 17
        '
        'nudHorasSemanales
        '
        Me.nudHorasSemanales.Location = New System.Drawing.Point(46, 456)
        Me.nudHorasSemanales.Name = "nudHorasSemanales"
        Me.nudHorasSemanales.Size = New System.Drawing.Size(77, 26)
        Me.nudHorasSemanales.TabIndex = 18
        '
        'btnGuardarCurso
        '
        Me.btnGuardarCurso.Location = New System.Drawing.Point(389, 513)
        Me.btnGuardarCurso.Name = "btnGuardarCurso"
        Me.btnGuardarCurso.Size = New System.Drawing.Size(97, 34)
        Me.btnGuardarCurso.TabIndex = 36
        Me.btnGuardarCurso.Text = "Guardar"
        Me.btnGuardarCurso.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(286, 513)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(97, 34)
        Me.btnCancelar.TabIndex = 35
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Cursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 597)
        Me.Controls.Add(Me.btnGuardarCurso)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.nudHorasSemanales)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtGradoAsociado)
        Me.Controls.Add(Me.cmbNivelEducativo)
        Me.Controls.Add(Me.txtNombreCurso)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Cursos"
        Me.Text = "Form5"
        CType(Me.nudHorasSemanales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNombreCurso As TextBox
    Friend WithEvents cmbNivelEducativo As ComboBox
    Friend WithEvents txtGradoAsociado As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents nudHorasSemanales As NumericUpDown
    Friend WithEvents btnGuardarCurso As Button
    Friend WithEvents btnCancelar As Button
End Class
