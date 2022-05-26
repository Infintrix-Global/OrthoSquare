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
using PreconFinal.Utility;
using System.Data.OleDb;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Text;



namespace OrthoSquare.patient
{
    public partial class AddConsultationDetails : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Patient objPatient = new BAL_Patient();
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();
        public static DataTable AllData = new DataTable();
        BAL_Clinic objc = new BAL_Clinic();
        BAL_EnquirySource objES = new BAL_EnquirySource();
        BasePage objBasePage = new BasePage();

        int PatientID = 0;
        int Eid = 0;
        string lID = "";
        private string strQuery = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionUtilities.UserID != null)
            {

                if (Request.QueryString["PatientID"] != null)
                {
                    PatientID = Convert.ToInt32(Request.QueryString["PatientID"].ToString());
                }


                if (Request.QueryString["Eid"] != null)
                {
                    Eid = Convert.ToInt32(Request.QueryString["Eid"].ToString());

                    Edit.Visible = false;

                }

                if (!IsPostBack)
                {
                    BindGettooth();
                    getAllPatient();
                    AddConsultationRow(true);


                }
            }
            else
            {
                Response.Redirect("Login.aspx");
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


        public void BindGettooth()
        {
            DataTable dt = objcommon.Gettooth();
            ddltooth.DataSource = dt;
            ddltooth.DataTextField = "toothNo";
            ddltooth.DataValueField = "toothID";
            ddltooth.DataBind();
        }






        public void getAllPatient()
        {
            string Cid = "";

            if (SessionUtilities.RoleID == 1)
            {
                Cid = SessionUtilities.Empid.ToString();
            }
            else if (SessionUtilities.RoleID == 3)
            {
                string A = "";
                DataTable dt23 = objPatient.DoctorByClinicLIST(SessionUtilities.Empid);


                for (int i = 0; i < dt23.Rows.Count; i++)
                {
                    A += dt23.Rows[i]["ClinicID"].ToString() + ",";

                }

                if (A != "")
                {
                    A = A.Remove(A.Length - 1);
                }

                Cid = A;
            }
            else
            {
                Cid = "";
            }

            Session["ClinicID"] = Cid;
            // AllData = objPatient.GetPatientlist();
            //  AllData = objPatient.NewGetPatientlist1(Cid);
            AllData = objPatient.GetAllPatientRecordReport(txtFromDate.Text, txtToDate.Text, Cid, txttxtMobailNoss.Text, txtPatientNos.Text, Convert.ToInt32(PatientsId));

            if (AllData != null && AllData.Rows.Count > 0)
            {


                if (AllData != null && AllData.Rows.Count > 0)
                {

                    lblTotaCount.Text = AllData.Rows.Count.ToString();
                    gvShow.DataSource = AllData;
                    gvShow.DataBind();
                }
                else
                {
                    lblTotaCount.Text = "0";
                    gvShow.DataSource = null;
                    gvShow.DataBind();
                }



                if (SessionUtilities.RoleID == 2)
                {
                    //e.Row.Cells[7].Visible = false;
                    gvShow.Columns[6].Visible = true;
                }
            }
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllPatient();
        }





        protected void btndownloadOptional_Click(object sender, EventArgs e)
        {
            DownloadFile("patient_Master.xlsx", "patient_Master.xlsx");
        }

        protected void DownloadFile(string DownloadFileName, string OutgoingFileName)
        {
            string path = MapPath("~/") + "\\Predefine_Documents\\" + DownloadFileName;
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + OutgoingFileName);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.WriteFile(file.FullName);
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }


        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



            }
        }

        protected void gvShow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void txtPatientName_TextChanged(object sender, EventArgs e)

        {
            DataTable dt = objPatient.PatientSelectDoctorID(txtPatientName.Text);
            PatientsId = Convert.ToInt32(dt.Rows[0]["PatientId"]);
            getAllPatient();


        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllPatient();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btExcel_Click(object sender, ImageClickEventArgs e)
        {


            int Cid = 0;

            if (SessionUtilities.RoleID == 1)
            {
                Cid = Convert.ToInt32(SessionUtilities.Empid);
            }
            else
            {
                Cid = 0;
            }
            //AllData = objPatient.GetPatientlist();
            AllData = objPatient.NewGetPatientlist11(Cid);

            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.ClearContent();
            response.Charset = Encoding.UTF8.WebName;
            response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls");
            response.AddHeader("Content-Type", "application/Excel");
            response.ContentType = "application/vnd.xlsx";
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    GridView gridView = new GridView();
                    gridView.DataSource = AllData;
                    gridView.DataBind();
                    gridView.RenderControl(htw);
                    response.Write(sw.ToString());
                    gridView.Dispose();
                    AllData.Dispose();
                    response.End();
                }
            }
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

                    string Clinic_id = (HttpContext.Current.Session["ClinicID"]).ToString();
                    if (RoleId == 1)
                    {
                        cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1 ";
                        cmd.CommandText += " and  P.FristName +' ('+P.Mobile +')' like '%" + prefixText + "%' and P.ClinicID ='" + ClinicId + "'";
                        cmd.CommandText += "order by patientid DESC ";
                    }
                    else if (RoleId == 3)
                    {


                        cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1  and  P.FristName +' ('+P.Mobile +')'  like '%" + prefixText + "%' and P.ClinicID in (" + Clinic_id + ")";


                    }
                    else
                    {
                        cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1  and  P.FristName +' ('+P.Mobile +')' like '%" + prefixText + "%'";


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




        private void AddConsultationRow(bool AddBlankRow)
        {
            try
            {

                string Treatment = "", MedicinesName = "", hdnWOEmployeeIDVal = "";
                string SlotPositionStart = "", SlotPositionEnd = "";

                List<PatientTreatment> objMedi = new List<PatientTreatment>();

                foreach (GridViewRow item in GridConsultationDetails.Rows)
                {
                    string inHouseValues = "";
                   
                    string Treatmentid = "0";
                    string Treatmenttooth = "0";
                    string ConfomToUser = "";
                    string WorkDone = "";
                    hdnWOEmployeeIDVal = ((HiddenField)item.FindControl("hdnWOEmployeeID")).Value;
                     Treatmentid = ((DropDownList)item.FindControl("ddlTreatment")).SelectedValue;

                    Treatmenttooth = ((DropDownList)item.FindControl("ddlTreatmenttooth")).SelectedValue;

                    CheckBox CheckBoxConfomToUser = (CheckBox)item.FindControl("CheckBoxConfomToUser");
                    TextBox txtSdate = (TextBox)item.FindControl("txtSdate");

                    CheckBox CheckBoxWorkDone = (CheckBox)item.FindControl("CheckBoxWorkDone");
                    TextBox txtWorkdate = (TextBox)item.FindControl("txtWorkdate");


                    TextBox txtRemarks = (TextBox)item.FindControl("txtRemarks");
                   
;

                    if (CheckBoxConfomToUser.Checked)
                    {
                        ConfomToUser = "Yes";
                    }
                    else
                    {
                        ConfomToUser = "No";
                    }

                    if (CheckBoxWorkDone.Checked)
                    {
                        WorkDone = "Yes";
                    }
                    else
                    {
                        WorkDone = "No";
                    }

                   




                    AddMedicines(ref objMedi, Convert.ToInt32(hdnWOEmployeeIDVal), Convert.ToInt32(Treatmentid), Treatmenttooth, ConfomToUser, txtSdate.Text, WorkDone, txtWorkdate.Text, txtRemarks.Text);
                }
                if (AddBlankRow)
                    AddMedicines(ref objMedi, 1,0, "0", "0", "0", "0", "0", "0");
                //GrowerPutData = objinvoice;
                GridConsultationDetails.DataSource = objMedi;
                GridConsultationDetails.DataBind();
                ViewState["Data"] = objMedi;
            }
            catch (Exception ex)
            {

            }
        }





        private void AddMedicines(ref List<PatientTreatment> objGP, int ID,int TreatmentID, string ToothNo, string ConfomToUser,string TreatmentStartDate, string WorkDone, string WorkDoneDate, string Remarks)
        {
            PatientTreatment objM = new PatientTreatment();
            objM.ID = ID;
            objM.RowNumber = objGP.Count + 1;
            objM.TreatmentID = TreatmentID;
            objM.ToothNo = ToothNo;
            objM.ConfomToUser = ConfomToUser;
            objM.TreatmentStartDate = TreatmentStartDate;
            objM.WorkDone = WorkDone;
            objM.WorkDoneDate = WorkDoneDate;
            
            objM.Remarks = Remarks;
          
            ViewState["ojbpro"] = objGP;
        }

        protected void GridConsultationDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridConsultationDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddConsultationRow(true);
        }
    }
}


