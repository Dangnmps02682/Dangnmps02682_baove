Imports System.Data.SqlClient

Public Class frmQuanLySach
    Dim chuoiketnoi As String = "Workstation id=testinf205.mssql.somee.com;packet size=4096;user id=TestINF205;pwd=Abcd@123;data source=testinf205.mssql.somee.com;persist security info=False;initial catalog=testinf205"
    Dim database As New DataTable

    Private Sub frmQuanLySach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ketnoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim lenh1 As SqlDataAdapter = New SqlDataAdapter("select * from Sach", ketnoi)

        ketnoi.Open()
        lenh1.Fill(database)
        dgvQuanLySach.DataSource = database.DefaultView
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim ketnoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim lenh2 As String = "insert into Sach values (@MaSach,@TenSach,@NgayXuatBan,@DonGia,@MaLoai)"
        Dim thucthi As New SqlCommand(lenh2, ketnoi)
        ketnoi.Open()
        Try
            thucthi.Parameters.AddWithValue("@MaSach", txtMaSach.Text)
            thucthi.Parameters.AddWithValue("@TenSach", txtTenSach.Text)
            thucthi.Parameters.AddWithValue("@NgayXuatBan", dtpNgayXuatBan.Value)
            thucthi.Parameters.AddWithValue("@DonGia", txtDonGia.Text)
            thucthi.Parameters.AddWithValue("@MaLoai", txtMaLoai.Text)
            MessageBox.Show("Thêm sách thành công")
            ketnoi.Close()
        Catch ex As Exception
            MessageBox.Show("Không thể thêm sách")
            ketnoi.Close()
        End Try

        Dim lammoi As SqlDataAdapter = New SqlDataAdapter("select * from Sach", ketnoi)

        database.Clear()
        lammoi.Fill(database)
        dgvQuanLySach.DataSource = database.DefaultView

    End Sub


    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Dim ketnoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim lenh3 As String = "Update Sach set MaSach = @MaSach,TenSach = @TenSach,NgayXuatBan = @NgayXuatBan,DonGia = @DonGia,LoaiSach_MaLoai = @MaLoai"
        Dim thucthi As New SqlCommand(lenh3, ketnoi)
        ketnoi.Open()
        Try
            thucthi.Parameters.AddWithValue("@MaSach", txtMaSach.Text)
            thucthi.Parameters.AddWithValue("@TenSach", txtTenSach.Text)
            thucthi.Parameters.AddWithValue("@NgayXuatBan", dtpNgayXuatBan.Value)
            thucthi.Parameters.AddWithValue("@DonGia", txtDonGia.Text)
            thucthi.Parameters.AddWithValue("@MaLoai", txtMaLoai.Text)
            MessageBox.Show("Sửa sách thành công")
            ketnoi.Close()
        Catch ex As Exception
            MessageBox.Show("Không thể sửa sách")
            ketnoi.Close()
        End Try

        Dim lammoi As SqlDataAdapter = New SqlDataAdapter("select * from Sach", ketnoi)

        database.Clear()
        dgvQuanLySach.DataSource = database
        dgvQuanLySach.DataSource = Nothing
        loaddata()
    End Sub

    Private Sub dgvQuanLySach_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuanLySach.CellContentClick
        Dim index As Integer = dgvQuanLySach.CurrentCell.RowIndex
        txtMaSach.Text = dgvQuanLySach.Item(0, index).Value
        txtTenSach.Text = dgvQuanLySach.Item(1, index).Value
        dtpNgayXuatBan.Value = dgvQuanLySach.Item(2, index).Value
        txtDonGia.Text = dgvQuanLySach.Item(3, index).Value
        txtMaLoai.Text = dgvQuanLySach.Item(4, index).Value
    End Sub

    Private Sub loaddata()
        Dim ketnoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim lenh4 As SqlDataAdapter = New SqlDataAdapter("select * from Sach", ketnoi)

        ketnoi.Open()
        lenh4.Fill(database)
        dgvQuanLySach.DataSource = database.DefaultView

    End Sub

End Class
