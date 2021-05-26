using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using OrthoSquare.Utility;
using System.IO;
using System.Net;

namespace OrthoSquare.Help
{
    public partial class ReportIssueNew : System.Web.UI.Page
    {
        BasePage objBasePage = new BasePage();
        BAL_Clinic objClinic = new BAL_Clinic();
        clsCommonMasters objCommon = new clsCommonMasters();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIssuetype();
                Bindstatus();
                BindGridIssue();
                if (SessionUtilities.RoleID.ToString() == "1")
                    btnAddNew.Visible = false;
            }
        }

        protected void btnissue_Click(object sender, EventArgs e)
        {


            objClinic.AddIssue(SessionUtilities.UserID,ddlIssueType .SelectedItem .Text ,txtTitle .Text  ,txtissue.Text,lblAttachment .Text );
            BindGridIssue();
            Edit.Visible = true;
            Add.Visible = false;
            SendHelpMail(ddlIssueType.SelectedItem.Text, txtTitle.Text.Trim(), txtissue.Text.Trim());


            txtissue.Text = "";
        
        }

        public void Bindstatus()
        {
            DataTable dt = objCommon.statusMasterInfo();
            ddlStateus.DataSource = dt;
            ddlStateus.DataTextField = "statusName";
            ddlStateus.DataValueField = "StatusId";
            ddlStateus.DataBind();

            ddlStateus.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindIssuetype()
        {
            DataTable dt= objCommon.IssuetypeMasterInfo();
            ddlIssueType.DataSource = dt;
            ddlIssueType.DataTextField = "IssuetypeName";
            ddlIssueType.DataValueField = "Issuetypeid";
            ddlIssueType.DataBind();

            ddlIssueType.Items.Insert(0, new ListItem("--- Select ---", "0"));


            ddlIssueTypeSearch.DataSource = dt;
            ddlIssueTypeSearch.DataTextField = "IssuetypeName";
            ddlIssueTypeSearch.DataValueField = "Issuetypeid";
            ddlIssueTypeSearch.DataBind();

            ddlIssueTypeSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindGridIssue()
        {
            int EMPID = 0;

            DataTable AllData = new DataTable();

           

            AllData = objCommon.GetIssueList(SessionUtilities.UserID, ddlIssueTypeSearch .SelectedItem .Text ,ddlStateus .SelectedItem .Text ,txtFromDate.Text,txtToDate .Text );
            GridIssue.DataSource = AllData;
            GridIssue.DataBind();
        }

        protected void GridIssue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridIssue.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
       
            Add.Visible = true;
        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {


                BindGridIssue();

               
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAttachment_Click(object sender, EventArgs e)
        {
            UploadAttachment();
        }

        public void UploadAttachment()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FileUploadAttachment.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FileUploadAttachment.Focus();
            }
        
            string aa = FileUploadAttachment.FileName;
            string ext = System.IO.Path.GetExtension(FileUploadAttachment.PostedFile.FileName).ToLower();
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

                if (FileUploadAttachment.HasFile)
                {

                    filename = Server.MapPath(FileUploadAttachment.FileName);
                    newfile = FileUploadAttachment.PostedFile.FileName;
                    //                filecontent = System.IO.File.ReadAllText(filename);
                    FileInfo fi = new FileInfo(newfile);

                    // check folder exist or not
                    if (!System.IO.Directory.Exists(@"~\Documents"))
                    {
                        try
                        {

                          //  int Dno1 = objCommon.GetDoctorMax_No();

                            string Imgname = "File_"+ txtTitle.Text;

                            string path = Server.MapPath(@"~\Documents\");
                            System.IO.Directory.CreateDirectory(path);
                            FileUploadAttachment.SaveAs(path + @"\" + "File_" + txtTitle.Text + ext);

                            ImageAttachment.ImageUrl = @"~\Documents\" + "File_"+ txtTitle.Text + ext;
                            ImageAttachment.Visible = true;

                            lblAttachment.Text = Imgname + ext;

                          //  IdentityPolicyImageUrl = Imgname + ext;


                        }
                        catch (Exception ex)
                        {
                            lblAttachment.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }

        protected void GridIssue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewAttachment")
            {
                string str = e.CommandArgument.ToString();
                DownloadFile(str, str);
            }
        }

        protected void DownloadFile(string DownloadFileName, string OutgoingFileName)
        {
            string path = MapPath("~/") + "\\Documents\\" + DownloadFileName;
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


        protected void SendHelpMail(string IssueType, string Title, string Details)
        {
            
            var fromAddress = "orthomail885@gmail.com";
        
            var toAddress = "mehul.rana@infintrixglobal.com,ankit.shah@infintrixglobal.com";

            const string fromPassword = "Ortho@1234";
         
            string subject = "OrthoSquare Issue";
            string body = "Dear Sir," + "\n";
            body += "OrthoSquare Issue Details:" + "\n\n";
            body += "Issue Type : " + IssueType + " " + "\n";
            body += "Title : " + Title + " " + "\n";
            body += "Issue Details : " + Details + " " + "\n";
            body += "Thank you!" + "\n";
            body += "Warm Regards," + "\n";

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                //smtp.Port = 465;
                smtp.EnableSsl = true;

                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 50000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

    }
}