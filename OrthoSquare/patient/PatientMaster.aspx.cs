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

namespace OrthoSquare.patient
{
    public partial class PatientMaster : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Patient objPatient = new BAL_Patient();
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        public static DataTable AllData = new DataTable();
        int PatientID = 0;
        int Eid = 0;
        string lID = "";
        protected void Page_Load(object sender, EventArgs e)
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
                TabContactPerson1.Tabs[0].Enabled = true;

                TabContactPerson1.Tabs[1].Enabled = false;
                TabContactPerson1.Tabs[2].Enabled = false;
            }
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
                        txtBDate.Text = dt.Rows[0]["DateBirth"].ToString();
                        ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString();
                        BindState();
                        ddlState.SelectedValue = dt.Rows[0]["stateid"].ToString();
                        BindCity();
                        ddlCity.SelectedValue = dt.Rows[0]["Cityid"].ToString();
                        RadGender.SelectedValue = dt.Rows[0]["Gender"].ToString();


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
                           lID += CheckBoxList1.Items[i].Value + ",";

                           

                       }
                   }

                   if (lID != "")
                   {
                       lID = lID.Remove(lID.Length - 1);
                   }




                   string ConsentStatement = "";

                if (CheckConsentStatement.Checked==true)
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

                Patient_Details objPatientDetails = new Patient_Details()
                {
                    patientid = patientid,
                    ClinicID=SessionUtilities .Empid ,
                    EnquiryId=Eid,
                    PatientCode = txtPatientNo.Text,
                    // EnquiryDate = Convert .ToDateTime(txtENqDate.Text),
                    RegistrationDate  = txtRegDate.Text,

                    FirstName = txtFname.Text,
                    LastName = txtLname.Text,
                    // DateBirth = Convert .ToDateTime (txtBDate.Text),
                    DateBirth =txtBDate.Text,
                    Age = txtAge.Text,
                    boolgroup=txtBoolGroup .Text,
                    Gender = RadGender.SelectedItem.Text,
                    Address = txtAddress.Text,
                    CountryId = Convert.ToInt32(ddlCountry.SelectedValue),
                    stateid = Convert.ToInt32(ddlState.SelectedValue),
                    Cityid = Convert.ToInt32(ddlCity.SelectedValue),
                    Area = txtArea.Text,
                    Email = txtEmail.Text,
                    Mobile = txtMobile.Text,
                    Telephone = txtTelephone.Text,
                    MedicalProblem= MedicalProblem,
                    Allergic=Allergic,
                    Pregnant =RadPregnant.SelectedItem .Text ,
                    DueDate=  txtPreganetDueDate.Text, 
                    PanMasalaChewing= RadPanMasala.SelectedItem .Text ,
                    Tobacco=RadTobacco .SelectedItem .Text ,
                    Somking=RadSomking.SelectedItem .Text ,
                    cigrattesInDay=txtNofoCigrattes.Text,
                    ListofMedicine=txtListMedicine.Text ,
                    FamilyDoctorName=txtFDoctorName.Text,
                    DrAddress =txtDoctorAddres .Text ,
                    ProfileImage=lblProfile .Text ,

                    Complaint =txtcomplaint.Text ,
                    DentalTreatment = txtlistDentalTreatment.Text,
                    ConsentStatement=ConsentStatement, 
                   // PaymentMode = RadioPayment1.SelectedItem .Text ,
                    //PayDate =txtpaymentDate1 .Text ,
                   // Amount=txtAmount1 .Text ,
                   Nooftooth=lID,
                    CreatedBy = 1,
                    ModifiedBy = SessionUtilities.Empid,

                    IsActive = true

                };


                  int Isv = objPatient.GetPatientssIsvelid(txtMobile.Text);

                  if (Isv > 0)
                  {
                      lblMessage.Text = "Doctor already exists";
                      lblMessage.ForeColor = System.Drawing.Color.Red;

                  }
                  else
                  {
                      _isInserted = objPatient.Add_Patient(objPatientDetails);
                  }
                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Patient";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    patientid = 0;
                    lblMessage.Text = "Patient Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    Clear();
                    btnConsultation.Visible = true;
                   // Response.Redirect("PatientMaster.aspx");
                    
                }
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

            AllData = objPatient.GetPatientlist();
            //Dhaval 
            for (int i = 0; i < AllData.Rows.Count; i++)
            {
                if (AllData.Rows[i]["Pstatus"].ToString() == "1")
                { AllData.Rows[i]["Pstatus"] = "Less Co-operative"; }
                else if (AllData.Rows[i]["Pstatus"].ToString() == "2")
                { AllData.Rows[i]["Pstatus"] = "Co-operative"; }
                else if (AllData.Rows[i]["Pstatus"].ToString() == "3")
                { AllData.Rows[i]["Pstatus"] = "Very Co-operative"; }
            }
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                //if (txtSearch.Text != "")
                //{
                if (txtSearch.Text != "")
                {
                    search += "FristName like '%" + txtSearch.Text + "%'";
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

                try
                {

                    DataTable dt = objENQ.GetSelectAllEnquiry(ID);

                    //txtEnquiryNO.Text = dt.Rows[0]["Enquiryno"].ToString();
                    //txtENqDate.Text = dt.Rows[0]["EnquiryDate"].ToString();
                    //txtFname.Text = dt.Rows[0]["FirstName"].ToString();
                    //txtLname.Text = dt.Rows[0]["LastName"].ToString();
                    //txtBDate.Text = dt.Rows[0]["DateBirth"].ToString();
                    //txtAge.Text = dt.Rows[0]["Age"].ToString();
                    //txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    //txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                    //txtArea.Text = dt.Rows[0]["Area"].ToString();
                    //txtTelephone.Text = dt.Rows[0]["Telephone"].ToString();
                    //txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    //txtFollowupDate.Text = dt.Rows[0]["Folllowupdate"].ToString();
                    //BindCountry();
                    //ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString();
                    //BindState();
                    //ddlState.SelectedValue = dt.Rows[0]["stateid"].ToString();
                    //BindCity();
                    //ddlCity.SelectedValue = dt.Rows[0]["Cityid"].ToString();
                    ////   ddlInterested.SelectedValue = dt.Rows[0]["CatId"].ToString();
                    //BindEnquirySource();
                    //ddlEnquirySource.SelectedValue = dt.Rows[0]["Sourceid"].ToString();
                    ////  ddlPurpose.SelectedValue = dt.Rows[0]["PurposeId"].ToString();
                    ////  ddlReceivedBy.SelectedValue = dt.Rows[0]["ReceivedByEmpId"].ToString();
                    ////  ddlAssign.SelectedValue = dt.Rows[0]["AssignToEmpId"].ToString();
                    //RadGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                    //RadInterestLavel.SelectedValue = dt.Rows[0]["InterestLevel"].ToString();


                    //  ddlUOM.SelectedValue = dt.Rows[0]["UOMId"].ToString();
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
            int pid = objcommon.GetpatientNo();

         //   Response.Redirect("../Doctor/ConsultationAddTreatment.aspx");
            Response.Redirect("../Doctor/ConsultationAddTreatment.aspx?pid=" + pid);
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

                    if ( !string.IsNullOrEmpty(Common.CheckNullandEmpty(item["FirstName"]))
                        && !string.IsNullOrEmpty(Common.CheckNullandEmpty(item["LastName"]) )
                        )
                    {

                        int Isv = objPatient.GetPatientssIsvelid(item["Mobile"].ToString().Trim());

                        if (Isv > 0)
                        {

                        }
                        else
                        {

                            int Did = objPatient.SaveExcelUploadedPatient(PCode, item["FirstName"].ToString().Trim(), item["LastName"].ToString().Trim(), item["Email"].ToString().Trim(), item["Mobile"].ToString().Trim(), item["BirthDate"].ToString().Trim());

                        
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




    }
}