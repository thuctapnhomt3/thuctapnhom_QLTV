using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_1.GUI;

namespace GUI_NhanSu
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }

        BUS.BusSinhVien bis = new BUS.BusSinhVien();
        private void DisEnl(bool e)
        {
            btThem.Enabled = !e;
            btXoa.Enabled = !e;
            btSua.Enabled = !e;
            btnLuu.Enabled = e;
            txtHoten.Enabled = e;
            cboGioiTinh.Enabled = e;
            dtgNgaySinh.Enabled = e;
            txtDiachi.Enabled = e;
            txtLop.Enabled = e;
            txtMaSV.Enabled = e;

        }
        private void clearData()
        {
            txtHoten.Text = "";
            txtMaSV.Text = "";
            txtLop.Text = "";
            txtDiachi.Text = "";
            dtgNgaySinh.Text = "";
            cboGioiTinh.Text = "";
        }
        private void HienThi()
        {
            dgvSinhVien.DataSource = bis.GetDataProc();
            dgvSinhVien.AutoResizeColumns();
           
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain fmain = new frmMain();
            fmain.Show();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);
        }

        private void dgvSinhVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvSinhVien.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = Convert.ToString(dgvSinhVien.CurrentRow.Cells["MASV"].Value);
            txtHoten.Text = Convert.ToString(dgvSinhVien.CurrentRow.Cells["TENSV"].Value);
            cboGioiTinh.Text = Convert.ToString(dgvSinhVien.CurrentRow.Cells["GIOITINH"].Value);
            txtLop.Text = Convert.ToString(dgvSinhVien.CurrentRow.Cells["LOP"].Value);
            txtDiachi.Text = Convert.ToString(dgvSinhVien.CurrentRow.Cells["DIACHI"].Value);
            dtgNgaySinh.Text= Convert.ToString(dgvSinhVien.CurrentRow.Cells["NGAYSINH"].Value);

        }
        int fluu;
        private void btThem_Click(object sender, EventArgs e)
        {
            fluu = 0;

            txtMaSV.Text = bis.TangMa();
            DisEnl(true);
            txtMaSV.Enabled = false;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            fluu = 1;
            DisEnl(true);
            txtMaSV.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //if (txtMaSV.Text == "")
            //{
            //    MessageBox.Show("Bạn chưa nhập mã phiếu yêu cầu! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //if (txtHoten.Text == "")
            //{
            //    MessageBox.Show("Bạn chưa nhập khách hàng! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //DAO.SinhVienDAO obj = new DAO.SinhVienDAO();


            //obj.Masv = txtMaSV.Text;
            //obj.Hoten = txtHoten.Text;
            //obj.Gioitinh = cboGioiTinh.SelectedItem.ToString();
            //obj.Ngaysinh = dtgNgaySinh.Value;
            //obj.Diachi = txtHoten.Text;
            // obj.Lop = txtLop.Text;
            //if (txtMaSV.Text != "" && txtHoten.Text != ""  && fluu == 0)
            //{
            //    try
            //    {

            //        bis.InsertData(obj);
            //        MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        HienThi();
            //        frmSinhVien_Load(sender, e);
            //        clearData();
            //        DisEnl(false);
            //        fluu = 1;
            //    }
            //    catch
            //    {

            //    }
            //}
            //else if (txtMaSV.Text != "" && txtHoten.Text != "" && fluu != 0)
            //{
            //    try
            //    {
            //        bis.UpdateData(obj);
            //        MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        HienThi();
            //        frmSinhVien_Load(sender, e);
            //        clearData();
            //        DisEnl(false);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi" + ex.Message);
            //    }
            //}

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        bis.DeleteData(txtMaSV.Text);
            //        MessageBox.Show("Xóa thành công!");
            //        clearData();
            //        DisEnl(false);
            //        HienThi();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi" + ex.Message);
            //    }
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmSinhVien_Load(sender, e);
            DisEnl(false);
            clearData();
        }
    }
}
