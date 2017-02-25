<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LoginDBDataSet7 = New WindowsApplication1.loginDBDataSet7()
        Me.LoginDBDataSet7BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LoginDBDataSet = New WindowsApplication1.loginDBDataSet()
        Me.LoginDBDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        CType(Me.LoginDBDataSet7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoginDBDataSet7BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoginDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoginDBDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(454, 29)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Billing Info"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(25, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LoginDBDataSet7
        '
        Me.LoginDBDataSet7.DataSetName = "loginDBDataSet7"
        Me.LoginDBDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LoginDBDataSet7BindingSource
        '
        Me.LoginDBDataSet7BindingSource.DataSource = Me.LoginDBDataSet7
        Me.LoginDBDataSet7BindingSource.Position = 0
        '
        'LoginDBDataSet
        '
        Me.LoginDBDataSet.DataSetName = "loginDBDataSet"
        Me.LoginDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LoginDBDataSetBindingSource
        '
        Me.LoginDBDataSetBindingSource.DataSource = Me.LoginDBDataSet
        Me.LoginDBDataSetBindingSource.Position = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(424, 253)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(168, 50)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Add New Billing Info"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvData.BackgroundColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvData.Location = New System.Drawing.Point(25, 77)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(1018, 150)
        Me.dgvData.TabIndex = 6
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(1065, 329)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form4"
        CType(Me.LoginDBDataSet7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoginDBDataSet7BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoginDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoginDBDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LoginDBDataSet7 As WindowsApplication1.loginDBDataSet7
    Friend WithEvents LoginDBDataSet7BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LoginDBDataSet As WindowsApplication1.loginDBDataSet
    Friend WithEvents LoginDBDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
End Class
