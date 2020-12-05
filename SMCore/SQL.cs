using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Xml;

namespace SMCore
{
    public static class SQL
    {
        static string text;
        static SqlConnection con;

        public static bool baglanti_test()
        {
            DataTable ret;
            string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            XmlTextReader reader = new XmlTextReader(currentPath + @"\CONFIG.xml");
            while (reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "CON_STR")
                    {
                        text = reader.ReadString();
                        break;
                    }
                }
            }
            reader.Close();
                
            con = new SqlConnection(text);
            ret = SQL.get("SELECT 1"); 
            if(ret != null)
            {
                Log.WriteLog("SQL bağlantısı sağlandı.");
                return true;
            }
            else
            {
                Log.WriteLog("SQL bağlantısı yapılamadı. => " + text);
                return false;
            }
        }

        public static string getConStr()
        {
            return text;
        }

        public static DataTable get(string query)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                con.Close();
                return dt;
            }
            catch (Exception e)
            {
                Log.WriteLog("SQL bağlantısı koptu.");
                con.Close();
                return null;
            }
        }

        public static void set(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Log.WriteLog("SQL bağlantısı koptu.");
                con.Close();
            }
        }
    
        public static DataTable getU(string query)
        {
            using (SqlConnection connection = new SqlConnection(text))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataSet ds = new DataSet();
                    connection.Open();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    connection.Close();
                    return dt;
                }
                catch (Exception e)
                {
                    Log.WriteLog("SQL bağlantısı koptu.");
                    return null;
                }
            }
        }

        public static void setU(string query)
        {
            using (SqlConnection connection = new SqlConnection(text))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.WriteLog("SQL bağlantısı koptu.");
                }
            }
        }
    }
}
