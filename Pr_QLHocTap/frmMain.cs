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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        string strConn = DataProvider.Instance.connectionSTR;
        SqlConnection conn = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            string admin = TaiKhoanDAO.Instance.getTaikhoan;
            if (admin == "admin")
            {
                lbWelcome.Text = "Xin chào Admin !";
            }
            else
            {
                string tenTK = TaiKhoanDAO.Instance.LoadHoTenTaiKhoan();
                lbWelcome.Text = "Xin chào " + tenTK + ", chúc bạn có một ngày mới hoc tập hiệu quả !";
            }
            HienThiToanBoSinhVien();
            HienThiToanBoHocPhan();
            HienThiSinhVienLenBangDiem();
            HienThiHocPhanLenBangDiem();
            HienThiToanBoBangDiem();

            if (admin == "admin")
            {

            }
            else
            {
                btnTaoMoiHP.Hide();
                btnLuuHP.Hide(); 
                btnXoaHP.Hide();
                btnXoa.Hide();
                btnIn.Hide();
                btnTaoMoi.Hide();
                cbMaSV.Text = TaiKhoanDAO.Instance.getTaikhoan;
                cbTenSV.Text = TaiKhoanDAO.Instance.LoadHoTenTaiKhoan();
                txtDiemCC.ReadOnly = true;
                txtDiemGK.ReadOnly = true;
                txtDiemCK.ReadOnly = true;
            }

        }        

        private void HienThiToanBoBangDiem()
        {

            string tentaikhoan = TaiKhoanDAO.Instance.getTaikhoan;
            if (tentaikhoan == "admin")
            {
                try
                {
                    OpenConnection();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * from BangDiem";
                    command.Connection = conn;

                    SqlDataReader reader = command.ExecuteReader();

                    lvBangDiem.Items.Clear();

                    while (reader.Read())
                    {
                        string idbd = reader.GetString(0);
                        string masv = reader.GetString(1);
                        string tensv = reader.GetString(2);
                        string mahp = reader.GetString(3);
                        string tenhp = reader.GetString(4);

                        float diemcc = (float)reader.GetDouble(5);
                        float diemgk = (float)reader.GetDouble(6);
                        float diemck = (float)reader.GetDouble(7);
                        float diemh10 = (float)reader.GetDouble(8);
                        float diemh4 = (float)reader.GetDouble(9);
                        string diemhc = reader.GetString(10);

                        ListViewItem lvi = new ListViewItem((lvBangDiem.Items.Count + 1) + "");
                        //ListViewItem lvi = new ListViewItem(id + "");
                        //lvi.SubItems.Add(id + "");

                        lvi.SubItems.Add(idbd);
                        lvi.SubItems.Add(masv);
                        lvi.SubItems.Add(tensv);
                        lvi.SubItems.Add(mahp);
                        lvi.SubItems.Add(tenhp);
                        lvi.SubItems.Add(diemcc + "");
                        lvi.SubItems.Add(diemgk + "");
                        lvi.SubItems.Add(diemck + "");
                        lvi.SubItems.Add(diemh10 + "");
                        lvi.SubItems.Add(diemh4 + "");
                        lvi.SubItems.Add(diemhc);

                        lvBangDiem.Items.Add(lvi);

                        //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                        //Vậy nên ở đây gán Tag=mã
                        //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                        lvi.Tag = idbd;
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
                    command.CommandText = "Select * from BangDiem";
                    command.CommandText = string.Format("select * from BangDiem where MaSV='{0}'",tentaikhoan);
                    command.Connection = conn;

                    SqlDataReader reader = command.ExecuteReader();

                    lvBangDiem.Items.Clear();

                    while (reader.Read())
                    {
                        string idbd = reader.GetString(0);
                        string masv = reader.GetString(1);
                        string tensv = reader.GetString(2);
                        string mahp = reader.GetString(3);
                        string tenhp = reader.GetString(4);

                        float diemcc = (float)reader.GetDouble(5);
                        float diemgk = (float)reader.GetDouble(6);
                        float diemck = (float)reader.GetDouble(7);
                        float diemh10 = (float)reader.GetDouble(8);
                        float diemh4 = (float)reader.GetDouble(9);
                        string diemhc = reader.GetString(10);

                        ListViewItem lvi = new ListViewItem((lvBangDiem.Items.Count + 1) + "");
                        //ListViewItem lvi = new ListViewItem(id + "");
                        //lvi.SubItems.Add(id + "");

                        lvi.SubItems.Add(idbd);
                        lvi.SubItems.Add(masv);
                        lvi.SubItems.Add(tensv);
                        lvi.SubItems.Add(mahp);
                        lvi.SubItems.Add(tenhp);
                        lvi.SubItems.Add(diemcc + "");
                        lvi.SubItems.Add(diemgk + "");
                        lvi.SubItems.Add(diemck + "");
                        lvi.SubItems.Add(diemh10 + "");
                        lvi.SubItems.Add(diemh4 + "");
                        lvi.SubItems.Add(diemhc);

                        lvBangDiem.Items.Add(lvi);

                        //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                        //Vậy nên ở đây gán Tag=mã
                        //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                        lvi.Tag = idbd;
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

        private void HienThiHocPhanLenBangDiem()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;                
                command.CommandText = "Select * from HocPhan";
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                cbMaHP.Items.Clear();
                cbTenHP.Items.Clear();

                while (reader.Read())
                {
                    string mahp = reader.GetString(0);
                    string tenhp = reader.GetString(1);

                    cbMaHP.Items.Add(mahp);
                    cbTenHP.Items.Add(tenhp);

                    //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                    //Vậy nên ở đây gán Tag=mã
                    //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                    cbMaHP.Tag = mahp;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConnection();
        }

        private void HienThiSinhVienLenBangDiem()
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

                    cbMaSV.Items.Clear();
                    cbTenSV.Items.Clear();

                    while (reader.Read())
                    {
                        string masv = reader.GetString(0);
                        string tensv = reader.GetString(1);

                        cbMaSV.Items.Add(masv);
                        cbTenSV.Items.Add(tensv);



                        //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                        //Vậy nên ở đây gán Tag=mã
                        //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                        cbMaSV.Tag = masv;
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

                    cbMaSV.Items.Clear();
                    cbTenSV.Items.Clear();

                    while (reader.Read())
                    {
                        string masv = reader.GetString(0);
                        string tensv = reader.GetString(1);

                        cbMaSV.Items.Add(masv);
                        cbTenSV.Items.Add(tensv);



                        //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                        //Vậy nên ở đây gán Tag=mã
                        //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                        cbMaSV.Tag = masv;
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

        private void HienThiToanBoHocPhan()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from HocPhan";
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                lvHocPhan.Items.Clear();
                
                while (reader.Read())
                {
                    //int id = reader.GetInt32(0);
                    string ma = reader.GetString(0);
                    string ten = reader.GetString(1);
                    int sotc = reader.GetInt32(2);
                    string matq = reader.GetString(3);
                    ListViewItem lvi = new ListViewItem((lvHocPhan.Items.Count + 1) + "");
                    //ListViewItem lvi = new ListViewItem(id + "");
                    lvi.SubItems.Add(ma);
                    lvi.SubItems.Add(ten);
                    lvi.SubItems.Add(sotc+"");
                    lvi.SubItems.Add(matq);                    

                    lvHocPhan.Items.Add(lvi);
                    
                    //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                    //Vậy nên ở đây gán Tag=mã
                    //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                    lvi.Tag = ma;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConnection();
        }

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
        private void HienThiToanBoSinhVien()
        {

            string tentaikhoan = TaiKhoanDAO.Instance.getTaikhoan;
            if (tentaikhoan == "admin")
            {
                try
                {
                    OpenConnection();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * from SinhVien";
                    command.Connection = conn;

                    SqlDataReader reader = command.ExecuteReader();

                    lvSinhVien.Items.Clear();

                    while (reader.Read())
                    {
                        string ma = reader.GetString(0);
                        string ten = reader.GetString(1);
                        int gioitinh = reader.GetInt32(2);
                        string ngaysinh = reader.GetString(3);
                        string phone = reader.GetString(4);
                        string quequan = reader.GetString(5);
                        ListViewItem lvi = new ListViewItem((lvSinhVien.Items.Count + 1) + "");
                        lvi.SubItems.Add(ma + "");
                        lvi.SubItems.Add(ten);
                        lvi.SubItems.Add(gioitinh == 0 ? "Nam" : "Nữ");
                        lvi.SubItems.Add(ngaysinh);
                        lvi.SubItems.Add(phone);
                        lvi.SubItems.Add(quequan);

                        lvSinhVien.Items.Add(lvi);

                        if (gioitinh == 0)
                            lvi.ImageIndex = 0;
                        else if (gioitinh == 1)
                            lvi.ImageIndex = 1;

                        //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                        //Vậy nên ở đây gán Tag=mã
                        //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                        lvi.Tag = ma;
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
                    //command.CommandText = "Select * from SinhVien where MaSV=@tentaikhoan";
                    command.CommandText = string.Format("Select * from SinhVien where MaSV='{0}'",tentaikhoan);
                    command.Connection = conn;

                    SqlDataReader reader = command.ExecuteReader();

                    lvSinhVien.Items.Clear();

                    while (reader.Read())
                    {
                        string ma = reader.GetString(0);
                        string ten = reader.GetString(1);
                        int gioitinh = reader.GetInt32(2);
                        string ngaysinh = reader.GetString(3);
                        string phone = reader.GetString(4);
                        string quequan = reader.GetString(5);
                        ListViewItem lvi = new ListViewItem((lvSinhVien.Items.Count + 1) + "");
                        lvi.SubItems.Add(ma + "");
                        lvi.SubItems.Add(ten);
                        lvi.SubItems.Add(gioitinh == 0 ? "Nam" : "Nữ");
                        lvi.SubItems.Add(ngaysinh);
                        lvi.SubItems.Add(phone);
                        lvi.SubItems.Add(quequan);

                        lvSinhVien.Items.Add(lvi);

                        if (gioitinh == 0)
                            lvi.ImageIndex = 0;
                        else if (gioitinh == 1)
                            lvi.ImageIndex = 1;

                        //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                        //Vậy nên ở đây gán Tag=mã
                        //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                        lvi.Tag = ma;
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

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvSinhVien.SelectedItems[0];
            //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
            string ma = (string)lvi.Tag;
            HienThiChiTiet(ma);
        }

        private void HienThiChiTiet(string ma)
        {
           
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from SinhVien where MaSV=@ma";
                command.Connection = conn;
                SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
                parMa.Value = ma;
                command.Parameters.Add(parMa);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string ten = reader.GetString(1);
                    int gioitinh = reader.GetInt32(2);
                    string ngaysinh = reader.GetString(3);
                    string phone = reader.GetString(4);
                    string quequan = reader.GetString(5);

                    txtMaSV.Text = ma + "";
                    txtTenSV.Text = ten;
                    if (gioitinh == 0)
                        radNam.Checked = true;
                    else
                        radNu.Checked = true;
                    dtpNgaySinh.Text = ngaysinh;
                    txtSDT.Text = phone;
                    txtQueQuan.Text = quequan;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Today;
            txtSDT.Text = "";
            txtQueQuan.Text = "";
            txtTimKiem.Text = "Nhập tên cần tìm";
            txtMaSV.Focus();
            HienThiToanBoSinhVien();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaSV.Text;
                if (KiemTraTonTai(ma) == true)
                {                   
                        //tiến hành cập nhật
                        CapNhatSinhVien(ma);                    
                }
                else
                {
                    //tiến hành thêm mới
                    string tentaikhoan = TaiKhoanDAO.Instance.getTaikhoan;
                    if (tentaikhoan == "admin")
                    {
                        if (txtMaSV.Text != "")
                        {
                            ThemMoiSinhVien();
                        }
                        else
                        {
                            MessageBox.Show("Bạn cần phải nhập thông tin cần thiết!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn không có quyền thêm mới sinh viên !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn cần phải nhập thông tin cần thiết" + "--" + ex.Message, "Ồ!");
            }
            HienThiSinhVienLenBangDiem();
        }
        private void ThemMoiSinhVien()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "insert into SinhVien values(@ma,@ten,@gt,@ngaysinh,@phone,@quequan)  insert into TaiKhoan (MaSV,TK,MK) values (@ma,@ma,@ma)";
                command.CommandText = sql;
                command.Connection = conn;

                command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = txtMaSV.Text;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtTenSV.Text;
                if (radNam.Checked == true)
                    command.Parameters.Add("@gt", SqlDbType.Int).Value = 0;
                else
                    command.Parameters.Add("@gt", SqlDbType.Int).Value = 1;
                command.Parameters.Add("@ngaysinh", SqlDbType.NVarChar).Value = dtpNgaySinh.Text;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = txtSDT.Text;
                command.Parameters.Add("@quequan", SqlDbType.NVarChar).Value = txtQueQuan.Text;

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoSinhVien();
                    MessageBox.Show("Lưu thông tin thành công");
                    btnTaoMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void CapNhatSinhVien(string ma)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "Update SinhVien set HoTen=@ten,GioiTinh=@gt,NgaySinh=@ngaysinh,SDT=@phone,QueQuan=@quequan where MaSV=@ma";
                command.CommandText = sql;
                command.Connection = conn;

                command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = txtMaSV.Text;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtTenSV.Text;
                command.Parameters.Add("@gt", SqlDbType.Int).Value = radNam.Checked ? 0 : 1;
                command.Parameters.Add("@ngaysinh", SqlDbType.NVarChar).Value = dtpNgaySinh.Text;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = txtSDT.Text;
                command.Parameters.Add("@quequan", SqlDbType.NVarChar).Value = txtQueQuan.Text;

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoSinhVien();
                    MessageBox.Show("Lưu thông tin thành công");
                    btnTaoMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private bool KiemTraTonTai(string ma)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from SinhVien where MaSV=@ma";
                command.Connection = conn;
                SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
                parMa.Value = ma;
                command.Parameters.Add(parMa);

                SqlDataReader reader = command.ExecuteReader();
                bool kq = reader.Read();
                reader.Close();
                return kq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sinh viên để có thể xóa");
                return;
            }
            ListViewItem lvi = lvSinhVien.SelectedItems[0];
            string ma = (string)lvi.Tag;
            //string ma = TaiKhoanDAO.Instance.getMasv;
            DialogResult ret = MessageBox.Show("Bạn có chắc muốn xóa ko", "Xác nhận:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                ThucHienXoa(ma);
            }
            HienThiSinhVienLenBangDiem();
            HienThiToanBoBangDiem();
        }

        private void ThucHienXoa(string ma)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "delete BangDiem where MaSV=@ma delete TaiKhoan where MaSV=@ma  delete from SinhVien where MaSV=@ma";
                command.Connection = conn;
                command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoSinhVien();
                    MessageBox.Show("Xóa thông tin thành công");
                    btnTaoMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show("Xóa thông tin thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = "select * from SinhVien where HoTen like @ten";
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = "%" + txtTimKiem.Text + "%";

                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                lvSinhVien.Items.Clear();
                
                while (reader.Read())
                {
                    string ma = reader.GetString(0);
                    string ten = reader.GetString(1);
                    int gioitinh = reader.GetInt32(2);
                    string ngaysinh = reader.GetString(3);
                    string phone = reader.GetString(4);
                    string quequan = reader.GetString(5);
                    ListViewItem lvi = new ListViewItem((lvSinhVien.Items.Count + 1) + "");
                    lvi.SubItems.Add(ma + "");
                    lvi.SubItems.Add(ten);
                    lvi.SubItems.Add(gioitinh == 0 ? "Nam" : "Nữ");
                    lvi.SubItems.Add(ngaysinh);
                    lvi.SubItems.Add(phone);
                    lvi.SubItems.Add(quequan);

                    lvSinhVien.Items.Add(lvi);
                    
                    if (gioitinh == 0)
                        lvi.ImageIndex = 0;
                    else if (gioitinh == 1)
                        lvi.ImageIndex = 1;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInAn frm = new frmInAn();
            frm.Show();
        }
        //-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------
        private void lvHocPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHocPhan.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvHocPhan.SelectedItems[0];
            //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
            string ma = (string)lvi.Tag;
            HienThiChiTietHocPhan(ma);
        }

        private void HienThiChiTietHocPhan(string ma)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from HocPhan where MaHP=@ma";
                command.Connection = conn;
                SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
                parMa.Value = ma;
                command.Parameters.Add(parMa);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    //int id = reader.GetInt32(0);
                    string mahp = reader.GetString(0);
                    string ten = reader.GetString(1);
                    int sotc = reader.GetInt32(2);
                    string matq = reader.GetString(3);

                    //txtID.Text = id + "";
                    txtMaHP.Text = mahp;
                    txtTenHP.Text = ten;
                    txtSoTC.Text = sotc + "";
                    txtMaHPTQ.Text = matq;
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTaoMoiHP_Click(object sender, EventArgs e)
        {
            //txtID.Text = "";
            txtMaHP.Text = "";
            txtTenHP.Text = "";
            txtSoTC.Text = "";
            txtMaHPTQ.Text = "";

            txtTimKiemHP.Text = "Nhập tên cần tìm";
            txtMaHP.Focus();
            HienThiToanBoHocPhan();
        }

        private void btnLuuHP_Click(object sender, EventArgs e)
        {
            try
            {
                string mahp = txtMaHP.Text;
                if (KiemTraTonTaiHP(mahp) == true)
                {
                    //tiến hành cập nhật
                    CapNhatHocPhan(mahp);
                }
                else
                {
                    //tiến hành thêm mới
                    ThemMoiHocPhan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn cần phải nhập thông tin cần thiết" + "--" + ex.Message, "Ồ!");
            }
            HienThiHocPhanLenBangDiem();
        }

        private void ThemMoiHocPhan()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "insert into HocPhan values(@mahp,@tenhp,@sotc,@matq)";
                command.CommandText = sql;
                command.Connection = conn;

                //command.Parameters.Add("@id", SqlDbType.Int).Value = txtID.Text;
                command.Parameters.Add("@mahp", SqlDbType.NVarChar).Value = txtMaHP.Text;
                command.Parameters.Add("@TenHP", SqlDbType.NVarChar).Value = txtTenHP.Text;
                command.Parameters.Add("@sotc", SqlDbType.Int).Value = txtSoTC.Text+"";
                command.Parameters.Add("@matq", SqlDbType.NVarChar).Value = txtMaHPTQ.Text;

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoHocPhan();
                    MessageBox.Show("Lưu thông tin thành công");
                    btnTaoMoiHP.PerformClick();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn cần phải nhập thông tin cần thiết" + "--" + ex.Message, "Ồ!");
            }
        }

        private void CapNhatHocPhan(string mahp)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "Update HocPhan set MaHP=@mahp,TenHP=@tenhp,SoTC=@sotc,MaTQ=@matq where MaHP=@mahp";
                command.CommandText = sql;
                command.Connection = conn;

                //command.Parameters.Add("@id", SqlDbType.Int).Value = txtID.Text;
                command.Parameters.Add("@mahp", SqlDbType.NVarChar).Value = txtMaHP.Text;
                command.Parameters.Add("@TenHP", SqlDbType.NVarChar).Value = txtTenHP.Text;
                command.Parameters.Add("@sotc", SqlDbType.Int).Value = txtSoTC.Text+"";
                command.Parameters.Add("@matq", SqlDbType.NVarChar).Value = txtMaHPTQ.Text;

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoHocPhan();
                    MessageBox.Show("Lưu thông tin thành công");
                    btnTaoMoiHP.PerformClick();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn cần phải nhập thông tin cần thiết" + "--" + ex.Message, "Ồ!");
            }
        }

        private bool KiemTraTonTaiHP(string mahp)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from HocPhan where MaHP=@mahp";
                command.Connection = conn;
                SqlParameter parMa = new SqlParameter("@mahp", SqlDbType.NVarChar);
                parMa.Value = mahp;
                command.Parameters.Add(parMa);

                SqlDataReader reader = command.ExecuteReader();
                bool kq = reader.Read();
                reader.Close();
                return kq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void btnXoaHP_Click(object sender, EventArgs e)
        {
            if (lvHocPhan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn học phần để có thể xóa");
                return;
            }
            ListViewItem lvi = lvHocPhan.SelectedItems[0];
            string mahp = (string)lvi.Tag;
            DialogResult ret = MessageBox.Show("Bạn có chắc muốn xóa ko", "Xác nhận:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                ThucHienXoaHP(mahp);
            }
            HienThiHocPhanLenBangDiem();
        }

        private void ThucHienXoaHP(string mahp)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from HocPhan where MaHP=@mahp";
                command.Connection = conn;
                command.Parameters.Add("@mahp", SqlDbType.NVarChar).Value = mahp;

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoHocPhan();
                    MessageBox.Show("Xóa thông tin thành công");
                    btnTaoMoiHP.PerformClick();
                }
                else
                {
                    MessageBox.Show("Xóa thông tin thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiemHP_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKiemHP.Text = "";
        }

        private void btnTimKiemHP_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = "select * from HocPhan where TenHP like @tenhp";
                command.Parameters.Add("@tenhp", SqlDbType.NVarChar).Value = "%" + txtTimKiemHP.Text + "%";

                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                lvHocPhan.Items.Clear();
                
                while (reader.Read())
                {
                    //int id = reader.GetInt32(0);
                    string ma = reader.GetString(0);
                    string ten = reader.GetString(1);
                    int sotc = reader.GetInt32(2);
                    string matq = reader.GetString(3);
                    ListViewItem lvi = new ListViewItem((lvHocPhan.Items.Count + 1) + "");
                    //ListViewItem lvi = new ListViewItem(id + "");
                    lvi.SubItems.Add(ma);
                    lvi.SubItems.Add(ten);
                    lvi.SubItems.Add(sotc + "");
                    lvi.SubItems.Add(matq);

                    lvHocPhan.Items.Add(lvi);
                   
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInHP_Click(object sender, EventArgs e)
        {
            frmInAnHP frmhp = new frmInAnHP();
            frmhp.Show();
        }
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        
        private void cbMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTenSV.Text = "";
            string masv = cbMaSV.SelectedItem.ToString();
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;                
                
                command.CommandText = "select HoTen from SinhVien where MaSV = @masv";
                command.Parameters.Add("@masv", SqlDbType.NVarChar).Value = masv;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                { 
                    string s = reader.GetString(0);
                    cbTenSV.SelectedText = s;
                }                
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbTenSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMaSV.Text = "";
            string hoten = cbTenSV.SelectedItem.ToString();
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
                    cbMaSV.SelectedText = s;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void cbMaHP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTenHP.Text = "";
            string mahp = cbMaHP.SelectedItem.ToString();
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = "select TenHP from HocPhan where MaHP = @mahp";
                command.Parameters.Add("@mahp", SqlDbType.NVarChar).Value = mahp;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string s = reader.GetString(0);
                    cbTenHP.SelectedText = s;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbTenHP_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMaHP.Text = "";
            string tenhp = cbTenHP.SelectedItem.ToString();
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = "select MaHP from HocPHan where tenhp = @tenhp";
                command.Parameters.Add("@tenhp", SqlDbType.NVarChar).Value = tenhp;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string s = reader.GetString(0);
                    cbMaHP.SelectedText = s;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnTaoMoiBD_Click(object sender, EventArgs e)
        {
           


            string tentaikhoan = TaiKhoanDAO.Instance.getTaikhoan;
            if (tentaikhoan == "admin")
            {

                txtIdBD.Text = "";
                cbMaSV.Text = "";
                cbTenSV.Text = "";
                cbTenHP.Text = "";
                cbMaHP.Text = "";
                txtDiemCC.Text = "";
                txtDiemGK.Text = "";
                txtDiemCK.Text = "";
                txtDiemHe10.Text = "";
                txtDiemHe4.Text = "";
                txtDiemHeChu.Text = "";
                txtTimKiemBD.Text = "Nhập tên cần tìm";
                txtDiemCC.Focus();
                HienThiToanBoBangDiem();
                HienThiSinhVienLenBangDiem();
            }
            else
            {
                txtIdBD.Text = "";
                //cbMaSV.Text = "";
                //cbTenSV.Text = "";
                cbTenHP.Text = "";
                cbMaHP.Text = "";
                txtDiemCC.Text = "";
                txtDiemGK.Text = "";
                txtDiemCK.Text = "";
                txtDiemHe10.Text = "";
                txtDiemHe4.Text = "";
                txtDiemHeChu.Text = "";
                txtTimKiemBD.Text = "Nhập tên cần tìm";
                txtDiemCC.Focus();
                HienThiToanBoBangDiem();
                HienThiSinhVienLenBangDiem();

            }





        }

        private void btnLuuBD_Click(object sender, EventArgs e)
        {
            try
            {
                //int id = int.Parse(txtIdBD.Text);
                string id = txtIdBD.Text;
                string masv = cbMaSV.Text;
                string mahp = cbMaHP.Text;
                if (KiemTraTonTaiBD(masv) == true && KiemTraTonTaiBD2(mahp)==true)
                {
                    //tiến hành cập nhật
                    CapNhatBangDiem(id);
                }
                else
                {
                    //tiến hành thêm mới
                    ThemMoiBangDiem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn cần phải nhập thông tin cần thiết" + "--" + ex.Message, "Ồ!");
            }
        }

        private bool KiemTraTonTaiBD2(string mahp)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from BangDiem where MaHP=@mahp";
                command.Connection = conn;
                //SqlParameter parid = new SqlParameter("@id", SqlDbType.NVarChar);
                //parid.Value = id;
                command.Parameters.Add("@mahp", SqlDbType.NVarChar).Value = cbMaHP.Text;
                SqlDataReader reader = command.ExecuteReader();
                //bool kq = reader.Read();
                //reader.Close();
                //return kq;     
                if (reader.HasRows == true) return true;
            }
            //catch (MissingFieldException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //catch (FormatException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            catch (Exception ex)
            {
                MessageBox.Show("Thím bị lỗi rồi --- " + ex.Message);
            }
            return false;
        }

        public void ChuyenDoiDiem()
        {
            float diemchuyencan = float.Parse(txtDiemCC.Text.ToString().Trim());
            float diemgiuaki = float.Parse(txtDiemGK.Text.ToString().Trim());
            float diemcuoiki = float.Parse(txtDiemCK.Text.ToString().Trim());

            float diemhe10;
            float diemhe4;
            string diemchu;
            string xeploai;
            diemhe10 = (float)(0.1 * diemchuyencan + 0.2 * diemgiuaki + 0.7 * diemcuoiki);
            diemhe4 = (float)((diemhe10 / 10) * 4);

            if (diemhe10 >= 9.0 && diemhe10 <= 10)
            {
                diemchu = "A+";
                xeploai = "Giỏi";
                txtDiemHe10.Text = diemhe10.ToString();
                txtDiemHe4.Text = diemhe4.ToString();
                txtDiemHeChu.Text = diemchu;
            }
            else if (diemhe10 >= 8.5 && diemhe10 <= 8.9)
            {
                diemchu = "A";
                xeploai = "Giỏi";
                txtDiemHe10.Text = diemhe10.ToString();
                txtDiemHe4.Text = diemhe4.ToString();
                txtDiemHeChu.Text = diemchu;
            }
            else if (diemhe10 >= 7.8 && diemhe10 <= 8.4)
            {
                diemchu = "B+";
                xeploai = "Khá";
                txtDiemHe10.Text = diemhe10.ToString();
                txtDiemHe4.Text = diemhe4.ToString();
                txtDiemHeChu.Text = diemchu;
            }
            else if (diemhe10 >= 7.0 && diemhe10 <= 7.7)
            {
                diemchu = "B";
                xeploai = "Khá";
                txtDiemHe10.Text = diemhe10.ToString();
                txtDiemHe4.Text = diemhe4.ToString();
                txtDiemHeChu.Text = diemchu;
            }
            else if (diemhe10 >= 6.3 && diemhe10 <= 6.9)
            {
                diemchu = "C+";
                xeploai = "Trung bình";
                txtDiemHe10.Text = diemhe10.ToString();
                txtDiemHe4.Text = diemhe4.ToString();
                txtDiemHeChu.Text = diemchu;
            }
            else if (diemhe10 >= 5.5 && diemhe10 <= 6.2)
            {
                diemchu = "C";
                xeploai = "Trung bình";
                txtDiemHe10.Text = diemhe10.ToString();
                txtDiemHe4.Text = diemhe4.ToString();
                txtDiemHeChu.Text = diemchu;
            }
            else if (diemhe10 >= 4.8 && diemhe10 <= 5.4)
            {
                diemchu = "D+";
                xeploai = "Trung bình yếu";
                txtDiemHe10.Text = diemhe10.ToString();
                txtDiemHe4.Text = diemhe4.ToString();
                txtDiemHeChu.Text = diemchu;
            }
            else if (diemhe10 >= 4.0 && diemhe10 <= 4.7)
            {
                diemchu = "D";
                xeploai = "Trung bình yếu";
                txtDiemHe10.Text = diemhe10.ToString();
                txtDiemHe4.Text = diemhe4.ToString();
                txtDiemHeChu.Text = diemchu;
            }
            else if (diemhe10 >= 0 && diemhe10 <= 4.0)
            {
                diemchu = "F";
                xeploai = "Kém";
                txtDiemHe10.Text = diemhe10.ToString();
                txtDiemHe4.Text = diemhe4.ToString();
                txtDiemHeChu.Text = diemchu;
            }
        }
        
        private void ThemMoiBangDiem()
        {
            try
            {
                float diemchuyencan = float.Parse(txtDiemCC.Text.ToString().Trim());
                float diemgiuaki = float.Parse(txtDiemGK.Text.ToString().Trim());
                float diemcuoiki = float.Parse(txtDiemCK.Text.ToString().Trim());

                float diemhe10;
                float diemhe4;
                string diemchu;
                string xeploai;

                diemhe10 = (float)(0.1 * diemchuyencan + 0.2 * diemgiuaki + 0.7 * diemcuoiki);
                diemhe4 = (float)((diemhe10 / 10) * 4);

                if (diemhe10 >= 9.0 && diemhe10 <= 10)
                {
                    diemchu = "A+";
                    xeploai = "Giỏi";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 8.5 && diemhe10 <= 8.9)
                {
                    diemchu = "A";
                    xeploai = "Giỏi";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 7.8 && diemhe10 <= 8.4)
                {
                    diemchu = "B+";
                    xeploai = "Khá";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 7.0 && diemhe10 <= 7.7)
                {
                    diemchu = "B";
                    xeploai = "Khá";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 6.3 && diemhe10 <= 6.9)
                {
                    diemchu = "C+";
                    xeploai = "Trung bình";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 5.5 && diemhe10 <= 6.2)
                {
                    diemchu = "C";
                    xeploai = "Trung bình";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 4.8 && diemhe10 <= 5.4)
                {
                    diemchu = "D+";
                    xeploai = "Trung bình yếu";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 4.0 && diemhe10 <= 4.7)
                {
                    diemchu = "D";
                    xeploai = "Trung bình yếu";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 0 && diemhe10 <= 4.0)
                {
                    diemchu = "F";
                    xeploai = "Kém";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                /*
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "insert into BangDiem values(@DiemCC,@DiemGK,@DiemCK,@DiemHe10,@DiemHe4,@DiemChu)";
                command.CommandText = sql;
                command.Connection = conn;

                //command.Parameters.Add("@id", SqlDbType.NVarChar).Value = txtIdBD.Text;
                //command.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = cbMaSV.Text;
                //command.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = cbTenSV.Text;
                //command.Parameters.Add("@MaHP", SqlDbType.NVarChar).Value = cbMaHP.Text;
                //command.Parameters.Add("@TenHP", SqlDbType.NVarChar).Value = cbTenHP.Text;

                command.Parameters.Add("@DiemCC", SqlDbType.Float).Value = float.Parse(txtDiemCC.Text);
                command.Parameters.Add("@DiemGK", SqlDbType.Float).Value = float.Parse(txtDiemGK.Text);
                command.Parameters.Add("@DiemCK", SqlDbType.Float).Value = float.Parse(txtDiemCK.Text);

                command.Parameters.Add("@DiemHe10", SqlDbType.Float).Value = diemhe10;
                command.Parameters.Add("@DiemHe4", SqlDbType.Float).Value = diemhe4;
                command.Parameters.Add("@DiemChu", SqlDbType.NVarChar).Value = txtDiemHeChu.Text;

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoBangDiem();
                    MessageBox.Show("Lưu thông tin thành công");
                    btnTaoMoiBD.PerformClick();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại");
                }
                */

                using (SqlConnection newconn = new SqlConnection(strConn))
                {
                    //string sql = "Update BangDiem set DiemCC=@DiemCC,DiemGK=@DiemGK,DiemCK=@DiemCK,DiemHe10=@DiemHe10,DiemHe4=@DiemHe4,DiemChu=@DiemChu where ID=" + txtIdBD.Text;
                    string sql = "insert into BangDiem values(@ID,@MaSV,@HoTen,@MaHP,@TenHP,@DiemCC,@DiemGK,@DiemCK,@DiemHe10,@DiemHe4,@DiemChu)";
                    SqlCommand command = new SqlCommand(sql, newconn);
                    command.Parameters.Add("@ID", SqlDbType.NVarChar);

                    Random rd = new Random();
                    int iidd = rd.Next(1000,90000000);
                    string getid = iidd.ToString();

                    command.Parameters["@ID"].Value = getid;

                    command.Parameters.Add("@MaSV", SqlDbType.NVarChar);
                    command.Parameters["@MaSV"].Value = cbMaSV.Text;
                    command.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                    command.Parameters["@HoTen"].Value = cbTenSV.Text;
                    command.Parameters.Add("@MaHP", SqlDbType.NVarChar);
                    command.Parameters["@MaHP"].Value = cbMaHP.Text;
                    command.Parameters.Add("@TenHP", SqlDbType.NVarChar);
                    command.Parameters["@TenHP"].Value = cbTenHP.Text;

                    command.Parameters.Add("@DiemCC", SqlDbType.Float);
                    command.Parameters["@DiemCC"].Value = float.Parse(txtDiemCC.Text);
                    command.Parameters.Add("@DiemGK", SqlDbType.Float);
                    command.Parameters["@DiemGK"].Value = float.Parse(txtDiemGK.Text);
                    command.Parameters.Add("@DiemCK", SqlDbType.Float);
                    command.Parameters["@DiemCK"].Value = float.Parse(txtDiemCK.Text);
                    command.Parameters.Add("@DiemHe10", SqlDbType.Float);
                    command.Parameters["@DiemHe10"].Value = diemhe10;
                    command.Parameters.Add("@DiemHe4", SqlDbType.Float);
                    command.Parameters["@DiemHe4"].Value = diemhe4;
                    command.Parameters.Add("@DiemChu", SqlDbType.NVarChar);
                    command.Parameters["@DiemChu"].Value = txtDiemHeChu.Text;
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                    //int kq = command.ExecuteNonQuery();
                    //if (kq > 0)
                    //{
                    HienThiToanBoBangDiem();
                        MessageBox.Show("Lưu thông tin thành công");
                        btnTaoMoiBD.PerformClick();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Lưu thông tin thất bại");
                    //}
                }
            }
            //catch (MissingFieldException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //catch (FormatException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            catch (Exception ex)
            {
                MessageBox.Show("Bạn cần nhập thông tin cần thiết --- " + ex.Message);
            }
        }

        private void CapNhatBangDiem(string id)
        {
            try
            {
                float diemchuyencan = float.Parse(txtDiemCC.Text.ToString().Trim());
                float diemgiuaki = float.Parse(txtDiemGK.Text.ToString().Trim());
                float diemcuoiki = float.Parse(txtDiemCK.Text.ToString().Trim());

                float diemhe10;
                float diemhe4;
                string diemchu="";
                string xeploai;

                diemhe10 = (float)(0.1 * diemchuyencan + 0.2 * diemgiuaki + 0.7 * diemcuoiki);
                diemhe4 = (float)((diemhe10 / 10) * 4);

                if (diemhe10 >= 9.0 && diemhe10 <= 10)
                {
                    diemchu = "A+";
                    xeploai = "Giỏi";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 8.5 && diemhe10 <= 8.9)
                {
                    diemchu = "A";
                    xeploai = "Giỏi";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 7.8 && diemhe10 <= 8.4)
                {
                    diemchu = "B+";
                    xeploai = "Khá";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 7.0 && diemhe10 <= 7.7)
                {
                    diemchu = "B";
                    xeploai = "Khá";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 6.3 && diemhe10 <= 6.9)
                {
                    diemchu = "C+";
                    xeploai = "Trung bình";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 5.5 && diemhe10 <= 6.2)
                {
                    diemchu = "C";
                    xeploai = "Trung bình";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 4.8 && diemhe10 <= 5.4)
                {
                    diemchu = "D+";
                    xeploai = "Trung bình yếu";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 4.0 && diemhe10 <= 4.7)
                {
                    diemchu = "D";
                    xeploai = "Trung bình yếu";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }
                else if (diemhe10 >= 0 && diemhe10 <= 4.0)
                {
                    diemchu = "F";
                    xeploai = "Kém";
                    txtDiemHe10.Text = diemhe10.ToString();
                    txtDiemHe4.Text = diemhe4.ToString();
                    txtDiemHeChu.Text = diemchu;
                }

                /*
                using(SqlConnection newconn = new SqlConnection(strConn)) {
                    string sql = "Update BangDiem set DiemCC=@DiemCC,DiemGK=@DiemGK,DiemCK=@DiemCK,DiemHe10=@DiemHe10,DiemHe4=@DiemHe4,DiemChu=@DiemChu where ID="+txtIdBD.Text;
                    SqlCommand command = new SqlCommand(sql,newconn);
                    command.Parameters.Add("@DiemCC", SqlDbType.Float);
                    command.Parameters["@DiemCC"].Value = float.Parse(txtDiemCC.Text);
                    command.Parameters.Add("@DiemGK", SqlDbType.Float);
                    command.Parameters["@DiemGK"].Value = float.Parse(txtDiemGK.Text);
                    command.Parameters.Add("@DiemCK", SqlDbType.Float);
                    command.Parameters["@DiemCK"].Value= float.Parse(txtDiemCK.Text);
                    command.Parameters.Add("@DiemHe10", SqlDbType.Float);
                    command.Parameters["@DiemHe10"].Value= diemhe10;
                    command.Parameters.Add("@DiemHe4", SqlDbType.Float);
                    command.Parameters["@DiemHe4"].Value = diemhe4;
                    command.Parameters.Add("@DiemChu", SqlDbType.NVarChar);
                    command.Parameters["@DiemChu"].Value = txtDiemHeChu.Text;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                //int kq = command.ExecuteNonQuery();
                //if (kq > 0)
                //{
                    HienThiToanBoBangDiem();
                    MessageBox.Show("Lưu thông tin thành công");
                    btnTaoMoiBD.PerformClick();
                //}
                //else
                //{
                //    MessageBox.Show("Lưu thông tin thất bại");
                //}
                */

                using (SqlConnection newconn = new SqlConnection(strConn))
                {
                    string sql = "Update BangDiem set ID=@ID,DiemCC=@DiemCC,DiemGK=@DiemGK,DiemCK=@DiemCK,DiemHe10=@DiemHe10,DiemHe4=@DiemHe4,DiemChu=@DiemChu where ID=" + txtIdBD.Text;
                    SqlCommand command = new SqlCommand(sql, newconn);
                    command.Parameters.Add("@ID", SqlDbType.NVarChar);
                    command.Parameters["@ID"].Value = txtIdBD.Text;
                    command.Parameters.Add("@DiemCC", SqlDbType.Float);
                    command.Parameters["@DiemCC"].Value = float.Parse(txtDiemCC.Text);
                    command.Parameters.Add("@DiemGK", SqlDbType.Float);
                    command.Parameters["@DiemGK"].Value = float.Parse(txtDiemGK.Text);
                    command.Parameters.Add("@DiemCK", SqlDbType.Float);
                    command.Parameters["@DiemCK"].Value = float.Parse(txtDiemCK.Text);
                    command.Parameters.Add("@DiemHe10", SqlDbType.Float);
                    command.Parameters["@DiemHe10"].Value = diemhe10;
                    command.Parameters.Add("@DiemHe4", SqlDbType.Float);
                    command.Parameters["@DiemHe4"].Value = diemhe4;
                    command.Parameters.Add("@DiemChu", SqlDbType.NVarChar);
                    command.Parameters["@DiemChu"].Value = txtDiemHeChu.Text;
                    command.Connection.Open();
                    //command.ExecuteNonQuery();

                    int kq = command.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        HienThiToanBoBangDiem();
                        MessageBox.Show("Lưu thông tin thành công");
                        btnTaoMoiBD.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Lưu thông tin thất bại");
                    }
                }
            }
            //catch (MissingFieldException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //catch (FormatException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            catch (Exception ex)
            {
                MessageBox.Show("Học phần này đã có điểm --- " + ex.Message);
            }
        }

        private bool KiemTraTonTaiBD(string masv)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from BangDiem where MaSV=@masv";
                command.Connection = conn;
                //SqlParameter parid = new SqlParameter("@id", SqlDbType.NVarChar);
                //parid.Value = id;
                command.Parameters.Add("@masv", SqlDbType.NVarChar).Value = cbMaSV.Text;
                SqlDataReader reader = command.ExecuteReader();
                //bool kq = reader.Read();
                //reader.Close();
                //return kq;     
                if (reader.HasRows == true) return true;
            }
            //catch (MissingFieldException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //catch (FormatException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            catch (Exception ex)
            {
                MessageBox.Show("Thím bị lỗi rồi --- " + ex.Message);
            }
            return false;
        }

        private void btnXoaBD_Click(object sender, EventArgs e)
        {
            if (lvBangDiem.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn dòng để có thể xóa");
                return;
            }
            ListViewItem lvi = lvBangDiem.SelectedItems[0];
            //string masv = (string)lvi.Tag;
            //string mahp = (string)lvi.Tag;
            string idbd = (string)lvi.Tag;

            DialogResult ret = MessageBox.Show("Bạn có chắc muốn xóa ko", "Xác nhận:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                ThucHienXoaBD(idbd);
            }
        }

        private void ThucHienXoaBD(string idbd)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                //command.CommandText = "delete from BangDiem where MaSV=@masv and MaHP=@mahp";
                command.CommandText = "delete from BangDiem where ID=@idbd";
                command.Connection = conn;
                command.Parameters.Add("@idbd", SqlDbType.NVarChar).Value = txtIdBD.Text;
                //command.Parameters.Add("@mahp", SqlDbType.NVarChar).Value = cbMaHP.Text;               

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoBangDiem();
                    MessageBox.Show("Xóa thông tin thành công");
                    btnTaoMoiBD.PerformClick();
                }
                else
                {
                    MessageBox.Show("Xóa thông tin thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvBangDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBangDiem.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvBangDiem.SelectedItems[0];
            //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
            string idbd = (string)lvi.Tag;
            HienThiChiTietBangDiem(idbd);
        }

        private void HienThiChiTietBangDiem(string idbd)
        {
            try
            {                
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from BangDiem where ID=@idbd";
                command.Connection = conn;
                SqlParameter parMa = new SqlParameter("@idbd", SqlDbType.NVarChar);
                parMa.Value = idbd;
                command.Parameters.Add(parMa);

                
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string idbd1 = reader.GetString(0);
                    string masv = reader.GetString(1);
                    string tensv = reader.GetString(2);
                    string mahp = reader.GetString(3);
                    string tenhp = reader.GetString(4);

                    float diemcc = (float)reader.GetDouble(5);
                    float diemgk = (float)reader.GetDouble(6);
                    float diemck = (float)reader.GetDouble(7);
                    float diemh10 = (float)reader.GetDouble(8);
                    float diemh4 = (float)reader.GetDouble(9);
                    string diemhc = reader.GetString(10);

                    txtIdBD.Text = idbd1;
                    cbMaSV.Text = masv;
                    cbTenSV.Text = tensv;
                    cbMaHP.Text = mahp;
                    cbTenHP.Text = tenhp;

                    txtDiemCC.Text = diemcc + "";
                    txtDiemGK.Text = diemgk + "";
                    txtDiemCK.Text = diemck + "";
                    txtDiemHe10.Text = diemh10 + "";
                    txtDiemHe4.Text = diemh4 + "";
                    txtDiemHeChu.Text = diemhc;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXemCT_Click(object sender, EventArgs e)
        {
            frmXemChiTietBD frm = new frmXemChiTietBD();
            frm.ShowDialog();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.') && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSoTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.') && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDiemCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.') && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDiemGK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.') && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDiemCK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.') && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnTimKiemBD_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;

                //command.CommandText = "select * from BangDiem where HoTen like @HoTen";
                //command.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = "%" + txtTimKiemBD.Text + "%";

                command.CommandText = "select * from BangDiem where TenHP like @TenHP";
                command.Parameters.Add("@TenHP", SqlDbType.NVarChar).Value = "%" + txtTimKiemBD.Text + "%";


                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                lvBangDiem.Items.Clear();

                while (reader.Read())
                {
                    string idbd = reader.GetString(0);
                    string masv = reader.GetString(1);
                    string tensv = reader.GetString(2);
                    string mahp = reader.GetString(3);
                    string tenhp = reader.GetString(4);

                    float diemcc = (float)reader.GetDouble(5);
                    float diemgk = (float)reader.GetDouble(6);
                    float diemck = (float)reader.GetDouble(7);
                    float diemh10 = (float)reader.GetDouble(8);
                    float diemh4 = (float)reader.GetDouble(9);
                    string diemhc = reader.GetString(10);

                    ListViewItem lvi = new ListViewItem((lvBangDiem.Items.Count + 1) + "");
                    //ListViewItem lvi = new ListViewItem(id + "");
                    //lvi.SubItems.Add(id + "");

                    lvi.SubItems.Add(idbd);
                    lvi.SubItems.Add(masv);
                    lvi.SubItems.Add(tensv);
                    lvi.SubItems.Add(mahp);
                    lvi.SubItems.Add(tenhp);
                    lvi.SubItems.Add(diemcc + "");
                    lvi.SubItems.Add(diemgk + "");
                    lvi.SubItems.Add(diemck + "");
                    lvi.SubItems.Add(diemh10 + "");
                    lvi.SubItems.Add(diemh4 + "");
                    lvi.SubItems.Add(diemhc);

                    lvBangDiem.Items.Add(lvi);

                    //Khi kích vào từng dòng trong listView sẽ hiển thị chi tiết lên, vậy làm sao biết ta kích vào dòng nào thì dùng "Tag"
                    //Vậy nên ở đây gán Tag=mã
                    //Mỗi lần nhấn vào lấy đc Tag ra => lấy đc mã => sẽ lấy đc thông tin chi tiết.
                    lvi.Tag = idbd;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiemBD_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKiemBD.Text = "";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan f = new frmQuanLyTaiKhoan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //-------------------------------------------------------------------------------


    }
}
