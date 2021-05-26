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

namespace OrthoSquare.Dashboard
{
    public partial class DocterDashboard : System.Web.UI.Page
    {

        clsCommonMasters objcommon = new clsCommonMasters();
        public static DataTable AllData = new DataTable();
        BAL_EnquirySource objES = new BAL_EnquirySource();
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        BAL_Appointment objApp = new BAL_Appointment();
        BAL_ConsultationAddTreatment objCT = new BAL_ConsultationAddTreatment();
        BAL_DoctorsDetails pbjD = new BAL_DoctorsDetails();
        BAL_Patient objp = new BAL_Patient();
        Notificationnew objN = new Notificationnew();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessages", "alert('Your software will be expired on 20-06-2019')", true);

                objcommon.UserLoginhistory(SessionUtilities.Empid, SessionUtilities.RoleID);
                bindYear();
                FollowupNo();
                BindChart();
                BindASSIGNENQUIRIES();
                BINDPENDINGFOLLOWUPS();
                bindDoctorByClinic();
                PatientNo();
                // bindpatient();
                TotalInvoice();
                TotalExpense();
                getAllEnquiry();
                TotalTodayAppoimnet();
                bindYear();
                GridTodayAppoinmentget();

                DataTable Dt = pbjD.GetDocInTimeOutTimeNew(0, Convert.ToInt32(SessionUtilities.Empid));


                if (Dt != null && Dt.Rows.Count > 0)
                {

                    DataTable Dt123 = pbjD.GetDocInTimeOutDetails(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(SessionUtilities.Empid));
                    if (Dt123 != null && Dt123.Rows.Count > 0)
                    {
                        lblDate.Text = "Out Date" + Dt123.Rows[0]["AtdnDate"].ToString();
                        lblTime.Text = "Out Time" + Dt123.Rows[0]["TimeOut"].ToString();
                        ddlClinic.SelectedValue = Dt123.Rows[0]["ClinicID"].ToString();
                    }
                }
                else
                {
                    DataTable Dt43 = pbjD.GetDocInTimeOutTime(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(SessionUtilities.Empid));
                    if (Dt43 != null && Dt43.Rows.Count > 0)
                    {
                        lblDate.Text = "In Date " + Dt43.Rows[0]["AtdnDate"].ToString();
                        lblTime.Text = "In Time " + Dt43.Rows[0]["TimeIn"].ToString();

                        ddlClinic.SelectedValue = Dt43.Rows[0]["ClinicID"].ToString();
                    }
                }
            }


        }


        public void bindYear()
        {

            DataTable dt = objcommon.GetYear();



            ddlyear.DataSource = dt;
            ddlyear.DataTextField = "YearName";
            ddlyear.DataValueField = "Yearid";
            ddlyear.DataBind();
            ddlyear.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlyear.SelectedItem.Text = (System.DateTime.Now.Year).ToString();



            ddlyesrEXP1.DataSource = dt;
            ddlyesrEXP1.DataTextField = "YearName";
            ddlyesrEXP1.DataValueField = "Yearid";
            ddlyesrEXP1.DataBind();

            ddlyesrEXP1.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlyesrEXP1.SelectedItem.Text = (System.DateTime.Now.Year).ToString();


            ddlYEARENQ.DataSource = dt;
            ddlYEARENQ.DataTextField = "YearName";
            ddlYEARENQ.DataValueField = "Yearid";
            ddlYEARENQ.DataBind();

            ddlYEARENQ.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlYEARENQ.SelectedItem.Text = (System.DateTime.Now.Year).ToString();


        }


        //public void bindpatient()
        //{

        //    DataTable dt = objp.GetPatientlist();



        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        ddlpatient.DataSource = dt;
        //        ddlpatient.DataTextField = "FristName";
        //        ddlpatient.DataValueField = "patientid";
        //        ddlpatient.DataBind();
        //    }
        //    ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));

        //}


        public void BindPatient()
        {
            ddlpatient1.DataSource = objp.NewGetPatientlist(Convert.ToInt32(ddlClinic.SelectedValue));
            ddlpatient1.DataTextField = "Fname";
            ddlpatient1.DataValueField = "patientid";
            ddlpatient1.DataBind();
            ddlpatient1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        protected void ddlClinic_SelectedIndexChanged1(object sender, EventArgs e)
        {

            BindPatient();
        }

        public void bindDoctorByClinic()
        {

            DataTable dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);

            if (dt != null && dt.Rows.Count > 0)
            {
                ddlClinic.DataSource = dt;
                ddlClinic.DataTextField = "ClinicName";
                ddlClinic.DataValueField = "ClinicID";
                ddlClinic.DataBind();
            }
            ddlClinic.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }

        public void getAllEnquiry()
        {

            int Did = 0;

            if (SessionUtilities.RoleID == 3)
            {
                Did = SessionUtilities.Empid;
            }
            else
            {

                Did = 0;

            }

            AllData = objENQ.GetAllEnquiryByAssignToDoctor(Did, ddlYEARENQ.SelectedItem.Text);


            if (AllData != null && AllData.Rows.Count > 0)
            {
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }

        }
        protected void ddlYEARENQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllEnquiry();
        }
        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllEnquiry();
        }

        public void BindASSIGNENQUIRIES()
        {

            int Eno = objcommon.GetASSIGNENQUIRIES1(SessionUtilities.Empid);
            lblEnq.Text = Eno.ToString();
        }

        public void PatientNo()
        {

            int Eno = objcommon.GetPatientCountDocterCount(SessionUtilities.Empid);
            lblPatient.Text = Eno.ToString();
        }

        public void FollowupNo()
        {

            int Eno = objcommon.GetFollowupCountNoNew(Convert.ToInt32(SessionUtilities.Empid), Convert.ToInt32(SessionUtilities.RoleID));
            lblFollwupCOunt.Text = Eno.ToString();
        }


        public void BINDPENDINGFOLLOWUPS()
        {

            int Eno = objcommon.GetPENDINGFOLLOWUPS(SessionUtilities.Empid);
            lblpendingFollowup.Text = Eno.ToString();
        }

        public void TotalInvoice()
        {

            decimal Totalinv = objcommon.GetTotalPaidAmountDocter(SessionUtilities.Empid);

            if (Totalinv != 0)
            {
                totalRevenue.Text = Totalinv.ToString("#,##0.00");
            }
            else
            {

                totalRevenue.Text = "0.00";
            }
        }

        public void TotalExpense()
        {

            decimal TotalExp = objcommon.GetTotalExpenseDocter(SessionUtilities.Empid);

            if (TotalExp != 0)
            {
                lblExp.Text = TotalExp.ToString("#,##0.00");
            }
            else
            {

                lblExp.Text = "0.00";
            }
        }


        public void TotalTodayAppoimnet()
        {

            int Eno = objcommon.GetTotalNoofAppoinmentNo(SessionUtilities.Empid);
            lblTotalTodayAppoiment.Text = Eno.ToString();
        }


        public void GridTodayAppoinmentget()
        {

            int Did = 0;

            if (SessionUtilities.RoleID == 3)
            {
                Did = SessionUtilities.Empid;
            }
            else
            {
                Did = 0;

            }


            AllData = objApp.GetAlltodayAppoinmentNewDocter(Did);
            if (AllData != null && AllData.Rows.Count > 0)
            {

                GridAppoinment.DataSource = AllData;
                GridAppoinment.DataBind();
            }
        }

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

        protected void GridAppoinment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Aid = Convert.ToInt32(e.CommandArgument);
            string msg;

            if (e.CommandName == "Approve")
            {

                int _isDeleted = objApp.GetApprove(Aid);


                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblpatientid = (Label)gvRow.FindControl("lblpatientid");
                Label lblstart_date = (Label)gvRow.FindControl("lblstart_date");
                Label lblstart_Time = (Label)gvRow.FindControl("lblstart_Time");


                DataTable DTP = objp.GetPatient(Convert.ToInt32(lblpatientid.Text));

                msg = "Your Appointment Date :" + lblstart_date.Text + " " + "Time : " + lblstart_Time.Text + " has been Approved";

                objN.SendMessage(lblpatientid.Text, DTP.Rows[0]["registrationToken"].ToString(), msg, "Approved Appointment", "1");

                Response.Redirect("DocterDashboard.aspx");

            }
            if (e.CommandName == "Reject")
            {


                int _isDeleted = objApp.GetReject(Aid);


                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblpatientid = (Label)gvRow.FindControl("lblpatientid");
                Label lblstart_date = (Label)gvRow.FindControl("lblstart_date");
                Label lblstart_Time = (Label)gvRow.FindControl("lblstart_Time");


                DataTable DTP = objp.GetPatient(Convert.ToInt32(lblpatientid.Text));

                msg = "Your Appointment Date :" + lblstart_date.Text + " " + "Time : " + lblstart_Time.Text + " has been Rejected";

                objN.SendMessage(lblpatientid.Text, DTP.Rows[0]["registrationToken"].ToString(), msg, " Reject Appointment", "2");



                Response.Redirect("DocterDashboard.aspx");
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/fullcalendar/demos/NewAppointmentClinic.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Master/AppointmentList.aspx");
        }

        public void getAllGallery()
        {

            AllData = objCT.GetPTGallery(Convert.ToInt32(ddlpatient1.SelectedValue));
            grdProducts.DataSource = AllData;
            grdProducts.DataBind();

        }
        protected void ddlpatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllGallery();
        }



        //--------------------------------------------------------- Bar Chart----------



        protected void ddlyesrEXP1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChart();
        }

        private DataTable GetData()
        {
            string conn = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
            DataTable dt = new DataTable();

            string cmd = "Select * from ( Select  M.MonthsName, Sum(IM.PaidAmount) COLLECTION  from  MonthsMaster M Left  join InvoiceMaster IM on M.MonthsName = MONTH(IM.PayDate) where IM.DoctorID ='" + SessionUtilities.Empid + "' "
        + " Group by MonthsName ) T1 "
        + " Join (Select  M.MonthsName, Sum(IM.Amount) EXPENSES from  MonthsMaster M "
        + "  Left  join ExpenseMaster IM on M.MonthsName = MONTH(IM.ExpDate) where YEAR(IM.ExpDate) ='" + ddlyesrEXP1.SelectedItem.Text + "' "
        + " Group by MonthsName )T2 "
        + " ON T1.MonthsName = T2 .MonthsName ";


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

        data.addColumn('string', 'MonthsName');

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


        //---------------------------------------------------Pai Chart -------------------------

        protected void btnTimeIn_Click(object sender, EventArgs e)
        {

            try
            {
                int _isInserted = -1;

                var zone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                var timeInIndia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zone);
                var timeInIndiaAsString = timeInIndia.ToString("hh:mm tt", CultureInfo.InvariantCulture);

                _isInserted = pbjD.SaveDoctorAttendanceIntime(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(SessionUtilities.Empid), timeInIndiaAsString, System.DateTime.Now.ToString("dd-MM-yyyy"));


                if (_isInserted == -1)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Login", "alert('Failed to Add Attendance')", true);
                }
                else
                {

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Login", "alert('Attendance Added Successfully')", true);

                    DataTable Dt = pbjD.GetDocInTimeOutTime(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(SessionUtilities.Empid));

                    lblDate.Text = "In Date " + Dt.Rows[0]["AtdnDate"].ToString();
                    lblTime.Text = "In Time " + Dt.Rows[0]["TimeIn"].ToString();

                    ddlClinic.SelectedValue = Dt.Rows[0]["ClinicID"].ToString();



                }


            }
            catch (Exception ex)
            {
            }
        }


        protected void btnTimeOut_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;

                var zone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                var timeInIndia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zone);
                var timeInIndiaAsString = timeInIndia.ToString("hh:mm tt", CultureInfo.InvariantCulture);


                //_isInserted = pbjD.SaveDoctorAttendanceOuttime(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(SessionUtilities.Empid), timeInIndiaAsString, System.DateTime.Now.ToString("dd-MM-yyyy"));


                _isInserted = pbjD.SaveDoctorAttendanceOuttime(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(SessionUtilities.Empid), timeInIndiaAsString, System.DateTime.Now.ToString("dd-MM-yyyy"));


                if (_isInserted == -1)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Login", "alert('Failed to Add Attendance')", true);
                }
                else
                {

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Login", "alert('Attendance Added Successfully')", true);

                    DataTable Dt = pbjD.GetDocInTimeOutDetails(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(SessionUtilities.Empid));

                    lblDate.Text = "Out Date  " + Dt.Rows[0]["AtdnDate"].ToString();
                    lblTime.Text = "Out Time  " + Dt.Rows[0]["TimeOut"].ToString();
                    ddlClinic.SelectedValue = Dt.Rows[0]["ClinicID"].ToString();



                }


            }
            catch (Exception ex)
            {
            }

        }
    }
}