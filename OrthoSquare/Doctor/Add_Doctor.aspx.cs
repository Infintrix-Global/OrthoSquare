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
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
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
                BindddlclinicAS();
                txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                ddlState.Items.Insert(0, new ListItem("--- Select ---", "0"));
                ddlCity.Items.Insert(0, new ListItem("--- Select ---", "0"));
                TabContactPerson1.Tabs[0].Enabled = true;

                TabContactPerson1.Tabs[1].Enabled = false;
                TabContactPerson1.Tabs[2].Enabled = false;
            }
        }
        public void getAllDoctor()
        {

            int Cid1 = 0;


            if(SessionUtilities .RoleID == 2)
            {

                Cid1 = 0;
            }
            else
            {
                Cid1 = SessionUtilities.Empid;

            }





            AllData = objDoc.GetAllDocters(Cid1);
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        public void Bindddlclinic()
        {
            ddlclinic.DataSource = objcommon.clinicMaster();
            ddlclinic.DataTextField = "ClinicName";
            ddlclinic.DataValueField = "ClinicID";
            ddlclinic.DataBind();

         //   ddlclinic.Items.Insert(0, new ListItem("--- Select ---", "0"));


         //   lst.Items.Clear();
         //   lst.Items.Add(new ListItem("-- Select --", "-1"));

         //   lst.SelectedIndex = 0;

         //  // DataSet ds = new DataSet();
         ////  ds.Tables.Add(objcommon.clinicMaster()); // Get Your Detail Here from Database 

         //   lst.DataSource = objcommon.clinicMaster();
         //   lst.DataBind();

        }





        public void BindddlclinicAS()
        {
            CheckBoxList1.DataSource = objcommon.clinicMaster();
            CheckBoxList1.DataTextField = "ClinicName";
            CheckBoxList1.DataValueField = "ClinicID";
            CheckBoxList1.DataBind();

          

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
            ddl_Degree1.DataSource = objcommon.DoctorDegree();
            ddl_Degree1.DataValueField = "DegreeID";
            ddl_Degree1.DataTextField = "Name";
            ddl_Degree1.DataBind();
        }
        private void DoctorTypeNew()
        {
           
                    ddlDoctorTypeNew.DataSource = objcommon.AllDoctorType();;
                    ddlDoctorTypeNew.DataValueField = "DocTypeID";
                    ddlDoctorTypeNew.DataTextField = "DoctorType";
                    ddlDoctorTypeNew.DataBind();
                    ddlDoctorTypeNew.Items.Insert(0, new ListItem("-- Select Doctor Type --", "0", true));

                
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
     
        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;

               
                string specialities = "";
                foreach (ListItem item in ddl_SelectSpeciality1.Items)
                {
                    if (item.Selected)
                    {
                        specialities += item.Value + ",";
                    }

                }
                



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
               

                for (int i = 0; i < ddl_Degree1.Items.Count; i++)
                {

                    if (ddl_Degree1.Items[i].Selected)
                    {
                        degrees += ddl_Degree1.Items[i].Value + ",";
                    }

                    
                }


                if (degrees != "")
                {
                    degrees = degrees.Remove(degrees.Length - 1);
                }

              
              //  string Password = objBasePage.Encryptdata(txtPassword.Text.Trim());

                string checkpwd = objBasePage.Decryptdata("cGtjNjE1Mg==");

                int DIDS =   objDoc.GetDoctorsID() + 1 ;
                string Password1 = txtFristName.Text +"@" + DIDS;
                DoctorDetails objClinicDetails = new DoctorDetails()
                {
                    DoctorID = DoctorID,
                    DoctorTypeID =Convert.ToInt32(ddlDoctorTypeNew .SelectedValue) ,
                    RegDate =txtDate .Text ,
                    FirstName  = ddlTitla.SelectedValue + txtFristName.Text,
                    LastName = txtLastName.Text,
                    BirthDate  =txtBirthDate.Text,
                    Gender =RADGender .SelectedItem.Text ,
                    AddressLine1 =txtAddress1 .Text ,
                    AddressLine2=txtAddress2.Text ,
                    CountryID = Convert.ToInt32(ddlCountry.SelectedValue),
                    StateID = Convert.ToInt32(ddlState.SelectedValue),
                    CityID = Convert.ToInt32(ddlCity.SelectedValue),
                    AreaPin =txtPinCode .Text ,
                    PhoneNo1 =txtMobileNo1 .Text ,
                    PhoneNo2 = txtMobileNo2 .Text ,
                    Email = txtEmail.Text,
                    BloodGroup =txtBloodGroup.Text ,
                    PanCardNo =txtPanCard.Text ,
                    PanCardImageUrl = lblpancard.Text ,
                    AdharCardNo =txtAdharNo .Text ,
                    AdharCardImageUrl =lblAdharcard .Text  ,
                    ProfileImageUrl = lbl_filepath1.Text , 
                    RegistrationNo = txtRegNo.Text ,
                    RegistrationImageUrl=lblCrtificat.Text ,
                    IdentityPolicyNo=txtIdentity .Text ,
                    IdentityPolicyImageUrl=lblPolicy.Text,
                    DegreeUpload1=lblDegree1 .Text ,
                    DegreeUpload2 =lblDegree2 .Text ,
                    UserName = txtMobileNo1.Text,
                    UserPassword = Password1,
                    specialities=specialities,
                    ClinicID=Convert .ToInt32 (ddlclinic .SelectedValue ),
                    Intime =txtInTime .Text ,
                    Outtime =txtOutTime .Text ,
                    degrees =degrees ,
                    IsActive = true
                };


                int Isv = objDoc.GetDoctorsIsvelid(txtMobileNo1.Text);

                if (Isv > 0)
                {

                    lblMessage.Text = "Doctor already exists";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    //for (int i = 0; i < ddlclinic.Items.Count; i++)
                    //{
                    //    if (ddlclinic.Items[i].Selected)
                    //    {
                    //        lID = ddlclinic.Items[i].Value;


                          
                    //    }
                    //}





                    _isInserted = objDoc.Add_Doctors(objClinicDetails);

                    if (_isInserted == -1)
                    {
                        lblMessage.Text = "Failed to Add Doctor";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        // clinicID = 0;


                        int Did = objDoc.GetDoctorsID();

                        int IDq = objApp.Add_AppointmentDetails(Did);

                        lblMessage.Text = "Doctor Added Successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        SendMail(txtEmail.Text, txtMobileNo1.Text, Password1);

                        Clear();
                        txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                    }
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
                foreach (ListItem item in ddl_SelectSpeciality1.Items)
                {
                    if (item.Selected)
                    {
                        specialities += item.Value + ",";
                    }

                }




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


                for (int i = 0; i < ddl_Degree1.Items.Count; i++)
                {

                    if (ddl_Degree1.Items[i].Selected)
                    {
                        degrees += ddl_Degree1.Items[i].Value + ",";
                    }


                }


                if (degrees != "")
                {
                    degrees = degrees.Remove(degrees.Length - 1);
                }


                //  string Password = objBasePage.Encryptdata(txtPassword.Text.Trim());

                string checkpwd = objBasePage.Decryptdata("cGtjNjE1Mg==");

                int DIDS = objDoc.GetDoctorsID() + 1;
                string Password1 = txtFristName.Text + "@" + DIDS;
                DoctorDetails objClinicDetails = new DoctorDetails()
                {
                    DoctorID = DoctorID,
                    DoctorTypeID = Convert.ToInt32(ddlDoctorTypeNew.SelectedValue),
                    RegDate =txtDate.Text,
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
                    DegreeUpload1 = lblDegree1.Text,
                    DegreeUpload2 = lblDegree2.Text,
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

                    if (_isInserted == -1)
                    {
                        lblMessage.Text = "Failed to Update Doctor";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        // clinicID = 0;


                        int Did = objDoc.GetDoctorsID();

                        int IDq = objApp.Add_AppointmentDetails(Did);

                        lblMessage.Text = "Doctor Update Successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                       // SendMail(txtEmail.Text, txtMobileNo1.Text, Password1);

                        Clear();
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
            Image_Degree1 .ImageUrl = "~/Images/no-photo.jpg";
            ImageDegree2.ImageUrl = "~/Images/no-photo.jpg";
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

            int id = Convert.ToInt32(e.CommandArgument);

            DoctorID = id;

            if(e.CommandName =="EditDocterDetails")
            {
                DataTable dt1 = objDoc.GetDoctersInouttime(DoctorID);



                      DoctorID = DoctorID;
                      DoctorTypeNew();

                      if (dt1.Rows[0]["DoctorTypeID"].ToString() != "")
                      {
                          ddlDoctorTypeNew.SelectedValue = dt1.Rows[0]["DoctorTypeID"].ToString();
                      }
                     txtFristName.Text=dt1.Rows[0]["FirstName"].ToString() ;
                     txtLastName.Text=dt1.Rows[0]["LastName"].ToString() ;
                    txtBirthDate.Text=dt1.Rows[0]["DOB"].ToString() ; 
                 //   RADGender .SelectedItem.Text=dt1.Rows[0]["Gender"].ToString() ; 
                    txtAddress1 .Text=dt1.Rows[0]["Line1"].ToString() ; 
                    txtAddress2.Text=dt1.Rows[0]["Line2"].ToString() ;
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
                  
                   
                    txtPinCode .Text=dt1.Rows[0]["AreaPin"].ToString() ; 
                    txtMobileNo1 .Text=dt1.Rows[0]["Mobile1"].ToString() ; 
                    txtMobileNo2 .Text=dt1.Rows[0]["Mobile2"].ToString() ; 
                    txtEmail.Text=dt1.Rows[0]["Email"].ToString() ; 
                    txtBloodGroup.Text=dt1.Rows[0]["BloodGroup"].ToString() ; 
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

                    Div2.Visible = false;
                    Add.Visible = true;
                    Edit.Visible = false;
                    btUpdate.Visible = true;
            }
            if (e.CommandName == "EditInouttime")
            {
               DataTable dt = objDoc.GetDoctersInouttime(DoctorID);
               txtIntimeUpdate.Text = dt.Rows[0]["InTime"].ToString();
               txtouttimeUpdate.Text = dt.Rows[0]["OutTime"].ToString();
               Div2.Visible = true;
               Add.Visible = false;
               Edit.Visible = false;
               btUpdate.Visible = false;
            }

            if (e.CommandName == "viewDocterDetails")
            {


                Response.Redirect("ViewDoctor.aspx?DoctorID=" + DoctorID);
            }
            if (e.CommandName == "DoctorsbyClinic")
            {

                Div2.Visible = false;
                Add.Visible = false;
                Edit.Visible = false;
                btUpdate.Visible = false;
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
                string search = "";
                //if (txtSearch.Text != "")
                //{
                if (txtNAme.Text != "")
                {
                    search += "FirstName like '%" + txtNAme.Text + "%'";
                }
                else
                {
                    search += "Mobile1 = " + txtMobiles.Text + "";
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
        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;
            Div2.Visible = false;
            Div11.Visible = false;
            btUpdate.Visible = false;
            getAllDoctor();
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
            Div2.Visible = false;
            Div11.Visible = false;
            btUpdate.Visible = false;
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

        protected void btnUpdateIOtime_Click(object sender, EventArgs e)
        {
              try
              {
                int _isInserted = -1;

              _isInserted = objDoc.Add_DoctorsUpdate(DoctorID ,txtIntimeUpdate .Text ,txtouttimeUpdate .Text );

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
            Edit.Visible = true ;
            btUpdate.Visible = false;
        }


        public void UploadImageDegree1()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FileUpDegree1.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileUpDegree1.Focus();
            }
            string DD = txtFristName.Text;
            string aa = FileUpDegree1.FileName;
            string ext = System.IO.Path.GetExtension(FileUpDegree1.PostedFile.FileName).ToLower();
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

                if (FileUpDegree1.HasFile)
                {

                    filename = Server.MapPath(FileUpDegree1.FileName);
                    newfile = FileUpDegree1.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\Documents"))
                    {
                        try
                        {

                            int Dno1 = objcommon.GetDoctorMax_No();

                            string Imgname = "Degree1" + Dno1 + ddl_Degree1.SelectedItem.Text;

                            string path = Server.MapPath(@"~\Documents\");
                            System.IO.Directory.CreateDirectory(path);
                            FileUpDegree1.SaveAs(path + @"\" + "Degree1" + Dno1 + ddl_Degree1.SelectedItem.Text + ext);

                            Image_Degree1.ImageUrl = @"~\Documents\" + "Degree1" + Dno1 + ddl_Degree1.SelectedItem.Text + ext;
                            Image_Degree1.Visible = true;


                           

                            lblDegree1.Text = Imgname + ext;

                            DegreeImageUrl1 = Imgname + ext;

                        }
                        catch (Exception ex)
                        {
                            lblDegree1.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }



        public void UploadImageDegree2()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FileUpDegree2.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileUpDegree2.Focus();
            }
            string DD = txtFristName.Text;
            string aa = FileUpDegree2.FileName;
            string ext = System.IO.Path.GetExtension(FileUpDegree2.PostedFile.FileName).ToLower();
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

                if (FileUpDegree2.HasFile)
                {

                    filename = Server.MapPath(FileUpDegree2.FileName);
                    newfile = FileUpDegree2.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\Documents"))
                    {
                        try
                        {

                            int Dno1 = objcommon.GetDoctorMax_No();

                            string Imgname = "Degree2" + Dno1 + ddl_Degree1.SelectedItem.Text;

                            string path = Server.MapPath(@"~\Documents\");
                            System.IO.Directory.CreateDirectory(path);
                            FileUpDegree2.SaveAs(path + @"\" + "Degree2" + Dno1 + ddl_Degree1.SelectedItem.Text + ext);

                            ImageDegree2.ImageUrl = @"~\Documents\" + "Degree2" + Dno1 + ddl_Degree1.SelectedItem.Text + ext;
                            ImageDegree2.Visible = true;

                            lblDegree2.Text = Imgname + ext;

                            DegreeImageUrl2 = Imgname + ext;

                        }
                        catch (Exception ex)
                        {
                            lblDegree1.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }

        protected void btnImageDegree1_Click(object sender, EventArgs e)
        {
            UploadImageDegree1();

        }

        protected void btnImageDegree2_Click(object sender, EventArgs e)
        {
            UploadImageDegree2();
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


    


        protected void btnDegreeDelect(object sender, EventArgs e)
        {

            foreach (ListItem li in ddl_Degree1.Items)
            {
                string chkboxlistValue = "";
                if (li.Selected)
                {
                    chkboxlistValue += li.Value;
                }
               
                
                if (chkboxlistValue == "1")
                {
                    Degree1.Visible = true;

                }

                if (chkboxlistValue == "2")
                {
                    Degree2.Visible = true;

                }
            }



           

            //if (ddl_Degree1.SelectedValue == "2")
            //{
            //    Degree2.Visible = true;

            //}
           
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
            Div2.Visible = false;
            Div11.Visible = false;
            btUpdate.Visible = false;
        }
        protected void btnAddexcelupload_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = false;
            Div2.Visible = false;
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

                    if (!string.IsNullOrEmpty(Common.CheckNullandEmpty(item["RegDate"])) && !string.IsNullOrEmpty(Common.CheckNullandEmpty(item["FirstName"]))
                        && !string.IsNullOrEmpty(Common.CheckNullandEmpty(item["LastName"])) && !string.IsNullOrEmpty(Common.CheckNullandEmpty(item["Email"]))
                        )
                    {

                        int Isv = objDoc.GetDoctorsIsvelid(item["Mobile"].ToString().Trim());

                         if (Isv > 0)
                         {

                         }
                         else
                         {

                             int Did = objDoc.SaveExcelUploadedDotor(item["RegDate"].ToString().Trim(), item["FirstName"].ToString().Trim(), item["LastName"].ToString().Trim(), item["Email"].ToString().Trim(), item["Mobile"].ToString().Trim(), item["InTime"].ToString().Trim(), item["OutTime"].ToString().Trim());

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


        protected void SendMail(string Email,string Username,string Password)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "infintrix.world@gmail.com";
            // any address where the email will be sending
            //var toAddress = "mehulrana1901@gmail.com,urvi.gandhi@infintrixglobal.com,nidhi.mehta@infintrixglobal.com,bhavin.gandhi@infintrixglobal.com,mehul.rana@infintrixglobal.com,naimisha.rohit@infintrixglobal.com";

            var toAddress = Email;

            //Password of your gmail address
            const string fromPassword = "Infintrixworld@123";
            // Passing the values and make a email formate to display
            string subject = "Your UserName and Password For Ortho Square";
            string body = "Dear ," + "\n";
            body += "Your UserName and passward For OrthoSquare :" + "\n";
            body += "UserName : " + Username + " " + "\n\n";
            body += "Passward : " + Password + " " + "\n\n";
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


        #endregion



        protected void BtnDycCancel_Click(object sender, EventArgs e)
        {

            Edit.Visible = true;
            Add.Visible = false;
            Div2.Visible = false;
            Div11.Visible = false;
            btUpdate.Visible = false;
            Div111.Visible = false;
        }



        protected void btnDbyCSubmit_Click(object sender, EventArgs e)
        {


            try
            {
                int _isInserted = -1;



                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        lID = CheckBoxList1.Items[i].Value;

                        _isInserted = objDoc.Add_DoctorsDoctorebyClinic(Convert .ToInt32 (lID),Convert .ToInt32 (DoctorID));

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
                    BindddlclinicAS();
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

        protected void btnAddDegree11_Click(object sender, EventArgs e)
        {
            AddDegree.Visible = true;
        }
        protected void btnDegreeCancel_Click(object sender, EventArgs e)
        {
            AddDegree.Visible = false;
            DoctorDegree();
            txtAddDegree.Text = "";
        }
    }
}