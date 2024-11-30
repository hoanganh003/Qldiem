namespace QuanLyDiem
{
    partial class frm_Nhap_DauDiem
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_MaSV = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Malop = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_SoLuong = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbb_daudiem = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txt_giatri = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_nhap = new Guna.UI2.WinForms.Guna2Button();
            this.lb_hoTen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Điểm";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(635, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 30;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_MaSV
            // 
            this.lb_MaSV.AutoSize = true;
            this.lb_MaSV.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaSV.Location = new System.Drawing.Point(74, 86);
            this.lb_MaSV.Name = "lb_MaSV";
            this.lb_MaSV.Size = new System.Drawing.Size(110, 28);
            this.lb_MaSV.TabIndex = 31;
            this.lb_MaSV.Text = "lb_MaSV";
            this.lb_MaSV.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 28);
            this.label2.TabIndex = 32;
            this.label2.Text = "Mã Lớp :";
            // 
            // lb_Malop
            // 
            this.lb_Malop.AutoSize = true;
            this.lb_Malop.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Malop.Location = new System.Drawing.Point(189, 139);
            this.lb_Malop.Name = "lb_Malop";
            this.lb_Malop.Size = new System.Drawing.Size(119, 28);
            this.lb_Malop.TabIndex = 33;
            this.lb_Malop.Text = "lb_MaLop";
            this.lb_Malop.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 28);
            this.label3.TabIndex = 34;
            this.label3.Text = "Số Lượng Đầu Điểm :";
            // 
            // lb_SoLuong
            // 
            this.lb_SoLuong.AutoSize = true;
            this.lb_SoLuong.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SoLuong.Location = new System.Drawing.Point(314, 193);
            this.lb_SoLuong.Name = "lb_SoLuong";
            this.lb_SoLuong.Size = new System.Drawing.Size(137, 28);
            this.lb_SoLuong.TabIndex = 35;
            this.lb_SoLuong.Text = "lb_SoLuong";
            this.lb_SoLuong.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 28);
            this.label5.TabIndex = 36;
            this.label5.Text = "Chọn Đầu Điểm :";
            // 
            // cbb_daudiem
            // 
            this.cbb_daudiem.BackColor = System.Drawing.Color.Transparent;
            this.cbb_daudiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_daudiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_daudiem.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_daudiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_daudiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_daudiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_daudiem.ItemHeight = 30;
            this.cbb_daudiem.Location = new System.Drawing.Point(277, 290);
            this.cbb_daudiem.Name = "cbb_daudiem";
            this.cbb_daudiem.Size = new System.Drawing.Size(298, 36);
            this.cbb_daudiem.TabIndex = 37;
            this.cbb_daudiem.SelectedIndexChanged += new System.EventHandler(this.cbb_daudiem_SelectedIndexChanged);
            // 
            // txt_giatri
            // 
            this.txt_giatri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_giatri.DefaultText = "";
            this.txt_giatri.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_giatri.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_giatri.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_giatri.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_giatri.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_giatri.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_giatri.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_giatri.Location = new System.Drawing.Point(277, 359);
            this.txt_giatri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_giatri.Name = "txt_giatri";
            this.txt_giatri.PasswordChar = '\0';
            this.txt_giatri.PlaceholderText = "";
            this.txt_giatri.SelectedText = "";
            this.txt_giatri.Size = new System.Drawing.Size(298, 48);
            this.txt_giatri.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 28);
            this.label6.TabIndex = 39;
            this.label6.Text = "Giá Trị :";
            // 
            // btn_nhap
            // 
            this.btn_nhap.BorderRadius = 10;
            this.btn_nhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_nhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_nhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_nhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_nhap.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nhap.ForeColor = System.Drawing.Color.White;
            this.btn_nhap.Location = new System.Drawing.Point(395, 472);
            this.btn_nhap.Name = "btn_nhap";
            this.btn_nhap.Size = new System.Drawing.Size(180, 45);
            this.btn_nhap.TabIndex = 40;
            this.btn_nhap.Text = "Nhập";
            this.btn_nhap.Click += new System.EventHandler(this.btn_nhap_Click);
            // 
            // lb_hoTen
            // 
            this.lb_hoTen.AutoSize = true;
            this.lb_hoTen.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hoTen.Location = new System.Drawing.Point(314, 86);
            this.lb_hoTen.Name = "lb_hoTen";
            this.lb_hoTen.Size = new System.Drawing.Size(111, 28);
            this.lb_hoTen.TabIndex = 43;
            this.lb_hoTen.Text = "lb_hoTen";
            this.lb_hoTen.Visible = false;
            // 
            // frm_Nhap_DauDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 544);
            this.Controls.Add(this.lb_hoTen);
            this.Controls.Add(this.btn_nhap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_giatri);
            this.Controls.Add(this.cbb_daudiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_SoLuong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_Malop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_MaSV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Nhap_DauDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Nhap_DauDiem";
            this.Load += new System.EventHandler(this.frm_Nhap_DauDiem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_MaSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_Malop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_SoLuong;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_daudiem;
        private Guna.UI2.WinForms.Guna2TextBox txt_giatri;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btn_nhap;
        private System.Windows.Forms.Label lb_hoTen;
    }
}