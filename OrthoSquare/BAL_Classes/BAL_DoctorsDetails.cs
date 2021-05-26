using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{

    public class BAL_DoctorsDetails
    {
        General objGeneral = new General();
        DataSet ds = new DataSet();


        private string strQuery = string.Empty;
        public int Add_Doctors(DoctorDetails bojDoctor)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", bojDoctor.DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@RegDate", objGeneral.getDatetime(bojDoctor.RegDate));
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorTypeID", bojDoctor.DoctorTypeID);
                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", bojDoctor.FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", bojDoctor.LastName);
                objGeneral.AddParameterWithValueToSQLCommand("@AddressLine1", bojDoctor.AddressLine1);
                objGeneral.AddParameterWithValueToSQLCommand("@AddressLine2", bojDoctor.AddressLine2);
                objGeneral.AddParameterWithValueToSQLCommand("@AreaPin", bojDoctor.AreaPin);
                // objGeneral.AddParameterWithValueToSQLCommand("@DOB", objGeneral.getDatetime(bojDoctor.BirthDate));
                if (Convert.ToString(bojDoctor.BirthDate) == "")
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@DOB", DBNull.Value);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@DOB", objGeneral.getDatetime(bojDoctor.BirthDate));
                }
                objGeneral.AddParameterWithValueToSQLCommand("@Gender", bojDoctor.Gender);

                objGeneral.AddParameterWithValueToSQLCommand("@BloodGroup", bojDoctor.BloodGroup);
                objGeneral.AddParameterWithValueToSQLCommand("@PhoneNo1", bojDoctor.PhoneNo1);
                objGeneral.AddParameterWithValueToSQLCommand("@PhoneNo2", bojDoctor.PhoneNo2);
                objGeneral.AddParameterWithValueToSQLCommand("@Emailid", bojDoctor.Email);

                objGeneral.AddParameterWithValueToSQLCommand("@StateID", bojDoctor.StateID);
                objGeneral.AddParameterWithValueToSQLCommand("@CountryID", bojDoctor.CountryID);
                objGeneral.AddParameterWithValueToSQLCommand("@CityID", bojDoctor.CityID);


                objGeneral.AddParameterWithValueToSQLCommand("@PanCardNo", bojDoctor.PanCardNo);
                objGeneral.AddParameterWithValueToSQLCommand("@PanCardImageUrl", bojDoctor.PanCardImageUrl);
                objGeneral.AddParameterWithValueToSQLCommand("@AdharCardNo", bojDoctor.AdharCardNo);
                objGeneral.AddParameterWithValueToSQLCommand("@AdharCardImageUrl", bojDoctor.AdharCardImageUrl);
                objGeneral.AddParameterWithValueToSQLCommand("@ProfileImageUrl", bojDoctor.ProfileImageUrl);

                objGeneral.AddParameterWithValueToSQLCommand("@IsActive", bojDoctor.IsActive);
                objGeneral.AddParameterWithValueToSQLCommand("@Role", 3);
                objGeneral.AddParameterWithValueToSQLCommand("@UserName", bojDoctor.UserName);
                objGeneral.AddParameterWithValueToSQLCommand("@Password", bojDoctor.UserPassword);
                objGeneral.AddParameterWithValueToSQLCommand("@BasicDegree", bojDoctor.degrees);
                objGeneral.AddParameterWithValueToSQLCommand("@SpecialityID", bojDoctor.specialities);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", bojDoctor.ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@Intime", bojDoctor.Intime);
                objGeneral.AddParameterWithValueToSQLCommand("@Outtime", bojDoctor.Outtime);


                objGeneral.AddParameterWithValueToSQLCommand("@RegistrationNo", bojDoctor.RegistrationNo);
                objGeneral.AddParameterWithValueToSQLCommand("@RegistrationImageUrl", bojDoctor.RegistrationImageUrl);
                objGeneral.AddParameterWithValueToSQLCommand("@IdentityPolicyNo", bojDoctor.IdentityPolicyNo);
                objGeneral.AddParameterWithValueToSQLCommand("@IdentityPolicyImageUrl", bojDoctor.IdentityPolicyImageUrl);
                objGeneral.AddParameterWithValueToSQLCommand("@DegreeUpload1", bojDoctor.DegreeUpload1);
                objGeneral.AddParameterWithValueToSQLCommand("@DegreeUpload2", bojDoctor.DegreeUpload2);

                if (bojDoctor.DoctorID > 0)
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);

                }
                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("sp_AddDoctorProfile");

            }
            catch (Exception ex)
            {

            }
            return isInserted;
        }

        public int Add_DoctorsDoctorebyClinicDelete(int Did)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();
                
                strQuery = "Delete From DoctorByClinic where  DoctorID =@Did";

                objGeneral.AddParameterWithValueToSQLCommand("@Did", Did);
                
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;

            }
            catch (Exception ex)
            {

            }
            return isInserted;
        }



        public int Add_DoctorsDoctorebyClinic(int Cid, int Did)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery = "insert into DoctorByClinic (ClinicID ,DoctorID,UpdateID,Updatetime,IsActivr,IsDeactive) values (@ClinicID,@Did,1,GetDate(),1,1)";

                objGeneral.AddParameterWithValueToSQLCommand("@Did", Did);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);


                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;

            }
            catch (Exception ex)
            {

            }
            return isInserted;
        }

        public DataTable GetDoctersByClinicSelect(int DoctorID)
        {
            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select * from DoctorByClinic where  DoctorID=@DoctorID";
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public int Add_DoctorDegree(string Dname)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery = "insert into tbl_Doctor_Degree (Name) values ('" + Dname + "')";


                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                isInserted = 1;

            }
            catch (Exception ex)
            {

            }
            return isInserted;
        }





        public int Add_DoctorsUpdate(long DoctorID, string Intime, string Outtime)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();


                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@Intime", Intime);
                objGeneral.AddParameterWithValueToSQLCommand("@Outtime", Outtime);
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);


                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("sp_AddDoctorInOutTime");



            }
            catch (Exception ex)
            {

            }
            return isInserted;
        }

        public int DeleteDoctors(int DID)
        {
            int _isDeleted = -1;
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DID);
                ds = objGeneral.GetDatasetByCommand_SP("Get_Doctorinfo");
                _isDeleted = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public DataTable GetAllDocters(int Cid, int Did)
        {
            DataTable dt = new DataTable();
            try
            {

                strQuery = " Select *,L.UserName as LLUserName,L.Password as LLPassword from tbl_DoctorDetails D Join Login L on D.DoctorID = L.ClinicID   where L.RoleID  In (3)   and D.IsDeleted=0 ";
                if (Did > 0)
                    strQuery += " and D.DoctorID='" + Did + "'";
                if (Cid > 0)
                    strQuery += " and D.ClinicID='" + Cid + "'";

                strQuery += "  order by D.DoctorID desc";

                // objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetAllDoctersNew(int Cid, int Did, string Name, string MNo)
        {
            DataTable dt = new DataTable();
            try
            {
                // strQuery = "  Select * from tbl_DoctorDetails D left Join DoctorByClinic DC on DC.DoctorID = D.DoctorID where D.IsDeleted=0 ";
                strQuery = "  Select * from tbl_DoctorDetails D left Join DoctorByClinic DC on DC.DoctorID = D.DoctorID where D.IsDeleted=0 and DC.IsDeactive=1";

                // strQuery = "  Select * from tbl_DoctorDetails D  where D.IsDeleted=0 ";

                if (Did > 0)
                    strQuery += " and DC.DoctorID='" + Did + "'";
                if (Cid > 0)
                    strQuery += " and DC.ClinicID='" + Cid + "'";
                if (Name != "")
                    strQuery += " and D.FirstName like '%" + Name + "%'";
                if (MNo != "")
                    strQuery += " and D.Mobile1 like '%" + MNo + "%'";
                strQuery += "  order by D.DoctorID desc";

                // objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetAllDoctersNew2(int Cid, int Did, string Name, string MNo)
        {
            // strQuery = "  Select * from tbl_DoctorDetails D left Join DoctorByClinic DC on DC.DoctorID = D.DoctorID where D.IsDeleted=0 ";
            //strQuery = "  Select * from tbl_DoctorDetails D left Join DoctorByClinic DC on DC.DoctorID = D.DoctorID where D.IsDeleted=0 ";
            DataTable dt = new DataTable();
            try
            {
                strQuery = "  Select * from tbl_DoctorDetails D  where D.IsDeleted=0 ";

                if (Did > 0)
                    strQuery += " and D.DoctorID='" + Did + "'";
                if (Cid > 0)
                    strQuery += " and D.ClinicID='" + Cid + "'";
                if (Name != "")
                    strQuery += " and D.FirstName like '%" + Name + "%'";
                if (MNo != "")
                    strQuery += " and D.Mobile1 like '%" + MNo + "%'";
                strQuery += "  order by D.DoctorID desc";

                // objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public DataTable GetAllDoctersNew1(int Cid, int Did, string Name, string MNo)
        {
            //  strQuery = "  Select * from tbl_DoctorDetails D left Join DoctorByClinic DC on DC.DoctorID = D.DoctorID where D.IsDeleted=0 ";
            DataTable dt = new DataTable();
            try
            {
                strQuery = "  Select  DISTINCT  D.DoctorID,D.ProfileImageUrl,D.FirstName,D.LastName,D.Mobile1,D.Mobile2,D.Email,D.RegDate ";
                strQuery += "  from tbl_DoctorDetails D left Join DoctorByClinic DC on DC.DoctorID = D.DoctorID where D.IsDeleted=0 ";

                if (Did > 0)
                    strQuery += " and D.DoctorID='" + Did + "'";
                if (Cid > 0)
                    strQuery += " and DC.ClinicID='" + Cid + "'";
                if (Name != "")
                    strQuery += " and D.FirstName like '%" + Name + "%'";
                if (MNo != "")
                    strQuery += " and D.Mobile1 like '%" + MNo + "%'";
                strQuery += "  order by D.DoctorID desc";

                // objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public DataTable GetDoctersInouttime(long DoctorID)
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", 0);
                ds = objGeneral.GetDatasetByCommand_SP("Get_Doctorinfo");
            }
            catch (Exception ex)
            {

            }
            return ds.Tables[0];
        }


        public DataTable GetDocterstbl_Doctor_Degree(long DoctorID)
        {


            DataTable dt = new DataTable();
            try
            {
                strQuery = "Select * from tbl_DoctorByDegreeNew where DoctorID  ='" + DoctorID + "'";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
            // return ds.Tables[0];
        }

        public DataTable GetDocterstbl_DrSpeciality(long DoctorID)
        {

            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select * from tbl_DrSpeciality DS Join tbl_DoctorBySpeciality Dbs  on Dbs.SpecialityID=DS.SpecialityID where Dbs .DoctorID  ='" + DoctorID + "'";
                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

            // return ds.Tables[0];
        }



        public DataTable GetDoctorbyClinic(long DoctorID)
        {

            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select * from DoctorByClinic DC Join tbl_ClinicDetails C  on DC.ClinicID=C.ClinicID where DC .DoctorID  ='" + DoctorID + "'";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
            // return ds.Tables[0];
        }

        public DataTable GetDoctersDate_Collection(long DoctorID, string FromDate, string Todate, int Cid)
        {
            DataTable dt = new DataTable();
            try
            {

                strQuery = "Select  IM.PayDate,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName,DD.LastName,IM.PaidAmount from InvoiceMaster IM  Join PatientMaster PM on  PM.patientid =IM.patientid Join tbl_DoctorDetails DD on  IM.DoctorID =DD.DoctorID where PM.IsActive =1";

                if (DoctorID > 0)
                    strQuery += " and IM.DoctorID ='" + DoctorID + "'";

                if (Cid > 0)
                    strQuery += " and IM.ClinicID ='" + Cid + "'";

                if (FromDate != "" && Todate != "")
                    strQuery += " and convert(date,IM.PayDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";

                //objGeneral.AddParameterWithValueToSQLCommand("@FromDate", );
                //objGeneral.AddParameterWithValueToSQLCommand("@Todate",);

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;


        }



        public DataTable GetDoctersDate_Attendance(long DoctorID, string FromDate, string Todate, int Cid)
        {

            DataTable dt = new DataTable();
            try
            {
                strQuery = "Select * from tbl_DoctorDetails DD Join DoctorAttendance DA on DA.DoctorID = DD.DoctorID left join tbl_ClinicDetails C on DA.ClinicID = C.ClinicID where DD.IsActive =1";

                if (DoctorID > 0)
                    strQuery += " and DA.DoctorID ='" + DoctorID + "'";
                if (Cid > 0)
                    strQuery += " and DA.ClinicID ='" + Cid + "'";
                if (FromDate != "" && Todate != "")
                    strQuery += " and convert(date,DA.AttendanceDate,105) between convert(date,'" + Convert.ToDateTime(FromDate) + "',105) and convert(date,'" + Convert.ToDateTime(Todate) + "',105)";

                //objGeneral.AddParameterWithValueToSQLCommand("@FromDate", );
                //objGeneral.AddParameterWithValueToSQLCommand("@Todate",);

                dt = objGeneral.GetDatasetByCommand(strQuery);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

        public DataTable GetAllDoctersRevenue(long DoctorID, int Cid)
        {

            DataTable dt = new DataTable();
            try
            {
                strQuery = "SELECT DISTINCT COUNT(IM.patientid)  AS patientidCount, IM.DoctorID,DD.FirstName,DD.LastName,sum (IM.PaidAmount) as TotalSum from InvoiceMaster IM join tbl_DoctorDetails DD on  IM.DoctorID =DD.DoctorID ";

                if (DoctorID > 0)
                    strQuery += " and IM.DoctorID ='" + DoctorID + "'";
                if (Cid > 0)
                    strQuery += " and IM.ClinicID ='" + Cid + "'";

                strQuery += " Group by IM.DoctorID,DD.FirstName,DD.LastName";
                dt = objGeneral.GetDatasetByCommand(strQuery);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }


        public int GetDoctorsID()
        {

            try
            {
                strQuery = "Select isNull(MAX(DoctorID),1) from  tbl_DoctorDetails where IsDeleted =0";
                return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool InsertUpdateAddDoctor_Degree(DataTable dt)
        {

            strQuery = string.Empty;
            try
            {
                General objGeneral = new General();
                strQuery = "AddDoctor_Degree";


                objGeneral.AddParameterWithValueToSQLCommand("@TblSDoctorQualifcation", dt);
                objGeneral.GetExecuteNonQueryByCommand_SP(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDoctorByDegree(int DoctorID)
        {
            strQuery = string.Empty;
            try
            {
                General objGeneral = new General();

                strQuery = "Delete from tbl_DoctorByDegreeNew where DoctorID=" + DoctorID + " ";

                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public int GetDoctorsIsvelid(string Mno)
        {

            try
            {
                strQuery = "Select Count(*) from tbl_DoctorDetails  where Mobile1 ='" + Mno + "'";
                return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int SaveExcelUploadedDotor(int ClinicID, string RegDate, string FirstName, string LastName, string Email, string Mobile, string InTime, string OutTime)
        {

            int NewID = 0;
            try
            {
                General objGeneral = new General();




                strQuery = "INSERT INTO tbl_DoctorDetails (ClinicId,RegDate,FirstName,LastName,Email,Mobile1,InTime,OutTime,IsActive,IsDeleted)";
                strQuery += "VALUES (@ClinicID,@RegDate,@FirstName,@LastName,@Email,@Mobile,@InTime,@OutTime,1,0) ; Select @@IDENTITY ";


                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", LastName);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", Email);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@RegDate", objGeneral.getDatetime(Convert.ToDateTime(RegDate).ToString("dd-MM-yyyy")));

                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@InTime", Convert.ToDateTime(InTime).ToString("hh:mm tt"));

                objGeneral.AddParameterWithValueToSQLCommand("@OutTime", Convert.ToDateTime(OutTime).ToString("hh:mm tt"));



                NewID = int.Parse(objGeneral.GetExecuteScalarByCommand(strQuery));

                //  return true;
            }
            catch (Exception ex)
            {
                // return false;
            }

            return NewID;
        }



        public int SaveExcelUploadedDotorNew(int Cid, string RegDate, string FirstName, string LastName, string Email, string Mobile, string InTime, string OutTime)
        {

            int NewID = 0;
            try
            {
                General objGeneral = new General();




                strQuery = "INSERT INTO tbl_DoctorDetails (ClinicID,RegDate,FirstName,LastName,Email,Mobile1,InTime,OutTime,IsActive,IsDeleted)";
                strQuery += "VALUES (@Cid,@RegDate,@FirstName,@LastName,@Email,@Mobile,@InTime,@OutTime,1,0) ; Select @@IDENTITY ";


                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@Cid", Cid);

                objGeneral.AddParameterWithValueToSQLCommand("@LastName", LastName);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", Email);
                objGeneral.AddParameterWithValueToSQLCommand("@RegDate", objGeneral.getDatetime(RegDate));

                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@InTime", Convert.ToDateTime(InTime).ToString("hh:mm tt"));

                objGeneral.AddParameterWithValueToSQLCommand("@OutTime", Convert.ToDateTime(OutTime).ToString("hh:mm tt"));



                NewID = int.Parse(objGeneral.GetExecuteScalarByCommand(strQuery));

                //  return true;
            }
            catch (Exception ex)
            {
                // return false;
            }

            return NewID;
        }









        public int SaveExcelUploadedLoginDotor(string UserName, string Password, int Did)
        {

            int NewID = 0;
            try
            {
                General objGeneral = new General();




                strQuery = "INSERT INTO Login (UserName,Password,RoleID,IsActive,ClinicID)";
                strQuery += "VALUES (@UserName,@Password,3,1,@Did) ; Select @@IDENTITY ";


                objGeneral.AddParameterWithValueToSQLCommand("@UserName", UserName);
                objGeneral.AddParameterWithValueToSQLCommand("@Password", Password);
                objGeneral.AddParameterWithValueToSQLCommand("@Did", Did);




                NewID = int.Parse(objGeneral.GetExecuteScalarByCommand(strQuery));

                //  return true;
            }
            catch (Exception ex)
            {
                // return false;
            }

            return NewID;
        }


        public int SaveDoctorAttendanceIntime(int ClinicID, int DoctorID, string TimeIn, string AttendanceDate)
        {

            int NewID = 0;
            try
            {
                General objGeneral = new General();

                strQuery = "INSERT INTO DoctorAttendance (ClinicID,DoctorID,TimeIn,AttendanceDate,IsActive,Fid)";
                strQuery += "VALUES (@ClinicID,@DoctorID,@TimeIn,@AttendanceDate,1,1) ; Select @@IDENTITY ";


                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@TimeIn", TimeIn);
                objGeneral.AddParameterWithValueToSQLCommand("@AttendanceDate", objGeneral.getDatetime(AttendanceDate));


                NewID = int.Parse(objGeneral.GetExecuteScalarByCommand(strQuery));


            }
            catch (Exception ex)
            {
                // return false;
            }

            return NewID;
        }



        public int SaveDoctorAttendanceOuttime(int ClinicID, int DoctorID, string TimeOut, string AttendanceDate)
        {

            int NewID = 0;
            try
            {
                General objGeneral = new General();

                // strQuery = "Update DoctorAttendance set TimeOut =@TimeOut where ClinicID=@ClinicID and DoctorID=@DoctorID and convert(date,AttendanceDate,105) =@AttendanceDate";

                strQuery = "Update DoctorAttendance set TimeOut =@TimeOut,Fid=0 where ClinicID=@ClinicID and DoctorID=@DoctorID  and TimeOut Is null and Fid=1";


                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@TimeOut", TimeOut);
                objGeneral.AddParameterWithValueToSQLCommand("@AttendanceDate", objGeneral.getDatetime(AttendanceDate));
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                NewID = 1;
            }
            catch (Exception ex)
            {
                // return false;
            }

            return NewID;
        }



        public DataTable GetDocInTimeOutTime(int Cid, int Did)
        {
            try
            {
                string strQuery = string.Empty;
                General objGeneral = new General();

                strQuery = "select Top 1 CONVERT(VARCHAR(10), AttendanceDate, 105) as AtdnDate,TimeIn,TimeOut,ClinicID from DoctorAttendance where ClinicID=@ClinicID and DoctorID=@DoctorID and TimeIn IS Not NULL order by AttendanceId DESC";
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                DataTable dt = objGeneral.GetDatasetByCommand(strQuery);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetDocInTimeOutTimeNew(int Cid, int Did)
        {
            try
            {
                string strQuery = string.Empty;
                General objGeneral = new General();

                strQuery = "select Top 1 CONVERT(VARCHAR(10), AttendanceDate, 105) as AtdnDate,TimeIn,TimeOut,ClinicID from DoctorAttendance where  DoctorID=@DoctorID and TimeIn IS Not NULL  and Fid=1 order by AttendanceId DESC";
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                DataTable dt = objGeneral.GetDatasetByCommand(strQuery);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetDocInTimeOutDetails(int Cid, int Did)
        {
            try
            {
                string strQuery = string.Empty;
                General objGeneral = new General();

                strQuery = "select Top 1 CONVERT(VARCHAR(10), AttendanceDate, 105) as AtdnDate,TimeIn,TimeOut,ClinicID from DoctorAttendance where ClinicID=@ClinicID and DoctorID=@DoctorID and TimeOut IS Not NULL order by AttendanceId DESC";
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", Did);
                DataTable dt = objGeneral.GetDatasetByCommand(strQuery);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}