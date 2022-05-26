using OrthoSquare.BAL_Classes;
using OrthoSquare.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace OrthoSquare.patient
{
    public partial class NewRegistrationPatient : System.Web.UI.Page
    {
        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        BAL_Patient objP = new BAL_Patient();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Finance objF = new BAL_Finance();
        decimal sumFooterValue = 0;
        decimal sumFooterPendingValue = 0;
        decimal Total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtSFromFollowDate.Text = Convert.ToDateTime(System.DateTime.Now).ToString("dd-MM-yyyy");
                txtSToFollowDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                if (SessionUtilities.RoleID == 1)
                {
                    bindClinic();
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();


                    getPatientReport();


                }
                else
                {
                    bindClinic();
               
                    DoctorId = 0;
                    getPatientReport();

                }
            }
        }

        private long DoctorId
        {
            get
            {
                if (ViewState["DoctorId"] != null)
                {
                    return (long)ViewState["DoctorId"];
                }
                return 0;
            }
            set
            {
                ViewState["DoctorId"] = value;
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
                if (DoctorId > 0)
                {
                    dt = objcommon.GetDoctorByClinic(Convert.ToInt32(DoctorId));
                }
                else
                {
                    dt = objc.GetAllClinicDetais();
                }


            }
            ddlClinic.DataSource = dt;

            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

      

      


        public void getPatientReport()
        {

            AllData = objP.GetPatientDetailsReport(txtSFromFollowDate.Text, txtSToFollowDate.Text, Convert.ToInt32(ddlClinic.SelectedValue),0, "1");
            if (AllData != null && AllData.Rows.Count > 0)
            {

                lblTotaCount.Text = AllData.Rows.Count.ToString();
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
            else
            {
                lblTotaCount.Text = "0";
                gvShow.DataSource = null;
                gvShow.DataBind();
            }

            //gvShow.DataSource = AllData;
            //gvShow.DataBind();


            //lblTotaCount.Text = AllData.Rows.Count.ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getPatientReport();

        }


        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            //   btSearch_Click(sender, e);
            getPatientReport();
        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPatientReport();
        }
    }


}