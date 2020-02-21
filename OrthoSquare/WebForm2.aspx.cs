using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web.UI.WebControls;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;

using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
namespace OrthoSquare
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SendMail();
            
        }


        protected void SendMail()
        {

           
            var fromAddress = "infintrix.world@gmail.com";
           
            var toAddress = "mehulrana1901@gmail.com";

         
            const string fromPassword = "Infintrixworld@123";
            
            string subject = "Your UserName and Password For OrthoSquare";
       

               string body = " ";
              
              body += "<div> Mehul RANA </DIV>";
              body += "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
              body += " <tr> <td bgcolor='#ffffff' align='center'> ";
               
              body += " ";
              body += " ";


              body += " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width:800px;' class='wrapper'> ";
              body += "    <tr>   <td align='left' valign='top' width='120' style='padding: 15px 0;'>   <img alt='Logo' src='logo.png' width='100' height'100' style='display: block;'>  </td>";
              body += " <td width='410'> <p style='font-size:14px; font-family: Helvetica, Arial, sans-serif; color:#4D4B4B; line-height:1.4'><span style='font-size:16px; font-family: Helvetica, Arial, sans-serif; font-weight:600; color:#4D4B4B; padding-top: 30px;'> Orthosquare Multispeciality Dental Clinic pvt ltd</span><br> ";
              body += " <p style='font-size:14px; font-family: Helvetica, Arial, sans-serif; color:#4D4B4B; line-height:1.4'><span style='font-size:16px; font-family: Helvetica, Arial, sans-serif; font-weight:600; color:#4D4B4B; padding-top: 30px;'> Orthosquare Multispeciality Dental Clinic pvt ltd</span><br>";
              body += "MAC near Rudharax Residency<br>  9016995488, aa@gmail.com </p> </td>";
              body += "<td width='120'><p style='font-size:14px; font-family: Helvetica, Arial, sans-serif; color:#4D4B4B; line-height:1.4'>Date: 05-10-2018<br> No. INV5</p></td></tr>";
              body += " <tr><td colspan='3' width='600'><hr></td></tr></table></td></tr>";   
              body += " <tr>  <td bgcolor='#ffffff' align='center' style='padding: 0px;'>   <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 800px;' class='responsive-table'>";     
              body += " <tr> <td>";
             
              body += " <table width='100%' border='0' cellspacing='0' cellpadding='0'>";
              body += "<tr> <td align='center' style='font-size:25px; text-transform:uppercase; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top:10px; padding-bottom:20px;' class='padding-copy'>Invoice</td> </tr> ";
              body += "<tr> <td>";

              body += "";
              
                       
               
            
            
            
          
             body += " </td> </tr>  </table>  </td> </tr>";

              
               
           
          
       


               body += "</table>";
             //  body += " </body>";
              // body += " </html> ";

            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 50000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }


        protected void Button21111_Click(object sender, EventArgs e)
        {
            SendEmail1();

        }

        private void SendEmail1()


        {


            //string Email = "mehulrana1901@gmail.com,nidhi.mehta@infintrixglobal.com,gaurav.jadhav@infintrixglobal.com,ankit.shah@infintrixglobal.com";
            string Email = "mehulrana1901@gmail.com";
            using (MailMessage mm = new MailMessage("mmtiadmin@mmti.co.in", Email))
            {

                mm.Subject = "Ortho Invoice" + "";
                mm.Body = "<DIV> Mehul Rana</Div> <table border='0' cellpadding='0' cellspacing='0' width='100%'>  <tr> <td bgcolor='#ffffff' align='center'>"

                +"<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width:800px;' class='wrapper'>"
                + " <tr> <td align='left' valign='top' width='120' style='padding: 15px 0;'>   <img alt='Logo' src='logo.png' width='100' height'100' style='display: block;'>  </td>"

                + " <td width='410'> <p style='font-size:14px; font-family: Helvetica, Arial, sans-serif; color:#4D4B4B; line-height:1.4'><span style='font-size:16px; font-family: Helvetica, Arial, sans-serif; font-weight:600; color:#4D4B4B; padding-top: 30px;'> Orthosquare Multispeciality Dental Clinic pvt ltd</span><br> "
                
                + "MAC near Rudharax Residency<br>  9016995488, aa@gmail.com </p> </td>"
                 + "<td width='120'><p style='font-size:14px; font-family: Helvetica, Arial, sans-serif; color:#4D4B4B; line-height:1.4'>Date: 05-10-2018<br> No. INV5</p></td></tr>"
                 + " <tr><td colspan='3' width='600'><hr></td></tr></table></td></tr>"
                 + " <tr>  <td bgcolor='#ffffff' align='center' style='padding: 0px;'>   <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 800px;' class='responsive-table'>"
                 + " <tr> <td>"

                 + " <table width='100%' border='0' cellspacing='0' cellpadding='0'>"
                 + "<tr> <td align='center' style='font-size:25px; text-transform:uppercase; font-family: Helvetica, Arial, sans-serif; color: #333333; padding-top:10px; padding-bottom:20px;' class='padding-copy'>Invoice</td> </tr> "
                 + "<tr> <td>"
                 + "<table cellspacing='0' cellpadding='0' border='0' width='100%'><tr><td valign='top' class='mobile-wrapper'><td valign='top' class='mobile-wrapper'>"    
                 +" <table cellpadding='0' cellspacing='0' border='0' width='27%' style='width: 27%;' align='left'>  <tr><td style='padding: 0 0 0px 0;'>"                
                 +" <table cellpadding='0' cellspacing='0' border='0' width='100%'><tr> <td align='left' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; line-height:1.4'>"                       
                 +"  <p>Kantaben Rana<br>  Patient ID: P01<br> 7069885544<br>  mm@gmail.com<br><br> <strong> By Dr. Ronak Amjed</strong></p>"                        
                 +"</td></tr></table></td></tr></table>"                             
                 +" <table cellpadding='0' cellspacing='0' border='0' width='27%' style='width: 27%;' align='left'>   <tr>     <td style='padding: 0 0 0px 0;'>"                       
                 +" <table cellpadding='0' cellspacing='0' border='0' width='100%'> <tr> <td align='right' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; line-height:1.4'>"
                 +" Female: 29 years<br>     Blood Group:Test  "
                 + "</td> </tr></table> </td></tr> </table> </td> </tr></table>"             
                                          
                

                 + " </td> </tr>  </table>  </td> </tr>"



                 +"<tr> <td bgcolor='#ffffff' align='center' style='margin-bottom:15px;'>"
           
                 +"<table cellpadding='5' cellspacing='6' width='100%' style='max-width: 800px; border:1px solid #939292;' class='responsive-table'>"
           //---inv  
  

                  








                 +"<tr style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700;  background:#CBC8C8; border-bottom:1px solid #929191;'>"
                +" <td>Sr.no.</td><td>Treatments & Products</td> <td>Unit</td> <td>Cost INR</td><td>Discount</td> <td>Tax INR (12 %)</td> <td>Total Cost INR</td> </tr>"
             
                 +"<tr style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>"            
                +"<td>1</td><td>Crowns and Bridges</td><td>1</td><td>5,000.00</td><td>1.00</td> <td>599.88</td>  <td>5,598.88</td> </tr>"
                 //---
                +"  </table> </td>  </tr>"
                +" <tr> <td bgcolor='#ffffff' align='center'>"
                        
             //------------------
                +" <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 800px;' class='responsive-table'>"
                +"<tr>   <td style='padding: 20px 0 0 0;'>"
                
             
           +"<table cellspacing='0' cellpadding='0' border='0' width='100%'> <tr><td valign='top' class='mobile-wrapper'>"
                                   
           +" <table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='left'><tr><td style='padding: 0 0 10px 0;'>"
           +"<table cellpadding='0' cellspacing='0' border='0' width='100%'> <tr>"
            +"<td align='left' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>Total</td>"
             +"</tr> </table></td> </tr></table>"
           
            +"<table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='right'><tr> <td style='padding: 0 0 10px 0;'>"
            +"<table cellpadding='0' cellspacing='0' border='0' width='100%'>  " 
            +"<td align='right' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px;'> 5,000.00</td> </tr>"                                 
            +" </table></td></tr> </table> </td></tr> "  
                    
              //--------------------------------      

               + "<tr>   <td>"


           + "<table cellspacing='0' cellpadding='0' border='0' width='100%'> <tr><td valign='top' class='mobile-wrapper'>"

           + " <table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='left'><tr><td style='padding: 0 0 10px 0;'>"
           + "<table cellpadding='0' cellspacing='0' border='0' width='100%'> <tr>"
            + "<td align='left' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>Less Discount</td>"
             + "</tr> </table></td> </tr></table>"

            + "<table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='right'><tr> <td style='padding: 0 0 10px 0;'>"
            + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>  "
            + "<td align='right' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px;'> 1.00</td> </tr>"
            + " </table></td></tr> </table> </td></tr> "  
           
            //--------------------------------------------
               + "<tr>   <td >"


           + "<table cellspacing='0' cellpadding='0' border='0' width='100%'> <tr><td valign='top' class='mobile-wrapper'>"

           + " <table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='left'><tr><td style='padding: 0 0 10px 0;'>"
           + "<table cellpadding='0' cellspacing='0' border='0' width='100%'> <tr>"
            + "<td align='left' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>Taxable Total</td>"
             + "</tr> </table></td> </tr></table>"

            + "<table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='right'><tr> <td style='padding: 0 0 10px 0;'>"
            + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>  "
            + "<td align='right' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px;'>4,999.00</td> </tr>"
            + " </table></td></tr> </table> </td></tr> "  
            //--------------------------------------------
              + "<tr>   <td >"


           + "<table cellspacing='0' cellpadding='0' border='0' width='100%'> <tr><td valign='top' class='mobile-wrapper'>"

           + " <table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='left'><tr><td style='padding: 0 0 10px 0;'>"
           + "<table cellpadding='0' cellspacing='0' border='0' width='100%'> <tr>"
            + "<td align='left' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>Total Tax(12%)</td>"
             + "</tr> </table></td> </tr></table>"

            + "<table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='right'><tr> <td style='padding: 0 0 10px 0;'>"
            + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>  "
            + "<td align='right' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px;'> 599.88</td> </tr>"
            + " </table></td></tr> </table> </td></tr> " 
            //---------------------------------------------------

              + "<tr>   <td >"


           + "<table cellspacing='0' cellpadding='0' border='0' width='100%'> <tr><td valign='top' class='mobile-wrapper'>"

           + " <table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='left'><tr><td style='padding: 0 0 10px 0;'>"
           + "<table cellpadding='0' cellspacing='0' border='0' width='100%'> <tr>"
            + "<td align='left' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>Total Amount</td>"
             + "</tr> </table></td> </tr></table>"

            + "<table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='right'><tr> <td style='padding: 0 0 10px 0;'>"
            + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>  "
            + "<td align='right' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px;'> 5,598.88</td> </tr>"
            + " </table></td></tr> </table> </td></tr> "
                    //---------------------------------------------------
                      + "<tr>   <td >"


           + "<table cellspacing='0' cellpadding='0' border='0' width='100%'> <tr><td valign='top' class='mobile-wrapper'>"

           + " <table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='left'><tr><td style='padding: 0 0 10px 0;'>"
           + "<table cellpadding='0' cellspacing='0' border='0' width='100%'> <tr>"
            + "<td align='left' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>Amount Received</td>"
             + "</tr> </table></td> </tr></table>"

            + "<table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='right'><tr> <td style='padding: 0 0 10px 0;'>"
            + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>  "
            + "<td align='right' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px;'> 5,598.88</td> </tr>"
            + " </table></td></tr> </table> </td></tr> "
                    //---------------------------------------------------
                      + "<tr>   <td >"


           + "<table cellspacing='0' cellpadding='0' border='0' width='100%'> <tr><td valign='top' class='mobile-wrapper'>"

           + " <table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='left'><tr><td style='padding: 0 0 10px 0;'>"
           + "<table cellpadding='0' cellspacing='0' border='0' width='100%'> <tr>"
            + "<td align='left' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>Balance Amount</td>"
             + "</tr> </table></td> </tr></table>"

            + "<table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='right'><tr> <td style='padding: 0 0 10px 0;'>"
            + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>  "
            + "<td align='right' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px;'>3598.88</td> </tr>"
            + " </table></td></tr> </table> </td></tr> "
                    //---------------------------------------------------

               + "<tr>   <td >"


           + "<table cellspacing='0' cellpadding='0' border='0' width='100%'> <tr><td valign='top' class='mobile-wrapper'>"

           + " <table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='left'><tr><td style='padding: 0 0 10px 0;'>"
           + "<table cellpadding='0' cellspacing='0' border='0' width='100%'> <tr>"
            + "<td align='left' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>Net Amount(in Words)</td>"
             + "</tr> </table></td> </tr></table>"

            + "<table cellpadding='0' cellspacing='0' border='0' width='47%' style='width: 47%;' align='right'><tr> <td style='padding: 0 0 10px 0;'>"
            + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>  "
            + "<td align='right' style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px;'>Rupees Two Thousand Only</td> </tr>"
            + " </table></td></tr> </table> </td></tr> "
                    //---------------------------------------------------
            + "</table></td></tr>"


             +" <tr> <td bgcolor='#ffffff' align='0center' style='padding-top:25px;'> <table cellpadding='5' cellspacing='6' width='100%' style='max-width: 800px;' class='responsive-table'>"
 +"<tr style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700; border-top:1px solid #929191;border-bottom:1px solid #929191;'>"
 +"<td>#</td> <td>Date</td><td>Payment Mode</td> <td>Amount Paid INR</td> <td>Amount Pending    </tr>"
 +"<tr style='font-family: Helvetica, Arial, sans-serif; color: #333333; font-size: 14px; font-weight:700'>"          
 +" <td>1</td><td>25-09-2018</td><td>Cash</td><td>2,000.00</td> <td>3,598.88</td></tr>  </table></td> </tr>"  

                + "</table>";
                
                
                
                mm.IsBodyHtml = true;
               // mm.To ="";
              //  SmtpClient smtp = new SmtpClient();
               // smtp.Host = "199.79.63.199";
               // smtp.Port = 25;
                //smtp.EnableSsl = true;
              //  smtp.EnableSsl = false;


               // smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
               // smtp.UseDefaultCredentials = true;

               // NetworkCredential NetworkCred = new NetworkCredential("mmtiadmin@mmti.co.in", "mmti@@123");
                //smtp.UseDefaultCredentials = true;
              //  smtp.Credentials = NetworkCred;

              //  smtp.Send(mm);

                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential("infintrix.world@gmail.com", "Infintrixworld@123");
                    smtp.Timeout = 50000;
                }
                // Passing values to smtp object
                smtp.Send(mm);

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Registion Details sent to .');" + Email, true);
            }

        }
    }
}