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

namespace OrthoSquare.Report
{
    public partial class MedicinesCollectionReport : System.Web.UI.Page
    {
        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        BAL_Expense objExp = new BAL_Expense();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Finance objF = new BAL_Finance();
        decimal sumFooterValue = 0;
        decimal sumFooterPendingValue = 0;
        decimal Total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSFromFollowDate.Text = Convert.ToDateTime(System.DateTime.Now).AddDays(-15).ToString("dd-MM-yyyy");
                txtSToFollowDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");


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
                    DoctorId = 0;
                    getAllCollection();

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
            ddlDocter.DataTextField = "DoctorName";
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
                ddlDocter.DataSource = objcommon.DoctersMaster(Cid, 3);

            }


            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "DoctorName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            Total = 0;
            bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
            getAllCollection();
        }

        public void getAllCollection()
        {

            AllData = objExp.GetAllMedicinesCollectionReport(txtSFromFollowDate.Text, txtSToFollowDate.Text, Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(DoctorId), txtMedicines.Text);

            if (AllData != null && AllData.Rows.Count > 0)
            {
                for (int i = 0; i < AllData.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(AllData.Rows[i]["GrandTotal"]);


                }
                lblTotaCount.Text = Total.ToString();
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


          //  lblTotaCount.Text = AllData.Rows.Count.ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Total = 0;
            getAllCollection();

        }

        protected void txtDocter_TextChanged(object sender, EventArgs e)
        {
            Total = 0;
            DataTable dt = objcommon.DoctersSelectDoctorID(txtDocter.Text);
            DoctorId = Convert.ToInt32(dt.Rows[0]["DoctorID"]);

            getAllCollection();
            bindClinic();
        }


        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            //   btSearch_Click(sender, e);
            getAllCollection();
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    int DoctorID = 0;
                    int RoleId = Convert.ToInt32(HttpContext.Current.Session["RoleID"]);
                    //cmd.CommandText = " select distinct GPD.jobcode from gti_jobs_seeds_plan GTS inner join GrowerPutAwayDetails GPD on GPD.wo=GTS.wo  where  GPD.FacilityID ='" + Facility + "'  AND GPD.jobcode like '%" + prefixText + "%' union select distinct jobcode from gti_jobs_seeds_plan_Manual where loc_seedline ='" + Facility + "'  AND jobcode like '%" + prefixText + "%' order by jobcode" +
                    //    "";
                    //SessionUtilities.Empid, SessionUtilities.RoleID
                    if (RoleId == 3)
                    {

                        DoctorID = Convert.ToInt32(HttpContext.Current.Session["Empid"]);


                    }

                    else
                    {

                        DoctorID = 0;

                    }

                    cmd.CommandText = "Select FirstName+' '+ isnull(LastName,' ') as DoctorName,* from tbl_DoctorDetails where  IsActive =1 and IsDeleted=0  AND FirstName like '%" + prefixText + "%' ";


                    cmd.CommandText += "  order by FirstName ASC";

                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["DoctorName"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchMedicines(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    int DoctorID = 0;


                    cmd.CommandText = "Select * From MedicinesMaster where  IsActive=1  AND MedicinesName like '%" + prefixText + "%' ";

                    cmd.CommandText += "  order by MedicinesName ASC";

                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["MedicinesName"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }


        protected void txtMedicines_TextChanged(object sender, EventArgs e)
        {
            Total = 0;
            getAllCollection();
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");

                //Total += Convert.ToDecimal(lblGrandTotal.Text);

                //lblTotaCount.Text = Total.ToString();
            }
        }
    }


}