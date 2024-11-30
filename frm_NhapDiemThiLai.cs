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
    public partial class frm_NhapDiemThiLai : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private string masv = frm_Diem.masv;
        private string hoten = frm_Diem.hoten;
        private string malop = frm_Diem.malop;
        private string mamon = frm_Diem.mamon;

        private static string madaudiem;

        public frm_NhapDiemThiLai()
        {
            InitializeComponent();
        }

        private void frm_NhapDiemThiLai_Load(object sender, EventArgs e)
        {
            lb_MaSV.Visible = true;
            lb_hoTen.Visible = true;
            lb_Malop.Visible = true;
            lb_MaSV.Text = masv;
            lb_hoTen.Text = hoten;
            lb_Malop.Text = malop;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaDauDiem FROM DiemDauDiem WHERE TenDauDiem = @tendaudiem", conn);
                cmd.Parameters.AddWithValue("@tendaudiem", txt_daudiem.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    madaudiem = reader["MaDauDiem"].ToString();
                }
                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "UPDATE DiemSinhVien SET Diem = @diem ,LanThi = LanThi + 1 WHERE MaSinhVien = @masv AND MaLopHoc = @malophoc AND MaDauDiem = @madaudiem";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    if (float.TryParse(txt_giatri.Text, out float diem))
                    {
                        cmd.Parameters.AddWithValue("@diem", diem);
                        cmd.Parameters.AddWithValue("@masv", masv);
                        cmd.Parameters.AddWithValue("@malophoc", malop);
                        cmd.Parameters.AddWithValue("@madaudiem", madaudiem);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật điểm thành công!", "Thông báo");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật điểm thất bại!", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Giá trị điểm không hợp lệ!", "Thông báo");
                    }
                }
            }
        }
    }
}
