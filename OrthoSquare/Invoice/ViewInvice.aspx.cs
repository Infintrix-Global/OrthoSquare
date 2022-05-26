using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Data.SqlClient;
using System.Configuration;

namespace OrthoSquare.Invoice
{
    public partial class ViewInvice : System.Web.UI.Page
    {

        BAL_InvoiceDetails objinv = new BAL_InvoiceDetails();
        public static DataTable AllData = new DataTable();
        clsCommonMasters objcomm = new clsCommonMasters();
        BAL_Clinic objc = new BAL_Clinic();
        BAL_Patient objPatient = new BAL_Patient();
        decimal SumPaid = 0;
        decimal sumPendingValue = 0;
        decimal sumGrandValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindClinic();
                if (SessionUtilities.RoleID == 1)
                {

                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindDocter(SessionUtilities.Empid);
                    getAllInvoice(Convert.ToInt32(SessionUtilities.Empid), 0);
                }
                else if (SessionUtilities.RoleID == 3)
                {
                    ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
                    getAllInvoice(0, Convert.ToInt32(SessionUtilities.Empid));
                }
                else
                {
                    ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

                    getAllInvoice(0, 0);
                }
                // ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));


            }
        }
        public void bindClinic()
        {

            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcomm.GetDoctorByClinic(SessionUtilities.Empid);
            }
            else if (SessionUtilities.RoleID == 1)
            {
                dt = objc.GetAllClinicDetaisNew(SessionUtilities.Empid);
            }
            else
            {
                dt = objc.GetAllClinicDetaisNew(0);

            }
            ddlClinic.DataSource = dt;

            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindDocter(Convert.ToInt32(ddlClinic.SelectedValue));
            getAllInvoice(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue));

        }
        public void BindDocter(int Cid)
        {
            DataTable dt = null;
            ddlDoctor.DataSource = null;
            ddlDoctor.DataBind();
            //ddlDoctor.Items.Remove("--- Select ---");
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {
                dt = objcomm.DoctersMaster(Cid, SessionUtilities.RoleID);
                ddlDoctor.DataSource = dt;

            }
            else
            {
                dt = objcomm.DoctersMaster(Cid, SessionUtilities.RoleID);
                ddlDoctor.DataSource = dt;

            }

            ddlDoctor.DataTextField = "DoctorName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.Items.Remove(ddlDoctor.Items.FindByValue("0"));
            ddlDoctor.DataBind();
            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));




        }

        public void getAllInvoice(int Cid, int Did)
        {
           

            AllData = objinv.GetAllGetAllInvoicDispaly(Cid, Did, Convert.ToInt32(PatientsId), txtMobileNo.Text, txtFromEnquiryDate.Text, txtToEnquiryDate.Text);

            if (AllData != null && AllData.Rows.Count > 0)
            {
                for (int i = 0; i < AllData.Rows.Count; i++)
                {
                    SumPaid += Convert.ToDecimal(AllData.Rows[i]["SumPaid"]);
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

            //gvShow.DataSource = AllData;
            //gvShow.DataBind();

        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;


            if (SessionUtilities.RoleID == 1)
            {
                getAllInvoice(Convert.ToInt32(SessionUtilities.Empid), 0);
            }
            else if (SessionUtilities.RoleID == 3)
            {

                getAllInvoice(0, Convert.ToInt32(SessionUtilities.Empid));
            }
            else
            {
                getAllInvoice(0, 0);
            }


            //  btSearch_Click(sender, e);
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Viewinv")
            {
                int invCode = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Int32 rowind = gvRow.RowIndex;
                Label lblInvoiceCode = (Label)gvRow.FindControl("lblInvoiceCode");

                Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + invCode + "&Fid=" + lblInvoiceCode.Text + "&Back=" + 1);

            }

            if (e.CommandName == "delete1")
            {

                string invCode1 = e.CommandArgument.ToString();

                int I = objinv.DeleteInvoicie(invCode1);
                getAllInvoice(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue));


            }


        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            getAllInvoice(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue));

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            // Edit.Visible = false;
            // .. Add.Visible = true;
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton bindeleteinv = (ImageButton)e.Row.FindControl("lbtDelete");
                if (SessionUtilities.RoleID == 2)
                {
                    bindeleteinv.Visible = true;
                }
                else
                {
                    bindeleteinv.Visible = false;
                }

            }
        }

        private long PatientsId
        {
            get
            {
                if (ViewState["PatientsId"] != null)
                {
                    return (long)ViewState["PatientsId"];
                }
                return 0;
            }
            set
            {
                ViewState["PatientsId"] = value;
            }
        }
        protected void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objPatient.PatientSelect(txtPatientName.Text);
            PatientsId = Convert.ToInt32(dt.Rows[0]["PatientId"]);
            getAllInvoice(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue));

        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllInvoice(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue));

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
                        cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1 ";
                        cmd.CommandText += " and  P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' like '%" + prefixText + "%' and P.ClinicID ='" + ClinicId + "'";
                        cmd.CommandText += "order by patientid DESC ";
                    }
                    else if (RoleId == 3)
                    {

                        cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1 and P.ClinicID ='" + Cid + "' and  P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')'  like '%" + prefixText + "%'";


                    }
                    else
                    {
                        cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1  and  P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' like '%" + prefixText + "%'";


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

       
    }
}