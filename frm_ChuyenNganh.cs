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
    public partial class frm_ChuyenNganh : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public frm_ChuyenNganh()
        {
            InitializeComponent();
            loaddata();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loaddata()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ChuyenNganh";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_chuyennganh.DataSource = table;
            }
        }

        private void ClearTextBoxes()
        {
            txt_tencn.Text = "";
            txt_macn.Text = "";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string checkExistQuery = "SELECT COUNT(*) FROM ChuyenNganh WHERE MaChuyenNganh = @Ma";
                using (SqlCommand checkExistCmd = new SqlCommand(checkExistQuery, conn))
                {
                    checkExistCmd.Parameters.AddWithValue("@Ma", txt_macn.Text);
                    int existingRecords = (int)checkExistCmd.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Chuyên ngành này đã tồn tại");
                    }
                    else
                    {
                        string sqlQuery = "INSERT INTO ChuyenNganh(MaChuyenNganh, ChuyenNganh) VALUES (@Ma,@Ten)";
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ma", txt_macn.Text);
                            cmd.Parameters.AddWithValue("@Ten", txt_tencn.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm chuyên ngành thành công", "Thông báo");
                                string selectQuery = "SELECT * FROM ChuyenNganh";
                                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgv_chuyennganh.DataSource = dt;
                                ClearTextBoxes();
                            }
                            else
                            {
                                MessageBox.Show("Thêm chuyên ngành không thành công !!!", "Thông báo");
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

                string sqlQuery = "UPDATE ChuyenNganh SET ChuyenNganh = @Ten WHERE MaChuyenNganh = @Ma";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", txt_macn.Text);
                    cmd.Parameters.AddWithValue("@Ten", txt_tencn.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật chuyên ngành thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM ChuyenNganh";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_chuyennganh.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chuyên ngành thất bại!", "Thông báo");
                    }
                }
                conn.Close();
            }
        }

        private void dgv_chuyennganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_chuyennganh.Rows[e.RowIndex];
                txt_macn.Text = selectedRow.Cells["MaChuyenNganh"].Value != DBNull.Value ? selectedRow.Cells["MaChuyenNganh"].Value.ToString() : "";
                txt_tencn.Text = selectedRow.Cells["ChuyenNganh"].Value != DBNull.Value ? selectedRow.Cells["ChuyenNganh"].Value.ToString() : "";
            }
        }

        private void btn_sua_Leave(object sender, EventArgs e)
        {
        }

        private void btn_xoamem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "UPDATE ChuyenNganh SET TrangThai = 0 WHERE MaChuyenNganh = @ma";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", txt_macn.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa mềm chuyên ngành thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM ChuyenNganh WHERE TrangThai = 1";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_chuyennganh.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mềm chuyên ngành thất bại!", "Thông báo");
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
                string sqlQuery = "SELECT * FROM ChuyenNganh WHERE ChuyenNganh LIKE @TenCN";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TenCN", "%" + tenCNTimKiem + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgv_chuyennganh.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy chuyên ngành!", "Thông báo");
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            loaddata();
            ClearTextBoxes() ;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                if (txt_macn.Text == "")
                {
                    MessageBox.Show("Hãy Chọn Chuyên Ngành !", "Thông Báo");
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT SV.MaSinhVien, SV.HoTen, SV.Email, SV.SoDienThoai, SV.ChuyenNganh\r\nFROM SinhVien SV\r\nJOIN ChuyenNganh CN ON SV.ChuyenNganh = CN.ChuyenNganh\r\nWHERE CN.MaChuyenNganh = @Ma";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ma", txt_macn.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_chuyennganh.DataSource = table;
                }
            }
            if( guna2ComboBox1.SelectedIndex == 1)
            {
                if (txt_macn.Text == "")
                {
                    MessageBox.Show("Hãy Chọn Chuyên Ngành !", "Thông Báo");
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CN.ChuyenNganh, COUNT(SV.MaSinhVien) AS SoLuongSinhVien\r\nFROM ChuyenNganh CN\r\nLEFT JOIN SinhVien SV ON CN.ChuyenNganh = SV.ChuyenNganh WHERE CN.MaChuyenNganh = @Ma\r\nGROUP BY CN.ChuyenNganh;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ma", txt_macn.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_chuyennganh.DataSource = table;
                }
            }    
        }
    }
}
