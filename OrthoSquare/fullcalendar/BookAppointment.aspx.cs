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
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        Notificationnew objN = new Notificationnew();
        BAL_Clinic objc = new BAL_Clinic();
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

                bindClinic();

                if (SessionUtilities.RoleID == 1)
                {
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindDocter(Convert.ToInt32(SessionUtilities.Empid));
                    // BindPatient();
                }
            }

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

            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindDocter(Convert.ToInt32(ddlClinic.SelectedValue));
           
        }

        public void BindDocter(int Cid)
        {
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDoctor.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);

            }
            else
            {
                ddlDoctor.DataSource = objcommon.DoctersMasterNewENQ11(Cid, SessionUtilities.RoleID);

            }

            ddlDoctor.DataTextField = "DoctorName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();
            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
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

        private long EnquiryID
        {
            get
            {
                if (ViewState["EnquiryID"] != null)
                {
                    return (long)ViewState["EnquiryID"];
                }
                return 0;
            }
            set
            {
                ViewState["EnquiryID"] = value;
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

            if (RadioButtonList1.SelectedValue == "0")
            {
                AllData = objENQ.GetAllEnquirynewAppoiment(0);
                GridEnquiry.DataSource = AllData;
                GridEnquiry.DataBind();
            }
            else
            {
                string Cid = "";

                if (SessionUtilities.RoleID == 1)
                {
                    Cid = SessionUtilities.Empid.ToString();
                }
                else if (SessionUtilities.RoleID == 3)
                {
                    string A = "";
                    DataTable dt23 = objPatient.DoctorByClinicLIST(SessionUtilities.Empid);

                    //for (int i = 0; i < AllData.Rows.Count; i++)
                    //{

                    //}

                    for (int i = 0; i < dt23.Rows.Count; i++)
                    {
                        A += dt23.Rows[i]["ClinicID"].ToString() + ",";

                    }

                    if (A != "")
                    {
                        A = A.Remove(A.Length - 1);
                    }

                    Cid = A;
                }
                else
                {
                    Cid = "";
                }
                AllData = objPatient.NewGetPatientlist1(Cid);
                // AllData = objPatient.GetPatientlist();
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }


        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllPatient();
        }

        protected void GridEnquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridEnquiry.PageIndex = e.NewPageIndex;
            getAllPatient();
        }


        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                //if (txtSearch.Text != "")
                //{

                if (RadioButtonList1.SelectedValue == "0")
                {
                    if (txtPno.Text != "")
                    {
                        search += "FirstName = '" + txtPno.Text + "'";
                    }
                    else
                    {
                        search += "Mobile = '" + txtsMobile.Text + "'";
                    }



                    DataRow[] dtSearch1 = AllData.Select(search);
                    if (dtSearch1.Count() > 0)
                    {
                        DataTable dtSearch = dtSearch1.CopyToDataTable();
                        GridEnquiry.DataSource = dtSearch;
                        GridEnquiry.DataBind();
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        GridEnquiry.DataSource = dt;
                        GridEnquiry.DataBind();
                    }
                }
                else
                {
                    if (txtPno.Text != "")
                    {
                        search += "FristName = '" + txtPno.Text + "'";
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

            if (e.CommandName == "SelectP")
            {
                int Pid = Convert.ToInt32(e.CommandArgument);

                patientid = Pid;

                EnquiryID = 0;
           
                DataTable dt = objPatient.GetPatient(Pid);

                txtFname.Text = dt.Rows[0]["FristName"].ToString();
                txtLname.Text = dt.Rows[0]["LastName"].ToString();
                if(dt.Rows[0]["BOD"].ToString() !="")
                {
                      txtBDate.Text = Convert.ToDateTime(dt.Rows[0]["BOD"]).ToString("dd-MM-yyyy");
                }
                txtAge.Text = dt.Rows[0]["Age"].ToString();
                // RadGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                if (dt.Rows[0]["Gender"].ToString() != "")
                {
                    //RadGender.Items.FindByValue(dt.Rows[0]["Gender"].ToString()).Selected = true;
                    RadGender.Items.FindByText(dt.Rows[0]["Gender"].ToString()).Selected = true;

                }
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                txtTelephone.Text = dt.Rows[0]["Telephone"].ToString();
                //bindDoctorMaster();
                //if (lblDocterID.Text != "")
                //{
                //    int IDa= Convert.ToInt32(lblDocterID.Text);
                //    ddlDoctor.SelectedValue = IDa.ToString();
                //}

                Edit.Visible = false;
                Add.Visible = true;
            }
        }

        protected void GridEnquiry_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "SelectP")
            {
                int Eid = Convert.ToInt32(e.CommandArgument);

                EnquiryID = Eid;
                patientid = 0;
                DataTable dt = objENQ.GetAllEnquirynewAppoiment(Eid);

                txtFname.Text = dt.Rows[0]["FirstName"].ToString();
                txtLname.Text = dt.Rows[0]["LastName"].ToString();
                if (dt.Rows[0]["DateBirth"].ToString() != "")
                {
                    txtBDate.Text = Convert.ToDateTime(dt.Rows[0]["DateBirth"]).ToString("dd-MM-yyyy");
                }
                txtAge.Text = dt.Rows[0]["Age"].ToString();
                // RadGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                if (dt.Rows[0]["Gender"].ToString() != "")
                {
                    RadGender.Items.FindByText(dt.Rows[0]["Gender"].ToString()).Selected = true;
                }
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                txtTelephone.Text = dt.Rows[0]["Telephone"].ToString();
               // bindDoctorMaster();
              
                Edit.Visible = false;
                Add.Visible = true;
            }
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
                    ClinicID = Convert.ToInt32(ddlClinic.SelectedValue),
                    AppointmenNo = txtPatientNo.Text,
                    patientid = patientid,
                    EnquiryID= EnquiryID,
                    DoctorID = Convert.ToInt32(ddlDoctor.SelectedValue),
                    FirstName = txtFname.Text,
                    LastName = txtLname.Text,

                    DateBirth = txtBDate.Text,
                    Age = txtAge.Text,

                    Gender = RadGender.SelectedItem.Text.Trim(),

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
                    string msg;
                    lblMessage.Text = "Patient Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    DataTable DTP = objPatient.GetPatient(Convert .ToInt32 (patientid));

                    msg = "Your Appoinment Date :" + txtRegDate.Text + " " + "Time : " + Convert .ToDateTime (txtRegDate.Text).ToShortTimeString() + " has been Booked Appoinment";

                    if (DTP.Rows[0]["registrationToken"].ToString() != "")
                    {

                        objN.SendMessage(patientid.ToString(), DTP.Rows[0]["registrationToken"].ToString(), msg, " Booked Appoinment", "3");
                    }
                    CleartextBoxes(this);



                    // Clear();
                    Response.Redirect("demos/NewAppointmentClinic.aspx");

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

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "0")
            {
                btnAddNew.Visible = true;
                PanelPatient.Visible = false;
                PanelEnquiry.Visible = true;
                getAllPatient();
            }
            else
            {
                btnAddNew.Visible = false;
                PanelPatient.Visible = true;
                PanelEnquiry.Visible = false;
                getAllPatient();

            }

        }
            }
}