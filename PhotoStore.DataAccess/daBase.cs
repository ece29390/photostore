using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace PhotoStore.DataAccess
{
    public abstract class daBase
    {
        protected int commandTimeout = 30;

        /// <summary>Sql parameter builder.</summary>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="sqlDbType">Sql data type.</param>
        /// <param name="parameterDirection">Parameter direction.</param>
        /// <param name="value">Parameter value.</param>
        /// <returns>Sql parameter.</returns>
        public SqlParameter SqlParameterBuilder(string parameterName, SqlDbType sqlDbType, ParameterDirection parameterDirection, Object value)
        {
            SqlParameter sqlParam = new SqlParameter();
            sqlParam.ParameterName = parameterName;
            sqlParam.SqlDbType = sqlDbType;
            sqlParam.Direction = parameterDirection;
            sqlParam.Value = value;
            return sqlParam;
        }

        /// <summary>Add in parameter to the sql command.</summary>
        /// <param name="command">Sql command.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="sqlDbType">Sql data type.</param>
        /// <param name="value">Parameter value.</param>
        public void AddInParameter(SqlCommand command, string parameterName, SqlDbType sqlDbType, Object value)
        {
            SqlParameter p = SqlParameterBuilder(parameterName, sqlDbType, ParameterDirection.Input, value);
            command.Parameters.Add(p);
        }

        /// <summary>Add out parameter to the sql command.</summary>
        /// <param name="command">Sql command.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="sqlDbType">Sql data type.</param>
        /// <param name="value">Parameter value.</param>
        public void AddOutParameter(SqlCommand command, string parameterName, SqlDbType sqlDbType, Object value)
        {
            SqlParameter p = SqlParameterBuilder(parameterName, sqlDbType, ParameterDirection.Output, value);
            command.Parameters.Add(p);
        }

        /// <summary>execute a select command</summary>
        /// <param name="selectCommandText">the select statement</param>
        /// <returns>dataset: result set of the select statement</returns>
        protected DataSet executeSelect(string selectCommandText)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CnnStr"].ToString());

            using (SqlDataAdapter sda = new SqlDataAdapter(selectCommandText, conn))
            {
                sda.Fill(ds);
                sda.Dispose();
            }
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return ds;
        }

        /// <summary>retrieve a particular row defined by Id</summary>
        /// <param name="TableName">the table in reference</param>
        /// <param name="Id">the Id of a particular row</param>
        /// <returns>datarow: a row of data</returns>
        protected DataRow executeSelectById(string TableName, int Id)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CnnStr"].ToString());

            using (SqlDataAdapter sda = new SqlDataAdapter("Select * from "+ TableName + " where Id=" + Id, conn))
            {
                sda.Fill(ds);
                sda.Dispose();
            }
            if (conn.State == ConnectionState.Open)
                conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return ds.Tables[0].Rows[0];
        }


        public void ExecuteNonQuery(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CnnStr"].ToString());
            conn.Open();
            cmd.Connection = conn;

            cmd.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open)
                conn.Close();

            cmd.Parameters.Clear();
            cmd.Dispose();
        }

        /// <summary>executes a stored procedure</summary>
        /// <param name="paramName">the table in reference</param>
        /// <param name="Id">the Id of a particular row</param>
        /// <returns>datarow: a row of data</returns>
        public DataSet executeProcedure(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CnnStr"].ToString());
            conn.Open();
            cmd.Connection = conn;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (cmd.Connection.State == ConnectionState.Open)
                cmd.Connection.Close();

            conn.Close();
            return ds;

        }
        
        ///// <summary>executes a stored procedure</summary>
        ///// <param name="paramName">the table in reference</param>
        ///// <param name="Id">the Id of a particular row</param>
        ///// <returns>datarow: a row of data</returns>
        //public DataSet executeProcedure(string procedureName, string paramName, string paramValue)
        //{
        //    SqlCommand cmd = new SqlCommand(procedureName, (new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CnnStr"].ToString())));

        //    SqlParameter param = new SqlParameter(paramName, paramValue);
        //    cmd.Parameters.Add(param);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    if (cmd.Connection.State == ConnectionState.Open)
        //        cmd.Connection.Close();
        //    return ds;

        //}
        //public void RunNonQuery(string SPName, SqlParameter[] paramlist)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandText = SPName;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = conn;

        //    //int i;

        //    foreach (object p in paramlist)
        //    {
        //        cmd.Parameters.Add(p);
        //    }

        //    ClosedConnection();
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    //i = Convert.ToInt16(cmd.ExecuteScalar());
        //    conn.Close();

        //    //return i;
        //    cmd.Parameters.Clear();
        //    cmd.Dispose();
        //}


        //public SqlDataReader RunReader(string SPName, SqlParameter paramlist)
        //{

        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataReader dr;

        //    cmd.CommandText = SPName;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = conn;

        //    cmd.Parameters.Add(paramlist);

        //    ClosedConnection();
        //    conn.Open();
        //    dr = cmd.ExecuteReader();


        //    cmd.Parameters.Clear();
        //    cmd.Dispose();
        //    return dr;

        //}

        //public SqlDataReader RunReader(string SPName)
        //{
        //    SqlDataReader dr;
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandText = SPName;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = conn;



        //    //Function call to closed the sqlconnection
        //    ClosedConnection();
        //    conn.Open();


        //    dr = cmd.ExecuteReader();
        //    cmd.Parameters.Clear();
        //    cmd.Dispose();
        //    return dr;

        //}











        //public void ClosedConnection()
        //{
        //    conn.Close();

        //}

        //public DataSet RunDataset(string SPName)
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter(SPName, conn);
        //    ds.Tables.Clear();
        //    da.Fill(ds, " ");
        //    return ds;
        //}


    }
}
