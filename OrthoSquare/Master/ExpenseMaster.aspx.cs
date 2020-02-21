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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAllExpense();
                BindDocter();
                BindVendor();
                BindDocterSearch();
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

        public void BindDocter()
        {
            ddlDoctor1.DataSource = objdoc.GetAllDocters(SessionUtilities.Empid);
            ddlDoctor1.DataTextField = "FirstName";
            ddlDoctor1.DataValueField = "DoctorID";
            ddlDoctor1.DataBind();

            ddlDoctor1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        public void BindVendor()
        {
            ddlVendor.DataSource = objv.GetAllVendor();
            ddlVendor.DataTextField = "VendorName";
            ddlVendor.DataValueField = "VendorID";
            ddlVendor.DataBind();

            ddlVendor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindDocterSearch()
        {
            ddlDocterSearch.DataSource = objdoc.GetAllDocters(SessionUtilities.Empid);
            ddlDocterSearch.DataTextField = "FirstName";
            ddlDocterSearch.DataValueField = "DoctorID";
            ddlDocterSearch.DataBind();

            ddlDocterSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }




        public void getAllExpense()
        {

            AllData = objExp.GetAllExpenSe();
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;



                _isInserted = objExp.Add_Expense(ExpenseID, Convert.ToInt32(ddlDoctor1.SelectedValue), SessionUtilities.Empid, ddlVendor.SelectedItem .Text, txtAmount.Text, txtExpDate.Text,txtExpDetails .Text ,lblEXP .Text , SessionUtilities.Empid);



                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Expense";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    ExpenseID = 0;
                    lblMessage.Text = "Expense Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    Clear();


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
            getAllExpense();
        }


        public void Clear()
        {
            CleartextBoxes(this);
          //  BindPatient();
          //  BindTypeOfwork();

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
            getAllExpense();
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

                    ddlVendor .SelectedItem .Text = dtSearch.Rows[0]["VendorName"].ToString();
                    txtAmount.Text =( Convert .ToInt32 (dtSearch.Rows[0]["Amount"])).ToString ();
                    txtExpDate.Text =Convert .ToDateTime ( dtSearch.Rows[0]["ExpDate"]).ToString("dd-MM-yyyy");
                    txtExpDetails.Text = dtSearch.Rows[0]["ExpDetails"].ToString();

                    ddlDoctor1.SelectedValue = dtSearch.Rows[0]["DoctorID"].ToString();
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
                    getAllExpense();
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

                if (Convert.ToInt32(ddlDocterSearch.SelectedValue) > 0)
                {
                    search += "DoctorID ='" + Convert.ToInt32(ddlDocterSearch.SelectedValue) + "'";
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

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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