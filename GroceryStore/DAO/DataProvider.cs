using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            set { instance = value; }
        }

        //String connectString = @"Data Source=MSI;Initial Catalog=CuaHangTienLoi;Integrated Security=True";
        String connectString = @"Data Source = LAPTOP-VVRRVKK8; Initial Catalog = CuaHangTienLoi; Integrated Security = True";
        //String conn = $"{}"
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                addValuePara(command, query, parameters);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(table);   

                conn.Close();

            }
            return table;
        }

        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);


                addValuePara(command, query, parameters);

                data = command.ExecuteNonQuery();
                conn.Close();

            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = new object();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                addValuePara(command, query, parameters);

                data = command.ExecuteScalar();
                conn.Close();

            }
            return data;
        }

        public static void addValuePara(SqlCommand command, string query, object[] parameters = null)
        {
            if (parameters != null)
            {
                string[] paras = query.Split(' ');
                int i = 0;
                foreach (string para in paras)
                {
                    if (para.Contains('@'))
                    {
                        command.Parameters.AddWithValue(para, parameters[i]);
                        i++;
                    }
                }
            }
        }

        public void ExecuteStoredProcedure(string statement, object[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string[] paraNames = statement.Split(' ', ',', '@').Where(s => !string.IsNullOrEmpty(s)).ToArray();
                SqlCommand command = new SqlCommand(paraNames[0], conn);
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.AddWithValue(paraNames[i + 1], parameters[i]);

                    }
                }

                try
                {
                    conn.Open();
                    System.Diagnostics.Debug.Print(command.CommandText);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: " + ex.Message);
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public DataTable ExecuteStoredProcedureSelect(string statement, object[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string[] paraNames = statement.Split(' ', ',', '@').Where(s => !string.IsNullOrEmpty(s)).ToArray();
                SqlCommand command = new SqlCommand(paraNames[0], conn);
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.AddWithValue(paraNames[i + 1], parameters[i]);
                    }
                }

                DataTable results = new DataTable();
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        results.Load(reader);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: " + ex.Message);
                    Console.WriteLine("Error: " + ex.Message);
                }
                return results;
            }
        }

        public double ExecuteStoredProcedureScalar(string statement, object[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string[] paraNames = statement.Split(' ', ',', '@').Where(s => !string.IsNullOrEmpty(s)).ToArray();
                SqlCommand command = new SqlCommand(paraNames[0], conn);
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.AddWithValue(paraNames[i + 1], parameters[i]);
                    }
                }

                double result = 0;
                try
                {
                    conn.Open();
                    object scalarResult = command.ExecuteScalar();
                    if (scalarResult != null)
                    {
                        result = Convert.ToDouble(scalarResult);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Error: " + ex.Message);
                    Console.WriteLine("Error: " + ex.Message);
                }
                return result;
            }
        }

    }
}
