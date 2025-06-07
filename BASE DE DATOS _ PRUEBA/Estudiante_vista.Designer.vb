<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Estudiante_vista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Estudiante_vista))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAnadirEstudiante = New System.Windows.Forms.Button()
        Me.btnBuscarEstudiante = New System.Windows.Forms.Button()
        Me.txtBusquedaEstudiante = New System.Windows.Forms.TextBox()
        Me.cboGrado = New System.Windows.Forms.ComboBox()
        Me.cboSeccion = New System.Windows.Forms.ComboBox()
        Me.dgvEstudiantes = New System.Windows.Forms.DataGridView()
        Me.colEditar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colEliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dgvEstudiantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estuadiantes"
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(791, 516)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(92, 29)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAnadirEstudiante
        '
        Me.btnAnadirEstudiante.Location = New System.Drawing.Point(677, 28)
        Me.btnAnadirEstudiante.Name = "btnAnadirEstudiante"
        Me.btnAnadirEstudiante.Size = New System.Drawing.Size(91, 31)
        Me.btnAnadirEstudiante.TabIndex = 5
        Me.btnAnadirEstudiante.Text = "Añadir"
        Me.btnAnadirEstudiante.UseVisualStyleBackColor = True
        '
        'btnBuscarEstudiante
        '
        Me.btnBuscarEstudiante.Image = CType(resources.GetObject("btnBuscarEstudiante.Image"), System.Drawing.Image)
        Me.btnBuscarEstudiante.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnBuscarEstudiante.Location = New System.Drawing.Point(84, 75)
        Me.btnBuscarEstudiante.Name = "btnBuscarEstudiante"
        Me.btnBuscarEstudiante.Size = New System.Drawing.Size(26, 26)
        Me.btnBuscarEstudiante.TabIndex = 6
        Me.btnBuscarEstudiante.UseVisualStyleBackColor = True
        '
        'txtBusquedaEstudiante
        '
        Me.txtBusquedaEstudiante.Location = New System.Drawing.Point(116, 75)
        Me.txtBusquedaEstudiante.Name = "txtBusquedaEstudiante"
        Me.txtBusquedaEstudiante.Size = New System.Drawing.Size(652, 26)
        Me.txtBusquedaEstudiante.TabIndex = 7
        Me.txtBusquedaEstudiante.Text = "Buscar Nombres, Apellidos, ID" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cboGrado
        '
        Me.cboGrado.FormattingEnabled = True
        Me.cboGrado.Location = New System.Drawing.Point(88, 127)
        Me.cboGrado.Name = "cboGrado"
        Me.cboGrado.Size = New System.Drawing.Size(80, 28)
        Me.cboGrado.TabIndex = 8
        Me.cboGrado.Text = "Grado"
        '
        'cboSeccion
        '
        Me.cboSeccion.FormattingEnabled = True
        Me.cboSeccion.Location = New System.Drawing.Point(192, 127)
        Me.cboSeccion.Name = "cboSeccion"
        Me.cboSeccion.Size = New System.Drawing.Size(89, 28)
        Me.cboSeccion.TabIndex = 9
        Me.cboSeccion.Text = "Sección"
        '
        'dgvEstudiantes
        '
        Me.dgvEstudiantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEstudiantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colEditar, Me.colEliminar})
        Me.dgvEstudiantes.Location = New System.Drawing.Point(89, 185)
        Me.dgvEstudiantes.Name = "dgvEstudiantes"
        Me.dgvEstudiantes.RowHeadersWidth = 62
        Me.dgvEstudiantes.RowTemplate.Height = 28
        Me.dgvEstudiantes.Size = New System.Drawing.Size(877, 318)
        Me.dgvEstudiantes.TabIndex = 10
        '
        'colEditar
        '
        Me.colEditar.HeaderText = ""
        Me.colEditar.MinimumWidth = 8
        Me.colEditar.Name = "colEditar"
        Me.colEditar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colEditar.Text = "Editar"
        Me.colEditar.UseColumnTextForButtonValue = True
        Me.colEditar.Width = 65
        '
        'colEliminar
        '
        Me.colEliminar.HeaderText = ""
        Me.colEliminar.MinimumWidth = 8
        Me.colEliminar.Name = "colEliminar"
        Me.colEliminar.Text = "Eliminar"
        Me.colEliminar.UseColumnTextForButtonValue = True
        Me.colEliminar.Width = 80
        '
        'Estudiante_vista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 575)
        Me.Controls.Add(Me.dgvEstudiantes)
        Me.Controls.Add(Me.cboSeccion)
        Me.Controls.Add(Me.cboGrado)
        Me.Controls.Add(Me.txtBusquedaEstudiante)
        Me.Controls.Add(Me.btnBuscarEstudiante)
        Me.Controls.Add(Me.btnAnadirEstudiante)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Estudiante_vista"
        Me.Text = "Form2"
        CType(Me.dgvEstudiantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnAnadirEstudiante As Button
    Friend WithEvents btnBuscarEstudiante As Button
    Friend WithEvents txtBusquedaEstudiante As TextBox
    Friend WithEvents cboGrado As ComboBox
    Friend WithEvents cboSeccion As ComboBox
    Friend WithEvents dgvEstudiantes As DataGridView
    Friend WithEvents colEditar As DataGridViewButtonColumn
    Friend WithEvents colEliminar As DataGridViewButtonColumn
End Class
