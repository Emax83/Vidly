using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Vidly.Infrastracture
{
    public class DBHelper
    {
        public string ConnectionString { get; }
        public List<SqlParameter> SqlParameters { get; }

        public DBHelper(string _ConnectionString)
        {
            SqlParameters = new List<SqlParameter>();

            ConnectionString = _ConnectionString;//"Server=PC-STUDIO\\SQL2017;Initial Catalog=code4fun;User Id=sa;Password=Milan@83;";

            //if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("localhost"))
            //{
            //    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Debug"].ConnectionString;
            //}
            //else
            //{
            //    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Release"].ConnectionString;
            //}
        }

        public DataTable GetDataTableFromStoredProcedure(string spName, string tableName = "table")
        {
            DataTable dataTable = new DataTable(tableName);
            SqlDataAdapter adapter = new SqlDataAdapter(spName, ConnectionString);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddRange(SqlParameters.ToArray());
            adapter.FillSchema(dataTable, SchemaType.Source);
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetDataTableFromQueryString(string tsqlQuery, string tableName = "table")
        {
            DataTable dataTable = new DataTable(tableName);
            SqlDataAdapter adapter = new SqlDataAdapter(tsqlQuery, ConnectionString);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.SelectCommand.Parameters.AddRange(SqlParameters.ToArray());
            adapter.FillSchema(dataTable, SchemaType.Source);
            adapter.Fill(dataTable);
            return dataTable;
        }

        public int ExecuteQueryFromStoredProcedure(string spName)
        {
            int count = 0;
            SqlCommand command = new SqlCommand(spName, new SqlConnection(ConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(SqlParameters.ToArray());
            command.Connection.Open();
            count = command.ExecuteNonQuery();
            command.Connection.Close();
            return count;
        }

        public int ExecuteQueryFromQueryString(string tsqlQuery)
        {
            int count = 0;
            SqlCommand command = new SqlCommand(tsqlQuery, new SqlConnection(ConnectionString));
            command.CommandType = CommandType.Text;
            command.Parameters.AddRange(SqlParameters.ToArray());
            command.Connection.Open();
            count = command.ExecuteNonQuery();
            command.Connection.Close();
            return count;
        }

        public bool TestConnection()
        {
            bool valid = false;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);
            builder.ConnectTimeout = 5; //5 seconds, no more to wait
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                valid = true;
            }
            catch
            {
                valid = false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return valid;
        }


        public IEnumerable<object> GetEnumerableObjectFromDataTable(DataTable dataTable, Type destinationType)
        {
            List<object> instances = new List<object>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                try
                {
                    instances.Add(GetObjectFromDataRow(dataRow, destinationType));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return instances;
        }

        public IEnumerable<SqlParameter> GetParametersFromObject(object source)
        {
            List<SqlParameter> pars = new List<SqlParameter>();

            foreach (PropertyInfo prop in source.GetType().GetProperties())
            {
                pars.Add(new SqlParameter(string.Format("@{0}", prop.Name), prop.GetValue(source)));
            }

            return pars;
        }

        public object GetObjectFromDataRow(DataRow dataRow, Type destinationType)
        {
            object instance = Activator.CreateInstance(destinationType);
            foreach (DataColumn col in dataRow.Table.Columns)
            {
                try
                {
                    PropertyInfo property = destinationType.GetProperty(col.ColumnName);
                    if (property != null && property.CanWrite)
                    {
                        object value = Convert.ChangeType(dataRow[col.ColumnName], property.PropertyType);
                        property.SetValue(instance, value);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("GetObjectFromDataRow Error Column " + col.ColumnName, ex);
                }
            }
            return instance;
        }
    }
}