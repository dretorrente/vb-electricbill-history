<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtuserID = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.TotalAmount = New System.Windows.Forms.TextBox()
        Me.ElectricBillInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LoginDBDataSet9 = New WindowsApplication1.loginDBDataSet9()
        Me.TotalKWH = New System.Windows.Forms.TextBox()
        Me.DueDate = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BillPeriod = New System.Windows.Forms.TextBox()
        Me.MeterReading = New System.Windows.Forms.TextBox()
        Me.BillDate = New System.Windows.Forms.TextBox()
        Me.Table1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SampleDataSet = New WindowsApplication1.sampleDataSet()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.Table1TableAdapter = New WindowsApplication1.sampleDataSetTableAdapters.Table1TableAdapter()
        Me.ElectricBillInfoTableAdapter = New WindowsApplication1.loginDBDataSet9TableAdapters.ElectricBillInfoTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NextMeter = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ElectricBillInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoginDBDataSet9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Table1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SampleDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NextMeter)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtuserID)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.btnDel)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.TotalAmount)
        Me.GroupBox1.Controls.Add(Me.TotalKWH)
        Me.GroupBox1.Controls.Add(Me.DueDate)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BillPeriod)
        Me.GroupBox1.Controls.Add(Me.MeterReading)
        Me.GroupBox1.Controls.Add(Me.BillDate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 435)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 391)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "ID"
        '
        'txtuserID
        '
        Me.txtuserID.Location = New System.Drawing.Point(122, 10)
        Me.txtuserID.Name = "txtuserID"
        Me.txtuserID.Size = New System.Drawing.Size(137, 20)
        Me.txtuserID.TabIndex = 17
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(185, 391)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(104, 391)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 15
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(185, 362)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 23)
        Me.btnDel.TabIndex = 14
        Me.btnDel.Text = "Delete"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(104, 362)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 362)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'TotalAmount
        '
        Me.TotalAmount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ElectricBillInfoBindingSource, "TotalCurrentAmount", True))
        Me.TotalAmount.Location = New System.Drawing.Point(122, 264)
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.Size = New System.Drawing.Size(137, 20)
        Me.TotalAmount.TabIndex = 12
        '
        'ElectricBillInfoBindingSource
        '
        Me.ElectricBillInfoBindingSource.DataMember = "ElectricBillInfo"
        Me.ElectricBillInfoBindingSource.DataSource = Me.LoginDBDataSet9
        '
        'LoginDBDataSet9
        '
        Me.LoginDBDataSet9.DataSetName = "loginDBDataSet9"
        Me.LoginDBDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TotalKWH
        '
        Me.TotalKWH.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ElectricBillInfoBindingSource, "TotalKWH", True))
        Me.TotalKWH.Location = New System.Drawing.Point(123, 224)
        Me.TotalKWH.Name = "TotalKWH"
        Me.TotalKWH.Size = New System.Drawing.Size(137, 20)
        Me.TotalKWH.TabIndex = 11
        '
        'DueDate
        '
        Me.DueDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ElectricBillInfoBindingSource, "DueDate", True))
        Me.DueDate.Location = New System.Drawing.Point(122, 182)
        Me.DueDate.Name = "DueDate"
        Me.DueDate.Size = New System.Drawing.Size(137, 20)
        Me.DueDate.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 264)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Total Current Amount"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Total KWH"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Due Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Bill Period"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Meter Reading Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "BIll Date"
        '
        'BillPeriod
        '
        Me.BillPeriod.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ElectricBillInfoBindingSource, "BillPeriod", True))
        Me.BillPeriod.Location = New System.Drawing.Point(122, 133)
        Me.BillPeriod.Name = "BillPeriod"
        Me.BillPeriod.Size = New System.Drawing.Size(137, 20)
        Me.BillPeriod.TabIndex = 2
        '
        'MeterReading
        '
        Me.MeterReading.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ElectricBillInfoBindingSource, "MeterReadingDate", True))
        Me.MeterReading.Location = New System.Drawing.Point(122, 84)
        Me.MeterReading.Name = "MeterReading"
        Me.MeterReading.Size = New System.Drawing.Size(137, 20)
        Me.MeterReading.TabIndex = 1
        '
        'BillDate
        '
        Me.BillDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ElectricBillInfoBindingSource, "BillDate", True))
        Me.BillDate.Location = New System.Drawing.Point(122, 47)
        Me.BillDate.Name = "BillDate"
        Me.BillDate.Size = New System.Drawing.Size(137, 20)
        Me.BillDate.TabIndex = 0
        '
        'Table1BindingSource
        '
        Me.Table1BindingSource.DataMember = "Table1"
        Me.Table1BindingSource.DataSource = Me.SampleDataSet
        '
        'SampleDataSet
        '
        Me.SampleDataSet.DataSetName = "sampleDataSet"
        Me.SampleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvData)
        Me.GroupBox2.Location = New System.Drawing.Point(309, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(693, 423)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvData.Location = New System.Drawing.Point(20, 19)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(654, 378)
        Me.dgvData.TabIndex = 0
        '
        'Table1TableAdapter
        '
        Me.Table1TableAdapter.ClearBeforeFill = True
        '
        'ElectricBillInfoTableAdapter
        '
        Me.ElectricBillInfoTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(116, 453)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 306)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Next Meter Reading"
        '
        'NextMeter
        '
        Me.NextMeter.Location = New System.Drawing.Point(122, 306)
        Me.NextMeter.Name = "NextMeter"
        Me.NextMeter.Size = New System.Drawing.Size(137, 20)
        Me.NextMeter.TabIndex = 21
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1053, 488)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form7"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form7"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ElectricBillInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoginDBDataSet9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Table1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SampleDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BillPeriod As System.Windows.Forms.TextBox
    Friend WithEvents MeterReading As System.Windows.Forms.TextBox
    Friend WithEvents BillDate As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SampleDataSet As WindowsApplication1.sampleDataSet
    Friend WithEvents Table1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Table1TableAdapter As WindowsApplication1.sampleDataSetTableAdapters.Table1TableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LoginDBDataSet9 As WindowsApplication1.loginDBDataSet9
    Friend WithEvents ElectricBillInfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ElectricBillInfoTableAdapter As WindowsApplication1.loginDBDataSet9TableAdapters.ElectricBillInfoTableAdapter
    Friend WithEvents TotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents TotalKWH As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtuserID As System.Windows.Forms.TextBox
    Friend WithEvents DueDate As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents NextMeter As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
