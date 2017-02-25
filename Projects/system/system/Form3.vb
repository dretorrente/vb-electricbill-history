Imports System.Data.OleDb
Imports System.ComponentModel

Public Class Form3
    

    Friend closeProgramAlreadyRequested As Boolean = False


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Form3.DataGridView1.Rows.Add(serviceInfo.Item(0), serviceInfo.Item(1), serviceInfo.Item(2), serviceInfo.Item(3))
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = _
        "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"
       
        Me.RefreshData()
        dgvData.Refresh()
    End Sub

    Public Sub RefreshData()
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT ID, " & _
                                             "ServiceIDNumber, Rate, ContractName, ServiceAddress " & _
                                             " FROM  [" + getUser + "ElectricBill] ORDER BY ID", cnn)
        Dim dt As New DataTable
        Dim ds = New DataSet
        da.Fill(dt)
        Me.dgvData.DataSource = dt

        Dim n As Integer = Me.dgvData.Rows.Count
        'dt.Rows.Count      
        'sampleLabel.Text = dt.Rows(1).Item("id")
        'sampleLabel.Text = Me.dgvData.Rows(0).Cells("id").Value

        Dim i As Integer = 1
        Dim current As Integer = 0
        Dim previous As Integer = 0

        Dim serviceID As ArrayList = New ArrayList
        Dim serviceRate As ArrayList = New ArrayList
        Dim serviceCName As ArrayList = New ArrayList
        Dim serviceAdd As ArrayList = New ArrayList
        Dim serviceTotal As ArrayList = New ArrayList
        Dim counter As Integer = 0
        Dim insertLoop As Boolean = False


        '        While i <> n
        '            GoTo insert
        'insert:
        '            insertLoop = True
        '            serviceID.Remove(dt.Rows(previous).Item("ServiceIDNumber"))
        '            serviceRate.Remove(dt.Rows(previous).Item("Rate"))
        '            serviceCName.Remove(dt.Rows(previous).Item("ContractName"))
        '            serviceAdd.Remove(dt.Rows(previous).Item("ServiceAddress"))

        '            previous += 1
        '            serviceID.Add(dt.Rows(current).Item("ServiceIDNumber"))
        '            serviceRate.Add(dt.Rows(current).Item("Rate"))
        '            serviceCName.Add(dt.Rows(current).Item("ContractName"))
        '            serviceAdd.Add(dt.Rows(current).Item("ServiceAddress"))


        '            While insertLoop = True

        '                'Dim row = New DataGridViewRow()
        '                'dgvData.Rows.Add(row)
        '                Me.dgvData.Rows.Add(serviceID.Item(current), serviceRate.Item(current), serviceCName.Item(current), serviceAdd.Item(current))
        '                current += 1
        '                GoTo Looping

        '            End While
        'Looping:


        '            i += 1
        '            sampleLabel.Text = Me.dgvData.Rows.Count
        '            countlbl.Text = current
        '            countlbl.Text = i

        '            GoTo insert



        '        End While


        'While insertLoop = True
        '    Me.dgvData.Rows.Add(serviceID.Item(i), serviceRate.Item(i), serviceCName.Item(i), serviceAdd.Item(i))
        'End While




        'For i = 0 To n
        '    insertLoop = True
        '    serviceID.Remove(dt.Rows(previous).Item("ServiceIDNumber"))
        '    serviceRate.Remove(dt.Rows(previous).Item("Rate"))
        '    serviceCName.Remove(dt.Rows(previous).Item("ContractName"))
        '    serviceAdd.Remove(dt.Rows(previous).Item("ServiceAddress"))

        '    previous += 1
        '    serviceID.Add(dt.Rows(current).Item("ServiceIDNumber"))
        '    serviceRate.Add(dt.Rows(current).Item("Rate"))
        '    serviceCName.Add(dt.Rows(current).Item("ContractName"))
        '    serviceAdd.Add(dt.Rows(current).Item("ServiceAddress"))


        '    current += 1
        '    i += 1

        'Next
        'While i = Me.dgvData.Rows.Count
        '    insertLoop = True
        '    serviceID.Remove(dt.Rows(previous).Item("ServiceIDNumber"))
        '    serviceRate.Remove(dt.Rows(previous).Item("Rate"))
        '    serviceCName.Remove(dt.Rows(previous).Item("ContractName"))
        '    serviceAdd.Remove(dt.Rows(previous).Item("ServiceAddress"))

        '    previous += 1
        '    serviceID.Add(dt.Rows(current).Item("ServiceIDNumber"))
        '    serviceRate.Add(dt.Rows(current).Item("Rate"))
        '    serviceCName.Add(dt.Rows(current).Item("ContractName"))
        '    serviceAdd.Add(dt.Rows(current).Item("ServiceAddress"))


        '    current += 1
        '    i += 1



        'End While
        'While insertLoop = True

        '    Me.dgvData.Rows.Add(serviceID.Item(counter), serviceRate.Item(counter), serviceCName.Item(counter), serviceAdd.Item(counter))
        '    sampleLabel.Text = Me.dgvData.Rows.Count
        '    countlbl.Text = counter
        '    counter += 1
        'End While


        ' counter += 1


        ' Me.dgvData.Rows.Add(serviceID.Item(i), serviceRate.Item(i), serviceCName.Item(i), serviceAdd.Item(i))

        'If counter = Me.dgvData.Rows.Count Then
        '    Me.dgvData.Rows.Add(serviceID.Item(counter), serviceRate.Item(counter), serviceCName.Item(counter), serviceAdd.Item(counter))

        '    sampleLabel.Text = Me.dgvData.Rows.Count
        '    countlbl.Text = counter
        'End If

        'counter += 1

        'Me.dgvData.Rows.Add(serviceID.Item(current), serviceRate.Item(current), serviceCName.Item(current), serviceAdd.Item(current))
        'MessageBox.Show(String.Join(vbNewLine, serviceInfo.ToArray()))


        'End While
        





        cnn.Close()
    End Sub

    Private Sub Form3_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing


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
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = _
        "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"

        Me.RefreshData()
        Form2.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(sample2)
    End Sub



    Private Sub dgvData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = _
        "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"

        Form6.RefreshData()
        Form6.Show()
    End Sub
End Class