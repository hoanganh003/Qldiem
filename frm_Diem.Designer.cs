namespace QuanLyDiem
{
    partial class frm_Diem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Diem = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_malop = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbb_mamonhoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_nhap = new Guna.UI2.WinForms.Guna2Button();
            this.lb_tenlop = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_diemthilai = new Guna.UI2.WinForms.Guna2Button();
            this.btn_nhap_daudiem = new Guna.UI2.WinForms.Guna2Button();
            this.btn_excel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Diem)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Diem
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgv_Diem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Diem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_Diem.ColumnHeadersHeight = 40;
            this.dgv_Diem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Diem.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_Diem.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_Diem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_Diem.Location = new System.Drawing.Point(0, 0);
            this.dgv_Diem.Name = "dgv_Diem";
            this.dgv_Diem.ReadOnly = true;
            this.dgv_Diem.RowHeadersVisible = false;
            this.dgv_Diem.RowHeadersWidth = 51;
            this.dgv_Diem.RowTemplate.Height = 24;
            this.dgv_Diem.Size = new System.Drawing.Size(1203, 541);
            this.dgv_Diem.TabIndex = 0;
            this.dgv_Diem.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Diem.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_Diem.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_Diem.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_Diem.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_Diem.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Diem.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_Diem.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_Diem.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_Diem.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Diem.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_Diem.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_Diem.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_Diem.ThemeStyle.ReadOnly = true;
            this.dgv_Diem.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_Diem.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Diem.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Diem.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_Diem.ThemeStyle.RowsStyle.Height = 24;
            this.dgv_Diem.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_Diem.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_Diem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Diem_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 612);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Mã Lớp";
            // 
            // cbb_malop
            // 
            this.cbb_malop.BackColor = System.Drawing.Color.Transparent;
            this.cbb_malop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_malop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_malop.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_malop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_malop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_malop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_malop.ItemHeight = 30;
            this.cbb_malop.Location = new System.Drawing.Point(181, 592);
            this.cbb_malop.Name = "cbb_malop";
            this.cbb_malop.Size = new System.Drawing.Size(208, 36);
            this.cbb_malop.TabIndex = 2;
            this.cbb_malop.SelectedIndexChanged += new System.EventHandler(this.cbb_malop_SelectedIndexChanged);
            // 
            // cbb_mamonhoc
            // 
            this.cbb_mamonhoc.BackColor = System.Drawing.Color.Transparent;
            this.cbb_mamonhoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_mamonhoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_mamonhoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_mamonhoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_mamonhoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_mamonhoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_mamonhoc.ItemHeight = 30;
            this.cbb_mamonhoc.Location = new System.Drawing.Point(181, 668);
            this.cbb_mamonhoc.Name = "cbb_mamonhoc";
            this.cbb_mamonhoc.Size = new System.Drawing.Size(208, 36);
            this.cbb_mamonhoc.TabIndex = 4;
            this.cbb_mamonhoc.SelectedIndexChanged += new System.EventHandler(this.cbb_mamonhoc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 688);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn Mã Môn Học";
            // 
            // btn_nhap
            // 
            this.btn_nhap.BorderRadius = 10;
            this.btn_nhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_nhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_nhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_nhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_nhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_nhap.ForeColor = System.Drawing.Color.White;
            this.btn_nhap.Location = new System.Drawing.Point(407, 659);
            this.btn_nhap.Name = "btn_nhap";
            this.btn_nhap.Size = new System.Drawing.Size(180, 45);
            this.btn_nhap.TabIndex = 5;
            this.btn_nhap.Text = "Nhập Điểm";
            this.btn_nhap.Click += new System.EventHandler(this.btn_nhap_Click);
            // 
            // lb_tenlop
            // 
            this.lb_tenlop.AutoSize = true;
            this.lb_tenlop.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tenlop.Location = new System.Drawing.Point(413, 606);
            this.lb_tenlop.Name = "lb_tenlop";
            this.lb_tenlop.Size = new System.Drawing.Size(65, 23);
            this.lb_tenlop.TabIndex = 6;
            this.lb_tenlop.Text = "label3";
            this.lb_tenlop.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_excel);
            this.panel1.Controls.Add(this.btn_diemthilai);
            this.panel1.Controls.Add(this.btn_nhap_daudiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(593, 541);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 214);
            this.panel1.TabIndex = 7;
            // 
            // btn_diemthilai
            // 
            this.btn_diemthilai.BorderRadius = 10;
            this.btn_diemthilai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_diemthilai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_diemthilai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_diemthilai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_diemthilai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_diemthilai.ForeColor = System.Drawing.Color.White;
            this.btn_diemthilai.Location = new System.Drawing.Point(70, 157);
            this.btn_diemthilai.Name = "btn_diemthilai";
            this.btn_diemthilai.Size = new System.Drawing.Size(498, 45);
            this.btn_diemthilai.TabIndex = 9;
            this.btn_diemthilai.Text = "Nhập Điểm Thi Lại";
            this.btn_diemthilai.Visible = false;
            this.btn_diemthilai.Click += new System.EventHandler(this.btn_diemthilai_Click);
            // 
            // btn_nhap_daudiem
            // 
            this.btn_nhap_daudiem.BorderRadius = 10;
            this.btn_nhap_daudiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_nhap_daudiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_nhap_daudiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_nhap_daudiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_nhap_daudiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_nhap_daudiem.ForeColor = System.Drawing.Color.White;
            this.btn_nhap_daudiem.Location = new System.Drawing.Point(70, 15);
            this.btn_nhap_daudiem.Name = "btn_nhap_daudiem";
            this.btn_nhap_daudiem.Size = new System.Drawing.Size(498, 45);
            this.btn_nhap_daudiem.TabIndex = 8;
            this.btn_nhap_daudiem.Text = "Nhập Đầu Điểm";
            this.btn_nhap_daudiem.Click += new System.EventHandler(this.btn_nhap_daudiem_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.BorderRadius = 10;
            this.btn_excel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_excel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_excel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_excel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_excel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_excel.ForeColor = System.Drawing.Color.White;
            this.btn_excel.Location = new System.Drawing.Point(70, 86);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(498, 45);
            this.btn_excel.TabIndex = 10;
            this.btn_excel.Text = "Xuất File Excel";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // frm_Diem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 755);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_tenlop);
            this.Controls.Add(this.btn_nhap);
            this.Controls.Add(this.cbb_mamonhoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbb_malop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Diem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Diem";
            this.Text = "frm_Diem";
            this.Load += new System.EventHandler(this.frm_Diem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Diem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_Diem;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_malop;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_mamonhoc;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btn_nhap;
        private System.Windows.Forms.Label lb_tenlop;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btn_nhap_daudiem;
        private Guna.UI2.WinForms.Guna2Button btn_diemthilai;
        private Guna.UI2.WinForms.Guna2Button btn_excel;
    }
}