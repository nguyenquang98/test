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
    public partial class frmInAn : Form
    {
        public frmInAn()
        {
            InitializeComponent();
        }

        private void frmInAn_Load(object sender, EventArgs e)
        {
         
            SqlConnection conn = new SqlConnection(DataProvider.Instance.connectionSTR);
            SqlDataAdapter adapter = new SqlDataAdapter("select sv.MaSV,sv.HoTen,(case when GioiTinh='0' then N'Nam' else N'Nữ' End) as GioiTinh,sv.NgaySinh,sv.SDT,sv.QueQuan from SinhVien as sv", conn);
            DataSet ds = new DataSet();
           
            adapter.Fill(ds, "SinhVien");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pr_QLHocTap.ReportSinhVien.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
