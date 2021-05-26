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
namespace OrthoSquare.Dashboard
{
    public partial class BranchDashboard : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        public static DataTable AllData = new DataTable();
        BAL_EnquirySource objES = new BAL_EnquirySource();
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        BAL_Appointment objApp = new BAL_Appointment();
        BAL_ConsultationAddTreatment objCT = new BAL_ConsultationAddTreatment();
        BAL_Treatment objT = new BAL_Treatment();
        BAL_Patient objp = new BAL_Patient();
        Notificationnew objN = new Notificationnew();
        NewOrthoSquare2210Entities db;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
              //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMsg", "alert('Your software will be expired on 20-06-2019')", true);

                objcommon.UserLoginhistory(SessionUtilities.Empid, SessionUtilities.RoleID);

                bindYear();
                bindMonths();
                FollowupNo();
                EnqNo();
                DocterNo();
                PatientNo();
                bindpatient();
                BindChart();
                getAllGallery();
                //  bindDoctorMaster();
                TotalInvoice();
                TotalExpense();
                BindFolloupview();
                getAllTreatmentPatientCount();
                TotalTodayAppoimnet();

                GridTodayAppoinmentget();

            }
        }
        
        public void TotalTodayAppoimnet()
        {

            int Eno = objcommon.GetTotalNoofAppoinmentNo(SessionUtilities.Empid);
            lblTotalTodayAppoiment.Text = Eno.ToString();
        }

        public void FollowupNo()
        {

            int Eno = objcommon.GetFollowupCountNoNew(Convert.ToInt32(SessionUtilities.Empid), Convert.ToInt32(SessionUtilities.RoleID));
            lblFollwupCOunt.Text =  Eno.ToString();
        }

        public void EnqNo()
        {

            int Eno = objcommon.GetEnquiryCountNoNew(SessionUtilities .Empid);
            lblEnq.Text = Eno.ToString();
        }
        
        public void TotalInvoice()
        {

            decimal Totalinv = objcommon.GetTotalPaidAmount(SessionUtilities.Empid);

            if (Totalinv != 0)
            {
                totalinvoice.Text = Totalinv.ToString("N", CultureInfo.GetCultureInfo("en-IN")); 
            }
            else
            {

                totalinvoice.Text = "0.00";
            }
        }
        
        public void TotalExpense()
        {

            decimal  TotalExp = objcommon.GetTotalExpense(SessionUtilities.Empid);

            if (TotalExp != 0)
            {
                lblExp.Text = TotalExp.ToString("N", CultureInfo.GetCultureInfo("en-IN")); 
            }
            else
            {

                lblExp.Text = "0.00";
            }
        }
        
        public void DocterNo()
        
        {

            int Eno = objcommon.GetDoctorMax_NoNew(SessionUtilities.Empid);
            lblDoctors.Text = Eno.ToString();
        }

        public void PatientNo()
        {

            int Eno = objcommon.GetPatientCount_NoNew(SessionUtilities.Empid);
            lblPatient.Text = Eno.ToString();
        }
        
        public void bindYear()
        {

            DataTable dt = objcommon.GetYear();



                ddlyear.DataSource = dt;
                ddlyear.DataTextField = "YearName";
                ddlyear.DataValueField = "Yearid";
                ddlyear.DataBind();
                ddlyear.Items.Insert(0, new ListItem("--- Select ---", "0"));
                ddlyear.SelectedItem.Text = (System.DateTime.Now.Year).ToString ();



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

        public void bindMonths()
        {

            DataTable dt = objcommon.GetMonths();


            if (dt != null && dt.Rows.Count > 0)
            {
                ddlMonth.DataSource = dt;
                ddlMonth.DataTextField = "MonthsName";
                ddlMonth.DataValueField = "MonthID";
                ddlMonth.DataBind();
            }
            ddlMonth.Items.Insert(0, new ListItem("--- Select ---", "0"));
            ddlMonth.SelectedItem.Text = (System.DateTime.Now.Month).ToString();

        }

        public void bindpatient()
        {

            
            DataTable dt = objp.NewGetPatientlist(Convert.ToInt32(SessionUtilities.Empid));
           

            if (dt != null && dt.Rows.Count > 0)
            {
                ddlpatient1.DataSource = dt;
                ddlpatient1.DataTextField = "Fname";
                ddlpatient1.DataValueField = "patientid";
                ddlpatient1.DataBind();
            }
            ddlpatient1.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }


        public void BindFolloupview()
        {

            GridViewFolloupDetils1.DataSource = objENQ.GetViewAllEnquiryFollowup(Convert.ToInt32(SessionUtilities.Empid), Convert.ToInt32(SessionUtilities.RoleID));
            GridViewFolloupDetils1.DataBind();



        }

        protected void GridViewFolloupDetils1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFolloupDetils1.PageIndex = e.NewPageIndex;
            BindFolloupview();
        }

        public void getAllTreatmentPatientCount()
        {
            string DID= "0";
            DataTable dt = objT.GetDoctorByClinicnew(SessionUtilities.Empid);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DID += dt.Rows[i]["DoctorID"] + ",";

                }

                if (DID != "")
                {
                    DID = DID.Remove(DID.Length - 1);
                }
            }

            DataTable AllData1 = objT.GetTreatmentPatientCount(ddlyear .SelectedItem .Text, ddlMonth.SelectedItem .Text, DID);

         
                GridTREATMENTWISEPATIENT.DataSource = AllData1;
                GridTREATMENTWISEPATIENT.DataBind();
          

        }
        
        protected void GridTREATMENTWISEPATIENT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridTREATMENTWISEPATIENT.PageIndex = e.NewPageIndex;
            getAllTreatmentPatientCount();
        }

        public void getAllGallery()
        {

            AllData = objCT.GetPTGallery(Convert.ToInt32(ddlpatient1.SelectedValue));
            grdProducts.DataSource = AllData;
            grdProducts.DataBind();

        }
        
        public void GridTodayAppoinmentget()
        {

            int Cid = 0;

            if (SessionUtilities.RoleID == 1)
            {
                Cid = SessionUtilities.Empid;
              
            }
            else
            {
                Cid = 0;
              

            }


            AllData = objApp.GetAlltodayAppoinmentNew(Cid);
            if (AllData != null && AllData.Rows.Count > 0)
            {
               
                GridAppoinment.DataSource = AllData;
                GridAppoinment.DataBind();
            }
        }
        
        protected void GridAppoinment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Aid = Convert.ToInt32(e.CommandArgument);
            string msg;
            if (e.CommandName == "Approve")
            {

                
                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblpatientid = (Label)gvRow.FindControl("lblpatientid");
                Label lblstart_date = (Label)gvRow.FindControl("lblstart_date");
                Label lblstart_Time = (Label)gvRow.FindControl("lblstart_Time");
                int _isDeleted = objApp.GetApprove(Aid);


                 DataTable DTP =  objp.GetPatient(Convert.ToInt32(lblpatientid.Text));

                msg = "Your Appoinment Date :" + lblstart_date.Text + " " + "Time : " + lblstart_Time.Text + " has been Approved"; 
               

               // PushNotification(Convert.ToInt32(lblpatientid.Text), "Approved Appoinment", msg);
                objN.SendMessage(lblpatientid.Text, DTP.Rows[0]["registrationToken"].ToString(), msg, " Approved Appoinment","1");
                
                Response.Redirect("BranchDashboard.aspx");
             
            }
            if (e.CommandName == "Reject")
            {

                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblpatientid = (Label)gvRow.FindControl("lblpatientid");
                Label lblstart_date = (Label)gvRow.FindControl("lblstart_date");
                Label lblstart_Time = (Label)gvRow.FindControl("lblstart_Time");

                int _isDeleted = objApp.GetReject(Aid);
                DataTable DTP = objp.GetPatient(Convert.ToInt32(lblpatientid.Text));

                msg = "Your Appoinment Date :" + lblstart_date.Text + " " + "Time : " + lblstart_Time.Text + " has been Reject";

                objN.SendMessage(lblpatientid.Text, DTP.Rows[0]["registrationToken"].ToString(), msg, " Reject Appoinment","2");
                

                Response.Redirect("BranchDashboard.aspx");
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
      
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/fullcalendar/demos/NewAppointmentClinic.aspx");
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Master/AppointmentList.aspx");
        }


        
        protected void ddlYEARENQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getAllEnquiry();
        }

        protected void ddlpatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllGallery();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllTreatmentPatientCount();
            BindChart();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllTreatmentPatientCount();
            BindChart();
        }

        protected void ddlyesrEXP11_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChart();
        }
        private DataTable GetData()
        {
            string conn = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
            DataTable dt = new DataTable();

            string cmd = "Select * from ( Select  M.MonthsName, Sum(IM.PaidAmount) COLLECTION  from  MonthsMaster M Left  join InvoiceMaster IM on M.MonthsName = MONTH(IM.PayDate) where IM.ClinicID ='" + SessionUtilities.Empid + "' and  YEAR(IM.PayDate) ='"+ddlyesrEXP1.SelectedItem .Text +"' "
        + " Group by MonthsName ) T1 "
        + " Join (Select  M.MonthsName, Sum(IM.Amount) EXPENSES from  MonthsMaster M "
        + "  Left  join ExpenseMaster IM on M.MonthsName = MONTH(IM.ExpDate)  where YEAR(IM.ExpDate) ='" + ddlyesrEXP1.SelectedItem.Text + "' "
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


        public void PushNotification(int patientid, string Title, string Message)
        {

            try
            {
                string strTitle = Title;
                string strBody = Message;

                string applicationID = ConfigurationManager.AppSettings["applicationId1"];
                string senderId = ConfigurationManager.AppSettings["senderId1"];

                //string deviceId = "ba92be2da78e7285";

                db = new NewOrthoSquare2210Entities();
                var res = (from P in db.PatientMasters
                           where P.patientid == patientid
                           select P).ToList();
                if (res != null)
                {
                    foreach (var item in res)
                    {
                        string regToken = item.registrationToken;
                        string useridname = item.patientid .ToString() + " " + item.FristName;
                        string logs = "";

                        if (!string.IsNullOrEmpty(regToken))
                        {
                            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                            tRequest.Method = "post";
                            tRequest.ContentType = "application/json";
                            var data = new
                            {
                                //to = deviceId,
                                to = regToken,
                                notification = new
                                {
                                    title = strTitle,
                                    body = strBody,
                                    sound = "Enabled"
                                }
                            };

                            var serializer = new JavaScriptSerializer();
                            var json = serializer.Serialize(data);
                            Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                            //tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                            tRequest.Headers.Add("Authorization: key=" + applicationID);
                            //tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                            tRequest.Headers.Add("Sender: id=" + senderId);

                            tRequest.ContentLength = byteArray.Length;
                            using (Stream dataStream = tRequest.GetRequestStream())
                            {
                                dataStream.Write(byteArray, 0, byteArray.Length);
                                using (WebResponse tResponse = tRequest.GetResponse())
                                {
                                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                    {
                                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                        {
                                            String sResponseFromServer = tReader.ReadToEnd();
                                            string str = sResponseFromServer;

                                            logs = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")); ;
                                            logs += Environment.NewLine;
                                            logs += useridname;
                                            logs += Environment.NewLine;
                                            logs += str;
                                            logs += Environment.NewLine;
                                            logs += "-----------------------------------------------------------";
                                            logs += Environment.NewLine;

                                            string path = Server.MapPath("~/PushNotificationLogs/notificationlogs.txt");

                                            using (StreamWriter writer = new StreamWriter(path, true))
                                            {
                                                writer.WriteLine(logs);
                                                writer.Close();
                                            }

                                        }
                                    }
                                }
                            }
                        }

                    } //end of foreach loop
                  //  lblmsg.Text = "Message has been sent successfully";
                }

            }
            catch (Exception ex)
            {
                string str = ex.Message;
              //  lblmsg.Text = str;
            }
        }




    }
}