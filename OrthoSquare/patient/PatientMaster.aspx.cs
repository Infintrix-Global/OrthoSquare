using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.IO;
using PreconFinal.Utility;
using System.Data.OleDb;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Text;


namespace OrthoSquare.patient
{
    public partial class PatientMaster : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Patient objPatient = new BAL_Patient();
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        public static DataTable AllData = new DataTable();
        BAL_Clinic objc = new BAL_Clinic();
        BAL_EnquirySource objES = new BAL_EnquirySource();
        BasePage objBasePage = new BasePage();

        int PatientID = 0;
        int Eid = 0;
        string lID = "";
        private string strQuery = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionUtilities.UserID != null)
            {

                if (Request.QueryString["PatientID"] != null)
                {
                    PatientID = Convert.ToInt32(Request.QueryString["PatientID"].ToString());
                }


                if (Request.QueryString["Eid"] != null)
                {
                    Eid = Convert.ToInt32(Request.QueryString["Eid"].ToString());

                    Edit.Visible = false;
                    Add.Visible = true;
                }

                if (!IsPostBack)
                {
                    bindClinic();

                    if (SessionUtilities.RoleID == 1)
                    {

                        ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();

                    }

                    PatientNo();
                    //getAllEnquiry();
                    BindAllergic();
                    BindMedicalProblem();
                    BindCountry();
                    ddlCountry.SelectedValue = "1";
                    BindState();
                    ddlState.SelectedValue = "2";
                    BindCity();
                    ddlCity.SelectedValue = "34";
                    EnquiryBind();
                    getAllPatient();
                    BindGettooth();
                    BindEnquirySource();
                    TabContactPerson1.Tabs[0].Enabled = true;
                    TabContactPerson1.Tabs[1].Enabled = false;
                    TabContactPerson1.Tabs[2].Enabled = false;

                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void BindEnquirySource()
        {
            int iCount = 0;
            int C = 0;
            DataTable dtES = objES.GetAllEnqirySource();
            if (dtES != null && dtES.Rows.Count > 0)
                iCount = dtES.Rows.Count;

            C = iCount + 1;
            ddlEnquirysource.DataSource = dtES;
            ddlEnquirysource.DataTextField = "Sourcename";
            ddlEnquirysource.DataValueField = "Sourceid";

            ddlEnquirysource.DataBind();

            ddlEnquirysource.Items.Insert(0, new ListItem("--- Select ---", "0"));

            ddlEnquirysource.Items.Insert(iCount, new ListItem("Other", "-1"));
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
                // dt = objc.GetAllClinicDetaisNew(SessionUtilities.Empid);
                dt = objc.GetAllClinicDetais();

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


        public void bindClinicExpUplod()
        {


            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);
            }
            else if (SessionUtilities.RoleID == 1)
            {
                // dt = objc.GetAllClinicDetaisNew(SessionUtilities.Empid);
                dt = objc.GetAllClinicDetais();

            }
            else
            {
                dt = objc.GetAllClinicDetais();

            }
            ddlCinicFileUp.DataSource = dt;
            ddlCinicFileUp.DataValueField = "ClinicID";
            ddlCinicFileUp.DataTextField = "ClinicName";
            ddlCinicFileUp.DataBind();
            ddlCinicFileUp.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }




        public void EnquiryBind()
        {
            if (Eid != 0)
            {

                try
                {

                    DataTable dt = objENQ.GetSelectAllEnquiry(Eid);
                    if (dt != null)
                    {
                        txtFname.Text = dt.Rows[0]["FirstName"].ToString();
                        txtLname.Text = dt.Rows[0]["LastName"].ToString();
                        txtEmail.Text = dt.Rows[0]["Email"].ToString();
                        txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                        txtArea.Text = dt.Rows[0]["Area"].ToString();
                        txtTelephone.Text = dt.Rows[0]["Telephone"].ToString();
                        txtAddress.Text = dt.Rows[0]["Address"].ToString();
                        //  txtBoolGroup.Text = dt.Rows[0]["BloodGroup"].ToString();
                        txtAge.Text = dt.Rows[0]["Age"].ToString();

                        if (dt.Rows[0]["DateBirth"].ToString() != "")
                        {
                            if (Convert.ToDateTime(dt.Rows[0]["DateBirth"]).ToString("dd-MM-yyyy") == "01-01-1999")
                            {
                                txtBDate.Text = "";
                            }
                            else
                            {
                                txtBDate.Text = Convert.ToDateTime(dt.Rows[0]["DateBirth"]).ToString("dd-MM-yyyy");
                            }
                        }

                        ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString();
                        BindState();
                        ddlState.SelectedValue = dt.Rows[0]["stateid"].ToString();
                        // BindCity();
                        ddlCity.SelectedValue = dt.Rows[0]["Cityid"].ToString();
                        bindClinic();
                        ddlClinic.SelectedValue = dt.Rows[0]["ClinicID"].ToString();
                        RadGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                        BindEnquirySource();
                        if (dt.Rows[0]["Sourceid"].ToString() != "")
                        {
                            ddlEnquirysource.SelectedValue = dt.Rows[0]["Sourceid"].ToString();
                        }

                    }

                    //  ddlUOM.SelectedValue = dt.Rows[0]["UOMId"].ToString();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
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





        public void BindMedicalProblem()
        {
            ChkMedicalProblem1.DataSource = objcommon.MedicalProblemMaster();
            ChkMedicalProblem1.DataTextField = "Name";
            ChkMedicalProblem1.DataValueField = "MedicalProid";

            ChkMedicalProblem1.DataBind();



        }

        public void BindAllergic()
        {
            checkallergic.DataSource = objcommon.AllergicDetails();
            checkallergic.DataTextField = "allergicName";
            checkallergic.DataValueField = "allergicId";

            checkallergic.DataBind();



        }

        public void BindCountry()
        {
            ddlCountry.DataSource = objcommon.CountryMaster();
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "ID";
            ddlCountry.DataBind();

            ddlCountry.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }

        public void PatientNo()
        {
            txtRegDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

            int Eno = objcommon.GetPatient_No();
            txtPatientNo.Text = "P" + Eno.ToString();
        }

        public void BindState()
        {

            string Couid = "";

            if (ddlCountry.SelectedValue == "")
            {
                Couid = "0";

            }
            else
            {
                Couid = ddlCountry.SelectedValue;

            }



            ddlState.DataSource = objcommon.NewStateMaster(Convert.ToInt32(Couid));
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();

            ddlState.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void BindCity()
        {
            string sid = "";

            if (ddlState.SelectedValue == "")
            {
                sid = "0";

            }
            else
            {
                sid = ddlState.SelectedValue;

            }

            ddlCity.DataSource = objcommon.CityMaster(Convert.ToInt32(sid));
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();

            ddlCity.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void btAdd_Click1(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;

                string MedicalProblem = "";


                for (int i = 0; i < ChkMedicalProblem1.Items.Count; i++)
                {

                    if (ChkMedicalProblem1.Items[i].Selected)
                    {
                        MedicalProblem += ChkMedicalProblem1.Items[i].Value + ",";
                    }

                }
                if (MedicalProblem != "")
                {
                    MedicalProblem = MedicalProblem.Remove(MedicalProblem.Length - 1);
                }



                string Allergic = "";


                for (int i = 0; i < checkallergic.Items.Count; i++)
                {

                    if (checkallergic.Items[i].Selected)
                    {
                        Allergic += checkallergic.Items[i].Value + ",";
                    }

                }
                if (Allergic != "")
                {
                    Allergic = Allergic.Remove(Allergic.Length - 1);
                }



                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        lID += CheckBoxList1.Items[i].Text + ",";



                    }
                }

                if (lID != "")
                {
                    lID = lID.Remove(lID.Length - 1);
                }




                string ConsentStatement = "";

                if (CheckConsentStatement.Checked == true)
                {
                    ConsentStatement = "Yes";

                }
                else
                {
                    ConsentStatement = "No";
                }

                if (txtBDate.Text == "")
                {
                    txtBDate.Text = null;
                }


                string Password1 = "", UserName = "", SendPassword = "";
                int Pid = objPatient.GetPaisantID();
                // Password1 = objBasePage.Encryptdata(txtFname.Text + "@" + Pid);
                UserName = txtMobile.Text.Trim();
                Password1 = txtFname.Text + "@" + Pid;

                Patient_Details objPatientDetails = new Patient_Details()
                {
                    patientid = patientid,
                    ClinicID = Convert.ToInt32(ddlClinic.SelectedValue),
                    EnquiryId = Eid,
                    PatientCode = txtPatientNo.Text,
                    // EnquiryDate = Convert .ToDateTime(txtENqDate.Text),
                    RegistrationDate = txtRegDate.Text,

                    FirstName = txtFname.Text,
                    LastName = txtLname.Text,
                    // DateBirth = Convert .ToDateTime (txtBDate.Text),
                    DateBirth = txtBDate.Text,
                    Age = txtAge.Text,
                    boolgroup = txtBoolGroup.Text,
                    Gender = RadGender.SelectedItem.Text,
                    Address = txtAddress.Text,
                    CountryId = Convert.ToInt32(ddlCountry.SelectedValue),
                    stateid = Convert.ToInt32(ddlState.SelectedValue),
                    Cityid = Convert.ToInt32(ddlCity.SelectedValue),
                    Area = txtArea.Text,
                    Email = txtEmail.Text,
                    Mobile = txtMobile.Text,
                    Telephone = txtTelephone.Text,
                    MedicalProblem = MedicalProblem,
                    Allergic = Allergic,
                    Pregnant = RadPregnant.SelectedItem.Text,
                    DueDate = txtPreganetDueDate.Text,
                    PanMasalaChewing = RadPanMasala.SelectedItem.Text,
                    Tobacco = RadTobacco.SelectedItem.Text,
                    Somking = RadSomking.SelectedItem.Text,
                    cigrattesInDay = txtNofoCigrattes.Text,
                    ListofMedicine = txtListMedicine.Text,
                    FamilyDoctorName = txtFDoctorName.Text,
                    DrAddress = txtDoctorAddres.Text,
                    ProfileImage = lblProfile.Text,

                    Complaint = txtcomplaint.Text,
                    DentalTreatment = txtlistDentalTreatment.Text,
                    ConsentStatement = ConsentStatement,
                    ConsentParth = lblConsentPic.Text,


                    // PaymentMode = RadioPayment1.SelectedItem .Text ,
                    //PayDate =txtpaymentDate1 .Text ,
                    // Amount=txtAmount1 .Text ,
                    Nooftooth = lID,
                    CreatedBy = SessionUtilities.Empid,
                    ModifiedBy = SessionUtilities.Empid,
                    UserName = txtMobile.Text,
                    Password = Password1,
                    IsActive = true

                };


                int Isv = 0;

                if (patientid == 0)
                {
                    DataTable dt = new DataTable();
                    dt = objPatient.GetPatientssIsvelidNew(txtMobile.Text.Trim(), txtFname.Text.Trim());
                    if(dt!=null && dt.Rows.Count>0)
                    {
                       
                        lblClinic_Name.Text = dt.Rows[0]["ClinicName"].ToString();
                        lblPatientName.Text = dt.Rows[0]["PatienntName"].ToString();
                        Isv = dt.Rows.Count;
                    }
                   
                }

                if (Isv > 0)
                {


                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Confirm()", true);
                    string confirmValue = Request.Form["confirm_value"];
                    if (confirmValue == "Yes")
                    {
                       
                        _isInserted = objPatient.Add_Patient(objPatientDetails);
                    }
                    else
                    {
                       
                        // do nothing  
                    }

                    //   ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "confirm('You are overriding the existing pay grade ');", true);



                    //  If(window.confirm) { insertPayGrade(); } 

                    // string message = "Do you want to submit?";
                    //ClientScript.RegisterOnSubmitStatement(this.GetType(), "confirm", "return confirm('" + message + "');");





                }
                else
                {
                    _isInserted = objPatient.Add_Patient(objPatientDetails);
                }

                if (_isInserted == -1)
                {
                    if (Isv > 0)
                    {
                        //lblMessage.Text = "Mobile number already in use";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        //lblMessage.Text = "Failed to Add Patient";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                        objcommon.ShowMessage(this, "Failed to Add Patient");
                    }
                }
                else
                {
                    if (Convert.ToInt32(Eid) > 0)
                    {
                        int Eid1 = objPatient.EnquiryToPatient(Eid);
                    }
                    //patientid = 0;
                  //  Response.Write("<script>alert('Patient Added Successfully')</script>");
                    //lblMessage.Text = "Patient Added Successfully";
                    //lblMessage.ForeColor = System.Drawing.Color.Green;

                    objcommon.ShowMessage(this, "Patient Added Successfully");

                    btnConsultation.Visible = true;
                    Clear();

                    // SendMail(txtEmail.Text, txtMobile.Text, Password1);
                    int ID = objBasePage.SendMail(txtEmail.Text.Trim(), UserName, Password1);

                    // Response.Redirect("PatientMaster.aspx");

                }
                //  }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;
        }
        protected void txtBDate_TextChanged(object sender, EventArgs e)
        {

            DateTime now = DateTime.Today;
            DateTime birthday = Convert.ToDateTime(txtBDate.Text);
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;
            txtAge.Text = age.ToString();
        }

        protected void RadPregnant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadPregnant.SelectedItem.Text == "Yes")
            {
                txtPreganetDueDate.Visible = true;

            }
            else
            {
                txtPreganetDueDate.Visible = false;

            }
        }

        protected void RadSomking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadSomking.SelectedItem.Text == "Yes")
            {
                txtNofoCigrattes.Visible = true;

            }
            else
            {
                txtNofoCigrattes.Visible = false;

            }

        }
        public void Clear()
        {
            CleartextBoxes(this);
            // BindCountry();
            PatientNo();

            BindAllergic();
            BindMedicalProblem();
            // ddlState.Items.Insert(0, new ListItem("--- Select ---", "0"));
            //ddlCity.Items.Insert(0, new ListItem("--- Select ---", "0"));
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

        protected void BtnNextContact_Click(object sender, EventArgs e)
        {
            TabContactPerson1.Tabs[1].Enabled = true;
            TabContactPerson1.ActiveTabIndex = 1;
        }


        protected void BtnNextMedical_Click(object sender, EventArgs e)
        {
            TabContactPerson1.Tabs[2].Enabled = true;
            TabContactPerson1.ActiveTabIndex = 2;
        }



        public void getAllPatient()
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
            // AllData = objPatient.GetPatientlist();
            AllData = objPatient.NewGetPatientlist1(Cid);
            if (AllData != null && AllData.Rows.Count > 0)
            {
                //Dhaval 
                for (int i = 0; i < AllData.Rows.Count; i++)
                {
                    if (AllData.Rows[i]["PCstatus"].ToString() == "1")
                    { AllData.Rows[i]["PCstatus"] = "Less Co-operative"; }
                    else if (AllData.Rows[i]["PCstatus"].ToString() == "2")
                    { AllData.Rows[i]["PCstatus"] = "Co-operative"; }
                    else if (AllData.Rows[i]["PCstatus"].ToString() == "3")
                    { AllData.Rows[i]["PCstatus"] = "Very Co-operative"; }
                }
                gvShow.DataSource = AllData;
                gvShow.DataBind();

                if (SessionUtilities.RoleID == 2)
                {
                    //e.Row.Cells[7].Visible = false;
                    gvShow.Columns[6].Visible = true;
                }
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                //if (txtSearch.Text != "")
                //{


                if (txtNameS.Text.Trim() != "" && txtLastNameS.Text.Trim() != "")
                {
                    search += "FristName like '%" + txtNameS.Text.Trim() + "%' and LastName like '%" + txtLastNameS.Text.Trim() + "%'";
                }
                else if (txtNameS.Text.Trim() != "")
                {
                    search += "FristName like '%" + txtNameS.Text.Trim() + "%'";
                }
                else if (txtPatientNos.Text.Trim() != "")
                {
                    search += "PatientCode like '%" + txtPatientNos.Text.Trim() + "%'";
                }
                else if (txttxtMobailNoss.Text.Trim() != "")
                {
                    search += "Mobile like '%" + txttxtMobailNoss.Text.Trim() + "%'";
                }
                else
                {

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

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEnquiry")
            {
                Add.Visible = true;
                //btUpdate.Visible = true;
                btAdd.Visible = true;
                Edit.Visible = false;
                int ID = Convert.ToInt32(e.CommandArgument);

                PatientID = ID;
                patientid = ID;
                try
                {

                    DataTable dt = objPatient.GetPatientDetils(ID);
                    // DataTable dt1 = objP.GetPatientDetils(pid);

                    // txtEnquiryNO.Text = dt.Rows[0]["Enquiryno"].ToString();
                    //  txtENqDate.Text = dt.Rows[0]["EnquiryDate"].ToString();
                    txtPatientNo.Text = dt.Rows[0]["PatientCode"].ToString();


                    txtRegDate.Text = Convert.ToDateTime(dt.Rows[0]["RegistrationDate"]).ToString("dd-MM-yyyy");

                    txtFname.Text = dt.Rows[0]["FristName"].ToString();
                    txtLname.Text = dt.Rows[0]["LastName"].ToString();

                    if (dt.Rows[0]["BOD"].ToString() != "")
                    {
                        txtBDate.Text = Convert.ToDateTime(dt.Rows[0]["BOD"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtBDate.Text = "";

                    }
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                    txtArea.Text = dt.Rows[0]["Area"].ToString();
                    txtTelephone.Text = dt.Rows[0]["Telephone"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtBoolGroup.Text = dt.Rows[0]["BloodGroup"].ToString();
                    //    txtFollowupDate.Text = dt.Rows[0]["Folllowupdate"].ToString();
                    bindClinic();
                    if (dt.Rows[0]["ClinicID"] != "")
                    {
                        ddlClinic.SelectedValue = dt.Rows[0]["ClinicID"].ToString();

                    }
                    BindCountry();
                    if (dt.Rows[0]["CountryId"].ToString() != "")
                    {
                        ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString();
                    }
                    BindState();
                    if (dt.Rows[0]["stateid"].ToString() != "")
                    {
                        ddlState.SelectedValue = dt.Rows[0]["stateid"].ToString();
                    }
                    BindCity();
                    if (dt.Rows[0]["Cityid"].ToString() != "")
                    {
                        ddlCity.SelectedValue = dt.Rows[0]["Cityid"].ToString();
                    }

                    //   ddlInterested.SelectedValue = dt.Rows[0]["CatId"].ToString();

                    //  ddlPurpose.SelectedValue = dt.Rows[0]["PurposeId"].ToString();
                    //  ddlReceivedBy.SelectedValue = dt.Rows[0]["ReceivedByEmpId"].ToString();
                    //  ddlAssign.SelectedValue = dt.Rows[0]["AssignToEmpId"].ToString();
                    //if (dt.Rows[0]["Gender"].ToString() != "")
                    //{
                    //    RadGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                    //}
                    if (dt.Rows[0]["Gender"].ToString() != "")
                    {
                        RadGender.Items.FindByText(dt.Rows[0]["Gender"].ToString()).Selected = true;
                    }
                    if (dt.Rows[0]["ProfileImage"].ToString() != "")
                    {
                        ImageProfile.ImageUrl = "~/EmployeeProfile/" + dt.Rows[0]["ProfileImage"].ToString();
                    }
                    else
                    {
                        ImageProfile.ImageUrl = "~/Images/no-photo.jpg";

                    }
                    DataTable dt11 = objPatient.GetPatientMedicalHistory(ID);
                    if (dt11 != null && dt11.Rows.Count > 0)
                    {
                        txtListMedicine.Text = dt11.Rows[0]["ListofMedicine"].ToString();
                        txtDoctorAddres.Text = dt11.Rows[0]["DrAddress"].ToString();

                        txtFDoctorName.Text = dt11.Rows[0]["FamilyDoctorName"].ToString();

                        RadPregnant.SelectedValue = dt11.Rows[0]["Pregnant"].ToString();
                        RadPanMasala.SelectedValue = dt11.Rows[0]["PanMasalaChewing"].ToString();
                        RadTobacco.SelectedValue = dt11.Rows[0]["Tobacco"].ToString();
                        RadSomking.SelectedValue = dt11.Rows[0]["Somking"].ToString();

                        if (Convert.ToDateTime(dt11.Rows[0]["DueDate"]).ToString("dd-MM-yyyy") == "01-01-1990")
                        {
                            txtPreganetDueDate.Visible = false;

                        }
                        else
                        {
                            txtPreganetDueDate.Visible = true;
                            txtPreganetDueDate.Text = Convert.ToDateTime(dt11.Rows[0]["DueDate"]).ToString("dd-MM-yyyy");
                        }
                        if (dt11.Rows[0]["Somking"].ToString() == "Yes")
                        {
                            txtNofoCigrattes.Visible = true;
                            txtNofoCigrattes.Text = dt11.Rows[0]["cigrattesInDay"].ToString();
                        }
                    }



                    DataTable dtInfo = objPatient.GetPatientbyDentalinfo(ID);
                    if (dtInfo != null && dtInfo.Rows.Count > 0)
                    {
                        txtcomplaint.Text = dtInfo.Rows[0]["Complaint"].ToString();
                        txtlistDentalTreatment.Text = dtInfo.Rows[0]["DentalTreatment"].ToString();
                        TextBox1.Text = dtInfo.Rows[0]["ToothNo"].ToString();

                        if (dtInfo.Rows[0]["ConsentStatement"].ToString() == "Yes")
                        {
                            CheckConsentStatement.Checked = true;
                        }
                        else
                        {
                            CheckConsentStatement.Checked = false;


                        }

                    }

                    DataTable dt111 = objPatient.GetPatientMedicalProblem(ID);


                    if (dt111 != null && dt111.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt111.Rows.Count; j++)
                        {
                            for (int i = 0; i < ChkMedicalProblem1.Items.Count; i++)
                            {
                                if (ChkMedicalProblem1.Items[i].Text == dt111.Rows[j]["Name"].ToString())
                                {
                                    ChkMedicalProblem1.Items[i].Selected = true;
                                }
                            }
                        }
                    }


                    DataTable dtalg11 = objPatient.GetPatientbyAllergic(ID);


                    if (dtalg11 != null && dtalg11.Rows.Count > 0)
                    {
                        for (int P = 0; P < dtalg11.Rows.Count; P++)
                        {
                            for (int K = 0; K < checkallergic.Items.Count; K++)
                            {
                                if (checkallergic.Items[K].Text == dtalg11.Rows[P]["allergicName"].ToString())
                                {
                                    checkallergic.Items[K].Selected = true;
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }
            if (e.CommandName == "viewPDetails")
            {
                int ID1 = Convert.ToInt32(e.CommandArgument);

                PatientID = ID1;

                Response.Redirect("patientView.aspx?pid=" + PatientID);
            }
        }

        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objPatient.DeletePatient(ID);
                if (_isDeleted != -1)
                {

                    lblMessage.Text = "Enquiry Deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("PatientMaster.aspx");
                    btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }



        protected void btnImageProfile_Click(object sender, EventArgs e)
        {
            UploadImageProfile();
        }

        public void UploadImageProfile()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FileUpProfile.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileUpProfile.Focus();
            }
            //string DD = txtFristName.Text;
            string aa = FileUpProfile.FileName;
            string ext = System.IO.Path.GetExtension(FileUpProfile.PostedFile.FileName).ToLower();
            bool isValidFile = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (isValidFile == true)
            {

                if (FileUpProfile.HasFile)
                {

                    filename = Server.MapPath(FileUpProfile.FileName);
                    newfile = FileUpProfile.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\EmployeeProfile"))
                    {
                        try
                        {

                            int PID = objcommon.GetPatientCount_No();

                            string Imgname = "Profile" + PID + txtFname.Text;

                            string path = Server.MapPath(@"~\EmployeeProfile\");
                            System.IO.Directory.CreateDirectory(path);
                            FileUpProfile.SaveAs(path + @"\" + "Profile" + PID + txtFname.Text + ext);

                            ImageProfile.ImageUrl = @"~\EmployeeProfile\" + "Profile" + PID + txtFname.Text + ext;
                            ImageProfile.Visible = true;

                            lblProfile.Text = Imgname + ext;

                            //  IdentityPolicyImageUrl = Imgname + ext;


                        }
                        catch (Exception ex)
                        {
                            lblProfile.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }



        protected void btConsultationAdd_Click1(object sender, EventArgs e)
        {
            int Pid = 0;
            if (patientid > 0)
            {
                Pid = Convert.ToInt32(patientid);
                patientid = 0;
            }
            else
            {
                Pid = objcommon.GetpatientNo();
            }


            //   Response.Redirect("../Doctor/ConsultationAddTreatment.aspx");
            Response.Redirect("../Doctor/ConsultationAddTreatment.aspx?pid=" + Pid);
        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
        }

        protected void btBack_Click(object sender, EventArgs e)
        {

            Edit.Visible = true;
            Add.Visible = false;
            getAllPatient();
        }
        protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShow.EditIndex = -1;
            btSearch_Click(sender, e);
        }

        protected void btnAddMedicalProblem_Click(object sender, EventArgs e)
        {
            BAL_MedicalProblem objES = new BAL_MedicalProblem();
            int _isInserted = -1;

            _isInserted = objES.AddMProblems(txtMedicalProblem.Text);

            BindMedicalProblem();

            txtMedicalProblem.Text = "";
        }

        protected void btnAddMedicalProblem123_Click(object sender, EventArgs e)
        {
            AddMedicalProblem.Visible = true;
        }
        protected void btnMedicalProblemCancel_Click(object sender, EventArgs e)
        {
            AddMedicalProblem.Visible = false;
            BindMedicalProblem();

            txtMedicalProblem.Text = "";
        }




        protected void btnAddallergic_Click(object sender, EventArgs e)
        {
            BAL_MedicalProblem objES = new BAL_MedicalProblem();
            int _isInserted = -1;

            _isInserted = objES.Add_Allergic(txtAddallergic.Text);

            BindAllergic();

            txtAddallergic.Text = "";
        }

        protected void btnAddAllergic123_Click(object sender, EventArgs e)
        {
            Addallergic.Visible = true;
        }
        protected void btnallergicCancel_Click(object sender, EventArgs e)
        {
            Addallergic.Visible = false;
            BindAllergic();

            txtAddallergic.Text = "";
        }


        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = "";

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    name += CheckBoxList1.Items[i].Text + ",";
                    lID += CheckBoxList1.Items[i].Value + ",";
                }
            }
            TextBox1.Text = name;

        }


        public void BindGettooth()
        {
            DataTable dt = objcommon.Gettooth();


            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataTextField = "toothNo";
            CheckBoxList1.DataValueField = "toothID";
            CheckBoxList1.DataBind();


        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btExcel_Click(object sender, ImageClickEventArgs e)
        {

            //string constr = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    int Cid = 0;

            //    if (SessionUtilities.RoleID == 1)
            //    {
            //        Cid = Convert.ToInt32(SessionUtilities.Empid);
            //    }
            //    else
            //    {
            //        Cid = 0;
            //    }
            //    strQuery = " Select *,P.FristName +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1";

            //    if (Cid > 0)
            //        strQuery += " and P.ClinicID ='" + Cid + "'";
            //    strQuery += "order by patientid DESC ";


            //    using (SqlCommand cmd = new SqlCommand(strQuery))
            //    {
            //        using (SqlDataAdapter sda = new SqlDataAdapter())
            //        {
            //            cmd.Connection = con;
            //            sda.SelectCommand = cmd;
            //            using (DataTable dt = new DataTable())
            //            {
            //                sda.Fill(dt);
            //                using (XLWorkbook wb = new XLWorkbook())
            //                {
            //                    wb.Worksheets.Add(dt, "Customers");

            //                    Response.Clear();
            //                    Response.Buffer = true;
            //                    Response.Charset = "";
            //                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //                    Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
            //                    using (MemoryStream MyMemoryStream = new MemoryStream())
            //                    {
            //                        wb.SaveAs(MyMemoryStream);
            //                        MyMemoryStream.WriteTo(Response.OutputStream);
            //                        Response.Flush();
            //                        Response.End();
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            int Cid = 0;

            if (SessionUtilities.RoleID == 1)
            {
                Cid = Convert.ToInt32(SessionUtilities.Empid);
            }
            else
            {
                Cid = 0;
            }
            //AllData = objPatient.GetPatientlist();
            AllData = objPatient.NewGetPatientlist11(Cid);

            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.ClearContent();
            response.Charset = Encoding.UTF8.WebName;
            response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
            response.AddHeader("Content-Type", "application/Excel");
            response.ContentType = "application/vnd.xlsx";
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    GridView gridView = new GridView();
                    gridView.DataSource = AllData;
                    gridView.DataBind();
                    gridView.RenderControl(htw);
                    response.Write(sw.ToString());
                    gridView.Dispose();
                    AllData.Dispose();
                    response.End();
                }
            }
        }


        #region " ***** Questions ***** "
        protected void btnOptionalUpload_Click(object sender, EventArgs e)
        {

            //   DisableMessage();
            bool Result = false;
            string ResultMsg = "";
            // Previousdisabled();
            // maxquestion();

            UploadAllQuestions(flOptional, ref Result, ref ResultMsg);

            // EnableorDisableQuestion();

        }

        protected void btbtnExlCancel_Click(object sender, EventArgs e)
        {

            Edit.Visible = true;
            Add.Visible = false;

            Div11.Visible = false;
            btUpdate.Visible = false;
        }
        protected void btnAddexcelupload_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = false;

            btUpdate.Visible = false;
            Div11.Visible = true;
        }

        protected void UploadAllQuestions(FileUpload flUpload, ref bool Result, ref string ErrorName)
        {
            string[] validFileTypes = { "xls", "xlsx" };
            string ext = System.IO.Path.GetExtension(flUpload.PostedFile.FileName);
            bool isValidFile = false;
            if (flUpload.HasFile == false)
            {
                Result = false;
                ErrorName = "Please select file.";
                return;
            }
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (isValidFile == true)
            {
                try
                {
                    string FolderPath = Server.MapPath(@"~/Temp/");
                    string filename = flUpload.FileName;
                    string fileExtension = Path.GetExtension(flUpload.PostedFile.FileName);
                    string fileLocation = FolderPath + filename;
                    flUpload.SaveAs(fileLocation);
                    DataTable dtExcel = new DataTable("IIsecurity");
                    string SourceConstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";

                    OleDbConnection con = new OleDbConnection(SourceConstr);
                    string query = "Select * from [Sheet1$]";

                    OleDbDataAdapter data = new OleDbDataAdapter(query, con);

                    data.Fill(dtExcel);
                    con.Close();
                    List<FailedQuestionList> objFailQuestion = new List<FailedQuestionList>();
                    int iResult = SaveExcelDataToDataBase(dtExcel, ref objFailQuestion);



                    //  lblMSG1.Text = strresult;
                    //  Result = false;
                    lblMSG11.Text = "patient Information have been uploaded sucessfully.";

                }
                catch (Exception ex)
                {
                    Result = false;
                    ErrorName = "patient Information Not Saved";
                }
            }
            else
            {
                Result = false;
                ErrorName = "Invalid File. Please Select proper file.";
            }
        }

        protected void btnAddexcelupload_Click1(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = false;

            btUpdate.Visible = false;
            Div11.Visible = true;

            bindClinicExpUplod();
            if (SessionUtilities.RoleID == 1)
            {
                ddlCinicFileUp.SelectedValue = SessionUtilities.Empid.ToString();
            }
        }

        /// <summary>
        /// Save data from Excell to DB
        /// </summary>
        /// <param name="dtExcel"> DataTable</param>
        /// <returns>Return 1 if Success else 0</returns>
        protected int SaveExcelDataToDataBase(DataTable dtExcel, ref List<FailedQuestionList> objFailQuestion)
        {
            try
            {

                bool IsValidChapter = false;
                bool Result = false;
                int reccount = 1;
                // create list object
                BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
                //    CourseMasterBLL objCourseMasterBLL = new CourseMasterBLL();
                foreach (DataRow item in dtExcel.Rows)
                {

                    int Eno = objcommon.GetPatient_No();
                    string PCode = "P" + Eno.ToString();

                    if (!string.IsNullOrEmpty(Common.CheckNullandEmpty(item["FirstName"]))
                        && !string.IsNullOrEmpty(Common.CheckNullandEmpty(item["LastName"]))
                        )
                    {

                        int Isv = objPatient.GetPatientssIsvelid(item["Mobile"].ToString().Trim(), item["FirstName"].ToString().Trim());

                        if (Isv > 0)
                        {

                        }
                        else
                        {

                            int Did = objPatient.SaveExcelUploadedPatient(PCode, item["FirstName"].ToString().Trim(), item["LastName"].ToString().Trim(), item["Email"].ToString().Trim(), item["Mobile"].ToString().Trim(), item["BirthDate"].ToString().Trim(), Convert.ToInt32(ddlCinicFileUp.SelectedValue));


                        }
                        reccount++;
                    }
                }
                return Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            //return 1;
        }



        protected void btndownloadOptional_Click(object sender, EventArgs e)
        {
            DownloadFile("patient_Master.xlsx", "patient_Master.xlsx");
        }

        protected void DownloadFile(string DownloadFileName, string OutgoingFileName)
        {
            string path = MapPath("~/") + "\\Predefine_Documents\\" + DownloadFileName;
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + OutgoingFileName);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.WriteFile(file.FullName);
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
        #endregion

        protected void CheckConsentStatement_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckConsentStatement.Checked == true)
            {
                PanelConsent.Visible = true;
            }
            else
            {
                PanelConsent.Visible = false;

            }
        }

        protected void btnConsentPic_Click(object sender, EventArgs e)
        {
            UploadImageConsent();
        }

        public void UploadImageConsent()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FileUploadConsent.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileUploadConsent.Focus();
            }
            //string DD = txtFristName.Text;
            string aa = FileUploadConsent.FileName;
            string ext = System.IO.Path.GetExtension(FileUploadConsent.PostedFile.FileName).ToLower();
            bool isValidFile = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (isValidFile == true)
            {

                if (FileUploadConsent.HasFile)
                {

                    filename = Server.MapPath(FileUploadConsent.FileName);
                    newfile = FileUploadConsent.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\ConsentDoc"))
                    {
                        try
                        {

                            int PID = objcommon.GetPatientCount_No();

                            string Imgname = "Consent" + PID + txtFname.Text;

                            string path = Server.MapPath(@"~\ConsentDoc\");
                            System.IO.Directory.CreateDirectory(path);
                            FileUploadConsent.SaveAs(path + @"\" + "Consent" + PID + txtFname.Text + ext);

                            ImageConsentPic.ImageUrl = @"~\ConsentDoc\" + "Consent" + PID + txtFname.Text + ext;
                            ImageConsentPic.Visible = true;

                            lblConsentPic.Text = Imgname + ext;

                            //  IdentityPolicyImageUrl = Imgname + ext;


                        }
                        catch (Exception ex)
                        {
                            lblConsentPic.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



            }
        }

        protected void gvShow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //protected void SendMail(string Email, string Username, string Password)
        //{
        //    // Gmail Address from where you send the mail
        //    var fromAddress = "orthomail885@gmail.com";
        //    // any address where the email will be sending
        //    // var toAddress = "mehulrana1901@gmail.com,urvi.gandhi@infintrixglobal.com,nidhi.mehta@infintrixglobal.com,bhavin.gandhi@infintrixglobal.com,mehul.rana@infintrixglobal.com,naimisha.rohit@infintrixglobal.com";

        //    var toAddress = Email + ",drshraddhakambale@gmail.com";

        //    //Password of your gmail address
        //    const string fromPassword = "Ortho@1234";
        //    // Passing the values and make a email formate to display
        //    string subject = "Your UserName and Password For Ortho Square";
        //    string body = "Dear ," + "\n";
        //    body += "Your UserName and Password For OrthoSquare :" + "\n";
        //    body += "UserName : " + Username + " " + "\n\n";
        //    body += "Password : " + Password + " " + "\n\n";
        //    body += "Thank you!" + "\n";
        //    body += "Warm Regards," + "\n";

        //    // smtp settings
        //    var smtp = new System.Net.Mail.SmtpClient();
        //    {
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.EnableSsl = true;
        //        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
        //        smtp.Timeout = 50000;
        //    }
        //    // Passing values to smtp object
        //    smtp.Send(fromAddress, toAddress, subject, body);
        //}


    }
}


