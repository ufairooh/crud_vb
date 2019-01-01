Imports MySql.Data.MySqlClient
Public Class Form3
    Dim str As String = "server=localhost; uid=root; pwd=root; database=homestead; Convert Zero Datetime=True"
    Dim con As New MySqlConnection(str)
    Sub load()
        Dim query As String = "select suuid_order as id_order, id_pelanggan as id_pelanggan, total_price as total, lunas as lunas from tb_order"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("id_order").Width = 150
        DataGridView1.Columns("id_pelanggan").Width = 150
        DataGridView1.Columns("total").Width = 300
        DataGridView1.Columns("lunas").Width = 150
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Select Case ListBox1.SelectedIndex
            Case 0
                Dim f1 As New Form1
                f1.Show()
                Close()
            Case 1
                Dim f2 As New Form2
                f2.Show()
                Close()
            Case 2
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
        adapter = New MySqlDataAdapter("select suuid_order as id_order, id_pelanggan as id_pelanggan, total_price as total, lunas as lunas from tb_order where suuid_order like '%" & TextBox6.Text & "%' or id_pelanggan like '%" & TextBox6.Text & "%' or total_price like '%" & TextBox6.Text & "%'", con)
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("id_order").Width = 150
        DataGridView1.Columns("id_pelanggan").Width = 150
        DataGridView1.Columns("total").Width = 300
        DataGridView1.Columns("lunas").Width = 150
        con.Close()
    End Sub
End Class