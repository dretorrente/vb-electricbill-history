Imports System.Data.OleDb
Imports System.ComponentModel
Public Class Jan
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(getUser)

    End Sub
    
    Public Sub RefreshData()
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT ID, " & _
                                              "BillDate, TotalKWH, TotalCurrentAmount, NextMeterReading, Generation, Transmission, SystemLoss, Distribution, Subsidies, GovernmentTaxes, UniversalCharges, FitAll, OtherCharges " & _
                                              " FROM  [" + getUser + "ElectricBill] ORDER BY BillDate DESC", cnn)
        Dim dr As OleDbDataReader = cmd.ExecuteReader
        Dim billdates As Boolean = False
        Dim Billdate As String = ""
        Dim Totalkwh As String = ""
        Dim TotalAmount As String = ""
        Dim NextMeter As String = ""
        Dim Generation As String = ""
        Dim Transmission As String = ""
        Dim SystemLoss As String = ""
        Dim DistributionMeralco As String = ""
        Dim Subsidies As String = ""
        Dim GovernmentTaxes As String = ""
        Dim UniversalCharges As String = ""
        Dim FitAll As String = ""
        Dim OtherCharges As String = ""

        While dr.Read
            billdates = True
            Billdate = dr("BillDate").ToString
            Billdate = FormatDateTime(Convert.ToDateTime(Billdate), DateFormat.ShortDate)
            Totalkwh = dr("TotalKWH").ToString
            TotalAmount = dr("TotalCurrentAmount").ToString
            NextMeter = dr("NextMeterReading").ToString
            NextMeter = FormatDateTime(Convert.ToDateTime(NextMeter), DateFormat.ShortDate)
            Generation = dr("Generation").ToString
            Transmission = dr("Transmission").ToString
            SystemLoss = dr("SystemLoss").ToString
            DistributionMeralco = dr("Distribution").ToString
            Subsidies = dr("Subsidies").ToString
            GovernmentTaxes = dr("GovernmentTaxes").ToString
            UniversalCharges = dr("UniversalCharges").ToString
            FitAll = dr("FitAll").ToString
            OtherCharges = dr("OtherCharges").ToString
        End While
        Dim genPercent = Math.Round((Generation / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        Dim transPercent = Math.Round((Transmission / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        Dim sysPercent = Math.Round((SystemLoss / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        Dim disPercent = Math.Round((DistributionMeralco / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        Dim subPercent = Math.Round((Subsidies / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        Dim govPercent = Math.Round((GovernmentTaxes / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        Dim univPercent = Math.Round((UniversalCharges / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        Dim fitPercent = Math.Round((FitAll / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        Dim otherPercent = Math.Round((OtherCharges / TotalAmount) * 100, MidpointRounding.AwayFromZero)

        If billdates = True Then

            Dim lblUser As New Label
            lblUser.Location = New System.Drawing.Point(314, 13)
            lblUser.Name = "lblUser"
            lblUser.TabIndex = 5
            lblUser.Size = New System.Drawing.Size(445, 20)

            lblUser.Text = "Your Breakdown Charges Percentage as of " + Billdate + ""
            lblUser.AutoSize = False
            lblUser.TextAlign = 2
            lblUser.Anchor = AnchorStyles.Top

            lblUser.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)

            Me.Controls.Add(lblUser)
            totalAmt.Text = "P" + TotalAmount

            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Generation", genPercent)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Transmission", transPercent)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("System Loss", sysPercent)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Distribution(Meralco)", disPercent)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Subsidies", subPercent)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Government Taxes", govPercent)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Universal Charges", univPercent)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Fit-All(Renewable)", fitPercent)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Other Charges", otherPercent)
        End If
        Dim genStr As String = genPercent
        Dim transStr As String = transPercent
        Dim sysStr As String = sysPercent
        Dim disStr As String = disPercent
        Dim subStr As String = subPercent
        Dim govStr As String = govPercent
        Dim uniStr As String = univPercent
        Dim fitStr As String = fitPercent
        Dim otherStr As String = otherPercent
        Me.listPercent.Items.Add("Your Generation Percentage: " + genStr + "%")
        Me.listPercent.Items.Add("Transmission Percentage: " + transStr + "%")
        Me.listPercent.Items.Add("System Loss Percentage: " + sysStr + "%")
        Me.listPercent.Items.Add("Distribution(Meralco) Percentage: " + disStr + "%")
        Me.listPercent.Items.Add("Subsidies Percentage: " + subStr + "%")
        Me.listPercent.Items.Add("Government Taxes Percentage: " + govStr + "%")
        Me.listPercent.Items.Add("Universal Charges Percentage: " + uniStr + "%")
        Me.listPercent.Items.Add("Fit-All(Renewable Percentage: " + fitStr + "%")
        Me.listPercent.Items.Add("Other Charges Percentage: " + otherStr + "%")

        cnn.Close()
    End Sub

    Private Sub Jan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn.ConnectionString = _
     "Provider=Microsoft.Jet.OLEDB.4.0;" & _
       "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"
        Me.RefreshData()
        'provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        ''Change the following to your access database location
        'dataFile = "C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb"
        'connString = provider & dataFile
        'cnn.ConnectionString = connString

        ''the query:
        'Dim cmd As OleDbCommand = New OleDbCommand("SELECT ID, " & _
        '                                     "BillDate, TotalKWH, TotalCurrentAmount, NextMeterReading, Generation, Transmission, SystemLoss, Distribution, Subsidies, GovernmentTaxes, UniversalCharges, FitAll, OtherCharges " & _
        '                                     " FROM  [" + getUser + "ElectricBill] ORDER BY BillDate DESC", cnn)
        'cnn.Open()
        'Dim dr As OleDbDataReader = cmd.ExecuteReader
        'Dim billdates As Boolean = False
        'Dim Billdate As String = ""
        'Dim Totalkwh As String = ""
        'Dim TotalAmount As String = ""
        'Dim NextMeter As String = ""
        'Dim Generation As String = ""
        'Dim Transmission As String = ""
        'Dim SystemLoss As String = ""
        'Dim DistributionMeralco As String = ""
        'Dim Subsidies As String = ""
        'Dim GovernmentTaxes As String = ""
        'Dim UniversalCharges As String = ""
        'Dim FitAll As String = ""
        'Dim OtherCharges As String = ""

        'While dr.Read
        '    billdates = True
        '    Billdate = dr("BillDate").ToString
        '    Billdate = FormatDateTime(Convert.ToDateTime(Billdate), DateFormat.ShortDate)
        '    Totalkwh = dr("TotalKWH").ToString
        '    TotalAmount = dr("TotalCurrentAmount").ToString
        '    NextMeter = dr("NextMeterReading").ToString
        '    NextMeter = FormatDateTime(Convert.ToDateTime(NextMeter), DateFormat.ShortDate)
        '    Generation = dr("Generation").ToString
        '    Transmission = dr("Transmission").ToString
        '    SystemLoss = dr("SystemLoss").ToString
        '    DistributionMeralco = dr("Distribution").ToString
        '    Subsidies = dr("Subsidies").ToString
        '    GovernmentTaxes = dr("GovernmentTaxes").ToString
        '    UniversalCharges = dr("UniversalCharges").ToString
        '    FitAll = dr("FitAll").ToString
        '    OtherCharges = dr("OtherCharges").ToString
        'End While
        'Dim genPercent = Math.Round((Generation / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        'Dim transPercent = Math.Round((Transmission / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        'Dim sysPercent = Math.Round((SystemLoss / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        'Dim disPercent = Math.Round((DistributionMeralco / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        'Dim subPercent = Math.Round((Subsidies / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        'Dim govPercent = Math.Round((GovernmentTaxes / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        'Dim univPercent = Math.Round((UniversalCharges / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        'Dim fitPercent = Math.Round((FitAll / TotalAmount) * 100, 2, MidpointRounding.AwayFromZero)
        'Dim otherPercent = Math.Round((OtherCharges / TotalAmount) * 100, MidpointRounding.AwayFromZero)

        'If billdates = True Then

        '    Dim lblUser As New Label
        '    lblUser.Location = New System.Drawing.Point(314, 13)
        '    lblUser.Name = "lblUser"
        '    lblUser.TabIndex = 5
        '    lblUser.Size = New System.Drawing.Size(445, 20)

        '    lblUser.Text = "Your Breakdown Charges Percentage as of " + Billdate + ""
        '    lblUser.AutoSize = False
        '    lblUser.TextAlign = 2
        '    lblUser.Anchor = AnchorStyles.Top

        '    lblUser.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)

        '    Me.Controls.Add(lblUser)
        '    totalAmt.Text = "P" + TotalAmount

        '    Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Generation", genPercent)

        '    Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Transmission", transPercent)
        '    Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("System Loss", sysPercent)
        '    Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Distribution(Meralco)", disPercent)
        '    Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Subsidies", subPercent)
        '    Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Government Taxes", govPercent)
        '    Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Universal Charges", univPercent)
        '    Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Fit-All(Renewable)", fitPercent)
        '    Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Other Charges", otherPercent)




        'End If
        'Dim genStr As String = genPercent
        'Dim transStr As String = transPercent
        'Dim sysStr As String = sysPercent
        'Dim disStr As String = disPercent
        'Dim subStr As String = subPercent
        'Dim govStr As String = govPercent
        'Dim uniStr As String = univPercent
        'Dim fitStr As String = fitPercent
        'Dim otherStr As String = otherPercent
        'Me.listPercent.Items.Add("Your Generation Percentage: " + genStr + "%")
        'Me.listPercent.Items.Add("Transmission Percentage: " + transStr + "%")
        'Me.listPercent.Items.Add("System Loss Percentage: " + sysStr + "%")
        'Me.listPercent.Items.Add("Distribution(Meralco) Percentage: " + disStr + "%")
        'Me.listPercent.Items.Add("Subsidies Percentage: " + subStr + "%")
        'Me.listPercent.Items.Add("Government Taxes Percentage: " + govStr + "%")
        'Me.listPercent.Items.Add("Universal Charges Percentage: " + uniStr + "%")
        'Me.listPercent.Items.Add("Fit-All(Renewable Percentage: " + fitStr + "%")
        'Me.listPercent.Items.Add("Other Charges Percentage: " + otherStr + "%")

        'Feb.getDate = NextMeter
        'Average.getkwh1 = Totalkwh
        'cnn.Close()
        

    End Sub

    Private Sub Chart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart1.Click

    End Sub


    Private Sub Jan_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If Form1.closeProgramAlreadyRequested = False Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to close the program?", "Cancel Setup?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If result = DialogResult.No Then
                e.Cancel = True
            Else
                e.Cancel = False
                Form1.Close()
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form10.Show()
    End Sub

    Private Sub totalAmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles totalAmt.Click

    End Sub
End Class