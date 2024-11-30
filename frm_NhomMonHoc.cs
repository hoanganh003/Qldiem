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
    public partial class frm_NhomMonHoc : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public frm_NhomMonHoc()
        {
            InitializeComponent();
            loaddata();
        }

        private void loaddata()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM NhomMonHoc";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_Nhommon.DataSource = table;
            }
        }

        private void ClearTextBoxes()
        {
            txt_manhom.Text = "";
            txt_tennhom.Text = "";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string checkExistQuery = "SELECT COUNT(*) FROM NhomMonHoc WHERE MaNhomMon = @Ma";
                using (SqlCommand checkExistCmd = new SqlCommand(checkExistQuery, conn))
                {
                    checkExistCmd.Parameters.AddWithValue("@Ma", txt_manhom.Text);
                    int existingRecords = (int)checkExistCmd.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Nhóm môn học này đã tồn tại");
                    }
                    else
                    {
                        string sqlQuery = "INSERT INTO NhomMonHoc(MaNhomMon, TenNhomMon) VALUES (@Ma,@Ten)";
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ma", txt_manhom.Text);
                            cmd.Parameters.AddWithValue("@Ten", txt_tennhom.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm nhóm môn học thành công", "Thông báo");
                                string selectQuery = "SELECT * FROM NhomMonHoc";
                                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgv_Nhommon.DataSource = dt;
                                ClearTextBoxes();
                            }
                            else
                            {
                                MessageBox.Show("Thêm nhóm môn học không thành công !!!", "Thông báo");
                            }
                        }
                    }
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "UPDATE NhomMonHoc SET TenNhomMon = @Ten WHERE MaNhomMon = @Ma";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", txt_manhom.Text);
                    cmd.Parameters.AddWithValue("@Ten", txt_tennhom.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật nhóm môn học thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM NhomMonHoc";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_Nhommon.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật nhóm môn học thất bại!", "Thông báo");
                    }
                }
                conn.Close();
            }
        }

        private void dgv_Nhommon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_Nhommon.Rows[e.RowIndex];
                txt_manhom.Text = selectedRow.Cells["MaNhomMon"].Value != DBNull.Value ? selectedRow.Cells["MaNhomMon"].Value.ToString() : "";
                txt_tennhom.Text = selectedRow.Cells["TenNhomMon"].Value != DBNull.Value ? selectedRow.Cells["TenNhomMon"].Value.ToString() : "";
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "UPDATE NhomMonHoc SET TrangThai = 0 WHERE MaNhomMon = @ma";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", txt_manhom.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa mềm nhóm môn học thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM NhomMonHoc WHERE TrangThai = 1";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_Nhommon.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mềm nhóm môn học thất bại!", "Thông báo");
                    }
                }
                conn.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string tenCNTimKiem = txt_timkiem.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "SELECT * FROM NhomMonHoc WHERE TenNhomMon LIKE @TenCN";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TenCN", "%" + tenCNTimKiem + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgv_Nhommon.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhóm môn học!", "Thông báo");
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            loaddata();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                if (txt_manhom.Text == "")
                {
                    MessageBox.Show("Hãy Chọn Nhóm Môn Học !", "Thông Báo");
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT NhomMonHoc.MaNhomMon,NhomMonHoc.TenNhomMon, MonHoc.TenMonHoc\r\nFROM MonHoc\r\nINNER JOIN NhomMonHoc ON MonHoc.MaNhomMon = NhomMonHoc.MaNhomMon\r\nWHERE NhomMonHoc.MaNhomMon = @Ma\r\nORDER BY NhomMonHoc.MaNhomMon";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ma", txt_manhom.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_Nhommon.DataSource = table;
                }
            }
        }
    }
}
