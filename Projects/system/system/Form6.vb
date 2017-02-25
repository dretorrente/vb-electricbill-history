Imports System.Data.OleDb
Imports System.ComponentModel
Public Class Form6

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn = New OleDb.OleDbConnection
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
                                             "ServiceIDNumber, Rate, ContractName, ServiceAddress " & _
                                             " FROM  [" + getUser + "ElectricBill] ORDER BY ID", cnn)
        Dim dt As New DataTable
        da.Fill(dt)
        Me.dgvData.DataSource = dt
        Dim i As Integer = 0
        Dim n As Integer = Me.dgvData.Rows.Count
        Dim current As Integer = 0
        Dim previous As Integer = 0
        If n > 0 Then
            While i <> n
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
            
        End If

        cnn.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Form6_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
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

        Me.ServiceID.Text = ""
        Me.Rate.Text = ""
        Me.ContractName.Text = ""
        Me.ServiceAdd.Text = ""

        Me.txtuserID.Tag = ""
        Me.txtuserID.Text = ""
        Me.txtuserID.Focus()
        Me.btnEdit.Enabled = True
        Me.btnAdd.Text = "Add"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim cmd As New OleDb.OleDbCommand

        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        cmd.Connection = cnn
        
        If (txtuserID.Text = "" And ServiceID.Text = "" And Rate.Text = "" And ContractName.Text = "" And ServiceAdd.Text = "") Then
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

            cmd.CommandText = "INSERT INTO " + getUser + "ElectricBill([ID],[ServiceIDNumber],[Rate],[ContractName],[ServiceAddress]) " & _
                    " VALUES(?,?,?,?,?)"
            cmd.Parameters.Add(New OleDbParameter("ID", CType(txtuserID.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("ServiceIDNumber", CType(ServiceID.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Rate", CType(Rate.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("ContractName", CType(ContractName.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("ServiceAddress", CType(ServiceAdd.Text, String)))
            cmd.ExecuteNonQuery()
        Else
            cmd.CommandText = "UPDATE " + getUser + "ElectricBill SET ID = @ID, ServiceIDNumber = @ServiceIDNumber, Rate=@Rate, ContractName=@ContractName, ServiceAddress=@ServiceAddress WHERE ID=" + Me.txtuserID.Tag.ToString().Trim() + ""

            cmd.Parameters.AddWithValue("@ID", txtuserID.Text)
            cmd.Parameters.AddWithValue("@ServiceIDNumber", ServiceID.Text)
            cmd.Parameters.AddWithValue("@Rate", Rate.Text)
            cmd.Parameters.AddWithValue("@ContractName", ContractName.Text)
            cmd.Parameters.AddWithValue("@ServiceAddress", ServiceAdd.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated")
        End If
        dgvData.Refresh()
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
                Me.ServiceID.Text = dt.Rows(0).Item("ServiceIDNumber").ToString
                Me.Rate.Text = dt.Rows(0).Item("Rate").ToString
                Me.ContractName.Text = dt.Rows(0).Item("ContractName").ToString
                Me.ServiceAdd.Text = dt.Rows(0).Item("ServiceAddress").ToString
                Me.txtuserID.Tag = intStdID
                Me.btnAdd.Text = "Update"

                Me.btnEdit.Enabled = False
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
        Jan.RefreshData()
        Feb.RefreshData()
        March.RefreshData()
        Form3.Show()
    End Sub

    Private Sub display_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        
        
        'MessageBox.Show(dgvData.Rows.Count)
    End Sub

    
    Function IsInDatagridview(ByVal cell1 As String, ByVal rowCell1_ID As Integer, ByRef dgv As DataGridView)

        Dim isFound As Boolean = False

        For Each rw As DataGridViewRow In Me.dgvData.Rows
            If rw.Cells(rowCell1_ID).Value.ToString = cell1 Then

                isFound = True
                Return isFound



            End If
        Next

        Return isFound

    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.ServiceID.Text = ""
        Me.Rate.Text = ""
        Me.ContractName.Text = ""
        Me.ServiceAdd.Text = ""

        Me.txtuserID.Tag = ""
        Me.txtuserID.Text = ""
        Me.txtuserID.Focus()
        Me.btnEdit.Enabled = True
        Me.btnAdd.Text = "Add"
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class