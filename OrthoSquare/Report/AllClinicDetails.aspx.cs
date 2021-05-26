using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Text;

namespace OrthoSquare.Report
{
    public partial class AllClinicDetails : System.Web.UI.Page
    {

        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Clinic objclinic = new BAL_Clinic();

        int Cid = 0;
        string FromDate = "", Todate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bindddlclinic();
                txtFromEnquiryDate.Text = (Convert.ToDateTime(System.DateTime.Now)).ToString("dd-MM-yyyy");
                txtToEnquiryDate.Text = (Convert.ToDateTime(System.DateTime.Now)).ToString("dd-MM-yyyy");
                biendConsultation();
                biendAppointments();
                biendEnquiry();
                biendFollowup();
                biendExpenseMaster();
                biendInvoiceMaster();
            }
        }

        public void Bindddlclinic()
        {

            DataTable dt;
            if (SessionUtilities.RoleID == 3)
            {
                dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);
            }
            else if (SessionUtilities.RoleID == 1)
            { // dt = objclinic.GetAllClinicDetaisNew(SessionUtilities.Empid);
                dt = objclinic.GetAllClinicDetais();
            }
            else
            {
                dt = objclinic.GetAllClinicDetais();

            }
            ddlClinic.DataSource = dt;

            // ddlclinic.DataSource = objcommon.clinicMaster();
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataBind();

            ddlClinic.Items.Insert(0, new ListItem("--- Select ---", "0"));


        }

        protected void ddlClinic_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindDocter(Convert.ToInt32(ddlClinic.SelectedValue));
           
        }

        public void BindDocter(int Cid)
        {
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDoctors.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);

            }
            else
            {
                ddlDoctors.DataSource = objcommon.DoctersMasterNewENQ11(Cid, SessionUtilities.RoleID);

            }

            ddlDoctors.DataTextField = "FirstName";
            ddlDoctors.DataValueField = "DoctorID";
            ddlDoctors.DataBind();
            ddlDoctors.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void biendConsultation()
        {

            DataTable dt = objcommon.clinicVSConsultation(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue),ddlDoctors .SelectedValue);
          
                gvShowConsultation.DataSource = dt;
                gvShowConsultation.DataBind();
           
                //gvShowConsultation.DataSource = null;
                //gvShowConsultation.DataBind();
           


        }

        protected void gvShowConsultation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShowConsultation.PageIndex = e.NewPageIndex;

            biendConsultation();
        }
        public void biendAppointments()
        {

            DataTable dt = objcommon.clinicVSAppointments( txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue),ddlDoctors.SelectedValue);
            

                GridAppoinment.DataSource = dt;
                GridAppoinment.DataBind();
           
        }

        protected void GridAppoinment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridAppoinment.PageIndex = e.NewPageIndex;

            biendAppointments();
        }


        public void biendEnquiry()
        {

            DataTable dt = objcommon.clinicVSEnquiry(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue),ddlDoctors.SelectedValue);
           
                GridViewEnquiry.DataSource = dt;
                GridViewEnquiry.DataBind();
          
        }

        protected void GridViewEnquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEnquiry.PageIndex = e.NewPageIndex;

            biendEnquiry();
        }

        public void biendFollowup()
        {

            DataTable dt = objcommon.clinicVSFollowup(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue),ddlDoctors.SelectedValue);
           
                GridViewFollowup.DataSource = dt;
                GridViewFollowup.DataBind();
           
        }

        protected void GridViewFollowup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFollowup.PageIndex = e.NewPageIndex;

            biendFollowup();
        }


        public void biendExpenseMaster()
        {

            DataTable dt = objcommon.clinicVSExpenseMaster(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue),ddlDoctors.SelectedValue);
           
                GridViewExpenseMaster.DataSource = dt;
                GridViewExpenseMaster.DataBind();
           
        }

        protected void GridViewExpenseMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewExpenseMaster.PageIndex = e.NewPageIndex;

            biendExpenseMaster();
        }


        public void biendInvoiceMaster()
        {

            DataTable dt = objcommon.clinicVSInvoiceMaster(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue),ddlDoctors.SelectedValue);
            
                GridViewInvoiceMaster.DataSource = dt;
                GridViewInvoiceMaster.DataBind();
           

        }

        protected void GridViewInvoiceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewInvoiceMaster.PageIndex = e.NewPageIndex;

            biendInvoiceMaster();
        }



        protected void btSearch_Click(object sender, EventArgs e)
        {
            biendAppointments();
            biendConsultation();
            biendEnquiry();
            biendFollowup();
            biendExpenseMaster();
            biendInvoiceMaster();
        }

     }
}