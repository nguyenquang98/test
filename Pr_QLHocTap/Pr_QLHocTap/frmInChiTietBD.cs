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


namespace Pr_QLHocTap
{
    public partial class frmMain : Form
    {
        //public frmInChiTietBD()
        //{
        //    InitializeComponent();
        //}
        public frmMain()
        {
            InitializeComponent();
        }

        string strConn = "Server=MOLOTUS;Database=CSDL_QLHocTap;Integrated Security=True";
        SqlConnection conn = null;
        //private void OpenConnection()
        //{
        //    //if (conn == null)
        //    //{
        //    conn = new SqlConnection(strConn);
        //    //if (conn.State == ConnectionState.Closed)
        //    conn.Open();
        //    //}
        //}
        
        private void frmInChiTietBD_Load(object sender, EventArgs e)
        {
            //SqlCommand command = new SqlCommand();
            //SqlConnection conn = new SqlConnection("Server=MOLOTUS;Database=CSDL_QLHocTap;Integrated Security=True");            
            //SqlDataAdapter adapter = new SqlDataAdapter("select * from ChiTietBangDiem", conn);
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            
            command.CommandText = "select * from BangDiem where MaSV like @masvct";
            //command.Parameters.Add("@masvct", SqlDbType.NVarChar).Value = "%" + cbMaSvChiTiet.Text + "%";
            command.Parameters.Add("@masvct", SqlDbType.NVarChar).Value = cbMaSvChiTiet.Text;
            
            SqlDataReader reader = command.ExecuteReader();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ChiTietBD");
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetChiTietBD";
            rds.Value = ds.Tables[0];
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pr_QLHocTap.ReportChiTietBD.rdlc";
            //this.reportViewer1.LocalReport.DataSources.Add(rds);

            //this.reportViewer1.RefreshReport();

            
        }
    }
}
