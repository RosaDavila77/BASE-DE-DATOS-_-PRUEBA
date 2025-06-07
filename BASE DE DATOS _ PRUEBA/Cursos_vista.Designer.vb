<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cursos_vista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cursos_vista))
        Me.txtBusquedaCurso = New System.Windows.Forms.TextBox()
        Me.btnBuscarCurso = New System.Windows.Forms.Button()
        Me.btnAñadir_curso = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCursos = New System.Windows.Forms.DataGridView()
        Me.ColEditar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ColEliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dgvCursos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBusquedaCurso
        '
        Me.txtBusquedaCurso.Location = New System.Drawing.Point(105, 66)
        Me.txtBusquedaCurso.Name = "txtBusquedaCurso"
        Me.txtBusquedaCurso.Size = New System.Drawing.Size(652, 26)
        Me.txtBusquedaCurso.TabIndex = 16
        Me.txtBusquedaCurso.Text = "Buscar ID, Nombre del Curso, Descripción"
        '
        'btnBuscarCurso
        '
        Me.btnBuscarCurso.Image = CType(resources.GetObject("btnBuscarCurso.Image"), System.Drawing.Image)
        Me.btnBuscarCurso.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnBuscarCurso.Location = New System.Drawing.Point(73, 66)
        Me.btnBuscarCurso.Name = "btnBuscarCurso"
        Me.btnBuscarCurso.Size = New System.Drawing.Size(26, 26)
        Me.btnBuscarCurso.TabIndex = 15
        Me.btnBuscarCurso.UseVisualStyleBackColor = True
        '
        'btnAñadir_curso
        '
        Me.btnAñadir_curso.Location = New System.Drawing.Point(666, 19)
        Me.btnAñadir_curso.Name = "btnAñadir_curso"
        Me.btnAñadir_curso.Size = New System.Drawing.Size(91, 31)
        Me.btnAñadir_curso.TabIndex = 14
        Me.btnAñadir_curso.Text = "Añadir"
        Me.btnAñadir_curso.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(780, 507)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(92, 29)
        Me.btnCerrar.TabIndex = 13
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Cursos"
        '
        'dgvCursos
        '
        Me.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCursos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColEditar, Me.ColEliminar})
        Me.dgvCursos.Location = New System.Drawing.Point(73, 137)
        Me.dgvCursos.Name = "dgvCursos"
        Me.dgvCursos.RowHeadersWidth = 62
        Me.dgvCursos.RowTemplate.Height = 28
        Me.dgvCursos.Size = New System.Drawing.Size(852, 349)
        Me.dgvCursos.TabIndex = 18
        '
        'ColEditar
        '
        Me.ColEditar.HeaderText = ""
        Me.ColEditar.MinimumWidth = 8
        Me.ColEditar.Name = "ColEditar"
        Me.ColEditar.Text = "Editar"
        Me.ColEditar.UseColumnTextForButtonValue = True
        Me.ColEditar.Width = 50
        '
        'ColEliminar
        '
        Me.ColEliminar.HeaderText = ""
        Me.ColEliminar.MinimumWidth = 8
        Me.ColEliminar.Name = "ColEliminar"
        Me.ColEliminar.Text = "Eliminar"
        Me.ColEliminar.UseColumnTextForButtonValue = True
        Me.ColEliminar.Width = 70
        '
        'Cursos_vista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 558)
        Me.Controls.Add(Me.dgvCursos)
        Me.Controls.Add(Me.txtBusquedaCurso)
        Me.Controls.Add(Me.btnBuscarCurso)
        Me.Controls.Add(Me.btnAñadir_curso)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Cursos_vista"
        Me.Text = "Form5"
        CType(Me.dgvCursos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBusquedaCurso As TextBox
    Friend WithEvents btnBuscarCurso As Button
    Friend WithEvents btnAñadir_curso As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvCursos As DataGridView
    Friend WithEvents ColEditar As DataGridViewButtonColumn
    Friend WithEvents ColEliminar As DataGridViewButtonColumn
End Class
