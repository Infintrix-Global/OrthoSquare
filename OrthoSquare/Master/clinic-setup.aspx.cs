﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Net;

namespace OrthoSquare.Branch
{
    public partial class clinic_setup : System.Web.UI.Page
    {
        BasePage objBasePage = new BasePage();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Clinic objClinic = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAllClinic();
                BindLocation();
                BindCountry();
                txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            }
        }

        private long clinicID
        {
            get
            {
                if (ViewState["clinicID"] != null)
                {
                    return (long)ViewState["clinicID"];
                }
                return 0;
            }
            set
            {
                ViewState["clinicID"] = value;
            }
        }

        public void getAllClinic()
        {

            AllData = objClinic.GetAllClinicDetais();
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        public void BindLocation()
        {
            ddl_Location.DataSource = objcommon.AreaMaster();
            ddl_Location.DataValueField = "LocationID";
            ddl_Location.DataTextField = "LocationName";
            ddl_Location.DataBind();
            ddl_Location.Items.Insert(ddl_Location.Items.Count, new ListItem("Other Location", "Other Location"));

        }

        public void BindCountry()
        {
            ddlCountry.DataSource = objcommon.CountryMaster();
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "ID";
            ddlCountry.DataBind();

            ddlCountry.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }
        public void BindState()
        {
            ddlState.DataSource = objcommon.NewStateMaster(Convert.ToInt32(ddlCountry.SelectedValue));
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();

            ddlState.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        public void BindCity()
        {
            ddlCity.DataSource = objcommon.CityMaster(Convert.ToInt32(ddlState.SelectedValue));
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

        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;

              //  string Password = objBasePage.Encryptdata(txtPassword.Text.Trim());

                string checkpwd = objBasePage.Decryptdata("cGtjNjE1Mg==");

                int Lid = 0;

                if (ddl_Location.SelectedItem.Text == "Other Location")
                {
                    Lid = 0;

                }
                else
                {
                    Lid = Convert.ToInt32(ddl_Location.SelectedValue);

                }





                ClinicDetails objClinicDetails = new ClinicDetails()
                {
                    clinicID = clinicID,
                    ClinicName  = txtClinicName .Text ,
                    FirstName = txtFristName .Text ,
                    LastName =txtLastName .Text ,
                    AddressLine1  = txtAddress1.Text,
                    AddressLine2  = txtAddress2.Text,
                    CountryID  = Convert .ToInt32(ddlCountry.SelectedValue) ,
                    StateID = Convert .ToInt32(ddlState.SelectedValue),
                    CityID= Convert .ToInt32(ddlCity.SelectedValue)  ,
                    LocationID =Lid ,
                    PhoneNo1  = txtMobile.Text,
                    PhoneNo2 = txtTelephone .Text,
                    Emailid = txtEmail .Text ,
                    Noofweek  = ddl_DayOfWeek .SelectedItem .Text ,
                    openTime = txtOpenTime .Text ,
                    CloseTime  = txtCloseTime .Text ,
                    UserName=txtFristName.Text,
                    UserPassword = txtFristName.Text+"@123",
                    LocationName =txtLocation.Text,
                    IsActive = true
                };

                _isInserted = objClinic.Add_Clinic(objClinicDetails);

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Clinic";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {



                    clinicID = 0;


                   int CID= objClinic. GetClinicID();

                  int IDC= objClinic.Add_AppointmentDetails
                      
                      (CID);

                    lblMessage.Text = "Clinic Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    SendMail();
                    Clear();
                   // txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                   
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void ddl_Location_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Location.SelectedItem.Text == "Other Location")
            {
                locationDiv.Visible = true;

            }
            else
            {
                locationDiv.Visible = false;

            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
            getAllClinic();
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEnquiry")
            {
                Add.Visible = true;
                btUpdate.Visible = true;
                btAdd.Visible = true;
                Edit.Visible = false;
                int ID = Convert.ToInt32(e.CommandArgument);

                clinicID = ID;

                try
                {

                    DataTable dt = objClinic .GetSelectAllClinic(ID);
                    
                    txtClinicName.Text = dt.Rows[0]["ClinicName"].ToString();
                    txtAddress1.Text = dt.Rows[0]["AddressLine1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["AddressLine2"].ToString();
                    txtMobile.Text = dt.Rows[0]["PhoneNo1"].ToString();
                    txtTelephone.Text = dt.Rows[0]["PhoneNo2"].ToString();
                    txtEmail.Text = dt.Rows[0]["EmailID"].ToString();

                    BindCountry();
                    ddlCountry.SelectedValue = dt.Rows[0]["CountryID"].ToString();
                    BindState();
                    ddlState.SelectedValue = dt.Rows[0]["StateID"].ToString();
                    BindCity();
                    ddlCity.SelectedValue = dt.Rows[0]["CityID"].ToString();
                    BindLocation();
                    ddl_Location.SelectedValue = dt.Rows[0]["LocationID"].ToString();
                    ddl_DayOfWeek.SelectedItem.Text = dt.Rows[0]["DayOfWeek"].ToString();
                    txtOpenTime.Text = dt.Rows[0]["OpenTime"].ToString();
                    txtCloseTime.Text = dt.Rows[0]["CloseTime"].ToString();
                  //  txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                 //   txtPassword.Text = dt.Rows[0]["Password"].ToString();
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objClinic.DeleteClinic(ID);
                if (_isDeleted != -1)
                {

                    lblMessage.Text = "Clinic Deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                  //  Response.Redirect("EnquiryDetails.aspx");
                    btSearch_Click(sender, e);
                   
                    getAllClinic();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


           
        }


        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            var fromAddress = "infintrix.world@gmail.com";
            // any address where the email will be sending
            //var toAddress = "mehulrana1901@gmail.com,urvi.gandhi@infintrixglobal.com,nidhi.mehta@infintrixglobal.com,bhavin.gandhi@infintrixglobal.com,mehul.rana@infintrixglobal.com,naimisha.rohit@infintrixglobal.com";

            var toAddress = txtEmail.Text;

            //Password of your gmail address
            const string fromPassword = "Infintrixworld@123";
            // Passing the values and make a email formate to display
            string subject = "Your UserName and Password For Ortho Square";
            string body = "Dear ," + "\n";
            body += "Your UserName and passward For OrthoSquare :" + "\n";
            body += "UserName : " + txtFristName.Text + " " + "\n\n";
            body += "Passward : " + txtFristName.Text + "@123" + " " + "\n\n";
            body += "Thank you!" + "\n";
            body += "Warm Regards," + "\n";

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 50000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
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
                string search = "";
                
                if (txtSearch.Text != "")
                {
                    search += "ClinicName like '%" + txtSearch.Text + "%'";
                }
                else
                {
                    // search += "Mobile = " + txtm.Text + "";
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
            catch (Exception ex)
            {
            }
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
        }

        public void Clear()
        {
            CleartextBoxes(this);
            BindCountry();
            BindLocation();
            ddlState.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlCity.Items.Insert(0, new ListItem("--- Select ---", "0"));
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
    }
}