Imports System.Data.OleDb
Imports System.ComponentModel
Public Class Form9

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FirstName As String = TextBox1.Text
        Dim LastName As String = TextBox2.Text
        Dim Username As String = TextBox3.Text
        Dim pass As String = TextBox4.Text
        Dim confirm As String = TextBox5.Text
        If pass <> confirm Then
            MessageBox.Show("Password doesn't match")
        Else
            Dim connectionString As String = _
                "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                "Data Source=C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb;"
            Using con As New OleDbConnection(connectionString)
                con.Open()
                Using cmd As New OleDbCommand()
                    cmd.Connection = con
                    cmd.CommandText = _
                        "Create TABLE " + Username + "ElectricBill (ID COUNTER, FirstName TEXT, LastName TEXT, ServiceIDNumber TEXT, Rate TEXT, ContractName TEXT, ServiceAddress TEXT, BillDate TEXT, MeterReadingDate TEXT, BillPeriod TEXT, DueDate TEXT, TotalKWH TEXT, TotalCurrentAmount TEXT, Generation TEXT, Transmission TEXT, SystemLoss TEXT, Distribution TEXT, Subsidies TEXT, GovernmentTaxes TEXT, UniversalCharges TEXT, FitAll TEXT, OtherCharges TEXT )"
                   
                    Try
                        cmd.ExecuteNonQuery()

                        MsgBox("Table created")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    cmd.CommandText = "Insert into users([FirstName],[LastName],[username],[password]) Values(?,?,?,?)"
                    cmd.Parameters.Add(New OleDbParameter("FirstName", CType(FirstName, String)))
                    cmd.Parameters.Add(New OleDbParameter("LastName", CType(LastName, String)))
                    cmd.Parameters.Add(New OleDbParameter("username", CType(Username, String)))
                    cmd.Parameters.Add(New OleDbParameter("password", CType(pass, String)))
                    'cmd.CommandText = "Insert into " + Username + "ElectricBill([FirstName],[LastName]) Values(?,?)"
                    ' cmd.Parameters.Add(New OleDbParameter("FirstName", CType(FirstName, String)))
                    'cmd.Parameters.Add(New OleDbParameter("LastName", CType(LastName, String)))
                    Try
                        cmd.ExecuteNonQuery()
                        MsgBox("Tnsert Success users")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    cmd.CommandText = "Insert into " + Username + "ElectricBill([FirstName],[LastName]) Values(?,?)"
                    cmd.Parameters.Add(New OleDbParameter("FirstName", CType(FirstName, String)))
                    cmd.Parameters.Add(New OleDbParameter("LastName", CType(LastName, String)))
                    Try
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        TextBox5.Clear()
                        MsgBox("Tnsert Success bills")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                End Using
                con.Close()

            End Using

        End If
        Me.Hide()
        Form1.Show()
        
    End Sub

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class