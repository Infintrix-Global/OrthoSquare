using OrthoSquare.BAL_Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrthoSquare
{
    public partial class SendMail : System.Web.UI.Page
    {
        General objG = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
           AreaManager();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AreaManager();

        }


        public void AreaManager()
        {

            NameValueCollection nv1 = new NameValueCollection();

            DataTable dt1 = objG.GetDataTable("GET_AreaManagerDetails", nv1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
              
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string EmailId = "";
                    string Name = "";
                    //EmailId = dt1.Rows[i]["Email"].ToString() + ",drshraddhakambale@gmail.com"; 

                    EmailId = dt1.Rows[i]["Email"].ToString() + ",MehulRana1901@Gmail.com,drshraddhakambale@gmail.com";
                    Name = dt1.Rows[i]["DoctorName"].ToString();


                    NameValueCollection nv = new NameValueCollection();
                    nv.Add("@ID", dt1.Rows[i]["DoctorId"].ToString());
                    nv.Add("@Mode","1");
                    DataTable dt = objG.GetDataTable("GET_ AreaManagerCollectionSenedMail", nv);

                    string textBody = "";
                    textBody = "Dear " + Name + "," + "<br>";
                    textBody += "Daily Collection Report :" + "<br>";
                    textBody += " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 800 + "><tr bgcolor='#4da6ff'><td><b>Clinic Name</b></td> <td> <b>New Patient</b> </td> <td> <b> New Enquiry</b> </td> <td> <b> Treatment Collection</b> </td>  <td> <b>Medicines Collection</b> </td> <td> <b>Total Collection</b> </td> </tr>";
                    for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                    {
                        DataTable dt11 = new DataTable();
                        dt11 = null;
                        NameValueCollection nv11 = new NameValueCollection();
                        nv11.Add("@ID", dt.Rows[loopCount]["ClinicId"].ToString());
                        nv11.Add("@Mode", "2");

                        dt11 = objG.GetDataTable("GET_ AreaManagerCollectionSenedMail", nv11);

                        textBody += "<tr><td>" + dt.Rows[loopCount]["ClinicName"] + "</td><td> " + dt11.Rows[0]["NoofPatient"] + "</td><td> " + dt11.Rows[0]["NoOfEnquiry"] + "</td> <td> " + dt11.Rows[0]["PaidAmount"] + "</td> <td> " + dt11.Rows[0]["MedicinesPaidAmount"] + "</td> <td> " + dt11.Rows[0]["Total"] + "</td> </tr>";
                    }

                    textBody += "</table>" + "<br>"; ;
                    textBody += "Thank you!" + "<br>";
                    textBody += "Warm Regards," + "<br>";

                    Send_Mail(EmailId, textBody);
                }
            }
            
        }

        protected void Send_Mail(string Email, string textBody)
        {
            string EmailFromAddress = ConfigurationManager.AppSettings["EmailFromAddress"].ToString();
            string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"].ToString();
            var fromAddress = EmailFromAddress;
            var toAddress = Email;
            string fromPassword = EmailPassword.ToString();

            string Date1 = System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            string subject = "Daily Log -"+ Date1;
            // string body = textBody;

            MailMessage mail = new MailMessage();
            System.Net.Mail.SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(EmailFromAddress);
            mail.To.Add(Email);
            mail.Subject = subject;
            mail.Body = textBody;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(EmailFromAddress, EmailPassword);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);


            //// smtp settings
            //var smtp = new System.Net.Mail.SmtpClient();
            //{
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;
            //    smtp.EnableSsl = true;
            //    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            //    smtp.Timeout = 50000;
            //}

            //smtp.Send(fromAddress, toAddress, subject, body);
        }



    }
}