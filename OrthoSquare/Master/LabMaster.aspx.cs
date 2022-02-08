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
using System.Data.SqlClient;
using System.Configuration;

namespace OrthoSquare.Master
{
    public partial class LabMaster : System.Web.UI.Page
    {
        BAL_LabsDetails objL = new BAL_LabsDetails();
        clsCommonMasters objcomm = new clsCommonMasters();
        BAL_Patient objp = new BAL_Patient();
        public static DataTable AllData = new DataTable();

        string lID = "";
        int Cid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (SessionUtilities.RoleID == 1)
                {
                    Cid = SessionUtilities.Empid;

                }

                getAllLabs(Cid);
                BindPatient();
                BindGettooth();
                BindTypeOfwork();
            }

        }

        public void getAllLabs(int Cid)
        {

            AllData = objL.GetLabs(Cid);
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        public void BindGettooth()
        {
            DataTable dt = objcomm.Gettooth();


            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataTextField = "toothNo";
            CheckBoxList1.DataValueField = "toothID";
            CheckBoxList1.DataBind();


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
            //ddlpatient.DataSource = objp.GetPatientlist();
            //ddlpatient.DataTextField = "Fname";
            //ddlpatient.DataValueField = "patientid";
            //ddlpatient.DataBind();

            //ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));
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



        private long PatientId
        {
            get
            {
                if (ViewState["PatientId"] != null)
                {
                    return (long)ViewState["PatientId"];
                }
                return 0;
            }
            set
            {
                ViewState["PatientId"] = value;
            }
        }
        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;
                string OutwardDate = "", InwardDate = "";

                if (txtInwardDate.Text == "")
                {
                    InwardDate = "01-01-1990";
                }
                else
                {
                    InwardDate = txtInwardDate.Text;
                }

                if (txtInwardDate.Text == "")
                {
                    OutwardDate = "01-01-1990";
                }
                else
                {
                    OutwardDate = txtOutwardDate.Text;
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


                LabDetails objLab = new LabDetails()
                {

                    Labid = Labid,
                    patientid = Convert.ToInt32(PatientId),
                    TypeOfworkId = Convert.ToInt32(ddlTypeOfwork.SelectedValue),
                    LabName = txtLabname.Text,
                    ToothNo = lID,
                    OutwardDate = OutwardDate,
                    InwardDate = InwardDate,
                    Workcompletion = txtWorkcompletion.Text,
                    Notes = txtNotes.Text,
                    billuplod = lbl_filepath1.Text,
                    CreateID = SessionUtilities.Empid,
                    WorkStatus = RADWorkStatus.SelectedItem.Text


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
                    lblMessage.Text = "Lab details added successfully";
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

            if (SessionUtilities.RoleID == 1)
            {
                Cid = SessionUtilities.Empid;

            }
            getAllLabs(Cid);
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
            if (SessionUtilities.RoleID == 1)
            {
                Cid = SessionUtilities.Empid;

            }
            getAllLabs(Cid);
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (e.CommandName == "EditEnquiry")
            {
                Add.Visible = true;
                Edit.Visible = false;
                int ID = Convert.ToInt32(e.CommandArgument);

                Labid = ID;

                try
                {

                    DataTable dt = objL.GetLabsSelect(ID);

                    txtLabname.Text = dt.Rows[0]["LabName"].ToString();
                    TextBox1.Text = dt.Rows[0]["ToothNo"].ToString();
                    txtOutwardDate.Text = dt.Rows[0]["OutwardDate"].ToString();
                    txtInwardDate.Text = dt.Rows[0]["InwardDate"].ToString();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString();
                    txtWorkcompletion.Text = dt.Rows[0]["Workcompletion"].ToString();
                    BindPatient();

                  //  ddlpatient.SelectedValue = dt.Rows[0]["patientid"].ToString();
                    txtPatient.Text = dt.Rows[0]["patientid"].ToString();
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
                string toothName = "";
                Add.Visible = true;
                Edit.Visible = false;
                int ID = Convert.ToInt32(e.CommandArgument);
                DataTable dt = objL.GetLabsSelect(ID);
                Labid = ID;
                txtLabname.Text = dt.Rows[0]["LabName"].ToString();



                DataTable dt1 = objcomm.GettoothDetails(dt.Rows[0]["ToothNo"].ToString());

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        toothName += dt1.Rows[i]["toothNo"] + ",";

                    }
                    TextBox1.Text = toothName;
                }



                //  TextBox1.Text = dt.Rows[0]["ToothNo"].ToString();
                BindPatient();

               txtPatient.Text= dt.Rows[0]["patientid"].ToString();
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
                    if (SessionUtilities.RoleID == 1)
                    {
                        Cid = SessionUtilities.Empid;

                    }
                    getAllLabs(Cid);
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
                    search += "LabName like '%" + txtSearch.Text.Trim() + "%'";
                }
                if (txtFristNameS.Text != "")
                {
                    search += "FristName like '%" + txtFristNameS.Text.Trim() + "%'";
                }
                if (txtLastNameS.Text != "")
                {
                    search += "LastName like '%" + txtLastNameS.Text.Trim() + "%'";
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

                            string Imgname = txtLabname.Text + ddlTypeOfwork.SelectedItem.Text + txtPatient.Text;

                            string path = Server.MapPath(@"~\BajajFinanceDoc\");
                            System.IO.Directory.CreateDirectory(path);
                            FuImage1.SaveAs(path + @"\" + txtLabname.Text + ddlTypeOfwork.SelectedItem.Text + txtPatient.Text + ext);

                            ImagePhoto1.ImageUrl = @"~\BajajFinanceDoc\" + txtLabname.Text + ddlTypeOfwork.SelectedItem.Text + txtPatient.Text + ext;
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
        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string toothName = "";
                Label lblID = (Label)e.Row.FindControl("lblID");
                Label lblWorkcompletion = (Label)e.Row.FindControl("lblWorkcompletion");
                Label lblWorkStatus = (Label)e.Row.FindControl("lblWorkStatus");
                Label lblOutwardDate = (Label)e.Row.FindControl("lblOutwardDate");
                Label lblInwardDate = (Label)e.Row.FindControl("lblInwardDate");
                Label lblToothNo = (Label)e.Row.FindControl("lblToothNo");



                DataTable dt = objL.GetLabsDetails(Convert.ToInt32(lblID.Text));


                DataTable dt1 = objcomm.GettoothDetails(lblToothNo.Text.Trim());

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        toothName += dt1.Rows[i]["toothNo"] + ",";

                    }
                    lblToothNo.Text = toothName;
                }



                if (dt != null && dt.Rows.Count > 0)
                {
                    lblWorkcompletion.Text = dt.Rows[0]["Workcompletion"].ToString();
                    lblWorkStatus.Text = dt.Rows[0]["WorkStatus"].ToString();

                }
                else
                {
                    lblWorkcompletion.Text = "NA";

                }

                if (lblOutwardDate.Text == "1990-01-01")
                {

                    lblOutwardDate.Text = "";
                }


                if (lblInwardDate.Text == "1990-01-01")
                {

                    lblInwardDate.Text = "";
                }

            }
        }

        protected void txtPatient_TextChanged(object sender, EventArgs e)
        {

            DataTable dt = objp.NewGetPatientlistSearch(txtPatient.Text);
            PatientId = Convert.ToInt32(dt.Rows[0]["patientid"].ToString());

        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    int DoctorID = 0, ClinicId = 0; ;
                    int RoleId = Convert.ToInt32(HttpContext.Current.Session["RoleID"]);
                    DoctorID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                    ClinicId = Convert.ToInt32(HttpContext.Current.Session["UserID"]);




                    cmd.CommandText = " Select *,P.FristName+' '+ isnull(p.LastName,'')  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1 ";
                    cmd.CommandText += "and  P.FristName +' ' + P.LastName like '%" + prefixText + "%' ";
                    cmd.CommandText += "  order by FristName ASC";



                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["Fname"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }


    }
}