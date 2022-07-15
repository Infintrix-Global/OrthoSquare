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
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Collections.Specialized;
using System.Text;

namespace OrthoSquare.Report
{
    public partial class DocterCollectionReport : System.Web.UI.Page
    {
        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        BAL_Expense objExp = new BAL_Expense();
        clsCommonMasters objcommon = new clsCommonMasters();
        GeneralNew objG1 = new GeneralNew();
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

                    //getAllCollection();
                    getAllCollectionNew();

                }
                else
                {
                    bindClinic();
                    bindDoctorMasterNew();

                    //getAllCollection();
                    getAllCollectionNew();
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
                if(DoctorId >0)
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
                ddlDocter.DataSource = objcommon.DoctersMaster(Cid,3);
             
            }


            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "DoctorName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
        }



        //public void getAllCollection()
        //{

        //    AllData = objExp.GetAllDocterCollectionReportNew11(ddlClinic.SelectedValue,txtDocter.Text);
        //    if (txtDocter.Text != "")
        //    {
        //        DoctorId = Convert.ToInt64(AllData.Rows[0]["DoctorId"]);
        //    }
        //    else
        //    {
        //        DoctorId = 0;
        //    }
        //    gvShow.DataSource = AllData;
        //    gvShow.DataBind();

        //}




        public void getAllCollectionNew()
        {
            List<DoctorCollection> list = new List<DoctorCollection>();


            NameValueCollection nv1 = new NameValueCollection();

            nv1.Add("@ClinicID", ddlClinic.SelectedValue);
            nv1.Add("@DoctorID", DoctorID.ToString());
            nv1.Add("@FromDate", txtSFromFollowDate.Text);
            nv1.Add("@ToDate", txtSToFollowDate.Text);
            nv1.Add("@Mode", "1");

            DataTable dt1 = objG1.GetDataTable("GET_DoctorCollectionDetailsReport", nv1);

            DoctorCollection objCol = null;
            if (dt1 != null)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {


                    NameValueCollection nv11 = new NameValueCollection();

                    nv11.Add("@ClinicID", dt1.Rows[i]["Clinicid"].ToString());
                    nv11.Add("@DoctorID", dt1.Rows[i]["DoctorID"].ToString());
                    nv11.Add("@FromDate", txtSFromFollowDate.Text);
                    nv11.Add("@ToDate", txtSToFollowDate.Text);
                    nv11.Add("@Mode", "2");

                    DataTable dt11 = objG1.GetDataTable("GET_DoctorCollectionDetailsReport", nv11);

                    // DataTable dt11 = objExp.GetAllClinicCollection_ReportNew(txtFromPayDate.Text, txtToPayDate.Text, Convert.ToInt32(ddlClinic.SelectedValue));

                    objCol = new DoctorCollection();

                    objCol.ClinicName = dt11.Rows[0]["ClinicName"].ToString();
                    objCol.DoctorName = dt11.Rows[0]["DoctorName"].ToString();

                    objCol.PaidAmount = dt11.Rows[0]["PaidAmount"].ToString();
                   
                    objCol.MedicinesPaidAmount = dt11.Rows[0]["MedicinesPaidAmount"].ToString();
                 
                    list.Add(objCol);

                }
            }


            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            AllData = converter.ToDataTable(list);
            if (AllData != null && AllData.Rows.Count > 0)
            {

                for (int i = 0; i < AllData.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(AllData.Rows[i]["PaidAmount"]) + Convert.ToDecimal(AllData.Rows[i]["MedicinesPaidAmount"]);


                }

                lblTotalTop.Text = Total.ToString();
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
            else
            {
                lblTotalTop.Text = Total.ToString();
                gvShow.DataSource = null;
                gvShow.DataBind();
            }

        }


        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
        }


        public class DoctorCollection
        {
            public string ClinicName { get; set; }

            public string DoctorName { get; set; }
            public string PaidAmount { get; set; }
          
            public string MedicinesPaidAmount { get; set; }
          

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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllCollectionNew();

        }

        protected void txtDocter_TextChanged(object sender, EventArgs e)
        {

            DataTable dt = objcommon.DoctersSelectDoctorID(txtDocter.Text);
            DoctorID = Convert.ToInt32(dt.Rows[0]["DoctorID"]);

            getAllCollectionNew();
            bindClinic();
        }


        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            //   btSearch_Click(sender, e);
            getAllCollectionNew();
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    Label lblPaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
            //    Label lblPendingAmount = (Label)e.Row.FindControl("lblPendingAmount");
            //    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            //    Label lblDoctor = (Label)e.Row.FindControl("lblDoctor");
            //    Label lblClinicID = (Label)e.Row.FindControl("lblClinicID");
            //    Label lblIsDelete = (Label)e.Row.FindControl("lblIsDelete");


             
            //    DataTable dt = objExp.GetAllDocterCollectionAmount(Convert.ToInt32(lblClinicID.Text), Convert.ToInt32(lblDoctor.Text), txtSFromFollowDate.Text.Trim(), txtSToFollowDate.Text.Trim());

                
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        decimal PaidAmount = 0;
            //        decimal TotalAmount = 0;
            //        decimal Pending = 0;

            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            PaidAmount += Convert.ToDecimal(dt.Rows[i]["PaidAmount"]);
            //            TotalAmount += Convert.ToDecimal(dt.Rows[i]["Total"]);
                       
            //        }
            //        Pending = TotalAmount - PaidAmount;
            //        lblPaidAmount.Text = PaidAmount.ToString();
            //        lblPendingAmount.Text = Pending.ToString();
            //        lblTotal.Text = TotalAmount.ToString();

                   
            //    }
            //    else
            //    {
            //        lblPaidAmount.Text = "0";
            //        lblPendingAmount.Text = "0";
            //        lblTotal.Text = "0";



            //    }

            //    sumFooterValue += Convert.ToDecimal(lblPaidAmount.Text);
            //    sumFooterPendingValue += Convert.ToDecimal(lblPendingAmount.Text);
            //    Total+= Convert.ToDecimal(lblTotal.Text);

              

            //}

           
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label lblPaidAmountTotal = (Label)e.Row.FindControl("lblPaidAmountTotal");
            //    Label lblPendingAmountTotal = (Label)e.Row.FindControl("lblPendingAmountTotal");
            //    Label lblGTotla = (Label)e.Row.FindControl("lblGTotla");

            //    lblPaidAmountTotal.Text = sumFooterValue.ToString();
            //    lblPendingAmountTotal.Text = sumFooterPendingValue.ToString();
            //    lblGTotla.Text = Total.ToString();

               
            //}
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btExcel_ClickClinic(object sender, ImageClickEventArgs e)
        {


            //  AllData = objExp.GetAllClinicCollection_Report(txtFromPayDate.Text, txtToPayDate.Text, Convert.ToInt32(ddlClinic.SelectedValue));


            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.ClearContent();
            response.Charset = Encoding.UTF8.WebName;
            response.AddHeader("content-disposition", "attachment; filename=" + "DoctorCollectionReport_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
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

      
    }


}