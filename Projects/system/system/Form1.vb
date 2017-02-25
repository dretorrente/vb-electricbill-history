Imports System.Data.OleDb
Imports System.ComponentModel
Public Class Form1
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    


    Friend closeProgramAlreadyRequested As Boolean = False

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles login.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        'Change the following to your access database location
        dataFile = "C:\Users\TEST\Documents\Meralco\Projects\system\system\bin\Debug\admin.mdb"
        connString = provider & dataFile
        cnn.ConnectionString = connString

        'the query:
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [users] WHERE [username] = '" & username.Text & "' AND [password] = '" & password.Text & "'", cnn)
        cnn.Open()
        Dim dr As OleDbDataReader = cmd.ExecuteReader
        ' the following variable is hold true if user is found, and false if user is not found
        Dim userFound As Boolean = False
        Dim FirstName As String = ""
        Dim LastName As String = ""
        Dim user As String = ""
        
        'if found:
        While dr.Read
            userFound = True
            FirstName = dr("FirstName").ToString
            LastName = dr("LastName").ToString
            user = dr("username").ToString
            getUser = user
            getFirstName = FirstName
            getLastName = LastName
        End While

        If userFound = True Then
            'Dim cmd2 As OleDbCommand = New OleDbCommand("SELECT * FROM [" + user + "ElectricBill]", cnn)
            'Dim dr1 As OleDbDataReader = cmd2.ExecuteReader
            'Dim eBillHistory As Boolean = False
            'While dr1.Read
            '    eBillHistory = True
            '    ServiceIDNumber = dr1("ServiceIDNumber").ToString
            '    Rate = dr1("Rate").ToString
            '    Contract = dr1("ContractName").ToString
            '    ServiceAddress = dr1("ServiceAddress").ToString
            '    BillDate = dr1("BillDate").ToString
            '    MeterReadingDate = dr1("MeterReadingDate").ToString
            '    BillPeriod = dr1("BillPeriod").ToString
            '    DueDate = dr1("DueDate").ToString
            '    TotalKWH = dr1("TotalKWH").ToString
            '    TotalCurrentAmount = dr1("TotalCurrentAmount").ToString
            '    Generation = dr1("Generation").ToString
            '    Transmission = dr1("Transmission").ToString
            '    SystemLoss = dr1("SystemLoss").ToString
            '    DistributionMeralco = dr1("Distribution").ToString
            '    Subsidies = dr1("Subsidies").ToString
            '    GovernmentTaxes = dr1("GovernmentTaxes").ToString
            '    UniversalCharges = dr1("UniversalCharges").ToString
            '    FitAll = dr1("FitAll").ToString
            '    OtherCharges = dr1("OtherCharges").ToString
            'End While

            'If eBillHistory = True Then

            '    Me.Hide()
            '    Dim serviceInfo As ArrayList = New ArrayList(50)
            '    serviceInfo.Add(ServiceIDNumber)
            '    serviceInfo.Add(Rate)
            '    serviceInfo.Add(Contract)
            '    serviceInfo.Add(ServiceAddress)

            '    Dim serviceIDArray As ArrayList = New ArrayList(10)

            '    Form3.DataGridView1.Rows.Add(serviceInfo.Item(0), serviceInfo.Item(1), serviceInfo.Item(2), serviceInfo.Item(3))
            '    ' Form3.ListBox1.Items.Add("Your Service ID Number is: " + serviceInfo.Item(0))
            '    'Form3.ListBox1.Items.Add("Your Rate is: " + serviceInfo.Item(1))
            '    ' Form3.ListBox1.Items.Add("Your Contract in the name of: " + serviceInfo.Item(2))
            '    'Form3.ListBox1.Items.Add("Your Service Address: " + serviceInfo.Item(3))

            '    Dim billingInfo As ArrayList = New ArrayList(50)

            '    billingInfo.Add(BillDate)
            '    billingInfo.Add(MeterReadingDate)
            '    billingInfo.Add(BillPeriod)
            '    billingInfo.Add(DueDate)
            '    billingInfo.Add(TotalKWH)
            '    billingInfo.Add(TotalCurrentAmount)

            '    Form4.DataGridView1.Rows.Add(billingInfo.Item(0), billingInfo.Item(1), billingInfo.Item(2), billingInfo.Item(3), billingInfo.Item(4), billingInfo.Item(5))
            '    'Form4.ListBox1.Items.Add("Your Bill Date is: " + billingInfo.Item(0))
            '    ' Form4.ListBox1.Items.Add("Your Meter Reading Date is: " + billingInfo.Item(1))
            '    ' Form4.ListBox1.Items.Add("Your Bill Period is: " + billingInfo.Item(2))
            '    ' Form4.ListBox1.Items.Add("Your Due Date: " + billingInfo.Item(3))
            '    ' Form4.ListBox1.Items.Add("Your Total KWH: " + billingInfo.Item(4))
            '    ' Form4.ListBox1.Items.Add("Your Total Current Amount is: " + billingInfo.Item(5))
            '    Dim breakdownInfo As ArrayList = New ArrayList(50)

            '    breakdownInfo.Add(Generation)
            '    breakdownInfo.Add(Transmission)
            '    breakdownInfo.Add(SystemLoss)
            '    breakdownInfo.Add(DistributionMeralco)
            '    breakdownInfo.Add(Subsidies)
            '    breakdownInfo.Add(GovernmentTaxes)
            '    breakdownInfo.Add(UniversalCharges)
            '    breakdownInfo.Add(FitAll)
            '    breakdownInfo.Add(OtherCharges)

            '    Form5.DataGridView1.Rows.Add(breakdownInfo.Item(0), breakdownInfo.Item(1), breakdownInfo.Item(2), breakdownInfo.Item(3), breakdownInfo.Item(4), breakdownInfo.Item(5), breakdownInfo.Item(6), breakdownInfo.Item(7), breakdownInfo.Item(8))
            '    'Form5.ListBox1.Items.Add("Your Generation is: " + breakdownInfo.Item(0))
            '    ' Form5.ListBox1.Items.Add("Your Transmission is: " + breakdownInfo.Item(1))
            '    ' Form5.ListBox1.Items.Add("Your System Loss is: " + breakdownInfo.Item(2))
            '    ' Form5.ListBox1.Items.Add("Your Distribution Meralco is: " + breakdownInfo.Item(3))
            '    ' Form5.ListBox1.Items.Add("Your Subsidies is: " + breakdownInfo.Item(4))
            '    ' Form5.ListBox1.Items.Add("Your Government Taxes is: " + breakdownInfo.Item(5))
            '    ' Form5.ListBox1.Items.Add("Your Universal Charges is: " + breakdownInfo.Item(6))
            '    ' Form5.ListBox1.Items.Add("Your Fit All(Renewable) is: " + breakdownInfo.Item(7))
            '    ' Form5.ListBox1.Items.Add("Your Other Charges is: " + breakdownInfo.Item(8))

            Dim lblUser As New Label
            lblUser.Location = New System.Drawing.Point(87, 25)
            lblUser.Name = "lblUser"
            lblUser.TabIndex = 8
            lblUser.Size = New System.Drawing.Size(320, 35)

            lblUser.Text = "Welcome " + FirstName + ""
            lblUser.AutoSize = False
            lblUser.TextAlign = 2
            lblUser.Anchor = AnchorStyles.Top

            lblUser.Font = New Font("Microsoft Sans Serif", 18, FontStyle.Bold)

            Form2.Controls.Add(lblUser)
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
           

            Form2.Show()

            'End If

        Else
            MsgBox("Sorry, username or password not found", MsgBoxStyle.OkOnly, "Invalid Login")
        End If



        cnn.Close()



    End Sub

    Private Sub password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles password.TextChanged

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form9.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
