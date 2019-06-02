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
using Microsoft.Reporting.WinForms;
using Pr_QLHocTap.DAO;
namespace Pr_QLHocTap
{
    public partial class frmInAnChiTietBD : Form
    {
        public frmInAnChiTietBD()
        {
            InitializeComponent();
        }

        public void frmInAnChiTietBD_Load(object sender, EventArgs e)
        {
            string massv = TaiKhoanDAO.Instance.getMasv;
            SqlConnection conn = new SqlConnection(DataProvider.Instance.connectionSTR);

            SqlDataAdapter adapter = new SqlDataAdapter("select hp.MaHP , hp.TenHP , hp.SoTC , hp.MaTQ ,CONVERT(decimal(10,2),  bd.DiemCC) as DiemCC  ,CONVERT(decimal(10,2),  bd.DiemGK ) as DiemGK,CONVERT(decimal(10,2),  bd.DiemCK) as DiemCK ,CONVERT(decimal(10,2) ,  bd.DiemHe10) as DiemHe10 ,CONVERT(decimal(10,2),  bd.DiemHe4 ) as DiemHe4, bd.DiemChu  from BangDiem as bd , SinhVien as sv , HocPhan as hp where sv.MaSV = bd.MaSV and hp.MaHP = bd.MaHP and sv.MaSV='" + massv + "'", conn);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "ChiTietBD");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetCTBD";
            rds.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pr_QLHocTap.ReportCTBD.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
