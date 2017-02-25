Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Globalization

Public Class Form7

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn.ConnectionString = _
        "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"
        Me.RefreshData()
    End Sub



    Private Sub Form7_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        Me.BillDate.Text = ""
        Me.MeterReading.Text = ""
        Me.BillPeriod.Text = ""
        Me.DueDate.Text = ""
        Me.TotalKWH.Text = ""
        Me.TotalAmount.Text = ""
        Me.NextMeter.Text = ""
        Me.txtuserID.Tag = ""
        Me.txtuserID.Text = ""
        Me.txtuserID.Focus()
        Me.btnEdit.Enabled = True
        Me.btnAdd.Text = "Add"
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Public Sub RefreshData()
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT ID, " & _
                                             "BillDate, MeterReadingDate, BillPeriod, DueDate, TotalKWH, TotalCurrentAmount, NextMeterReading " & _
                                             " FROM  [" + getUser + "ElectricBill] ORDER BY ID", cnn)
        Dim dt As New DataTable
        da.Fill(dt)

        Me.dgvData.DataSource = dt
        cnn.Close()
    End Sub
    Private Sub ConvertToDateTime(ByVal value As String)
        Dim convertedDate As Date
        Try
            convertedDate = Convert.ToDateTime(value)
            Console.WriteLine("'{0}' converts to {1}.", value, convertedDate)
        Catch e As FormatException
            Console.WriteLine("'{0}' is not in the proper format.", value)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim cmd As New OleDb.OleDbCommand


        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        cmd.Connection = cnn

        If (txtuserID.Text = "" And BillDate.Text = "" And MeterReading.Text = "" And BillPeriod.Text = "" And DueDate.Text = "" And TotalKWH.Text = "" And TotalAmount.Text = "" And NextMeter.Text = "") Then
            MessageBox.Show("Please Fillup the missing fields!")
            Exit Sub
        End If
        Dim d As DateTime
        Dim BillsDate As String = String.Empty
        Dim MeterReadings As String = String.Empty
        Dim NextMeters As String = String.Empty
        Dim DueDates As String = String.Empty


        If Me.txtuserID.Tag & "" = "" Then
            If txtuserID.Text = "" Then
                Dim i As Integer = 0

                Dim current As Integer = 0
                Dim previous As Integer = 0
                Dim idCounter As Integer
                If dgvData.Rows.Count > 0 Then
                    While i <> dgvData.Rows.Count
                        serviceInfo.Remove(Me.dgvData.Rows(previous).Cells("id").Value)
                        previous += 1
                        serviceInfo.Add(Me.dgvData.Rows(current).Cells("id").Value)
                        'MessageBox.Show(String.Join(vbNewLine, serviceInfo.ToArray()))
                        current += 1
                        i += 1
                        'MessageBox.Show(n)
                    End While
                    'For Each element In serviceInfo
                    '    MessageBox.Show(element)
                    'Next
                    'MessageBox.Show(String.Join(vbNewLine, serviceInfo1.ToArray()))
                    Dim arrCount = serviceInfo.Count
                    idCounter = arrCount + 1
                    txtuserID.Text = idCounter
                End If
            End If

            If Me.dgvData.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim n As Integer = Me.dgvData.Rows.Count
                Dim str1 As String
                Dim str2 As String
                Dim previous As Integer = 0
                Dim boolFound As Boolean = False
                While i <> n
                    str1 = Me.dgvData.Rows(i).Cells("id").Value.ToString.Trim()
                    str2 = txtuserID.Text
                    If str1 = str2 Then
                        boolFound = True
                        MessageBox.Show("same id")
                        txtuserID.Text = ""
                        txtuserID.Focus()
                        Exit Sub

                    End If
                    i += 1
                    previous += 1
                End While

            End If
            If BillDate.Text <> "" Then
                If Not IsDate(BillDate.Text) Then
                    MessageBox.Show("Please input a valid format")
                    Exit Sub
                Else
                    If DateTime.TryParse(BillDate.Text, d) Then
                        BillsDate = d.ToString("MM/dd/yyyy")
                    End If

                    'If DateTime.TryParse(BillPeriod.Text, d) Then
                    '    BillPeriods = d.ToString("MM/dd/yyyy")
                    'End If
                    'If DateTime.TryParse(DueDate.Text, d) Then
                    '    DueDates = d.ToString("MM/dd/yyyy")
                    'End If
                End If
            ElseIf BillDate.Text = "" Then
                Dim DOB As Nullable(Of Date) = Date.Now
                Dim datestring As String = DOB.Value.ToString("d")

                'DOB = Nothing
                BillsDate = datestring

            End If
            If MeterReading.Text <> "" Then
                If Not IsDate(MeterReading.Text) Then
                    MessageBox.Show("Please input a valid format")
                    Exit Sub
                Else
                    If DateTime.TryParse(MeterReading.Text, d) Then
                        MeterReadings = d.ToString("MM/dd/yyyy")
                    End If
                End If
            ElseIf MeterReading.Text = "" Then
                Dim DOB As Nullable(Of Date) = Date.Now
                Dim datestring As String = DOB.Value.ToString("d")

                'DOB = Nothing
                MeterReadings = datestring
            End If

            If DueDate.Text <> "" Then
                If Not IsDate(DueDate.Text) Then
                    MessageBox.Show("Please input a valid format")
                    Exit Sub
                Else
                    If DateTime.TryParse(DueDate.Text, d) Then
                        DueDates = d.ToString("MM/dd/yyyy")
                    End If
                End If
            ElseIf DueDate.Text = "" Then
                Dim DOB As Nullable(Of Date) = Date.Now
                Dim datestring As String = DOB.Value.ToString("d")

                'DOB = Nothing
                DueDates = datestring
            End If

            If NextMeter.Text <> "" Then
                If Not IsDate(NextMeter.Text) Then
                    MessageBox.Show("Please input a valid format")
                    Exit Sub
                Else
                    If DateTime.TryParse(NextMeter.Text, d) Then
                        NextMeters = d.ToString("MM/dd/yyyy")
                    End If
                End If
            ElseIf NextMeter.Text = "" Then
                Dim DOB As Nullable(Of Date) = Date.Now
                Dim datestring As String = DOB.Value.ToString("d")

                'DOB = Nothing
                NextMeters = datestring
            End If



            cmd.CommandText = "INSERT INTO " + getUser + "ElectricBill([ID],[BillDate],[MeterReadingDate],[BillPeriod],[DueDate],[TotalKWH],[TotalCurrentAmount],[NextMeterReading]) " & _
                " VALUES(?,?,?,?,?,?,?,?)"
            cmd.Parameters.Add(New OleDbParameter("ID", CType(txtuserID.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("BillDate", CType(BillsDate, Date)))
            cmd.Parameters.Add(New OleDbParameter("MeterReadingDate", CType(MeterReadings, Date)))
            cmd.Parameters.Add(New OleDbParameter("BillPeriod", CType(BillPeriod.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("DueDate", CType(DueDates, Date)))
            cmd.Parameters.Add(New OleDbParameter("TotalKWH", CType(TotalKWH.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("TotalCurrentAmount", CType(TotalAmount.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("NextMeterReading", CType(NextMeters, Date)))
            cmd.ExecuteNonQuery()
        Else
            If BillDate.Text <> "" Then
                If Not IsDate(BillDate.Text) Then
                    MessageBox.Show("Please input a valid format")
                    Exit Sub
                Else
                    If DateTime.TryParse(BillDate.Text, d) Then
                        BillsDate = d.ToString("MM/dd/yyyy")
                    End If

                    'If DateTime.TryParse(BillPeriod.Text, d) Then
                    '    BillPeriods = d.ToString("MM/dd/yyyy")
                    'End If
                    'If DateTime.TryParse(DueDate.Text, d) Then
                    '    DueDates = d.ToString("MM/dd/yyyy")
                    'End If
                End If
            ElseIf BillDate.Text = "" Then
                Dim DOB As Nullable(Of Date) = Date.Now
                Dim datestring As String = DOB.Value.ToString("d")
                BillsDate = DateTime.MinValue.ToShortDateString()
                'DOB = Nothing
                BillsDate = datestring

            End If
            If MeterReading.Text <> "" Then
                If Not IsDate(MeterReading.Text) Then
                    MessageBox.Show("Please input a valid format")
                    Exit Sub
                Else
                    If DateTime.TryParse(MeterReading.Text, d) Then
                        MeterReadings = d.ToString("MM/dd/yyyy")
                    End If
                End If
            ElseIf MeterReading.Text = "" Then
                Dim DOB As Nullable(Of Date) = Date.Now
                Dim datestring As String = DOB.Value.ToString("d")
                MeterReadings = DateTime.MinValue.ToShortDateString()
                'DOB = Nothing
                MeterReadings = datestring
            End If

            If DueDate.Text <> "" Then
                If Not IsDate(DueDate.Text) Then
                    MessageBox.Show("Please input a valid format")
                    Exit Sub
                Else
                    If DateTime.TryParse(DueDate.Text, d) Then
                        DueDates = d.ToString("MM/dd/yyyy")
                    End If
                End If
            ElseIf DueDate.Text = "" Then
                Dim DOB As Nullable(Of Date) = Date.Now
                Dim datestring As String = DOB.Value.ToString("d")
                DueDates = DateTime.MinValue.ToShortDateString()
                DueDates = datestring
            End If
            If NextMeter.Text <> "" Then
                If Not IsDate(NextMeter.Text) Then
                    MessageBox.Show("Please input a valid format")
                    Exit Sub
                Else
                    If DateTime.TryParse(NextMeter.Text, d) Then
                        NextMeters = d.ToString("MM/dd/yyyy")
                    End If
                End If
            ElseIf NextMeter.Text = "" Then
                Dim DOB As Nullable(Of Date) = Date.Now
                Dim datestring As String = DOB.Value.ToString("d")

                'DOB = Nothing
                NextMeters = datestring
            End If
            cmd.CommandText = "UPDATE " + getUser + "ElectricBill SET ID = @ID, BillDate = @BillDate, MeterReadingDate=@MeterRead, BillPeriod=@BillPeriod, DueDate=@DueDate, TotalKWH=@TotalKWH, TotalCurrentAmount=@TotalAmount, NextMeterReading=@NextMeterRead WHERE ID=" + Me.txtuserID.Tag.ToString().Trim() + ""

            cmd.Parameters.AddWithValue("@ID", txtuserID.Text)
            cmd.Parameters.AddWithValue("@BillDate", CType(BillsDate, Date))
            cmd.Parameters.AddWithValue("@MeterRead", CType(MeterReadings, Date))
            cmd.Parameters.AddWithValue("@BillPeriod", BillPeriod.Text)
            cmd.Parameters.AddWithValue("@DueDate", CType(DueDates, Date))
            cmd.Parameters.AddWithValue("@TotalKWH", TotalKWH.Text)
            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount.Text)
            cmd.Parameters.AddWithValue("@NextMeterRead", CType(NextMeters, Date))



            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated")
        End If
        RefreshData()
        Jan.Dispose()
        Feb.Dispose()
        March.Dispose()
        April.Dispose()
        May.Dispose()
        June.Dispose()
        July.Dispose()
        Aug.Dispose()
        Sep.Dispose()
        Nov.Dispose()
        Dec.Dispose()
        Average.Dispose()
        Me.btnClear.PerformClick()
        cnn.Close()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvData.Rows.Count > 0 Then
            If Me.dgvData.SelectedRows.Count > 0 Then
                Dim intStdID As Integer = Me.dgvData.SelectedRows(0).Cells("id").Value

                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If
                Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [" + getUser + "ElectricBill] WHERE [ID]=" & intStdID, cnn)
                Dim dt As New DataTable
                da.Fill(dt)

                Me.txtuserID.Text = intStdID
                If Not IsDBNull(dt.Rows(0).Item("BillDate")) Then
                    Me.BillDate.Text = dt.Rows(0).Item("BillDate").ToShortDateString()
                    Me.BillDate.Text = FormatDateTime(Convert.ToDateTime(Me.BillDate.Text), DateFormat.ShortDate)
                End If
                If Not IsDBNull(dt.Rows(0).Item("MeterReadingDate")) Then
                    Me.MeterReading.Text = dt.Rows(0).Item("MeterReadingDate").ToString
                    Me.MeterReading.Text = FormatDateTime(Convert.ToDateTime(Me.MeterReading.Text), DateFormat.ShortDate)
                End If
                If Not IsDBNull(dt.Rows(0).Item("DueDate")) Then
                    Me.DueDate.Text = dt.Rows(0).Item("DueDate").ToString
                    Me.DueDate.Text = FormatDateTime(Convert.ToDateTime(Me.DueDate.Text), DateFormat.ShortDate)
                End If
                If Not IsDBNull(dt.Rows(0).Item("NextMeterReading")) Then
                    Me.NextMeter.Text = dt.Rows(0).Item("NextMeterReading").ToString
                    Me.NextMeter.Text = FormatDateTime(Convert.ToDateTime(Me.NextMeter.Text), DateFormat.ShortDate)
                End If

                Me.BillPeriod.Text = dt.Rows(0).Item("BillPeriod").ToString
                
                Me.TotalKWH.Text = dt.Rows(0).Item("TotalKWH").ToString
                Me.TotalAmount.Text = dt.Rows(0).Item("TotalCurrentAmount").ToString
               

                Me.txtuserID.Tag = intStdID
                Me.btnAdd.Text = "Update"

                Me.btnEdit.Enabled = False
                cnn.Close()

            End If
        End If
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

        If Me.dgvData.Rows.Count > 0 Then
            If Me.dgvData.SelectedRows.Count > 0 Then
                Dim intStdID As Integer = Me.dgvData.SelectedRows(0).Cells("id").Value
                If Not cnn.State = ConnectionState.Open Then
                    cnn.Open()
                End If

                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = cnn
                cmd.CommandText = "DELETE * FROM [" + getUser + "ElectricBill] WHERE [ID]=" & intStdID
                cmd.ExecuteNonQuery()
                Me.RefreshData()
                cnn.Close()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = _
        "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"
        Form3.dgvData.Refresh()
        Form3.RefreshData()
        Form4.dgvData.Refresh()
        Form4.RefreshData()
        Form5.dgvData.Refresh()
        Form5.RefreshData()
        
        Form4.Show()
    End Sub

    Private Sub BillDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillDate.TextChanged

    End Sub
    Private Const _cust_Format As String = "        "

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.BillDate.Text = ""
        Me.MeterReading.Text = ""
        Me.BillPeriod.Text = ""
        Me.DueDate.Text = ""
        Me.TotalKWH.Text = ""
        Me.TotalAmount.Text = ""
        Me.NextMeter.Text = ""
        Me.txtuserID.Tag = ""
        Me.txtuserID.Text = ""
        Me.txtuserID.Focus()
        Me.btnEdit.Enabled = True
        Me.btnAdd.Text = "Add"
    End Sub
End Class