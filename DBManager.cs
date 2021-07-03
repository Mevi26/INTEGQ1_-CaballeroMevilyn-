using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DL
{
    public class DBManager
    {


        SqlConnection con = new SqlConnection ("Data Source=MEVZCABALLERO11; Database=3tier; Integrated Security=True;");


        public DataTable ExecuteDatatable(string query)
        {
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }
        public void ExecuteNoneQuery(string query)
        {
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public bool ExecuteScalar(string query)
        {
            DataTable dt = new DataTable();
            dt = ExecuteDatatable(query);
            if (dt.Rows.Count == 1 && dt.Columns.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

