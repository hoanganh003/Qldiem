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
    public partial class frm_MonHoc : Form
    {
        public static string mamonchon;
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public frm_MonHoc()
        {
            InitializeComponent();
            loaddata();
            loadcbbmanhommon();
        }

        private void loaddata()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Modified query to add cumulative percentage for each subject
                string query = @"
            SELECT 
                MonHoc.MaMonHoc,
                MonHoc.TenMonHoc,
                MonHoc.SoTinChi,
                MonHoc.PhanLoai,
                MonHoc.TongSoBuoiHoc,
                MonHoc.MaNhomMon,
                MonHoc.TrangThai,
                DieuKienMonHoc.DiemToiThieu,
                DieuKienMonHoc.DieuKienDiThi,
                COUNT(DiemDauDiem.MaDauDiem) AS SoDauDiem,
                ISNULL(SUM(DiemDauDiem.Tyle), 0) AS TongTyLe
            FROM 
                MonHoc
            LEFT JOIN 
                DieuKienMonHoc ON MonHoc.MaMonHoc = DieuKienMonHoc.MaMonHoc
            LEFT JOIN 
                DiemDauDiem ON MonHoc.MaMonHoc = DiemDauDiem.MaMonHoc
            GROUP BY 
                MonHoc.MaMonHoc, 
                MonHoc.TenMonHoc, 
                MonHoc.SoTinChi, 
                MonHoc.PhanLoai, 
                MonHoc.TongSoBuoiHoc,
                MonHoc.MaNhomMon,
                MonHoc.TrangThai,
                DieuKienMonHoc.DiemToiThieu, 
                DieuKienMonHoc.DieuKienDiThi
            ORDER BY 
                MonHoc.MaMonHoc";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_MonHoc.DataSource = table;

                dgv_MonHoc.Columns["MaMonHoc"].HeaderText = "Mã Môn Học";
                dgv_MonHoc.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";
                dgv_MonHoc.Columns["SoTinChi"].HeaderText = "Số Tín Chỉ";
                dgv_MonHoc.Columns["PhanLoai"].HeaderText = "Phân Loại";
                dgv_MonHoc.Columns["TongSoBuoiHoc"].HeaderText = "Tổng Số Buổi Học";
                dgv_MonHoc.Columns["MaNhomMon"].HeaderText = "Mã Nhóm Môn";
                dgv_MonHoc.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgv_MonHoc.Columns["DiemToiThieu"].HeaderText = "Điểm Tối Thiểu";
                dgv_MonHoc.Columns["DieuKienDiThi"].HeaderText = "Điều Kiện Dự Thi";
                dgv_MonHoc.Columns["SoDauDiem"].HeaderText = "Số Đầu Điểm";
                dgv_MonHoc.Columns["TongTyLe"].HeaderText = "Tổng Tỷ Lệ (%)";
            }
        }

        private void loadcbbmanhommon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaNhomMon FROM NhomMonHoc WHERE TrangThai = 1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    cbb_manhommon.Items.Add(reader["MaNhomMon"].ToString());
                }
                reader.Close();
            }
        }


        private void ClearTextBoxes()
        {
            txt_ma.Text = "";
            txt_tenmon.Text = "";
            txt_sotinchi.Text = "";
            cbb_phanloai.Text = "";
            txt_sobuoihoc.Text = "";
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string checkExistQuery = "SELECT COUNT(*) FROM MonHoc WHERE MaMonHoc = @Ma";
                using (SqlCommand checkExistCmd = new SqlCommand(checkExistQuery, conn))
                {
                    checkExistCmd.Parameters.AddWithValue("@Ma", txt_ma.Text);
                    int existingRecords = (int)checkExistCmd.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Môn học này đã tồn tại");
                    }
                    else
                    {
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                string sqlQuery = "INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi, PhanLoai, TongSoBuoiHoc,MaNhomMon) " +
                                                  "VALUES (@Ma, @Ten, @sotin, @phanloai, @tongsobuoi,@manhommon)";

                                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Ma", txt_ma.Text);
                                    cmd.Parameters.AddWithValue("@Ten", txt_tenmon.Text);
                                    cmd.Parameters.AddWithValue("@sotin", txt_sotinchi.Text);
                                    cmd.Parameters.AddWithValue("@phanloai", cbb_phanloai.Text);
                                    cmd.Parameters.AddWithValue("@tongsobuoi", txt_sobuoihoc.Text);
                                    cmd.Parameters.AddWithValue("@manhommon", cbb_manhommon.Text);

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        string sqlQuery2 = "INSERT INTO DieuKienMonHoc (MaMonHoc) VALUES (@Ma)";
                                        using (SqlCommand cmd_2 = new SqlCommand(sqlQuery2, conn, transaction))
                                        {
                                            cmd_2.Parameters.AddWithValue("@Ma", txt_ma.Text);
                                            cmd_2.ExecuteNonQuery();
                                        }

                                        // Xác nhận transaction
                                        transaction.Commit();
                                        MessageBox.Show("Thêm môn học thành công", "Thông báo");

                                        // Cập nhật lại DataGridView
                                        loaddata();
                                        ClearTextBoxes();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Thêm môn học không thành công !!!", "Thông báo");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Nếu có lỗi, hoàn tác tất cả các thay đổi
                                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                            }
                        }
                    }
                }
            }

        }

        private void dgv_MonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_MonHoc.Rows[e.RowIndex];

                // Kiểm tra nếu giá trị không phải là DBNull trước khi chuyển đổi
                txt_ma.Text = selectedRow.Cells["MaMonHoc"].Value != DBNull.Value ? selectedRow.Cells["MaMonHoc"].Value.ToString() : "";
                txt_tenmon.Text = selectedRow.Cells["TenMonHoc"].Value != DBNull.Value ? selectedRow.Cells["TenMonHoc"].Value.ToString() : "";
                txt_sotinchi.Text = selectedRow.Cells["SoTinChi"].Value != DBNull.Value ? selectedRow.Cells["SoTinChi"].Value.ToString() : "";
                cbb_phanloai.Text = selectedRow.Cells["PhanLoai"].Value != DBNull.Value ? selectedRow.Cells["PhanLoai"].Value.ToString() : "";
                txt_sobuoihoc.Text = selectedRow.Cells["TongSoBuoiHoc"].Value != DBNull.Value ? selectedRow.Cells["TongSoBuoiHoc"].Value.ToString() : "";
                cbb_manhommon.Text = selectedRow.Cells["MaNhomMon"].Value != DBNull.Value ? selectedRow.Cells["MaNhomMon"].Value.ToString() : "";

                mamonchon = selectedRow.Cells["MaMonHoc"].Value.ToString();

            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "UPDATE MonHoc SET TenMonHoc = @Ten, SoTinChi = @sotin, PhanLoai = @phanloai, TongSoBuoiHoc= @tongsobuoi , MaNhomMon= @manhommon WHERE MaMonHoc =@Ma";

                // Tạo đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    // Thêm các tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@Ma", txt_ma.Text);
                    cmd.Parameters.AddWithValue("@Ten", txt_tenmon.Text);
                    cmd.Parameters.AddWithValue("@sotin", txt_sotinchi.Text);
                    cmd.Parameters.AddWithValue("@phanloai", cbb_phanloai.Text);
                    cmd.Parameters.AddWithValue("@tongsobuoi", txt_sobuoihoc.Text);
                    cmd.Parameters.AddWithValue("@manhommon", cbb_manhommon.Text);

                    // Thực thi câu lệnh SQL
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật môn học thành công!", "Thông báo");
                        loaddata();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật môn học thất bại!", "Thông báo");
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

                string sqlQuery = "UPDATE MonHoc SET TrangThai = 0 WHERE MaMonHoc = @MaMH";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaMH", txt_ma.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa mềm môn học thành công!", "Thông báo");
                        loaddata();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mềm môn học thất bại!", "Thông báo");
                    }
                }
                conn.Close();
            }
        }

        private void pic_timkiem_Click(object sender, EventArgs e)
        {
            string tenMHTimKiem = txt_timkiem.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "SELECT \r\n    MonHoc.MaMonHoc,\r\n    MonHoc.TenMonHoc,\r\n    MonHoc.SoTinChi,\r\n    MonHoc.PhanLoai,\r\n    MonHoc.TongSoBuoiHoc,\r\n MonHoc.MaNhomMon,   MonHoc.TrangThai, \r\n    DieuKienMonHoc.DiemToiThieu,\r\n    DieuKienMonHoc.DieuKienDiThi,\r\n    COUNT(DiemDauDiem.MaDauDiem) AS SoDauDiem\r\nFROM \r\n    MonHoc\r\nLEFT JOIN \r\n    DieuKienMonHoc ON MonHoc.MaMonHoc = DieuKienMonHoc.MaMonHoc\r\nLEFT JOIN \r\n    DiemDauDiem ON MonHoc.MaMonHoc = DiemDauDiem.MaMonHoc\r\nWHERE \r\n\tWHERE MonHoc.TenMonHoc LIKE @TenTK \r\nGROUP BY \r\n    MonHoc.MaMonHoc, \r\n    MonHoc.TenMonHoc, \r\n    MonHoc.SoTinChi, \r\n    MonHoc.PhanLoai, \r\n    MonHoc.TongSoBuoiHoc,MonHoc.MaNhomMon, \r\n    MonHoc.TrangThai,\r\n    DieuKienMonHoc.DiemToiThieu, \r\n    DieuKienMonHoc.DieuKienDiThi\r\nORDER BY \r\n    MonHoc.MaMonHoc;";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TenTK", "%" + tenMHTimKiem + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgv_MonHoc.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy môn học!", "Thông báo");
                    }
                }
            }
        }

        private void btn_dieukien_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mamonchon))
            {
                frm_DieuKien_Diem f = new frm_DieuKien_Diem();
                f.ShowDialog();
                loaddata();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học trước khi nhập điểm quá trình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_daudiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mamonchon))
            {
                frm_DauDiem f = new frm_DauDiem();
                f.ShowDialog();
                loaddata();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học trước khi nhập đầu điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            loaddata();
            ClearTextBoxes();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_ma.Text == "")
            {
                MessageBox.Show("Hãy Chọn Môn Học !", "Thông Báo");
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT LopHoc.MaLopHoc, LopHoc.TenLopHoc, LopHoc.HocKy, LopHoc.NamHoc, LopHoc.TrangThai\r\nFROM LopHoc\r\nJOIN MonHoc ON LopHoc.MaMonHoc = MonHoc.MaMonHoc\r\nWHERE LopHoc.MaMonHoc = @Ma";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ma", txt_ma.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_MonHoc.DataSource = table;
            }
        }
    }
}
