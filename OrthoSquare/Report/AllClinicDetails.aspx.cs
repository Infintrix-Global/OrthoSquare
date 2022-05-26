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
        BAL_DoctorsDetails objDoc = new BAL_DoctorsDetails();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Clinic objclinic = new BAL_Clinic();

        int Cid = 0;
        string FromDate = "", Todate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindddlclinic();
                txtFromEnquiryDate.Text = (Convert.ToDateTime(System.DateTime.Now)).ToString("dd-MM-yyyy");
                txtToEnquiryDate.Text = (Convert.ToDateTime(System.DateTime.Now)).ToString("dd-MM-yyyy");
                if (SessionUtilities.RoleID != 3)
                {
                    biendConsultation();
                    biendAppointments();
                    biendEnquiry();
                    biendFollowup();
                    biendExpenseMaster();
                    biendInvoiceMaster();
                }
            }
        }

        public void Bindddlclinic()
        {

            DataTable dt;
            if (SessionUtilities.RoleID == 3)
            {
               // dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);

                dt = objcommon.GetSubAdminClinic(Convert.ToInt32(SessionUtilities.Empid));
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

            ddlDoctors.DataTextField = "DoctorName";
            ddlDoctors.DataValueField = "DoctorID";
            ddlDoctors.DataBind();
            ddlDoctors.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        private string ClinicID
        {
            get
            {
                if (Request.QueryString["ClinicID"] != null)
                {
                    return Request.QueryString["ClinicID"].ToString();
                }
                return "";
            }
            set
            {

            }
        }

        private String Clinic_ID
        {
            get
            {
                if (ViewState["Clinic_ID"] != null)
                {
                    return (String)ViewState["Clinic_ID"];
                }
                return "";
            }
            set
            {
                ViewState["Clinic_ID"] = value;
            }
        }

        public void SelectClinic()
        {
            DataTable dt111SP = objDoc.GetSubAdminClinicSelect(Convert.ToInt32(SessionUtilities.Empid));

            string Cid = "";

            if (dt111SP != null && dt111SP.Rows.Count > 0)
            {
                for (int j = 0; j < dt111SP.Rows.Count; j++)
                {

                    Cid +=  dt111SP.Rows[j]["ClinicID"].ToString() + ",";

                }

                if (Cid != "")
                {
                    Clinic_ID = Cid.Remove(Cid.Length - 1, 1);
                }
                else
                {
                    Clinic_ID = Cid;
                }
            }
            else
            {
                ClinicID = "";
            }

           
        }



        public void biendConsultation()
        {
            if(ddlClinic.SelectedValue=="0")
            {
                SelectClinic();
            }
            else
            {
                Clinic_ID = ddlClinic.SelectedValue;
            }

            DataTable dt = objcommon.clinicVSConsultation(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Clinic_ID, ddlDoctors.SelectedValue,SessionUtilities.RoleID);

            gvShowConsultation.DataSource = dt;
            gvShowConsultation.DataBind();
            lblConsultationCount.Text = dt.Rows.Count.ToString();
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

            DataTable dt = objcommon.clinicVSAppointments(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue), ddlDoctors.SelectedValue, SessionUtilities.RoleID);


            GridAppoinment.DataSource = dt;
            GridAppoinment.DataBind();

            lblAppointmentsCount.Text = dt.Rows.Count.ToString();
        }

        protected void GridAppoinment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridAppoinment.PageIndex = e.NewPageIndex;

            biendAppointments();
        }


        public void biendEnquiry()
        {

            DataTable dt = objcommon.clinicVSEnquiry(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue), ddlDoctors.SelectedValue, SessionUtilities.RoleID);

            GridViewEnquiry.DataSource = dt;
            GridViewEnquiry.DataBind();
            lblEnquiriesCount.Text = dt.Rows.Count.ToString();
        }

        protected void GridViewEnquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEnquiry.PageIndex = e.NewPageIndex;

            biendEnquiry();
        }

        public void biendFollowup()
        {

            DataTable dt = objcommon.clinicVSFollowup(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue), ddlDoctors.SelectedValue, SessionUtilities.RoleID);

            GridViewFollowup.DataSource = dt;
            GridViewFollowup.DataBind();
            lblFollowupCount.Text = dt.Rows.Count.ToString();
        }

        protected void GridViewFollowup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFollowup.PageIndex = e.NewPageIndex;

            biendFollowup();
        }


        public void biendExpenseMaster()
        {

            DataTable dt = objcommon.clinicVSExpenseMaster(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue), ddlDoctors.SelectedValue, SessionUtilities.RoleID);

            GridViewExpenseMaster.DataSource = dt;
            GridViewExpenseMaster.DataBind();
            if (dt.Rows.Count >= 0 && dt != null)
            {
                double Expense = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Expense += Convert.ToDouble(dt.Rows[i]["Amount"]);

                }

                lblExpenseTotal.Text = Expense.ToString("n2");
            }
            else
            {
                lblExpenseTotal.Text = "0.00";
            }
        }

        protected void GridViewExpenseMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewExpenseMaster.PageIndex = e.NewPageIndex;

            biendExpenseMaster();
        }


        public void biendInvoiceMaster()
        {
            double Invoice = 0;
            decimal TotalMedicinesAmount = objcommon.GetTotalMedicines(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim());
            lblMedicinesAmount.Text = TotalMedicinesAmount.ToString("n2");
            DataTable dt = objcommon.clinicVSInvoiceMaster(txtFromEnquiryDate.Text.Trim(), txtToEnquiryDate.Text.Trim(), Convert.ToInt32(ddlClinic.SelectedValue), ddlDoctors.SelectedValue, SessionUtilities.RoleID);
            if (dt.Rows.Count >= 0 && dt != null)
            {
                GridViewInvoiceMaster.DataSource = dt;
                GridViewInvoiceMaster.DataBind();
             
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Invoice += Convert.ToDouble(dt.Rows[i]["PaidAmount"]);

                }

                lblCollectionCount.Text = Invoice.ToString("n2");
            }
            else
            {
                lblCollectionCount.Text = "0.00";
            }

            lblCMtotal.Text =(Convert.ToDecimal(Invoice)+ TotalMedicinesAmount).ToString("n2");
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