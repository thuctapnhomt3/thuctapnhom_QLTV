using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTN_1.GUI;

namespace GUI_NhanSu
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public static int quyen;
        ClassConnection cq = new ClassConnection();
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đủ tên tài khoản và mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }
            cq.OpenConection();
            try
            {
                SqlCommand cm = new SqlCommand("Select * from Login where taikhoan = @id and matkhau =@password ", cq.GetCon());
                cm.Parameters.AddWithValue("@id", txtTaiKhoan.Text);
                cm.Parameters.AddWithValue("@password", txtMatKhau.Text);
                SqlDataAdapter adt = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                cq.CloseConnection();
                string us = txtTaiKhoan.Text;
                string pss = txtMatKhau.Text;
                string taikhoan = "";
                string matkhau = "";
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    taikhoan = row["taikhoan"].ToString().Trim();
                    matkhau = row["matkhau"].ToString().Trim();
                    quyen = int.Parse(row["phanquyen"].ToString());
                }
                int ok = string.Compare(us, taikhoan);
                int ok1 = string.Compare(pss, matkhau);
                //int ok = us.CompareTo(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                //int ok1 = pss.CompareTo(ds.Tables[0].Rows[0].ItemArray[1].ToString());
                if (ds.Tables[0].Rows.Count == 1 && ok == 0 && ok1 == 0)
                {
                    this.Hide();
                    frmMain fm = new frmMain();
                    fm.Show();
                }
                else
                {
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                    txtTaiKhoan.Focus();
                    MessageBox.Show("Bạn đã nhập sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }  
        }

        private void checkMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }
    }
}
