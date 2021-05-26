using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Text;
using OrthoSquare.BAL_Classes;
using System.Net;
namespace OrthoSquare.Utility
{
    public class BasePage
    {
        General objGeneral = new General();

        //public string DateFormat
        //{
        //    get { return SessionUtilities.DateFormatted; }
        //}
        //public string SuccessMsg { get { return ConfigurationManager.AppSettings["SuccMsg"]; } }
        //public string FailureMsg { get { return ConfigurationManager.AppSettings["FailMsg"]; } }
        public string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
        public string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }


        public int SendMail(string Email, string Username, string Password)
        {
            int IsReturn = 0;
            try
            {
                var fromAddress = "infintrix.vadodara@gmail.com";

                var toAddress = Email;

                const string fromPassword = "Igvadodara@123";
                // Passing the values and make a email formate to display
                string subject = "Your UserName and Password For ";
                string body = "Dear ," + "\n";
                body += "Your UserName and Password For OrthoSquare :" + "\n";
                body += "UserName : " + Username + " " + "\n\n";
                body += "Password : " + Password + " " + "\n\n";
                body += "Thank you!" + "\n";
                body += "Warm Regards," + "\n";

                // smtp settings
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
                IsReturn = 1;
            }
            catch (Exception ex)
            {
                //objGeneral.ErrorMessage("Error is=" + Convert.ToString(ex.Message));
                throw ex;
            }
            return IsReturn;
        }




    }
}