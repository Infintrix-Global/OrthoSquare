using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace OrthoSquare.Report
{
    public partial class PatientCollectionReport : System.Web.UI.Page
    {

        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        BAL_Expense objExp = new BAL_Expense();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Patient objp = new BAL_Patient();
        decimal SumPaid = 0;
        decimal sumPendingValue = 0;
        decimal sumGrandValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = Convert.ToDateTime(System.DateTime.Now).AddDays(-5).ToString("dd-MM-yyyy");
                txtToDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                if (SessionUtilities.RoleID == 1)
                {
                    bindClinic();
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    bindDoctorMaster(SessionUtilities.Empid);
                   // ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));
                    getAllCollection();


                }
                else
                {
                    bindClinic();
                    ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

                    //  ddlClinic.Enabled = false;
                    // bindDoctorMaster(SessionUtilities.Empid);
                    getAllCollection();

                }
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
                dt = objc.GetAllClinicDetais();

            }
            ddlClinic.DataSource = dt;


            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        public void bindDoctorMaster(int Cid)
        {

            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDocter.DataSource = objcommon.DoctersMaster(Cid,SessionUtilities.RoleID);
               

            }
            else
            {
                ddlDocter.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);
               
            }




            
            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "DoctorName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
            getAllCollection();
        }



        public void getAllCollection()
        {

            //AllData = objExp.GetAllPatientCollectionReport(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDocter.SelectedValue),txtToDate .Text .Trim (),txtFromDate .Text .Trim (), txtPatientName.Text.Trim());

            AllData = objExp.GetAllPatientCollectionReport(txtFromDate.Text, txtToDate.Text, Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDocter.SelectedValue),Convert.ToInt32(PatientId));

            //gvShow.DataSource = AllData;
            //gvShow.DataBind();

            if (AllData != null && AllData.Rows.Count > 0)
            {
                for (int i = 0; i < AllData.Rows.Count; i++)
                {
                     SumPaid += Convert.ToDecimal(AllData.Rows[i]["PaidAmount"]);
                    sumPendingValue += Convert.ToDecimal(AllData.Rows[i]["PendingAmount"]);
                    sumGrandValue += Convert.ToDecimal(AllData.Rows[i]["GrandTotal"]);


                }
                lblGrandTotal.Text = sumGrandValue.ToString();
                lblPaid.Text = SumPaid.ToString();
                lblPending.Text = sumPendingValue.ToString();
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
            else
            {
                lblGrandTotal.Text = "0";
                lblPaid.Text = "0";
                lblPending.Text = "0";

                gvShow.DataSource = null;
                gvShow.DataBind();
            }



        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllCollection();

        }



        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            //   btSearch_Click(sender, e);
            getAllCollection();
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

           
        }


        private long PatientId
        {
            get
            {
                if (ViewState["PatientId"] != null)
                {
                    return (long)ViewState["PatientId"];
                }
                return 0;
            }
            set
            {
                ViewState["PatientId"] = value;
            }
        }
        protected void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objp.PatientSelect(txtPatientName.Text);
            PatientId = Convert.ToInt32(dt.Rows[0]["PatientId"]);
            getAllCollection();


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
                    int DoctorID = 0, ClinicId = 0;
                    int RoleId = Convert.ToInt32(HttpContext.Current.Session["RoleID"]);
                    DoctorID = Convert.ToInt32(HttpContext.Current.Session["Empid"]);
                    ClinicId = Convert.ToInt32(HttpContext.Current.Session["Empid"]);
                    int Cid = Convert.ToInt32(HttpContext.Current.Session["Cid"]);
                    if (RoleId == 1)
                    {
                        cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' as as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1 ";
                        cmd.CommandText += " and  P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')'  like '%" + prefixText + "%' and P.ClinicID ='" + ClinicId + "'";
                        cmd.CommandText += "order by patientid DESC ";
                    }
                    else if (RoleId == 3)
                    {

                        cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')'  as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1 and P.ClinicID ='" + Cid + "' and  P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' a  like '%" + prefixText + "%'";


                    }
                    else
                    {
                        cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1  and  P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')'  like '%" + prefixText + "%'";


                    }


                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["Fname"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }

        protected void ddlDocter_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllCollection();
        }
    }
}