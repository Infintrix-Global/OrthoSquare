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
    public partial class BookAppointment : System.Web.UI.Page
    {
        string a = "";

        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Appointment objApp = new BAL_Appointment();
        BAL_Patient objPatient = new BAL_Patient();
        public static DataTable AllData = new DataTable();
        string DateTimevalue = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = Request.QueryString["DateTime"].ToString();
            lblDocterID.Text = Request.QueryString["ddlDocter"].ToString();

             DateTimevalue = Request.QueryString["DateTime"].ToString();

            if (!IsPostBack)
            {
               

                AppoinmentNo();
               
                getAllPatient();

                bindDoctorMaster();

                if(lblDocterID .Text !="")
                {
                    ddlDocter.SelectedValue = lblDocterID.Text;
                }
            }

        }

        public void bindDoctorMaster()
        {
            ddlDocter.DataSource = objcommon.DoctersMaster(SessionUtilities.Empid );
            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "FirstName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

            if(SessionUtilities .RoleID ==3)
            {
                ddlDocter.DataValueField = (SessionUtilities.Empid).ToString ();
                

            }

        }

        private long Appointmentid
        {
            get
            {
                if (ViewState["Appointmentid"] != null)
                {
                    return (long)ViewState["Appointmentid"];
                }
                return 0;
            }
            set
            {
                ViewState["Appointmentid"] = value;
            }
        }


        private long patientid
        {
            get
            {
                if (ViewState["patientid"] != null)
                {
                    return (long)ViewState["patientid"];
                }
                return 0;
            }
            set
            {
                ViewState["patientid"] = value;
            }
        }

        public void AppoinmentNo()
        {
            txtRegDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

            int Eno = objcommon.GetAppoinmentMax_No();
            txtPatientNo.Text = "A" + Eno.ToString();




        }

        public void getAllPatient()
        {

            AllData = objPatient.GetPatientlist();
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            // btSearch_Click(sender, e);
        }



        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                //if (txtSearch.Text != "")
                //{
                if (txtPno.Text != "")
                {
                    search += "PatientCode like '%" + txtPno.Text + "%'";
                }
                else
                {
                    search += "Mobile = '" + txtsMobile.Text + "'";
                }

                DataRow[] dtSearch1 = AllData.Select(search);
                if (dtSearch1.Count() > 0)
                {
                    DataTable dtSearch = dtSearch1.CopyToDataTable();
                    gvShow.DataSource = dtSearch;
                    gvShow.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    gvShow.DataSource = dt;
                    gvShow.DataBind();
                }
                //}
                //else
                //{
                //    gvShow.DataSource = AllData;
                //    gvShow.DataBind();
                //}
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             

            int Pid = Convert.ToInt32(e.CommandArgument);

            patientid = Pid;

            DataTable dt = objPatient.GetPatient(Pid);

            txtFname.Text = dt.Rows[0]["FristName"].ToString();
            txtLname.Text = dt.Rows[0]["LastName"].ToString();
            txtBDate.Text = Convert .ToDateTime (dt.Rows[0]["BOD"]).ToString("dd-MM-yyyy");
            txtAge.Text = dt.Rows[0]["Age"].ToString();
            RadGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();

            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
            txtTelephone.Text = dt.Rows[0]["Telephone"].ToString();


            Edit.Visible = false;
            Add.Visible = true;
        }



        protected void txtBDate_TextChanged(object sender, EventArgs e)
        {
            General objg = new General();
            DateTime now = DateTime.Today;
            DateTime birthday = objg.getDatetime(txtBDate.Text);
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;
            txtAge.Text = age.ToString();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {

            var P = lblDateTime.Text;
          
           // s = s.Substring(1, s.Length - 1);

           // lblDateTime.Text.Replace("'", "");

            string m;

                m = lblDateTime.Text.Replace("'", "");
           // string M = s.ToString ();
                string s = m + " (GMT Standard Time)";

            //var date = DateTime.ParseExact(DateTimevalue+ " (GMT Standard Time)",
            //           "ddd MMM dd yyyy HH:mm:ss 'GMT+0000 (GMT Standard Time)'",
            //           CultureInfo.InvariantCulture);

                string q = "Mon Jan 13 2014 11:02:00 GMT+0000 (GMT Standard Time)";

          //  string s = lblDate.Text + " (GMT Standard Time)";
            var date = DateTime.ParseExact(s,
                       "ddd MMM dd yyyy HH:mm:ss 'GMT 0000 (GMT Standard Time)'",
                       CultureInfo.InvariantCulture);

          //  var date1 = DateTime.ParseExact(s, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.WriteLine(date.ToString("yyyy-MM-dd"));

            // txtRegDate.Text = date.ToString("yyyy-MM-dd HH:mm");

            txtRegDate.Text = date.ToString("dd-MM-yyyy HH:mm");
            string Did = m = lblDocterID.Text.Replace("'", "");

            try
            {
                int _isInserted = -1;


                Appointment_Details objAppoiment = new Appointment_Details()
                {
                    Appointmentid = Appointmentid,
                    ClinicID =SessionUtilities .Empid ,
                    AppointmenNo = txtPatientNo.Text,
                    patientid = patientid,
                    DoctorID = Convert.ToInt32(Did),
                    FirstName = txtFname.Text,
                    LastName = txtLname.Text,

                    DateBirth = txtBDate.Text,
                    Age = txtAge.Text,

                    Gender = RadGender.SelectedItem.Text,

                    Email = txtEmail.Text,
                    Mobile1 = txtMobile.Text,
                    Mobile2 = txtTelephone.Text,
                    start_date = txtRegDate.Text,
                    end_date = txtRegDate.Text,

                    start_time = "1",
                    end_time = "1",
                    CreatedBy = SessionUtilities.Empid,
                    ModifiedBy = SessionUtilities.Empid,

                    IsActive = true

                };

                _isInserted = objApp.Add_AppointmentDetails(objAppoiment);

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Patient";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Appointmentid = 0;
                    lblMessage.Text = "Patient Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    CleartextBoxes(this);
                    // Clear();
                    Response.Redirect("NewAppointmentClinic.aspx");

                }
            }
            catch (Exception ex)
            {
            }
        }


        public void CleartextBoxes(Control parent)
        {

            foreach (Control c in parent.Controls)
            {

                if ((c.GetType() == typeof(TextBox)))
                {



                    ((TextBox)(c)).Text = "";

                }


                if (c.HasControls())
                {

                    CleartextBoxes(c);

                }

            }

        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
        }


        protected void btnclear_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewAppointmentClinic.aspx");
        }
    }
}