using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class BAL_Patient
    {

        General objGeneral = new General();
        DataSet ds = new DataSet();

        private string strQuery = string.Empty;
        public int Add_PatientMH(Patient_Details bojpatient)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                string Duedate;
                if (bojpatient.DueDate == "")
                {

                    Duedate = "1990-01-01";
                }
                else
                {

                    Duedate = Convert.ToDateTime(bojpatient.DueDate).ToString("yyyy-MM-dd");
                }


                objGeneral.AddParameterWithValueToSQLCommand("@patientid", bojpatient.patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryId", bojpatient.EnquiryId);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", bojpatient.ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@PatientCode", bojpatient.PatientCode);
                objGeneral.AddParameterWithValueToSQLCommand("@RegistrationDate", Convert.ToDateTime(bojpatient.RegistrationDate));
                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", bojpatient.FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", bojpatient.LastName);
                objGeneral.AddParameterWithValueToSQLCommand("@DateBirth", Convert.ToDateTime(bojpatient.DateBirth).ToString("yyyy-MM-dd"));
                objGeneral.AddParameterWithValueToSQLCommand("@Age", bojpatient.Age);
                objGeneral.AddParameterWithValueToSQLCommand("@BloodGroup", bojpatient.boolgroup);
                objGeneral.AddParameterWithValueToSQLCommand("@Gender", bojpatient.Gender);
                objGeneral.AddParameterWithValueToSQLCommand("@Address", bojpatient.Address);
                objGeneral.AddParameterWithValueToSQLCommand("@CountryId", bojpatient.CountryId);
                objGeneral.AddParameterWithValueToSQLCommand("@stateid", bojpatient.stateid);
                objGeneral.AddParameterWithValueToSQLCommand("@Cityid", bojpatient.Cityid);
                objGeneral.AddParameterWithValueToSQLCommand("@Area", bojpatient.Area);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", bojpatient.Email);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", bojpatient.Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@Telephone", bojpatient.Telephone);
                objGeneral.AddParameterWithValueToSQLCommand("@CreatedBy", bojpatient.CreatedBy);
                objGeneral.AddParameterWithValueToSQLCommand("@ModifiedBy", bojpatient.ModifiedBy);
                objGeneral.AddParameterWithValueToSQLCommand("@IsActive", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicalProblem", bojpatient.MedicalProblem);
                objGeneral.AddParameterWithValueToSQLCommand("@Allergic", bojpatient.Allergic);

                objGeneral.AddParameterWithValueToSQLCommand("@Pregnant", bojpatient.Pregnant);

                objGeneral.AddParameterWithValueToSQLCommand("@DueDate", Duedate);


                objGeneral.AddParameterWithValueToSQLCommand("@PanMasalaChewing", bojpatient.PanMasalaChewing);

                objGeneral.AddParameterWithValueToSQLCommand("@Tobacco", bojpatient.Tobacco);

                objGeneral.AddParameterWithValueToSQLCommand("@Somking", bojpatient.Somking);

                objGeneral.AddParameterWithValueToSQLCommand("@cigrattesInDay", bojpatient.cigrattesInDay);

                objGeneral.AddParameterWithValueToSQLCommand("@ListofMedicine", bojpatient.ListofMedicine);




                objGeneral.AddParameterWithValueToSQLCommand("@DrAddress", bojpatient.DrAddress);

                objGeneral.AddParameterWithValueToSQLCommand("@FamilyDoctorName", bojpatient.FamilyDoctorName);

                objGeneral.AddParameterWithValueToSQLCommand("@Complaint", bojpatient.Complaint);

                objGeneral.AddParameterWithValueToSQLCommand("@DentalTreatment", bojpatient.DentalTreatment);

                objGeneral.AddParameterWithValueToSQLCommand("@ConsentStatement", bojpatient.ConsentStatement);


                objGeneral.AddParameterWithValueToSQLCommand("@UserName", bojpatient.UserName);

                objGeneral.AddParameterWithValueToSQLCommand("@Password", bojpatient.Password);


                objGeneral.AddParameterWithValueToSQLCommand("@mode", 3);

                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_ADDPatient");
            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }




        public int Add_Patient(Patient_Details bojpatient)
        {
            int isInserted = -1;
            try
            {
                General objGeneral = new General();

                DateTime Duedate;
                if (bojpatient.DueDate == "")
                {

                    Duedate = objGeneral.getDatetime("01-01-1990");
                }
                else
                {

                    Duedate = objGeneral.getDatetime(bojpatient.DueDate);
                }



                objGeneral.AddParameterWithValueToSQLCommand("@patientid", bojpatient.patientid);
                objGeneral.AddParameterWithValueToSQLCommand("@EnquiryId", bojpatient.EnquiryId);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", bojpatient.ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@PatientCode", bojpatient.PatientCode);
                objGeneral.AddParameterWithValueToSQLCommand("@RegistrationDate", objGeneral.getDatetime(bojpatient.RegistrationDate));
                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", bojpatient.FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", bojpatient.LastName);
                //Dhaval
                if (Convert.ToString(bojpatient.DateBirth) == "")
                {

                    objGeneral.AddParameterWithValueToSQLCommand("@DateBirth", DBNull.Value);
                }
                else
                {
                    //objGeneral.AddParameterWithValueToSQLCommand("@DateBirth", objGeneral.getDatetime(bojpatient.DateBirth));
                    objGeneral.AddParameterWithValueToSQLCommand("@DateBirth", bojpatient.DateBirth);

                }
                objGeneral.AddParameterWithValueToSQLCommand("@Age", bojpatient.Age);
                objGeneral.AddParameterWithValueToSQLCommand("@BloodGroup", bojpatient.boolgroup);
                objGeneral.AddParameterWithValueToSQLCommand("@Gender", bojpatient.Gender);
                objGeneral.AddParameterWithValueToSQLCommand("@Address", bojpatient.Address);
                objGeneral.AddParameterWithValueToSQLCommand("@CountryId", bojpatient.CountryId);
                objGeneral.AddParameterWithValueToSQLCommand("@stateid", bojpatient.stateid);
                objGeneral.AddParameterWithValueToSQLCommand("@Cityid", bojpatient.Cityid);
                objGeneral.AddParameterWithValueToSQLCommand("@Area", bojpatient.Area);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", bojpatient.Email);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", bojpatient.Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@Telephone", bojpatient.Telephone);
                objGeneral.AddParameterWithValueToSQLCommand("@CreatedBy", bojpatient.CreatedBy);
                objGeneral.AddParameterWithValueToSQLCommand("@ModifiedBy", bojpatient.ModifiedBy);
                objGeneral.AddParameterWithValueToSQLCommand("@ProfileImage", bojpatient.ProfileImage);
                objGeneral.AddParameterWithValueToSQLCommand("@IsActive", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@MedicalProblem", bojpatient.MedicalProblem);
                objGeneral.AddParameterWithValueToSQLCommand("@Allergic", bojpatient.Allergic);
                objGeneral.AddParameterWithValueToSQLCommand("@Pregnant", bojpatient.Pregnant);
                objGeneral.AddParameterWithValueToSQLCommand("@DueDate", Duedate);

                objGeneral.AddParameterWithValueToSQLCommand("@PanMasalaChewing", bojpatient.PanMasalaChewing);

                objGeneral.AddParameterWithValueToSQLCommand("@Tobacco", bojpatient.Tobacco);

                objGeneral.AddParameterWithValueToSQLCommand("@Somking", bojpatient.Somking);

                objGeneral.AddParameterWithValueToSQLCommand("@cigrattesInDay", bojpatient.cigrattesInDay);

                objGeneral.AddParameterWithValueToSQLCommand("@ListofMedicine", bojpatient.ListofMedicine);

                objGeneral.AddParameterWithValueToSQLCommand("@Nooftooth", bojpatient.Nooftooth);


                objGeneral.AddParameterWithValueToSQLCommand("@DrAddress", bojpatient.DrAddress);

                objGeneral.AddParameterWithValueToSQLCommand("@FamilyDoctorName", bojpatient.FamilyDoctorName);

                objGeneral.AddParameterWithValueToSQLCommand("@Complaint", bojpatient.Complaint);

                objGeneral.AddParameterWithValueToSQLCommand("@DentalTreatment", bojpatient.DentalTreatment);

                objGeneral.AddParameterWithValueToSQLCommand("@ConsentStatement", bojpatient.ConsentStatement);

                objGeneral.AddParameterWithValueToSQLCommand("@UserName", bojpatient.UserName);

                objGeneral.AddParameterWithValueToSQLCommand("@Password", bojpatient.Password);
                objGeneral.AddParameterWithValueToSQLCommand("@ConsentParth", bojpatient.ConsentParth);

                objGeneral.AddParameterWithValueToSQLCommand("@CaseFileNo", bojpatient.CaseFileNo);

                if (bojpatient.patientid > 0)
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                }
                else
                {
                    objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                }

                isInserted = objGeneral.GetExecuteNonQueryByCommand_SP("SP_ADDPatient");



            }
            catch (Exception ex)
            {
            }
            return isInserted;
        }


        public int GetPaisantID()
        {

            try
            {
                string strQuery = "Select isNull(MAX(patientid)+1,1) from  PatientMaster where IsActive =1";
                return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetPatient(int patientid)
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 1);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid);
                ds = objGeneral.GetDatasetByCommand_SP("GET_PatientDetails");


            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];

        }

        public DataTable GetPatientlist()
        {
            try
            {
                objGeneral.AddParameterWithValueToSQLCommand("@mode", 4);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", 0);
                ds = objGeneral.GetDatasetByCommand_SP("GET_PatientDetails");
            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }


        public DataTable NewGetPatientlist(int Cid)
        {

            strQuery = " Select *,P.FristName+' '+ isnull(p.LastName,'')  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1";

            if (Cid > 0)
                strQuery += " and P.ClinicID ='" + Cid + "'";
            strQuery += "order by patientid DESC ";
            return objGeneral.GetDatasetByCommand(strQuery);



        }


        public DataTable PatientSelectDoctorID(string PatientName)
        {
            DataTable dt = new DataTable();
            try
            {
                General objGeneral = new General();


                strQuery = "Select *,P.FristName+' '+ isnull(p.LastName,'')  +'  ('+P.Mobile +')', patientid from PatientMaster p where  IsActive =1 ";
                strQuery += " and P.FristName+' '+ isnull(p.LastName,'')  +'  ('+P.Mobile +')' like '%" + PatientName + "%'";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable PatientSelect(string PatientName)
        {
            DataTable dt = new DataTable();
            try
            {
                General objGeneral = new General();


                strQuery = "Select *,P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')', patientid from PatientMaster p where  IsActive =1 ";
                strQuery += " and P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' like '%" + PatientName + "%'";

                dt = objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable NewGetPatientlistSearch(string PatientName)
        {

            strQuery = " Select *,P.FristName+' '+ isnull(p.LastName,'')  +'  ( '+P.Mobile +' )' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1";

            strQuery += " and  P.FristName+' '+ isnull(p.LastName,'')  +'  ('+P.Mobile +')'  like  '%" + PatientName + "%'";
            strQuery += "order by patientid DESC ";
            return objGeneral.GetDatasetByCommand(strQuery);



        }

        public DataTable NewGetPatientlistMonth(string Cid)
        {

            strQuery = " Select *,P.FristName +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId ";
            strQuery += "  left join tbl_ClinicDetails CD on CD.ClinicId = P.ClinicId  where P.IsActive =1  and  month(RegistrationDate) = month(GETDATE())  and   Year(RegistrationDate) = Year(GETDATE())";

            if (Cid != "")
            {
                string ASD = "(" + Cid + ")";
                strQuery += " and P.ClinicID in " + ASD + "";
            }
            strQuery += "order by patientid DESC ";
            return objGeneral.GetDatasetByCommand(strQuery);



        }


        public DataTable GetAllPatientRecordReport(string FromDate, string Todate, string ClinicID,string Mobile,string PatientCode, int patientid)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@PatientCode", PatientCode);
                objGeneral.AddParameterWithValueToSQLCommand("@PatiletId", patientid);

                ds = objGeneral.GetDatasetByCommand_SP("GET_PatientReport");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }

        public DataTable NewGetPatientlist1(string Cid)
        {

            strQuery = " Select *,P.FristName +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId ";
            strQuery += "  left join tbl_ClinicDetails CD on CD.ClinicId = P.ClinicId  where P.IsActive =1";

            if (Cid != "")
            {
                string ASD = "(" + Cid + ")";
                strQuery += " and P.ClinicID in " + ASD + "";
            }
            strQuery += "order by patientid DESC ";
            return objGeneral.GetDatasetByCommand(strQuery);



        }

        public DataTable GETPatientSelect(int Paid)
        {

            strQuery = " Select *,P.FristName+' '+ isnull(p.LastName,'')  +'  ( '+P.Mobile +' )'  as Fname from PatientMaster P  where  Patientid=" + Paid + "";



            return objGeneral.GetDatasetByCommand(strQuery);



        }


        public DataTable DoctorByClinicLIST(int Did)
        {

            strQuery = " Select *  from DoctorByClinic where DoctorID='" + Did + "'";

            return objGeneral.GetDatasetByCommand(strQuery);



        }







        public DataTable NewGetPatientlist11(int Cid)
        {

            strQuery = " Select PatientCode,RegistrationDate,FristName +' '+LastName as Name ,Gender,BOD,BloodGroup,Age,Address+' '+Area as Address,Email,Mobile,Telephone  from PatientMaster  where  IsActive =1";

            if (Cid > 0)
                strQuery += " and ClinicID ='" + Cid + "'";
            strQuery += "order by patientid DESC ";
            return objGeneral.GetDatasetByCommand(strQuery);



        }

        public int DeletePatient(int PID)
        {
            int _isDeleted = -1;
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 2);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", PID);

                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("GET_PatientDetails");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }

        public int EnquiryToPatient(int PID)
        {
            int _isDeleted = -1;
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 6);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", PID);

                _isDeleted = objGeneral.GetExecuteNonQueryByCommand_SP("GET_PatientDetails");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _isDeleted;
        }


        public DataTable GetMedicalHistoryDetails(long patientid)
        {
            try
            {

                objGeneral.AddParameterWithValueToSQLCommand("@mode", 5);
                objGeneral.AddParameterWithValueToSQLCommand("@patientid", patientid);
                ds = objGeneral.GetDatasetByCommand_SP("GET_PatientDetails");


            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];

        }


        public int GetPatientssIsvelid(string Mno, string Fname)
        {

            try
            {
                string strQuery = "Select Count(*) from PatientMaster  where Mobile ='" + Mno + "' and FristName='" + Fname + "'";
                return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //public int GetPatientssIsvelidNew(string Mno, string Fname)
        //{

        //    try
        //    {
        //        string strQuery = "Select PM.FristName+' '+PM.LastName [PatienntName],Cd.ClinicName From PatientMaster PM " +
        //            " join tbl_ClinicDetails Cd on Cd.ClinicID=PM.ClinicID   where PM.Mobile ='" + Mno + "' and PM.FristName='" + Fname + "'";
        //        return Convert.ToInt32(objGeneral.GetDatasetByCommand(strQuery));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        public DataTable GetPatientssIsvelidNew(string Mno, string Fname)
        {
            try
            {
                string strQuery = "Select PM.FristName+' '+PM.LastName [PatienntName],Cd.ClinicName From PatientMaster PM " +
                     " join tbl_ClinicDetails Cd on Cd.ClinicID=PM.ClinicID   where PM.Mobile ='" + Mno + "' and PM.FristName='" + Fname + "'";
                return objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public int SaveExcelUploadedPatient(string Pcode, string FirstName, string LastName, string Email, string Mobile, string BirthDate, int ClinicID)
        {

            int NewID = 0;
            try
            {
                General objGeneral = new General();




                string strQuery = "INSERT INTO PatientMaster (PatientCode,ClinicID,FristName,LastName,Email,Mobile,CountryId,Cityid,stateid,IsActive)";
                strQuery += "VALUES (@PatientCode,@ClinicID,@FirstName,@LastName,@Email,@Mobile,@CountryId,@Cityid,@stateid,1) ; Select @@IDENTITY ";


                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", LastName);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", Email);
                // objGeneral.AddParameterWithValueToSQLCommand("@BirthDate", Convert.ToDateTime(BirthDate));

                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@PatientCode", Pcode);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);

                objGeneral.AddParameterWithValueToSQLCommand("@CountryId", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@Cityid", 0);
                objGeneral.AddParameterWithValueToSQLCommand("@stateid", 0);


                NewID = int.Parse(objGeneral.GetExecuteScalarByCommand(strQuery));

                //  return true;
            }
            catch (Exception ex)
            {
                // return false;
            }

            return NewID;
        }


        public DataTable GetPatientDetils(long PID)
        {



            string strQuery = "Select * from PatientMaster  where patientid  ='" + PID + "'";

            return objGeneral.GetDatasetByCommand(strQuery);


        }

        public DataTable GetPatientMedicalHistory(long PID)
        {



            string strQuery = "Select * from PatientMedicalHistory  where patientid  ='" + PID + "'";

            return objGeneral.GetDatasetByCommand(strQuery);


        }


        public DataTable GetPatientMedicalProblem(long PID)
        {



            string strQuery = " Select * from MedicalProblem mp join PatientbyMedicalProblem pbm on pbm.MedicalProid=mp.MedicalProid  where pbm.patientid  ='" + PID + "'";

            return objGeneral.GetDatasetByCommand(strQuery);


        }

        public DataTable GetPatientbyAllergic(long PID)
        {



            string strQuery = " Select * from AllergicMaster mp join PatientbyAllergic pbm on pbm.allergicId=mp.allergicId  where pbm.patientid  ='" + PID + "'";

            return objGeneral.GetDatasetByCommand(strQuery);


        }

        public DataTable GetPatientbyDentalinfo(long PID)
        {



            string strQuery = " Select * from PatientbyDentalinfo where  patientid  ='" + PID + "'";

            return objGeneral.GetDatasetByCommand(strQuery);


        }

        public DataTable GetPatientInvoiceNo(int PatientId)
        {
            try
            {
                General objGeneral = new General();

                objGeneral.AddParameterWithValueToSQLCommand("@PatientId", PatientId);
                objGeneral.AddParameterWithValueToSQLCommand("@Mode", 1);

                ds = objGeneral.GetDatasetByCommand_SP("Get_PatientInvoiceNo");

            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }

        public DataTable GetPatientInvoiceDetsils(int PatientId)
        {
            try
            {


                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@PatientId", PatientId);
                objGeneral.AddParameterWithValueToSQLCommand("@Mode", 2);
                ds = objGeneral.GetDatasetByCommand_SP("Get_PatientInvoiceNo");


            }
            catch (Exception ex)
            {
            }
            return ds.Tables[0];
        }



        public DataTable GetPatientDetailsReport(string FromDate, string Todate, int ClinicID, int DoctorsID, string Mode)
        {
            try
            {
                General objGeneral = new General();
                objGeneral.AddParameterWithValueToSQLCommand("@FromDate", FromDate);
                objGeneral.AddParameterWithValueToSQLCommand("@Todate", Todate);
                objGeneral.AddParameterWithValueToSQLCommand("@ClinicID", ClinicID);
                objGeneral.AddParameterWithValueToSQLCommand("@DoctorsID", DoctorsID);

                objGeneral.AddParameterWithValueToSQLCommand("@mode", Mode);



                ds = objGeneral.GetDatasetByCommand_SP("GET_PatientNewAndOldDetailsReport");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ds.Tables[0];
        }


    }



}