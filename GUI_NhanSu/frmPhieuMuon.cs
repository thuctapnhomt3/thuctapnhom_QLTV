using BUS;
using DAO;
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
    public partial class frmPhieuMuon : Form
    {
        public frmPhieuMuon()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        BUSNhanVien Bus = new BUSNhanVien();
        BUSPhieuMuon bis = new BUSPhieuMuon();
        BusSinhVien bus = new BusSinhVien();
        public void ShowNV()
        {
            DataTable dt = new DataTable();
            dt = Bus.GetData();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TENNV";
            comboBox1.ValueMember = "MANV";
        }
        public void ShowSV()
        {
            DataTable dt = new DataTable();
            dt = bus.GetDataProc();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "TENSV";
            comboBox2.ValueMember = "MASV";
        }
        private void DisEnl(bool e)
        {
            btThem.Enabled = !e;
            btXoa.Enabled = !e;
            btSua.Enabled = !e;
            btnLuu.Enabled = e;
            txtMaPhieu.Enabled = e;
            comboBox2.Enabled = e;
            comboBox1.Enabled = e;
            dateTimePicker1.Enabled = e;
            dateTimePicker2.Enabled = e;
            txtGhichu.Enabled = e;
        }
        private void clearData()
        {
            txtMaPhieu.Text = "";
            txtGhichu.Text = "";
        }
        private void HienThi()
        {
            dgvPhieuMuon.DataSource = bis.GetDataProc();
            dgvPhieuMuon.AutoResizeColumns();
            ShowNV();
            ShowSV();
        }
        int fluu;
        private void btThem_Click(object sender, EventArgs e)
        {
            fluu = 0;
            txtMaPhieu.Text = bis.TangMa();
            DisEnl(true);
            txtMaPhieu.Enabled = false;
        }

        private void cboNguoiViet_Load(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);
        }

        private void btSua_Click(object sender, EventArgs e)
        {

            fluu = 1;
            DisEnl(true);
            txtMaPhieu.Enabled = false;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bis.DeleteData(txtMaPhieu.Text);
                    MessageBox.Show("Xóa thành công!");
                    clearData();
                    DisEnl(false);
                    HienThi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu yêu cầu! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập khách hàng! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if (dtNgayNhap.Value != DateTime.Now)
            //{
            //    MessageBox.Show("Bạn nhập sai ngày! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            PhieuMuonDao obj = new PhieuMuonDao();

            obj.MaPM = txtMaPhieu.Text;
            obj.MaNV = comboBox1.SelectedValue.ToString();
            obj.MaSV = comboBox2.SelectedValue.ToString();
            obj.NgayMuon = dateTimePicker1.Value;
            obj.NgayTra = dateTimePicker2.Value;
            obj.Ghichu = txtGhichu.Text;
            if (txtMaPhieu.Text != "" && fluu == 0)
            {
                try
                {

                    bis.InsertData(obj);
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    cboNguoiViet_Load(sender, e);
                    clearData();
                    DisEnl(false);
                    fluu = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
            else if (txtMaPhieu.Text != "" && fluu != 0)
            {
                try
                {
                    bis.UpdateData(obj);
                    MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    cboNguoiViet_Load(sender, e);
                    clearData();
                    DisEnl(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain fmain = new frmMain();
            fmain.Show();
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = Convert.ToString(dgvPhieuMuon.CurrentRow.Cells["MASV"].Value);
            comboBox1.Text = Convert.ToString(dgvPhieuMuon.CurrentRow.Cells["MANV"].Value);
            dateTimePicker1.Text = Convert.ToString(dgvPhieuMuon.CurrentRow.Cells["NGAYMUON"].Value);
            dateTimePicker2.Text = Convert.ToString(dgvPhieuMuon.CurrentRow.Cells["NGAYTRA"].Value);
            txtMaPhieu.Text = Convert.ToString(dgvPhieuMuon.CurrentRow.Cells["MAPM"].Value);
            txtGhichu.Text = Convert.ToString(dgvPhieuMuon.CurrentRow.Cells["GHICHU"].Value);
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            if (cbTimKiem.Text == "Theo Mã")
            {

                dgvPhieuMuon.DataSource = bis.TimKiemPYC("SELECT MAPM,TENNV,TENSV, NGAYMUON,NGAYTRA, GHICHU FROM dbo.PHIEUMUON INNER JOIN dbo.SINHVIEN ON SINHVIEN.MASV = PHIEUMUON.MASV INNER JOIN dbo.NHANVIEN ON NHANVIEN.MANV = PHIEUMUON.MANV WHERE MAPM like '%" + txtTimKiem.Text.Trim() + "%'");
            }
            if (cbTimKiem.Text == "Theo Tên")
            {
                dgvPhieuMuon.DataSource = bis.TimKiemPYC("SELECT MAPM,TENNV,TENSV, NGAYMUON,NGAYTRA, GHICHU FROM dbo.PHIEUMUON INNER JOIN dbo.SINHVIEN ON SINHVIEN.MASV = PHIEUMUON.MASV INNER JOIN dbo.NHANVIEN ON NHANVIEN.MANV = PHIEUMUON.MANV WHERE TENNV like '%" + txtTimKiem.Text.Trim() + "%'");
            }
            if (cbTimKiem.Text == "Theo Tên Sinh Viên")
            {
                dgvPhieuMuon.DataSource = bis.TimKiemPYC("SELECT MAPM,TENNV,TENSV, NGAYMUON,NGAYTRA, GHICHU FROM dbo.PHIEUMUON INNER JOIN dbo.SINHVIEN ON SINHVIEN.MASV = PHIEUMUON.MASV INNER JOIN dbo.NHANVIEN ON NHANVIEN.MANV = PHIEUMUON.MANV WHERE TENSV like '%" + txtTimKiem.Text.Trim() + "%'");
            }
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã phiếu! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                cboTensach CT = new cboTensach(txtMaPhieu.Text);
                CT.ShowDialog();
                this.Show();
                HienThi();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cboNguoiViet_Load(sender, e);
            DisEnl(false);
            clearData();
        }
    }
}
