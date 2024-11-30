using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
            pnl_nav.Height = btn_trangchu.Height;
            pnl_nav.Left = btn_trangchu.Left;
            pnl_nav.Top = btn_trangchu.Top;
            btn_trangchu.BackColor = Color.FromArgb(0, 159, 201);

            lb_title.Text = "Trang Chủ";
            this.pal_control.Controls.Clear();
            frm_home f = new frm_home() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_sinhvien_Click(object sender, EventArgs e)
        {
            pnl_nav.Height = btn_sinhvien.Height;
            pnl_nav.Left = btn_sinhvien.Left;
            pnl_nav.Top = btn_sinhvien.Top;
            btn_sinhvien.BackColor = Color.FromArgb(0,159,201);

            lb_title.Text = "Quản Lý Sinh Viên";
            this.pal_control.Controls.Clear();
            frm_SinhVien f = new frm_SinhVien() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            pnl_nav.Height = btn_trangchu.Height;
            pnl_nav.Left = btn_trangchu.Left;
            pnl_nav.Top = btn_trangchu.Top;
            btn_trangchu.BackColor = Color.FromArgb(0, 159, 201);

            lb_title.Text = "Trang Chủ";
            this.pal_control.Controls.Clear();
            frm_home f = new frm_home() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }


        private void btn_monhoc_Click(object sender, EventArgs e)
        {
            pnl_nav.Height = btn_monhoc.Height;
            pnl_nav.Left = btn_monhoc.Left;
            pnl_nav.Top = btn_monhoc.Top;
            btn_monhoc.BackColor = Color.FromArgb(0, 159, 201);

            lb_title.Text = "Quản Lý Môn Học";
            this.pal_control.Controls.Clear();
            frm_MonHoc f = new frm_MonHoc() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }

        private void btn_monhoc_Leave(object sender, EventArgs e)
        {
            btn_monhoc.BackColor = Color.FromArgb(0, 189, 201);
        }

        private void btn_lop_Click(object sender, EventArgs e)
        {
            pnl_nav.Height = btn_lop.Height;
            pnl_nav.Left = btn_lop.Left;
            pnl_nav.Top = btn_lop.Top;
            btn_lop.BackColor = Color.FromArgb(0, 159, 201);

            lb_title.Text = "Quản Lý Lớp Học";
            this.pal_control.Controls.Clear();
            frm_Lop f = new frm_Lop() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }


        private void btn_dangkylop_Click(object sender, EventArgs e)
        {
            pnl_nav.Height = btn_dangkylop.Height;
            pnl_nav.Left = btn_dangkylop.Left;
            pnl_nav.Top = btn_dangkylop.Top;
            btn_dangkylop.BackColor = Color.FromArgb(0, 159, 201);

            lb_title.Text = " Đăng Ký Lớp ";
            this.pal_control.Controls.Clear();
            frm_DangKyLopChoSinhVien f = new frm_DangKyLopChoSinhVien() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }

        private void btn_diem_Click(object sender, EventArgs e)
        {
            pnl_nav.Height = btn_diem.Height;
            pnl_nav.Left = btn_diem.Left;
            pnl_nav.Top = btn_diem.Top;
            btn_diem.BackColor = Color.FromArgb(0, 159, 201);
            lb_title.Text = " Thông Tin Điểm ";
            this.pal_control.Controls.Clear();
            frm_Diem f = new frm_Diem() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }
        private void btn_lop_Leave(object sender, EventArgs e)
        {
            btn_lop.BackColor = Color.FromArgb(0, 189, 201);
        }

        private void btn_dangkylop_Leave(object sender, EventArgs e)
        {
            btn_dangkylop.BackColor = Color.FromArgb(0, 189, 201);
        }
        private void btn_trangchu_Leave(object sender, EventArgs e)
        {
            btn_trangchu.BackColor = Color.FromArgb(0, 189, 201);
        }

        private void btn_sinhvien_Leave(object sender, EventArgs e)
        {
            btn_sinhvien.BackColor = Color.FromArgb(0, 189, 201);
        }

        private void btn_diem_Leave(object sender, EventArgs e)
        {
            btn_diem.BackColor = Color.FromArgb(0, 189, 201);
        }

        private void btn_thietlap_Click(object sender, EventArgs e)
        {
            pnl_nav.Height = btn_thietlap.Height;
            pnl_nav.Left = btn_thietlap.Left;
            pnl_nav.Top = btn_thietlap.Top;
            btn_thietlap.BackColor = Color.FromArgb(0, 159, 201);

            frm_Them frm = new frm_Them();
            frm.ShowDialog();
        }

        private void btn_thietlap_Leave(object sender, EventArgs e)
        {
            btn_thietlap.BackColor = Color.FromArgb(0, 189, 201);
        }

        public void showformChuyenNganh()
        {
            lb_title.Text = "Quản Lý Chuyên Ngành";
            this.pal_control.Controls.Clear();
            frm_ChuyenNganh f = new frm_ChuyenNganh { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }
        public void showformNhomMon()
        {
            lb_title.Text = "Quản Lý Nhóm Môn Học";
            this.pal_control.Controls.Clear();
            frm_NhomMonHoc f = new frm_NhomMonHoc { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }

        public void showformHocKy()
        {
            lb_title.Text = "Quản Lý Học Kỳ";
            this.pal_control.Controls.Clear();
            frm_HocKy f = new frm_HocKy { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pal_control.Controls.Add(f);
            f.Show();
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
