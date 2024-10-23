using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KetNoiCSDL
{
    internal class Class1
    {
        //Ket noi co so du lieu
        private static string connectionString = "server=LAPTOP-K6CMR37C;database=PTUDCSDLN0X;integrated security=true;";
        private static SqlConnection connection;
        public static DataTable Query(string sql)
        {
            //Truy van co so du lieu
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
        public static void Execute(string sql) 
        {
            //Thuc thi cau lenh them, sua, xoa... trong csdl
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
