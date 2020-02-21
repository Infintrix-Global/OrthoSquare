using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
namespace OrthoSquare.Dashboard
{
    public partial class BranchDashboard : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        public static DataTable AllData = new DataTable();
        BAL_EnquirySource objES = new BAL_EnquirySource();
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        BAL_Appointment objApp = new BAL_Appointment();
        BAL_ConsultationAddTreatment objCT = new BAL_ConsultationAddTreatment();

           BAL_Patient objp = new BAL_Patient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                FollowupNo();
                EnqNo();
                DocterNo();
                PatientNo();
                bindpatient();
                // getAllGallery();
                //  bindDoctorMaster();
               TotalInvoice();
               TotalExpense();
                getAllEnquiry();
                TotalTodayAppoimnet();

                GridTodayAppoinmentget();

            }
        }


        public void TotalTodayAppoimnet()
        {

            int Eno = objcommon.GetTotalNoofAppoinmentNo(SessionUtilities.Empid);
            lblTotalTodayAppoiment.Text = Eno.ToString();
        }

        public void FollowupNo()
        {

            int Eno = objcommon.GetFollowupCountNoNew(SessionUtilities.Empid);
            lblFollwupCOunt.Text =  Eno.ToString();
        }

        public void EnqNo()
        {

            int Eno = objcommon.GetEnquiryCountNoNew(SessionUtilities .Empid);
            lblEnq.Text = Eno.ToString();
        }


        public void TotalInvoice()
        {

            decimal Totalinv = objcommon.GetTotalPaidAmount(SessionUtilities.Empid);

            if (Totalinv != 0)
            {
                totalinvoice.Text = Totalinv.ToString("#,##0.00"); 
            }
            else
            {

                totalinvoice.Text = "0.00";
            }
        }



        public void TotalExpense()
        {

            decimal  TotalExp = objcommon.GetTotalExpense(SessionUtilities.Empid);

            if (TotalExp != 0)
            {
                lblExp.Text = TotalExp.ToString("#,##0.00"); 
            }
            else
            {

                lblExp.Text = "0.00";
            }
        }


        public void DocterNo()
        
        {

            int Eno = objcommon.GetDoctorMax_NoNew(SessionUtilities.Empid);
            lblDoctors.Text = Eno.ToString();
        }

        public void PatientNo()
        {

            int Eno = objcommon.GetPatientCount_NoNew(SessionUtilities.Empid);
            lblPatient.Text = Eno.ToString();
        }

        public void bindpatient()
        {

            DataTable dt = objp.GetPatientlist();



            if (dt != null && dt.Rows.Count > 0)
            {
                ddlpatient.DataSource = dt;
                ddlpatient.DataTextField = "FristName";
                ddlpatient.DataValueField = "patientid";
                ddlpatient.DataBind();
            }
            ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }
        public void getAllEnquiry()
        {

            int Cid = 0;

            if (SessionUtilities.RoleID == 2)
            {

                Cid = 0;
            }
            else
            {

                Cid = SessionUtilities.Empid;

            }



            AllData = objENQ.GetAllEnquiry(Cid);

            if (AllData != null && AllData.Rows.Count > 0)
            {
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }

        }

        public void getAllGallery()
        {

            AllData = objCT.GetPTGallery(Convert .ToInt32 (ddlpatient.SelectedValue ));
            grdProducts.DataSource = AllData;
            grdProducts.DataBind();

        }


        public void GridTodayAppoinmentget()
        {

            int Cid = 0;

            if (SessionUtilities.RoleID == 2)
            {

                Cid = 0;
            }
            else
            {

                Cid = SessionUtilities.Empid;

            }


            AllData = objApp.GetAlltodayAppoinmentNew(Cid);
            if (AllData != null && AllData.Rows.Count > 0)
            {
               
                GridAppoinment.DataSource = AllData;
                GridAppoinment.DataBind();
            }
        }


        protected void GridAppoinment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Aid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Approve")
            {

                int _isDeleted = objApp.GetApprove(Aid);
               // GridTodayAppoinmentget();
                Response.Redirect("BranchDashboard.aspx");
             
            }
            if (e.CommandName == "Reject")
            {


                int _isDeleted = objApp.GetReject(Aid);
                Response.Redirect("BranchDashboard.aspx");
            }
        }



        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllEnquiry();
        }


        protected void GridAppoinment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblstatus = (Label)e.Row.FindControl("lblstatus");

                if (lblstatus.Text == "1")
                {
                    e.Row.Attributes["style"] = "background-color: #28b779";
                }
               

            }
        }
        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objENQ.DeleteEnquiry(ID);
                if (_isDeleted != -1)
                {

                    //lblMessage.Text = "Enquiry Deleted successfully.";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    //Response.Redirect("EnquiryDetails.aspx");
                   // btSearch_Click(sender, e);
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
           
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/fullcalendar/demos/NewAppointmentClinic.aspx");
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Master/AppointmentList.aspx");
        }

        protected void ddlpatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllGallery();
        }

    }
}