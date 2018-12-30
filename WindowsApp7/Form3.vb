Imports MySql.Data.MySqlClient
Public Class Form3
    Dim str As String = "server=localhost; uid=root; pwd=root; database=homestead; Convert Zero Datetime=True"
    Dim con As New MySqlConnection(str)
    Sub load()
        Dim query As String = "select suuid_order as id_order, id_pelanggan as id_pelanggan, total_price as total ,created_at as created_at, updated_at as updated_at, lunas as lunas from tb_order"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("id_order").Width = 150
        DataGridView1.Columns("id_pelanggan").Width = 150
        DataGridView1.Columns("total").Width = 300
        DataGridView1.Columns("created_at").Width = 150
        DataGridView1.Columns("updated_at").Width = 150
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
End Class