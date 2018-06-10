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

namespace TTN_1.GUI
{

    // cong viec cua Duc
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            ShowData();
        }


        BUSNhanVien bus_nv = new BUSNhanVien();
        void FormatData()
        {
            txtMaNV.Text = "";
            txtTen.Text = "";
            
            txtLuong.Text = "";
            txtDiaChi.Text = "";
            dtNgaySinh.Value = new DateTime(1997, 10, 01);
            rbKhac.Checked = false;
            rbNam.Checked = false;
            rbNu.Checked = false;
        }
        void ShowData()
        {
            dtgvNhanVien.DataSource = bus_nv.GetData();
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Length != 0)
            {
                string query = @"DELETE FROM dbo.NhanVien Where manv='" + txtMaNV.Text + "'";
                if (MessageBox.Show("Phòng ban liên quan đến các bảng khác, bạn có chắc muốn xóa dữ liệu liên quan đến phòng ban ??", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (bus_nv.Xoa(txtMaNV.Text.Trim()))
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
       
        private void btThem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (txtMaNV.Text != "" && txtTen.Text !=  "" && txtLuong.Text != ""&& txtDiaChi.Text != "")
                {
                    string gioitinh = "";
                    if (rbNam.Checked)
                    {
                        gioitinh = "Nam";
                    }
                    else if (rbNu.Checked)
                    {
                        gioitinh = "Nữ";
                    }
                    else
                    {
                        gioitinh = "Khác";
                    }
                    NhanVien nv = new NhanVien(txtMaNV.Text.ToString().Trim(), txtTen.Text.ToString().Trim(), DateTime.Parse(dtNgaySinh.Text.ToString()), gioitinh, int.Parse(txtLuong.Text.ToString()), txtDiaChi.Text.ToString().Trim());
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
                    MessageBox.Show("Bạn cần nhập đủ thông tin phòng ban");
            }
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString().Trim();
                txtTen.Text = row.Cells[1].Value.ToString().Trim();
                
                dtNgaySinh.Text = row.Cells[2].Value.ToString().Trim();
                if (row.Cells[3].Value.ToString().Trim() == "Nam")
                {
                    rbNam.Checked = true;
                }
                else if (row.Cells[3].Value.ToString().Trim() == "Nữ")
                    rbNu.Checked = true;
                else
                    rbKhac.Checked = true;
                txtLuong.Text = row.Cells[5].Value.ToString().Trim();
                txtDiaChi.Text = row.Cells[4].Value.ToString().Trim();
            }
            catch (Exception ex)
            {
                ex = bus_nv.GetEx();
                MessageBox.Show(ex.Message);
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (txtMaNV.Text != "" && txtTen.Text != "" && txtLuong.Text != "" && txtDiaChi.Text != "")
                {
                    string gioitinh = "";
                    if (rbNam.Checked)
                    {
                        gioitinh = "Nam";
                    }
                    else if (rbNu.Checked)
                    {
                        gioitinh = "Nữ";
                    }
                    else
                    {
                        gioitinh = "Khác";
                    }
                    NhanVien nv = new NhanVien(txtMaNV.Text.ToString().Trim(), txtTen.Text.ToString().Trim(),  DateTime.Parse(dtNgaySinh.Text.ToString()), gioitinh, int.Parse(txtLuong.Text.ToString()), txtDiaChi.Text.ToString().Trim());
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
                    MessageBox.Show("Bạn cần nhập đủ thông tin phòng ban");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain fmain = new frmMain();
            fmain.Show();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                btHienThi.Enabled = true;
                if (bus_nv.GetDataTimKiem(txtTimKiem.Text.Trim()) != null)
                {
                    FormatData();
                    dtgvNhanVien.DataSource = bus_nv.GetDataTimKiem(txtTimKiem.Text.Trim());
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

        private void frmNhanVien_Load(object sender, EventArgs e)
        {

        }
        private void DisEnl(bool e)
        {
            btThem.Enabled = !e;
            btXoa.Enabled = !e;
            btSua.Enabled = !e;
            txtDiaChi.Enabled = e;
            txtLuong.Enabled = e;
            txtMaNV.Enabled = e;
            txtTen.Enabled = e;

        }
        private void clearData()
        {
            txtTen.Text = "";
            txtLuong.Text = "";
            txtDiaChi.Text = "";
            txtMaNV.Text = "";
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
            DisEnl(false);
            clearData();
        }
    }
}
