using GUI_NhanSu;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tsLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin frm = new frmLogin();
            frm.Show();
        }


     
        private void tsNhanVien_Click(object sender, EventArgs e)
        {
            this.Close();
            frmNhanVien frmnv = new frmNhanVien();
            frmnv.Show();
        }

        private void qUẢNLÝNHÂNSỰToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sACHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Sach frmnv = new Sach();
            frmnv.Show();
        }

        private void pHIẾUTRẢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            PhieuTra frmnv = new PhieuTra();
            frmnv.Show();
        }

        private void tsDeAn_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPhieuMuon duc = new frmPhieuMuon();
            duc.Show();
        }

        private void ttPhongBan_Click(object sender, EventArgs e)
        {
            this.Close();
            frmSinhVien duc = new frmSinhVien();
            duc.Show();
        }

        private void tsNVDA_Click(object sender, EventArgs e)
        {

        }
    }
}
