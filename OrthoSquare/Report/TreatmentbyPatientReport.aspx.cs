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
using PreconFinal.Utility;
using System.Data.OleDb;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Text;
namespace OrthoSquare.Report
{
    public partial class TreatmentbyPatientReport : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        BAL_Treatment objt = new BAL_Treatment();
        clsCommonMasters objcomm = new clsCommonMasters();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlTreatment();
                BindDocterSearch();
                getAllPatient();
            }
        }

        public void BindDocterSearch()
        {
            if (SessionUtilities.RoleID == 1)
            {

                ddlDocterSearch.DataSource = objcomm.DoctersMaster(SessionUtilities.Empid, SessionUtilities.RoleID);

            }
            else if (SessionUtilities.RoleID == 3)
            {
                ddlDocterSearch.DataSource = objcomm.DoctersMaster123(SessionUtilities.Empid, SessionUtilities.RoleID);

            }
            else
            {
                ddlDocterSearch.DataSource = objcomm.DoctersMaster(0, SessionUtilities.RoleID);

            }

            ddlDocterSearch.DataTextField = "DoctorName";
            ddlDocterSearch.DataValueField = "DoctorID";
            ddlDocterSearch.DataBind();

            ddlDocterSearch.Items.Insert(0, new ListItem("--- Select Doctor---", "0"));
        }


        public void BindddlTreatment()
        {

            ddlTreatment.DataSource = objt.GetAllTreatment11();

            ddlTreatment.DataTextField = "TreatmentName";
            ddlTreatment.DataValueField = "TreatmentID";
            ddlTreatment.DataBind();

            ddlTreatment.Items.Insert(0, new ListItem("--- Select Treatment ---", "0"));
        }

        public void getAllPatient()
        {
            int DID = 0;

            if (SessionUtilities.RoleID == 3)
            {
                DID = Convert.ToInt32(SessionUtilities.Empid);
            }
            else
            {
                DID = Convert .ToInt32(ddlDocterSearch.SelectedValue);
            }

            //AllData = objPatient.GetPatientlist();
            AllData = objt.GetTreatmentbyPatient(DID,Convert .ToInt32(ddlTreatment .SelectedValue ),txtFromEnquiryDate .Text .Trim (),txtToEnquiryDate .Text .Trim ());
            if (AllData != null && AllData.Rows.Count > 0)
            {
               
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllPatient();


        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            getAllPatient();

        }
        }
}