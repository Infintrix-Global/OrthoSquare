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

namespace OrthoSquare.Report
{
    public partial class DocterCollectionReport : System.Web.UI.Page
    {
        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        BAL_Expense objExp = new BAL_Expense();
        clsCommonMasters objcommon = new clsCommonMasters();

        decimal sumFooterValue = 0;
        decimal sumFooterPendingValue = 0;
        decimal Total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {




                if (SessionUtilities.RoleID == 1)
                {
                    bindClinic();
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    bindDoctorMaster(SessionUtilities.Empid);
                   
                    getAllCollection();


                }
                else
                {
                    bindClinic();
                    bindDoctorMasterNew();
                    //  ddlClinic.Enabled = false;
                    //   bindDoctorMaster(SessionUtilities.Empid);
                    getAllCollection();

                }
            }
        }



        public void bindClinic()
        {

            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);
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

        }


        public void bindDoctorMasterNew()
        {


            if (SessionUtilities.RoleID == 3)
            {

                ddlDocter.DataSource = objcommon.DoctersMaster123(SessionUtilities.Empid, SessionUtilities.RoleID);


            }
          
            else
            {
                ddlDocter.DataSource = objcommon.DoctersMaster123(0, 3);

            }


            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "FirstName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }



        public void bindDoctorMaster(int Cid)
        {


            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDocter.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);
             

            }
            else
            {
                ddlDocter.DataSource = objcommon.DoctersMaster(Cid,3);
             
            }


            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "FirstName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
        }



        public void getAllCollection()
        {

            AllData = objExp.GetAllDocterCollectionReportNew1(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDocter.SelectedValue));

            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllCollection();

        }



        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            //   btSearch_Click(sender, e);
            getAllCollection();
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblPaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
                Label lblPendingAmount = (Label)e.Row.FindControl("lblPendingAmount");
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                Label lblDoctor = (Label)e.Row.FindControl("lblDoctor");
                Label lblClinicID = (Label)e.Row.FindControl("lblClinicID");
                Label lblIsDelete = (Label)e.Row.FindControl("lblIsDelete");


                //  Label lblDoctor = (Label)e.Row.FindControl("lblDoctor");
                //    Label lblClinicName = (Label)e.Row.FindControl("lblClinicName");

                DataTable dt =objExp.GetAllDocterCollectionReportNew11(Convert .ToInt32 (lblClinicID.Text ), Convert.ToInt32(lblDoctor.Text), txtSFromFollowDate.Text.Trim(), txtSToFollowDate.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblPaidAmount.Text = dt.Rows[0]["PaidAmount"].ToString();
                    lblPendingAmount.Text = dt.Rows[0]["PendingAmount"].ToString();
                    lblTotal.Text = dt.Rows[0]["Total"].ToString();
                }
                else
                {
                    lblPaidAmount.Text = "0";
                    lblPendingAmount.Text = "0";
                    lblTotal.Text = "0";



                }

                sumFooterValue += Convert.ToDecimal(lblPaidAmount.Text);
                sumFooterPendingValue += Convert.ToDecimal(lblPendingAmount.Text);
                Total+= Convert.ToDecimal(lblTotal.Text);

                if (lblTotal.Text == "0.00" && lblIsDelete.Text== "True")
                {
                    e.Row.Visible = false;

                }

            }

            // lblTotalTop.Text = sumFooterValue.ToString();
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblPaidAmountTotal = (Label)e.Row.FindControl("lblPaidAmountTotal");
                Label lblPendingAmountTotal = (Label)e.Row.FindControl("lblPendingAmountTotal");
                Label lblGTotla = (Label)e.Row.FindControl("lblGTotla");

                lblPaidAmountTotal.Text = sumFooterValue.ToString();
                lblPendingAmountTotal.Text = sumFooterPendingValue.ToString();
                lblGTotla.Text = Total.ToString();

               
            }
        }
    }
}