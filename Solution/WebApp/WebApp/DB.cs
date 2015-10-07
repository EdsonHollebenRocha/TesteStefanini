using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Classes
{
    public class DB
    {
        public static SqlConnection createConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=C:\\Users\\Edson\\Downloads\\Solution\\Solution\\WebApp\\WebApp\\App_Data\\Database.mdf;" +
                "Integrated Security=True;Connect Timeout=30");
            return conn;
        }

        public static DataTable getStaticData(string sql)
        {
            SqlConnection conn = createConnection();
            SqlCommand commmand = new SqlCommand();
            commmand.Connection = conn;
            commmand.CommandText = sql;
            IDataReader dr = null;
            commmand.Connection.Open();
            dr = commmand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            commmand.Connection.Close();
            return dt;
        }

        public static void executeSql(string sql)
        {
            SqlConnection conn = createConnection();
            SqlCommand commmand = new SqlCommand();
            commmand.Connection = conn;
            commmand.CommandText = sql;
            commmand.Connection.Open();
            commmand.ExecuteNonQuery();
            conn.Close();
        }

        public static void executeSqlWithParameters(string sql,SqlParameter[] parameters)
        {
            SqlConnection conn = createConnection();
            SqlCommand commmand = new SqlCommand();
            foreach (SqlParameter parameter in parameters)
                commmand.Parameters.Add(parameter);
            commmand.Connection = conn;
            commmand.CommandText = sql;
            commmand.Connection.Open();
            commmand.ExecuteNonQuery();
            conn.Close();
        }

        public static SqlParameter MakeParam(string nameParam, SqlDbType paramType, object paramValue)
        {
            SqlParameter param = new SqlParameter(nameParam, paramValue);
            param.SqlDbType = paramType;
            return param;
        }

        public static object getValue(string sql)
        {
            SqlConnection conn = createConnection();
            SqlCommand commmand = new SqlCommand();
            commmand.Connection = conn;
            commmand.CommandText = sql;
            commmand.Connection.Open();
            commmand.ExecuteNonQuery();
            object returnValue = commmand.ExecuteScalar();
            conn.Close();
            return returnValue;
        }

        public static string Quote(string value)
        {
            return "'" + value + "'";
        }

        public static string getMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

    }
}
