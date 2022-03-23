using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using System.IO;
using OrthoSquare.Utility;

namespace OrthoSquare.Employee
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_EmployeeMaster objEmp = new BAL_EmployeeMaster();
       
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
                getAllEmployee();
                BindRole();
                EmployeeCode();
                BindCountry();
                ddlCountry1.SelectedValue = "1";
                State();
                ddlState.SelectedValue = "2";
                City();
                ddlCity.SelectedValue = "34";
                Bindddlclinic();

                BindPermanentCountry();
                ddlPCountry.SelectedValue = "1";
                PermanentState();
                ddlPState.SelectedValue = "2";
                PermanentCity();
                ddlPCity.SelectedValue = "34";

                TabContactPerson1.Tabs[0].Enabled = true;

                TabContactPerson1.Tabs[1].Enabled = true;
                TabContactPerson1.Tabs[2].Enabled = true;
            }
        }

        public void getAllEmployee()
        {

            AllData = objEmp.GetAllEmployee(txtNAme.Text, txtMobiles.Text, txtE_code.Text );
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }


        
        public void EmployeeCode()
        {
            txtRegDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

            int Eno = objcommon.GetEmployeeCODE();

            txtEmpCode.Text = "EMP" + Eno.ToString();
        }


        public void Bindddlclinic()
        {
            ddlclinic.DataSource = objcommon.clinicMaster();
            ddlclinic.DataTextField = "ClinicName";
            ddlclinic.DataValueField = "ClinicID";
            ddlclinic.DataBind();

            ddlclinic.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }


        private long EmployeeID
        {
            get
            {
                if (ViewState["EmployeeID"] != null)
                {
                    return (long)ViewState["EmployeeID"];
                }
                return 0;
            }
            set
            {
                ViewState["EmployeeID"] = value;
            }
        }
        public void BindCountry()
        {
            ddlCountry1.DataSource = objcommon.CountryMaster();
            ddlCountry1.DataTextField = "CountryName";
            ddlCountry1.DataValueField = "ID";
            ddlCountry1.DataBind();

            ddlCountry1.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }


        public void BindRole()
        {
            ddlDesignation.DataSource = objcommon.GetRole();
            ddlDesignation.DataTextField = "RoleName";
            ddlDesignation.DataValueField = "RoleID";
            ddlDesignation.DataBind();

            ddlDesignation.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }
        public void BindPermanentCountry()
        {
            ddlPCountry.DataSource = objcommon.CountryMaster();
            ddlPCountry.DataTextField = "CountryName";
            ddlPCountry.DataValueField = "ID";
            ddlPCountry.DataBind();
            ddlPCountry.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }
        public void State()
        {
            ddlState.DataSource = objcommon.NewStateMaster(Convert.ToInt32(ddlCountry1.SelectedValue));
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
            //ddlState.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void PermanentState()
        {
            ddlPState.DataSource = objcommon.NewStateMaster(Convert.ToInt32(ddlPCountry.SelectedValue));
            ddlPState.DataTextField = "StateName";
            ddlPState.DataValueField = "StateID";
            ddlPState.DataBind();
            //ddlState.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void City()
        {
            ddlCity.DataSource = objcommon.CityMaster(Convert.ToInt32(ddlState.SelectedValue));
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();

            // ddlCity.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void PermanentCity()
        {
            ddlPCity.DataSource = objcommon.CityMaster(Convert.ToInt32(ddlPState.SelectedValue));
            ddlPCity.DataTextField = "CityName";
            ddlPCity.DataValueField = "CityID";
            ddlPCity.DataBind();
            // ddlCity.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        protected void btnUploadimage_Click(object sender, EventArgs e)
        {
            UploadImage();
        }
        public void UploadImage()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FuImage1.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FuImage1.Focus();
            }
            string DD = txtFname.Text;
            string aa = FuImage1.FileName;
            string ext = System.IO.Path.GetExtension(FuImage1.PostedFile.FileName).ToLower();
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

                if (FuImage1.HasFile)
                {

                    filename = Server.MapPath(FuImage1.FileName);
                    newfile = FuImage1.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\EmployeeProfile"))
                    {
                        try
                        {



                            //int imgID = objHeandle.HandlmaxID(Convert.ToInt32(ddlBrand.SelectedValue));

                            //int AddImageiD = imgID + 1;

                            string Imgname = txtEmpCode.Text + txtFname.Text;

                            string path = Server.MapPath(@"~\EmployeeProfile\");
                            System.IO.Directory.CreateDirectory(path);
                            FuImage1.SaveAs(path + @"\" + txtEmpCode.Text + txtFname.Text + ext);

                            ImagePhoto1.ImageUrl = @"~\EmployeeProfile\" + txtEmpCode.Text + txtFname.Text + ext;
                            ImagePhoto1.Visible = true;

                            lbl_filepath1.Text = Imgname + ext;


                        }
                        catch (Exception ex)
                        {
                            lbl_filepath1.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            State();
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            City();
        }
        protected void btnDocupload_Click(object sender, EventArgs e)
        {
            UploadImageDoc();
        }
        public void UploadImageDoc()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!fileDOc.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                fileDOc.Focus();
            }
            string DD = txtFname.Text;
            string aa = fileDOc.FileName;
            string ext = System.IO.Path.GetExtension(fileDOc.PostedFile.FileName).ToLower();
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

                if (fileDOc.HasFile)
                {

                    filename = Server.MapPath(fileDOc.FileName);
                    newfile = fileDOc.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\Material\Documents"))
                    {
                        try
                        {



                            //int imgID = objHeandle.HandlmaxID(Convert.ToInt32(ddlBrand.SelectedValue));

                            //int AddImageiD = imgID + 1;

                            string Imgname = txtEmpCode.Text;

                            string path = Server.MapPath(@"~\Material\Documents\");
                            System.IO.Directory.CreateDirectory(path);
                            fileDOc.SaveAs(path + @"\" + txtEmpCode.Text + ext);

                            ImgDoc.ImageUrl = @"~\Material\Documents\" + txtEmpCode.Text + ext;
                            ImgDoc.Visible = true;

                            lblDoc.Text = Imgname + ext;


                        }
                        catch (Exception ex)
                        {
                            lblDoc.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }
        protected void ddlPCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            PermanentState();
        }
        protected void ddlPState_SelectedIndexChanged(object sender, EventArgs e)
        {
            PermanentCity();
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

        public void ClearEmployeeDetails()
        {

            CleartextBoxes(this);
            ddlCountry1.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlState.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlCity.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlPCountry.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlPState.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlPCity.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ImagePhoto1.ImageUrl = "~/img/noimageavail.jpg";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string PermanentCountry1 = "", PermanentState1 = "", PermanentCity1="";

            if (CheCopy.Checked == true)
            {
                PermanentCountry1 = ddlCountry1.SelectedValue;
                PermanentState1=ddlState.SelectedValue;
                PermanentCity1 = ddlCity.SelectedValue;

            }
            else
            {

                PermanentCountry1 = ddlPCountry.SelectedValue;
                PermanentState1 = ddlPState.SelectedValue;
                PermanentCity1 = ddlPCity.SelectedValue;
            }



            try
            {
                int _isInserted = -1;

                Employee_Details objEmpDetails = new Employee_Details()
                {
                    EmployeeID = EmployeeID,
                    ClinicID = Convert .ToInt32 (ddlclinic .SelectedValue) ,
                    EmployeeCode = txtEmpCode.Text,
                    RegistrationDate =txtRegDate.Text,
                    FirstName = txtFname.Text,
                    MiddleName = txtMidName.Text,
                    Surname = txtLname.Text,
                    Gender = RadGender.SelectedItem.Text,
                    Nationality = dllNationality.SelectedItem.Text,
                    Religion = "",
                    Emp_Cast = "",
                    BloodGroup = txtBloodGroup.Text,
                    BirthDate = txtBirthDate.Text,
                    EmployeePhoto = lbl_filepath1.Text,

                    CurrentAddress = txtAddress.Text,
                    CurrentLandmark = txtArea.Text,
                    CurrentCountry = Convert.ToInt32(ddlCountry1.SelectedValue),
                    CurrentState = Convert.ToInt32(ddlState.SelectedValue),
                    CurrentCity = Convert.ToInt32(ddlCity.SelectedValue),
                    CurrentPinCode = txtperPincode.Text,
                    PermanentAddress = txtperAddress.Text,
                    PermanentLandmark = txtperArea.Text,


                    PermanentCountry = Convert.ToInt32(PermanentCountry1),
                    PermanentState = Convert.ToInt32(PermanentState1),
                    PermanentCity = Convert.ToInt32(PermanentCity1),
                    PermanentPinCode = txtperPincode.Text,
                    ResidentPhone = txtPerTelephoneNO.Text,
                    Mobile = txtMobile.Text,
                    Email = txtEmail.Text,

                    BankName = txtBankName.Text,
                    BranchName = txtBranchName.Text,
                    IFSC_Code = txtIFSC_Code.Text,
                    AccountHolderName = txtAccountHolderName.Text,
                    AccountNumber = txtAccountNo.Text,

                    AadhaarNo = txtAadhaarcard.Text,
                    DrivinglicenceNo = txtdrivinglicence.Text,
                    PassportNo = txtPassportNo.Text,
                    Documentimg = lblDoc.Text,
                    Role=Convert .ToInt32 (ddlDesignation.SelectedValue) ,
                    CreatedBy = SessionUtilities.Empid,
                    UserName = txtUsername .Text ,
                    Password =txtPassword .Text ,
                    ModifiedBy = SessionUtilities.Empid,


                };

                _isInserted = objEmp.Add_EmployeeDetails(objEmpDetails);

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Employee";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    EmployeeID = 0;
                    lblMessage.Text = "Employee Details submitted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    ClearEmployeeDetails();
                    Response.Redirect("EmployeeDetails.aspx");

                }

            }
            catch (Exception ex)
            {
            }
        }
        protected void CheCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (CheCopy.Checked == true)
            {
                txtperAddress.Text = txtAddress.Text;
                txtperArea.Text = txtArea.Text;
                txtperPincode.Text = txtPincode.Text;
                ddlPCountry.SelectedItem.Text = ddlCountry1.SelectedItem.Text;
                ddlPState.SelectedItem.Text = ddlState.SelectedItem.Text;
                ddlPCity.SelectedItem.Text = ddlCity.SelectedItem.Text;
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
                //  btUpdate.Visible = true;
                // btAdd.Visible = false;
                Edit.Visible = false;
                int ID = Convert.ToInt32(e.CommandArgument);

                EmployeeID = ID;

                try
                {

                    DataTable dt = objEmp.GetSelectAllEmployee(ID);

                    txtEmpCode.Text = dt.Rows[0]["EmployeeCode"].ToString();
                    txtRegDate.Text = Convert.ToDateTime(dt.Rows[0]["RegistrationDate"]).ToString("dd-MM-yyyy");
                    txtFname.Text = dt.Rows[0]["FirstName"].ToString();
                    txtLname.Text = dt.Rows[0]["Surname"].ToString();
                    txtMidName.Text = dt.Rows[0]["MiddleName"].ToString();
                    RadGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                 
                    txtBloodGroup.Text = dt.Rows[0]["BloodGroup"].ToString();

                    if (Convert.ToDateTime(dt.Rows[0]["BirthDate"]).ToString("dd-MM-yyyy") == "01-01-1990")
                    {
                        txtBirthDate.Text="";
                    }
                    else
                    {
                    txtBirthDate.Text = Convert.ToDateTime(dt.Rows[0]["BirthDate"]).ToString("dd-MM-yyyy");
                    }
                    lbl_filepath1.Text = dt.Rows[0]["EmployeePhoto"].ToString();
                    dllNationality.Text = dt.Rows[0]["Nationality"].ToString();
                    ImagePhoto1.ImageUrl = "~/Material/EmployeeProfile/" + dt.Rows[0]["EmployeePhoto"].ToString();

                    txtAddress.Text = dt.Rows[0]["CurrentAddress"].ToString();
                    txtArea.Text = dt.Rows[0]["CurrentLandmark"].ToString();
                    txtPincode.Text = dt.Rows[0]["CurrentPinCode"].ToString();
                    if (dt.Rows[0]["CurrentCountry"].ToString() != "0")
                    {
                        ddlCountry1.SelectedValue = dt.Rows[0]["CurrentCountry"].ToString();
                    }
                    if (dt.Rows[0]["CurrentState"].ToString() != "0")
                    {
                        State();
                        ddlState.SelectedValue = dt.Rows[0]["CurrentState"].ToString();
                    }
                    if (dt.Rows[0]["CurrentCity"].ToString() != "0")
                    {
                        City();
                        ddlCity.SelectedValue = dt.Rows[0]["CurrentCity"].ToString();
                    }
                    txtperAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                    txtperArea.Text = dt.Rows[0]["PermanentLandmark"].ToString();
                    txtperPincode.Text = dt.Rows[0]["CurrentPinCode"].ToString();

                    if (dt.Rows[0]["PermanentCountry"].ToString() != "0")
                    {
                        ddlPCountry.SelectedValue = dt.Rows[0]["PermanentCountry"].ToString();
                    }
                    if (dt.Rows[0]["PermanentState"].ToString() != "0")
                    {
                        PermanentState();
                        ddlPState.SelectedValue = dt.Rows[0]["PermanentState"].ToString();
                    }
                    if (dt.Rows[0]["PermanentCity"].ToString() != "0")
                    {
                        PermanentCity();
                        ddlPCity.SelectedValue = dt.Rows[0]["PermanentCity"].ToString();
                    }
                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtPerTelephoneNO.Text = dt.Rows[0]["ResidentPhone"].ToString();

                    txtBankName.Text = dt.Rows[0]["BankName"].ToString();
                    txtBankName.Text = dt.Rows[0]["BranchName"].ToString();
                    txtAccountNo.Text = dt.Rows[0]["AccountNumber"].ToString();
                    txtIFSC_Code.Text = dt.Rows[0]["IFSC_Code"].ToString();
                    txtAccountHolderName.Text = dt.Rows[0]["AccountHolderName"].ToString();
                    txtAadhaarcard.Text = dt.Rows[0]["AadhaarNo"].ToString();
                    txtdrivinglicence.Text = dt.Rows[0]["DrivinglicenceNo"].ToString();
                    txtPassportNo.Text = dt.Rows[0]["PassportNo"].ToString();
                    txtPassword.Text = dt.Rows[0]["UserName"].ToString();
                    txtUsername.Text = dt.Rows[0]["Password"].ToString();
                    if (dt.Rows[0]["RoleID"].ToString() != "0")
                    {
                        ddlDesignation.SelectedValue = dt.Rows[0]["RoleID"].ToString();
                    }
                    txtUsername.Text = dt.Rows[0]["UserName1"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password1"].ToString();
                    Bindddlclinic();
                    ddlclinic.SelectedValue = dt.Rows[0]["ClinicID"].ToString();
                    if(dt.Rows[0]["EmployeePhoto"].ToString() !="")
                    {
                        ImagePhoto1.ImageUrl = "~/EmployeeProfile/" + dt.Rows[0]["EmployeePhoto"].ToString();
                    }
                    else
                    {
                         ImagePhoto1.ImageUrl = " ~/Images/no-photo.jpg";
                   
                }   }
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

                int _isDeleted = objEmp.DeleteEmployee(ID);
                if (_isDeleted != -1)
                {

                    lblMessage.Text = "Enquiry Deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("EmployeeDetails.aspx");
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
            getAllEmployee();
            //try
            //{
            //    string search = "";
            //    //if (txtSearch.Text != "")
            //    //{
            //    if (txtNAme.Text != "")
            //    {
            //        search += "FirstName like '%" + txtNAme.Text + "%'";
            //    }
            //    else
            //    {
            //        search += "Mobile = " + txtMobiles.Text + "";
            //    }

            //    DataRow[] dtSearch1 = AllData.Select(search);
            //    if (dtSearch1.Count() > 0)
            //    {
            //        DataTable dtSearch = dtSearch1.CopyToDataTable();
            //        gvShow.DataSource = dtSearch;
            //        gvShow.DataBind();
            //    }
            //    else
            //    {
            //        DataTable dt = new DataTable();
            //        gvShow.DataSource = dt;
            //        gvShow.DataBind();
            //    }
            //    //}
            //    //else
            //    //{
            //    //    gvShow.DataSource = AllData;
            //    //    gvShow.DataBind();
            //    //}
            //}
            //catch (Exception ex)
            //{
            //}
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
        }

        protected void BtnNextContact_Click(object sender, EventArgs e)
        {
            BtnNextContact.CausesValidation = true;
            TabContactPerson1.Tabs[1].Enabled = true;
            TabContactPerson1.ActiveTabIndex = 1;
        }


        protected void BtnNextMedical_Click(object sender, EventArgs e)
        {
            TabContactPerson1.Tabs[2].Enabled = true;
            TabContactPerson1.ActiveTabIndex = 2;
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image Image1 = (Image)e.Row.FindControl("Image1");
                Label lblProfilePic = (Label)e.Row.FindControl("lblProfilePic");

                if(lblProfilePic.Text=="")
                {
                    Image1.ImageUrl= "../Images/no-photo.jpg";
                }


            }
        }
    }
}