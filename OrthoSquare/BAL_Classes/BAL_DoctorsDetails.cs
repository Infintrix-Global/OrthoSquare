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
                objGeneral.AddParameterWithValueToSQLCommand("@DOB", objGeneral.getDatetime(bojDoctor.BirthDate));
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


        public int Add_DoctorsDoctorebyClinic(int Cid,int Did)
        {
            int isInserted = -1;
            try
            {

                General objGeneral = new General();

                strQuery ="insert into DoctorByClinic (ClinicID ,DoctorID,UpdateID,Updatetime,IsActivr) values (@ClinicID,@Did,1,GetDate(),1)";

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


                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID",DoctorID);
                objGeneral.AddParameterWithValueToSQLCommand("@Intime",Intime);
                objGeneral.AddParameterWithValueToSQLCommand("@Outtime",Outtime);
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


        public DataTable GetAllDocters(int Cid)
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorID", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", Cid);
                
                ds = objGeneral.GetDatasetByCommand_SP("Get_Doctorinfo");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
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



            strQuery = "Select * from tbl_DoctorByDegree  DBD LEFT JOIN  tbl_Doctor_Degree DD on DD.DegreeID =DBD.DegreeID  where DoctorID  ='" + DoctorID + "'";

                return objGeneral.GetDatasetByCommand(strQuery);
          
           // return ds.Tables[0];
        }

        public DataTable GetDocterstbl_DrSpeciality(long DoctorID)
        {



            strQuery = "Select * from tbl_DrSpeciality DS Join tbl_DoctorBySpeciality Dbs  on Dbs.SpecialityID=DS.SpecialityID where Dbs .DoctorID  ='" + DoctorID + "'";

            return objGeneral.GetDatasetByCommand(strQuery);

            // return ds.Tables[0];
        }



        public DataTable GetDoctorbyClinic(long DoctorID)
        {



            strQuery = "Select * from DoctorByClinic DC Join tbl_ClinicDetails C  on DC.ClinicID=C.ClinicID where DC .DoctorID  ='" + DoctorID + "'";

            return objGeneral.GetDatasetByCommand(strQuery);

            // return ds.Tables[0];
        }

        public DataTable GetDoctersDate_Collection(long DoctorID, string FromDate, string Todate)
        {
          

                strQuery = "Select  IM.PayDate,PM.FristName as PFristName,PM.LastName as PLastName,DD.FirstName,DD.LastName,IM.PaidAmount from InvoiceMaster IM  Join PatientMaster PM on  PM.patientid =IM.patientid Join tbl_DoctorDetails DD on  IM.DoctorID =DD.DoctorID where PM.IsActive =1";

                if (DoctorID > 0)
                    strQuery += " and IM.DoctorID ='" + DoctorID + "'";
                if (FromDate != "" && Todate != "")
                    strQuery += " and convert(date,IM.PayDate,105) between convert(date,'"+Convert .ToDateTime(FromDate)+"',105) and convert(date,'"+ Convert .ToDateTime(Todate)+"',105)";

                //objGeneral.AddParameterWithValueToSQLCommand("@FromDate", );
                //objGeneral.AddParameterWithValueToSQLCommand("@Todate",);

                return objGeneral.GetDatasetByCommand(strQuery);

          
          
        }


        public DataTable GetAllDoctersRevenue(long DoctorID)
        {


            strQuery = "SELECT DISTINCT COUNT(IM.patientid)  AS patientidCount, IM.DoctorID,DD.FirstName,DD.LastName,sum (IM.PaidAmount) as TotalSum from InvoiceMaster IM join tbl_DoctorDetails DD on  IM.DoctorID =DD.DoctorID ";

            if (DoctorID > 0)
                strQuery += " and IM.DoctorID ='" + DoctorID + "'";

            strQuery += " Group by IM.DoctorID,DD.FirstName,DD.LastName";
            return objGeneral.GetDatasetByCommand(strQuery);

        }


        public int GetDoctorsID()
        {
           
            try
            {
                strQuery = "Select MAX(DoctorID) from  tbl_DoctorDetails where IsDeleted =0";
                return Convert .ToInt32 (objGeneral.GetExecuteScalarByCommand(strQuery));
            }
            catch (Exception ex)
            {
                throw ex;
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

        public int SaveExcelUploadedDotor(string RegDate, string FirstName, string LastName, string Email, string Mobile, string InTime, string OutTime)
        {

            int NewID=0;
            try
            {
                General objGeneral = new General();




                strQuery = "INSERT INTO tbl_DoctorDetails (RegDate,FirstName,LastName,Email,Mobile1,InTime,OutTime,IsDeleted)";
                strQuery += "VALUES (@RegDate,@FirstName,@LastName,@Email,@Mobile,@InTime,@OutTime,0) ; Select @@IDENTITY ";

               
                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", LastName);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", Email);
                objGeneral.AddParameterWithValueToSQLCommand("@RegDate", Convert.ToDateTime(RegDate));

                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@InTime", Convert .ToDateTime(InTime).ToString ("hh:mm tt"));

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

    }
}