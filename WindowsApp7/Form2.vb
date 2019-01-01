Imports MySql.Data.MySqlClient
Public Class Form2
    Dim str As String = "server=localhost; uid=root; pwd=root; database=homestead"
    Dim con As New MySqlConnection(str)
    Sub load()
        Dim query As String = "select id_komentar as id_komentar, id_pelanggan as id_pelanggan, isi_komentar as komentar from tb_komentar"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("id_komentar").Width = 150
        DataGridView1.Columns("id_pelanggan").Width = 150
        DataGridView1.Columns("komentar").Width = 750
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Select Case ListBox1.SelectedIndex
            Case 0
                Dim f1 As New Form1
                f1.Show()
                Close()
            Case 1
            Case 2
                Dim f3 As New Form3
                f3.Show()
                Close()
            Case 3
            Case 4
            Case 5
        End Select
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Dim adapter As MySqlDataAdapter
        Dim ds As New DataSet
        con.Open()
        If TextBox6.Text = "" Then
            load()
        End If
        con.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim adapter As MySqlDataAdapter
        Dim ds As New DataSet
        con.Open()
        adapter = New MySqlDataAdapter("select id_komentar as id_komentar, id_pelanggan as id_pelanggan, isi_komentar as komentar from tb_komentar where id_komentar like '%" & TextBox6.Text & "%' or id_pelanggan like '%" & TextBox6.Text & "%' or isi_komentar like '%" & TextBox6.Text & "%'", con)
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("id_komentar").Width = 150
        DataGridView1.Columns("id_pelanggan").Width = 150
        DataGridView1.Columns("komentar").Width = 750
        con.Close()
    End Sub
End Class