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
                    objGeneral.AddParameterWithValueToSQLCommand("@DateBirth", objGeneral.getDatetime(bojpatient.DateBirth));
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


        public int GetPatientssIsvelid(string Mno)
        {

            try
            {
                string strQuery = "Select Count(*) from PatientMaster  where Mobile ='" + Mno + "'";
                return Convert.ToInt32(objGeneral.GetExecuteScalarByCommand(strQuery));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public int SaveExcelUploadedPatient(string Pcode, string FirstName, string LastName, string Email, string Mobile, string BirthDate)
        {

            int NewID = 0;
            try
            {
                General objGeneral = new General();




                string strQuery = "INSERT INTO PatientMaster (PatientCode,FristName,LastName,Email,Mobile,BOD,IsActive)";
                strQuery += "VALUES (@PatientCode,@FirstName,@LastName,@Email,@Mobile,@BirthDate,1) ; Select @@IDENTITY ";


                objGeneral.AddParameterWithValueToSQLCommand("@FirstName", FirstName);
                objGeneral.AddParameterWithValueToSQLCommand("@LastName", LastName);
                objGeneral.AddParameterWithValueToSQLCommand("@Email", Email);
                objGeneral.AddParameterWithValueToSQLCommand("@BirthDate", Convert.ToDateTime(BirthDate));

                objGeneral.AddParameterWithValueToSQLCommand("@Mobile", Mobile);
                objGeneral.AddParameterWithValueToSQLCommand("@PatientCode", Pcode);


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
    }
}