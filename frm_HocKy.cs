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
    public partial class frm_HocKy : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public frm_HocKy()
        {
            InitializeComponent();
            loaddata();
        }
        private void loaddata()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM HocKy";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgv_hocKy.DataSource = table;
            }
        }
        private void ClearTextBoxes()
        {
            txt_mahk.Text = "";
            txt_tenhk.Text = "";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string checkExistQuery = "SELECT COUNT(*) FROM HocKy WHERE MaHocKy = @Ma";
                using (SqlCommand checkExistCmd = new SqlCommand(checkExistQuery, conn))
                {
                    checkExistCmd.Parameters.AddWithValue("@Ma", txt_mahk.Text);
                    int existingRecords = (int)checkExistCmd.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Học kỳ này đã tồn tại");
                    }
                    else
                    {
                        string sqlQuery = "INSERT INTO HocKy(MaHocKy, HocKy) VALUES (@Ma,@Ten)";
                        using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ma", txt_mahk.Text);
                            cmd.Parameters.AddWithValue("@Ten", txt_tenhk.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm học kỳ thành công", "Thông báo");
                                string selectQuery = "SELECT * FROM HocKy";
                                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgv_hocKy.DataSource = dt;
                                ClearTextBoxes();
                            }
                            else
                            {
                                MessageBox.Show("Thêm học kỳ không thành công !!!", "Thông báo");
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

                string sqlQuery = "UPDATE HocKy SET HocKy = @Ten WHERE MaHocKy = @Ma";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", txt_mahk.Text);
                    cmd.Parameters.AddWithValue("@Ten", txt_tenhk.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật học kỳ thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM HocKy";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_hocKy.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật học kỳ thất bại!", "Thông báo");
                    }
                }
                conn.Close();
            }
        }

        private void dgv_hocKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_hocKy.Rows[e.RowIndex];
                txt_mahk.Text = selectedRow.Cells["MaHocKy"].Value != DBNull.Value ? selectedRow.Cells["MaHocKy"].Value.ToString() : "";
                txt_tenhk.Text = selectedRow.Cells["HocKy"].Value != DBNull.Value ? selectedRow.Cells["HocKy"].Value.ToString() : "";
            }
        }

        private void btn_xoamem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "UPDATE HocKy SET TrangThai = 0 WHERE MaHocKy = @ma";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", txt_mahk.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa mềm học kỳ thành công!", "Thông báo");
                        string selectQuery = "SELECT * FROM HocKy WHERE TrangThai = 1";
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv_hocKy.DataSource = dt;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mềm học kỳ thất bại!", "Thông báo");
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
                string sqlQuery = "SELECT * FROM HocKy WHERE HocKy LIKE @TenCN";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TenCN", "%" + tenCNTimKiem + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgv_hocKy.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy học kỳ !", "Thông báo");
                    }
                }
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                if (txt_mahk.Text == "")
                {
                    MessageBox.Show("Hãy Chọn Học Kỳ !", "Thông Báo");
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT hk.MaHocKy , hk.HocKy, lh.MaLopHoc , lh.TenLopHoc, lh.NamHoc, lh.TrangThai FROM HocKy hk JOIN LopHoc lh ON hk.HocKy = lh.Hocky WHERE hk.MaHocKy = @Ma";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ma", txt_mahk.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv_hocKy.DataSource = table;
                }
            }
        }
    }
}
