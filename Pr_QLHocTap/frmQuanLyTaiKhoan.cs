using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pr_QLHocTap.DAO;
namespace Pr_QLHocTap
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            string admin = TaiKhoanDAO.Instance.getTaikhoan;
            if (admin == "admin")
            {
                lblThongTinTK.Text = "Xin chào Admin";
                txtTaiKhoan.Text = TaiKhoanDAO.Instance.getTaikhoan;
            }
            else
            {
                txtTaiKhoan.Text = TaiKhoanDAO.Instance.getTaikhoan;
                lblThongTinTK.Text = "Xin chào  " + (string)TaiKhoanDAO.Instance.LoadHoTenTaiKhoan();
            }

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {

            string admin = TaiKhoanDAO.Instance.getTaikhoan;
            if (admin == "admin")
            {
                if (txtMatkhauCu.Text == TaiKhoanDAO.Instance.LoadMatKhauAdmin())
                {
                    string update = ("update TKadmin set MK='"+txtMatkhaumoi.Text.ToString().Trim()+"' where TK='"+admin+"'");
                    DataProvider.Instance.ExecuteQuery(update);
                    MessageBox.Show("Cập nhật mật khẩu mới thành công", "Thông báo", MessageBoxButtons.OK);
                    //txtMatkhauCu.Text = "";
                    //txtMatkhaumoi.Text = "";
                }
                else
                {
                    MessageBox.Show("Bạn phải nhập đúng mật khẩu cũ", "Thông báo", MessageBoxButtons.OK);
                }

            }
            else
            {

                if (txtMatkhauCu.Text == TaiKhoanDAO.Instance.LoadMatKhauSinhvien())
                {
                    string update = "update TaiKhoan set MK='"+ txtMatkhaumoi.Text.ToString().Trim() + "' where TK='"+TaiKhoanDAO.Instance.getTaikhoan+"'";
                    DataProvider.Instance.ExecuteQuery(update);
                    MessageBox.Show("Cập nhật mật khẩu mới thành công", "Thông báo", MessageBoxButtons.OK);
                    //txtMatkhauCu.Text = "";
                    //txtMatkhaumoi.Text = "";
                }
                else
                {
                    MessageBox.Show("Bạn phải nhập đúng mật khẩu cũ", "Thông báo", MessageBoxButtons.OK);
                }
            }

        }

    }
}
