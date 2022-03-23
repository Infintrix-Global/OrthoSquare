using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Data.OleDb;
using System.IO;
using PreconFinal.Utility;
using System.Reflection;

namespace OrthoSquare.Enquiry1
{
    public partial class EnquiryDetails : System.Web.UI.Page
    {

        clsCommonMasters objcommon = new clsCommonMasters();
        public static DataTable AllData = new DataTable();
        BAL_EnquirySource objES = new BAL_EnquirySource();
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        BAL_Clinic objclinic = new BAL_Clinic();
        BAL_Treatment objT = new BAL_Treatment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                EnqNo();
                BindddlclinicExcel();
                Bindddlclinic();
                BindCountry();
                ddlCountry.SelectedValue = "1";
                BindState();
                ddlState.SelectedValue = "2";
                BindCity();
                ddlCity.SelectedValue = "34";
                bindddlTreatment();
                BindEnquirySourceSearch();
                BindEnquirySource();
                BindAssignToEmp(0);
                BindAssignToTelecaller(0);
                if (SessionUtilities.RoleID == 1)
                {
                    ddlclinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindAssignToEmp(SessionUtilities.Empid);
                }
                bindClinicSearch();
                if (SessionUtilities.RoleID == 2)
                {
                    Cid.Visible = true;
                }

                RadioRole.SelectedValue = SessionUtilities.RoleID.ToString();
                RadioRole_SelectedIndexChanged(sender, e);
                getAllEnquiry();
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
        public void bindClinicSearch()
        {

            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);
            }
            else if (SessionUtilities.RoleID == 1)
            {
                dt = objclinic.GetAllClinicDetaisNew(SessionUtilities.Empid);
            }
            else
            {
                dt = objclinic.GetAllClinicDetais();

            }
            ddlclinicSearch.DataSource = dt;


            ddlclinicSearch.DataValueField = "ClinicID";
            ddlclinicSearch.DataTextField = "ClinicName";
            ddlclinicSearch.DataBind();
            ddlclinicSearch.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));



        }


        public void bindddlTreatment()
        {
            ddlTreatment.DataSource = objT.GetAllTreatment();
            ddlTreatment.DataValueField = "TreatmentID";
            ddlTreatment.DataTextField = "TreatmentName";
            ddlTreatment.DataBind();
            ddlTreatment.Items.Insert(0, new ListItem("-- Select Treatment--", "0", true));

        }

        public void BindddlclinicExcel()
        {

            DataTable dt;

            //if (SessionUtilities.RoleID == 3)
            //{
            //    dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);
            //}
            //else if (SessionUtilities.RoleID == 1)
            //{
            //   // dt = objclinic.GetAllClinicDetaisNew(SessionUtilities.Empid);
            //    dt = objclinic.GetAllClinicDetais();
            //}

            //else if (SessionUtilities.RoleID == 9)
            //{
            //    // dt = objclinic.GetAllClinicDetaisNew(SessionUtilities.Empid);
            //    // dt = objcommon.GetByTelecallerClinic(SessionUtilities.Empid,SessionUtilities.RoleID);
            //    dt = objclinic.GetAllClinicDetais();
            //}
            //else if (SessionUtilities.RoleID == 5)
            //{
            //    // dt = objclinic.GetAllClinicDetaisNew(SessionUtilities.Empid);
            //    dt = objcommon.GetByTelecallerClinic(SessionUtilities.Empid,SessionUtilities.RoleID);
            //}
            //else
            //{
            //    dt = objclinic.GetAllClinicDetais();

            //}


            dt = objclinic.GetAllClinicDetais();


            ddlClinicUploadExcel.DataSource = dt;
            ddlClinicUploadExcel.DataTextField = "ClinicName";
            ddlClinicUploadExcel.DataValueField = "ClinicID";
            ddlClinicUploadExcel.DataBind();
            ddlClinicUploadExcel.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        public void Bindddlclinic()
        {

            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);
            }
            else if (SessionUtilities.RoleID == 1)
            {
                // dt = objclinic.GetAllClinicDetaisNew(SessionUtilities.Empid);
                dt = objclinic.GetAllClinicDetais();
            }

            else if (SessionUtilities.RoleID == 9)
            {
                // dt = objclinic.GetAllClinicDetaisNew(SessionUtilities.Empid);
                // dt = objcommon.GetByTelecallerClinic(SessionUtilities.Empid,SessionUtilities.RoleID);
                dt = objclinic.GetAllClinicDetais();
            }
            else if (SessionUtilities.RoleID == 5)
            {
                // dt = objclinic.GetAllClinicDetaisNew(SessionUtilities.Empid);
                dt = objcommon.GetByTelecallerClinic(SessionUtilities.Empid, SessionUtilities.RoleID);
            }
            else
            {
                dt = objclinic.GetAllClinicDetais();

            }


            //dt = objclinic.GetAllClinicDetais();

            ddlclinic.DataSource = dt;
            ddlclinic.DataTextField = "ClinicName";
            ddlclinic.DataValueField = "ClinicID";
            ddlclinic.DataBind();
            ddlclinic.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void BindAssignToEmp(int Cid)
        {
            ddlAssign.Items.Clear();
            if (SessionUtilities.RoleID == 1)
            {

                ddlAssign.DataSource = objcommon.DoctersMasterNew(Cid, SessionUtilities.RoleID);
                ddlExDoctor.DataSource = objcommon.DoctersMasterNew(Cid, SessionUtilities.RoleID);

            }
            else if (SessionUtilities.RoleID == 3)
            {

                ddlAssign.DataSource = objcommon.DoctersMasterNewENQ11(Convert.ToInt16(ddlclinic.SelectedValue), SessionUtilities.RoleID);
                ddlExDoctor.DataSource = objcommon.DoctersMasterNewENQ11(Convert.ToInt16(ddlClinicUploadExcel.SelectedValue), SessionUtilities.RoleID);


            }

            else
            {
                // ddlAssign.DataSource = objcommon.DoctersMasterNewENQ(Cid, SessionUtilities.RoleID);
                ddlAssign.DataSource = objcommon.DoctersMasterNew(Cid, SessionUtilities.RoleID);
                ddlExDoctor.DataSource = objcommon.DoctersMasterNew(Cid, SessionUtilities.RoleID);

            }

            ddlAssign.DataTextField = "DoctorName";
            ddlAssign.DataValueField = "DoctorID";
            ddlAssign.DataBind();
            ddlAssign.Items.Insert(0, new ListItem("--- Select ---", "0"));

            ddlExDoctor.DataTextField = "DoctorName";
            ddlExDoctor.DataValueField = "DoctorID";
            ddlExDoctor.DataBind();
            ddlExDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));



        }


        public void BindAssignToTelecaller(int Cid)
        {
            ddlTelecaller.Items.Clear();
            BAL_EmployeeMaster objEMP = new BAL_EmployeeMaster();

            ddlTelecaller.DataSource = objEMP.GetAllTelecaller(Cid, SessionUtilities.RoleID);

            ddlTelecaller.DataTextField = "EMPName";
            ddlTelecaller.DataValueField = "EmployeeID";
            ddlTelecaller.DataBind();
            ddlTelecaller.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void getAllEnquiry()
        {
            string Cid = "0";
            string CID1 = "";
            int RoleId = 0;
            if (ddlclinicSearch.SelectedValue == "0")
            {
                if (SessionUtilities.RoleID == 1)
                {

                    Cid = SessionUtilities.Empid.ToString();
                    RoleId = SessionUtilities.RoleID;
                }
                else if (SessionUtilities.RoleID == 3)
                {

                    //DataTable dt1 = objcommon.GetDoctorByClinic(SessionUtilities.Empid);

                    //for (int i = 0; i < dt1.Rows.Count; i++)
                    //{
                    //    CID1 += dt1.Rows[i]["ClinicID"] + ",";
                    //}

                    //if (CID1 != "")
                    //{
                    //    CID1 = CID1.Remove(CID1.Length - 1);
                    //}
                    //Cid = CID1;
                    Cid = "0";
                    RoleId = SessionUtilities.RoleID;
                }
                else if (SessionUtilities.RoleID == 9 || SessionUtilities.RoleID == 5)
                {

                    //DataTable dt1 = objcommon.GetByTelecallerClinic(SessionUtilities.Empid, SessionUtilities.RoleID);

                    //for (int i = 0; i < dt1.Rows.Count; i++)
                    //{
                    //    CID1 += dt1.Rows[i]["ClinicID"] + ",";
                    //}

                    //if (CID1 != "")
                    //{
                    //    CID1 = CID1.Remove(CID1.Length - 1);
                    //}
                    //Cid = CID1;
                    Cid = "0";
                    RoleId = SessionUtilities.RoleID;
                }
                else
                {

                    Cid = "0";
                    RoleId = 0;
                }
            }
            else
            {
                Cid = ddlclinicSearch.SelectedValue;
            }

            AllData = objENQ.GetAllEnquirynew(Cid, txtSearch.Text.Trim(), txttxtMobailNoss.Text.Trim(), Convert.ToInt32(ddlEnquirysourceSearch.SelectedValue), txtFromEnquiryDate.Text, txtToEnquiryDate.Text, RoleId, Convert.ToInt32(SessionUtilities.Empid));

            Session["EnquiryDetails"] = AllData;
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        public void BindCountry()
        {
            ddlCountry.DataSource = objcommon.CountryMaster();
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "ID";
            ddlCountry.DataBind();

            ddlCountry.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }

        public void EnqNo()
        {
            txtENqDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

            int Eno = objcommon.GetEnquiryNo();
            txtEnquiryNO.Text = "E" + Eno.ToString();
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

        public void BindEnquirySource()
        {
            int iCount = 0;
            int C = 0;
            DataTable dtES = objES.GetAllEnqirySource();
            if (dtES != null && dtES.Rows.Count > 0)
                iCount = dtES.Rows.Count;

            C = iCount + 1;
            ddlEnquirySource.DataSource = dtES;
            ddlEnquirySource.DataTextField = "Sourcename";
            ddlEnquirySource.DataValueField = "Sourceid";

            ddlEnquirySource.DataBind();

            ddlEnquirySource.Items.Insert(0, new ListItem("--- Select ---", "0"));

            // ddlEnquirySource.Items.Insert(iCount, new ListItem("Other", "-1"));
        }



        public void BindEnquirySourceSearch()
        {
            DataTable dtES = objES.GetAllEnqirySource();
            ddlEnquirysourceSearch.DataSource = dtES;
            ddlEnquirysourceSearch.DataTextField = "Sourcename";
            ddlEnquirysourceSearch.DataValueField = "Sourceid";

            ddlEnquirysourceSearch.DataBind();

            ddlEnquirysourceSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));

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

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {

            int Isv = 0;
            try
            {
                int _isInserted = -1;

                string LavelCode = "";
                if (RadInterestLavel.SelectedItem.Text == "1")
                {
                    LavelCode = "Cold";
                }
                else if (RadInterestLavel.SelectedItem.Text == "2" || RadInterestLavel.SelectedItem.Text == "3")
                {
                    LavelCode = "Warm";
                }
                else
                {
                    LavelCode = "hot";
                }

                string FollowupDate = "";

                if (txtFollowupDate.Text != "")
                {
                    FollowupDate = txtFollowupDate.Text;
                }
                else
                {
                    FollowupDate = "01-01-1999";

                }
                string c = ddlCity.SelectedValue;

                // string Fdate = txtFollowupDate.Text;

                Enquiry_Details objEnqDetails = new Enquiry_Details()
                {
                    EnquiryID = EnquiryID,
                    // CatId = Convert.ToInt32(ddlInterested.SelectedValue),
                    Sourceid = Convert.ToInt32(ddlEnquirySource.SelectedValue),
                    // PurposeId = Convert.ToInt32(ddlPurpose.SelectedValue),
                    Enquiryno = txtEnquiryNO.Text,
                    // EnquiryDate = Convert .ToDateTime(txtENqDate.Text),
                    EnquiryDate = txtENqDate.Text,
                    ClinicID = Convert.ToInt32(ddlclinic.SelectedValue),
                    FirstName = txtFname.Text,
                    LastName = txtLname.Text,
                    // DateBirth = Convert .ToDateTime (txtBDate.Text),
                    DateBirth = txtBDate.Text,
                    Age = txtAge.Text,
                    Gender = RadGender.SelectedItem.Text,
                    Address = txtAddress.Text,
                    CountryId = Convert.ToInt32(ddlCountry.SelectedValue),
                    stateid = Convert.ToInt32(ddlState.SelectedValue),
                    Cityid = Convert.ToInt32(ddlCity.SelectedValue),
                    Area = txtArea.Text,
                    Email = txtEmail.Text,
                    Mobile = txtMobile.Text,
                    Telephone = txtTelephone.Text,
                    ReceivedByEmpId = Convert.ToInt32(ddlclinic.SelectedValue),
                    AssignToEmpId = Convert.ToInt32(ddlAssign.SelectedValue),
                    RoleId = Convert.ToInt32(SessionUtilities.RoleID),
                    TelecallerToEmpId = Convert.ToInt32(ddlTelecaller.SelectedValue),
                    Status = Rabinfo.SelectedValue,
                    //Folllowupdate = Convert.ToDateTime(txtFollowupDate.Text),

                    Folllowupdate = FollowupDate,
                    InterestLevel = RadInterestLavel.SelectedItem.Text,
                    InterestLevelCode = LavelCode,
                    // CreatedDate = System.DateTime.Now.ToString (),
                    Conversation = txtConversion.Text,
                    CreatedBy = SessionUtilities.Empid,
                    TreatmentID = Convert.ToInt32(ddlTreatment.SelectedValue),
                    //Dhaval
                    Pstatus = RBtnLstPsta.SelectedItem.Text,
                    IsActive = true
                };

                if (EnquiryID > 0)
                {

                }
                else
                {
                    Isv = objENQ.GetEnqurysIsvelid(txtMobile.Text);

                }
                if (Isv > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Mobile number already in use')", true);

                    lblMessage.Text = "Mobile number already in use";
                    lblMessage.ForeColor = System.Drawing.Color.Red;

                }
                else
                {
                    _isInserted = objENQ.Add_Enquiry(objEnqDetails);

                    if (_isInserted == -1)
                    {
                        lblMessage.Text = "Failed to Add Enquiry";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {

                        // lblMessage.Text = "Enquiry Added Successfully";
                        //lblMessage.ForeColor = System.Drawing.Color.Green;
                        //txtCompanyName.Text = "";
                        //txtBrandName.Text = "";

                        string url = "EnquiryDetails.aspx";


                        string message = "Enquiry Added Successfully";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);



                        if (Rabinfo.SelectedValue == "Patient")
                        {

                            string Eid = objENQ.GetEnqMaxId();

                            Response.Redirect("../patient/PatientMaster.aspx?Eid=" + Eid);
                        }
                        else
                        {
                            getAllEnquiry();
                            ///  Response.Redirect("EnquiryDetails.aspx");

                        }
                        EnquiryID = 0;
                        // getAllMaterial();
                        //btSearch_Click(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllEnquiry();
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

                EnquiryID = ID;

                try
                {

                    DataTable dt = objENQ.GetSelectAllEnquiry(ID);

                    txtEnquiryNO.Text = dt.Rows[0]["Enquiryno"].ToString();
                    txtENqDate.Text = Convert.ToDateTime(dt.Rows[0]["EnquiryDate"]).ToString("dd-MM-yyyy");
                    txtFname.Text = dt.Rows[0]["FirstName"].ToString();
                    txtLname.Text = dt.Rows[0]["LastName"].ToString();
                    Rabinfo.Enabled = false;
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
                    //  txtBDate.Text = Convert.ToDateTime(dt.Rows[0]["DateBirth"]).ToString("dd-MM-yyyy");

                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                    txtArea.Text = dt.Rows[0]["Area"].ToString();
                    txtTelephone.Text = dt.Rows[0]["Telephone"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    if (dt.Rows[0]["Folllowupdate"].ToString() != "")
                    {
                        if (Convert.ToDateTime(dt.Rows[0]["Folllowupdate"]).ToString("dd-MM-yyyy") == "01-01-1999")
                        {
                            txtFollowupDate.Text = "";
                        }
                        else
                        {

                            txtFollowupDate.Text = dt.Rows[0]["Folllowupdate"].ToString();
                        }
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
                    BindEnquirySource();
                    if (dt.Rows[0]["Sourceid"].ToString() != "")
                    {
                        ddlEnquirySource.SelectedValue = dt.Rows[0]["Sourceid"].ToString();
                    }
                    //  ddlPurpose.SelectedValue = dt.Rows[0]["PurposeId"].ToString();
                    //  ddlReceivedBy.SelectedValue = dt.Rows[0]["ReceivedByEmpId"].ToString();
                    //  ddlAssign.SelectedValue = dt.Rows[0]["AssignToEmpId"].ToString();
                    if (dt.Rows[0]["Gender"].ToString() != "")
                    {
                        // RadGender.SelectedValue = dt.Rows[0]["Gender"].ToString();

                        RadGender.Items.FindByText(dt.Rows[0]["Gender"].ToString()).Selected = true;
                    }
                    txtConversion.Text = dt.Rows[0]["Conversation"].ToString();


                    if (dt.Rows[0]["InterestLevel"].ToString() != "")
                    {
                        // RadInterestLavel.SelectedValue = dt.Rows[0]["InterestLevel"].ToString();
                        RadInterestLavel.Items.FindByText(dt.Rows[0]["InterestLevel"].ToString()).Selected = true;
                    }
                    Bindddlclinic();
                    ddlclinic.SelectedValue = dt.Rows[0]["ClinicID"].ToString();
                    BindAssignToEmp(Convert.ToInt32(dt.Rows[0]["ClinicID"]));
                    if (dt.Rows[0]["AssignToEmpId"].ToString() != "")
                    {
                        ddlAssign.SelectedValue = dt.Rows[0]["AssignToEmpId"].ToString();
                    }
                    bindddlTreatment();
                    if (dt.Rows[0]["TreatmentID"].ToString() != "")
                    {
                        ddlTreatment.SelectedValue = dt.Rows[0]["TreatmentID"].ToString();
                    }
                    //   Rabinfo.SelectedValue = dt.Rows[0]["Status"].ToString();
                    if (dt.Rows[0]["Status"].ToString() != "")
                    {
                        Rabinfo.Items.FindByText(dt.Rows[0]["Status"].ToString()).Selected = true;

                    }
                    if (dt.Rows[0]["Status"].ToString() == "Followup")
                    {
                        IDF.Visible = true;
                        if (dt.Rows[0]["Folllowupdate"].ToString() != "")
                        {
                            if (Convert.ToDateTime(dt.Rows[0]["Folllowupdate"]).ToString("dd-MM-yyyy") == "01-01-1999")
                            {
                                txtFollowupDate.Text = "";
                            }
                            else
                            {

                                txtFollowupDate.Text = Convert.ToDateTime(dt.Rows[0]["Folllowupdate"]).ToString("dd-MM-yyyy");
                            }
                        }
                    }
                    //  ddlUOM.SelectedValue = dt.Rows[0]["UOMId"].ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (e.CommandName == "viewEnqDetails")
            {
                int ID1 = Convert.ToInt32(e.CommandArgument);

                EnquiryID = ID1;

                Response.Redirect("ViewEnquiry.aspx?Eid=" + EnquiryID);
            }
        }

        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objENQ.DeleteEnquiry(ID);
                if (_isDeleted != -1)
                {

                    lblMessage.Text = "Enquiry Deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("EnquiryDetails.aspx");
                    btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShow.EditIndex = -1;
            btSearch_Click(sender, e);
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {


                getAllEnquiry();

            }
            catch (Exception ex)
            {
            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Add.Visible = true;
            btAdd.Visible = true;
            Edit.Visible = false;
            Div2.Visible = false;

            btUpdate.Visible = false;
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
            Div2.Visible = false;
            Rabinfo.Enabled = true;
        }


        protected void btnAddexcelupload_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = false;
            Div2.Visible = true;

            Div2.Visible = true;
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Clear();
            getAllEnquiry();
            Edit.Visible = true;
            Add.Visible = false;
            Div2.Visible = false;
        }

        public void Clear()
        {
            CleartextBoxes(this);
            // BindCountry();
            EnqNo();

            Bindddlclinic();
            BindCountry();
            ddlCountry.SelectedValue = "1";
            BindState();
            ddlState.SelectedValue = "2";
            BindCity();
            ddlCity.SelectedValue = "34";
            bindddlTreatment();
            BindEnquirySourceSearch();
            BindEnquirySource();

            if (SessionUtilities.RoleID == 1)
            {
                ddlclinic.SelectedValue = SessionUtilities.Empid.ToString();
                BindAssignToEmp(SessionUtilities.Empid);
            }
            bindClinicSearch();
            if (SessionUtilities.RoleID == 2)
            {
                Cid.Visible = true;
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



        protected void btbtnExlCancel_Click(object sender, EventArgs e)
        {

            Edit.Visible = true;
            Add.Visible = false;
            Div2.Visible = false;
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
            BindCity();
        }

        protected void ddlclinic_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RadioRole.SelectedValue == "3")
            {
                BindAssignToEmp(Convert.ToInt32(ddlclinic.SelectedValue));
            }
            else if (RadioRole.SelectedValue == "9")
            {
                BindAssignToTelecaller(Convert.ToInt32(ddlclinic.SelectedValue));
            }
            else if (RadioRole.SelectedValue == "5")
            {
                BindAssignToTelecaller(Convert.ToInt32(ddlclinic.SelectedValue));
            }
            else
            {

            }
        }

        protected void Rabinfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Rabinfo.SelectedValue == "Followup")
            {

                IDF.Visible = true;
            }
            else
            {
                IDF.Visible = false;

            }
        }

        protected void ddlEnquirySource_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlEnquirySource.SelectedItem.Text == "Other")
            //{
            //    LinkButton1.Visible = true;
            //}
            //else
            //{

            //    LinkButton1.Visible = false;
            //}
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void txtBDate_TextChanged(object sender, EventArgs e)
        {

            General objG = new General();
            DateTime now = DateTime.Today;
            DateTime birthday = objG.getDatetime(txtBDate.Text);
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;
            txtAge.Text = age.ToString();
        }

        protected void btnExcel1_Click1(object sender, EventArgs e)
        {
            DataTable dtDataExcel = (DataTable)Session["EnquiryDetails"];

            if (dtDataExcel != null && dtDataExcel.Rows.Count > 0)
            {

                List<ExcelRows> objExcelRows = new List<ExcelRows>();
                ExcelRows obj = new ExcelRows();
                obj.ColumnHeaderName = "Enquiry Report";
                obj.ColumnValue = null;
                objExcelRows.Add(obj);
                GridViewExportUtil.ExportToExcelManual("EnquiryReport", objExcelRows, dtDataExcel, null);
                lblMessage.Text = "";


            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No Record exists for Excel Download.";
                return;
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
                    if (objFailQuestion != null && objFailQuestion.Count > 0)
                    {
                        //  divOptionalMessage.Visible = true;
                        // divOptionalMessageSub.Attributes.Remove("class");
                        // divOptionalMessageSub.Attributes.Add("class", "errormsg");
                        // lblOptionalmsg.Attributes.Add("style", "color:red");
                        string strresult = "Following Enquiry fail to upload<br/>";
                        string mismatchdata = "";
                        foreach (FailedQuestionList item in objFailQuestion)
                        {
                            strresult += "EnQ No : " + item.srno + " :";
                            mismatchdata = "";


                            if (item.IsTreatmentIDMismatch)
                            {
                                if (string.IsNullOrEmpty(mismatchdata))
                                    mismatchdata = "Treatment";
                                else
                                    mismatchdata += ",Treatment";
                            }
                            if (item.IsClinicIDMismatch)
                            {
                                if (string.IsNullOrEmpty(mismatchdata))
                                    mismatchdata = "Clinic";
                                else
                                    mismatchdata += ",Clinic";
                            }


                            strresult += mismatchdata + " is not matched<hr><br/>";
                        }


                        lblMSG1.Text = strresult;
                        Result = false;
                    }
                    else
                    {
                        Result = true;


                        string url = "EnquiryDetails.aspx";


                        string message = "Enquiry Added Successfully. No of Save records " + iResult;
                        //string script = "window.onload = function(){ alert('";
                        //script += message;
                        //script += "');";
                        //script += "window.location = '";
                        //script += url;
                        //script += "'; }";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                        //   string url = "MyTaskGrower.aspx";
                        //   string message = "Assignment Successful";

                        //  ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + message + "'); window.location='" + url + "';", true);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + message + "');", true);
                    }
                }
                catch (Exception ex)
                {
                    Result = false;
                    ErrorName = "Enquiry Information Not Saved";
                }
            }
            else
            {
                Result = false;
                ErrorName = "Invalid File. Please Select proper file.";
            }
        }


        protected int SaveExcelDataToDataBase(DataTable dtExcel, ref List<FailedQuestionList> objFailQuestion)
        {
            try
            {

                bool IsValidChapter = false;
                bool Result = false;
                int reccount = 1;
                int SaveCount = 0;
                int NotSaveCount = 0;
                // create list object
                BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
                //    CourseMasterBLL objCourseMasterBLL = new CourseMasterBLL();
                List<EnqyiryExcel> objEnq = new List<EnqyiryExcel>();
                foreach (DataRow item in dtExcel.Rows)
                {
                    //   reccount = 1;
                    int SourceID = 0, TreatmentID = 0, ClinicID = 0, DoctorID = 0;
                    //int FieldID = 0, Groupid = 0;

                    if (!string.IsNullOrEmpty(Common.CheckNullandEmpty(item["FirstName"])))

                    {
                        int Eno = objcommon.GetEnquiryNo();
                        string EnquiryNO = "E" + Eno.ToString();

                        if (item["Mobile"].ToString().Trim() != "" || item["FirstName"].ToString().Trim() != "")
                        {
                            int Isv = objENQ.GetEnqurysIsvelid(item["Mobile"].ToString().Trim());

                            if (Isv > 0)
                            {
                                NotSaveCount++;

                                EnqyiryExcel objNewRow = new EnqyiryExcel();
                                objNewRow.Name = item["FirstName"].ToString().Trim() + ' ' + item["LastName"].ToString().Trim();
                                objNewRow.Email = item["Email"].ToString().Trim();
                                objNewRow.Mobile = item["Mobile"].ToString().Trim();
                                objNewRow.srno = NotSaveCount;
                                objEnq.Add(objNewRow);
                            }
                            else
                            {
                                SaveCount++;
                                int SourceId = 0;
                                SourceId = objcommon.GetEnquirySourceId(item["EnquirySource"].ToString().Trim());
                                if (SourceId == 0)
                                {
                                    SourceId = 29;
                                }
                                objENQ.SaveExcelUploadedEnquiry(Convert.ToInt32(item["Treatment"]), Convert.ToInt32(ddlClinicUploadExcel.SelectedValue), EnquiryNO, item["FirstName"].ToString().Trim(), item["LastName"].ToString().Trim(), item["Email"].ToString().Trim(), item["Mobile"].ToString().Trim(), item["Conversation"].ToString().Trim(), SessionUtilities.Empid, SessionUtilities.RoleID, SourceId, Convert.ToInt32(ddlExDoctor.SelectedValue), Convert.ToInt32(ddlExcelTelecaller.SelectedValue));

                            }
                        }
                        reccount++;
                    }


                }

                ListtoDataTable lsttodt = new ListtoDataTable();
                DataTable dt = lsttodt.ToDataTable(objEnq);
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridViewExcelNotSave.DataSource = dt;
                    GridViewExcelNotSave.DataBind();
                    PanelNotSaveEnquiry.Visible = true;
                }


                return Convert.ToInt32(SaveCount);

            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            //return 1;
        }



        public class ListtoDataTable
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties by using reflection   
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names  
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {

                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                return dataTable;
            }
        }
        protected void GridViewExcelNotSave_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewExcelNotSave.PageIndex = e.NewPageIndex;

            List<EnqyiryExcel> objEnq = new List<EnqyiryExcel>();
            ListtoDataTable lsttodt = new ListtoDataTable();
            DataTable dt = lsttodt.ToDataTable(objEnq);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridViewExcelNotSave.DataSource = dt;
                GridViewExcelNotSave.DataBind();
                PanelNotSaveEnquiry.Visible = true;
            }
        }

        protected void btndownloadOptional_Click(object sender, EventArgs e)
        {

            // DownloadFile("Enquiry_Master.xlsx", "Enquiry_Master.xlsx");
            DownloadFile("Enquiry_Master.xls", "Enquiry_Master.xls");
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

        protected void RadioRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioRole.SelectedValue == "3")
            {
                PanelDoctor.Visible = true;
                PanelTelecaller.Visible = false;
                BindAssignToEmp(Convert.ToInt32(ddlclinic.SelectedValue));
            }
            else
            {
                PanelDoctor.Visible = false;
                PanelTelecaller.Visible = true;
                BindAssignToTelecaller(Convert.ToInt32(ddlclinic.SelectedValue));
            }

        }


        protected void ddlClinicUploadExcel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAssignToEmp(Convert.ToInt32(ddlClinicUploadExcel.SelectedValue));
            BindExcelAssignToTelecaller(Convert.ToInt32(ddlClinicUploadExcel.SelectedValue));
        }

        protected void ExcelRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ExcelRadioButtonList.SelectedValue == "3")
            {
                ExcelDocPanel1.Visible = true;
                ExcelTelPanel2.Visible = false;

            }
            else
            {
                ExcelDocPanel1.Visible = false;
                ExcelTelPanel2.Visible = true;

            }
            BindAssignToEmp(Convert.ToInt32(ddlClinicUploadExcel.SelectedValue));
            BindExcelAssignToTelecaller(Convert.ToInt32(ddlClinicUploadExcel.SelectedValue));
        }


        public void BindExcelAssignToTelecaller(int Cid)
        {
            ddlExcelTelecaller.Items.Clear();
            BAL_EmployeeMaster objEMP = new BAL_EmployeeMaster();

            ddlExcelTelecaller.DataSource = objEMP.GetAllTelecaller(Cid, SessionUtilities.RoleID);

            ddlExcelTelecaller.DataTextField = "EMPName";
            ddlExcelTelecaller.DataValueField = "EmployeeID";
            ddlExcelTelecaller.DataBind();
            ddlExcelTelecaller.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
    }






}