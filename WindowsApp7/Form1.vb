Imports MySql.Data.MySqlClient

Public Class Form1
    Dim str As String = "server=localhost; uid=root; pwd=root; database=homestead"
    Dim con As New MySqlConnection(str)

    Sub load()
        TextBox1.Text = ""
        RichTextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Dim query As String = "select id_hidangan as id, nama_hidangan as Nama, deskripsi_hidangan as deskripsi ,harga_hidangan as harga, kategori_hidangan as kategori, foto_hidangan as foto from tb_hidangan"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("id").Width = 100
        DataGridView1.Columns("nama").Width = 250
        DataGridView1.Columns("deskripsi").Width = 250
        DataGridView1.Columns("harga").Width = 100
        DataGridView1.Columns("kategori").Width = 200
        DataGridView1.Columns("foto").Width = 200
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or RichTextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Please Fill All Field To Insert", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim Command As MySqlCommand
            Try
                con.Open()
                Command = con.CreateCommand
                Command.CommandText = "insert into tb_hidangan (nama_hidangan, deskripsi_hidangan, harga_hidangan, kategori_hidangan, foto_hidangan) values ('" & TextBox1.Text & "','" & RichTextBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox3.Text & "')"
                Command.ExecuteNonQuery()
                load()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or RichTextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Please Fill All Field To Insert", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim Command As MySqlCommand
            Try
                con.Open()
                Command = con.CreateCommand
                Command.CommandText = "update tb_hidangan set nama_hidangan='" & TextBox1.Text & "',deskripsi_hidangan='" & RichTextBox1.Text & "',harga_hidangan='" & TextBox2.Text & "',foto_hidangan='" & TextBox3.Text & "',kategori_hidangan='" & TextBox4.Text & "' where id_hidangan='" & TextBox5.Text & "'"
                Command.ExecuteNonQuery()
                load()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)

            TextBox1.Text = row.Cells("Nama").Value.ToString
            RichTextBox1.Text = row.Cells("deskripsi").Value.ToString
            TextBox2.Text = row.Cells("harga").Value.ToString
            TextBox3.Text = row.Cells("foto").Value.ToString
            TextBox4.Text = row.Cells("kategori").Value.ToString
            TextBox5.Text = row.Cells("id").Value.ToString
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or RichTextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Please Fill All Field To Insert", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim Command As MySqlCommand
            Try
                con.Open()
                Command = con.CreateCommand
                Command.CommandText = "delete from tb_hidangan where id_hidangan='" & TextBox5.Text & "'"
                Command.ExecuteNonQuery()
                load()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TextBox3.Text = OpenFileDialog1.SafeFileName
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Select Case ListBox1.SelectedIndex
            Case 0
            Case 1
                Dim f2 As New Form2
                f2.Show()
                Close()
            Case 2
                Dim f3 As New Form3
                f3.Show()
                Close()
            Case 3
            Case 4
            Case 5
        End Select
    End Sub
End Class
