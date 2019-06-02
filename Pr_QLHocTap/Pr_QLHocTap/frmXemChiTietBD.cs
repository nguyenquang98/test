using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Pr_QLHocTap.DAO;
namespace Pr_QLHocTap
{
    public partial class frmXemChiTietBD : Form
    {
        public frmXemChiTietBD()
        {
            InitializeComponent();
        }
        string strConn = @"" + DataProvider.Instance.connectionSTR + "";
        SqlConnection conn = null;
        private void OpenConnection()
        {
            //if (conn == null)
            //{
            conn = new SqlConnection(strConn);
            //if (conn.State == ConnectionState.Closed)
            conn.Open();
            //}
        }
        private void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void cbMaSVct_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTenSVct.Text = "";
            string masvct = cbMaSVct.SelectedItem.ToString();
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = "select HoTen from SinhVien where MaSV = @masvct";
                command.Parameters.Add("@masvct", SqlDbType.NVarChar).Value = masvct;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string s = reader.GetString(0);
                    cbTenSVct.SelectedText = s;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbTenSVct_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMaSVct.Text = "";
            string hoten = cbTenSVct.SelectedItem.ToString();
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = "select MaSV from SinhVien where HoTen = @hoten";
                command.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = hoten;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string s = reader.GetString(0);
                    cbMaSVct.SelectedText = s;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HienThiSinhVienLenChiTietBD()
        {
            string tentaikhoan = TaiKhoanDAO.Instance.getTaikhoan;
            if (tentaikhoan == "admin")
            {
                try
                {
                    OpenConnection();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    //command.CommandText = "Select * from SinhVien where masv=@masv and tensv=@tensv";
                    command.CommandText = "Select * from SinhVien";
                    command.Connection = conn;

                    SqlDataReader reader = command.ExecuteReader();

                    cbMaSVct.Items.Clear();
                    cbTenSVct.Items.Clear();

                    while (reader.Read())
                    {
                        string masvct = reader.GetString(0);
                        string tensvct = reader.GetString(1);

                        cbMaSVct.Items.Add(masvct);
                        cbTenSVct.Items.Add(tensvct);
                        //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                        //Vậy nên ở đây gán Tag=mã
                        //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                        cbMaSVct.Tag = masvct;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                CloseConnection();

            }
            else
            {
                try
                {
                    OpenConnection();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    //command.CommandText = "Select * from SinhVien where masv=@masv and tensv=@tensv";
                    command.CommandText = string.Format("Select * from SinhVien where MaSV='{0}'",tentaikhoan);
                    command.Connection = conn;

                    SqlDataReader reader = command.ExecuteReader();

                    cbMaSVct.Items.Clear();
                    cbTenSVct.Items.Clear();

                    while (reader.Read())
                    {
                        string masvct = reader.GetString(0);
                        string tensvct = reader.GetString(1);

                        cbMaSVct.Items.Add(masvct);
                        cbTenSVct.Items.Add(tensvct);
                        //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                        //Vậy nên ở đây gán Tag=mã
                        //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                        cbMaSVct.Tag = masvct;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                CloseConnection();
            }


           
        }

        private void frmXemChiTietBD_Load(object sender, EventArgs e)
        {
            HienThiSinhVienLenChiTietBD();
            string tentaikhoan = TaiKhoanDAO.Instance.getTaikhoan;
            if (tentaikhoan == "admin")
            {


            }
            else
            {
                cbMaSVct.Text= TaiKhoanDAO.Instance.getTaikhoan;
                cbTenSVct.Text = TaiKhoanDAO.Instance.LoadHoTenTaiKhoan();
            }

        }

        private void btnXemDiemCT_Click(object sender, EventArgs e)
        {
            string masv = cbMaSVct.Text.ToString().Trim();
            TaiKhoanDAO.Instance.getMasv = masv;
            string sql= String.Format("select hp.MaHP , hp.TenHP , hp.SoTC , hp.MaTQ ,CONVERT(decimal(10,2), bd.DiemCC) as DiemCC   , CONVERT(decimal(10,2), bd.DiemGK) as DiemGK , CONVERT(decimal(10,2), bd.DiemCK ) as DiemCK,CONVERT(decimal(10,2),  bd.DiemHe10) as DiemHe10 , CONVERT(decimal(10,2), bd.DiemHe4) as DiemHe4 , bd.DiemChu  from BangDiem as bd , SinhVien as sv , HocPhan as hp where sv.MaSV = bd.MaSV and hp.MaHP = bd.MaHP and sv.MaSV='{0}'", masv);

            dgvXemdiem.DataSource = DataProvider.Instance.ExecuteQuery(sql);
            dgvXemdiem.Show();

            //try
            //{
            //    string masv = cbMaSVct.Text.ToString().Trim();
            //    OpenConnection();
            //    SqlCommand command = new SqlCommand();
            //    command.CommandType = CommandType.Text;


            //    //command.CommandText = "select * from BangDiem where MaSV like @masvct";

            //    command.CommandText = String.Format("select hp.MaHP,hp.TenHP, hp.SoTC, hp.MaTQ, bd.DiemCC,bd.DiemGK, bd.DiemCK, bd.DiemHe10, bd.DiemHe4, bd.DiemChu  from BangDiem as bd, SinhVien as sv ,HocPhan as hp where sv.MaSV=bd.MaSV and hp.MaHP=bd.MaHP and sv.MaSV='{0}'", masv);
            //    //command.Parameters.Add("@masvct", SqlDbType.NVarChar).Value = "%" + cbMaSvChiTiet.Text + "%";
            //    //command.Parameters.Add("@masvct", SqlDbType.NVarChar).Value = cbMaSVct.Text;
            //    command.Connection = conn;
            //    SqlDataReader reader = command.ExecuteReader();

            //    lvBDChiTiet.Items.Clear();

            //    while (reader.Read())
            //    {
            //        //string idbd = reader.GetString(0);
            //        //string masv = reader.GetString(1);
            //        //string tensv = reader.GetString(2);
            //        string mahp = reader.GetString(0);
            //        string tenhp = reader.GetString(1);

            //        int sotc = reader.GetInt32(2);
            //        string matq = reader.GetString(3);

            //        float diemcc = reader.GetFloat(4);
            //        float diemgk = reader.GetFloat(5);
            //        float diemck = reader.GetFloat(6);
            //        float diemh10 = (float)double.Parse(reader.GetString(7));
            //        float diemh4 = (float)reader.GetDouble(8);
            //        string diemhc = reader.GetString(9);

            //        ListViewItem lvi = new ListViewItem((lvBDChiTiet.Items.Count + 1) + "");
            //        //ListViewItem lvi = new ListViewItem(id + "");
            //        //lvi.SubItems.Add(id + "");

            //        //lvi.SubItems.Add(idbd);
            //        //lvi.SubItems.Add(masv);
            //        //lvi.SubItems.Add(tensv);
            //        lvi.SubItems.Add(mahp);
            //        lvi.SubItems.Add(tenhp);

            //        lvi.SubItems.Add("");
            //        lvi.SubItems.Add("");

            //        lvi.SubItems.Add(diemcc + "");
            //        lvi.SubItems.Add(diemgk + "");
            //        lvi.SubItems.Add(diemck + "");
            //        lvi.SubItems.Add(diemh10 + "");
            //        lvi.SubItems.Add(diemh4 + "");
            //        lvi.SubItems.Add(diemhc);

            //        lvBDChiTiet.Items.Add(lvi);
            //    }
            //    reader.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}            
        }

        private void btnGoiY_Click(object sender, EventArgs e)
        {
            string maxsv= TaiKhoanDAO.Instance.getMasv;
            string sql = string.Format("select * from HocPhan where MaHP in(select hpch.MaHP from(select hp.MaHP, hp.MaTQ from HocPhan as hp where (hp.MaHP) not in (select hp.MaHP from SinhVien as sv, HocPhan as hp, BangDiem as bd where sv.MaSV = bd.MaSV and hp.MaHP=bd.MaHP and sv.MaSV='{0}')) as hpch ,(select hp.MaHP from SinhVien as sv, HocPhan as hp, BangDiem as bd where sv.MaSV = bd.MaSV and hp.MaHP=bd.MaHP and sv.MaSV='{1}' and bd.DiemChu not like 'F') as hpdh where hpch.MaTQ=hpdh.MaHP or hpch.MaTQ='' )", maxsv, maxsv);
            dgvXemdiem.DataSource = DataProvider.Instance.ExecuteQuery(sql);
            


            //try
            //{
            //    OpenConnection();
            //    SqlCommand command = new SqlCommand();
            //    command.CommandType = CommandType.Text;
            //    command.CommandText = "Select * from HocPhan";
            //    command.Connection = conn;

            //    SqlDataReader reader = command.ExecuteReader();

            //    grvXemdiem.ClearSelection();

            //    while (reader.Read())
            //    {
            //        //int id = reader.GetInt32(0);
            //        string ma = reader.GetString(0);
            //        //string ten = reader.GetString(1);
            //        //int sotc = reader.GetInt32(2);
            //        string matq = reader.GetString(3);

            //        //if (matq == ma)
            //        //{
            //            //for ()
            //            {
            //                DataGridView lvi = new DataGridView((grvXe) + "");
            //                //ListViewItem lvi = new ListViewItem(id + "");
            //                lvi.SubItems.Add(ma);
            //                //lvi.SubItems.Add(ten);
            //                //lvi.SubItems.Add(sotc + "");
            //                lvi.SubItems.Add("");
            //                lvi.SubItems.Add("");
            //                lvi.SubItems.Add(matq);

            //            grvXemdiem.Items.Add(lvi);
            //            }
            //        //}
            //    }
            //    reader.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //CloseConnection();
        }

        private void btnInCTBD_Click(object sender, EventArgs e)
        {
            frmInAnChiTietBD frm = new frmInAnChiTietBD();
            frm.Show();

        }

        private void btn_hp_chuahoc_Click(object sender, EventArgs e)
        {
            string maxsv = TaiKhoanDAO.Instance.getMasv;
            string sql = string.Format("select hp.* from HocPhan as hp where (hp.MaHP) not in (select hp.MaHP from SinhVien as sv, HocPhan as hp, BangDiem as bd where sv.MaSV = bd.MaSV and hp.MaHP = bd.MaHP and sv.MaSV = '{0}')", maxsv);
            //string sql = string.Format("select * from HocPhan where MaHP in(select hpch.MaHP from(select hp.MaHP, hp.MaTQ from HocPhan as hp where (hp.MaHP) not in (select hp.MaHP from SinhVien as sv, HocPhan as hp, BangDiem as bd where sv.MaSV = bd.MaSV and hp.MaHP=bd.MaHP and sv.MaSV='{0}')) as hpch ,(select hp.MaHP from SinhVien as sv, HocPhan as hp, BangDiem as bd where sv.MaSV = bd.MaSV and hp.MaHP=bd.MaHP and sv.MaSV='{1}') as hpdh where hpch.MaTQ=hpdh.MaHP )", maxsv, maxsv);
            dgvXemdiem.DataSource = DataProvider.Instance.ExecuteQuery(sql);
        }

        private void btn_hp_hoclai_Click(object sender, EventArgs e)
        {
            string maxsv = TaiKhoanDAO.Instance.getMasv;
            string sql = string.Format("select hp.MaHP , hp.TenHP , hp.SoTC , hp.MaTQ ,CONVERT(decimal(10,2),  bd.DiemCC) as DiemCC  ,CONVERT(decimal(10,2),  bd.DiemGK ) as DiemGK,CONVERT(decimal(10,2),  bd.DiemCK) as DiemCK ,CONVERT(decimal(10,2) ,  bd.DiemHe10) as DiemHe10 ,CONVERT(decimal(10,2),  bd.DiemHe4 ) as DiemHe4, bd.DiemChu from BangDiem as bd, HocPhan as hp  where  bd.MaHP=hp.MaHP   and bd.MaSV='{0}' and (bd.DiemChu like'F' or bd.DiemChu like'D' or bd.DiemChu like'D+') ", maxsv);
            //string sql = string.Format("select * from HocPhan where MaHP in(select hpch.MaHP from(select hp.MaHP, hp.MaTQ from HocPhan as hp where (hp.MaHP) not in (select hp.MaHP from SinhVien as sv, HocPhan as hp, BangDiem as bd where sv.MaSV = bd.MaSV and hp.MaHP=bd.MaHP and sv.MaSV='{0}')) as hpch ,(select hp.MaHP from SinhVien as sv, HocPhan as hp, BangDiem as bd where sv.MaSV = bd.MaSV and hp.MaHP=bd.MaHP and sv.MaSV='{1}') as hpdh where hpch.MaTQ=hpdh.MaHP )", maxsv, maxsv);
            dgvXemdiem.DataSource = DataProvider.Instance.ExecuteQuery(sql);
        }
    }
}
