<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cursos_editar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnGuardarCambios = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.nudHorasSemanales = New System.Windows.Forms.NumericUpDown()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtGradoAsociado = New System.Windows.Forms.TextBox()
        Me.cmbNivelEducativo = New System.Windows.Forms.ComboBox()
        Me.txtNombreCurso = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        CType(Me.nudHorasSemanales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGuardarCambios
        '
        Me.btnGuardarCambios.Location = New System.Drawing.Point(551, 526)
        Me.btnGuardarCambios.Name = "btnGuardarCambios"
        Me.btnGuardarCambios.Size = New System.Drawing.Size(97, 34)
        Me.btnGuardarCambios.TabIndex = 49
        Me.btnGuardarCambios.Text = "Guardar"
        Me.btnGuardarCambios.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(430, 526)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(97, 34)
        Me.btnCancelar.TabIndex = 48
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'nudHorasSemanales
        '
        Me.nudHorasSemanales.Location = New System.Drawing.Point(62, 462)
        Me.nudHorasSemanales.Name = "nudHorasSemanales"
        Me.nudHorasSemanales.Size = New System.Drawing.Size(77, 26)
        Me.nudHorasSemanales.TabIndex = 47
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(62, 337)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(384, 76)
        Me.txtDescripcion.TabIndex = 46
        '
        'txtGradoAsociado
        '
        Me.txtGradoAsociado.Location = New System.Drawing.Point(62, 275)
        Me.txtGradoAsociado.Name = "txtGradoAsociado"
        Me.txtGradoAsociado.Size = New System.Drawing.Size(155, 26)
        Me.txtGradoAsociado.TabIndex = 45
        '
        'cmbNivelEducativo
        '
        Me.cmbNivelEducativo.FormattingEnabled = True
        Me.cmbNivelEducativo.Items.AddRange(New Object() {"Inicial", "Primaria", "Secundaria"})
        Me.cmbNivelEducativo.Location = New System.Drawing.Point(62, 203)
        Me.cmbNivelEducativo.Name = "cmbNivelEducativo"
        Me.cmbNivelEducativo.Size = New System.Drawing.Size(155, 28)
        Me.cmbNivelEducativo.TabIndex = 44
        '
        'txtNombreCurso
        '
        Me.txtNombreCurso.Location = New System.Drawing.Point(62, 127)
        Me.txtNombreCurso.Name = "txtNombreCurso"
        Me.txtNombreCurso.Size = New System.Drawing.Size(208, 26)
        Me.txtNombreCurso.TabIndex = 43
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(58, 428)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 20)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Horas semanales"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(58, 314)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 20)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Descripción"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Grado Asociado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 20)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Nivel educativo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Nombre de curso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(297, 64)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Información de curso" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 511)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 20)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "No Activo"})
        Me.cmbEstado.Location = New System.Drawing.Point(62, 547)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(124, 28)
        Me.cmbEstado.TabIndex = 51
        '
        'Cursos_editar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 643)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGuardarCambios)
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
        Me.Name = "Cursos_editar"
        Me.Text = "Form2"
        CType(Me.nudHorasSemanales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGuardarCambios As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents nudHorasSemanales As NumericUpDown
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtGradoAsociado As TextBox
    Friend WithEvents cmbNivelEducativo As ComboBox
    Friend WithEvents txtNombreCurso As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbEstado As ComboBox
End Class
