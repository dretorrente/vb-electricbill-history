Imports System.Data.OleDb
Imports System.ComponentModel
Public Class Form8

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                                             "Generation, Transmission, SystemLoss, Distribution, Subsidies, GovernmentTaxes, UniversalCharges, FitAll, OtherCharges" & _
                                             " FROM  [" + getUser + "ElectricBill] ORDER BY ID", cnn)
        Dim dt As New DataTable
        da.Fill(dt)

        Me.dgvData.DataSource = dt
        cnn.Close()
    End Sub

    Private Sub Form8_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
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


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim cmd As New OleDb.OleDbCommand


        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        cmd.Connection = cnn

        If (txtuserID.Text = "" And Generation.Text = "" And Transmission.Text = "" And SystemLoss.Text = "" And Distribution.Text = "" And Subsidies.Text = "" And GovernmentTaxes.Text = "" And UniversalCharges.Text = "" And FitAll.Text = "" And OtherCharges.Text = "") Then
            MessageBox.Show("Please Fillup the missing fields!")
            Exit Sub
        End If

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
            cmd.CommandText = "INSERT INTO " + getUser + "ElectricBill([ID],[Generation],[Transmission],[SystemLoss],[Distribution],[Subsidies],[GovernmentTaxes],[UniversalCharges],[FitAll],[OtherCharges]) " & _
                " VALUES(?,?,?,?,?,?,?,?,?,?)"
            cmd.Parameters.Add(New OleDbParameter("ID", CType(txtuserID.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Generation", CType(Generation.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Transmission", CType(Transmission.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("SystemLoss", CType(SystemLoss.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Distribution", CType(Distribution.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Subsidies", CType(Subsidies.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("GovernmentTaxes", CType(GovernmentTaxes.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("UniversalCharges", CType(UniversalCharges.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("FitAll", CType(FitAll.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("OtherCharges", CType(OtherCharges.Text, String)))
            cmd.ExecuteNonQuery()
        Else
            cmd.CommandText = "UPDATE " + getUser + "ElectricBill SET ID = @ID, Generation = @Generation, Transmission=@Transmission, SystemLoss=@SystemLoss, Distribution=@Distribution, Subsidies=@Subsidies, GovernmentTaxes=@GovernmentTaxes, UniversalCharges=@UniversalCharges, FitAll=@FitAll, OtherCharges=@OtherCharges WHERE ID=" + Me.txtuserID.Tag.ToString().Trim() + ""
            cmd.Parameters.AddWithValue("@ID", txtuserID.Text)
            cmd.Parameters.AddWithValue("@Generation", Generation.Text)
            cmd.Parameters.AddWithValue("@Transmission", Transmission.Text)
            cmd.Parameters.AddWithValue("@SystemLoss", SystemLoss.Text)
            cmd.Parameters.AddWithValue("@Distribution", Distribution.Text)
            cmd.Parameters.AddWithValue("@Subsidies", Subsidies.Text)
            cmd.Parameters.AddWithValue("@GovernmentTaxes", GovernmentTaxes.Text)
            cmd.Parameters.AddWithValue("@UniversalCharges", UniversalCharges.Text)
            cmd.Parameters.AddWithValue("@FitAll", FitAll.Text)
            cmd.Parameters.AddWithValue("@OtherCharges", OtherCharges.Text)

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

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemLoss.TextChanged

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
                Me.Generation.Text = dt.Rows(0).Item("Generation").ToString
                Me.Transmission.Text = dt.Rows(0).Item("Transmission").ToString
                Me.SystemLoss.Text = dt.Rows(0).Item("SystemLoss").ToString
                Me.Distribution.Text = dt.Rows(0).Item("Distribution").ToString
                Me.Subsidies.Text = dt.Rows(0).Item("Subsidies").ToString
                Me.GovernmentTaxes.Text = dt.Rows(0).Item("GovernmentTaxes").ToString
                Me.UniversalCharges.Text = dt.Rows(0).Item("UniversalCharges").ToString
                Me.FitAll.Text = dt.Rows(0).Item("FitAll").ToString
                Me.OtherCharges.Text = dt.Rows(0).Item("OtherCharges").ToString
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

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Generation.Text = ""
        Me.Transmission.Text = ""
        Me.SystemLoss.Text = ""
        Me.Distribution.Text = ""
        Me.Subsidies.Text = ""
        Me.GovernmentTaxes.Text = ""
        Me.UniversalCharges.Text = ""
        Me.FitAll.Text = ""
        Me.OtherCharges.Text = ""

        Me.txtuserID.Tag = ""
        Me.txtuserID.Text = ""
        Me.txtuserID.Focus()
        Me.btnEdit.Enabled = True
        Me.btnAdd.Text = "Add"
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
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
        
        Form5.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Generation.Text = ""
        Me.Transmission.Text = ""
        Me.SystemLoss.Text = ""
        Me.Distribution.Text = ""
        Me.Subsidies.Text = ""
        Me.GovernmentTaxes.Text = ""
        Me.UniversalCharges.Text = ""
        Me.FitAll.Text = ""
        Me.OtherCharges.Text = ""

        Me.txtuserID.Tag = ""
        Me.txtuserID.Text = ""
        Me.txtuserID.Focus()
        Me.btnEdit.Enabled = True
        Me.btnAdd.Text = "Add"
    End Sub
End Class