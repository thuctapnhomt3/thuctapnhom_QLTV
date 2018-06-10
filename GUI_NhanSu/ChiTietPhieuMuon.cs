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
    public partial class cboTensach : Form
    {
        public cboTensach()
        {
            InitializeComponent();
        }

        public void ShowSach()
        {
            BUS.BusSach Bus = new BUS.BusSach();
            DataTable dt = new DataTable();
            dt = Bus.GetDataProc(txtMaPhieu.Text);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TENSACH";
            comboBox1.ValueMember = "MASACH";
        }
        int fluu;
        private void DisEnl(bool e)
        {
            btThem.Enabled = !e;
            btXoa.Enabled = !e;
            btSua.Enabled = !e;
            btnLuu.Enabled = e;
            txtMaPhieu.Enabled = e;
            txtSoluong.Enabled = e;
            comboBox1.Enabled = e;
            
        }
        private void clearData()
        {
            txtMaPhieu.Text = "";
            txtSoluong.Text = "";
        }
        private void HienThi()
        {
            txtMaPhieu.Text = ma;
            BUS.BUSChiTietPhieuMuon bis = new BUS.BUSChiTietPhieuMuon();
            dgvChiTietPhieuMuon.DataSource = bis.GetDataProc("SELECT MAPM,TENSACH,SOLUONGMUON,TENTG FROM dbo.CHITIETPHIEUMUON,dbo.SACH WHERE SACH.MASACH = CHITIETPHIEUMUON.MASACH AND MAPM = '"+txtMaPhieu.Text.Trim()+"'");
            dgvChiTietPhieuMuon.AutoResizeColumns();
            ShowSach();
        }
        string ma;
        public cboTensach(string text) : this()
        {
            ma = text;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            fluu = 0;
            DisEnl(true);
            txtMaPhieu.Enabled = false;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            fluu = 1;
            DisEnl(true);
            txtMaPhieu.Enabled = false;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            BUS.BUSChiTietPhieuMuon Bus = new BUS.BUSChiTietPhieuMuon();
            if (txtMaPhieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            int _soLuong;
            int.TryParse(txtSoluong.Text, out _soLuong);
            DAO.ChiTietPhieuMuon obj = new DAO.ChiTietPhieuMuon();
            obj.MaPM = txtMaPhieu.Text;
            obj.MaSach = comboBox1.SelectedValue.ToString();
            obj.SoLuong = _soLuong;

            if (txtMaPhieu.Text != ""  && fluu == 0)
            {
                try
                {
                    Bus.InsertData(obj);
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    cboTensach_Load(sender, e);
                    DisEnl(false);
                    fluu = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
            else if (txtMaPhieu.Text != "" &&  fluu != 0)
            {
                try
                {
                    Bus.UpdateData(obj);
                    MessageBox.Show("Sửa Thành Công ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    cboTensach_Load(sender, e);
                    DisEnl(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            BUS.BUSChiTietPhieuMuon BUS = new BUS.BUSChiTietPhieuMuon();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    BUS.DeleteData(txtMaPhieu.Text, comboBox1.SelectedValue.ToString());
                    MessageBox.Show("Xóa thành công!");
                    DisEnl(false);
                    HienThi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
            }
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {

        }

        private void cboTensach_Load(object sender, EventArgs e)
        {
            HienThi();
            DisEnl(false);
        }

        private void dgvChiTietPhieuMuon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvChiTietPhieuMuon.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPhieuMuon fmain = new frmPhieuMuon();
            fmain.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cboTensach_Load(sender, e);
            DisEnl(false);
            clearData();
        }
    }
}
