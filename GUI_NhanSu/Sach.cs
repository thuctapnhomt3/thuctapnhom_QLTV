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
    public partial class Sach : Form
    {
        public Sach()
        {
            InitializeComponent();
            ShowData();
        }

        BusSach bus_nv = new BusSach();
        void FormatData()
        {
            txtMasach.Text = "";
            txtTensach.Text = "";

            txtsoluong.Text = "";
            txttentacgia.Text = "";
            txtnamxb.Text = "";
          
        }
        void ShowData()
        {
            dgvSach.DataSource = bus_nv.GetData();
        }
        private void dtNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Sach_Load(object sender, EventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //if (txtMasach.Text.Length != 0)
            //{
            //    string query = @"DELETE FROM dbo.NhanVien Where manv='" + txtMasach.Text + "'";
            //    if (MessageBox.Show("Phòng ban liên quan đến các bảng khác, bạn có chắc muốn xóa dữ liệu liên quan đến phòng ban ??", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        if (bus_nv.Xoa(txtMasach.Text.Trim()))
            //        {
            //            FormatData();
            //            ShowData();
            //            MessageBox.Show("Xóa thành công");
            //        }
            //        else
            //        {
            //            Exception ex = bus_nv.GetEx();
            //            MessageBox.Show(ex.Message);
            //            MessageBox.Show("Lỗi");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn");
            //}
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (dr == DialogResult.OK)
            //{
            //    if (txtMasach.Text != "" && txtnamxb.Text != "" && txttentacgia.Text != "" && txtTensach.Text != "")
            //    {
                    
            //        SachDao nv = new SachDao(txtMasach.Text.ToString().Trim(), txtTensach.Text.ToString().Trim(), txttentacgia.Text.Trim(),int.Parse(txtsoluong.Text.Trim()), txtnamxb.Text.ToString().Trim());
            //        if (bus_nv.Sua(nv) == true)
            //        {
            //            FormatData();
            //            ShowData();
            //            MessageBox.Show("Sửa thành công");
            //        }
            //        else
            //        {
            //            Exception ex = bus_nv.GetEx();
            //            MessageBox.Show(ex.Message);
            //            MessageBox.Show("Có lỗi xảy ra");
            //        }
            //    }
            //    else
            //        MessageBox.Show("Bạn cần nhập đủ thông tin phòng ban");
            //}
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (dr == DialogResult.OK)
            //{
            //    if (txtMasach.Text != "" && txtnamxb.Text != "" && txttentacgia.Text != "" && txtTensach.Text != "")
            //    {
            //        SachDao sach = new SachDao(txtMasach.Text.ToString().Trim(), txtTensach.Text.ToString().Trim(), txtTensach.Text.Trim(), int.Parse(txtsoluong.Text.Trim()), txtnamxb.Text.ToString().Trim());
            //        //(txtMaNV.Text.ToString().Trim(), txtTen.Text.ToString().Trim(), txtMaPhong.Text.ToString().Trim(),DateTime.Parse(dtNgaySinh.Text.ToString()),gioitinh,int.Parse(txtLuong.Text.ToString()), txtDiaChi.Text.ToString().Trim());
            //        if (bus_nv.Them(sach) == true)
            //        {
            //            FormatData();
            //            ShowData();
            //            MessageBox.Show("Thêm thành công");
            //        }
            //        else
            //        {
            //            Exception ex = bus_nv.GetEx();
            //            MessageBox.Show(ex.Message);
            //            MessageBox.Show("Có lỗi xảy ra");
            //        }
            //    }
            //    else
            //        MessageBox.Show("Bạn cần nhập đủ thông tin ");
            //}
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain fmain = new frmMain();
            fmain.Show();
        }

        private void btHienThi_Click(object sender, EventArgs e)
        {
            btHienThi.Enabled = false;
            txtTimKiem.Text = "";
            ShowData();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            //if (txtTimKiem.Text != "")
            //{
            //    btHienThi.Enabled = true;
            //    if (bus_nv.GetDataTimKiem(txtTimKiem.Text.Trim()) != null)
            //    {
            //        FormatData();
            //        dgvSach.DataSource = bus_nv.GetDataTimKiem(txtTimKiem.Text.Trim());
            //        MessageBox.Show("Tìm thành công");
            //    }
            //    else
            //    {
            //        Exception ex = bus_nv.GetEx();
            //        MessageBox.Show(ex.Message);
            //        MessageBox.Show("Lỗi rồi bạn ơi !");
            //    }
            //}
            //else
            //    MessageBox.Show("Bạn cần nhập thông tin để tìm kiếm !");
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvSach.Rows[e.RowIndex];
                txtMasach.Text = row.Cells["MASACH"].Value.ToString().Trim();
                txtTensach.Text = row.Cells["TENSACH"].Value.ToString().Trim();


                txtsoluong.Text = row.Cells["SOLUONG"].Value.ToString().Trim();
                txttentacgia.Text = row.Cells["TENTG"].Value.ToString().Trim();
                txtnamxb.Text = row.Cells["NAMXUATBAN"].Value.ToString().Trim();
            }
            catch (Exception ex)
            {
                ex = bus_nv.GetEx();
                MessageBox.Show(ex.Message);
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void dgvSach_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvSach.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
