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


namespace OrthoSquare.Help
{
    public partial class ITsupport : System.Web.UI.Page
    {
        BAL_Clinic objClinic = new BAL_Clinic();
        clsCommonMasters objCommon = new clsCommonMasters();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIssuetype();
                Bindstatus();
                BindGridIssue();
            }
        }
        private long IdIT
        {
            get
            {
                if (ViewState["IdIT"] != null)
                {
                    return (long)ViewState["IdIT"];
                }
                return 0;
            }
            set
            {
                ViewState["IdIT"] = value;
            }
        }

      

        public void Bindstatus()
        {
            DataTable dt = objCommon.statusMasterInfo();
            ddlStatus.DataSource = dt;
            ddlStatus.DataTextField = "statusName";
            ddlStatus.DataValueField = "StatusId";
            ddlStatus.DataBind();

            ddlStatus.Items.Insert(0, new ListItem("--- Select ---", "0"));

            ddlSearchStateus.DataSource = dt;
            ddlSearchStateus.DataTextField = "statusName";
            ddlSearchStateus.DataValueField = "StatusId";
            ddlSearchStateus.DataBind();

            ddlSearchStateus.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindIssuetype()
        {
            DataTable dt = objCommon.IssuetypeMasterInfo();
            ddlIssueTypeSearch.DataSource = dt;
            ddlIssueTypeSearch.DataTextField = "IssuetypeName";
            ddlIssueTypeSearch.DataValueField = "Issuetypeid";
            ddlIssueTypeSearch.DataBind();

            ddlIssueTypeSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindGridIssue()
        {
            DataTable AllData = new DataTable();
            AllData = objCommon.GetIssueList(0, ddlIssueTypeSearch.SelectedItem.Text, ddlSearchStateus.SelectedItem.Text, txtFromDate.Text, txtToDate.Text);
            GridIssue.DataSource = AllData;
            GridIssue.DataBind();
        }


       

        protected void GridIssue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridIssue.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
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



        protected void GridIssue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewAttachment")
            {
                string str = e.CommandArgument.ToString();
                DownloadFile(str, str);
            }

            if (e.CommandName == "ITSelect")
            {
                Edit.Visible = false;
                Add.Visible = true;

                IdIT = Convert.ToInt32(e.CommandArgument);
            }

            if (e.CommandName == "delete1")
            {
             int   IDISS = Convert.ToInt32(e.CommandArgument);
                objClinic.DeleteIssue(IDISS);
                BindGridIssue();

               
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


        protected void btnissue_Click(object sender, EventArgs e)
        {
            objClinic.UpDateIssueComment(SessionUtilities.Empid,Convert .ToInt32(IdIT), ddlStatus.SelectedItem.Text, txtComment.Text.Trim());
            BindGridIssue();
            Edit.Visible = true;
            Add.Visible = false;
            txtComment.Text = "";
            Bindstatus();
        }

    }
}