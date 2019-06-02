using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_QLHocTap.DAO
{
    public class TaiKhoanDAO
    {
        public string getTaikhoan;
        public string getMasv;
        private static TaiKhoanDAO instance;
        public static TaiKhoanDAO Instance {
        get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
        private set { instance = value; }
        }
        private TaiKhoanDAO() { }



        public bool LoginMember(string taikhoan, string matkhau)
        {
            string sql = "select * from TaiKhoan where TaiKhoan.TK='"+taikhoan+"' and TaiKhoan.MK='"+matkhau+"'";
            DataTable result = DataProvider.Instance.ExecuteQuery(sql);
            return result.Rows.Count == 1;
        }

        public bool LoginAdmin(string taikhoan, string matkhau)
        {
            string sql = "select * from TKadmin as ad where ad.TK='" + taikhoan + "' and ad.MK='" + matkhau + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(sql);
            return result.Rows.Count == 1;
        }


        public string LoadHoTenTaiKhoan()
        {
            string query = string.Format("select sv.HoTen from SinhVien as sv, TaiKhoan as tk where tk.MaSV=sv.MaSV and tk.TK='{0}'", getTaikhoan);
            return (string)DataProvider.Instance.ExecuteScalar(query);
        }
        public string LoadMaSinhvien()
        {
            string tk = TaiKhoanDAO.Instance.getTaikhoan;
            string query = string.Format("SELECT tk.MaSV FROM  TaiKhoan as tk WHERE tk.TK ='{0}'",getTaikhoan);
            return (string)DataProvider.Instance.ExecuteScalar(query);
        }

        public string LoadMatKhauSinhvien()
        {
            string query = "SELECT TaiKhoan.MK FROM TaiKhoan  WHERE TaiKhoan.TK= '" + (string)TaiKhoanDAO.Instance.getTaikhoan + "'";
            string mk = (string)DataProvider.Instance.ExecuteScalar(query);
            string matkhau = mk.Trim();
            return matkhau;
        }

        public string LoadMatKhauAdmin()
        {
            string query = String.Format("select ad.MK from TKadmin as ad where ad.TK = '{0}'", (string)TaiKhoanDAO.Instance.getTaikhoan);
            string mk = (string)DataProvider.Instance.ExecuteScalar(query);
            string matkhau = mk.Trim();
            return matkhau;
        }

        public bool Themmoitaikhoan(string masv)
        {
            string query = String.Format("INSERT INTO TaiKhoan(MaSV, TK, MK) VALUES('{0}', '{1}', '{2}'", masv, masv, masv);
            int result = (int)DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
