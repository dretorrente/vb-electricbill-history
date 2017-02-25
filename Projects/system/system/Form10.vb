Public Class Form10

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Jan.Refresh()
        Feb.Refresh()
        March.Refresh()
    End Sub




    Private Sub Form10_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub btnJan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJan.Click
        Me.Hide()
        Jan.Show()
    End Sub

    Private Sub btnFeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFeb.Click
        Me.Hide()
        Feb.Show()
    End Sub

    Private Sub btnMar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMar.Click
        Me.Hide()
        March.Show()

    End Sub

    Private Sub btnApr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApr.Click
        Me.Hide()
        April.Show()
    End Sub

    Private Sub btnMay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMay.Click
        Me.Hide()
        May.Show()
    End Sub

    Private Sub btnJun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJun.Click
        Me.Hide()
        June.Show()
    End Sub

    Private Sub btnJul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJul.Click
        Me.Hide()
        July.Show()
    End Sub

    Private Sub btnAug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAug.Click
        Me.Hide()
        Aug.Show()
    End Sub

    Private Sub btnSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSep.Click
        Me.Hide()
        Sep.Show()
    End Sub

    Private Sub btnOct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOct.Click
        Me.Hide()
        Oct.Show()
    End Sub

    Private Sub btnNov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNov.Click
        Me.Hide()
        Nov.Show()
    End Sub

    Private Sub btnDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDec.Click
        Me.Hide()
        Dec.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form3.dgvData.Refresh()
        Form3.RefreshData()
        Form4.dgvData.Refresh()
        Form4.RefreshData()
        Form5.dgvData.Refresh()
        Form5.RefreshData()
        Average.Show()
    End Sub
End Class