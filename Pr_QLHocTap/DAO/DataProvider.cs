using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_QLHocTap.DAO
{
    class DataProvider
    {

        // code design singleton cho class Dataprovider
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }
        private DataProvider() { }


        public string connectionSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\CSDL\CSDL\CSDL_QLHocTap.mdf;Integrated Security=True;Connect Timeout=30";
       
        //Thực thi câu lệnh sql , có thế có tham số truyền vào
        public DataTable ExecuteQuery(string query, object[] paramater = null)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        command.Parameters.AddWithValue(item, paramater[i]);
                        i++;
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(datatable);
                connection.Close();
            }
            return datatable;
        }
        //đếm số dòng thực thi câu lệnh thành công
        public int ExecuteNonQuery(string query, object[] paramater = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        command.Parameters.AddWithValue(item, paramater[i]);
                        i++;
                    }
                }

                try
                {
                    data = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    data = -1;
                }

                connection.Close();
            }
            return data;
        }
        //lấy dữ liệu dòng fđầu tiên
        public object ExecuteScalar(string query, object[] paramater = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        command.Parameters.AddWithValue(item, paramater[i]);
                        i++;
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }


}

