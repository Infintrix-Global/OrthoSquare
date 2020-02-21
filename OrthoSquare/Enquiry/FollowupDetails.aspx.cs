﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;

namespace OrthoSquare.Enquiry
{
    public partial class FollowupDetails : System.Web.UI.Page
    {
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        public static DataTable AllData = new DataTable();
        BAL_FollowupMode objFMode = new BAL_FollowupMode();
        BAL_Enquirystatus objStatus = new BAL_Enquirystatus();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_EnquirySource objES = new BAL_EnquirySource();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnqNo();
                getAllEnquiry();
                BindEnquiryStatus();
                BindFollowupmode();
                BindEnquirySource();
                BindReceivedByEmp();
            }
        }

        public void EnqNo()
        {

            int Eno = objcommon.GetFollowupNo();
            txtFollowupID.Text = "F" + Eno.ToString();
        }

        private long Followupid
        {
            get
            {
                if (ViewState["Followupid"] != null)
                {
                    return (long)ViewState["Followupid"];
                }
                return 0;
            }
            set
            {
                ViewState["Followupid"] = value;
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


        public void getAllEnquiry()
        {


            if (SessionUtilities.RoleID == 3)
            {

                AllData = objENQ.GetAllEnquiryFollowpDetails(Convert .ToInt32 (SessionUtilities.Empid));

            }
            else
            {

                AllData = objENQ.GetAllEnquiryFollowup();
            }
            //Dhaval
            for (int i = 0; i < AllData.Rows.Count; i++)
            {
                if (AllData.Rows[i]["Pstatus"].ToString() == "1")
                { AllData.Rows[i]["Pstatus"] = "Less Co-operative"; }
                else if(AllData.Rows[i]["Pstatus"].ToString() == "2")
                { AllData.Rows[i]["Pstatus"] = "Co-operative"; }
                else if (AllData.Rows[i]["Pstatus"].ToString() == "3")
                { AllData.Rows[i]["Pstatus"] = "Very Co-operative"; }
            }
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        public void BindEnquirySource()
        {
            ddlSource.DataSource = objES.GetAllEnqirySource();
            ddlSource.DataTextField = "Sourcename";
            ddlSource.DataValueField = "Sourceid";
            ddlSource.DataBind();

            ddlSource.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        public void BindFollowupmode()
        {
            ddlFollowupmode.DataSource = objFMode.GetAllFollowupMode();
            ddlFollowupmode.DataTextField = "ModeName";
            ddlFollowupmode.DataValueField = "ModeId";
            ddlFollowupmode.DataBind();

            ddlFollowupmode.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindEnquiryStatus()
        {
            ddlStatus.DataSource = objStatus.GetAllEnquirystatus();

            ddlStatus.DataTextField = "statusName";
            ddlStatus.DataValueField = "StatusId";
            ddlStatus.DataBind();
           // ddlStatus.Items.Insert(0, "---Select---");
            ddlStatus.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void BindReceivedByEmp()
        {
           

            ddlRecievedby.DataSource = objcommon.clinicMaster();
            ddlRecievedby.DataTextField = "ClinicName";
            ddlRecievedby.DataValueField = "ClinicID";
            ddlRecievedby.DataBind();

            ddlRecievedby.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;

        }


        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "AddCustomer")
            {
                string Eid = e.CommandArgument.ToString();
                EnquiryID = Convert .ToInt32 (Eid);
                Response.Redirect("../patient/PatientMaster.aspx?Eid=" + Eid);
            }


            if (e.CommandName == "FollowupEnquiry")
            {
                AddPane.Visible = true;


                Edit.Visible = false;
                int ID = Convert.ToInt32(e.CommandArgument);

                EnquiryID = ID;

                try
                {

                    DataTable dt = objENQ.GetSelectAllEnquiry(ID);

                    lblName.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    lblEnqDate.Text = Convert.ToDateTime(dt.Rows[0]["EnquiryDate"]).ToString("dd-MM-yyyy");
                    lblAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblMobileNo.Text = dt.Rows[0]["Mobile"].ToString() + ", " + dt.Rows[0]["Telephone"].ToString();
                    lblSourse.Text = dt.Rows[0]["Sourcename"].ToString();
                    lblEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtTodayFollowupdate.Text = Convert.ToDateTime(dt.Rows[0]["Folllowupdate"]).ToString("dd-MM-yyyy");
                    txtEmployee.Text = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    lblEqNo.Text = dt.Rows[0]["Enquiryno"].ToString();
                    lblEmpNo.Text = dt.Rows[0]["AssignToEmpId"].ToString();
                    lblEnqID.Text = dt.Rows[0]["EnquiryID"].ToString();
                    //  ddlUOM.SelectedValue = dt.Rows[0]["UOMId"].ToString();

                    BindFolloup(ID);



                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void BindFolloup(int Eid)
        {

            GridViewFolloup.DataSource = objENQ.GetAllEnquiryFollowup1(Convert .ToInt32 (Eid));
            GridViewFolloup.DataBind();

          
        }



        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;

                Followup_Details objFollowupDetails = new Followup_Details()
                {

                    Followupid = Followupid,
                    FollowupCode = "F001",
                    EnquiryID = Convert.ToInt32(lblEnqID.Text),
                    ClinicID =SessionUtilities .Empid ,
                    employeeid = Convert.ToInt32(lblEmpNo.Text),
                    enquiryno = lblEqNo.Text,
                    Followupdate = txtTodayFollowupdate.Text,
                    Followupmodeid = Convert.ToInt32(ddlFollowupmode.SelectedValue),
                    ConversationDetails = txtConversion.Text,
                    NextFollowupdate = txtNextFollowupDate.Text,
                    InterestLevel = RadInterestLavel.SelectedItem.Text,
                    Statusid = Convert.ToInt32(ddlStatus.SelectedValue),
                    Remak = txtRemark.Text,
                    CreatedBy = 1

                };

                _isInserted = objENQ.Add_Followup(objFollowupDetails);

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Followup";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                  //  EnquiryID = 0;
                    lblMessage.Text = "Followup Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;


                    if (ddlStatus.SelectedItem.Text == "Patient")
                    {

                        Response.Redirect("../patient/PatientMaster.aspx?Eid=" + EnquiryID);

                    }

                    //txtCompanyName.Text = "";
                    //txtBrandName.Text = "";
                    Response.Redirect("FollowupDetails.aspx");
                    // getAllMaterial();
                    //btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
            }
        }



        protected void btnCancel1_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            AddPane.Visible = false;
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblEnquiryType = (Label)e.Row.FindControl("lblEnquiryType");
                Label lblInterestLevel = (Label)e.Row.FindControl("lblInterestLevel");
                Label lblEQid = (Label)e.Row.FindControl("lblID");
                Label lblTotalfollowUp = (Label)e.Row.FindControl("lblTotalfollowUp");

                Label lblFollowupDate = (Label)e.Row.FindControl("lblFollowupDate");

                Label lblFollowupNextDate = (Label)e.Row.FindControl("lblFollowupNextDate");
                Label lblFollowupsStatus = (Label)e.Row.FindControl("lblFollowupsStatus");

                ImageButton btnFollowup = (ImageButton)e.Row.FindControl("btnFollowup");
                ImageButton ImageButton1 = (ImageButton)e.Row.FindControl("ImageButton1");



                lblTotalfollowUp.Text = objENQ.GetFollowuTotal(Convert.ToInt32(lblEQid.Text));

                if (lblTotalfollowUp.Text != "0")
                {
                  

                }

                if (lblTotalfollowUp.Text == "0")
                {
                    if (lblInterestLevel.Text == "1")
                    {
                        lblEnquiryType.BackColor = System.Drawing.Color.Green;
                        lblEnquiryType.Font.Bold = true;

                        lblEnquiryType.ForeColor = System.Drawing.Color.White;
                    }
                    else if (lblInterestLevel.Text == "2" || lblInterestLevel.Text == "3")
                    {
                        lblEnquiryType.BackColor = System.Drawing.Color.Orange;
                        lblEnquiryType.Font.Bold = true;
                        lblEnquiryType.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        lblEnquiryType.BackColor = System.Drawing.Color.Red;
                        lblEnquiryType.Font.Bold = true;
                        lblEnquiryType.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {

                    DataTable dt = objENQ.GetEnquiryNextFollowupDate(Convert.ToInt32(lblEQid.Text));

                    lblFollowupDate.Visible = false;
                    lblFollowupNextDate.Text = Convert.ToDateTime(dt.Rows[0]["NextFollowupdate"]).ToString("dd-MM-yyyy");

                    lblFollowupsStatus.Text = dt.Rows[0]["statusName"].ToString();


                    if (lblFollowupsStatus.Text == "Closed " || lblTotalfollowUp.Text =="5")
                    {
                        btnFollowup.Enabled = false;
                        ImageButton1.Enabled = false;

                        lblFollowupsStatus.Text = "Closed";
                    }


                       lblInterestLevel.Text = objENQ.GetFollowulaveDetilas(Convert.ToInt32(lblEQid.Text));           
                    
                    if (lblInterestLevel.Text == "1")
                    {

                        lblEnquiryType.Text = "Cold";
                        lblEnquiryType.BackColor = System.Drawing.Color.Green;
                        lblEnquiryType.Font.Bold = true;

                        lblEnquiryType.ForeColor = System.Drawing.Color.White;
                    }
                    else if (lblInterestLevel.Text == "2" || lblInterestLevel.Text == "3")
                    {
                        lblEnquiryType.Text = "Warm";
                        lblEnquiryType.BackColor = System.Drawing.Color.Orange;
                        lblEnquiryType.Font.Bold = true;
                        lblEnquiryType.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        lblEnquiryType.Text = "hot";
                        lblEnquiryType.BackColor = System.Drawing.Color.Red;
                        lblEnquiryType.Font.Bold = true;
                        lblEnquiryType.ForeColor = System.Drawing.Color.White;
                    }



                }


            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = objFMode.FolloupSearchList(txtName.Text, txtMobile.Text, Convert.ToInt32(ddlSource.SelectedValue), Convert.ToInt32(ddlRecievedby.SelectedValue), txtFromEnquiryDate.Text, txtToEnquiryDate.Text, txtSFromFollowDate.Text, txtSToFollowDate.Text);

                gvShow.DataSource = dt;
                gvShow.DataBind();


                //string search = "";
                ////if (txtSearch.Text != "")
                ////{
                //if (txtSearch.Text != "")
                //{
                //    //search += "FirstName like '%" + txtSearch.Text + "%'";

                //    search += "FirstName ='" + txtSearch.Text + "',Mobile ='"+txtMobile.Text +"' "; 
                //}
                //else
                //{
                //    search += "FirstName ='" + txtSearch.Text + "',Mobile ='" + txtMobile.Text + "' "; 
                //    // search += "Mobile = " + txtm.Text + "";
                //}

                //DataRow[] dtSearch1 = AllData.Select(search);
                //if (dtSearch1.Count() > 0)
                //{
                //    DataTable dtSearch = dtSearch1.CopyToDataTable();
                //    gvShow.DataSource = dtSearch;
                //    gvShow.DataBind();
                //}
                //else
                //{
                //    DataTable dt = new DataTable();
                //    gvShow.DataSource = dt;
                //    gvShow.DataBind();
                //}
                ////}
                ////else
                ////{
                ////    gvShow.DataSource = AllData;
                ////    gvShow.DataBind();
                ////}
            }
            catch (Exception ex)
            {
            }
        }
    }
}