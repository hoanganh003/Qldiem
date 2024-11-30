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
    public partial class frm_Them : Form
    {
        public frm_Them()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_chuyennganh_Click(object sender, EventArgs e)
        {
            frm_Main f = (frm_Main)Application.OpenForms["frm_Main"];
            f.showformChuyenNganh();
            this.Close();
        }

        private void btn_nhommon_Click(object sender, EventArgs e)
        {
            frm_Main f = (frm_Main)Application.OpenForms["frm_Main"];
            f.showformNhomMon();
            this.Close();
        }

        private void btn_hocky_Click(object sender, EventArgs e)
        {
            frm_Main f = (frm_Main)Application.OpenForms["frm_Main"];
            f.showformHocKy();
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["frm_Main"].Close();
            Application.OpenForms["frm_loading"].Close();
        }
    }
}
