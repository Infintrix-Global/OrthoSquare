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
using System.Web.UI.HtmlControls;

namespace OrthoSquare.Doctor
{
    public partial class ViewConsultation : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        public static DataTable AllData1 = new DataTable();
        public static DataTable AllData2 = new DataTable();
        public static DataTable AllData3 = new DataTable();
        public static DataTable AllData4 = new DataTable();
        BAL_Appointment ojbApp = new BAL_Appointment();
        BAL_Patient objPatient = new BAL_Patient();
        BAL_ConsultationAddTreatment objCT = new BAL_ConsultationAddTreatment();
        BAL_Treatment objT = new BAL_Treatment();
        BAL_Patient objp = new BAL_Patient();
        BAL_Clinic objc = new BAL_Clinic();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_LabsDetails objL = new BAL_LabsDetails();
        string lID = "";
        string ToothNo1 = "";
        string TreatmentID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                bindClinic();
                if (SessionUtilities.RoleID == 2)
                {
                    Cid.Visible = true;
                }
              getAllDetails();

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

        public void getAllDetails()
        {

          //  DataTable AllData = objPatient.GetPatientlist();

            int Cid = 0;
            int Did = 0;

            if(SessionUtilities .RoleID ==1)
            {
                Cid = SessionUtilities .Empid;
                Did = 0;

            }
            else if (SessionUtilities.RoleID == 3)
            {

                Cid = 0;
                Did = SessionUtilities.Empid;
            }
            else
            {

                Cid = Convert .ToInt32(ddlClinic.SelectedValue );
                Did = 0;
            }



            AllData = ojbApp.GetAlltodayConsultationViewConnew(Did, Cid,txtName.Text .Trim (),txtPatientNo .Text .Trim ());
            //  AllData = ojbApp.GetAllviewConsultation();
            if (AllData != null && AllData.Rows.Count > 0)
            {
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
        }
        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllDetails();
        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getAllDetails();
                //string search = "";


                //if (txtName.Text != "")
                //{
                //  //  search += "FristName like '%" + txtName.Text + "%'";
                //}
                //else if (txtPatientNo.Text != "")
                //{
                //    search += "PatientCode ='" + txtPatientNo.Text + "'";
                //}
                //else if (ddlClinic.SelectedValue != "0")
                //{

                //     search += "ClinicID ='" +ddlClinic.SelectedValue  + "'";
                //}

                //DataRow[] dtSearch1 = AllData.Select(search);
                //if (dtSearch1.Count() > 0)
                //{
                //    DataTable dtSearch = dtSearch1.CopyToDataTable();
                //    gvShow.DataSource = dtSearch;
                //    gvShow.DataBind();
                //}
                //else
                //{
                //    DataTable dt = new DataTable();
                //    gvShow.DataSource = dt;
                //    gvShow.DataBind();
                //}



            }
            catch (Exception ex)
            {
            }
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Pselect")
            {
                string search = "";
                int pid = Convert.ToInt32(e.CommandArgument);
                patientTm(pid, 1);
                BindComplaints(pid);
                BiendPreviousConsultation(pid);
                getMedicalHistory(pid);
                getAllLabs(pid);
                getAllGallery(pid);
                getAllTreatmentPlan(pid);
                getAllMedicines(pid);
                Add.Visible = true;
                Edit.Visible = false;
            }
        }
        public void patientTm(int pid, int id)
        {
            string search = "";

            DataTable dt = objPatient.GetPatient(pid);

            if (dt.Rows.Count > 0)
            {


                lblPname.Text = dt.Rows[0]["FristName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
               lblPmobialNo.Text = dt.Rows[0]["Mobile"].ToString();

                 
                if (dt.Rows[0]["ProfileImage"].ToString() == "")
                {
                    Image1.ImageUrl = "../Images/no-photo.jpg";
                }
                else
                {
                    Image1.ImageUrl = "~/EmployeeProfile/" + dt.Rows[0]["ProfileImage"].ToString();
                }
            }


        }

        public void BindComplaints(int patientid)
        {

            DataTable dt = objcommon.ComplaintsDetils(Convert.ToInt32(patientid));

            if (dt != null && dt.Rows.Count > 0)
            {
                GirdComplaints.DataSource = dt;
                GirdComplaints.DataBind();
            }
        
        }
        public void BiendPreviousConsultation(long Pid)
        {

            AllData4 = ojbApp.GetPreviousConsultationDetila(Pid, 1);
            if (AllData4 != null && AllData4.Rows.Count > 0)
            {
                GridPreviousConsultation.DataSource = AllData4;
                GridPreviousConsultation.DataBind();
            }
        }

        public void getMedicalHistory(long Pid1)
        {
            AllData2 = objp.GetMedicalHistoryDetails(Pid1);
            if (AllData2 != null && AllData2.Rows.Count > 0)
            {
                GridMedicalHistory.DataSource = AllData2;
                GridMedicalHistory.DataBind();

            }
           
        }

        public void getAllLabs(int Pid)
        {

          DataTable AllDataLB = objL.GetLabsViewDetsils(Pid);

          if (AllDataLB != null && AllDataLB.Rows.Count > 0)
            {
                GridLab.DataSource = AllDataLB;
                GridLab.DataBind();
            }

        }

        public void getAllGallery(int Pid)
        {

         DataTable AllDataGL = objCT.GetPTGallery(Pid);
         if (AllDataGL != null && AllDataGL.Rows.Count > 0)
         {
             grdProducts1.DataSource = AllDataGL;
             grdProducts1.DataBind();
         }
        }

        public void getAllTreatmentPlan(int Pid)
        {

         DataTable AllDataTPP = objCT.GetPTTreatmentPlan(Pid);
         if (AllDataTPP != null && AllDataTPP.Rows.Count > 0)
         {
             GridTreatmentPlan.DataSource = AllDataTPP;
             GridTreatmentPlan.DataBind();

         }
            
        }

        public void getAllMedicines(int Pid)
        {

          DataTable   AllDataMP = objCT.GetMedicinesName(Pid);
          if (AllDataMP != null && AllDataMP.Rows.Count > 0)
          {
              GridViewMedicines.DataSource = AllDataMP;
              GridViewMedicines.DataBind();
          }
        }
    }
}