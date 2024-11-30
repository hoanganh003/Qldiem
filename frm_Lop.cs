using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem
{
    public partial class frm_Lop : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public frm_Lop()
        {
            InitializeComponent();
            loadccbmamon();
            loadccbhocky();
            loaddata();
        }

        private void loadccbmamon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaMonHoc FROM MonHoc WHERE TrangThai =1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    cbb_mamon.Items.Add(reader["MaMonHoc"].ToString());
                }
                reader.Close();
            }
        }
        private void loadccbhocky()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT HocKy FROM HocKy WHERE TrangThai =1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    cbb_hocky.Items.Add(reader["HocKy"].ToString());
                }
                reader.Close();
            }
        }

        private void loaddata()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM LopHoc";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_lop.DataSource = table;
            }
        }

        private void ClearTextBoxes()
        {
            txt_tenlop.Text = "";
            cbb_mamon.Text = "";
            cbb_hocky.Text = "";
            txt_namhoc.Text = "";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                    string sqlQuery = "INSERT INTO LopHoc( MaMonHoc, TenLopHoc, HocKy, NamHoc) VALUES (@mamon,@tenlop,@hocky,@namhoc)";
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@mamon", cbb_mamon.Text);
                            cmd.Parameters.AddWithValue("@tenlop", txt_tenlop.Text);
                            cmd.Parameters.AddWithValue("@hocky", cbb_hocky.Text);
                            cmd.Parameters.AddWithValue("@namhoc", txt_namhoc.Text);
                            int rowsAffected = cmd.ExecuteNonQuery();


                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm lớp thành công", "Thông báo");
                                string selectQuery = "SELECT * FROM LopHoc ";
                                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgv_lop.DataSource = dt;
                                ClearTextBoxes();
                            }
                            else
                            {
                                MessageBox.Show("Thêm lớp học không thành công !!!", "Thông báo");
                            }
                        }
            }
        }

        private void dgv_lop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_lop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lb_malop.Visible = true;
                DataGridViewRow selectedRow = dgv_lop.Rows[e.RowIndex];
                lb_malop.Text = selectedRow.Cells["MaLopHoc"].Value != DBNull.Value ? selectedRow.Cells["MaLopHoc"].Value.ToString() : "";
                txt_tenlop.Text = selectedRow.Cells["TenLopHoc"].Value != DBNull.Value ? selectedRow.Cells["TenLopHoc"].Value.ToString() : "";
                cbb_mamon.Text = selectedRow.Cells["MaMonHoc"].Value != DBNull.Value ? selectedRow.Cells["MaMonHoc"].Value.ToString() : "";
                cbb_hocky.Text = selectedRow.Cells["HocKy"].Value != DBNull.Value ? selectedRow.Cells["HocKy"].Value.ToString() : "";
                txt_namhoc.Text = selectedRow.Cells["NamHoc"].Value != DBNull.Value ? selectedRow.Cells["NamHoc"].Value.ToString() : "";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_Lop_Load(object sender, EventArgs e)
        {
            lb_malop.Visible = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "UPDATE LopHoc SET MaMonHoc = @mamon, TenLopHoc= @tenlop, HocKy = @hocky, NamHoc = @namhoc WHERE MaLopHoc = @ma";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", lb_malop.Text);
                    cmd.Parameters.AddWithValue("@mamon", cbb_mamon.Text);
                    cmd.Parameters.AddWithValue("@tenlop", txt_tenlop.Text);
                    cmd.Parameters.AddWithValue("@hocky", cbb_hocky.Text);
                    cmd.Parameters.AddWithValue("@namhoc", txt_namhoc.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM LopHoc";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_lop.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật lớp học thất bại!", "Thông báo");
                    }
                }
                // Đóng kết nối
                conn.Close();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "UPDATE LopHoc SET TrangThai = 0 WHERE MaLopHoc = @ma";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", lb_malop.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa mềm lớp học thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM LopHoc WHERE TrangThai = 1";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_lop.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mềm lớp học thất bại!", "Thông báo");
                    }
                }
                conn.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string tenLopTimKiem = txt_timkiem.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "SELECT * FROM LopHoc WHERE TenLopHoc LIKE @TenLop";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TenLop", "%" + tenLopTimKiem + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgv_lop.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lớp học!", "Thông báo");
                    }
                }
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT \r\n    sv.MaSinhVien,\r\n    sv.HoTen,\r\n    mh.TenMonHoc,\r\n    dk.DiemToiThieu,\r\n    SUM(CASE WHEN ddd.TenDauDiem != 'Điểm Thi' THEN ds.Diem * (ddd.TyLe/100) ELSE 0 END) AS DiemQuaTrinh,\r\n    SUM(CASE WHEN ddd.TenDauDiem != 'Điểm Thi' THEN ds.Diem * (ddd.TyLe/100) ELSE 0 END) \r\n        + MAX(CASE WHEN ddd.TenDauDiem = 'Điểm Thi' THEN ds.Diem * (ddd.TyLe/100) ELSE 0 END) AS DiemTongHop,\r\n    CASE \r\n        WHEN SUM(CASE WHEN ddd.TenDauDiem != 'Điểm Thi' THEN ds.Diem * (ddd.TyLe/100) ELSE 0 END) \r\n             + MAX(CASE WHEN ddd.TenDauDiem = 'Điểm Thi' THEN ds.Diem * (ddd.TyLe/100) ELSE 0 END) >= dk.DiemToiThieu \r\n        THEN 'Qua Mon'\r\n        ELSE 'Truot Mon'\r\n    END AS KetQua\r\nFROM \r\n    SinhVien sv\r\nJOIN DiemSinhVien ds ON sv.MaSinhVien = ds.MaSinhVien\r\nJOIN DiemDauDiem ddd ON ds.MaDauDiem = ddd.MaDauDiem\r\nJOIN LopHoc lh ON ds.MaLopHoc = lh.MaLopHoc\r\nJOIN MonHoc mh ON lh.MaMonHoc = mh.MaMonHoc\r\nJOIN DieuKienMonHoc dk ON mh.MaMonHoc = dk.MaMonHoc\r\nGROUP BY \r\n    sv.MaSinhVien, \r\n    sv.HoTen, \r\n    mh.TenMonHoc, \r\n    dk.DiemToiThieu\r\nORDER BY \r\n    sv.MaSinhVien";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_lop.DataSource = table;
                }
            }
            if (guna2ComboBox1.SelectedIndex == 1)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT \r\n    sv.MaSinhVien,\r\n    sv.HoTen,\r\n    sv.Email,\r\n    sv.SoDienThoai,\r\n    sv.ChuyenNganh,\r\n    sv.KhoaHoc,\r\n    sv.TrangThai,\r\n    COALESCE(SUM(svlh.SoBuoiHocDaNghi), 0) AS TongSoBuoiHocDaNghi\r\nFROM \r\n    SinhVien sv\r\nLEFT JOIN SinhVien_LopHoc svlh ON sv.MaSinhVien = svlh.MaSinhVien\r\nGROUP BY \r\n    sv.MaSinhVien, \r\n    sv.HoTen, \r\n    sv.Email, \r\n    sv.SoDienThoai, \r\n    sv.ChuyenNganh, \r\n    sv.KhoaHoc, \r\n    sv.TrangThai\r\nORDER BY \r\n    sv.MaSinhVien;";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_lop.DataSource = table;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            loaddata();
        }
    }
}
