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
namespace OrthoSquare.Enquiry
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
                getAllEnquiry();
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


        public void bindddlTreatment()
        {
            ddlTreatment.DataSource = objT.GetAllTreatment();
            ddlTreatment.DataValueField = "TreatmentID";
            ddlTreatment.DataTextField = "TreatmentName";
            ddlTreatment.DataBind();
            ddlTreatment.Items.Insert(0, new ListItem("-- Select Treatment--", "0", true));

        }

        public void Bindddlclinic()
        {
            ddlclinic.DataSource = objcommon.clinicMaster();
            ddlclinic.DataTextField = "ClinicName";
            ddlclinic.DataValueField = "ClinicID";
            ddlclinic.DataBind();

            ddlclinic.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }
        public void BindAssignToEmp(long Cid)
        {
            ddlAssign.DataSource = objclinic.GetSelectAllClinicEmployee(Cid);
            ddlAssign.DataTextField = "FirstName";
            ddlAssign.DataValueField = "DoctorID";
            ddlAssign.DataBind();

            ddlAssign.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void getAllEnquiry()
        {
            int Cid = 0;

            if( SessionUtilities .RoleID ==2 )
            {

                Cid = 0;
            }
            else
            {

                Cid = SessionUtilities.Empid;

            }



            AllData = objENQ.GetAllEnquiry(Cid);


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

            ddlEnquirySource.Items.Insert(iCount, new ListItem("Other", "-1"));
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

            string sid ="";

            if (ddlState.SelectedValue=="")
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


                string c = ddlCity.SelectedValue;


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
                    ReceivedByEmpId = SessionUtilities.Empid,
                    AssignToEmpId = Convert.ToInt32(ddlAssign.SelectedValue),
                    Status = "P",
                    //Folllowupdate = Convert.ToDateTime(txtFollowupDate.Text),
                    Folllowupdate = txtFollowupDate.Text,
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


                int Isv = objENQ.GetEnqurysIsvelid(txtMobile.Text);

                 if (Isv > 0)
                 {

                     lblMessage.Text = "Enquiry already exists";
                     lblMessage.ForeColor = System.Drawing.Color.Red;

                 }
                 else
                 {
                     _isInserted = objENQ.Add_Enquiry(objEnqDetails);
                 }
                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Enquiry";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    EnquiryID = 0;
                    lblMessage.Text = "Enquiry Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    //txtCompanyName.Text = "";
                    //txtBrandName.Text = "";
                    if (Rabinfo.SelectedValue == "Patient")
                    {

                        string Eid = objENQ.GetEnqMaxId();

                        Response.Redirect("../patient/PatientMaster.aspx?Eid=" + Eid);
                    }
                    else
                    {
                        Response.Redirect("EnquiryDetails.aspx");

                    }
                    // getAllMaterial();
                    //btSearch_Click(sender, e);
                }
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

                EnquiryID = ID;

                try
                {

                    DataTable dt = objENQ.GetSelectAllEnquiry(ID);

                    txtEnquiryNO.Text = dt.Rows[0]["Enquiryno"].ToString();
                    txtENqDate.Text = dt.Rows[0]["EnquiryDate"].ToString();
                    txtFname.Text = dt.Rows[0]["FirstName"].ToString();
                    txtLname.Text = dt.Rows[0]["LastName"].ToString();
                    txtBDate.Text = dt.Rows[0]["DateBirth"].ToString();
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                    txtArea.Text = dt.Rows[0]["Area"].ToString();
                    txtTelephone.Text = dt.Rows[0]["Telephone"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtFollowupDate.Text = dt.Rows[0]["Folllowupdate"].ToString();
                    BindCountry();
                    if (dt.Rows[0]["CountryId"].ToString() != "")
                    {
                        ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString();
                    }
                    BindState();
                    if (dt.Rows[0]["stateid"].ToString() !="")
                    {
                        ddlState.SelectedValue = dt.Rows[0]["stateid"].ToString();
                    }
                    BindCity();
                    if (dt.Rows[0]["Cityid"].ToString() !="")
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
                    RadGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                    if (dt.Rows[0]["InterestLevel"].ToString() != "")
                    {
                        RadInterestLavel.SelectedValue = dt.Rows[0]["InterestLevel"].ToString();

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
                string search = "";
                //if (txtSearch.Text != "")
                //{
                if (txtSearch.Text != "")
                {
                    search += "FirstName like '%" + txtSearch.Text + "%'";
                }

                if (Convert .ToInt32 (ddlEnquirysourceSearch.SelectedValue)  > 0)
                {
                    search += "Sourceid = " + Convert.ToInt32(ddlEnquirysourceSearch.SelectedValue) + "";
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

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int _isInserted = -1;


            //    string LavelCode = "";
            //    if (RadInterestLavel.SelectedItem.Text == "1")
            //    {
            //        LavelCode = "Cold";
            //    }
            //    else if (RadInterestLavel.SelectedItem.Text == "2" || RadInterestLavel.SelectedItem.Text == "3")
            //    {
            //        LavelCode = "Warm";
            //    }
            //    else
            //    {
            //        LavelCode = "hot";
            //    }


            //    Enquiry_Details objEnqDetails = new Enquiry_Details()
            //    {
            //        EnquiryID = EnquiryID,
            //        //CatId = Convert.ToInt32(ddlInterested.SelectedValue),
            //        Sourceid = Convert.ToInt32(ddlEnquirySource.SelectedValue),
            //       // PurposeId = Convert.ToInt32(ddlPurpose.SelectedValue),
            //        Enquiryno = txtEnquiryNO.Text,
            //        //  EnquiryDate = Convert.ToDateTime(txtENqDate.Text),
            //        FirstName = txtFname.Text,
            //        LastName = txtLname.Text,
            //        // DateBirth = Convert.ToDateTime(txtBDate.Text),
            //        Age = txtAge.Text,
            //        Gender = RadGender.SelectedItem.Text,
            //        Address = txtAddress.Text,
            //        stateid = Convert.ToInt32(ddlState.SelectedValue),
            //        Cityid = Convert.ToInt32(ddlCity.SelectedValue),
            //        Area = txtArea.Text,
            //        Email = txtEmail.Text,
            //        Mobile = txtMobile.Text,
            //        Telephone = txtTelephone.Text,
            //       // ReceivedByEmpId = Convert.ToInt32(ddlReceivedBy.SelectedValue),
            //       // AssignToEmpId = Convert.ToInt32(ddlAssign.SelectedValue),
            //        Status = "P",
            //        //Folllowupdate = Convert.ToDateTime(txtFollowupDate.Text),
            //        InterestLevel = RadInterestLavel.SelectedItem.Text,
            //        InterestLevelCode = LavelCode,
            //        ModifiedBy = 1,
            //        IsActive = true
            //        //ModifiedDate =""
            //    };

            //    _isInserted = objENQ.Update_Enquiry(objEnqDetails);

            //    if (_isInserted == -1)
            //    {
            //        lblMessage.Text = "Failed to Update Enquiry";
            //        lblMessage.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else
            //    {
            //        EnquiryID = 0;
            //        lblMessage.Text = "Material Update Enquiry";
            //        lblMessage.ForeColor = System.Drawing.Color.Green;
            //        //txtCompanyName.Text = "";
            //        //txtBrandName.Text = "";
            //        Response.Redirect("EnquiryDetails.aspx");
            //        getAllEnquiry();
            //        //btSearch_Click(sender, e);
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
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

            Edit.Visible = true;
            Add.Visible = false;
            Div2.Visible = false;
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
            BindAssignToEmp(Convert.ToInt32(ddlclinic.SelectedValue));
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
            if (ddlEnquirySource.SelectedItem.Text == "Other")
            {
                LinkButton1.Visible = true;
            }
            else
            {

                LinkButton1.Visible = false;
            }
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
                obj.ColumnHeaderName = "Primary Education Details Report";
                obj.ColumnValue = null;
                objExcelRows.Add(obj);

                GridViewExportUtil.ExportToExcelManual("PrimaryEducation", objExcelRows, dtDataExcel, null);
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
          bool  Result = false;
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
                       // divOptionalMessage.Visible = true;
                       // divOptionalMessageSub.Attributes.Remove("class");
                      //  divOptionalMessageSub.Attributes.Add("class", "confirmmsg");
                       // lblOptionalmsg.Attributes.Add("style", "color:Green");
                        lblMSG1.Text = "Enquiry Information have been uploaded sucessfully.";
                        //ErrorName = ErrorName;
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
                    int SourceID = 0, TreatmentID = 0, ClinicID = 0, DoctorID=0;
                    //int FieldID = 0, Groupid = 0;

                    if ( !string.IsNullOrEmpty(Common.CheckNullandEmpty(item["FirstName"]))
                        )
                    {
                        //Get Faculty ID based on Faculty Name
                        //string strSource = item["Source"].ToString().Trim().Replace("  ", " ");
                        //SourceID = objENQ.GetEnquirySourceID(strSource);

                        //Get Course ID based on FacultyID and CourseName
                        string strTreatment = item["Treatment"].ToString().Trim().Replace("  ", " ");
                        TreatmentID = objENQ.GetEnquiryTreatmentID(strTreatment);

                        //Get Subject ID based on  CourseID and SubjectName
                        string ClinicName = item["Clinic"].ToString().Trim().Replace("  ", " ");
                        ClinicID = objENQ.GetEnquiryClinicID(ClinicName);



                        //string AssignTo = item["AssignTo"].ToString().Trim().Replace("  ", " ");
                        //DoctorID = objENQ.GetEnquiryDoctorID(AssignTo);

                      

                        //  txtENqDate.Text = System.DateTime.Now.ToString("dd MMM yyyy");

                          int Eno = objcommon.GetEnquiryNo();
                          string EnquiryNO = "E" + Eno.ToString();


                          int Isv = objENQ.GetEnqurysIsvelid(item["Mobile"].ToString().Trim());

                          if (Isv > 0)
                          {

                          }
                          else
                          {


                              objENQ.SaveExcelUploadedEnquiry(TreatmentID, ClinicID, EnquiryNO, item["FirstName"].ToString().Trim(), item["LastName"].ToString().Trim(), item["Email"].ToString().Trim(), item["Mobile"].ToString().Trim(), item["Conversation"].ToString().Trim());
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
            DownloadFile("Enquiry_Master.xlsx", "Enquiry_Master.xlsx");
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