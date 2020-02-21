﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;

namespace OrthoSquare.BAL_Classes
{

    public class General
    {
        private string mstr_ConnectionString;
        private SqlConnection mobj_SqlConnection;
        private SqlCommand mobj_SqlCommand;
        private int mint_CommandTimeout = 2000;

        public enum ExpectedType
        {

            StringType = 0,
            NumberType = 1,
            DateType = 2,
            BooleanType = 3,
            ImageType = 4
        }

        public General()
        {
            try
            {
                mstr_ConnectionString = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ToString();
                mobj_SqlConnection = new SqlConnection(mstr_ConnectionString);
                mobj_SqlCommand = new SqlCommand();
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.Connection = mobj_SqlConnection;
                //ParseConnectionString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing data class." + Environment.NewLine + ex.Message);
            }
        }

        public void Dispose()
        {
            try
            {
                //Clean Up Connection Object if (mobj_SqlConnection != null)
                {
                    if (mobj_SqlConnection.State != ConnectionState.Closed)
                    {
                        mobj_SqlConnection.Close();
                    }
                    mobj_SqlConnection.Dispose();
                }
                //Clean Up Command Object if (mobj_SqlCommand != null)
                {
                    mobj_SqlCommand.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error disposing data class." + Environment.NewLine + ex.Message);
            }
        }


        public void CloseConnection()
        {
            if (mobj_SqlConnection.State != ConnectionState.Closed) mobj_SqlConnection.Close();
        }

        #region "********* For SP **********"
        public int GetExecuteScalarByCommand_SP(string Command)
        {
            object identity = 0;
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.StoredProcedure;

                mobj_SqlConnection.Open();

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                identity = mobj_SqlCommand.ExecuteScalar();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
            return Convert.ToInt32(identity);
        }

        public int GetExecuteNonQueryByCommand_SP(string Command)
        {
            int rowAffected = -1;
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.StoredProcedure;

                mobj_SqlConnection.Open();

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                rowAffected = mobj_SqlCommand.ExecuteNonQuery();

                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
            return rowAffected;
        }

        public DataSet GetDatasetByCommand_SP(string Command)
        {
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.StoredProcedure;

                mobj_SqlConnection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(mobj_SqlCommand);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public SqlDataReader GetReaderByCmd_SP(string Command)
        {
            SqlDataReader objSqlDataReader = null;
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandType = CommandType.StoredProcedure;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;

                mobj_SqlConnection.Open();
                mobj_SqlCommand.Connection = mobj_SqlConnection;

                objSqlDataReader = mobj_SqlCommand.ExecuteReader();
                return objSqlDataReader;
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }
        #endregion

        #region "********* For Quries **********"

        public string GetExecuteScalarByCommand(string Command)
        {
            object identity = 0;
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;

                mobj_SqlConnection.Open();

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                identity = mobj_SqlCommand.ExecuteScalar();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
            return identity.ToString();
        }

        public void GetExecuteNonQueryByCommand(string Command)
        {
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;

                mobj_SqlConnection.Open();

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                mobj_SqlCommand.ExecuteNonQuery();

                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public DataTable GetDatasetByCommand(string Command)
        {
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;

                mobj_SqlConnection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(mobj_SqlCommand);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable GetDatasetByCommand_Paging(string Command, int StartIndex, int PageSize)
        {
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;

                mobj_SqlConnection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(mobj_SqlCommand);
                DataSet ds = new DataSet();
                adpt.Fill(ds, StartIndex, PageSize, "Data");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }


        public SqlDataReader GetReaderBySQL(string strSQL)
        {
            mobj_SqlConnection.Open();
            try
            {
                SqlCommand myCommand = new SqlCommand(strSQL, mobj_SqlConnection);
                return myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public SqlDataReader GetReaderByCmd(string Command)
        {
            SqlDataReader objSqlDataReader = null;
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandType = CommandType.Text;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;

                mobj_SqlConnection.Open();
                mobj_SqlCommand.Connection = mobj_SqlConnection;

                objSqlDataReader = mobj_SqlCommand.ExecuteReader();
                return objSqlDataReader;
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        #endregion


        public void AddParameterWithValueToSQLCommand(string ParameterName, object Value)
        {
            try
            {
                mobj_SqlCommand.Parameters.AddWithValue(ParameterName, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType)
        {
            try
            {
                mobj_SqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType, int ParameterSize)
        {
            try
            {
                mobj_SqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType, ParameterSize));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetSQLCommandParameterValue(string ParameterName, object Value)
        {
            try
            {
                mobj_SqlCommand.Parameters[ParameterName].Value = Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetExecuteNonQueryByCommandFunction(string Command)
        {
            try
            {
                mobj_SqlCommand.CommandText = Command;
                mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
                mobj_SqlCommand.CommandType = CommandType.Text;

                mobj_SqlConnection.Open();

                mobj_SqlCommand.Connection = mobj_SqlConnection;
                int FeesID = mobj_SqlCommand.ExecuteNonQuery();
                return FeesID;

                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public DateTime getDatetime(string dt)
        {
            return DateTime.ParseExact(dt, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public DateTime getDatetime11(string dt)
        {
            return DateTime.ParseExact(dt, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
        }
    }



}