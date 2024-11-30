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
    public partial class frm_DauDiem : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        private string mamonchon = frm_MonHoc.mamonchon;
        public frm_DauDiem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_DauDiem_Load(object sender, EventArgs e)
        {
            lb_MaMon.Text = mamonchon;
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string checkQuery = "SELECT ISNULL(SUM(Tyle), 0) FROM DiemDauDiem WHERE MaMonHoc = @mamon";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@mamon", mamonchon);
                    decimal currentTotalPercentage = Convert.ToDecimal(checkCmd.ExecuteScalar());
                    decimal newPercentage = Convert.ToDecimal(txt_tyle.Text);
                    if (currentTotalPercentage + newPercentage > 100)
                    {
                        MessageBox.Show("Tổng tỷ lệ đầu điểm của môn học không được vượt quá 100%.Vui Lòng nhập lại", "Thông báo");
                        return;
                    }
                }

                string sqlQuery = "INSERT INTO DiemDauDiem(MaMonHoc, TenDauDiem, Tyle) VALUES (@mamon,@ten,@tyle)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@mamon", mamonchon);
                    cmd.Parameters.AddWithValue("@ten", cbb_ten.Text);
                    cmd.Parameters.AddWithValue("@tyle", txt_tyle.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật đầu điểm thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đầu điểm thất bại!", "Thông báo");
                    }
                }
                conn.Close();
                this.Close();
            }
        }

    }
}
