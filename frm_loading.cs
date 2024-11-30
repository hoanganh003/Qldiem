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
    public partial class frm_loading : Form
    {
        public frm_loading()
        {
            InitializeComponent();
        }

        private void frm_loading_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 785)
            {
                timer1.Stop();
                frm_Main f = new frm_Main();
                this.Hide();
                f.ShowDialog();
            }
        }
    }
}
