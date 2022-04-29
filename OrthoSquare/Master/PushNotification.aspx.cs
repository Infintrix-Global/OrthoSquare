using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.Data;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;
using OrthoSquare.BAL_Classes;

namespace OrthoSquare.Master
{
    public partial class PushNotification : System.Web.UI.Page
    {
        OrthosquareEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAdd_Click(object sender, EventArgs e)
        {

            try
            {
                string strTitle = txtTitle.Text;
                string strBody = txtMessage.Text;
                Notificationnew objN = new Notificationnew();
               
                //string deviceId = "ba92be2da78e7285";

                db = new OrthosquareEntities();
                var res = (from k in db.PatientMasters
                           select k).ToList();
                if (res != null)
                {
                    foreach (var item in res)
                    {
                        string regToken = item.registrationToken;
                        string useridname = item.patientid.ToString() + " " + item.FristName;
                        string logs = "";

                        if (!string.IsNullOrEmpty(regToken))
                        {
                           

                                 objN.SendMessage((item.patientid).ToString (),regToken,strBody, strTitle,"6");

                        }
                    }

                    lblMessage.Text = "Message has been sent successfully";

                }

            }
            catch (Exception ex)
            {
                string str = ex.Message;
                //lblMessage.Text = str;

            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtTitle.Text="";
            txtMessage.Text="";
        }
    }
}