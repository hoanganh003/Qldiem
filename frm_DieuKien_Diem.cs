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
    public partial class frm_DieuKien_Diem : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        private string mamonchon = frm_MonHoc.mamonchon;
        public frm_DieuKien_Diem()
        {
            InitializeComponent();
        }

        private void frm_DieuKien_Diem_Load(object sender, EventArgs e)
        {
            lb_MaMon.Text = mamonchon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "UPDATE DieuKienMonHoc SET DiemToiThieu = @diemtoithieu, DieuKienDiThi = @dieukienthi WHERE MaMonHoc =@Ma";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", mamonchon);
                    cmd.Parameters.AddWithValue("@diemtoithieu", txt_diemtoithieu.Text);
                    cmd.Parameters.AddWithValue("@dieukienthi", txt_diemduthi.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật điểm điều kiện thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật điểm điều kiện thất bại!", "Thông báo");
                    }
                }
                conn.Close();
                this.Close();
            }

        }
    }
}
