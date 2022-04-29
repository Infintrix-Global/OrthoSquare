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
    public partial class FinanceReport : System.Web.UI.Page
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

                bindFinance();
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


        public void bindFinance()
        {

            DataTable dt;

            dt = objF.GetAllFinance();
            ddlFinance.DataSource = dt;
            ddlFinance.DataValueField = "Financeid";
            ddlFinance.DataTextField = "FinanceName";
            ddlFinance.DataBind();
            ddlFinance.Items.Insert(0, new ListItem("-- Select Finance --", "0", true));
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
            bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
        }



        public void getAllCollection()
        {
            string FinanceM = "";
             if(ddlFinance.SelectedValue=="0")
            {
                FinanceM = "0";

            }
             else
            {
                FinanceM = ddlFinance.SelectedItem.Text;
            }

            AllData = objExp.GetAllFinancePayment(txtSFromFollowDate.Text,txtSToFollowDate.Text, Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(DoctorId), FinanceM);
           
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllCollection();

        }

        protected void txtDocter_TextChanged(object sender, EventArgs e)
        {
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

        //protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        //{



        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        Label lblPaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
        //        Label lblPendingAmount = (Label)e.Row.FindControl("lblPendingAmount");
        //        Label lblTotal = (Label)e.Row.FindControl("lblTotal");
        //        Label lblDoctor = (Label)e.Row.FindControl("lblDoctor");
        //        Label lblClinicID = (Label)e.Row.FindControl("lblClinicID");
        //        Label lblIsDelete = (Label)e.Row.FindControl("lblIsDelete");


        //        //  Label lblDoctor = (Label)e.Row.FindControl("lblDoctor");
        //        //    Label lblClinicName = (Label)e.Row.FindControl("lblClinicName");

        //        // DataTable dt =objExp.GetAllDocterCollectionReportNew11(Convert .ToInt32 (lblClinicID.Text ), Convert.ToInt32(lblDoctor.Text), txtSFromFollowDate.Text.Trim(), txtSToFollowDate.Text.Trim());
        //        DataTable dt = objExp.GetAllDocterCollectionAmount(Convert.ToInt32(lblClinicID.Text), Convert.ToInt32(lblDoctor.Text), txtSFromFollowDate.Text.Trim(), txtSToFollowDate.Text.Trim());


        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            decimal PaidAmount = 0;
        //            decimal TotalAmount = 0;
        //            decimal Pending = 0;

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                PaidAmount += Convert.ToDecimal(dt.Rows[i]["PaidAmount"]);
        //                TotalAmount += Convert.ToDecimal(dt.Rows[i]["Total"]);

        //            }
        //            Pending = TotalAmount - PaidAmount;
        //            lblPaidAmount.Text = PaidAmount.ToString();
        //            lblPendingAmount.Text = Pending.ToString();
        //            lblTotal.Text = TotalAmount.ToString();

        //            //lblPaidAmount.Text = dt.Rows[0]["PaidAmount"].ToString();
        //            //lblPendingAmount.Text = dt.Rows[0]["PendingAmount"].ToString();
        //            //lblTotal.Text = dt.Rows[0]["Total"].ToString();
        //        }
        //        else
        //        {
        //            lblPaidAmount.Text = "0";
        //            lblPendingAmount.Text = "0";
        //            lblTotal.Text = "0";



        //        }

        //        sumFooterValue += Convert.ToDecimal(lblPaidAmount.Text);
        //        sumFooterPendingValue += Convert.ToDecimal(lblPendingAmount.Text);
        //        Total += Convert.ToDecimal(lblTotal.Text);

        //        //if (lblTotal.Text == "0.00" && lblIsDelete.Text== "True")
        //        //{
        //        //    e.Row.Visible = false;

        //        //}

        //    }

        //    // lblTotalTop.Text = sumFooterValue.ToString();
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        Label lblPaidAmountTotal = (Label)e.Row.FindControl("lblPaidAmountTotal");
        //        Label lblPendingAmountTotal = (Label)e.Row.FindControl("lblPendingAmountTotal");
        //        Label lblGTotla = (Label)e.Row.FindControl("lblGTotla");

        //        lblPaidAmountTotal.Text = sumFooterValue.ToString();
        //        lblPendingAmountTotal.Text = sumFooterPendingValue.ToString();
        //        lblGTotla.Text = Total.ToString();


        //    }
        //}


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

        protected void ddlFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllCollection();
        }
    }


}