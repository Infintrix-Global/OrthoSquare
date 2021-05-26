using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using OrthoSquare.Data;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace OrthoSquare.Master
{
    public partial class TREATMENT_STATISTICS : System.Web.UI.Page
    {
        BAL_Treatment objT = new BAL_Treatment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAllTreatmentPatientCount("", "");
            }
        }


        public void getAllTreatmentPatientCount(string year, string Months)
        {

            DataTable AllData1 = objT.GetTreatmentPatientCount(year, Months,"");


            GridTREATMENTWISEPATIENT.DataSource = AllData1;
            GridTREATMENTWISEPATIENT.DataBind();


        }




        protected void GridTREATMENTWISEPATIENT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridTREATMENTWISEPATIENT.PageIndex = e.NewPageIndex;
            getAllTreatmentPatientCount("", "");
        }
    }
}