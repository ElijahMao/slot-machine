Public Class Form1

    Dim photo() As String = {"7", "企鵝", "沙漠", "無尾熊", "菊花", "鬱金香", "繡球花", "水母", "燈塔"}
    Dim n1, n2, n3 As Integer, total As Integer = 1000
    Dim r As New Random()

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = total.ToString()
        NumericUpDown1.Maximum = total
        NumericUpDown1.Value = "100"
        btn_reset.Enabled = False
    End Sub

    Private Sub btn_AllIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AllIn.Click
        NumericUpDown1.Value = total
    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        PictureBox1.Image = New Bitmap("7.png")
        PictureBox2.Image = New Bitmap("7.png")
        PictureBox3.Image = New Bitmap("7.png")
        total = 1000
        TextBox1.Text = total.ToString()
        NumericUpDown1.Maximum = total
        NumericUpDown1.Value = "100"
        NumericUpDown1.Enabled = True
        Button1.Enabled = True
        btn_reset.Enabled = False
        btn_AllIn.Enabled = True
        lbl_state.Text = "請按啟動開始遊戲"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Timer1.Enabled = False Then
            If NumericUpDown1.Value = 0 Then
                MessageBox.Show("請選擇投注量")
            Else
                lbl_state.Text = ""
                Timer1.Interval = 1
                Timer1.Enabled = True
                Button1.Text = "停止"
                btn_reset.Enabled = False
                btn_AllIn.Enabled = False
                NumericUpDown1.Enabled = False
            End If
        ElseIf Timer1.Enabled = True Then
            Timer1.Enabled = False
            btn_AllIn.Enabled = True
            NumericUpDown1.Enabled = True

            If n1 = n2 Then
                If n2 = n3 Then
                    If n1 = 0 Then
                        lbl_state.ForeColor = Color.Red
                        lbl_state.Text = "恭喜中頭獎，獲得100倍獎金!!!"
                        total += NumericUpDown1.Value * 100
                    Else
                        lbl_state.ForeColor = Color.Red
                        lbl_state.Text = "恭喜中特獎，獲得10倍獎金!!!"
                        total += NumericUpDown1.Value * 10
                    End If
                Else
                    If n1 = 0 Then
                        lbl_state.ForeColor = Color.Red
                        lbl_state.Text = "恭喜中獎，獲得5倍獎金"
                        total += NumericUpDown1.Value * 5
                    Else
                        lbl_state.ForeColor = Color.Brown
                        lbl_state.Text = "恭喜中獎"
                        total += NumericUpDown1.Value
                    End If
                End If
            Else
                If n2 = n3 Then
                    If n2 = 0 Then
                        lbl_state.ForeColor = Color.Red
                        lbl_state.Text = "恭喜中獎，獲得5倍獎金"
                        total += NumericUpDown1.Value * 5
                    Else
                        lbl_state.ForeColor = Color.Brown
                        lbl_state.Text = "恭喜中獎"
                        total += NumericUpDown1.Value
                    End If
                ElseIf n1 = n3 Then
                    If n1 = 0 Then
                        lbl_state.ForeColor = Color.Red
                        lbl_state.Text = "恭喜中獎，獲得5倍獎金"
                        total += NumericUpDown1.Value * 5
                    Else
                        lbl_state.ForeColor = Color.Brown
                        lbl_state.Text = "恭喜中獎"
                        total += NumericUpDown1.Value
                    End If
                Else
                    If n1 = 0 Or n2 = 0 Or n3 = 0 Then
                        lbl_state.ForeColor = Color.Red
                        lbl_state.Text = "恭喜中獎，獲得3倍獎金"
                        total += NumericUpDown1.Value * 3
                    Else
                        total -= NumericUpDown1.Value
                        lbl_state.ForeColor = Color.Black
                        lbl_state.Text = "真可惜"
                    End If
                End If
            End If

            Button1.Text = "啟動"
            TextBox1.Text = total.ToString()
            NumericUpDown1.Maximum = total
            If total <= 0 Then
                MessageBox.Show("破產了QQ")
                NumericUpDown1.Value = 0
                NumericUpDown1.Enabled = False
                Button1.Enabled = False
                btn_reset.Enabled = True
                btn_AllIn.Enabled = False
                lbl_state.Text = "請按重來重新遊戲"
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        n1 = r.Next(0, 8)
        PictureBox1.Image = New Bitmap(photo(n1).ToString() & ".jpg")

        n2 = r.Next(0, 8)
        PictureBox2.Image = New Bitmap(photo(n2).ToString() & ".jpg")

        n3 = r.Next(0, 8)
        PictureBox3.Image = New Bitmap(photo(n3).ToString() & ".jpg")
    End Sub

End Class
