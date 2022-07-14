using OrthoSquare.BAL_Classes;
using OrthoSquare.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace OrthoSquare.Report
{
    public partial class PaymentModeClinicReport : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Clinic objc = new BAL_Clinic();
        General objG = new General();
        decimal GTotal = 0;
        decimal GMTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {




                if (SessionUtilities.RoleID == 1)
                {
                    bindClinic();
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();

                }
                else
                {
                    bindClinic();


                }
                getYear();
                getMonth();
                getAllCollection();
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllCollection();
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


        protected void txtDocter_TextChanged(object sender, EventArgs e)
        {
            bindClinic();
        }


        public void getYear()
        {
            NameValueCollection nv = new NameValueCollection();

            nv.Add("@stateID", "");
            nv.Add("@Countryid", "");
            nv.Add("@ClinicID", "");
            nv.Add("@mode", "24");
            DataTable dt = objG.GetDataTable("GET_Common", nv);
            ddlYear.DataSource = dt;

            ddlYear.DataValueField = "YearName";
            ddlYear.DataTextField = "YearName";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("-- Select Year --", "0", true));

            ddlYear.SelectedValue = System.DateTime.Now.ToString("yyyy");
        }

        public void getMonth()
        {
            string m = System.DateTime.Now.ToString("MM");

            NameValueCollection nv = new NameValueCollection();
            DataTable dt1 = new DataTable();
            nv.Add("@stateID", "");
            nv.Add("@Countryid", "");
            nv.Add("@ClinicID", "");
            nv.Add("@mode", "23");
            dt1 = objG.GetDataTable("GET_Common", nv);
            ddlMonths.DataSource = dt1;
            ddlMonths.DataValueField = "MonthsNo";
            ddlMonths.DataTextField = "MonthsCode";
            ddlMonths.DataBind();

            ddlMonths.Items.Insert(0, new ListItem("-- Select Month --", "0", true));

            // ddlMonths.SelectedValue = System.DateTime.Now.ToString("MM");
        }


        public void getAllCollection()
        {

            NameValueCollection nv = new NameValueCollection();
            nv.Add("@MonthId", ddlMonths.SelectedValue);
            nv.Add("@YearId", ddlYear.SelectedValue);
            nv.Add("@ClinicID", ddlClinic.SelectedValue);
            nv.Add("@DoctorId", DoctorId.ToString());
            nv.Add("@FromDate", txtFromDate.Text);
            nv.Add("@ToDate", txtToDate.Text);
            DataTable dt = objG.GetDataTable("GET_PaymentModeReportMonth", nv);


            gvShow.DataSource = dt;
            gvShow.DataBind();

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

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal Total = 0;
                GridView gvPaymonthDay = e.Row.FindControl("gvPaymonthDay") as GridView;
                Label lblTotal = (Label)e.Row.FindControl("lblTotal1");
                Label lblCash = (Label)e.Row.FindControl("lblCash1");
                Label lblDebitCard = (Label)e.Row.FindControl("lblDebitCard1");
                Label lblCreditCard = (Label)e.Row.FindControl("lblCreditCard1");
                Label lblUPI = (Label)e.Row.FindControl("lblUPI1");
                Label lblCheque = (Label)e.Row.FindControl("lblCheque1");
                Label lblBajajfinance = (Label)e.Row.FindControl("lblBajajfinance1");

                Label lblKotakfinance = (Label)e.Row.FindControl("lblKotakfinance1");

                Label lblLiquiLoans = (Label)e.Row.FindControl("lblLiquiLoans1");
                Label lblIDFCFirstBank = (Label)e.Row.FindControl("lblIDFCFirstBank1");
                Label lblShopse = (Label)e.Row.FindControl("lblShopse1");
                Label lblMonthNo = (Label)e.Row.FindControl("lblMonthNo");

                Label lblShopsePreapproved1 = (Label)e.Row.FindControl("lblShopsePreapproved1");
                Label lblShopseHDFC1 = (Label)e.Row.FindControl("lblShopseHDFC1");
                Label lblShopseCreditCard1 = (Label)e.Row.FindControl("lblShopseCreditCard1");
                Label lblShopseAmex1 = (Label)e.Row.FindControl("lblShopseAmex1");
                Label lblNEFT = (Label)e.Row.FindControl("lblNEFT1");


                if (lblNEFT.Text == "")
                {
                    lblNEFT.Text = "0.00";
                }


                if (lblCash.Text == "")
                {
                    lblCash.Text = "0.00";
                }
                if (lblDebitCard.Text == "")
                {
                    lblDebitCard.Text = "0.00";
                }
                if (lblCreditCard.Text == "")
                {
                    lblCreditCard.Text = "0.00";
                }
                if (lblUPI.Text == "")
                {
                    lblUPI.Text = "0.00";
                }
                if (lblBajajfinance.Text == "")
                {
                    lblBajajfinance.Text = "0.00";
                }
                if (lblKotakfinance.Text == "")
                {
                    lblKotakfinance.Text = "0.00";
                }

                if (lblLiquiLoans.Text == "")
                {
                    lblLiquiLoans.Text = "0.00";
                }

                if (lblIDFCFirstBank.Text == "")
                {
                    lblIDFCFirstBank.Text = "0.00";
                }

                if (lblShopse.Text == "")
                {
                    lblShopse.Text = "0.00";
                }

                if (lblShopsePreapproved1.Text == "")
                {
                    lblShopsePreapproved1.Text = "0.00";
                }
                if (lblShopseHDFC1.Text == "")
                {
                    lblShopseHDFC1.Text = "0.00";
                }
                if (lblShopseCreditCard1.Text == "")
                {
                    lblShopseCreditCard1.Text = "0.00";
                }
                if (lblShopseAmex1.Text == "")
                {
                    lblShopseAmex1.Text = "0.00";
                }

                if (lblCheque.Text == "")
                {
                    lblCheque.Text = "0.00";
                }



                Total = Convert.ToDecimal(lblCash.Text) + Convert.ToDecimal(lblDebitCard.Text) + Convert.ToDecimal(lblCreditCard.Text) + Convert.ToDecimal(lblUPI.Text) + Convert.ToDecimal(lblBajajfinance.Text) + Convert.ToDecimal(lblKotakfinance.Text) + Convert.ToDecimal(lblLiquiLoans.Text) + Convert.ToDecimal(lblIDFCFirstBank.Text) + Convert.ToDecimal(lblShopse.Text) + Convert.ToDecimal(lblShopsePreapproved1.Text) + Convert.ToDecimal(lblShopseHDFC1.Text) + Convert.ToDecimal(lblShopseCreditCard1.Text) + Convert.ToDecimal(lblShopseAmex1.Text) + Convert.ToDecimal(lblCheque.Text) + Convert.ToDecimal(lblNEFT.Text); ;

                lblTotal.Text = Total.ToString();

                GMTotal += Total;

                NameValueCollection nv = new NameValueCollection();
                nv.Add("@MonthId", lblMonthNo.Text);
                nv.Add("@YearId", ddlYear.SelectedValue);
                nv.Add("@ClinicID", ddlClinic.SelectedValue);
                nv.Add("@DoctorId", DoctorId.ToString());

                nv.Add("@FromDate", txtFromDate.Text);
                nv.Add("@ToDate", txtToDate.Text);
                DataTable dt = objG.GetDataTable("GET_PaymentModeClinicReport", nv);

                gvPaymonthDay.DataSource = dt;
                gvPaymonthDay.DataBind();
            }


            lblTotalTop.Text = GMTotal.ToString();



        }

        protected void gvPaymonthDay_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal Total = 0;

                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                Label lblCash = (Label)e.Row.FindControl("lblCash");
                Label lblDebitCard = (Label)e.Row.FindControl("lblDebitCard");
                Label lblCreditCard = (Label)e.Row.FindControl("lblCreditCard");
                Label lblUPI = (Label)e.Row.FindControl("lblUPI");
                Label lblCheque = (Label)e.Row.FindControl("lblCheque");
                Label lblBajajfinance = (Label)e.Row.FindControl("lblBajajfinance");

                Label lblKotakfinance = (Label)e.Row.FindControl("lblKotakfinance");

                Label lblLiquiLoans = (Label)e.Row.FindControl("lblLiquiLoans");
                Label lblIDFCFirstBank = (Label)e.Row.FindControl("lblIDFCFirstBank");
                Label lblShopse = (Label)e.Row.FindControl("lblShopse");

                Label lblShopsePreapproved = (Label)e.Row.FindControl("lblShopsePreapproved");
                Label lblShopseHDFC = (Label)e.Row.FindControl("lblShopseHDFC");
                Label lblShopseCreditCard = (Label)e.Row.FindControl("lblShopseCreditCard");
                Label lblShopseAmex = (Label)e.Row.FindControl("lblShopseAmex");

                Label lblNEFT = (Label)e.Row.FindControl("lblNEFT");


                if (lblNEFT.Text == "")
                {
                    lblNEFT.Text = "0.00";
                }


                if (lblCash.Text == "")
                {
                    lblCash.Text = "0.00";
                }
                if (lblDebitCard.Text == "")
                {
                    lblDebitCard.Text = "0.00";
                }
                if (lblCreditCard.Text == "")
                {
                    lblCreditCard.Text = "0.00";
                }
                if (lblUPI.Text == "")
                {
                    lblUPI.Text = "0.00";
                }
                if (lblBajajfinance.Text == "")
                {
                    lblBajajfinance.Text = "0.00";
                }
                if (lblKotakfinance.Text == "")
                {
                    lblKotakfinance.Text = "0.00";
                }

                if (lblLiquiLoans.Text == "")
                {
                    lblLiquiLoans.Text = "0.00";
                }

                if (lblIDFCFirstBank.Text == "")
                {
                    lblIDFCFirstBank.Text = "0.00";
                }

                if (lblShopse.Text == "")
                {
                    lblShopse.Text = "0.00";
                }

                if (lblShopsePreapproved.Text == "")
                {
                    lblShopsePreapproved.Text = "0.00";
                }
                if (lblShopseHDFC.Text == "")
                {
                    lblShopseHDFC.Text = "0.00";
                }
                if (lblShopseCreditCard.Text == "")
                {
                    lblShopseCreditCard.Text = "0.00";
                }
                if (lblShopseAmex.Text == "")
                {
                    lblShopseAmex.Text = "0.00";
                }

                if (lblCheque.Text == "")
                {
                    lblCheque.Text = "0.00";
                }


                Total = Convert.ToDecimal(lblCash.Text) + Convert.ToDecimal(lblDebitCard.Text) + Convert.ToDecimal(lblCreditCard.Text) + Convert.ToDecimal(lblUPI.Text) + Convert.ToDecimal(lblBajajfinance.Text) + Convert.ToDecimal(lblKotakfinance.Text) + Convert.ToDecimal(lblLiquiLoans.Text) + Convert.ToDecimal(lblIDFCFirstBank.Text) + Convert.ToDecimal(lblShopse.Text) + Convert.ToDecimal(lblShopsePreapproved.Text) + Convert.ToDecimal(lblShopseHDFC.Text) + Convert.ToDecimal(lblShopseCreditCard.Text) + Convert.ToDecimal(lblShopseAmex.Text) + Convert.ToDecimal(lblCheque.Text) + Convert.ToDecimal(lblNEFT.Text);

                lblTotal.Text = Total.ToString();

                GTotal += Total;

            }


            lblTotalTop.Text = GTotal.ToString();
        }
    }
}