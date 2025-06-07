<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Horario_vista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Horario_vista))
        Me.lblxd = New System.Windows.Forms.Label()
        Me.txtBusquedaHorario = New System.Windows.Forms.TextBox()
        Me.btnBuscarHorario = New System.Windows.Forms.Button()
        Me.dgvHorarios = New System.Windows.Forms.DataGridView()
        Me.btnAnadirHorario = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.colEditar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colEliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dgvHorarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblxd
        '
        Me.lblxd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblxd.AutoSize = True
        Me.lblxd.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblxd.Location = New System.Drawing.Point(120, 23)
        Me.lblxd.Name = "lblxd"
        Me.lblxd.Size = New System.Drawing.Size(113, 32)
        Me.lblxd.TabIndex = 21
        Me.lblxd.Text = "Horarios"
        '
        'txtBusquedaHorario
        '
        Me.txtBusquedaHorario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtBusquedaHorario.Location = New System.Drawing.Point(123, 83)
        Me.txtBusquedaHorario.Name = "txtBusquedaHorario"
        Me.txtBusquedaHorario.Size = New System.Drawing.Size(444, 26)
        Me.txtBusquedaHorario.TabIndex = 22
        Me.txtBusquedaHorario.Text = "Buscar Nombres, Apellidos, ID, Especialidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnBuscarHorario
        '
        Me.btnBuscarHorario.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBuscarHorario.Image = CType(resources.GetObject("btnBuscarHorario.Image"), System.Drawing.Image)
        Me.btnBuscarHorario.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnBuscarHorario.Location = New System.Drawing.Point(91, 83)
        Me.btnBuscarHorario.Name = "btnBuscarHorario"
        Me.btnBuscarHorario.Size = New System.Drawing.Size(26, 26)
        Me.btnBuscarHorario.TabIndex = 23
        Me.btnBuscarHorario.UseVisualStyleBackColor = True
        '
        'dgvHorarios
        '
        Me.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHorarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colEditar, Me.colEliminar})
        Me.dgvHorarios.Location = New System.Drawing.Point(91, 145)
        Me.dgvHorarios.Name = "dgvHorarios"
        Me.dgvHorarios.RowHeadersWidth = 62
        Me.dgvHorarios.RowTemplate.Height = 28
        Me.dgvHorarios.Size = New System.Drawing.Size(754, 312)
        Me.dgvHorarios.TabIndex = 24
        '
        'btnAnadirHorario
        '
        Me.btnAnadirHorario.Location = New System.Drawing.Point(748, 37)
        Me.btnAnadirHorario.Name = "btnAnadirHorario"
        Me.btnAnadirHorario.Size = New System.Drawing.Size(97, 30)
        Me.btnAnadirHorario.TabIndex = 25
        Me.btnAnadirHorario.Text = "Añadir"
        Me.btnAnadirHorario.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(807, 479)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(97, 30)
        Me.btnCerrar.TabIndex = 26
        Me.btnCerrar.Text = "cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'colEditar
        '
        Me.colEditar.HeaderText = ""
        Me.colEditar.MinimumWidth = 8
        Me.colEditar.Name = "colEditar"
        Me.colEditar.Text = "Editar"
        Me.colEditar.UseColumnTextForButtonValue = True
        Me.colEditar.Width = 55
        '
        'colEliminar
        '
        Me.colEliminar.HeaderText = ""
        Me.colEliminar.MinimumWidth = 8
        Me.colEliminar.Name = "colEliminar"
        Me.colEliminar.Text = "Eliminar"
        Me.colEliminar.UseColumnTextForButtonValue = True
        Me.colEliminar.Width = 76
        '
        'Horario_vista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 521)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAnadirHorario)
        Me.Controls.Add(Me.dgvHorarios)
        Me.Controls.Add(Me.btnBuscarHorario)
        Me.Controls.Add(Me.txtBusquedaHorario)
        Me.Controls.Add(Me.lblxd)
        Me.Name = "Horario_vista"
        Me.Text = "Form2"
        CType(Me.dgvHorarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblxd As Label
    Friend WithEvents txtBusquedaHorario As TextBox
    Friend WithEvents btnBuscarHorario As Button
    Friend WithEvents dgvHorarios As DataGridView
    Friend WithEvents btnAnadirHorario As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents colEditar As DataGridViewButtonColumn
    Friend WithEvents colEliminar As DataGridViewButtonColumn
End Class