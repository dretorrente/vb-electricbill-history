Imports System.Data.OleDb
Imports System.ComponentModel
Public Class Feb
    Dim provider As String
    Dim dataFile As String
    Dim connString As String

    Shared Property getDate As String
    

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


        If (Not IsDBNull(dt.Rows(1).Item("Generation")) And Not IsDBNull(dt.Rows(1).Item("TotalCurrentAmount"))) Then
            Dim genPercent = Math.Round((dt.Rows(1).Item("Generation") / dt.Rows(1).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Generation", genPercent)
            Dim genStr As String = genPercent
            Me.listPercent.Items.Add("Your Generation Percentage: " + genStr + "%")

        End If
        If (Not IsDBNull(dt.Rows(1).Item("Transmission")) And Not IsDBNull(dt.Rows(1).Item("TotalCurrentAmount"))) Then
            Dim transPercent = Math.Round((dt.Rows(1).Item("Transmission") / dt.Rows(1).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Transimission", transPercent)
            Dim transStr As String = transPercent
            Me.listPercent.Items.Add("Transmission Percentage: " + transStr + "%")

        End If
        If (Not IsDBNull(dt.Rows(1).Item("SystemLoss")) And Not IsDBNull(dt.Rows(1).Item("TotalCurrentAmount"))) Then
            Dim sysPercent = Math.Round((dt.Rows(1).Item("SystemLoss") / dt.Rows(1).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("SystemLoss", sysPercent)
            Dim sysStr As String = sysPercent
            Me.listPercent.Items.Add("System Loss Percentage: " + sysStr + "%")


        End If
        If (Not IsDBNull(dt.Rows(1).Item("Distribution")) And Not IsDBNull(dt.Rows(1).Item("TotalCurrentAmount"))) Then
            Dim disPercent = Math.Round((dt.Rows(1).Item("Distribution") / dt.Rows(1).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Distribution", disPercent)
            Dim disStr As String = disPercent
            Me.listPercent.Items.Add("Distribution(Meralco) Percentage: " + disStr + "%")

        End If
        If (Not IsDBNull(dt.Rows(1).Item("Subsidies")) And Not IsDBNull(dt.Rows(1).Item("TotalCurrentAmount"))) Then
            Dim subPercent = Math.Round((dt.Rows(1).Item("Subsidies") / dt.Rows(1).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("Subsidies", subPercent)
            Dim subStr As String = subPercent
            Me.listPercent.Items.Add("Subsidies Percentage: " + subStr + "%")

        End If

        If (Not IsDBNull(dt.Rows(1).Item("GovernmentTaxes")) And Not IsDBNull(dt.Rows(1).Item("TotalCurrentAmount"))) Then
            Dim govPercent = Math.Round((dt.Rows(1).Item("GovernmentTaxes") / dt.Rows(1).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("GovernmentTaxes", govPercent)
            Dim govStr As String = govPercent
            Me.listPercent.Items.Add("Government Taxes Percentage: " + govStr + "%")

        End If
        If (Not IsDBNull(dt.Rows(1).Item("UniversalCharges")) And Not IsDBNull(dt.Rows(1).Item("TotalCurrentAmount"))) Then
            Dim univPercent = Math.Round((dt.Rows(1).Item("UniversalCharges") / dt.Rows(1).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("UniversalCharges", univPercent)
            Dim uniStr As String = univPercent
            Me.listPercent.Items.Add("Universal Charges Percentage: " + uniStr + "%")

        End If

        If (Not IsDBNull(dt.Rows(1).Item("FitAll")) And Not IsDBNull(dt.Rows(1).Item("TotalCurrentAmount"))) Then
            Dim fitPercent = Math.Round((dt.Rows(1).Item("FitAll") / dt.Rows(1).Item("TotalCurrentAmount")) * 100, 2, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("FitAll", fitPercent)
            Dim fitStr As String = fitPercent
            Me.listPercent.Items.Add("Fit-All(Renewable Percentage: " + fitStr + "%")
        End If

        If (Not IsDBNull(dt.Rows(1).Item("OtherCharges")) And Not IsDBNull(dt.Rows(1).Item("TotalCurrentAmount"))) Then
            Dim otherPercent = Math.Round((dt.Rows(1).Item("OtherCharges") / dt.Rows(1).Item("TotalCurrentAmount")) * 100, MidpointRounding.AwayFromZero)
            Me.Chart1.Series("Percentage - Total Amount").Points.AddXY("OtherCharges", otherPercent)
            Dim otherStr As String = otherPercent
            Me.listPercent.Items.Add("Other Charges Percentage: " + otherStr + "%")
        End If

        cnn.Close()
    End Sub

    Private Sub Feb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cnn.ConnectionString = _
      "Provider=Microsoft.Jet.OLEDB.4.0;" & _
        "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"
        Me.RefreshData()

    End Sub

    Private Sub Feb_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form10.Show()
    End Sub
End Class