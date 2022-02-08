using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Configuration;
using System.IO;
using System.Net;
using PreconFinal.Utility;
using System.Data.OleDb;

namespace OrthoSquare.Doctor
{
    public partial class Add_Doctor : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BasePage objBasePage = new BasePage();
        BAL_DoctorsDetails objDoc = new BAL_DoctorsDetails();
        BAL_Appointment objApp = new BAL_Appointment();
        BAL_Clinic objclinic = new BAL_Clinic();
        string AdharCarImageUrl = string.Empty;
        string CertificateImageUrl = string.Empty;
        string PanCardImageUrl = string.Empty;
        string profileImageUrl = string.Empty;
        string CrtificetImageUrl = string.Empty;
        string DegreeImageUrl1 = string.Empty;
        string DegreeImageUrl2 = string.Empty;
        string IdentityPolicyImageUrl = string.Empty;
        string lID = "";

        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Form.Attributes.Add("enctype", "multipart/form-data");
            FileUpload1.Attributes["onchange"] = "UploadFile(this)";

            if (!IsPostBack)
            {
                bindClinicSearch();

                if (SessionUtilities.RoleID == 1)
                {
                    ddlClinicSearch.SelectedValue = SessionUtilities.Empid.ToString();
                    // BindDocter(Convert.ToInt32(SessionUtilities.Empid));
                    // BindPatient();
                }
                BindCountry();
                ddlCountry.SelectedValue = "1";
                BindState();
                ddlState.SelectedValue = "2";
                BindCity();
                ddlCity.SelectedValue = "34";
                DoctorSpeciality();
                DoctorDegree();
                DoctorTypeNew();
                getAllDoctor();
                Bindddlclinic();
                BindddlclinicUplodExl();
              
                txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                ddlState.Items.Insert(0, new ListItem("--- Select ---", "0"));
                ddlCity.Items.Insert(0, new ListItem("--- Select ---", "0"));
                TabContactPerson1.Tabs[0].Enabled = true;

                TabContactPerson1.Tabs[1].Enabled = false;
                TabContactPerson1.Tabs[2].Enabled = false;
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
            ddlClinicSearch.DataSource = dt;

            ddlClinicSearch.DataValueField = "ClinicID";
            ddlClinicSearch.DataTextField = "ClinicName";
            ddlClinicSearch.DataBind();
            ddlClinicSearch.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        public void getAllDoctor()
        {

            int Cid1 = 0;
            int Did1 = 0;

            if (SessionUtilities.RoleID == 3)
            {
                Did1 = SessionUtilities.Empid;
                AllData = objDoc.GetAllDoctersNew2(Cid1, Did1, txtNAme.Text.Trim(), txtMobiles.Text.Trim());


            }
            else if (SessionUtilities.RoleID == 1)
            {
                Cid1 = Convert.ToInt32(ddlClinicSearch.SelectedValue);
                AllData = objDoc.GetAllDoctersNew(Cid1, Did1, txtNAme.Text.Trim(), txtMobiles.Text.Trim());

            }
            else
            {
                Cid1 = Convert.ToInt32(ddlClinicSearch.SelectedValue);
                Did1 = 0;
                AllData = objDoc.GetAllDoctersNew2(Cid1, Did1, txtNAme.Text.Trim(), txtMobiles.Text.Trim());


            }



            gvShow.DataSource = AllData;
            gvShow.DataBind();

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
                dt = objclinic.GetAllClinicDetaisNew(SessionUtilities.Empid);
            }
            else
            {
                dt = objclinic.GetAllClinicDetais();

            }
            ddlclinic.DataSource = dt;

            // ddlclinic.DataSource = objcommon.clinicMaster();
            ddlclinic.DataTextField = "ClinicName";
            ddlclinic.DataValueField = "ClinicID";
            ddlclinic.DataBind();



        }


        public void BindddlclinicUplodExl()
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
            ddlUploadClinic.DataSource = dt;

            // ddlclinic.DataSource = objcommon.clinicMaster();
            ddlUploadClinic.DataTextField = "ClinicName";
            ddlUploadClinic.DataValueField = "ClinicID";
            ddlUploadClinic.DataBind();
            ddlUploadClinic.Items.Insert(0, new ListItem("--- Select ---", "0"));


        }

        public void BindddlclinicAS(int DoctorID)
        {

            CheckBoxList1.DataSource = objcommon.clinicMaster();
            CheckBoxList1.DataTextField = "ClinicName";
            CheckBoxList1.DataValueField = "ClinicID";
            CheckBoxList1.DataBind();


            DataTable dt111SP = objDoc.GetDoctersByClinicSelect(DoctorID);


            if (dt111SP != null && dt111SP.Rows.Count > 0)
            {
                for (int j = 0; j < dt111SP.Rows.Count; j++)
                {
                    for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                    {
                        if (CheckBoxList1.Items[i].Value == dt111SP.Rows[j]["ClinicID"].ToString())
                        {
                            CheckBoxList1.Items[i].Selected = true;
                        }
                    }
                }
            }

        }
        private long DoctorID
        {
            get
            {
                if (ViewState["DoctorID"] != null)
                {
                    return (long)ViewState["DoctorID"];
                }
                return 0;
            }
            set
            {
                ViewState["DoctorID"] = value;
            }
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

        public void DoctorSpeciality()
        {
            ddl_SelectSpeciality1.DataSource = objcommon.DoctorSpeciality();
            ddl_SelectSpeciality1.DataValueField = "SpecialityID";
            ddl_SelectSpeciality1.DataTextField = "SpecialityName";
            ddl_SelectSpeciality1.DataBind();
        }

        public void DoctorDegree()
        {



            ddlDegreeQ.DataSource = objcommon.DoctorDegree();
            ddlDegreeQ.DataValueField = "DegreeID";
            ddlDegreeQ.DataTextField = "Name";
            ddlDegreeQ.DataBind();
            ddlDegreeQ.Items.Insert(ddlDegreeQ.Items.Count, new ListItem("Other", "Other"));
            ddlDegreeQ.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        private void DoctorTypeNew()
        {

            ddlDoctorTypeNew.DataSource = objcommon.AllDoctorType(); ;
            ddlDoctorTypeNew.DataValueField = "DocTypeID";
            ddlDoctorTypeNew.DataTextField = "DoctorType";
            ddlDoctorTypeNew.DataBind();
            ddlDoctorTypeNew.Items.Insert(0, new ListItem("-- Select Doctor Type --", "0", true));


            ddlDoctorTypeNew.SelectedItem.Text = "Full-Time Consultant";
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();

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


        protected void cbAll_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;


                string specialities = "";




                for (int i = 0; i < ddl_SelectSpeciality1.Items.Count; i++)
                {

                    if (ddl_SelectSpeciality1.Items[i].Selected)
                    {
                        specialities += ddl_SelectSpeciality1.Items[i].Value + ",";
                    }

                }
                if (specialities != "")
                {
                    specialities = specialities.Remove(specialities.Length - 1);
                }


                string degrees = "";



                string checkpwd = objBasePage.Decryptdata("cGtjNjE1Mg==");

                int DIDS = objDoc.GetDoctorsID() + 1;
                string str = txtFristName.Text.Trim().Replace(" ", "");
                string Password1 = str + "@" + DIDS;
                DoctorDetails objClinicDetails = new DoctorDetails()
                {
                    DoctorID = DoctorID,
                    DoctorTypeID = Convert.ToInt32(ddlDoctorTypeNew.SelectedValue),
                    RegDate = txtDate.Text,
                    FirstName = ddlTitla.SelectedValue + txtFristName.Text,
                    LastName = txtLastName.Text,
                    BirthDate = txtBirthDate.Text,
                    Gender = RADGender.SelectedItem.Text,
                    AddressLine1 = txtAddress1.Text,
                    AddressLine2 = txtAddress2.Text,
                    CountryID = Convert.ToInt32(ddlCountry.SelectedValue),
                    StateID = Convert.ToInt32(ddlState.SelectedValue),
                    CityID = Convert.ToInt32(ddlCity.SelectedValue),
                    AreaPin = txtPinCode.Text,
                    PhoneNo1 = txtMobileNo1.Text,
                    PhoneNo2 = txtMobileNo2.Text,
                    Email = txtEmail.Text,
                    BloodGroup = txtBloodGroup.Text,
                    PanCardNo = txtPanCard.Text,
                    PanCardImageUrl = lblpancard.Text,
                    AdharCardNo = txtAdharNo.Text,
                    AdharCardImageUrl = lblAdharcard.Text,
                    ProfileImageUrl = lbl_filepath1.Text,
                    RegistrationNo = txtRegNo.Text,
                    RegistrationImageUrl = lblCrtificat.Text,
                    IdentityPolicyNo = txtIdentity.Text,
                    IdentityPolicyImageUrl = lblPolicy.Text,
                    DegreeUpload1 = "",
                    DegreeUpload2 = "",
                    UserName = txtMobileNo1.Text,
                    UserPassword = Password1,
                    specialities = specialities,
                    ClinicID = Convert.ToInt32(ddlclinic.SelectedValue),
                    Intime = txtInTime.Text,
                    Outtime = txtOutTime.Text,
                    degrees = degrees,

                    IsActive = true
                };






                _isInserted = objDoc.Add_Doctors(objClinicDetails);
                int Did = objDoc.GetDoctorsID();


                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("DoctorID", typeof(int)));
                dt.Columns.Add(new DataColumn("DegreeName", typeof(string)));
                dt.Columns.Add(new DataColumn("Boardname", typeof(string)));
                dt.Columns.Add(new DataColumn("CertificationImage", typeof(string)));


                for (int i = 0; i <= GridQualification.Rows.Count - 1; i++)
                {
                    GridViewRow gRow = GridQualification.Rows[i];
                    string txt_CertificationName = ((TextBox)gRow.FindControl("txt_CertificationName")).Text;
                    string txt_boardname = ((TextBox)gRow.FindControl("txt_boardname")).Text;

                    string txtFileName = ((TextBox)gRow.FindControl("txtFileName")).Text;

                    if (txt_CertificationName != "" && txt_boardname != "")
                    {
                        dt.Rows.Add(Did, txt_CertificationName, txt_boardname, txtFileName);
                    }
                }



                bool Result1 = objDoc.InsertUpdateAddDoctor_Degree(dt);

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Doctor";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    // clinicID = 0;


                    int Did1 = objDoc.GetDoctorsID();

                    int IDq = objApp.Add_AppointmentDetails(Did1);

                    lblMessage.Text = "Doctor Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    SendMail(txtEmail.Text, txtMobileNo1.Text, Password1);
                    Clear();
                    txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                }

            }
            catch (Exception ex)
            {
            }
        }


        protected void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;


                string specialities = "";
                //foreach (ListItem item in ddl_SelectSpeciality1.Items)
                //{
                //    if (item.Selected)
                //    {
                //        specialities += item.Value + ",";
                //    }

                //}




                for (int i = 0; i < ddl_SelectSpeciality1.Items.Count; i++)
                {

                    if (ddl_SelectSpeciality1.Items[i].Selected)
                    {
                        specialities += ddl_SelectSpeciality1.Items[i].Value + ",";
                    }

                }
                if (specialities != "")
                {
                    specialities = specialities.Remove(specialities.Length - 1);
                }


                string degrees = "";





                //  string Password = objBasePage.Encryptdata(txtPassword.Text.Trim());

                string checkpwd = objBasePage.Decryptdata("cGtjNjE1Mg==");

                int DIDS = objDoc.GetDoctorsID() + 1;
                string Password1 = txtFristName.Text + "@" + DIDS;
                DoctorDetails objClinicDetails = new DoctorDetails()
                {
                    DoctorID = DoctorID,
                    DoctorTypeID = Convert.ToInt32(ddlDoctorTypeNew.SelectedValue),
                    RegDate = txtDate.Text,
                    FirstName = ddlTitla.SelectedValue + txtFristName.Text,
                    LastName = txtLastName.Text,
                    BirthDate = txtBirthDate.Text,
                    Gender = RADGender.SelectedItem.Text,
                    AddressLine1 = txtAddress1.Text,
                    AddressLine2 = txtAddress2.Text,
                    CountryID = Convert.ToInt32(ddlCountry.SelectedValue),
                    StateID = Convert.ToInt32(ddlState.SelectedValue),
                    CityID = Convert.ToInt32(ddlCity.SelectedValue),
                    AreaPin = txtPinCode.Text,
                    PhoneNo1 = txtMobileNo1.Text,
                    PhoneNo2 = txtMobileNo2.Text,
                    Email = txtEmail.Text,
                    BloodGroup = txtBloodGroup.Text,
                    PanCardNo = txtPanCard.Text,
                    PanCardImageUrl = lblpancard.Text,
                    AdharCardNo = txtAdharNo.Text,
                    AdharCardImageUrl = lblAdharcard.Text,
                    ProfileImageUrl = lbl_filepath1.Text,
                    RegistrationNo = txtRegNo.Text,
                    RegistrationImageUrl = lblCrtificat.Text,
                    IdentityPolicyNo = txtIdentity.Text,
                    IdentityPolicyImageUrl = lblPolicy.Text,
                    DegreeUpload1 = "",
                    DegreeUpload2 = "",
                    UserName = txtMobileNo1.Text,
                    UserPassword = Password1,
                    specialities = specialities,
                    ClinicID = Convert.ToInt32(ddlclinic.SelectedValue),
                    Intime = txtInTime.Text,
                    Outtime = txtOutTime.Text,
                    degrees = degrees,
                    IsActive = true
                };



                _isInserted = objDoc.Add_Doctors(objClinicDetails);


                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("DoctorID", typeof(int)));
                dt.Columns.Add(new DataColumn("DegreeName", typeof(string)));
                dt.Columns.Add(new DataColumn("Boardname", typeof(string)));
                dt.Columns.Add(new DataColumn("CertificationImage", typeof(string)));


                for (int i = 0; i <= GridQualification.Rows.Count - 1; i++)
                {
                    GridViewRow gRow = GridQualification.Rows[i];
                    string txt_CertificationName = ((TextBox)gRow.FindControl("txt_CertificationName")).Text;
                    string txt_boardname = ((TextBox)gRow.FindControl("txt_boardname")).Text;

                    string txtFileName = ((TextBox)gRow.FindControl("txtFileName")).Text;

                    if (txt_CertificationName != "" && txt_boardname != "")
                    {
                        dt.Rows.Add(DoctorID, txt_CertificationName, txt_boardname, txtFileName);
                    }
                }


                bool Result = objDoc.DeleteDoctorByDegree(Convert.ToInt32(DoctorID));

                bool Result1 = objDoc.InsertUpdateAddDoctor_Degree(dt);

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Update Doctor";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    // clinicID = 0;


                    //  int Did = objDoc.GetDoctorsID();
                    // int DCid = objDoc.Add_DoctorsDoctorebyClinic(Convert.ToInt32(ddlclinic.SelectedItem), Convert.ToInt32(Did));
                    // int IDq = objApp.Add_AppointmentDetails(Did);


                    // SendMail(txtEmail.Text, txtMobileNo1.Text, Password1);

                    Clear();
                    lblMessage.Text = "Doctor Update Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }

            }
            catch (Exception ex)
            {
            }


        }

        public void Clear()
        {
            CleartextBoxes(this);
            // BindCountry();

            BindCountry();
            DoctorSpeciality();
            DoctorDegree();
            DoctorTypeNew();
            getAllDoctor();
            Bindddlclinic();

            ImagePhoto1.ImageUrl = "~/Images/no-photo.jpg";
            ImageAdharcard.ImageUrl = "~/Images/no-photo.jpg";
            Imagepancard.ImageUrl = "~/Images/no-photo.jpg";
            ImageCrtificat.ImageUrl = "~/Images/no-photo.jpg";

            ImagePolicy.ImageUrl = "~/Images/no-photo.jpg";
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


        protected void btnUploadimage_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        protected void btnUploadAdharcard_Click(object sender, EventArgs e)
        {
            UploadImageAdharcard();
        }

        protected void btnUplPancard_Click(object sender, EventArgs e)
        {
            UploadImagePancard();
        }

        protected void btnUplCrtificat_Click(object sender, EventArgs e)
        {
            UploadImageCrtificet();
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
            string DD = txtFristName.Text;
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
                            int Dno = objcommon.GetDoctorMax_No();

                            string Imgname = "Profilepic" + Dno + txtFristName.Text;


                            // string Imgname = txtFristName.Text;

                            string path = Server.MapPath(@"~\EmployeeProfile\");
                            System.IO.Directory.CreateDirectory(path);
                            FuImage1.SaveAs(path + @"\" + "Profilepic" + Dno + txtFristName.Text + ext);

                            ImagePhoto1.ImageUrl = @"~\EmployeeProfile\" + "Profilepic" + Dno + txtFristName.Text + ext;
                            ImagePhoto1.Visible = true;

                            lbl_filepath1.Text = Imgname + ext;

                            profileImageUrl = Imgname + ext;

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


        public void UploadImageAdharcard()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FileAdharCard.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileAdharCard.Focus();
            }
            string DD = txtFristName.Text;
            string aa = FileAdharCard.FileName;
            string ext = System.IO.Path.GetExtension(FileAdharCard.PostedFile.FileName).ToLower();
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

                if (FileAdharCard.HasFile)
                {

                    filename = Server.MapPath(FileAdharCard.FileName);
                    newfile = FileAdharCard.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\Documents"))
                    {
                        try
                        {

                            int Dno = objcommon.GetDoctorMax_No();

                            string Imgname = "adhrcard" + Dno + txtAdharNo.Text;

                            string path = Server.MapPath(@"~\Documents\");
                            System.IO.Directory.CreateDirectory(path);
                            FileAdharCard.SaveAs(path + @"\" + "adhrcard" + Dno + txtAdharNo.Text + ext);

                            ImageAdharcard.ImageUrl = @"~\Documents\" + "adhrcard" + Dno + txtAdharNo.Text + ext;
                            ImageAdharcard.Visible = true;

                            lblAdharcard.Text = Imgname + ext;

                            AdharCarImageUrl = Imgname + ext;

                        }
                        catch (Exception ex)
                        {
                            lblAdharcard.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }


        public void UploadImagePancard()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FilePancard.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FilePancard.Focus();
            }
            string DD = txtFristName.Text;
            string aa = FilePancard.FileName;
            string ext = System.IO.Path.GetExtension(FilePancard.PostedFile.FileName).ToLower();
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

                if (FilePancard.HasFile)
                {

                    filename = Server.MapPath(FilePancard.FileName);
                    newfile = FilePancard.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\Documents"))
                    {
                        try
                        {

                            int Dno1 = objcommon.GetDoctorMax_No();

                            string Imgname = "pancardcard" + Dno1 + txtPanCard.Text;

                            string path = Server.MapPath(@"~\Documents\");
                            System.IO.Directory.CreateDirectory(path);
                            FilePancard.SaveAs(path + @"\" + "pancardcard" + Dno1 + txtPanCard.Text + ext);

                            Imagepancard.ImageUrl = @"~\Documents\" + "pancardcard" + Dno1 + txtPanCard.Text + ext;
                            Imagepancard.Visible = true;

                            lblpancard.Text = Imgname + ext;

                            PanCardImageUrl = Imgname + ext;

                        }
                        catch (Exception ex)
                        {
                            lblAdharcard.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }



        public void UploadImageCrtificet()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FileCrtificat.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileCrtificat.Focus();
            }
            string DD = txtFristName.Text;
            string aa = FileCrtificat.FileName;
            string ext = System.IO.Path.GetExtension(FileCrtificat.PostedFile.FileName).ToLower();
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

                if (FileCrtificat.HasFile)
                {

                    filename = Server.MapPath(FileCrtificat.FileName);
                    newfile = FileCrtificat.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\Documents"))
                    {
                        try
                        {

                            int Dno1 = objcommon.GetDoctorMax_No();

                            string Imgname = "Crtificat" + Dno1 + txtRegNo.Text;

                            string path = Server.MapPath(@"~\Documents\");
                            System.IO.Directory.CreateDirectory(path);
                            FileCrtificat.SaveAs(path + @"\" + "Crtificat" + Dno1 + txtRegNo.Text + ext);

                            ImageCrtificat.ImageUrl = @"~\Documents\" + "Crtificat" + Dno1 + txtRegNo.Text + ext;
                            ImageCrtificat.Visible = true;

                            lblCrtificat.Text = Imgname + ext;

                            PanCardImageUrl = Imgname + ext;

                        }
                        catch (Exception ex)
                        {
                            lblCrtificat.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            // btSearch_Click(sender, e);
            getAllDoctor();
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (e.CommandName == "EditDocterDetails")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                DoctorID = id;
                string beforeFounder = "";
                DataTable dt1 = objDoc.GetDoctersInouttime(DoctorID);




                DoctorTypeNew();

                if (dt1.Rows[0]["DoctorTypeID"].ToString() != "")
                {
                    ddlDoctorTypeNew.SelectedValue = dt1.Rows[0]["DoctorTypeID"].ToString();
                }
                // txtFristName.Text = dt1.Rows[0]["FirstName"].ToString().Replace(".", " ");
                txtFristName.Text = dt1.Rows[0]["FirstName"].ToString();

                int pos = txtFristName.Text.IndexOf(".") + 1;
                if (pos >= 0)
                {
                    // String after founder  
                    string afterFounder = txtFristName.Text.Remove(pos);
                    Console.WriteLine(afterFounder);
                    // Remove everything before founder but include founder  
                    beforeFounder = txtFristName.Text.Remove(0, pos);
                    Console.Write(beforeFounder);
                }

                txtFristName.Text = beforeFounder;
                txtLastName.Text = dt1.Rows[0]["LastName"].ToString();
                if (dt1.Rows[0]["DOB"].ToString() != "")
                {
                    txtBirthDate.Text = Convert.ToDateTime(dt1.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                }
                //   RADGender .SelectedItem.Text=dt1.Rows[0]["Gender"].ToString() ; 
                txtAddress1.Text = dt1.Rows[0]["Line1"].ToString();
                txtAddress2.Text = dt1.Rows[0]["Line2"].ToString();
                BindCountry();
                if (dt1.Rows[0]["CountryID"].ToString() != "")
                {
                    ddlCountry.SelectedValue = dt1.Rows[0]["CountryID"].ToString();
                }
                BindState();

                if (dt1.Rows[0]["StateID"].ToString() != "")
                {
                    ddlState.SelectedValue = dt1.Rows[0]["StateID"].ToString();
                }


                BindCity();
                if (dt1.Rows[0]["CityID"].ToString() != "")
                {
                    ddlCity.SelectedValue = dt1.Rows[0]["CityID"].ToString();
                }

                if (dt1.Rows[0]["Gender"].ToString() != "")
                {
                    RADGender.Items.FindByText(dt1.Rows[0]["Gender"].ToString()).Selected = true;
                }
                txtPinCode.Text = dt1.Rows[0]["AreaPin"].ToString();
                txtMobileNo1.Text = dt1.Rows[0]["Mobile1"].ToString();
                txtMobileNo2.Text = dt1.Rows[0]["Mobile2"].ToString();
                txtEmail.Text = dt1.Rows[0]["Email"].ToString();
                txtBloodGroup.Text = dt1.Rows[0]["BloodGroup"].ToString();
                //txtPanCard.Text ,
                //PanCardImageUrl=PanCardImageUrl,
                //AdharCardNo =txtAdharNo .Text ,
                //AdharCardImageUrl =AdharCarImageUrl ,
                //ProfileImageUrl =profileImageUrl, 
                // txtUserName.Text=dt1.Rows[0]["UserName1"].ToString();
                // txtPassword .Text=dt1.Rows[0]["Password1"].ToString() ;
                txtInTime.Text = dt1.Rows[0]["InTime"].ToString();
                txtOutTime.Text = dt1.Rows[0]["OutTime"].ToString();
                Bindddlclinic();

                if (dt1.Rows[0]["ClinicID"].ToString() != "")
                {
                    ddlclinic.SelectedValue = dt1.Rows[0]["ClinicID"].ToString();

                }
                ImagePhoto1.ImageUrl = "~/EmployeeProfile/" + dt1.Rows[0]["ProfileImageUrl"].ToString();
                ImageAdharcard.ImageUrl = "~/Documents/" + dt1.Rows[0]["AdharCardImageUrl"].ToString();
                Imagepancard.ImageUrl = "~/Documents/" + dt1.Rows[0]["PanCardImageUrl"].ToString();
                ImageCrtificat.ImageUrl = "~/Documents/" + dt1.Rows[0]["RegistrationImageUrl"].ToString();

                ImagePolicy.ImageUrl = "~/Documents/" + dt1.Rows[0]["IdentityPolicyImageUrl"].ToString();

                txtAdharNo.Text = dt1.Rows[0]["AdharCardNo"].ToString();
                txtPanCard.Text = dt1.Rows[0]["PanCardNo"].ToString();
                txtRegNo.Text = dt1.Rows[0]["RegistrationNo"].ToString();
                txtIdentity.Text = dt1.Rows[0]["IdentityPolicyNo"].ToString();


                DataTable dt111 = objDoc.GetDocterstbl_Doctor_Degree(DoctorID);


                if (dt111 != null && dt111.Rows.Count > 0)
                {

                    ViewState["QualificationCurrentTable"] = dt111;
                    AddQualification();
                    GridQualification.DataSource = dt111;
                    GridQualification.DataBind();

                    AddQualification();

                }




                DataTable dt111SP = objDoc.GetDocterstbl_DrSpeciality(DoctorID);


                if (dt111SP != null && dt111SP.Rows.Count > 0)
                {
                    for (int j = 0; j < dt111SP.Rows.Count; j++)
                    {
                        for (int i = 0; i < ddl_SelectSpeciality1.Items.Count; i++)
                        {
                            if (ddl_SelectSpeciality1.Items[i].Text == dt111SP.Rows[j]["SpecialityName"].ToString())
                            {
                                ddl_SelectSpeciality1.Items[i].Selected = true;
                            }
                        }
                    }
                }

                Div2.Visible = false;
                Add.Visible = true;
                btAdd.Visible = false;
                Edit.Visible = false;
                btUpdate.Visible = true;
            }
            if (e.CommandName == "EditInouttime")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                DoctorID = id;

                DataTable dt = objDoc.GetDoctersInouttime(DoctorID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtIntimeUpdate.Text = dt.Rows[0]["InTime"].ToString();
                    txtouttimeUpdate.Text = dt.Rows[0]["OutTime"].ToString();
                    Div2.Visible = true;
                    Add.Visible = false;
                    Edit.Visible = false;
                }
                // btUpdate.Visible = false;
            }

            if (e.CommandName == "viewDocterDetails")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                DoctorID = id;

                Response.Redirect("ViewDoctor.aspx?DoctorID=" + DoctorID);
            }
            if (e.CommandName == "DoctorsbyClinic")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                DoctorID = id;
                BindddlclinicAS(Convert.ToInt32(DoctorID));
                Div2.Visible = false;
                Add.Visible = false;
                Edit.Visible = false;
                //  btUpdate.Visible = false;
                Div11.Visible = false;
                Div111.Visible = true;
            }

        }

        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);



            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objDoc.DeleteDoctors(ID);
                if (_isDeleted != -1)
                {

                    lblMessage.Text = "Doctor Deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("Add_Doctor.aspx");
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

                getAllDoctor();
                //string search = "";
                ////if (txtSearch.Text != "")
                ////{
                //if (txtNAme.Text != "")
                //{
                //    search += "FirstName like '%" + txtNAme.Text + "%'";
                //}
                //else
                //{
                //    search += "Mobile1 = " + txtMobiles.Text + "";
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
        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;
            Div2.Visible = false;
            Div11.Visible = false;
            // btUpdate.Visible = false;
            getAllDoctor();
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
            Div2.Visible = false;
            Div11.Visible = false;
            // btUpdate.Visible = false;
        }



        protected void BtnNextContact_Click(object sender, EventArgs e)
        {

            if (DoctorID == 0)
            {
                int Isv = objDoc.GetDoctorsIsvelid(txtMobileNo1.Text);

                if (Isv > 0)
                {

                    lblMessage.Text = "Doctor already exists";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {


                    TabContactPerson1.Tabs[1].Enabled = true;
                    TabContactPerson1.ActiveTabIndex = 1;
                }
            }
            else
            {
                TabContactPerson1.Tabs[1].Enabled = true;
                TabContactPerson1.ActiveTabIndex = 1;

            }
        }
        protected void BtnNextMedical_Click(object sender, EventArgs e)
        {
            TabContactPerson1.Tabs[2].Enabled = true;
            TabContactPerson1.ActiveTabIndex = 2;
        }

        protected void btnUpdateIOtime_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;

                _isInserted = objDoc.Add_DoctorsUpdate(DoctorID, txtIntimeUpdate.Text, txtouttimeUpdate.Text);

                if (_isInserted == -1)
                {
                    lblmsg1.Text = "Failed to Add Doctor";
                    lblmsg1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    // clinicID = 0;
                    lblmsg1.Text = "Doctor Added Successfully";
                    lblmsg1.ForeColor = System.Drawing.Color.Green;
                    // Clear();


                }
            }
            catch (Exception ex)
            {
            }



        }

        protected void btnIOCancel_Click(object sender, EventArgs e)
        {
            Div2.Visible = false;
            Add.Visible = false;
            Edit.Visible = true;
            btUpdate.Visible = false;
        }



        protected void btnUplPolicy_Click(object sender, EventArgs e)
        {
            UploadImageIdentityPolicy();
        }

        public void UploadImageIdentityPolicy()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FileUploadPolicy.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileUploadPolicy.Focus();
            }
            string DD = txtFristName.Text;
            string aa = FileUploadPolicy.FileName;
            string ext = System.IO.Path.GetExtension(FileUploadPolicy.PostedFile.FileName).ToLower();
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

                if (FileUploadPolicy.HasFile)
                {

                    filename = Server.MapPath(FileUploadPolicy.FileName);
                    newfile = FileUploadPolicy.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\Documents"))
                    {
                        try
                        {

                            int Dno1 = objcommon.GetDoctorMax_No();

                            string Imgname = "PolicyNo" + Dno1 + txtIdentity.Text;

                            string path = Server.MapPath(@"~\Documents\");
                            System.IO.Directory.CreateDirectory(path);
                            FileUploadPolicy.SaveAs(path + @"\" + "PolicyNo" + Dno1 + txtIdentity.Text + ext);

                            ImagePolicy.ImageUrl = @"~\Documents\" + "PolicyNo" + Dno1 + txtIdentity.Text + ext;
                            ImagePolicy.Visible = true;

                            lblPolicy.Text = Imgname + ext;

                            IdentityPolicyImageUrl = Imgname + ext;


                        }
                        catch (Exception ex)
                        {
                            lblPolicy.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }



        #region " ***** Questions ***** "
        protected void btnOptionalUpload_Click(object sender, EventArgs e)
        {


            bool Result = false;
            string ResultMsg = "";


            UploadAllQuestions(flOptional, ref Result, ref ResultMsg);



        }

        protected void btbtnExlCancel_Click(object sender, EventArgs e)
        {

            Edit.Visible = true;
            Add.Visible = false;
            Div2.Visible = false;
            Div11.Visible = false;
            // btUpdate.Visible = false;
        }
        protected void btnAddexcelupload_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = false;
            Div2.Visible = false;
            // btUpdate.Visible = false;
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


                    lblMSG11.Text = "Doctor Information have been uploaded sucessfully.";
                    //  lblMSG1.Text = strresult;
                    //Result = false;

                }
                catch (Exception ex)
                {
                    Result = false;
                    ErrorName = "Doctor Information Not Saved";
                }
            }
            else
            {
                Result = false;
                ErrorName = "Invalid File. Please Select proper file.";
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
                    //   reccount = 1;
                    int SourceID = 0, TreatmentID = 0, ClinicID = 0, DoctorID = 0;
                    //int FieldID = 0, Groupid = 0;

                    string UserName = "", Password = "";

                    if (!string.IsNullOrEmpty(Common.CheckNullandEmpty(item["FirstName"]))
                        && !string.IsNullOrEmpty(Common.CheckNullandEmpty(item["LastName"])) && !string.IsNullOrEmpty(Common.CheckNullandEmpty(item["Email"]))
                        )
                    {

                        int Isv = objDoc.GetDoctorsIsvelid(item["Mobile"].ToString().Trim());

                        if (Isv > 0)
                        {

                        }
                        else
                        {

                            int Did = objDoc.SaveExcelUploadedDotor(Convert.ToInt32(ddlUploadClinic.SelectedValue), Convert.ToDateTime(System.DateTime.Now).ToString("dd-MM-yyyy"), item["FirstName"].ToString().Trim(), item["LastName"].ToString().Trim(), item["Email"].ToString().Trim(), item["Mobile"].ToString().Trim(), item["InTime"].ToString().Trim(), item["OutTime"].ToString().Trim());

                            //int Did = objDoc.GetDoctorsID();

                            int IDq = objApp.Add_AppointmentDetails(Did);

                            UserName = item["Mobile"].ToString().Trim();
                            Password = item["FirstName"].ToString().Trim() + "@" + Did;
                            int DidL = objDoc.SaveExcelUploadedLoginDotor(UserName, Password, Did);

                            SendMail(item["Email"].ToString().Trim(), UserName, Password);
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
            DownloadFile("Doctor_Master.xlsx", "Doctor_Master.xlsx");
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


        protected void SendMail(string Email, string Username, string Password)
        {
            string EmailFromAddress = ConfigurationManager.AppSettings["EmailFromAddress"].ToString();
            string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"].ToString();
            var fromAddress = EmailFromAddress;
            var toAddress = Email + ",drshraddhakambale@gmail.com";
            string fromPassword = EmailPassword.ToString();
            string subject = "Ortho Square";
            string body = "Dear ," + "\n";
            body += "Your UserName and Password For OrthoSquare :" + "\n";
            body += "UserName : " + Username + " " + "\n\n";
            body += "Password : " + Password + " " + "\n\n";
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
           
            smtp.Send(fromAddress, toAddress, subject, body);
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
        //        //smtp.Port = 465;
        //        smtp.EnableSsl = true;

        //        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
        //        smtp.Timeout = 50000;
        //    }
        //    // Passing values to smtp object
        //    smtp.Send(fromAddress, toAddress, subject, body);
        //}


        #endregion



        protected void BtnDycCancel_Click(object sender, EventArgs e)
        {

            Edit.Visible = true;
            Add.Visible = false;
            Div2.Visible = false;
            Div11.Visible = false;
            //  btUpdate.Visible = false;
            Div111.Visible = false;
        }

        protected void btnDbyCSubmit_Click(object sender, EventArgs e)
        {


            try
            {
             
                int  D_id=  objDoc.Add_DoctorsDoctorebyClinicDelete(Convert.ToInt32(DoctorID));

                int _isInserted = -1;

                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        lID = CheckBoxList1.Items[i].Value;

                        _isInserted = objDoc.Add_DoctorsDoctorebyClinic(Convert.ToInt32(lID), Convert.ToInt32(DoctorID));

                    }
                }


                if (_isInserted == -1)
                {
                    lblmsg1223.Text = "Failed to Add Doctor";
                    lblmsg1223.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblmsg1223.Text = "Doctor Added Successfully";
                    lblmsg1223.ForeColor = System.Drawing.Color.Green;

                    TextBox1.Text = "";
                    BindddlclinicAS(Convert.ToInt32(DoctorID));
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAddDegree_Click(object sender, EventArgs e)
        {
            int _isInserted = -1;

            _isInserted = objDoc.Add_DoctorDegree(txtAddDegree.Text);

            DoctorDegree();
            txtAddDegree.Text = "";
        }


        protected void btnDegreeCancel_Click(object sender, EventArgs e)
        {
            AddDegree.Visible = false;
            DoctorDegree();
            txtAddDegree.Text = "";
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ImageButton lbtDelete = (ImageButton)e.Row.FindControl("lbtDelete");
                ImageButton btnUpdate1 = (ImageButton)e.Row.FindControl("btnUpdate1");
                ImageButton ImageButton1 = (ImageButton)e.Row.FindControl("ImageButton1");
                ImageButton btnUpdate = (ImageButton)e.Row.FindControl("btnUpdate");



                if (SessionUtilities.RoleID == 3)
                {
                    lbtDelete.Visible = false;
                    btnUpdate1.Visible = false;
                    ImageButton1.Visible = true;

                    btnAddNew.Visible = false;
                    Button11.Visible = false;
                }
                else if (SessionUtilities.RoleID == 1)
                {
                    lbtDelete.Visible = false;
                    btnUpdate1.Visible = false;
                    ImageButton1.Visible = true;
                    btnUpdate.Visible = true;

                }
            }



        }
        //Qualification
        protected void GridQualification_DataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txt_CertificationName = (TextBox)e.Row.FindControl("txt_CertificationName");
                TextBox txt_boardname = (TextBox)e.Row.FindControl("txt_boardname");

                if (txt_CertificationName.Text == "" && txt_boardname.Text == "")
                {
                    //  e.Row.Visible = false;
                    e.Row.Attributes["style"] = "display:none";
                }


            }
        }

        protected void GridQualification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "GrdCQDelete")
                {
                    DataTable dt = (DataTable)ViewState["QualificationCurrentTable"];
                    string index = e.CommandArgument.ToString();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        if (dt.Rows[i]["DegreeName"].ToString() == index)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                    ViewState["QualificationCurrentTable"] = dt;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        GridQualification.DataSource = dt;
                        GridQualification.DataBind();

                        SetQualificationData();
                    }
                    else
                    {
                        // InstallmentTable();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void Upload12111(object sender, EventArgs e)
        {
            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif", "pdf" };

            if (!FileUpload1.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileUpload1.Focus();
            }
            //string DD = txtFristName.Text;
            string aa = FileUpload1.FileName;
            string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
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

                if (FileUpload1.HasFile)
                {

                    filename = Server.MapPath(FileUpload1.FileName);
                    newfile = FileUpload1.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\QualificationDoc"))
                    {
                        try
                        {


                            string Imgname = txtFristName.Text.Trim() + "_" + ddlDegreeQ.SelectedItem.Text;

                            string path = Server.MapPath(@"~\QualificationDoc\");
                            System.IO.Directory.CreateDirectory(path);
                            FileUpload1.SaveAs(path + @"\" + txtFristName.Text.Trim() + "_" + ddlDegreeQ.SelectedItem.Text + ext);

                            CertificationImage.ImageUrl = @"~\QualificationDoc\" + txtFristName.Text.Trim() + "_" + ddlDegreeQ.SelectedItem.Text + ext;
                            CertificationImage.Visible = true;

                            lblImageName.Text = Imgname + ext;

                            //  IdentityPolicyImageUrl = Imgname + ext;


                        }
                        catch (Exception ex)
                        {
                            lblImageName.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }

            //=========


        }


        public void AddQualification()
        {
            try
            {
                int index = 0;
                if (ViewState["QualificationCurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["QualificationCurrentTable"];
                    DataRow drCurrentRow = null;
                    decimal Installment_AMT = 0;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            GridViewRow gRow = GridQualification.Rows[index];
                            string Certification_Name = ((TextBox)GridQualification.Rows[index].Cells[1].FindControl("txt_CertificationName")).Text;
                            string boardname1 = ((TextBox)GridQualification.Rows[index].Cells[2].FindControl("txt_boardname")).Text;

                            TextBox box3 = (TextBox)GridQualification.Rows[index].Cells[3].FindControl("txtFileName");


                            drCurrentRow = dtCurrentTable.NewRow();
                            dtCurrentTable.Rows[i - 1]["DegreeName"] = "";
                            if (!string.IsNullOrEmpty(Certification_Name))
                            {

                                dtCurrentTable.Rows[i - 1]["DegreeName"] = Certification_Name;

                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(ddlDegreeQ.SelectedItem.Text))
                                {
                                    dtCurrentTable.Rows[i - 1]["DegreeName"] = ddlDegreeQ.SelectedItem.Text;
                                }
                                else
                                {
                                    if (ddlDegreeQ.SelectedItem.Text == "--- Select ---")
                                    {
                                        dtCurrentTable.Rows[i - 1]["DegreeName"] = "Na";
                                    }

                                }
                            }

                            dtCurrentTable.Rows[i - 1]["Boardname"] = "";
                            if (!string.IsNullOrEmpty(boardname1))
                            {
                                dtCurrentTable.Rows[i - 1]["Boardname"] = boardname1;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(txtBoardName.Text))
                                {
                                    dtCurrentTable.Rows[i - 1]["Boardname"] = txtBoardName.Text;
                                }
                                else
                                {

                                    dtCurrentTable.Rows[i - 1]["Boardname"] = "Na";
                                }
                            }



                            dtCurrentTable.Rows[i - 1]["CertificationImage"] = "";
                            if (!string.IsNullOrEmpty(box3.Text))
                            {
                                dtCurrentTable.Rows[i - 1]["CertificationImage"] = box3.Text;
                            }

                            else
                            {
                                if (!string.IsNullOrEmpty(lblImageName.Text))
                                {
                                    dtCurrentTable.Rows[i - 1]["CertificationImage"] = lblImageName.Text;
                                }
                                else
                                {
                                    dtCurrentTable.Rows[i - 1]["CertificationImage"] = "no-photo.jpg";

                                }
                            }
                            index++;
                        }
                        dtCurrentTable.Rows.Add(drCurrentRow);

                        ViewState["QualificationCurrentTable"] = dtCurrentTable;
                        GridQualification.DataSource = dtCurrentTable;
                        GridQualification.DataBind();
                        DoctorDegree();
                        txtBoardName.Text = "";
                        lblImageName.Text = "";
                        CertificationImage.ImageUrl = "~/img/no-photo.jpg";

                    }
                    else
                    {
                        QualificationTable();
                    }
                }
                SetQualificationData();
            }
            catch (Exception e)
            {
            }
        }

        protected void QualificationTable()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.AddRange(new DataColumn[3] {
                new DataColumn("DegreeName",typeof(string)),
                new DataColumn("Boardname",typeof(string)),

                new DataColumn("CertificationImage",typeof(string)),


                });

                dr = dt.NewRow();


                dr["DegreeName"] = ddlDegreeQ.SelectedItem.Text;
                dr["Boardname"] = txtBoardName.Text;
                dr["CertificationImage"] = lblImageName.Text;


                //dr["Status"] = "false";
                dt.Rows.Add(dr);

                ViewState["QualificationCurrentTable"] = dt;
                GridQualification.DataSource = dt;
                GridQualification.DataBind();

                DoctorDegree();
                txtBoardName.Text = "";
                lblImageName.Text = "";
                CertificationImage.ImageUrl = "~/img/no-photo.jpg";

            }
            catch (Exception e)
            {
            }
        }

        public void SetQualificationData()
        {
            try
            {
                int Index = 0;

                if (ViewState["QualificationCurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["QualificationCurrentTable"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            TextBox txt_CertificationName = (TextBox)GridQualification.Rows[Index].Cells[1].FindControl("txt_CertificationName");
                            TextBox txt_boardname = (TextBox)GridQualification.Rows[Index].Cells[2].FindControl("txt_boardname");

                            TextBox box3 = (TextBox)GridQualification.Rows[Index].Cells[3].FindControl("txtFileName");

                            Image ImageFileName = (Image)GridQualification.Rows[Index].Cells[3].FindControl("ImageFileName");




                            if (dt.Rows[i]["DegreeName"].ToString() != "")
                            {
                                txt_CertificationName.Text = dt.Rows[i]["DegreeName"].ToString();
                            }
                            else
                            {
                                txt_CertificationName.Text = "";
                            }
                            if (dt.Rows[i]["Boardname"].ToString() != "")
                            {
                                txt_boardname.Text = dt.Rows[i]["Boardname"].ToString();
                            }
                            else
                            {
                                txt_boardname.Text = "";

                            }
                            box3.Text = dt.Rows[i]["CertificationImage"].ToString();

                            if (dt.Rows[i]["CertificationImage"].ToString() != "")
                            {
                                ImageFileName.ImageUrl = "../QualificationDoc/" + dt.Rows[i]["CertificationImage"].ToString();
                            }
                            else
                            {

                                CertificationImage.ImageUrl = "~/img/no-photo.jpg";
                            }
                            Index++;
                        }

                    }
                    else
                    {
                        QualificationTable();
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        protected void btnAddDetails_Click(object sender, EventArgs e)
        {
            if (GridQualification.Rows.Count == 0)
            {
                QualificationTable();

                AddQualification();
            }
            else
            {

                AddQualification();
            }
        }

        protected void ddlDegreeQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDegreeQ.SelectedItem.Text == "Other")
            {

                AddDegree.Visible = true;

            }
            else
            {

                AddDegree.Visible = false;

            }
        }
    }
}