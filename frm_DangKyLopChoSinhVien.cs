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
    public partial class frm_DangKyLopChoSinhVien : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public frm_DangKyLopChoSinhVien()
        {
            InitializeComponent();
            loadcbbsinhvien();
            loadcbbmalop();
            loaddata();
        }

        private void loadcbbsinhvien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaSinhVien FROM SinhVien WHERE TrangThai = 1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    cbb_masv.Items.Add(reader["MaSinhVien"].ToString());
                }
                reader.Close();
            }
        }

        private void loadcbbmalop()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaLopHoc FROM LopHoc WHERE TrangThai =1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    cbb_malop.Items.Add(reader["MaLopHoc"].ToString());
                }
                reader.Close();
            }
        }

        private void loaddata()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT \r\n    SVLH.MaSinhVien,\r\n    SV.HoTen,\r\n    SV.Email,\r\n    LH.MaLopHoc,\r\n    LH.TenLopHoc,\r\n    SVLH.SoBuoiHocDaNghi,\r\n    SVLH.TrangThai AS TrangThaiSinhVienLopHoc\r\nFROM \r\n    SinhVien_LopHoc SVLH\r\nJOIN \r\n    SinhVien SV ON SVLH.MaSinhVien = SV.MaSinhVien\r\nJOIN \r\n    LopHoc LH ON SVLH.MaLopHoc = LH.MaLopHoc;\r\n";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_Dangky.DataSource = table;
            }
        }

        private void cbb_masv_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT HoTen FROM SinhVien WHERE TrangThai =1 AND MaSinhVien = '"+cbb_masv.Text+"'", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    txt_tensv.Text =  reader["HoTen"].ToString();
                }
                reader.Close();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Kiểm tra xem sinh viên đã tồn tại trong lớp học chưa
                string checkQuery = "SELECT COUNT(*) FROM SinhVien_LopHoc WHERE MaSinhVien = @masv AND MaLopHoc = @malh";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@masv", cbb_masv.Text);
                    checkCmd.Parameters.AddWithValue("@malh", cbb_malop.Text);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Sinh viên đã được thêm vào lớp này trước đó!", "Thông báo");
                        return;
                    }
                }

                // Nếu chưa tồn tại, thực hiện thêm sinh viên vào lớp
                string sqlQuery = "INSERT INTO SinhVien_LopHoc(MaSinhVien,MaLopHoc) VALUES (@masv,@malh)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@masv", cbb_masv.Text);
                    cmd.Parameters.AddWithValue("@malh", cbb_malop.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm sinh viên vào lớp thành công", "Thông báo");
                        string selectQuery = @"SELECT 
                                       SVLH.MaSinhVien,
                                       SV.HoTen,
                                       SV.Email,
                                       LH.MaLopHoc,
                                       LH.TenLopHoc,
                                       SVLH.SoBuoiHocDaNghi,
                                       SVLH.TrangThai AS TrangThaiSinhVienLopHoc
                                   FROM 
                                       SinhVien_LopHoc SVLH
                                   JOIN 
                                       SinhVien SV ON SVLH.MaSinhVien = SV.MaSinhVien
                                   JOIN 
                                       LopHoc LH ON SVLH.MaLopHoc = LH.MaLopHoc;";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_Dangky.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Thêm sinh viên vào lớp không thành công !!!", "Thông báo");
                    }
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string tenmasvTimKiem = txt_timkiem.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "SELECT \r\n    SVLH.MaSinhVien,\r\n    SV.HoTen,\r\n    SV.Email,\r\n    LH.MaLopHoc,\r\n    LH.TenLopHoc,\r\n    SVLH.SoBuoiHocDaNghi,\r\n    SVLH.TrangThai AS TrangThaiSinhVienLopHoc\r\nFROM \r\n    SinhVien_LopHoc SVLH\r\nJOIN \r\n    SinhVien SV ON SVLH.MaSinhVien = SV.MaSinhVien\r\nJOIN \r\n    LopHoc LH ON SVLH.MaLopHoc = LH.MaLopHoc WHERE SVLH.MaSinhVien LIKE @masv";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@masv", "%" + tenmasvTimKiem + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgv_Dangky.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên trong lớp học !", "Thông báo");
                    }
                }
            }
        }



        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "UPDATE SinhVien_LopHoc SET SoBuoiHocDaNghi = @sobuoihoc WHERE MaSinhVien = @masv AND MaLopHoc = @malop";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@masv", txt_masv_tam.Text);
                    cmd.Parameters.AddWithValue("@malop", txt_malop_tam.Text);
                    cmd.Parameters.AddWithValue("@sobuoihoc", txt_sobuoihoc.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật số buổi nghỉ thành công!", "Thông báo");
                        string selectQuery = "SELECT \r\n    SVLH.MaSinhVien,\r\n    SV.HoTen,\r\n    SV.Email,\r\n    LH.MaLopHoc,\r\n    LH.TenLopHoc,\r\n    SVLH.SoBuoiHocDaNghi,\r\n    SVLH.TrangThai AS TrangThaiSinhVienLopHoc\r\nFROM \r\n    SinhVien_LopHoc SVLH\r\nJOIN \r\n    SinhVien SV ON SVLH.MaSinhVien = SV.MaSinhVien\r\nJOIN \r\n    LopHoc LH ON SVLH.MaLopHoc = LH.MaLopHoc";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_Dangky.DataSource = dt;
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

        private void dgv_Dangky_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_Dangky.Rows[e.RowIndex];
                txt_masv_tam.Text = selectedRow.Cells["MaSinhVien"].Value != DBNull.Value ? selectedRow.Cells["MaSinhVien"].Value.ToString() : "";
                txt_malop_tam.Text = selectedRow.Cells["MaLopHoc"].Value != DBNull.Value ? selectedRow.Cells["MaLopHoc"].Value.ToString() : "";
                txt_sobuoihoc.Text = selectedRow.Cells["SoBuoiHocDaNghi"].Value != DBNull.Value ? selectedRow.Cells["SoBuoiHocDaNghi"].Value.ToString() : "";
            }
        }

        private void btn_xoamem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "UPDATE SinhVien_LopHoc SET TrangThai = 0 WHERE MaLopHoc = @malop AND MaSinhVien = @masv";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@masv", txt_masv_tam.Text);
                    cmd.Parameters.AddWithValue("@malop", txt_malop_tam.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa mềm sinh viên trong lớp thành công!", "Thông báo");
                        string selectQuery = "SELECT \r\n    SVLH.MaSinhVien,\r\n    SV.HoTen,\r\n    SV.Email,\r\n    LH.MaLopHoc,\r\n    LH.TenLopHoc,\r\n    SVLH.SoBuoiHocDaNghi,\r\n    SVLH.TrangThai AS TrangThaiSinhVienLopHoc\r\nFROM \r\n    SinhVien_LopHoc SVLH\r\nJOIN \r\n    SinhVien SV ON SVLH.MaSinhVien = SV.MaSinhVien\r\nJOIN \r\n    LopHoc LH ON SVLH.MaLopHoc = LH.MaLopHoc WHERE SVLH.TrangThai = 1";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_Dangky.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Xóa mềm sinh viên trong lớp thất bại!", "Thông báo");
                    }
                }
                conn.Close();
            }
        }
    }
}
