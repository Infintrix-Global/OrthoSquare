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
using System.IO;
using System.Net;

namespace OrthoSquare.Enquiry1
{
    public partial class ViewEnquiry : System.Web.UI.Page
    {

        BAL_EnquiryDetails objEnq=new BAL_EnquiryDetails ();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack )
            {

                int Eid = Convert.ToInt32(Request.QueryString["Eid"]);
                
                bindEnqProfile(Eid);


            }
        }


        public void bindEnqProfile(int Eid)
        {


            DataTable dt1 = objEnq.GetEnquiryDetils123(Eid);

            if (dt1 != null && dt1.Rows.Count > 0)
            {

                lblName.Text = dt1.Rows[0]["FirstName"].ToString() + " " + dt1.Rows[0]["LastName"].ToString();
                lblClinicName.Text = dt1.Rows[0]["ClinicName"].ToString();
                lblAssignToEmpId.Text = dt1.Rows[0]["Dname"].ToString();
                lblConversation.Text = dt1.Rows[0]["Conversation"].ToString();
                if (dt1.Rows[0]["Folllowupdate"].ToString() != "")
                {
                    if (Convert.ToDateTime(dt1.Rows[0]["Folllowupdate"]).ToString("dd-MM-yyyy") == "01-01-1999")
                    {
                        lblFolllowupdate.Text = "";
                    }
                    else
                    {

                        lblFolllowupdate.Text = Convert.ToDateTime(dt1.Rows[0]["Folllowupdate"]).ToString("dd-MM-yyyy");
                    }
                }

                if (dt1.Rows[0]["DateBirth"].ToString() != "")
                {
                    if (Convert.ToDateTime(dt1.Rows[0]["DateBirth"]).ToString("dd-MM-yyyy") == "01-01-1999")
                    {
                        lblbirthDate.Text = "";
                    }
                    else
                    {
                        lblbirthDate.Text = Convert.ToDateTime(dt1.Rows[0]["DateBirth"]).ToString("dd-MM-yyyy");
                    }
                }
                lblConversation.Text = dt1.Rows[0]["Conversation"].ToString();
                lblStatus .Text = dt1.Rows [0]["Status"].ToString ();
                lblSource.Text = dt1.Rows[0]["Sourcename"].ToString();
                lblTreatment.Text = dt1.Rows[0]["TreatmentName"].ToString();
                lblAge .Text = dt1.Rows[0]["Age"].ToString();
                lblGender.Text = dt1.Rows[0]["Gender"].ToString();
              //  lblbirthDate.Text = Convert.ToDateTime(dt1.Rows[0]["DateBirth"]).ToString("dd-MM-yyyy") + "   Age : " + dt1.Rows[0]["Age"].ToString(); ;
                lblGender.Text = dt1.Rows[0]["Gender"].ToString();
                lblAddress.Text = dt1.Rows[0]["Address"].ToString() +"," + dt1.Rows[0]["Area"].ToString();
                lblMobileNo.Text = dt1.Rows[0]["Mobile"].ToString() + " ," + dt1.Rows[0]["Telephone"].ToString();
                lblEmail.Text = dt1.Rows[0]["Email"].ToString();
            }
        }
    }
}