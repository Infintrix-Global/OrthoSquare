using OrthoSquare.BAL_Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace OrthoSquare.Report
{
    public partial class AreaManagerCollectionReport : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        public static DataTable AllData = new DataTable();
        BAL_Expense objExp = new BAL_Expense();
        General objG = new General();
        decimal sumFooterValue = 0;
        decimal sumFooterPendingValue = 0;
        decimal Total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromPayDate.Text = Convert.ToDateTime(System.DateTime.Now).AddDays(-15).ToString("dd-MM-yyyy");
                txtToPayDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");


                getAllCollection();
            }
        }

        private long DoctorID
        {
            get
            {
                if (ViewState["DoctorID"] != null)
                {
                    return (long)ViewState["DoctorID"];
                }
                return 0;
            }
            set
            {
                ViewState["DoctorID"] = value;
            }
        }


        public void getAllCollection()
        {

            AllData = objExp.GetAreaManagerClinicCollection_Report(txtFromPayDate.Text, txtToPayDate.Text,Convert.ToInt32(DoctorID));

            //gvShow.DataSource = AllData;
            //gvShow.DataBind();

            if (AllData != null && AllData.Rows.Count > 0)
            {
                for (int i = 0; i < AllData.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(AllData.Rows[i]["PaidAmount"]);


                }
                lblTotalTop.Text = Total.ToString();
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
            else
            {
                lblTotalTop.Text = "0";
                gvShow.DataSource = null;
                gvShow.DataBind();
            }

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

  
        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllCollection();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btExcel_ClickClinic(object sender, ImageClickEventArgs e)
        {


            AllData = objExp.GetAreaManagerClinicCollection_Report(txtFromPayDate.Text, txtToPayDate.Text, Convert.ToInt32(DoctorID));


            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.ClearContent();
            response.Charset = Encoding.UTF8.WebName;
            response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
            response.AddHeader("Content-Type", "application/Excel");
            response.ContentType = "application/vnd.xlsx";
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    GridView gridView = new GridView();
                    gridView.DataSource = AllData;
                    gridView.DataBind();
                    gridView.RenderControl(htw);
                    response.Write(sw.ToString());
                    gridView.Dispose();
                    AllData.Dispose();
                    response.End();
                }
            }
        }



        protected void txtDocter_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objcommon.DoctersSelectDoctorID(txtDocter.Text);

            DoctorID = Convert.ToInt32(dt.Rows[0]["DoctorID"]);
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
                    int DoctorID = 0, ClinicId = 0;
                    int RoleId = Convert.ToInt32(HttpContext.Current.Session["RoleID"]);
                    DoctorID = Convert.ToInt32(HttpContext.Current.Session["Empid"]);
                    ClinicId = Convert.ToInt32(HttpContext.Current.Session["Empid"]);
                    //cmd.CommandText = " select distinct GPD.jobcode from gti_jobs_seeds_plan GTS inner join GrowerPutAwayDetails GPD on GPD.wo=GTS.wo  where  GPD.FacilityID ='" + Facility + "'  AND GPD.jobcode like '%" + prefixText + "%' union select distinct jobcode from gti_jobs_seeds_plan_Manual where loc_seedline ='" + Facility + "'  AND jobcode like '%" + prefixText + "%' order by jobcode" +
                    //    "";
                    //SessionUtilities.Empid, SessionUtilities.RoleID





                    cmd.CommandText = "Select FirstName+' '+LastName as DoctorName,SA.DoctorId from SubAdminClinic  SA   join tbl_DoctorDetails DC on DC.DoctorID =SA.DoctorId  and DC.IsDeleted=0 and  FirstName+' '+LastName like '%" + prefixText + "%' ";
                    cmd.CommandText += "Group By FirstName,LastName,SA.DoctorId  order by FirstName ASC";


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

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal Total = 0;
                GridView gvClinicPay = e.Row.FindControl("gvClinicPay") as GridView;
                Label lblDoctorId = (Label)e.Row.FindControl("lblDoctorId");

                NameValueCollection nv = new NameValueCollection();
                nv.Add("@FromDate", txtFromPayDate.Text);
                nv.Add("@ToDate", txtToPayDate.Text);
                nv.Add("@DoctorID", lblDoctorId.Text);
                nv.Add("@Mode","2");


                DataTable dt = objG.GetDataTable("GET_AreaManagerCollectionReport", nv);

                gvClinicPay.DataSource = dt;
                gvClinicPay.DataBind();

            }


        }
    }
}