<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Profesor_vista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Profesor_vista))
        Me.dgvProfesores = New System.Windows.Forms.DataGridView()
        Me.colEditar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colEliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TXTbusqueda_profesor = New System.Windows.Forms.TextBox()
        Me.btnBUSCAR = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAñadir_profesor = New System.Windows.Forms.Button()
        CType(Me.dgvProfesores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProfesores
        '
        Me.dgvProfesores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProfesores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProfesores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colEditar, Me.colEliminar})
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvProfesores, 3)
        Me.dgvProfesores.Location = New System.Drawing.Point(3, 111)
        Me.dgvProfesores.Name = "dgvProfesores"
        Me.dgvProfesores.RowHeadersWidth = 62
        Me.dgvProfesores.RowTemplate.Height = 28
        Me.dgvProfesores.Size = New System.Drawing.Size(1032, 449)
        Me.dgvProfesores.TabIndex = 19
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
        'TXTbusqueda_profesor
        '
        Me.TXTbusqueda_profesor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TXTbusqueda_profesor.Location = New System.Drawing.Point(232, 67)
        Me.TXTbusqueda_profesor.Name = "TXTbusqueda_profesor"
        Me.TXTbusqueda_profesor.Size = New System.Drawing.Size(444, 26)
        Me.TXTbusqueda_profesor.TabIndex = 16
        Me.TXTbusqueda_profesor.Text = "Buscar Nombres, Apellidos, ID, Especialidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnBUSCAR
        '
        Me.btnBUSCAR.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBUSCAR.Image = CType(resources.GetObject("btnBUSCAR.Image"), System.Drawing.Image)
        Me.btnBUSCAR.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnBUSCAR.Location = New System.Drawing.Point(200, 67)
        Me.btnBUSCAR.Name = "btnBUSCAR"
        Me.btnBUSCAR.Size = New System.Drawing.Size(26, 26)
        Me.btnBUSCAR.TabIndex = 15
        Me.btnBUSCAR.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.7815!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.2185!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 291.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnCerrar, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvProfesores, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TXTbusqueda_profesor, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBUSCAR, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAñadir_profesor, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 455.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1038, 620)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'btnCerrar
        '
        Me.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrar.Location = New System.Drawing.Point(929, 566)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 51)
        Me.btnCerrar.TabIndex = 22
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 32)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Profesor"
        '
        'btnAñadir_profesor
        '
        Me.btnAñadir_profesor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAñadir_profesor.Location = New System.Drawing.Point(919, 21)
        Me.btnAñadir_profesor.Name = "btnAñadir_profesor"
        Me.btnAñadir_profesor.Size = New System.Drawing.Size(116, 29)
        Me.btnAñadir_profesor.TabIndex = 21
        Me.btnAñadir_profesor.Text = "Añadir"
        Me.btnAñadir_profesor.UseVisualStyleBackColor = True
        '
        'Profesor_vista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 620)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Profesor_vista"
        Me.Text = "Form5"
        CType(Me.dgvProfesores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvProfesores As DataGridView
    Friend WithEvents colEditar As DataGridViewButtonColumn
    Friend WithEvents colEliminar As DataGridViewButtonColumn
    Friend WithEvents TXTbusqueda_profesor As TextBox
    Friend WithEvents btnBUSCAR As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAñadir_profesor As Button
    Friend WithEvents btnCerrar As Button
End Class
