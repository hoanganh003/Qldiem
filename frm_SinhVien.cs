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
    public partial class frm_SinhVien : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public frm_SinhVien()
        {
            InitializeComponent();
            loaddata();
            loadcbbchuyennganh();
        }
        private void loaddata()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM SinhVien";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_SinhVien.DataSource = table;
            }
        }

        private void loadcbbchuyennganh()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ChuyenNganh FROM ChuyenNganh WHERE  TrangThai = 1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbb_chuyennganh.Items.Add(reader["ChuyenNganh"].ToString());
                }
                reader.Close();
            }
        }

        private void ClearTextBoxes()
        {
            txt_ma.Text = "";
            txt_hoten.Text = "";
            txt_email.Text = "";
            cbb_chuyennganh.Text = "";
            cbb_gioitinh.Text = "";
            txt_diachi.Text = "";
            txt_khoahoc.Text = "";
            txt_cccd.Text = "";
            txt_sdt.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string checkExistQuery = "SELECT COUNT(*) FROM SinhVien WHERE MaSinhVien = @Ma";
                using (SqlCommand checkExistCmd = new SqlCommand(checkExistQuery, conn))
                {
                    checkExistCmd.Parameters.AddWithValue("@Ma", txt_ma.Text);
                    int existingRecords = (int)checkExistCmd.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Sinh viên này đã tồn tại");
                    }
                    else
                    {
                        string sqlQuery = "INSERT INTO SinhVien (MaSinhVien,HoTen,Email,SoDienThoai,ChuyenNganh,GioiTinh,NgaySinh,DiaChi,KhoaHoc,CCCD) " +
                            "VALUES (@Ma, @Ten,@email,@SDT,@chuyennganh,@Gioitinh,@Ngaysinh,@diachi,@khoahoc,@cccd)";
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                        {
                            // Thêm các tham số vào câu lệnh SQL
                            cmd.Parameters.AddWithValue("@Ma", txt_ma.Text);
                            cmd.Parameters.AddWithValue("@Ten", txt_hoten.Text);
                            cmd.Parameters.AddWithValue("@email", txt_email.Text);
                            cmd.Parameters.AddWithValue("@SDT", txt_sdt.Text);
                            cmd.Parameters.AddWithValue("@chuyennganh", cbb_chuyennganh.Text);
                            cmd.Parameters.AddWithValue("@Gioitinh", cbb_gioitinh.Text);
                            cmd.Parameters.AddWithValue("@Ngaysinh", datp_ngaysinh.Value.ToString());
                            cmd.Parameters.AddWithValue("@diachi", txt_diachi.Text);
                            cmd.Parameters.AddWithValue("@khoahoc", txt_khoahoc.Text);
                            cmd.Parameters.AddWithValue("@cccd", txt_cccd.Text);

                    
                            int rowsAffected = cmd.ExecuteNonQuery();


                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm sinh viên thành công", "Thông báo");
                                // Sau khi thêm thành công, cập nhật lại DataGridView
                                string selectQuery = "SELECT * FROM SinhVien";
                                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgv_SinhVien.DataSource = dt;
                                ClearTextBoxes();
                            }
                            else
                            {
                                MessageBox.Show("Thêm sinh viên không thành công !!!", "Thông báo");
                            }
                        }
                    }
                }
            }
        }

        private void dgv_SinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_SinhVien.Rows[e.RowIndex];

                // Kiểm tra nếu giá trị không phải là DBNull trước khi chuyển đổi
                txt_ma.Text = selectedRow.Cells["MaSinhVien"].Value != DBNull.Value ? selectedRow.Cells["MaSinhVien"].Value.ToString() : "";
                txt_hoten.Text = selectedRow.Cells["HoTen"].Value != DBNull.Value ? selectedRow.Cells["HoTen"].Value.ToString() : "";
                txt_email.Text = selectedRow.Cells["Email"].Value != DBNull.Value ? selectedRow.Cells["Email"].Value.ToString() : "";
                txt_sdt.Text = selectedRow.Cells["SoDienThoai"].Value != DBNull.Value ? selectedRow.Cells["SoDienThoai"].Value.ToString() : "";
                cbb_chuyennganh.Text = selectedRow.Cells["ChuyenNganh"].Value != DBNull.Value ? selectedRow.Cells["ChuyenNganh"].Value.ToString() : "";
                cbb_gioitinh.Text   = selectedRow.Cells["GioiTinh"].Value != DBNull.Value ? selectedRow.Cells["GioiTinh"].Value.ToString() : "";
                datp_ngaysinh.Text   = selectedRow.Cells["NgaySinh"].Value != DBNull.Value ? selectedRow.Cells["NgaySinh"].Value.ToString() : "";
                txt_diachi.Text = selectedRow.Cells["DiaChi"].Value != DBNull.Value ? selectedRow.Cells["DiaChi"].Value.ToString() : "";
                txt_khoahoc.Text = selectedRow.Cells["KhoaHoc"].Value != DBNull.Value ? selectedRow.Cells["KhoaHoc"].Value.ToString() : "";
                txt_cccd.Text = selectedRow.Cells["CCCD"].Value != DBNull.Value ? selectedRow.Cells["CCCD"].Value.ToString() : "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "UPDATE SinhVien SET HoTen = @Ten, Email = @Email, SoDienThoai = @SDT, ChuyenNganh = @chuyennganh,GioiTinh = @gioitinh, " +
                    "NgaySinh = @ngaysinh, DiaChi = @diachi,KhoaHoc = @khoahoc,CCCD = @cccd WHERE MaSinhVien = @MaSV";

                // Tạo đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    // Thêm các tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@MaSV", txt_ma.Text);
                    cmd.Parameters.AddWithValue("@Ten", txt_hoten.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@SDT", txt_sdt.Text);
                    cmd.Parameters.AddWithValue("@chuyennganh", cbb_chuyennganh.Text);
                    cmd.Parameters.AddWithValue("@gioitinh", cbb_gioitinh.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", datp_ngaysinh.Value.ToString());
                    cmd.Parameters.AddWithValue("@diachi", txt_diachi.Text);
                    cmd.Parameters.AddWithValue("@khoahoc", txt_khoahoc.Text);
                    cmd.Parameters.AddWithValue("@cccd", txt_cccd.Text);

                    // Thực thi câu lệnh SQL
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM SinhVien";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_SinhVien.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sinh viên thất bại!", "Thông báo");
                    }
                }
                // Đóng kết nối
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "UPDATE SinhVien SET TrangThai = 0 WHERE MaSinhVien = @MaSV";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txt_ma.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa mềm sinh viên thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM SinhVien WHERE TrangThai = 1";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_SinhVien.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mềm sinh viên thất bại!", "Thông báo");
                    }
                }
                conn.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string tenKHTimKiem = txt_TenSV.Text.Trim();

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "SELECT * FROM SinhVien WHERE HoTen LIKE @TenSV";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@TenSV", "%" + tenKHTimKiem + "%");

                    // Thực thi câu lệnh SQL và lấy dữ liệu vào DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgv_SinhVien.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo");
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                if (txt_ma.Text == "" )
                {
                    MessageBox.Show("Hãy Chọn Sinh Viên !","Thông Báo");
                }    
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sv.MaSinhVien , sv.HoTen, svlh.MaLopHoc , lh.TenLopHoc , svlh.SoBuoiHocDaNghi, lh.HocKy, lh.NamHoc FROM SinhVien_LopHoc svlh JOIN SinhVien sv ON sv.MaSinhVien = svlh.MaSinhVien JOIN LopHoc lh ON svlh.MaLopHoc = lh.MaLopHoc WHERE svlh.MaSinhVien = @masv";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@masv",txt_ma.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_SinhVien.DataSource = table;
                }
            }
            if (guna2ComboBox1.SelectedIndex == 1)
            {
                if (txt_ma.Text == "")
                {
                    MessageBox.Show("Hãy Chọn Sinh Viên !", "Thông Báo");
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT SV.MaSinhVien, SV.HoTen, MH.MaMonHoc, MH.TenMonHoc, MH.SoTinChi, LH.TenLopHoc\r\nFROM SinhVien SV\r\nJOIN SinhVien_LopHoc SVLH ON SV.MaSinhVien = SVLH.MaSinhVien\r\nJOIN LopHoc LH ON SVLH.MaLopHoc = LH.MaLopHoc\r\nJOIN MonHoc MH ON LH.MaMonHoc = MH.MaMonHoc\r\nWHERE SVLH.MaSinhVien= @masv";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@masv", txt_ma.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_SinhVien.DataSource = table;
                }
            }
        }
    }
}
