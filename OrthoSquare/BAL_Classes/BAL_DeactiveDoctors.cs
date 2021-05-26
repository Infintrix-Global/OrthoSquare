using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_DeactiveDoctors
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        General objGeneral = new General();
        private string strQuery = string.Empty;
        public DataTable GetDoctorsDetails(int ClinicId)
        {
            try
            {
                General objGeneral = new General();
                strQuery = "Select *,DD.FirstName +' '+DD.LastName as DName from DoctorByClinic DBC Join  tbl_DoctorDetails DD on DD.DoctorID=DBC.DoctorID where DD.IsDeleted=0 and DBC.ClinicId=@Clinic ";
                objGeneral.AddParameterWithValueToSQLCommand("@Clinic", ClinicId);
                
                return objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public DataTable GetDoctorsSelect(int ClinicId)
        {
            try
            {
                General objGeneral = new General();
                strQuery = "Select * from DoctorByClinic  where IsDeactive=1 and ClinicId=@Clinic ";
                objGeneral.AddParameterWithValueToSQLCommand("@Clinic", ClinicId);

                return objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public int UpdateIsDeactive(int IsDeactive)
        {
            try
            {
                General objGeneral = new General();
                strQuery = "Update DoctorByClinic set  IsDeactive =0 where DCID =@IsDeactive";
                objGeneral.AddParameterWithValueToSQLCommand("@IsDeactive", IsDeactive);

                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int UpdateIsActive(int IsDeactive)
        {
            try
            {
                General objGeneral = new General();
                strQuery = "Update DoctorByClinic set  IsDeactive =1 where DCID =@IsActive";
                objGeneral.AddParameterWithValueToSQLCommand("@IsActive", IsDeactive);

                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}