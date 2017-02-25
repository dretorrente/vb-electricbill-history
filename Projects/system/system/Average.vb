Imports System.Data.OleDb
Imports System.ComponentModel
Public Class Average
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim cnn As OleDbConnection = New OleDbConnection
   


    Private Sub Average_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        'Change the following to your access database location
        dataFile = "C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb"
        connString = provider & dataFile
        cnn.ConnectionString = connString

        'the query:
        Dim da As New OleDb.OleDbDataAdapter("SELECT BillDate, TotalKWH " & _
                                            " FROM  [" + getUser + "ElectricBill] ORDER BY BillDate ASC", cnn)

        cnn.Open()
        Dim dt As New DataTable
        da.Fill(dt)

        Dim i As Integer = 0

        While i <> dt.Rows.Count
            Me.Chart1.Series("Average Usage for 12 months").Points.AddXY(FormatDateTime(Convert.ToDateTime(dt.Rows(i).Item("BillDate"))), dt.Rows(i).Item("TotalKWH"))
            i += 1
        End While

        'FirstMonth = FormatDateTime(Convert.ToDateTime(dt.Rows(0).Item("BillDate")), DateFormat.ShortDate)
        'SecondMonth = FormatDateTime(Convert.ToDateTime(dt.Rows(1).Item("BillDate")), DateFormat.ShortDate)
        'Totalkwh1 = dt.Rows(0).Item("TotalKWH")
        'Totalkwh2 = dt.Rows(1).Item("TotalKWH")
        'Me.Chart1.Series("Average Usage for 12 months").Points.AddXY(FirstMonth, Totalkwh1)
        'Me.Chart1.Series("Average Usage for 12 months").Points.AddXY(SecondMonth, Totalkwh2)
        cnn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form10.Show()
    End Sub

    Public Sub RefreshData()

        'If Not cnn.State = ConnectionState.Open Then
        '    cnn.Open()
        'End If
        'Dim cmd As OleDbCommand = New OleDbCommand("SELECT ID, " & _
        '                                      "BillDate, TotalKWH, TotalCurrentAmount, NextMeterReading, Generation, Transmission, SystemLoss, Distribution, Subsidies, GovernmentTaxes, UniversalCharges, FitAll, OtherCharges " & _
        '                                      " FROM  [" + getUser + "ElectricBill] ORDER BY BillDate DESC", cnn)
        'Dim dr As OleDbDataReader = cmd.ExecuteReader
        'Dim billdates As Boolean = False
        'Dim Billdate As String = ""
        'Dim Totalkhw As String = ""
        'Dim NextMeters As String = ""

        'Dim months As Boolean = False

        'While dr.Read
        '    billdates = True
        '    Billdate = dr("BillDate").ToString
        '    Billdate = FormatDateTime(Convert.ToDateTime(Billdate), DateFormat.ShortDate)
        '    Totalkhw = dr("TotalKWH").ToString

        '    NextMeters = dr("NextMeterReading").ToString
        '    Me.Chart1.Series("Average Usage for 12 months").Points.AddXY(Billdate, Totalkhw)

        'End While

        'If billdates = True Then
        '    Dim cmd1 As OleDbCommand = New OleDbCommand("SELECT ID, " & _
        '                                 "BillDate, TotalKWH, TotalCurrentAmount, NextMeterReading, Generation, Transmission, SystemLoss, Distribution, Subsidies, GovernmentTaxes, UniversalCharges, FitAll, OtherCharges " & _
        '                                 " FROM  [" + getUser + "ElectricBill] WHERE BillDate= #" + NextMeters + "#", cnn)
        '    While dr.Read

        '        Billdate = dr("BillDate").ToString
        '        Billdate = FormatDateTime(Convert.ToDateTime(Billdate), DateFormat.ShortDate)
        '        Totalkhw = dr("TotalKWH").ToString
        '        NextMeters = dr("NextMeterReading").ToString
        '        Me.Chart1.Series("Average Usage for 12 months").Points.AddXY(NextMeters, Totalkhw)
        '    End While
        'End If


        'cnn.Close()

    End Sub


   
End Class