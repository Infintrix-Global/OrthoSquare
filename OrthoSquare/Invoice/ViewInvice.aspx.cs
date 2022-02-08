using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;

namespace OrthoSquare.Invoice
{
    public partial class ViewInvice : System.Web.UI.Page
    {

        BAL_InvoiceDetails objinv = new BAL_InvoiceDetails();
        public static DataTable AllData = new DataTable();
        clsCommonMasters objcomm = new clsCommonMasters();
        BAL_Clinic objc = new BAL_Clinic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindClinic();
                if(SessionUtilities .RoleID ==1)
                {

                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindDocter(SessionUtilities.Empid);
                    getAllInvoice(Convert .ToInt32 (SessionUtilities.Empid), 0, "","");
                }
                else if (SessionUtilities .RoleID ==3)
                {
                    ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
                    getAllInvoice(0, Convert.ToInt32(SessionUtilities.Empid), "", "");
                }
                else
                {
                    ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

                    getAllInvoice(0, 0, "", "");
                }
               // ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
                

            }
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
                dt = objc.GetAllClinicDetaisNew(0);

            }
            ddlClinic.DataSource = dt;

            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindDocter(Convert.ToInt32(ddlClinic.SelectedValue));
        }
        public void BindDocter(int Cid)
        {
            DataTable dt=null ;
            ddlDoctor.DataSource = null;
            ddlDoctor.DataBind();
            //ddlDoctor.Items.Remove("--- Select ---");
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {
                dt= objcomm.DoctersMaster(Cid, SessionUtilities.RoleID);
                ddlDoctor.DataSource = dt;

            }
            else
            {
                dt=objcomm.DoctersMaster(Cid, SessionUtilities.RoleID);
                ddlDoctor.DataSource = dt;

            }

            ddlDoctor.DataTextField = "DoctorName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.Items.Remove(ddlDoctor.Items.FindByValue("0"));
            ddlDoctor.DataBind();
            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));

            

           
        }

        public void getAllInvoice(int Cid,int Did,string Search,string MNo)
        {

            AllData = objinv.GetAllInvoicDispaly(Cid, Did, Search, MNo, txtFromEnquiryDate.Text, txtToEnquiryDate.Text);
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;


            if (SessionUtilities.RoleID == 1)
            {
                getAllInvoice(Convert.ToInt32(SessionUtilities.Empid), 0, "", "");
            }
            else if (SessionUtilities.RoleID == 3)
            {
            
                getAllInvoice(0, Convert.ToInt32(SessionUtilities.Empid), "", "");
            }
            else
            {
                getAllInvoice(0, 0, "", "");
            }


          //  btSearch_Click(sender, e);
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "Viewinv")
            {
                int invCode = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Int32 rowind = gvRow.RowIndex;
                Label lblInvoiceCode = (Label)gvRow.FindControl("lblInvoiceCode");

                Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + invCode + "&Fid=" + lblInvoiceCode.Text + "&Back=" + 1);

            }

            if (e.CommandName == "delete1")
            {
            
                int invCode1 = Convert.ToInt32(e.CommandArgument);
                
                int I = objinv.Deleteinvoice(invCode1);
                getAllInvoice(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), txtSearch.Text, txtMobileNo.Text);


            }


        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
           getAllInvoice(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), txtSearch.Text, txtMobileNo.Text);
           
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
          // Edit.Visible = false;
          // .. Add.Visible = true;
        }
    }
}