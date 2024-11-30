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
using ClosedXML.Excel;

namespace QuanLyDiem
{
    public partial class frm_Diem : Form
    {
        public static string masv ,hoten , malop, mamon , tyle;
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public frm_Diem()
        {
            InitializeComponent();
            loadcbbmalop();
        }
        void LoadDataGridView(string maLopHoc, string maMonHoc)
        {
            dgv_Diem.Columns.Clear();
            dgv_Diem.Columns.Add("MaSinhVien", "Mã Sinh Viên");
            dgv_Diem.Columns.Add("HoTen", "Họ Tên");

            List<string> listDauDiem = LayDanhSachDauDiem(maMonHoc);

            foreach (var dauDiem in listDauDiem)
            {
                dgv_Diem.Columns.Add(dauDiem, dauDiem);
            }
            dgv_Diem.Columns.Add("DiemQuaTrinh", "Điểm Quá Trình");
            dgv_Diem.Columns.Add("DieuKienDuThi", "Điều Kiện Dự Thi");
            dgv_Diem.Columns.Add("DiemTongKet", "Điểm Tổng Kết");
            dgv_Diem.Columns.Add("DieuKienQuaMon", "Điều Kiện Qua Môn");


            if (!dgv_Diem.Columns.Contains("Điểm Thi"))
            {
                MessageBox.Show("Cột Điểm Thi chưa được thêm vào dgv_Diem.");
            }
            else
            {
                int diemThiIndex = dgv_Diem.Columns["Điểm Thi"].Index;
                dgv_Diem.Columns.Insert(diemThiIndex + 1, new DataGridViewTextBoxColumn { Name = "LanThi", HeaderText = "Lần Thi" });
            }

            DataTable danhSachSinhVien = LayDanhSachSinhVien(maLopHoc);
            if (danhSachSinhVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có sinh viên nào trong lớp này.");
                return;
            }
            DataTable dtDiem = LayDuLieuDiemSinhVien(maLopHoc, maMonHoc);
            float diemToiThieu = LayDiemToiThieuDuThi(maMonHoc);
            float diemQuaMon = LayDiemToiThieuQuaMon(maMonHoc);

            foreach (DataRow svRow in danhSachSinhVien.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv_Diem);

                string maSinhVien = svRow["MaSinhVien"].ToString();
                string hoTen = svRow["HoTen"].ToString();
                row.Cells[0].Value = maSinhVien;
                row.Cells[1].Value = hoTen;

                float tongtyle = 0;
                float diemQuaTrinh = 0;
                float tongdiemQuaTrinh = 0;
                var diemRows = dtDiem.AsEnumerable().Where(d => d["MaSinhVien"].ToString() == maSinhVien);

                foreach (var diemRow in diemRows)
                {
                    string dauDiem = diemRow["TenDauDiem"].ToString();

                    if (dauDiem == "Điểm Thi")
                    {
                        continue;
                    }

                    if (dgv_Diem.Columns.Contains(dauDiem))
                    {
                        int columnIndex = dgv_Diem.Columns[dauDiem].Index;
                        row.Cells[columnIndex].Value = diemRow["Diem"];

                        float diem = diemRow["Diem"] != DBNull.Value ? Convert.ToSingle(diemRow["Diem"]) : 0;
                        float tyLe = diemRow["TyLe"] != DBNull.Value ? Convert.ToSingle(diemRow["TyLe"]) : 0;
                        diemQuaTrinh += diem * (tyLe / 100);
                        tongtyle += tyLe;
                        tongdiemQuaTrinh = (diemQuaTrinh / tongtyle) * 100;
                    }
                }

                if (listDauDiem.Contains("Điểm Thi"))
                {
                    int diemThiIndex = dgv_Diem.Columns["Điểm Thi"].Index;
                    var diemThi = diemRows.FirstOrDefault(d => d["TenDauDiem"].ToString() == "Điểm Thi")?["Diem"];
                    row.Cells[diemThiIndex].Value = diemThi != DBNull.Value ? diemThi : null;

                    int lanThiIndex = dgv_Diem.Columns["LanThi"].Index;
                    var lanThi = diemRows.FirstOrDefault(d => d["LanThi"] != DBNull.Value && d["LanThi"] != null)?["LanThi"];

                    if (lanThi != DBNull.Value && lanThi != null)
                    {
                        row.Cells[lanThiIndex].Value = Convert.ToInt32(lanThi);
                    }

                    dgv_Diem.Columns["Điểm Thi"].DisplayIndex = dgv_Diem.Columns["DieuKienDuThi"].DisplayIndex + 1;
                    dgv_Diem.Columns["LanThi"].DisplayIndex = dgv_Diem.Columns["Điểm Thi"].DisplayIndex;
                }

                int diemQuaTrinhIndex = dgv_Diem.Columns["DiemQuaTrinh"].Index;
                row.Cells[diemQuaTrinhIndex].Value = tongdiemQuaTrinh;

                float diemthi = 0;
                var diemThiColumnIndex = dgv_Diem.Columns["Điểm Thi"]?.Index;

                if (diemThiColumnIndex != null && diemThiColumnIndex >= 0)
                {
                    var diemThiCell = row.Cells[(int)diemThiColumnIndex].Value;

                    if (diemThiCell != null && diemThiCell != DBNull.Value)
                    {
                        diemthi = Convert.ToSingle(diemThiCell);
                    }
                }

                int diemTongKetIndex = dgv_Diem.Columns["DiemTongKet"].Index;
                float diemTongKet = 0;

                if (tongtyle > 0)
                {
                    diemTongKet = (diemthi * (float)(1 - (tongtyle / 100))) + (tongdiemQuaTrinh * (float)(tongtyle / 100));
                }
                else
                {
                    diemTongKet = tongdiemQuaTrinh;
                }

                row.Cells[diemTongKetIndex].Value = diemTongKet;

                int dieuKienDuThiIndex = dgv_Diem.Columns["DieuKienDuThi"].Index;
                row.Cells[dieuKienDuThiIndex].Value = tongdiemQuaTrinh >= diemToiThieu ? "Đạt" : "Không Đạt";

                int dieuKienQuaMonIndex = dgv_Diem.Columns["DieuKienQuaMon"].Index;
                row.Cells[dieuKienQuaMonIndex].Value = diemTongKet >= diemQuaMon ? "Qua" : "Thi Lại";

                dgv_Diem.Rows.Add(row);
            }
        }

        public DataTable LayDanhSachSinhVien(string maLopHoc)
        {
            DataTable dtSinhVien = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT sv.MaSinhVien, sv.HoTen 
                         FROM SinhVien_LopHoc svlh
                         INNER JOIN SinhVien sv ON svlh.MaSinhVien = sv.MaSinhVien
                         WHERE svlh.MaLopHoc = @MaLopHoc";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLopHoc", maLopHoc);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSinhVien);
            }
            return dtSinhVien;
        }

        float LayDiemToiThieuDuThi(string maMonHoc)
        {
            string query = @"SELECT DieuKienDiThi 
                     FROM DieuKienMonHoc 
                     WHERE MaMonHoc = @MaMonHoc";

            var parameters = new Dictionary<string, object>
            {
                { "@MaMonHoc", maMonHoc }
            };

            DataTable dt = ThucHienTruyVan(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToSingle(dt.Rows[0]["DieuKienDiThi"]);
            }
            return 0;
        }
        float LayDiemToiThieuQuaMon(string maMonHoc)
        {
            string query = @"SELECT DiemToiThieu 
                     FROM DieuKienMonHoc 
                     WHERE MaMonHoc = @MaMonHoc";

            var parameters = new Dictionary<string, object>
            {
                { "@MaMonHoc", maMonHoc }
            };

            DataTable dt = ThucHienTruyVan(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToSingle(dt.Rows[0]["DiemToiThieu"]);
            }
            return 0;
        }
        List<string> LayDanhSachDauDiem(string maMonHoc)
        {
            List<string> listDauDiem = new List<string>();

            string query = @"SELECT TenDauDiem 
                     FROM DiemDauDiem 
                     WHERE MaMonHoc = @MaMonHoc";

            var parameters = new Dictionary<string, object>
            {
                { "@MaMonHoc", maMonHoc}
            };

            DataTable dt = ThucHienTruyVan(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                listDauDiem.Add(row["TenDauDiem"].ToString());
            }

            return listDauDiem;
        }

        DataTable LayDuLieuDiemSinhVien(string maLopHoc, string maMonHoc)
        {
                        string query = @"SELECT 
                sv.MaSinhVien, sv.HoTen, dd.TenDauDiem, ds.Diem, dd.TyLe, ds.LanThi
             FROM 
                SinhVien sv 
             JOIN 
                SinhVien_LopHoc svl ON sv.MaSinhVien = svl.MaSinhVien
             JOIN 
                LopHoc lh ON svl.MaLopHoc = lh.MaLopHoc
             JOIN 
                DiemDauDiem dd ON lh.MaMonHoc = dd.MaMonHoc
             LEFT JOIN 
                DiemSinhVien ds ON sv.MaSinhVien = ds.MaSinhVien AND dd.MaDauDiem = ds.MaDauDiem
             WHERE 
                lh.MaLopHoc = @MaLopHoc AND lh.MaMonHoc = @MaMonHoc
             ORDER BY 
                sv.MaSinhVien, dd.TenDauDiem";

            var parameters = new Dictionary<string, object>
            {
                { "@MaLopHoc", maLopHoc },
                { "@MaMonHoc", maMonHoc }
            };

            return ThucHienTruyVan(query, parameters);
        }
        DataTable ThucHienTruyVan(string query, Dictionary<string, object> parameters = null)
        {
            string connectionString = "Data Source=DUY_THANH\\SQLEXPRESS;Initial Catalog=QuanLyDiemSinhVien;Integrated Security=True;";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi truy vấn: " + ex.Message);
                }
            }

            return dt;
        }
        private void frm_Diem_Load(object sender, EventArgs e)
        {

        }
        private void loadcbbmalop()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaLopHoc FROM LopHoc WHERE TrangThai = 1", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                cbb_malop.Items.Clear();
                while (reader.Read())
                {
                    cbb_malop.Items.Add(reader["MaLopHoc"].ToString());
                }
                reader.Close();
            }
        }
        private void loadcbbmammon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaMonHoc FROM LopHoc WHERE MaLopHoc = '"+cbb_malop.Text+"' AND TrangThai = 1", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                cbb_mamonhoc.Items.Clear();
                while (reader.Read())
                {
                    cbb_mamonhoc.Items.Add(reader["MaMonHoc"].ToString());
                }
                reader.Close();
            }
        }

        private void cbb_malop_SelectedIndexChanged(object sender, EventArgs e)
        {
            malop = cbb_malop.Text;
            loadcbbmammon();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TenLopHoc FROM LopHoc WHERE MaLopHoc = '" + cbb_malop.Text + "' AND TrangThai = 1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lb_tenlop.Visible = true;   
                    lb_tenlop.Text =  reader["TenLopHoc"].ToString();
                }
                reader.Close();
            }
        }

        private void btn_diemthilai_Click(object sender, EventArgs e)
        {
            frm_NhapDiemThiLai f = new frm_NhapDiemThiLai();
            f.ShowDialog();
            LoadDataGridView(cbb_malop.Text, cbb_mamonhoc.Text);
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            if (dgv_Diem.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                DataTable dt = new DataTable();
                                foreach (DataGridViewColumn col in dgv_Diem.Columns)
                                {
                                    dt.Columns.Add(col.HeaderText);
                                }
                                foreach (DataGridViewRow row in dgv_Diem.Rows)
                                {
                                    DataRow newRow = dt.NewRow();
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        newRow[cell.ColumnIndex] = cell.Value ?? DBNull.Value;
                                    }
                                    dt.Rows.Add(newRow);
                                }
                                wb.Worksheets.Add(dt, "DataGridView_Data");

                                wb.SaveAs(sfd.FileName);

                                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbb_mamonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            mamon = cbb_mamonhoc.Text;
        }

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            if (cbb_malop.Text != "" || cbb_mamonhoc.Text != "")
            {
                LoadDataGridView(cbb_malop.Text,cbb_mamonhoc.Text);
            }
        }

        private void dgv_Diem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgv_Diem.Rows[e.RowIndex];
                if (selectedRow.Cells["MaSinhVien"].Value != null)
                {
                    masv = selectedRow.Cells["MaSinhVien"].Value.ToString();
                }

                if (selectedRow.Cells["HoTen"].Value != null)
                {
                    hoten = selectedRow.Cells["HoTen"].Value.ToString();
                }

                if (selectedRow.Cells["DieuKienQuaMon"] != null
                    && selectedRow.Cells["DieuKienQuaMon"].Value != null
                    && selectedRow.Cells["DieuKienQuaMon"].Value.ToString() == "Thi Lại")
                {
                    btn_diemthilai.Visible = true;
                }
                else
                {
                    btn_diemthilai.Visible = false;
                }
            }
        }

        private void btn_nhap_daudiem_Click(object sender, EventArgs e)
        {
            frm_Nhap_DauDiem f = new frm_Nhap_DauDiem();
            f.ShowDialog();
            LoadDataGridView(cbb_malop.Text, cbb_mamonhoc.Text);
        }
    }
}
