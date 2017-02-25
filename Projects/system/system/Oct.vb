Public Class Oct

    Private Sub Chart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart1.Click

    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
    Private Sub totalAmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles totalAmt.Click

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form10.Show()

    End Sub

    Private Sub Oct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn.ConnectionString = _
    "Provider=Microsoft.Jet.OLEDB.4.0;" & _
      "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"
        Me.RefreshData()
    End Sub




    Public Sub RefreshData()
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If

        Dim da As New OleDb.OleDbDataAdapter("SELECT ID, " & _
                                             "BillDate, TotalKWH, TotalCurrentAmount, NextMeterReading, Generation, Transmission, SystemLoss, Distribution, Subsidies, GovernmentTaxes, UniversalCharges, FitAll, OtherCharges " & _
                                             " FROM  [" + getUser + "ElectricBill] ORDER BY BillDate ASC", cnn)

        Dim dt As New DataTable
        da.Fill(dt)
        Dim Secmos As Boolean = False


        If (Not IsDBNull(dt.Rows(9).Item("Generation")) And Not IsDBNull(dt.Rows(9).Item("TotalCurrentAmount"))) Then
            Dim genPercent = Math.Round((dt.Rows(9).Item("Generation") / dt.Rows(9).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Generation", genPercent)
            Dim genStr As String = genPercent
            Me.ListBox1.Items.Add("Your Generation Percentage: " + genStr + "%")

        End If
        If (Not IsDBNull(dt.Rows(9).Item("Transmission")) And Not IsDBNull(dt.Rows(9).Item("TotalCurrentAmount"))) Then
            Dim transPercent = Math.Round((dt.Rows(9).Item("Transmission") / dt.Rows(9).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Transimission", transPercent)
            Dim transStr As String = transPercent
            Me.ListBox1.Items.Add("Transmission Percentage: " + transStr + "%")

        End If
        If (Not IsDBNull(dt.Rows(9).Item("SystemLoss")) And Not IsDBNull(dt.Rows(9).Item("TotalCurrentAmount"))) Then
            Dim sysPercent = Math.Round((dt.Rows(9).Item("SystemLoss") / dt.Rows(9).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("SystemLoss", sysPercent)
            Dim sysStr As String = sysPercent
            Me.ListBox1.Items.Add("System Loss Percentage: " + sysStr + "%")


        End If
        If (Not IsDBNull(dt.Rows(9).Item("Distribution")) And Not IsDBNull(dt.Rows(9).Item("TotalCurrentAmount"))) Then
            Dim disPercent = Math.Round((dt.Rows(9).Item("Distribution") / dt.Rows(9).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Distribution", disPercent)
            Dim disStr As String = disPercent
            Me.ListBox1.Items.Add("Distribution(Meralco) Percentage: " + disStr + "%")

        End If
        If (Not IsDBNull(dt.Rows(9).Item("Subsidies")) And Not IsDBNull(dt.Rows(9).Item("TotalCurrentAmount"))) Then
            Dim subPercent = Math.Round((dt.Rows(9).Item("Subsidies") / dt.Rows(9).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Subsidies", subPercent)
            Dim subStr As String = subPercent
            Me.ListBox1.Items.Add("Subsidies Percentage: " + subStr + "%")

        End If

        If (Not IsDBNull(dt.Rows(9).Item("GovernmentTaxes")) And Not IsDBNull(dt.Rows(9).Item("TotalCurrentAmount"))) Then
            Dim govPercent = Math.Round((dt.Rows(9).Item("GovernmentTaxes") / dt.Rows(9).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("GovernmentTaxes", govPercent)
            Dim govStr As String = govPercent
            Me.ListBox1.Items.Add("Government Taxes Percentage: " + govStr + "%")

        End If
        If (Not IsDBNull(dt.Rows(9).Item("UniversalCharges")) And Not IsDBNull(dt.Rows(9).Item("TotalCurrentAmount"))) Then
            Dim univPercent = Math.Round((dt.Rows(9).Item("UniversalCharges") / dt.Rows(9).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("UniversalCharges", univPercent)
            Dim uniStr As String = univPercent
            Me.ListBox1.Items.Add("Universal Charges Percentage: " + uniStr + "%")

        End If

        If (Not IsDBNull(dt.Rows(9).Item("FitAll")) And Not IsDBNull(dt.Rows(9).Item("TotalCurrentAmount"))) Then
            Dim fitPercent = Math.Round((dt.Rows(9).Item("FitAll") / dt.Rows(9).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("FitAll", fitPercent)
            Dim fitStr As String = fitPercent
            Me.ListBox1.Items.Add("Fit-All(Renewable Percentage: " + fitStr + "%")
        End If

        If (Not IsDBNull(dt.Rows(9).Item("OtherCharges")) And Not IsDBNull(dt.Rows(9).Item("TotalCurrentAmount"))) Then
            Dim otherPercent = Math.Round((dt.Rows(9).Item("OtherCharges") / dt.Rows(9).Item("TotalCurrentAmount")) * 100, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("OtherCharges", otherPercent)
            Dim otherStr As String = otherPercent
            Me.ListBox1.Items.Add("Other Charges Percentage: " + otherStr + "%")
        End If




        cnn.Close()
    End Sub
End Class