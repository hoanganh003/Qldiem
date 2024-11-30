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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyDiem
{
    public partial class frm_Nhap_DauDiem : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private string masv = frm_Diem.masv;
        private string hoten = frm_Diem.hoten;
        private string malop = frm_Diem.malop;
        private string mamon = frm_Diem.mamon;

        private static string madaudiem;
        public frm_Nhap_DauDiem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Nhap_DauDiem_Load(object sender, EventArgs e)
        {
            loadlb_soluong();
            loadccbtenmon();
            lb_MaSV.Visible = true;
            lb_hoTen.Visible = true;
            lb_Malop.Visible = true;
            lb_MaSV.Text = masv;
            lb_hoTen.Text = hoten;
            lb_Malop.Text = malop;
        }

        private void loadlb_soluong()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(DiemDauDiem.MaDauDiem) AS SoDauDiem FROM MonHoc LEFT JOIN DiemDauDiem ON MonHoc.MaMonHoc = DiemDauDiem.MaMonHoc WHERE MonHoc.MaMonHoc = @mamon", conn);
                cmd.Parameters.AddWithValue("@mamon" ,mamon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lb_SoLuong.Visible = true;
                    lb_SoLuong.Text = reader["SoDauDiem"].ToString();
                }
                reader.Close();
            }
        }
        private void loadccbtenmon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TenDauDiem\r\nFROM DiemDauDiem\r\nWHERE MaMonHoc = @mamon", conn);
                cmd.Parameters.AddWithValue("@mamon", mamon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbb_daudiem.Items.Add(reader["TenDauDiem"].ToString());
                }
                reader.Close();
            }
        }

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra xem điểm đã tồn tại cho sinh viên trong lớp học với đầu điểm cụ thể chưa
                string checkQuery = "SELECT COUNT(*) FROM DiemSinhVien WHERE MaSinhVien = @masv AND MaLopHoc = @malophoc AND MaDauDiem = @madaudiem";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@masv", masv);
                    checkCmd.Parameters.AddWithValue("@malophoc", malop);
                    checkCmd.Parameters.AddWithValue("@madaudiem", madaudiem);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Điểm đã tồn tại cho sinh viên này trong lớp học với đầu điểm đã chọn!", "Thông báo");
                        return;
                    }
                }

                // Nếu chưa tồn tại, thực hiện thêm điểm
                string sqlQuery = "INSERT INTO DiemSinhVien(MaSinhVien, MaLopHoc, MaDauDiem, Diem) VALUES (@masv, @malophoc, @madaudiem, @diem)";
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
                            MessageBox.Show("Thêm điểm thành công!", "Thông báo");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm điểm thất bại!", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Giá trị điểm không hợp lệ!", "Thông báo");
                    }
                }
            }

        }

        private void cbb_daudiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaDauDiem FROM DiemDauDiem WHERE TenDauDiem = @tendaudiem", conn);
                cmd.Parameters.AddWithValue("@tendaudiem", cbb_daudiem.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    madaudiem = reader["MaDauDiem"].ToString();
                }
                reader.Close();
            }
        }
    }
}
