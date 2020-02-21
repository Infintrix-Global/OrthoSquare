using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_Clinic
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();
        public int Add_Clinic(ClinicDetails  bojClinic)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

              
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", bojClinic.clinicID);
               
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicName", bojClinic.ClinicName);

                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", bojClinic.FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", bojClinic.LastName);


                objGeneral.AddParameterWithValueToSQLCommand("@AddressLine1", bojClinic.AddressLine1);
                objGeneral.AddParameterWithValueToSQLCommand("@AddressLine2", bojClinic.AddressLine2);
                objGeneral.AddParameterWithValueToSQLCommand("@LocationID", bojClinic.LocationID);
                objGeneral.AddParameterWithValueToSQLCommand("@PhoneNo1", bojClinic.PhoneNo1);
                objGeneral.AddParameterWithValueToSQLCommand("@PhoneNo2", bojClinic.PhoneNo2);
                objGeneral.AddParameterWithValueToSQLCommand("@Emailid", bojClinic.Emailid);
                objGeneral.AddParameterWithValueToSQLCommand("@DayOfWeek", bojClinic.Noofweek);
                objGeneral.AddParameterWithValueToSQLCommand("@openTime", bojClinic.openTime);
                objGeneral.AddParameterWithValueToSQLCommand("@CloseTime", bojClinic.CloseTime);
                objGeneral.AddParameterWithValueToSQLCommand("@StateID", bojClinic.StateID);
                objGeneral.AddParameterWithValueToSQLCommand("@CountryID", bojClinic.CountryID);
                objGeneral.AddParameterWithValueToSQLCommand("@CityID", bojClinic.CityID);

                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID",1);
                objGeneral.AddParameterWithValueToSQLCommand("@LocationName",bojClinic.LocationName);
                objGeneral.AddParameterWithValueToSQLCommand("@IsActive", bojClinic.IsActive);
                objGeneral.AddParameterWithValueToSQLCommand("@UserName", bojClinic.UserName);
                objGeneral.AddParameterWithValueToSQLCommand("@Password", bojClinic.UserPassword);

                if (bojClinic.clinicID > 0)
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

                }

                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("sp_ClinicSetUp");



            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }

        public DataTable GetAllClinicDetais()
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Clinic");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public int DeleteClinic(int CID)
        {
            int _isDeleted = -1;
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", CID);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("GET_Clinic");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }

        public DataTable GetSelectAllClinic(int CID)
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", CID);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Clinic");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable GetSelectAllClinicEmployee(long CID)
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", CID);
                ds = objGeneral.GetDatasetByCommand_SP("GET_Clinic");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public int GetClinicID()
        {

            try
            {
                string strQuery = "Select MAX(ClinicID) from  tbl_ClinicDetails where IsActive =1";
                return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int Add_AppointmentDetails(int Cid)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

              string   strQuery = "insert into AppointmentMaster (ClinicID,start_date,end_date,IsActive)values ('" + Cid + "','2017-10-10 00:00:00.000','2017-10-10 00:00:00.000',1)";
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;
            }

            catch (Exception ex)
            {
            }
            return isInserted;
        }
    }
}