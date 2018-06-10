using BUS;
using DAL;
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
    public partial class PhieuTra : Form
    {
        public PhieuTra()
        {
            InitializeComponent();
            ShowData();
        }
        BUSPhieuTra bus_nv = new BUSPhieuTra();
        BusSinhVien bus = new BusSinhVien();
        void FormatData()
        {
            txtMaPhieu.Text = "";
            txtGhichu.Text = "";
            txtGhichu.Text = "";

            dtNgayTra.Value = new DateTime(1997, 10, 01);

        }
        void ShowData()
        {
            dtgPhieutra.DataSource = bus_nv.GetData();
            cboSinhVien.DataSource = bus.GetDataProc();
            cboSinhVien.DisplayMember = "TENSV";
            cboSinhVien.ValueMember = "MASV";
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (txtMaPhieu.Text != "")
                {

                    PhieuTraDao nv = new PhieuTraDao(txtMaPhieu.Text.ToString().Trim(), cboSinhVien.SelectedValue.ToString(), dtNgayTra.Value, txtGhichu.Text);
                    //(txtMaNV.Text.ToString().Trim(), txtTen.Text.ToString().Trim(), txtMaPhong.Text.ToString().Trim(),DateTime.Parse(dtNgaySinh.Text.ToString()),gioitinh,int.Parse(txtLuong.Text.ToString()), txtDiaChi.Text.ToString().Trim());
                    if (bus_nv.Them(nv) == true)
                    {
                        FormatData();
                        ShowData();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        Exception ex = bus_nv.GetEx();
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Có lỗi xảy ra");
                    }
                }
                else
                    MessageBox.Show("Bạn cần nhập đủ thông tin ");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (txtMaPhieu.Text != "")
                {

                    PhieuTraDao nv = new PhieuTraDao(txtMaPhieu.Text.ToString().Trim(), cboSinhVien.SelectedValue.ToString(), DateTime.Parse(dtNgayTra.Text.ToString()), txtGhichu.Text);
                    //(txtMaNV.Text.ToString().Trim(), txtTen.Text.ToString().Trim(), txtMaPhong.Text.ToString().Trim(),DateTime.Parse(dtNgaySinh.Text.ToString()),gioitinh,int.Parse(txtLuong.Text.ToString()), txtDiaChi.Text.ToString().Trim());
                    if (bus_nv.Sua(nv) == true)
                    {
                        FormatData();
                        ShowData();
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        Exception ex = bus_nv.GetEx();
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Có lỗi xảy ra");
                    }
                }
                else
                    MessageBox.Show("Bạn cần nhập đủ thông tin ");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text.Length != 0)
            {

                if (MessageBox.Show("Phòng ban liên quan đến các bảng khác, bạn có chắc muốn xóa dữ liệu liên quan đến phòng ban ??", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (bus_nv.Xoa(txtMaPhieu.Text.Trim()))
                    {
                        FormatData();
                        ShowData();
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        Exception ex = bus_nv.GetEx();
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn");
            }
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                btHienThi.Enabled = true;
                if (bus_nv.GetDataTimKiem(txtTimKiem.Text.Trim()) != null)
                {
                    FormatData();
                    dtgPhieutra.DataSource = bus_nv.GetDataTimKiem(txtTimKiem.Text.Trim());
                    MessageBox.Show("Tìm thành công");
                }
                else
                {
                    Exception ex = bus_nv.GetEx();
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Lỗi rồi bạn ơi !");
                }
            }
            else
                MessageBox.Show("Bạn cần nhập thông tin để tìm kiếm !");
        }

        private void btHienThi_Click(object sender, EventArgs e)
        {
            btHienThi.Enabled = false;
            txtTimKiem.Text = "";
            ShowData();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {

            this.Close();
            frmMain fmain = new frmMain();
            fmain.Show();
        }

        private void PhieuTra_Load(object sender, EventArgs e)
        {

        }

        private void dtgPhieutra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtgPhieutra.Rows[e.RowIndex];
                txtMaPhieu.Text = row.Cells["MAPT"].Value.ToString().Trim();
                txtGhichu.Text = row.Cells["GHICHU"].Value.ToString().Trim();


                cboSinhVien.Text = row.Cells["TENSV"].Value.ToString().Trim();
                dtNgayTra.Text = row.Cells["NGAYTRA"].Value.ToString().Trim();

            }
            catch (Exception ex)
            {
                ex = bus_nv.GetEx();
                MessageBox.Show(ex.Message);
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void dtgPhieutra_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dtgPhieutra.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void DisEnl(bool e)
        {
            btThem.Enabled = !e;
            btXoa.Enabled = !e;
            btSua.Enabled = !e;
            txtGhichu.Enabled = e;
            txtMaPhieu.Enabled = e;
            cboSinhVien.Enabled = e;




        }
        private void clearData()
        {
            txtMaPhieu.Text = "";
            txtGhichu.Text = "";
            cboSinhVien.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DisEnl(false);
            clearData();
        }
    }
}
