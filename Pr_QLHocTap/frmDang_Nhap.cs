using Pr_QLHocTap.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr_QLHocTap
{
    public partial class frmDang_Nhap : Form
    {
        public frmDang_Nhap()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDang_Nhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
        private void btn_Dangnhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaiKhoan.Text;
            string matkhau = txtMatkhau.Text;

            TaiKhoanDAO.Instance.getTaikhoan = taikhoan;

            if (taikhoan=="admin")
            {
                if (LoginAdmin(taikhoan, matkhau))
                {
                    //fmQuanlytaikhoan.getTenTaiKhoan = txtTaikhoan.Text;
                    frmMain f = new frmMain();
                    this.Hide();
                    txtMatkhau.Text = "";
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu !");
                }
                return;

            }
            else
            {

                if (LoginSinhvien(taikhoan, matkhau))
                {
                    //fmQuanlytaikhoan.getTenTaiKhoan = txtTaikhoan.Text;
                    frmMain f = new frmMain();
                    this.Hide();
                    txtMatkhau.Text = "";
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu !");
                }
                return;
            }
        }
        bool LoginSinhvien(string taikhoan, string matkhau)
        {
            return TaiKhoanDAO.Instance.LoginMember(taikhoan, matkhau);
        }
        bool LoginAdmin(string taikhoan, string matkhau)
        {
            return TaiKhoanDAO.Instance.LoginAdmin(taikhoan, matkhau);
        }

        private void frmDang_Nhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }
    }
}
