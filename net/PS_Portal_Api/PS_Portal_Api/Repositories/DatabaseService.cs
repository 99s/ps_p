using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PS_Portal_Api.Repositories
{
    public class DatabaseService
    {
        public static string _connstring= @"Server = H0ME_IG; Database=psportal_db;Trusted_Connection=True;";
        //private static IConfiguration _configuration;

        //public DatabaseService(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    _connstring = _configuration["ConnectionStrings:DefaultConnection"];

        //}


        //IConfiguration _configuration;

        //public DatabaseService(IConfiguration Configuration)
        //{
        //    _configuration = Configuration;
        //    _connstring = _configuration.GetConnectionString("DefaultConnection");

        //}

        public DataSet ExecuteQuery(string sqlQry)
        {

            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(_connstring))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    DataSet _ds = new DataSet();
                    using (SqlCommand _sqlCommand = new SqlCommand(sqlQry, _sqlConnection))
                    {
                        _sqlCommand.CommandType = CommandType.Text;
                        SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter();
                        _sqlDataAdapter.SelectCommand = _sqlCommand;
                        _sqlDataAdapter.Fill(_ds);
                    }

                    return _ds;
                }
            }
            catch (Exception _e)
            {
                throw new Exception(_e.Message.ToString());
            }

        }
        public DataTable PopulateDataTable(string sqlQry)
        {
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(_connstring))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    DataTable _dt = new DataTable();
                    using (SqlCommand _sqlCommand = new SqlCommand(sqlQry, _sqlConnection))
                    {
                        _sqlCommand.CommandType = CommandType.Text;
                        SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter();
                        _sqlDataAdapter.SelectCommand = _sqlCommand;
                        _sqlDataAdapter.Fill(_dt);
                    }

                    return _dt;
                }
            }
            catch (Exception _e)
            {
                throw new Exception(_e.Message.ToString());
            }
        }
        public bool ExecuteNonQuery(string sqlQuery)
        {
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(_connstring))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    using (SqlCommand _sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                    {
                        _sqlCommand.CommandType = CommandType.Text;
                        int r = _sqlCommand.ExecuteNonQuery();
                        if (r == 0)
                            return false;
                        else
                            return true;
                    }
                }
            }
            catch (Exception _e)
            {
                throw new Exception(_e.Message.ToString());
            }

        }
        public bool ExecuteProcedure(string sqlProcName, SqlParameter[] sqlParam, Action<SqlParameterCollection> output)
        {
            int result = 0;
            bool succeed = false;
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(_connstring))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    using (SqlCommand _sqlCommand = new SqlCommand(sqlProcName, _sqlConnection))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (sqlParam != null && sqlParam.Length > 0)
                        { _sqlCommand.Parameters.AddRange(sqlParam); }
                        result = _sqlCommand.ExecuteNonQuery();
                        output?.Invoke(_sqlCommand.Parameters); // calls delegate
                        succeed = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                result = 0;
                succeed = false;
            }
            return succeed; // not trapped in any exception
        }
        public SqlParameterCollection ExecuteProcedure(string sqlProcName, SqlParameter[] sqlParam)
        {

            int result = 0;
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(_connstring))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    using (SqlCommand _sqlCommand = new SqlCommand(sqlProcName, _sqlConnection))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (sqlParam != null && sqlParam.Length > 0)
                        { _sqlCommand.Parameters.AddRange(sqlParam); }
                        result = _sqlCommand.ExecuteNonQuery();
                        return _sqlCommand.Parameters;
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }

            return null; // not trapped in any exception
        }
        public DataSet ExecuteStoreProc(string strProcName, SqlParameter[] sqlParam)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(_connstring))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    using (SqlCommand _sqlCommand = new SqlCommand(strProcName, _sqlConnection))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.CommandTimeout = 60 * 12 * 1000;
                        if (sqlParam != null && sqlParam.Length > 0)
                        { _sqlCommand.Parameters.AddRange(sqlParam); }
                        SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter();
                        _sqlDataAdapter.SelectCommand = _sqlCommand;
                        _sqlDataAdapter.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        public DataTable ExecuteStoreProcedure(string strProcName, SqlParameter[] sqlParam)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(_connstring))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    using (SqlCommand _sqlCommand = new SqlCommand(strProcName, _sqlConnection))
                    {
                        _sqlCommand.CommandTimeout = 20 * 60 * 1000;
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (sqlParam != null && sqlParam.Length > 0)
                        { _sqlCommand.Parameters.AddRange(sqlParam); }
                        SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter();
                        _sqlDataAdapter.SelectCommand = _sqlCommand;
                        _sqlDataAdapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public dynamic ExecuteProcedure2(string sqlProcName, SqlParameter[] sqlParam)
        {

            int result = 0;
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(_connstring))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    using (SqlCommand _sqlCommand = new SqlCommand(sqlProcName, _sqlConnection))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (sqlParam != null && sqlParam.Length > 0)
                        { _sqlCommand.Parameters.AddRange(sqlParam); }
                        result = _sqlCommand.ExecuteNonQuery();
                        return
                                new
                                {
                                    msg = result.ToString(),
                                    status = "success"
                                };
                    }
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    msg = ex.Message,
                    status = "failure"
                };
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
