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
    public partial class frmInAnHP : Form
    {
        public frmInAnHP()
        {
            InitializeComponent();
        }

        private void frmInAnHP_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"" + DataProvider.Instance.connectionSTR + "");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from HocPhan", conn);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "HocPhan");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetHP";
            rds.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pr_QLHocTap.ReportHP.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();            
        }
    }
}
