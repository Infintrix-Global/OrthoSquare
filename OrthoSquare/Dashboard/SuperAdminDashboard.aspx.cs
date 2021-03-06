using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Text;
using System.Collections.Specialized;

namespace OrthoSquare.Dashboard
{
    public partial class SuperAdminDashboard : System.Web.UI.Page
    {


        clsCommonMasters objcommon = new clsCommonMasters();
        public static DataTable AllData = new DataTable();
        BAL_EnquirySource objES = new BAL_EnquirySource();
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        BAL_Appointment objApp = new BAL_Appointment();
        BAL_ConsultationAddTreatment objCT = new BAL_ConsultationAddTreatment();
        BAL_Clinic objc = new BAL_Clinic();
        BAL_Patient objp = new BAL_Patient();
        Notificationnew objN = new Notificationnew();
        BAL_Treatment objT = new BAL_Treatment();
        GeneralNew objG = new GeneralNew();
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {

                //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMsg", "alert('Your software will be expired on 20-06-2019')", true);

                objcommon.UserLoginhistory(SessionUtilities.Empid, SessionUtilities.RoleID);

                bindYear();
                bindClinic();
                BindChart();
                GridTodayAppoinmentget();
                EmployeeCount();
                TreatmentMASTERCount();

                // getAllEnquiry();
                DocterNo();
                FollowupNo();
                EnqNo();
                PatientNo();
                TotalInvoice();
                TotalExpense();
                CONVERTEDEnq();
                CLINICSTotal();
                DAILYAPPONTMENTSTOTAL();
                CLINICSTotal();
               
                NewPatinetCount();
                VisitsCount();
               
                AdminCount();
            }
        }

        public void AdminCount()
        {
            NameValueCollection nv = new NameValueCollection();
            
            DataSet ds = objG.GetDataSet("GET_AdminCount", nv);
            DataTable dtEY = ds.Tables[0];
            DataTable dtEM = ds.Tables[1];
            DataTable dtED = ds.Tables[2];

            DataTable dtFY = ds.Tables[3];
            DataTable dtFM = ds.Tables[4];
            DataTable dtFD = ds.Tables[5];

            DataTable dtCEY = ds.Tables[6];
            DataTable dtCEM = ds.Tables[7];
            DataTable dtCED = ds.Tables[8];

            DataTable dtNPY = ds.Tables[9];
            DataTable dtNPM = ds.Tables[10];
            DataTable dtNPD = ds.Tables[11];

            DataTable dtVPY = ds.Tables[12];
            DataTable dtVPM = ds.Tables[13];
            DataTable dtVPD = ds.Tables[14];


            DataTable dtTCY = ds.Tables[15];
            DataTable dtTCM = ds.Tables[16];
            DataTable dtTCD = ds.Tables[17];

            DataTable dtPMY = ds.Tables[18];
            DataTable dtPMM = ds.Tables[19];
            DataTable dtPMD = ds.Tables[20];

            DataTable dtPEY = ds.Tables[21];
            DataTable dtPEM = ds.Tables[22];
            DataTable dtPED = ds.Tables[23];

            lblEnqYear.Text = dtEY.Rows[0]["EnquiryYear"].ToString();
            lblEnqMonth.Text = dtEM.Rows[0]["EnquiryMonth"].ToString();
            lbllblEnqDay.Text = dtED.Rows[0]["EnquiryDay"].ToString();

            lblFollouwpsYear.Text = dtFY.Rows[0]["FolllowuYear"].ToString();
            lblFollouwpsMonth.Text = dtFM.Rows[0]["FolllowuMonth"].ToString();
            lblFollouwpsDay.Text = dtFD.Rows[0]["FolllowuDay"].ToString();

            lblConversionYear.Text = dtCEY.Rows[0]["ConversionYear"].ToString();
            lblConversionMonth.Text = dtCEM.Rows[0]["ConversionMonth"].ToString();
            lblConversionDay.Text = dtCED.Rows[0]["ConversionDay"].ToString();

            lblNewYear.Text = dtNPY.Rows[0]["NewYear"].ToString();
            lblNewMonth.Text = dtNPM.Rows[0]["NewMonth"].ToString();
            lblNewDay.Text = dtNPD.Rows[0]["NewDay"].ToString();

            lblVisitsYear.Text = dtVPY.Rows[0]["PatientYear"].ToString();
            lblVisitsMonth.Text = dtVPM.Rows[0]["PatientMonth"].ToString();
            lblVisitsDay.Text = dtVPD.Rows[0]["PatientDay"].ToString();


            lblTreatCollYear.Text = Convert.ToDecimal(dtTCY.Rows[0]["TotalAmountYear"]).ToString("#,##0.00");
            lblTreatCollMonth.Text = Convert.ToDecimal(dtTCM.Rows[0]["TotalAmountMonth"]).ToString("#,##0.00");
            lblTreatCollDay.Text = Convert.ToDecimal(dtTCD.Rows[0]["TotalAmountDay"]).ToString("#,##0.00");

            lblMediCollYear.Text = Convert.ToDecimal(dtPMY.Rows[0]["GrandTotalYear"]).ToString("#,##0.00");
            lblMediCollMonth.Text = Convert.ToDecimal(dtPMM.Rows[0]["GrandTotalMonth"]).ToString("#,##0.00");
            lblMediCollDay.Text = Convert.ToDecimal(dtPMD.Rows[0]["GrandTotalDay"]).ToString("#,##0.00");


            lblExpenseYear.Text = Convert.ToDecimal(dtPEY.Rows[0]["AmountYear"]).ToString("#,##0.00");
            lblExpenseMonth.Text = Convert.ToDecimal(dtPEM.Rows[0]["AmountMonth"]).ToString("#,##0.00");
            lblExpenseDay.Text = Convert.ToDecimal(dtPED.Rows[0]["AmountDay"]).ToString("#,##0.00");

        }







        public void DocterNo()
        {

            //int Eno = objcommon.GetDoctorMax_No();
            int Eno = objcommon.GetDoctorCountMASTER();

            lblDoctors.Text = Eno.ToString();
        }

        public void EmployeeCount()
        {

            int Eno = objcommon.GetEmployyeCount();
            lblEmpTotal.Text = Eno.ToString();
        }



        public void VisitsCount()
        {
            string FromFollowDate = Convert.ToDateTime(System.DateTime.Now).ToString("dd-MM-yyyy");
            string ToFollowDate = System.DateTime.Now.ToString("dd-MM-yyyy");
            DataTable vdr = new DataTable();

            vdr = objp.GetPatientDetailsReport(FromFollowDate, ToFollowDate, 0, 0, "2");
            if (vdr != null && vdr.Rows.Count > 0)
            {

                lblPatinetVisits.Text = vdr.Rows.Count.ToString();

            }
            else
            {
                lblPatinetVisits.Text = "0";

            }
        }


        public void NewPatinetCount()
        {
            string FromFollowDate = Convert.ToDateTime(System.DateTime.Now).ToString("dd-MM-yyyy");
            string ToFollowDate = System.DateTime.Now.ToString("dd-MM-yyyy");
            DataTable vdr = new DataTable();

            vdr = objp.GetPatientDetailsReport(FromFollowDate, ToFollowDate, 0, 0, "1");
            if (vdr != null && vdr.Rows.Count > 0)
            {

                lblNewPatient.Text = vdr.Rows.Count.ToString();

            }
            else
            {
                lblNewPatient.Text = "0";

            }
        }

        public void TreatmentMASTERCount()
        {

            int Eno = objcommon.GetTreatmentMASTER();


            lblTreatmentTotal.Text = Eno.ToString();
        }




        public void FollowupNo()
        {

            int Eno = objcommon.GetFollowupCountNoNew(Convert.ToInt32(SessionUtilities.Empid), Convert.ToInt32(SessionUtilities.RoleID));
            lblFollwupCOunt.Text = Eno.ToString();
        }

        public void EnqNo()
        {

            int Eno = objcommon.GetEnquiryCountNo();
            lblEnq.Text = Eno.ToString();
        }

        public void PatientNo()
        {

            int Eno = objcommon.GetPatientCount_No();
            lblPatient.Text = Eno.ToString();
        }

        public void CONVERTEDEnq()
        {

            int Eno = objcommon.GetTotalCONVERTEDEnq();
            lblConvertedEnd.Text = Eno.ToString();
        }


        public void CLINICSTotal()
        {

            int Cno = objcommon.GetTotalCLINICS();
            lblClinics.Text = Cno.ToString();
        }


        public void DAILYAPPONTMENTSTOTAL()
        {

            int TPno = objcommon.GetTotalDAILYAPPONTMENTS();
            lblDailyAppontment.Text = TPno.ToString();
        }




        public void TotalInvoice()
        {

            decimal Totalinv = objcommon.GetTotalPaidAmount(0);
            decimal TotalMedicinesAmount = objcommon.GetTotalMedicinesAmount();

            if (Totalinv != 0)
            {
                totalinvoice.Text = (Totalinv + TotalMedicinesAmount).ToString("#,##0.00");
            }
            else
            {

                totalinvoice.Text = "0.00";
            }
        }


     
        public void bindClinic()
        {
            ddlClinic.DataSource = objc.GetAllClinicDetais();
            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));



            ddlClinicCollection.DataSource = objc.GetAllClinicDetais();
            ddlClinicCollection.DataValueField = "ClinicID";
            ddlClinicCollection.DataTextField = "ClinicName";
            ddlClinicCollection.DataBind();
            ddlClinicCollection.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));


        }
        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlClinicCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChart();
        }

        


        public void bindYear()
        {
            string Year = System.DateTime.Now.Year.ToString();

            DataTable dt = objcommon.GetYear();



            ddlyear1.DataSource = dt;
            ddlyear1.DataTextField = "YearName";
            ddlyear1.DataValueField = "YearName";
            ddlyear1.DataBind();
            ddlyear1.Items.Insert(0, new ListItem("--- Select ---", "0"));


            ddlYearSOE.DataSource = dt;
            ddlYearSOE.DataTextField = "YearName";
            ddlYearSOE.DataValueField = "YearName";
            ddlYearSOE.DataBind();
            ddlYearSOE.Items.Insert(0, new ListItem("--- Select ---", "0"));


            ddlYearCollection.DataSource = dt;
            ddlYearCollection.DataTextField = "YearName";
            ddlYearCollection.DataValueField = "YearName";
            ddlYearCollection.DataBind();
            ddlYearCollection.Items.Insert(0, new ListItem("--- Select ---", "0"));

            ddlyear1.SelectedValue = Year;
            ddlYearSOE.SelectedValue = Year;
            ddlYearCollection.SelectedValue = Year;
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void ddlYearSOE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlYearCollection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void TotalExpense()
        {


            decimal TotalExp = objcommon.GetTotalExpense(0);

            if (TotalExp != 0)
            {
                lblExp.Text = TotalExp.ToString("#,##0.00");
            }
            else
            {

                lblExp.Text = "0.00";
            }
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

                DataTable dt56 = objApp.GetAlltodayAppoinmentNew1(Cid);

                lblTodayAppoinment.Text = dt56.Rows.Count.ToString();
            }


        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridAppoinment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Aid = Convert.ToInt32(e.CommandArgument);
            string msg;
            if (e.CommandName == "Approve")
            {

                int _isDeleted = objApp.GetApprove(Aid);
                // GridTodayAppoinmentget();



                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblpatientid = (Label)gvRow.FindControl("lblpatientid");
                Label lblstart_date = (Label)gvRow.FindControl("lblstart_date");
                Label lblstart_Time = (Label)gvRow.FindControl("lblstart_Time");


                DataTable DTP = objp.GetPatient(Convert.ToInt32(lblpatientid.Text));

                msg = "Your Appoinment Date :" + lblstart_date.Text + " " + "Time : " + lblstart_Time.Text + " has been Approved";


                // PushNotification(Convert.ToInt32(lblpatientid.Text), "Approved Appoinment", msg);
                objN.SendMessage(lblpatientid.Text, DTP.Rows[0]["registrationToken"].ToString(), msg, " Approved Appoinment", "1");





                Response.Redirect("BranchDashboard.aspx");

            }
            if (e.CommandName == "Reject")
            {


                int _isDeleted = objApp.GetReject(Aid);


                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblpatientid = (Label)gvRow.FindControl("lblpatientid");
                Label lblstart_date = (Label)gvRow.FindControl("lblstart_date");
                Label lblstart_Time = (Label)gvRow.FindControl("lblstart_Time");


                DataTable DTP = objp.GetPatient(Convert.ToInt32(lblpatientid.Text));

                msg = "Your Appoinment Date :" + lblstart_date.Text + " " + "Time : " + lblstart_Time.Text + " has been Reject";

                objN.SendMessage(lblpatientid.Text, DTP.Rows[0]["registrationToken"].ToString(), msg, " Reject Appoinment", "2");

                Response.Redirect("BranchDashboard.aspx");
            }
        }



        //protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvShow.PageIndex = e.NewPageIndex;
        //    getAllEnquiry();
        //}


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
        //protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int index = Convert.ToInt32(e.RowIndex);
        //    try
        //    {
        //        int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

        //        int _isDeleted = objENQ.DeleteEnquiry(ID);
        //        if (_isDeleted != -1)
        //        {


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }



        //}

        //protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvShow.EditIndex = -1;

        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/fullcalendar/demos/NewAppointmentClinic.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Master/AppointmentList.aspx");
        }


        [WebMethod]
        public static List<object> GetChartDataline(string monthsid)
        {
            DateTime today = DateTime.Now;
            DateTime MonthsofYear = DateTime.Today.AddDays(-15);
            string query = " Select  M.MonthsName,count(MONTH(E.EnquiryDate)) Enq from  MonthsMaster M  left  join Enquiry E on M.MonthsName = MONTH(E.EnquiryDate) where  YEAR(E.EnquiryDate) ='"+ monthsid + "'  Group by MonthsName Order by  M.MonthsName ";

            string constr = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
    {
        "MonthsName", "Enq"
    });
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                    {
                        sdr["MonthsName"], sdr["Enq"]
                    });
                        }
                    }
                    con.Close();
                    return chartData;
                }
            }
        }



        [WebMethod]
        public static List<Data> GetDataDonut()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=92.204.4.195; Initial Catalog=Orthosquare; User ID=ortho_admin;Password=admin@@123");

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select gender,count(*) value from Patientmaster where IsActive=1 and gender is not NULL  group by gender";
            SqlCommand cmd = new SqlCommand(cmdstr, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            dt = ds.Tables[0];
            List<Data> dataList = new List<Data>();
            string cat = "";
            int val = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cat = dr[0].ToString();
                val = Convert.ToInt32(dr[1]);
                dataList.Add(new Data(cat, val));
            }
            return dataList;
        }

        //--------------------------------------------------------- Bar Chart----------

        private DataTable GetData()

        {
            //  string conn = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(@"Data Source=92.204.4.195; Initial Catalog=Orthosquare; User ID=ortho_admin;Password=admin@@123");

            DataTable dt = new DataTable();

            //       string cmd = "Select * from ( Select  M.MonthsName, Sum(IM.PaidAmount) COLLECTION  from  MonthsMaster M Left  join InvoiceMaster IM on M.MonthsName = MONTH(IM.PayDate) "
            //+ " Group by MonthsName ) T1 "
            //   + " Join (Select  M.MonthsName, Sum(IM.Amount) EXPENSES from  MonthsMaster M "
            //   +  "  Left  join ExpenseMaster IM on M.MonthsName = MONTH(IM.ExpDate) "
            //+  " Group by MonthsName )T2 "
            //+ " ON T1.MonthsName = T2 .MonthsName ";

            string cmd = " Select isnull(Sum(IM.PaidAmount),0)  COLLECTION,isnull(Sum(E.Amount) ,0) EXPENSES,MONTH(IM.PayDate) MonthsName from InvoiceMaster IM "
            + "  Left  join ExpenseMaster E on MONTH(IM.PayDate) = MONTH(E.ExpDate) where Year(IM.PayDate)  =" + ddlYearCollection.SelectedValue + "  Group by MONTH(IM.PayDate)";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);

            adp.Fill(dt);

            return dt;

        }

        private void BindChart()

        {

            DataTable dt = new DataTable();

            try

            {
                StringBuilder str = new StringBuilder();
                dt = GetData();

                str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

                       google.setOnLoadCallback(drawChart);

                       function drawChart() {

        var data = new google.visualization.DataTable();

        data.addColumn('string', 'Months');

        data.addColumn('number', 'COLLECTION');

        data.addColumn('number', 'EXPENSES');      

 

        data.addRows(" + dt.Rows.Count + ");");



                for (int i = 0; i <= dt.Rows.Count - 1; i++)

                {

                    str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["MonthsName"].ToString() + "');");

                    str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["COLLECTION"].ToString() + ") ;");

                    str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["EXPENSES"].ToString() + ") ;");

                }



                str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");

                str.Append(" chart.draw(data, {width: 450, height: 300, title: '',");

                str.Append("hAxis: {title: 'Months', titleTextStyle: {color: 'green'}}");

                str.Append("}); }");

                str.Append("</script>");

                lt.Text = str.ToString().Replace('*', '"');

            }

            catch

            { }

        }

       // ---------------------------------------------------Pai Chart -------------------------

             [WebMethod]
        public static List<Data> GetDatapai(string monthsid)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=92.204.4.195; Initial Catalog=Orthosquare; User ID=ortho_admin;Password=admin@@123");

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "Select ESM.Sourcename,count(E.Sourceid) as Source1 from Enquiry E join EnquirySourceMaster ESM on  ESM.Sourceid=E.Sourceid where ESM.Sourceid in (10,17,21,18,12) and Year(EnquiryDate)=" + monthsid + " group by ESM.Sourcename ";
            SqlCommand cmd = new SqlCommand(cmdstr, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            dt = ds.Tables[0];
            List<Data> dataList = new List<Data>();
            string cat = "";
            int val = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cat = dr[0].ToString();
                val = Convert.ToInt32(dr[1]);
                dataList.Add(new Data(cat, val));
            }
            return dataList;
        }

        public class Data
        {
            public string ColumnName = "";
            public int Value = 0;

            public Data(string columnName, int value)
            {
                ColumnName = columnName;
                Value = value;
            }
        }


    }
}