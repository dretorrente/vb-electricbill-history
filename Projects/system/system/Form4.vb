Imports System.Data.OleDb
Imports System.ComponentModel
Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn.ConnectionString = _
       "Provider=Microsoft.Jet.OLEDB.4.0;" & _
         "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"
        Me.RefreshData()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Form4_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
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


    Private Sub dgvData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellContentClick

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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        cnn.ConnectionString = _
        "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"
        Form7.RefreshData()
        Average.RefreshData()
        Form7.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class