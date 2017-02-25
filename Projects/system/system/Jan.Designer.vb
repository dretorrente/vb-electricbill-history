<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Jan
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.listPercent = New System.Windows.Forms.ListBox()
        Me.totalAmt = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.DarkGray
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(12, 62)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Color = System.Drawing.Color.Green
        Series1.Legend = "Legend1"
        Series1.Name = "Percentage - Total Amount"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(1027, 414)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'listPercent
        '
        Me.listPercent.FormattingEnabled = True
        Me.listPercent.Location = New System.Drawing.Point(817, 156)
        Me.listPercent.Name = "listPercent"
        Me.listPercent.Size = New System.Drawing.Size(201, 264)
        Me.listPercent.TabIndex = 2
        '
        'totalAmt
        '
        Me.totalAmt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.totalAmt.AutoSize = True
        Me.totalAmt.BackColor = System.Drawing.SystemColors.Control
        Me.totalAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalAmt.Location = New System.Drawing.Point(855, 115)
        Me.totalAmt.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.totalAmt.Name = "totalAmt"
        Me.totalAmt.Size = New System.Drawing.Size(151, 25)
        Me.totalAmt.TabIndex = 3
        Me.totalAmt.Text = "Total Amount"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Jan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(1051, 488)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.totalAmt)
        Me.Controls.Add(Me.listPercent)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "Jan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form11"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents listPercent As System.Windows.Forms.ListBox
    Friend WithEvents totalAmt As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
