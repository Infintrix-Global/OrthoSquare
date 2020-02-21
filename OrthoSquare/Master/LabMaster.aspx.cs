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
    public partial class LabMaster : System.Web.UI.Page
    {
        BAL_LabsDetails objL = new BAL_LabsDetails();
        clsCommonMasters objcomm = new clsCommonMasters();
        BAL_Patient objp = new BAL_Patient();
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getAllLabs();
                BindPatient();
                BindTypeOfwork();
            }

        }

        public void getAllLabs()
        {

            AllData = objL.GetLabs();
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        public void BindTypeOfwork()
        {
            DataTable dt = objcomm.GetTypeofWorkLab();


            ddlTypeOfwork.DataSource = dt;
            ddlTypeOfwork.DataTextField = "TypeName";
            ddlTypeOfwork.DataValueField = "TypeOfworkId";
            ddlTypeOfwork.DataBind();

            ddlTypeOfwork.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindPatient()
        {
            ddlpatient.DataSource = objp.GetPatientlist();
            ddlpatient.DataTextField = "FristName";
            ddlpatient.DataValueField = "patientid";
            ddlpatient.DataBind();

            ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        private long Labid
        {
            get
            {
                if (ViewState["Labid"] != null)
                {
                    return (long)ViewState["Labid"];
                }
                return 0;
            }
            set
            {
                ViewState["Labid"] = value;
            }
        }
        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;



                LabDetails objLab = new LabDetails()
                {
                  
                     Labid =Labid,
	                 patientid =Convert .ToInt32(ddlpatient .SelectedValue ),
                     TypeOfworkId = Convert.ToInt32(ddlTypeOfwork.SelectedValue),
	                 LabName =txtLabname .Text ,
                   	 ToothNo=txtToothNo .Text ,
	                 OutwardDate=txtOutwardDate .Text ,
	                 InwardDate = txtInwardDate .Text ,
	                 Workcompletion =txtWorkcompletion .Text ,
	                 Notes=txtNotes .Text,
                     billuplod =lbl_filepath1 .Text ,
                     CreateID = SessionUtilities.Empid,
                     WorkStatus=RADWorkStatus.SelectedItem.Text 


                };

               

                _isInserted = objL.Add_LabDetails(objLab);

              

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Lab";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Labid = 0;
                    lblMessage.Text = "Lab Added Successfully";
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
            getAllLabs();
        }

        public void Clear()
        {
            CleartextBoxes(this);
            BindPatient();
            BindTypeOfwork();
        
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
            getAllLabs();
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Add.Visible = true;
            Edit.Visible = false;
            int ID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EditEnquiry")
            {
               
               

                Labid = ID;

                try
                {

                    DataTable dt = objL.GetLabsSelect(ID);

                    txtLabname.Text = dt.Rows[0]["LabName"].ToString();
                    txtToothNo.Text = dt.Rows[0]["ToothNo"].ToString();
                    txtOutwardDate.Text = dt.Rows[0]["OutwardDate"].ToString();
                    txtInwardDate.Text = dt.Rows[0]["InwardDate"].ToString();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString();
                    txtWorkcompletion.Text = dt.Rows[0]["Workcompletion"].ToString();
                    BindPatient();

                    ddlpatient.SelectedValue = dt.Rows[0]["patientid"].ToString();
                    BindTypeOfwork();

                    ddlTypeOfwork.SelectedValue = dt.Rows[0]["TypeOfworkId"].ToString();
                   

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (e.CommandName == "SelectTeb")
            {
                DataTable dt = objL.GetLabsSelect(ID);
                Labid = ID;
                txtLabname.Text = dt.Rows[0]["LabName"].ToString();
                txtToothNo.Text = dt.Rows[0]["ToothNo"].ToString();
                BindPatient();

                ddlpatient.SelectedValue = dt.Rows[0]["patientid"].ToString();
                BindTypeOfwork();

                ddlTypeOfwork.SelectedValue = dt.Rows[0]["TypeOfworkId"].ToString();

            }
            
        }

        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objL.DeleteLab(ID);
                if (_isDeleted != -1)
                {

                    lblMessage.Text = "Clinic Deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    //  Response.Redirect("EnquiryDetails.aspx");
                    btSearch_Click(sender, e);
                    getAllLabs();
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

                if (txtSearch.Text != "")
                {
                    search += "LabName like '%" + txtSearch.Text + "%'";
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
                    if (!System.IO.Directory.Exists(@"~\BajajFinanceDoc"))
                    {
                        try
                        {



                            //int imgID = objHeandle.HandlmaxID(Convert.ToInt32(ddlBrand.SelectedValue));

                            //int AddImageiD = imgID + 1;

                            string Imgname = txtLabname.Text + ddlTypeOfwork.SelectedItem.Text + ddlpatient.SelectedValue;

                            string path = Server.MapPath(@"~\BajajFinanceDoc\");
                            System.IO.Directory.CreateDirectory(path);
                            FuImage1.SaveAs(path + @"\" + txtLabname.Text + ddlTypeOfwork.SelectedItem.Text + ddlpatient.SelectedValue + ext);

                            ImagePhoto1.ImageUrl = @"~\BajajFinanceDoc\" + txtLabname.Text + ddlTypeOfwork.SelectedItem.Text + ddlpatient.SelectedValue + ext;
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

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblID = (Label)e.Row.FindControl("lblID");
                Label lblWorkcompletion = (Label)e.Row.FindControl("lblWorkcompletion");
                Label lblWorkStatus = (Label)e.Row.FindControl("lblWorkStatus");


                
                DataTable dt = objL.GetLabsDetails(Convert.ToInt32(lblID.Text));

                if (dt != null && dt.Rows.Count > 0)
                {
                    lblWorkcompletion.Text = dt.Rows[0]["Workcompletion"].ToString();
                    lblWorkStatus.Text = dt.Rows[0]["WorkStatus"].ToString();

                    
                }
                else
                {

                    lblWorkcompletion.Text = "NA";

                }

           }
        }
    }
}