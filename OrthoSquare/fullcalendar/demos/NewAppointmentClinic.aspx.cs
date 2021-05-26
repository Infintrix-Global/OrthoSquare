using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Globalization;
using OrthoSquare.Utility;
using OrthoSquare.BAL_Classes;
using System.Data;
namespace OrthoSquare.Master
{
    public partial class NewAppointmentClinic : System.Web.UI.Page
    {
        string a="";

        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Appointment objApp = new BAL_Appointment();
        BAL_Patient objPatient = new BAL_Patient();
        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblDate.Text = TextBox1.Text;
           
            if(!IsPostBack )
            {

                ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));
               // bindDoctorMaster();
                bindClinic();

                if (SessionUtilities.RoleID == 1)
                {
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    bindDoctorMaster(SessionUtilities.Empid);
                }
            }

           

        }


     

        public void bindDoctorMaster(int Cid)
        {

            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {
                ddlDocter.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);

               // bindDoctorMaster(SessionUtilities.UserID, SessionUtilities.RoleID);

            }
            else
            {
                ddlDocter.DataSource = objcommon.DoctersMasterNewENQ11(Cid, SessionUtilities.RoleID);
              //  bindDoctorMaster(0, SessionUtilities.RoleID);
            }

            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "FirstName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }


        public void bindClinic()
        {


            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);
            }
            else if (SessionUtilities.RoleID == 1)
            {
                dt = objc.GetAllClinicDetaisNew(SessionUtilities.Empid);
            }
            else
            {
                dt = objc.GetAllClinicDetais();

            }
            ddlClinic.DataSource = dt;

           // ddlClinic.DataSource = objc.GetAllClinicDetais();
            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        [WebMethod]
        public static String TestOnWebService(string Docterid, string Docterid1)
        {

            General objg = new General();
            String query = "";
            String connectionString = WebConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);

            myConnection.Open();
            if (Docterid == "0")
            {
                if (SessionUtilities.RoleID == 2)
                {
                    query = "SELECT * FROM AppointmentMaster A  Join tbl_ClinicDetails C on C.ClinicID =A.ClinicID where  Year (CreatedDate) =Year(GETDATE())";
                }
               else if (SessionUtilities.RoleID == 1)
                {
                    query = "SELECT * FROM AppointmentMaster A left Join tbl_ClinicDetails C on C.ClinicID =A.ClinicID where A.ClinicID=" + SessionUtilities .Empid + " and Year (CreatedDate) =Year(GETDATE()) Or A.IsActive =0";

                }
                else
               {

                   query = "SELECT * FROM AppointmentMaster A left Join tbl_ClinicDetails C on C.ClinicID =A.ClinicID where A.DoctorID=" + SessionUtilities.Empid + " and Year (CreatedDate) =Year(GETDATE()) Or A.IsActive =0";

               }
            }
            else
            {
                // string strQ = "SELECT * FROM AppointmentMaster where DoctorID='" + Docterid + "'";

                // DataTable dt = objg.GetDatasetByCommand(strQ);

                // if(dt != null && dt.Rows.Count )


                query = "SELECT * FROM AppointmentMaster A left Join tbl_ClinicDetails C on C.ClinicID =A.ClinicID where A.DoctorID='" + Docterid + "' and Year (CreatedDate) =Year(GETDATE()) Or A.IsActive =0";
            }
            SqlCommand cmd = new SqlCommand(query, myConnection);

            SqlDataReader reader = cmd.ExecuteReader();


            string myJsonString = "";
            string json = "";
            List<object> myList = new List<object>();


            if (reader.HasRows)
            {
                var indexOfId = reader.GetOrdinal("Appointmentid");
                // var indexOfLecture = reader.GetOrdinal("FirstName") +'('+ reader.GetOrdinal("ClinicName") +')';
                var indexOfLecture = reader.GetOrdinal("FirstName");
                var indexOfStartDate = reader.GetOrdinal("start_date");
                var indexOfEndDate = reader.GetOrdinal("end_date");
                var indexOfTimeStart = reader.GetOrdinal("start_time");
                var indexOfTimeEnd = reader.GetOrdinal("end_time");
                var ClinicID = reader.GetOrdinal("ClinicID");

                while (reader.Read())
                {




                    var Id = reader.GetValue(indexOfId).ToString();
                    var Lecture = reader.GetValue(indexOfLecture).ToString() + " ("+ reader.GetValue(ClinicID).ToString() + ")";
                    var DateStart = reader.GetValue(indexOfStartDate).ToString();
                    var DateEnd = reader.GetValue(indexOfEndDate).ToString();
                    var StartTime = reader.GetValue(indexOfTimeStart);
                    var EndTime = reader.GetValue(indexOfTimeEnd);


                    //Convert Implicity typed var to Date Time
                    DateTime RealStartDate = Convert.ToDateTime(DateStart);
                    DateTime RealEndDate = Convert.ToDateTime(DateEnd);


                    //Convert Date Time to ISO
                    String SendStartDate = RealStartDate.ToString("s");
                    String SendEndDate = RealEndDate.ToString("s");

                   
                    timeTable t_table = new timeTable(Id, Lecture, SendStartDate, SendEndDate);


                    myList.Add(t_table);


                   


                }
                myJsonString = (new JavaScriptSerializer()).Serialize(myList);



                JavaScriptSerializer jss = new JavaScriptSerializer();
                 json = jss.Serialize(myList);

               // Response.Write(json);
               // Response.End();
                 if (Docterid1 != "")
                 {

                    // Response.Redirect("~/Master/BookAppointment.aspx?DateTime='" + Docterid1 + "'");

                     HttpContext.Current.Response.Redirect("~/Master/BookAppointment.aspx?DateTime='" + Docterid1 + "'");
                 }


                myConnection.Close();
            }

            return json;

        }

        public class timeTable
        {
            public String id { get; set; }
            public String title { get; set; }
            public String start { get; set; }
            public String end { get; set; }

            public timeTable(String I, String t, String ds, String de)
            {
                this.id = I;
                this.title = t;
                this.start = ds;
                this.end = de;
            }


        }

       

        protected void ddlDocter_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestOnWebService(ddlDocter.SelectedValue,"");
        }


        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
        }
    }
}