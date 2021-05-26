using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using System.Configuration;
namespace OrthoSquare.Master
{
    public partial class AddAdvertisment : System.Web.UI.Page
    {
        BAL_Advertisment objAd = new BAL_Advertisment();
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getAllAdvertis();
            }
        }



        private long Aid
        {
            get
            {
                if (ViewState["Aid"] != null)
                {
                    return (long)ViewState["Aid"];
                }
                return 0;
            }
            set
            {
                ViewState["Aid"] = value;
            }
        }

        public void getAllAdvertis()
        {
            AllData = objAd.GetAdvertisment(0);
            if (AllData != null && AllData.Rows.Count > 0)
            {
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;

  
                _isInserted = objAd.Add_Advertisment(Aid, txtTitle.Text, lbl_filepath1.Text);



                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Advertisment";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Aid = 0;
                    lblMessage.Text = "Advertisment added successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                   // Clear();
                    txtTitle.Text="";
                    ImagePhoto1.ImageUrl = "~/Images/no-photo.jpg";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
            getAllAdvertis();
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Add.Visible = true;
            Edit.Visible = false;

            if (e.CommandName == "EditAd")
            {

                int ID = Convert.ToInt32(e.CommandArgument);

                Aid = ID;

                try
                {
                  
                    DataTable dt = objAd.GetAdvertisment(ID);

                    txtTitle.Text = dt.Rows[0]["Title"].ToString();
                    ImagePhoto1.ImageUrl = dt.Rows[0]["AdImage"].ToString();

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

                int _isDeleted = objAd.DeleteAdvertisment(ID);
                if (_isDeleted != -1)
                {
                    Edit.Visible = true;
                    Add.Visible = false;
                    getAllAdvertis();
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
        protected void btBack_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;

            txtTitle.Text = "";
            ImagePhoto1.ImageUrl = "~/Images/no-photo.jpg";
            lblMessage.Text = "";
            getAllAdvertis();
        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";

                if (txtSearch.Text != "")
                {
                    search += "Title like '%" + txtSearch.Text + "%'";
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
                throw ex;
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
                    string ServerResponse = ConfigurationManager.AppSettings["FileAdPath"].ToString();

                    filename = Server.MapPath(FuImage1.FileName);
                    newfile = FuImage1.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\AdvertismentImage"))
                    {
                        try
                        {


                            //string Imgname = txtTitle.Text;
                            string Imgname = ServerResponse + txtTitle.Text;
                        
                            string path = Server.MapPath(@"~\AdvertismentImage\");
                            System.IO.Directory.CreateDirectory(path);
                            FuImage1.SaveAs(path + @"\" + txtTitle.Text  + ext);

                            ImagePhoto1.ImageUrl = @"~\AdvertismentImage\" + txtTitle.Text + ext;
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
    }


}