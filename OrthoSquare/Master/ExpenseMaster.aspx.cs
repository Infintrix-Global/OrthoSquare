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


namespace OrthoSquare.Master
{

    
    public partial class ExpenseMaster : System.Web.UI.Page
    {

        BAL_Expense objExp = new BAL_Expense();
        BAL_DoctorsDetails objdoc = new BAL_DoctorsDetails();
        BAL_Vendor objv = new BAL_Vendor();
        clsCommonMasters objcomm = new clsCommonMasters();
        public static DataTable AllData = new DataTable();
        BAL_Clinic objc = new BAL_Clinic();
        BAL_VendorType objVt = new BAL_VendorType();
        protected void Page_Load(object sender, EventArgs e)
        {

          

            if (!IsPostBack)
            {
                if (SessionUtilities.RoleID == 1)
                {
                    bindClinic();
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    bindDoctorMaster(SessionUtilities.Empid);

                    ddlClinicSearch.SelectedValue = SessionUtilities.Empid.ToString();
                    bindDoctorMasterSearch(SessionUtilities.Empid);

                    getAllExpense(Convert.ToInt32(ddlClinic.SelectedValue), 0);

                }
                else if(SessionUtilities.RoleID == 3)
                {

                    bindClinic();
                    bindDoctorMasterSearch(0);

                    getAllExpense(0, Convert.ToInt32(SessionUtilities.Empid));
                }
                else
                {
                    bindClinic();

                    getAllExpense(0,0);

                }
               
                bindVendorType();
               
            }
        }

        private long ExpenseID
        {
            get
            {
                if (ViewState["ExpenseID"] != null)
                {
                    return (long)ViewState["ExpenseID"];
                }
                return 0;
            }
            set
            {
                ViewState["ExpenseID"] = value;
            }
        }
        public void bindVendorType()
        {
            ddlVendorType.DataSource = objVt.GetAllVendorType();
            ddlVendorType.DataValueField = "VendorTypeId";
            ddlVendorType.DataTextField = "VendorType";
            ddlVendorType.DataBind();
            ddlVendorType.Items.Insert(0, new ListItem("-- Select vendor Type --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged11(object sender, EventArgs e)
        {
            bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
        }

        protected void ddlClinicSearch_SelectedIndexChanged11(object sender, EventArgs e)
        {
            bindDoctorMasterSearch(Convert.ToInt32(ddlClinicSearch.SelectedValue));
        }

        protected void ddlVendorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVendor();

            if(ddlVendorType .SelectedValue =="9")
            {
                PanelPlace.Visible = true;
                Panelvendor.Visible = false;
            }
            else
            {
                PanelPlace.Visible = false;
                Panelvendor.Visible = true;
            }
        }

        public void bindDoctorMaster(int Cid)
        {



            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {
                ddlDoctor1.DataSource = objcomm.DoctersMaster(Cid, SessionUtilities.RoleID);




            }
            else
            {
                ddlDoctor1.DataSource = objcomm.DoctersMasterAdmin(Cid);


            }



            ddlDoctor1.DataValueField = "DoctorID";
            ddlDoctor1.DataTextField = "DoctorName";
            ddlDoctor1.DataBind();
            ddlDoctor1.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        public void bindDoctorMasterSearch(int Cid)
        {



            if  (SessionUtilities.RoleID == 1)
            {
                ddlDocterSearch.DataSource = objcomm.DoctersMaster(Cid, SessionUtilities.RoleID);

            }
            else if(SessionUtilities.RoleID == 3)
            {
                ddlDocterSearch.DataSource = objcomm.DoctersMasterAdmin(Cid);

            }
            else
            {
                ddlDocterSearch.DataSource = objcomm.DoctersMasterAdmin(Cid);


            }



            ddlDocterSearch.DataValueField = "DoctorID";
            ddlDocterSearch.DataTextField = "DoctorName";
            ddlDocterSearch.DataBind();
            ddlDocterSearch.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        public void BindDocter()
        {
           

            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDoctor1.DataSource = objcomm.DoctersMaster(SessionUtilities.Empid, SessionUtilities.RoleID);
             
            }
            else
            {
                ddlDoctor1.DataSource = objcomm.DoctersMaster(0, SessionUtilities.RoleID);
              
            }

            
           // ddlDoctor1.DataSource = objdoc.GetAllDocters(Did);
            ddlDoctor1.DataTextField = "DoctorName";
            ddlDoctor1.DataValueField = "DoctorID";
            ddlDoctor1.DataBind();

            ddlDoctor1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        public void bindClinic()
        {

            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcomm.GetDoctorByClinic(SessionUtilities.Empid);
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


            ddlClinicSearch.DataSource = dt;

            ddlClinicSearch.DataValueField = "ClinicID";
            ddlClinicSearch.DataTextField = "ClinicName";
            ddlClinicSearch.DataBind();
            ddlClinicSearch.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));






        }

        public void BindVendor()
        {
            ddlVendor.DataSource = objv.GetAllVendor(0,Convert .ToInt32 (ddlVendorType .SelectedValue ));
            ddlVendor.DataTextField = "VendorName";
            ddlVendor.DataValueField = "VendorID";
            ddlVendor.DataBind();

            ddlVendor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

     
        public void getAllExpense(int Cid,int Did)
        {
            //int Cid = 0;
            //int Did = 0;
            //if(SessionUtilities .RoleID ==1)
            //{
            //    Cid = SessionUtilities.Empid;
            //    Did = 0;
            //}
            //else if(SessionUtilities.RoleID == 3)
            //{
            //    Did = SessionUtilities.Empid;
            //    Cid = 0;
            //}
            //else
            //{
            //    Cid = 0;
            //    Did = 0;

            //}

            AllData = objExp.GetAllExpenSe(Cid, Did);
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;


                _isInserted = objExp.Add_Expense(ExpenseID, Convert.ToInt32(ddlDoctor1.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), ddlVendorType.SelectedItem.Text, ddlVendor.SelectedItem.Text, txtAmount.Text, txtExpDate.Text, txtExpDetails.Text, lblEXP.Text, SessionUtilities.Empid,txtFormPlace.Text ,txtToplace .Text);



                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Expense";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    ExpenseID = 0;
                    Clear();
                    lblMessage.Text = "Expense Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                  


                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;
            getAllExpense(Convert.ToInt32(ddlClinicSearch.SelectedValue), Convert.ToInt32(ddlDocterSearch.SelectedValue));

        }

        public void Clear()
        {
            CleartextBoxes(this);
          //  BindPatient();
          //  BindTypeOfwork();
            lblMessage.Text = "";

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

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
            getAllExpense(Convert.ToInt32(ddlClinicSearch.SelectedValue),Convert.ToInt32(ddlDocterSearch.SelectedValue));
       
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

          
         
            if (e.CommandName == "EditEnquiry")
            {

                Add.Visible = true;
                Edit.Visible = false;

                int ID = Convert.ToInt32(e.CommandArgument);

                ExpenseID  = ID;

                try
                {

                      string search = "";

               
                    search += "ExpenseID ='" + ID + "'";
              
               

                DataRow[] dtSearch1 = AllData.Select(search);
                if (dtSearch1.Count() > 0)
                {
                    DataTable dtSearch = dtSearch1.CopyToDataTable();
                    BindVendor();
                    ddlVendorType.SelectedItem.Text = dtSearch.Rows[0]["VendorType"].ToString();
                    BindVendor();

                    ddlVendor .SelectedItem .Text = dtSearch.Rows[0]["VendorName"].ToString();
                    txtAmount.Text =( Convert .ToInt32 (dtSearch.Rows[0]["Amount"])).ToString ();
                    txtExpDate.Text =Convert .ToDateTime ( dtSearch.Rows[0]["ExpDate"]).ToString("dd-MM-yyyy");
                    txtExpDetails.Text = dtSearch.Rows[0]["ExpDetails"].ToString();
                    bindClinic();

                    ddlClinic.SelectedValue = dtSearch.Rows[0]["ClinicID"].ToString();
                    bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
                    ddlDoctor1.SelectedValue = dtSearch.Rows[0]["DoctorID"].ToString();

                    ImageEXP.ImageUrl = @"~\Documents\" + dtSearch.Rows[0]["ExpBillphoto"].ToString();
                    lblEXP.Text = dtSearch.Rows[0]["ExpBillphoto"].ToString(); 
                }


               
                    
                    
                    
                    //txtNotes.Text = dt.Rows[0]["Notes"].ToString();
                    //txtWorkcompletion.Text = dt.Rows[0]["Workcompletion"].ToString();
                    //BindPatient();

                    //ddlpatient.SelectedValue = dt.Rows[0]["patientid"].ToString();
                    //BindTypeOfwork();

                    //ddlTypeOfwork.SelectedValue = dt.Rows[0]["TypeOfworkId"].ToString();


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

                int _isDeleted = objExp.DeleteExp(ID);
                if (_isDeleted != -1)
                {

                    lblMessage.Text = "Expense Deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    //  Response.Redirect("EnquiryDetails.aspx");
                    btSearch_Click(sender, e);
                    getAllExpense(Convert.ToInt32(ddlClinicSearch.SelectedValue), Convert.ToInt32(ddlDocterSearch.SelectedValue));

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
                getAllExpense(Convert.ToInt32(ddlClinicSearch.SelectedValue), Convert.ToInt32(ddlDocterSearch.SelectedValue));


            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
            lblMessage.Text = "";
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblFormPlace = (Label)e.Row.FindControl("lblFormPlace");
                Label lblToPlace = (Label)e.Row.FindControl("lblToPlace");
                Label lblVendorName = (Label)e.Row.FindControl("lblVendorName");
                Label lblVendorType = (Label)e.Row.FindControl("lblVendorType");

                if (lblVendorType.Text == "Travelling")
                {
                    if (lblFormPlace.Text != "")
                    {
                        lblVendorName.Text = "From " + lblFormPlace.Text + "  To " + lblToPlace.Text;
                    }
                    else
                    {
                        lblVendorName.Text = "";
                    }
                }

            }
        }

        protected void btnUploadEXP_Click(object sender, EventArgs e)
        {
            UploadImageExpense();
        }

        public void UploadImageExpense()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FileEXP.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileEXP.Focus();
            }
          
            string ext = System.IO.Path.GetExtension(FileEXP.PostedFile.FileName).ToLower();
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

                if (FileEXP.HasFile)
                {

                    filename = Server.MapPath(FileEXP.FileName);
                    newfile = FileEXP.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\Documents"))
                    {
                        try
                        {

                            int Dno = objcomm.GetExpenseNo();

                            string Imgname = "Bill" + Dno +ddlVendor .SelectedItem .Text ;

                            string path = Server.MapPath(@"~\Documents\");
                            System.IO.Directory.CreateDirectory(path);
                            FileEXP.SaveAs(path + @"\" + "Bill" + Dno + ddlVendor.SelectedItem.Text + ext);

                            ImageEXP.ImageUrl = @"~\Documents\" + "Bill" + Dno + ddlVendor.SelectedItem.Text + ext;
                            ImageEXP.Visible = true;

                            lblEXP.Text = Imgname + ext;

                            //AdharCarImageUrl = Imgname + ext;

                        }
                        catch (Exception ex)
                        {
                            lblEXP.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }

    }
}