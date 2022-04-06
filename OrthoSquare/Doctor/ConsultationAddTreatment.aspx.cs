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
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

namespace OrthoSquare.Doctor
{
    public partial class ConsultationAddTreatment : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        public static DataTable AllData1 = new DataTable();
        public static DataTable AllData2 = new DataTable();
        public static DataTable AllData3 = new DataTable();
        public static DataTable AllData4 = new DataTable();
        Bal_MaterilaType objMT = new Bal_MaterilaType();
        BAL_Medicines objMedicines = new BAL_Medicines();
        BAL_Appointment ojbApp = new BAL_Appointment();
        BAL_Patient objPatient = new BAL_Patient();
        BAL_ConsultationAddTreatment objCT = new BAL_ConsultationAddTreatment();
        BAL_Treatment objT = new BAL_Treatment();
        BAL_Patient objp = new BAL_Patient();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_LabsDetails objL = new BAL_LabsDetails();
        BAL_InvoiceDetails objinv = new BAL_InvoiceDetails();
        string lID = "";
        string ToothNo1 = "";
        string TreatmentID = "";


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ClearCache();
                if (Request.QueryString["pid"] != null)
                {
                    int Pid = Convert.ToInt32(Request.QueryString["pid"]);

                    patientTm(Pid, 0);

                    Edit.Visible = false;
                    Add.Visible = true;
                }
                else
                {
                    getAllDetails();

                }

                AddMedicinesRow(true);
                bindDentalTreatmentWorkDone();

                bindDentalTreatment();
                BindGettooth();

                BindGettoothLeb();
                BindTypeOfwork();

                // getAlltodayConsultation();
                bindDentalCategory();
                BindMedicalProblem();
                BindAllergic();
                BindComplaints();

            }

        }
        public void ClearCache()
        {
            //txtToothNo.Attributes.Add("autocomplete", "off");
            //  txtTreatment.Attributes.Add("autocomplete", "off");
            txtcomplaint.Attributes.Add("autocomplete", "off");

            txtDoctorAddres.Attributes.Add("autocomplete", "off");
            txtFDoctorName.Attributes.Add("autocomplete", "off");
            txtLabname.Attributes.Add("autocomplete", "off");
            txtlistDentalTreatment.Attributes.Add("autocomplete", "off");
            txtListMedicine.Attributes.Add("autocomplete", "off");
            txtName.Attributes.Add("autocomplete", "off");
            txtNofoCigrattes.Attributes.Add("autocomplete", "off");
            txtNots.Attributes.Add("autocomplete", "off");

            txtNotsWorkDone.Attributes.Add("autocomplete", "off");
            txtPatientNo.Attributes.Add("autocomplete", "off");
            txtPlanDetails.Attributes.Add("autocomplete", "off");

            txtPlanDetails.Attributes.Add("autocomplete", "off");

            txtPreganetDueDate.Attributes.Add("autocomplete", "off");

        }

        private long patientid
        {
            get
            {
                if (ViewState["patientid"] != null)
                {
                    return (long)ViewState["patientid"];
                }
                return 0;
            }
            set
            {
                ViewState["patientid"] = value;
            }
        }


        private long DoctorID
        {
            get
            {
                if (ViewState["DoctorID"] != null)
                {
                    return (long)ViewState["DoctorID"];
                }
                return 0;
            }
            set
            {
                ViewState["DoctorID"] = value;
            }
        }


        public void BindTypeOfwork()
        {
            DataTable dt = objcommon.GetTypeofWorkLab();


            ddlTypeOfwork.DataSource = dt;
            ddlTypeOfwork.DataTextField = "TypeName";
            ddlTypeOfwork.DataValueField = "TypeOfworkId";
            ddlTypeOfwork.DataBind();

            ddlTypeOfwork.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }



        public void BindGettooth()
        {
            DataTable dt = objcommon.Gettooth();


            ddltooth11.DataSource = dt;
            ddltooth11.DataTextField = "toothNo";
            ddltooth11.DataValueField = "toothID";
            ddltooth11.DataBind();
            //ddltooth11.Items.Insert(0, new ListItem("--- Select ---", "0"));


            ddlToothNoWOrkname.DataSource = dt;
            ddlToothNoWOrkname.DataTextField = "toothNo";
            ddlToothNoWOrkname.DataValueField = "toothID";
            ddlToothNoWOrkname.DataBind();
            ddlToothNoWOrkname.Items.Insert(0, new ListItem("--- Select ---", "0"));






        }



        public void BindGettoothLeb()
        {
            DataTable dt = objcommon.Gettooth();


            ddlToothNo1.DataSource = dt;
            ddlToothNo1.DataTextField = "toothNo";
            ddlToothNo1.DataValueField = "toothID";
            ddlToothNo1.DataBind();

            //  ddlToothNo1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        //protected void ddlToothNo1_SelectedIndexChangedToothNo1(object sender, EventArgs e)
        //{
        //    string name = "";

        //    for (int i = 0; i < ddlToothNo1.Items.Count; i++)
        //    {
        //        if (ddlToothNo1.Items[i].Selected)
        //        {
        //            name += ddlToothNo1.Items[i].Text + ",";
        //            lID += ddlToothNo1.Items[i].Value + ",";
        //        }
        //    }
        //    txtToothNo.Text = name;

        //}



        //public void BindPatient()
        //{
        //    ddlpatient.DataSource = objp.GetPatientlist();
        //    ddlpatient.DataTextField = "FristName";
        //    ddlpatient.DataValueField = "patientid";
        //    ddlpatient.DataBind();

        //    ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));
        //}

        public void getAllDetails()
        {

            AllData = ojbApp.GetAlltodayConsultation();
            gvShow.DataSource = AllData;
            gvShow.DataBind();
        }

        public void getAlltodayConsultation(long Pid)
        {

            AllData1 = objCT.GetConsultationAddTreatment(Pid);

            if (AllData1 != null && AllData1.Rows.Count > 0)
            {
                GridTreatment.DataSource = AllData1;
                GridTreatment.DataBind();

                ButtonInvoice.Visible = true;
                TreatmentSubmit.Visible = true;
            }
        }

        //protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        //{


        //    string name = "";

        //    for (int i = 0; i < ddltooth11.Items.Count; i++)
        //    {
        //        if (ddltooth11.Items[i].Selected)
        //        {
        //            name += ddltooth11.Items[i].Text + ",";
        //            lID += ddltooth11.Items[i].Value + ",";
        //        }
        //    }
        //    TextBox1.Text = name;

        //}

        protected void GridTreatment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DropDownList ddltooth1 = (DropDownList)e.Row.FindControl("ddltooth");
                ListBox ddltoothM = (ListBox)e.Row.FindControl("ddltoothM");

                // Label lblTooth = (Label)e.Row.FindControl("lblTooth");
                Label lblTooth1 = (Label)e.Row.FindControl("lblTooth1");
                Label lblStartedTreatments = (Label)e.Row.FindControl("lblStartedTreatments");
                CheckBox CheckBoxT = (CheckBox)e.Row.FindControl("CheckBoxT");


                DataTable dt = objcommon.Gettooth();


                //ddltooth1.DataSource = dt;
                //ddltooth1.DataTextField = "toothNo";
                //ddltooth1.DataValueField = "toothID";
                //ddltooth1.DataBind();






                ddltoothM.DataSource = dt;
                ddltoothM.DataTextField = "toothNo";
                ddltoothM.DataValueField = "toothID";
                ddltoothM.DataBind();

                //       ddltoothM.SelectedItem.Text = lblTooth1.Text;



                if (lblStartedTreatments.Text == "No")
                {
                    lblStartedTreatments.ForeColor = System.Drawing.Color.Red;
                    CheckBoxT.Checked = false;
                    ddltoothM.Visible = true;
                    lblTooth1.Visible = false;
                }
                else
                {
                    lblStartedTreatments.ForeColor = System.Drawing.Color.Green;
                    CheckBoxT.Checked = true;
                    CheckBoxT.Enabled = false;
                    ddltoothM.Visible = false;
                    lblTooth1.Visible = true;
                }



                //  ddltooth1.Items.Insert(0, new ListItem("--- Select ---", "0"));

            }
        }



        protected void GridTreatment_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectT")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;


            }

            if (e.CommandName == "delete123")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                objCT.Delete_TreatmentbyPatient(ID);
                getAlltodayConsultation(patientid);
            }
        }



        public void BiendPreviousConsultation(long Pid)
        {

            AllData4 = ojbApp.GetPreviousConsultationDetila(Pid, 1);
            GridPreviousConsultation.DataSource = AllData4;
            GridPreviousConsultation.DataBind();
        }


        public void BiendTreatmentPlanConsultation(long Pid)
        {

            DataTable AllData44 = ojbApp.GetTreatmentPlanConsultationDetila(Pid, 1);
            if (AllData44 != null && AllData44.Rows.Count > 0)
            {
                GridViewTreatment.DataSource = AllData44;
                GridViewTreatment.DataBind();
                PanelTreatmentPlan.Visible = true;
            }

        }



        public void getMedicalHistory(long Pid1)
        {
            AllData2 = objp.GetMedicalHistoryDetails(Pid1);
            GridMedicalHistory.DataSource = AllData2;
            GridMedicalHistory.DataBind();


            if (AllData2.Rows.Count != 0)
            {

                Panel2.Visible = true;
            }
            else
            {

                Panel1.Visible = true;

            }
        }

        public void bindDentalCategory()
        {
            ddlTreatment.DataSource = objT.GetAllTreatment();
            ddlTreatment.DataValueField = "TreatmentID";
            ddlTreatment.DataTextField = "TreatmentName";
            ddlTreatment.DataBind();
            //  ddlTreatment.Items.Insert(0, new ListItem("-- Select Dental Category--", "0", true));

        }


        public void bindDentalTreatment()
        {
            ddlTreatmentDetails.DataSource = objT.GetAllTreatment();
            ddlTreatmentDetails.DataValueField = "TreatmentID";
            ddlTreatmentDetails.DataTextField = "TreatmentName";
            ddlTreatmentDetails.DataBind();
            ddlTreatmentDetails.Items.Insert(0, new ListItem("-- Select Dental Category--", "0", true));

        }

        public void bindDentalTreatmentWorkDone()
        {
            ddlTreatmentbyworkDone.DataSource = objT.GetAllTreatmentWorkDone(Convert.ToInt32(Request.QueryString["pid"]));
            ddlTreatmentbyworkDone.DataValueField = "ID";
            ddlTreatmentbyworkDone.DataTextField = "TreatmentName";
            ddlTreatmentbyworkDone.DataBind();
            ddlTreatmentbyworkDone.Items.Insert(0, new ListItem("-- Select --", "0", true));

        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string search = "";
            int pid = Convert.ToInt32(e.CommandArgument);

            patientTm(pid, 1);

        }

        public void bindDoctorMaster(int did, int Rolid)
        {
            //  ddl_DocterDetils.DataSource = objcommon.DoctersMasterNew(did, Rolid);

            ////  ddl_DocterDetils.DataSource = objcommon.DoctersMasterNew(did, Rolid);

            //ddl_DocterDetils.DataValueField = "DoctorID";
            //ddl_DocterDetils.DataTextField = "DoctorName";
            //ddl_DocterDetils.DataBind();
            //ddl_DocterDetils.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));


            if (Rolid == 3)
            {
                DataTable dt = objcommon.DoctersMasterNew(did, Rolid);
                txtDocter.Text = dt.Rows[0]["DoctorName"].ToString();
            }

        }
        public void patientTm(int pid, int id)
        {
            string search = "";

            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                bindDoctorMaster(SessionUtilities.Empid, SessionUtilities.RoleID);

            }
            else
            {

                bindDoctorMaster(0, SessionUtilities.RoleID);
            }

            getAlltodayConsultation(pid);
            BindTreatmentStartedNotesWorkDones(pid);
            getMedicalHistory(pid);
            BiendPreviousConsultation(pid);
            BiendTreatmentPlanConsultation(pid);

            getAlaGridViewViewMedicines(pid);
            getAllGallery(pid);
            getAlaGridelb(pid);

            DataTable dt = objPatient.GetPatient(pid);

            patientid = pid;
            if (SessionUtilities.RoleID == 3)
            {
                DoctorID = Convert.ToInt32(SessionUtilities.Empid);
            }
            //DoctorID = Convert.ToInt32(ddl_DocterDetils.SelectedValue);

            if (dt.Rows.Count > 0)
            {


                lblPname.Text = dt.Rows[0]["FristName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                lblPmobialNo.Text = dt.Rows[0]["Mobile"].ToString();

                if (dt.Rows[0]["ProfileImage"] != "")
                {
                    Image1.ImageUrl = "~/EmployeeProfile/" + dt.Rows[0]["ProfileImage"].ToString();
                }
                else
                {
                    Image1.ImageUrl = "~/Images/no-photo.jpg";

                }
                //lblDrName.Text = dtSearch.Rows[0]["DFirstName"].ToString() + " " + dtSearch.Rows[0]["DLastName"].ToString();
            }




            Add.Visible = true;
            Edit.Visible = false;



        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                int _isInserted = -1;



                for (int i = 0; i < ddlTreatment.Items.Count; i++)
                {
                    if (ddlTreatment.Items[i].Selected)
                    {
                        TreatmentID += ddlTreatment.Items[i].Value + ",";



                    }
                }

                if (TreatmentID != "")
                {
                    TreatmentID = TreatmentID.Remove(TreatmentID.Length - 1);
                }


                _isInserted = objCT.Add_TreatmentbyPatient(patientid, Convert.ToInt32(DoctorID), TreatmentID);
                bindDentalCategory();
                //txtTreatment.Text = ""; 
                getAlltodayConsultation(patientid);
            }
            catch (Exception ex)
            {
            }

        }


        public void BindTreatmentStartedNotesWorkDones(int Pid)
        {

            DataTable dt = objCT.GetTreatmentStartedNotesWorkDone(Pid);

            if (dt != null && dt.Rows.Count > 0)
            {
                GridTretmetWorkDone.DataSource = dt;
                GridTretmetWorkDone.DataBind();
            }
        }


        protected void btnTDoneWork_Clicklab(object sender, EventArgs e)
        {

            int c = 0;
            string x = "";
            string chkSelectedToothworkDone = "";
            foreach (ListItem item in ddlToothNoWOrkname.Items)
            {
                if (item.Selected)
                {
                    c = 1;
                    x += item.Text + ",";
                }
            }
            if (c > 0)
            {
                chkSelectedToothworkDone = x.Remove(x.Length - 1, 1);
            }




            //int TPD = objCT.Update_TreatmentbyPatientWorkDone(Convert.ToInt32(Request.QueryString["pid"]), Convert.ToInt32(ddlTreatmentbyworkDone.SelectedValue), ddlToothNoWOrkname.SelectedItem.Text, txtNotsWorkDone.Text);

            int TPD = objCT.Update_TreatmentbyPatientWorkDone(Convert.ToInt32(Request.QueryString["pid"]), Convert.ToInt32(ddlTreatmentbyworkDone.SelectedValue), chkSelectedToothworkDone, txtNotsWorkDone.Text);

            BindTreatmentStartedNotesWorkDones(Convert.ToInt32(Request.QueryString["pid"]));
            txtNotsWorkDone.Text = "";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Added Successfully')", true);

            PanelAddWOrkDone.Visible = false;
            PanelListWOrkDone.Visible = true;

        }
        protected void btnUpdateTreatment_Clicklab(object sender, EventArgs e)
        {
            int SelectedItems = 0;
            foreach (GridViewRow item in GridTreatment.Rows)
            {

                string StartedTreatments = "";
                CheckBox chkSelect = (CheckBox)item.FindControl("CheckBoxT");

                Label lblID = (item.Cells[0].FindControl("lblID") as Label);
                //  DropDownList ddltooth = (item.Cells[0].FindControl("ddltooth") as DropDownList);
                ListBox ddltooth = (item.Cells[0].FindControl("ddltoothM") as ListBox);
                TextBox txtCost = (item.Cells[0].FindControl("txtCost") as TextBox);
                Label lblStartedTreatments = (item.Cells[0].FindControl("lblStartedTreatments") as Label);
                TextBox txtSdate = (item.Cells[0].FindControl("txtSdate") as TextBox);

                int c = 0;
                string x = "";
                string chkSelectedTooth = "";
                foreach (ListItem item1 in ddltooth.Items)
                {
                    if (item1.Selected)
                    {
                        c = 1;
                        x += item1.Text + ",";
                    }
                }
                if (c > 0)
                {
                    chkSelectedTooth = x.Remove(x.Length - 1, 1);
                }



                if (item.RowType == DataControlRowType.DataRow)
                {
                    if (chkSelect.Checked == true)
                    {
                        StartedTreatments = "Yes";

                        if (lblStartedTreatments.Text == "No" || lblStartedTreatments.Text == "")
                        {
                            int TPD = objCT.Update_TreatmentbyPatientYES(Convert.ToInt32(lblID.Text), txtCost.Text, chkSelectedTooth, StartedTreatments, txtNots.Text, txtSdate.Text);
                            //int TPD = objCT.Update_TreatmentbyPatientYES(Convert.ToInt32(lblID.Text), txtCost.Text, ddltooth.SelectedItem.Text, StartedTreatments, txtNots.Text, txtSdate.Text);

                        }


                    }
                    else
                    {
                        StartedTreatments = "No";
                        //  int TPD = objCT.Update_TreatmentbyPatient(Convert.ToInt32(lblID.Text), txtCost.Text, ddltooth.SelectedItem.Text, StartedTreatments, txtNots.Text, txtSdate.Text);
                        int TPD = objCT.Update_TreatmentbyPatient(Convert.ToInt32(lblID.Text), txtCost.Text, chkSelectedTooth, StartedTreatments, txtNots.Text, txtSdate.Text);

                    }

                    SelectedItems++;

                }

            }

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Added Successfully')", true);
            txtNots.Text = "";
            getAlltodayConsultation(patientid);
            bindDentalTreatmentWorkDone();

        }


        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                //if (txtSearch.Text != "")
                //{
                if (txtName.Text != "")
                {
                    search += "PFristName like '%" + txtName.Text + "%'";
                }
                else
                {
                    search += "PatientCode ='" + txtPatientNo.Text + "'";
                }

                DataRow[] dtSearch1 = AllData.Select(search);
                if (dtSearch1.Count() > 0)
                {
                    DataTable dtSearch = dtSearch1.CopyToDataTable();
                    gvShow.DataSource = dtSearch;
                    gvShow.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    gvShow.DataSource = dt;
                    gvShow.DataBind();
                }
                //}
                //else
                //{
                //    gvShow.DataSource = AllData;
                //    gvShow.DataBind();
                //}
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Add.Visible = true;
            Edit.Visible = false;
        }

        public void BindMedicalProblem()
        {
            ChkMedicalProblem1.DataSource = objcommon.MedicalProblemMaster();
            ChkMedicalProblem1.DataTextField = "Name";
            ChkMedicalProblem1.DataValueField = "MedicalProid";

            ChkMedicalProblem1.DataBind();



        }

        public void BindAllergic()
        {
            checkallergic.DataSource = objcommon.AllergicDetails();
            checkallergic.DataTextField = "allergicName";
            checkallergic.DataValueField = "allergicId";

            checkallergic.DataBind();



        }


        public void BindComplaints()
        {

            DataTable dt = objcommon.ComplaintsDetils(Convert.ToInt32(patientid));

            if (dt != null && dt.Rows.Count > 0)
            {
                GirdComplaints.DataSource = dt;
                GirdComplaints.DataBind();
            }
            else
            {
                Panel3.Visible = true;
                Panel4.Visible = false;

            }


        }
        protected void btnAddNewComplaints_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            Panel4.Visible = false;
            HtmlGenericControl Complaints = FindControl("collapse_3_1") as HtmlGenericControl;

            // HtmlAnchor MyLnk = (HtmlAnchor)this.Master.FindControl("Complaints");
            // Complaints.Attributes.Add("class", "panel-collapse collapse in");
        }

        protected void btnWDAddNew_Click(object sender, EventArgs e)
        {
            PanelAddWOrkDone.Visible = true;
            PanelListWOrkDone.Visible = false;
            HtmlGenericControl Complaints = FindControl("#collapse_3_10") as HtmlGenericControl;

            // HtmlAnchor MyLnk = (HtmlAnchor)this.Master.FindControl("Complaints");
            // Complaints.Attributes.Add("class", "panel-collapse collapse in");
        }


        protected void RadPregnant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadPregnant.SelectedItem.Text == "Yes")
            {
                txtPreganetDueDate.Visible = true;

            }
            else
            {
                txtPreganetDueDate.Visible = false;

            }
        }

        protected void RadSomking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadSomking.SelectedItem.Text == "Yes")
            {
                txtNofoCigrattes.Visible = true;

            }
            else
            {
                txtNofoCigrattes.Visible = false;

            }

        }
        protected void btAdd_Click1(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;

                string MedicalProblem = "";


                for (int i = 0; i < ChkMedicalProblem1.Items.Count; i++)
                {

                    if (ChkMedicalProblem1.Items[i].Selected)
                    {
                        MedicalProblem += ChkMedicalProblem1.Items[i].Value + ",";
                    }

                }
                if (MedicalProblem != "")
                {
                    MedicalProblem = MedicalProblem.Remove(MedicalProblem.Length - 1);
                }



                string Allergic = "";


                for (int i = 0; i < checkallergic.Items.Count; i++)
                {

                    if (checkallergic.Items[i].Selected)
                    {
                        Allergic += checkallergic.Items[i].Value + ",";
                    }

                }
                if (Allergic != "")
                {
                    Allergic = MedicalProblem.Remove(Allergic.Length - 1);
                }

                string ConsentStatement = "";



                Patient_Details objPatientDetails = new Patient_Details()
                {
                    patientid = patientid,
                    EnquiryId = 0,
                    ClinicID = 0,
                    PatientCode = txtPatientNo.Text,
                    // EnquiryDate = Convert .ToDateTime(txtENqDate.Text),
                    RegistrationDate = "1990-01-01",

                    FirstName = "",
                    LastName = "",
                    // DateBirth = Convert .ToDateTime (txtBDate.Text),
                    DateBirth = "1990-01-01",
                    Age = "",
                    boolgroup = "",
                    Gender = "",
                    Address = "",
                    CountryId = 0,
                    stateid = 0,
                    Cityid = 0,
                    Area = "",
                    Email = "",
                    Mobile = "",
                    Telephone = "",
                    MedicalProblem = MedicalProblem,
                    Allergic = Allergic,
                    Pregnant = RadPregnant.SelectedItem.Text,
                    DueDate = txtPreganetDueDate.Text,
                    PanMasalaChewing = RadPanMasala.SelectedItem.Text,
                    Tobacco = RadTobacco.SelectedItem.Text,
                    Somking = RadSomking.SelectedItem.Text,
                    cigrattesInDay = txtNofoCigrattes.Text,
                    ListofMedicine = txtListMedicine.Text,
                    FamilyDoctorName = txtFDoctorName.Text,
                    DrAddress = txtDoctorAddres.Text,


                    Complaint = txtcomplaint.Text,
                    DentalTreatment = txtlistDentalTreatment.Text,
                    ConsentStatement = ConsentStatement,
                    // PaymentMode = RadioPayment1.SelectedItem .Text ,
                    //PayDate =txtpaymentDate1 .Text ,
                    // Amount=txtAmount1 .Text ,
                    CreatedBy = 1,
                    ModifiedBy = SessionUtilities.Empid,

                    IsActive = true

                };

                _isInserted = objPatient.Add_PatientMH(objPatientDetails);

                if (_isInserted == -1)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to Add Patient')", true);

                    lblMessage.Text = "Failed to Add Patient";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    patientid = 0;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Patient Added Successfully')", true);

                    lblMessage.Text = "Patient Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    Clear();


                }
            }
            catch (Exception ex)
            {


            }
        }

        public void Clear()
        {
            //CleartextBoxes(this);
            BindAllergic();
            BindMedicalProblem();

        }

        public void CleartextBoxes(Control parent)
        {

            foreach (Control c in parent.Controls)
            {

                if ((c.GetType() == typeof(TextBox)))
                {


                    ((TextBox)(c)).Text = "";

                }

                if (c.HasControls())
                {

                    CleartextBoxes(c);

                }

            }

        }


        protected void btAdd_Clicklab(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;

                for (int i = 0; i < ddlToothNo1.Items.Count; i++)
                {
                    if (ddlToothNo1.Items[i].Selected)
                    {
                        ToothNo1 += ddlToothNo1.Items[i].Text + ",";



                    }
                }

                if (ToothNo1 != "")
                {
                    ToothNo1 = ToothNo1.Remove(ToothNo1.Length - 1);
                }

                LabDetails1 objLab = new LabDetails1()
                {

                    Labid = 0,
                    patientid = patientid,
                    TypeOfworkId = Convert.ToInt32(ddlTypeOfwork.SelectedValue),
                    LabName = txtLabname.Text,
                    ToothNo = ToothNo1,
                    OutwardDate = "01-01-1900",
                    InwardDate = "01-01-1900",
                    Workcompletion = "",
                    Notes = "",
                    CreateID = SessionUtilities.Empid



                };



                _isInserted = objL.Add_LabDetails(objLab);



                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Lab";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Lab Added Successfullyy')", true);

                    lblMessage.Text = "Lab Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    getAlaGridelb(patientid);
                    Clear();
                    txtLabname.Text = "";

                }
            }
            catch (Exception ex)
            {
            }
        }



        public void getAlaGridelb(long Pid)
        {

            DataTable AllData12 = objL.GetLabsViewDetsilsNEW(Pid);

            if (AllData12 != null && AllData12.Rows.Count > 0)
            {
                GridViewLEBDetais.DataSource = AllData12;
                GridViewLEBDetais.DataBind();


            }
        }




        protected void btAddPTDetails_Click(object sender, EventArgs e)
        {
            InsertMultipleImage();

          

        }

        protected void btBackPT_Click(object sender, EventArgs e)
        {

        }



        protected void Gridinvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlTreatment = (DropDownList)e.Row.FindControl("ddlTreatment");

            }
        }





        protected void btAddCompains_Click(object sender, EventArgs e)
        {

            int _isInserted = -1;


            for (int i = 0; i < ddltooth11.Items.Count; i++)
            {
                if (ddltooth11.Items[i].Selected)
                {
                    lID += ddltooth11.Items[i].Text + ",";
                }
            }

            if (lID != "")
            {
                lID = lID.Remove(lID.Length - 1);
            }



            _isInserted = objCT.Add_complaintinsert(patientid, txtcomplaint.Text, txtlistDentalTreatment.Text, lID, Convert.ToInt32(DoctorID));
            //    _isInserted = objCT.Add_ADDPatientByToothno(patientid, lID);


            if (_isInserted == -1)
            {
                lblMessage.Text = "Failed to Add Complaints";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Complaints Added Successfully')", true);

                lblMessage.Text = "Complaints Added Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Clear();
                txtcomplaint.Text = "";
                txtlistDentalTreatment.Text = "";
                BindComplaints();
                Panel4.Visible = true;
                Panel3.Visible = false;
            }

        }





        protected void ButtonInvoice_Click(object sender, EventArgs e)
        {
            //Response.Redirect = "~/Invoice/InvoiceAdd.aspx";

            Response.Redirect("../Invoice/InvoiceAdd.aspx?pid=" + patientid);
        }



        protected void btAddTreatmentPlan_Click(object sender, EventArgs e)
        {

            int _isInserted = -1;

            _isInserted = objCT.Add_TreatmentbyPlan(patientid, Convert.ToInt32(DoctorID), txtPlanDetails.Text);



            if (_isInserted == -1)
            {
                lblMessage.Text = "Failed to Add Treatment Plan";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Treatment Plan Added Successfully')", true);

                lblMessage.Text = "Treatment Plan Added Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                // Clear();
                txtPlanDetails.Text = "";
                BiendTreatmentPlanConsultation(patientid);

            }

        }



        public void InsertMultipleImage()
        {
            // BindDetails();

            //  foreach ( HttpPostedFile postedFile in FuImage1.PostedFiles)
            //foreach (HttpPostedFile postedFile in FuImage1.PostedFiles)
            //{
            foreach (HttpPostedFile file in FuImage1.PostedFiles)
            {
                // HttpPostedFile hFile = Request.Files[file] as HttpPostedFile;

                String fileName = file.FileName;

                string lbl_filepath11 = "";

                string filename = "", newfile = "";
                string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

                if (!FuImage1.HasFile)
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                    FuImage1.Focus();
                }

                string aa = FuImage1.PostedFile.FileName;
                string ext = System.IO.Path.GetExtension(FuImage1.PostedFile.FileName).ToLower();
                bool isValidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (isValidFile == true)
                {

                    if (FuImage1.HasFile)
                    {

                        filename = Server.MapPath(FuImage1.FileName);
                        newfile = FuImage1.PostedFile.FileName;
                        //                filecontent = System.IO.File.ReadAllText(filename);
                        FileInfo fi = new FileInfo(newfile);

                        // check folder exist or not
                        if (!System.IO.Directory.Exists(@"~\TreatmentDoc"))
                        {
                            try
                            {

                                int PTNO = objcommon.GetPatientTreatmentMax_no();
                                string Imgname = ddlTreatmentDetails.SelectedItem.Text + PTNO + patientid;

                                string path = Server.MapPath(@"~\TreatmentDoc\");

                                System.IO.Directory.CreateDirectory(path);
                                file.SaveAs(path + @"\" + ddlTreatmentDetails.SelectedItem.Text + PTNO + patientid + ext);

                                //  ImagePhoto1.ImageUrl = @"~\TreatmentDoc\" + ddlTreatmentDetails.SelectedItem.Text + patientid + ext;
                                // ImagePhoto1.Visible = true;

                                // lbl_filepath1.Text = Imgname + ext;

                                lbl_filepath11 = Imgname + ext;


                                int _isInserted = -1;

                                _isInserted = objCT.Add_PTGallreryDetails(0, patientid, Convert.ToInt32(ddlTreatmentDetails.SelectedValue), txtRemarks.Text, lbl_filepath11);
                                lbl_filepath11 = "";
                                if (_isInserted == -1)
                                {
                                    lblMessage.Text = "Failed to Add Treatment Image";
                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Treatment Image Added Successfully')", true);

                                    lblMessage.Text = "Treatment Image Added Successfully";
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                    Clear();
                                    txtRemarks.Text = "";
                                    getAllGallery(patientid);

                                }
                            }
                            catch (Exception ex)
                            {
                                // lbl_filepath1.Text = "Not able to create new directory";
                            }

                        }
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
                }




                // FuImage1.SaveAs(Server.MapPath("~/Co-Working/Images/" + targetPath));



            }
        }

        public void getAllGallery(long Pid)
        {

            AllData = objCT.GetPTGallery(Convert.ToInt32(Pid));
            grdProducts.DataSource = AllData;
            grdProducts.DataBind();

        }



        protected void RBtnLstPsta_SelectedIndexChanged(object sender, EventArgs e)
        {

            int Cid = objCT.Update_PCstatus(Convert.ToInt32(patientid), RBtnLstPsta.SelectedValue);



        }



        protected void GridMedicalHistoryBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblDueDate = (Label)e.Row.FindControl("lblDueDate");

                if (lblDueDate.Text == "01-01-1990")
                {
                    lblDueDate.Text = "";
                }


            }
        }

        protected void txtDocter_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objcommon.DoctersSelectDoctorID(txtDocter.Text);
            DoctorID = Convert.ToInt32(dt.Rows[0]["DoctorID"]);
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
                    //cmd.CommandText = " select distinct GPD.jobcode from gti_jobs_seeds_plan GTS inner join GrowerPutAwayDetails GPD on GPD.wo=GTS.wo  where  GPD.FacilityID ='" + Facility + "'  AND GPD.jobcode like '%" + prefixText + "%' union select distinct jobcode from gti_jobs_seeds_plan_Manual where loc_seedline ='" + Facility + "'  AND jobcode like '%" + prefixText + "%' order by jobcode" +
                    //    "";
                    //SessionUtilities.Empid, SessionUtilities.RoleID

                    if (RoleId == 1)
                    {
                        cmd.CommandText = "Select D.FirstName+' '+ isnull(D.LastName,' ') as DoctorName,* from DoctorByClinic DBC join tbl_DoctorDetails D on D.DoctorID = DBC.DoctorID  where  IsActive =1  and IsDeleted=0 and DBC.IsDeactive=1 ";
                        cmd.CommandText += " and DBC.ClinicID='" + ClinicId + "' and  D.FirstName +' ' + D.LastName like '%" + prefixText + "%' ";
                        cmd.CommandText += "  order by FirstName ASC";
                    }
                    else if (RoleId == 3)
                    {

                        cmd.CommandText = "Select  FirstName+' '+ isnull(LastName,' ') as DoctorName,* from  tbl_DoctorDetails  where IsDeleted=0 and  FirstName +' ' + LastName like '%" + prefixText + "%'";
                        cmd.CommandText += " and DoctorID='" + DoctorID + "'";
                        cmd.CommandText += "  order by FirstName ASC";

                    }
                    else
                    {

                        cmd.CommandText = "Select  FirstName+' '+ isnull(LastName,' ') as DoctorName,* from tbl_DoctorDetails where  IsActive =1  and IsDeleted=0 and  FirstName +' ' + LastName like '%" + prefixText + "%' ";
                        cmd.CommandText += "  order by FirstName ASC";
                    }


                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["DoctorName"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }

        protected void GridTretmetWorkDone_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridTretmetWorkDone.PageIndex = e.NewPageIndex;
            BindTreatmentStartedNotesWorkDones(Convert.ToInt32(Request.QueryString["pid"]));
        }

        //-- Medicinec Add and Invoice Details Set
        //Change on Mehul Rana 
        // on 11-03-2022

        private void AddMedicinesRow(bool AddBlankRow)
        {
            try
            {

                string MedicinesType = "", MedicinesName = "", hdnWOEmployeeIDVal = "";
                string SlotPositionStart = "", SlotPositionEnd = "";

                List<MedicinesDetails> objMedi = new List<MedicinesDetails>();

                foreach (GridViewRow item in GridMedicinesDetails.Rows)
                {
                    string inHouseValues = "";
                    string Morning = "";
                    string Afternoon = "";
                    string Evening = "";
                    hdnWOEmployeeIDVal = ((HiddenField)item.FindControl("hdnWOEmployeeID")).Value;
                    MedicinesType = ((DropDownList)item.FindControl("ddlMedicinesType")).SelectedValue;
                    MedicinesName = ((DropDownList)item.FindControl("ddlMedicinesName")).SelectedValue;
                    TextBox txtTotalDose = (TextBox)item.FindControl("txtTotalDose");
                    TextBox txtTotalNoofDays = (TextBox)item.FindControl("txtTotalNoofDays");
                    TextBox txtStrip = (TextBox)item.FindControl("txtStrip");
                    TextBox txtRemarksN = (TextBox)item.FindControl("txtRemarksN");
                    CheckBox inHouse = (CheckBox)item.FindControl("CheckBoxInHouse");

                    CheckBox CheckBoxMorningN = (CheckBox)item.FindControl("CheckBoxMorningN");
                    CheckBox CheckBoxAfternoonN = (CheckBox)item.FindControl("CheckBoxAfternoonN");
                    CheckBox CheckBoxEveningN = (CheckBox)item.FindControl("CheckBoxEveningN");

                    if (inHouse.Checked)
                    {
                        inHouseValues = "Yes";
                    }
                    else
                    {
                        inHouseValues = "No";
                    }

                    if (CheckBoxMorningN.Checked)
                    {
                        Morning = "Yes";
                    }
                    else
                    {
                        Morning = "No";
                    }

                    if (CheckBoxAfternoonN.Checked)
                    {
                        Afternoon = "Yes";
                    }
                    else
                    {
                        Afternoon = "No";
                    }


                    if (CheckBoxEveningN.Checked)
                    {
                        Evening = "Yes";
                    }
                    else
                    {
                        Evening = "No";
                    }




                    AddMedicines(ref objMedi, Convert.ToInt32(hdnWOEmployeeIDVal), MedicinesType, MedicinesName, txtTotalDose.Text, txtTotalNoofDays.Text, Morning, Afternoon, Evening, txtRemarksN.Text, inHouseValues, txtStrip.Text);
                }
                if (AddBlankRow)
                    AddMedicines(ref objMedi, 1, "", "0", "0", "0", "", "", "", "", "", "0");
                //GrowerPutData = objinvoice;
                GridMedicinesDetails.DataSource = objMedi;
                GridMedicinesDetails.DataBind();
                ViewState["Data"] = objMedi;
            }
            catch (Exception ex)
            {

            }
        }



        public void GridSplitjob()
        {
            GridMedicinesDetails.DataSource = ViewState["Data"];
            GridMedicinesDetails.DataBind();
        }

        private void AddMedicines(ref List<MedicinesDetails> objGP, int ID, string MedicinesType, string MedicinesName, string Dose, string NoOfDays, string Morning, string Afternoon, string Evening, string Remarks, string InHouse, string Strip)
        {
            MedicinesDetails objM = new MedicinesDetails();
            objM.ID = ID;
            objM.RowNumber = objGP.Count + 1;
            objM.MedicinesType = MedicinesType;
            objM.MedicinesName = MedicinesName;
            objM.Dose = Dose;
            objM.NoOfDays = NoOfDays;
            objM.Morning = Morning;
            objM.Afternoon = Afternoon;
            objM.Evening = Evening;
            objM.Remarks = Remarks;
            objM.InHouse = InHouse;
            objM.Strip = Strip;
            objGP.Add(objM);
            ViewState["ojbpro"] = objGP;
        }


        protected void GridMedicinesDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlMedicinesType = (DropDownList)e.Row.FindControl("ddlMedicinesType");
                DropDownList ddlMedicinesName = (DropDownList)e.Row.FindControl("ddlMedicinesName");
                Label lblMedicinesType = (Label)e.Row.FindControl("lblMedicinesType");
                Label lblMedicines_Name = (Label)e.Row.FindControl("lblMedicines_Name");
                Label lblInHouse = (Label)e.Row.FindControl("lblInHouse");
                CheckBox CheckBoxInHouse = (CheckBox)e.Row.FindControl("CheckBoxInHouse");
                TextBox txtMedicinesName = (TextBox)e.Row.FindControl("txtMedicinesName");

                Label lblMorning = (Label)e.Row.FindControl("lblMorning");
                CheckBox CheckBoxMorningN = (CheckBox)e.Row.FindControl("CheckBoxMorningN");

                Label lblAfternoon = (Label)e.Row.FindControl("lblAfternoon");
                CheckBox CheckBoxAfternoonN = (CheckBox)e.Row.FindControl("CheckBoxAfternoonN");

                Label lblEvening = (Label)e.Row.FindControl("lblEvening");
                CheckBox CheckBoxEveningN = (CheckBox)e.Row.FindControl("CheckBoxEveningN");

                if (lblMorning.Text == "Yes")
                {
                    CheckBoxMorningN.Checked = true;
                }
                else
                {
                    CheckBoxMorningN.Checked = false;
                }

                if (lblAfternoon.Text == "Yes")
                {
                    CheckBoxAfternoonN.Checked = true;
                }
                else
                {
                    CheckBoxAfternoonN.Checked = false;
                }

                if (lblEvening.Text == "Yes")
                {
                    CheckBoxEveningN.Checked = true;
                }
                else
                {
                    CheckBoxEveningN.Checked = false;
                }





                if (lblInHouse.Text == "Yes")
                {
                    CheckBoxInHouse.Checked = true;
                    txtMedicinesName.Visible = false;
                    ddlMedicinesName.Visible = true;
                }
                else
                {
                    CheckBoxInHouse.Checked = false;
                    txtMedicinesName.Visible = true;
                    ddlMedicinesName.Visible = false;
                }

                ddlMedicinesType.DataSource = objMT.GetAllMaterialType("", "Medicine");
                ddlMedicinesType.DataValueField = "MaterialTypeId";
                ddlMedicinesType.DataTextField = "MaterialName";
                ddlMedicinesType.DataBind();
                ddlMedicinesType.Items.Insert(0, new ListItem("---Medicines Type---", "0"));
                //ddlMedicinesType.Items.Insert(ddlMedicinesType.Items.Count, new ListItem("Other", "Other"));
                ddlMedicinesType.SelectedValue = lblMedicinesType.Text;
                BindMedicines(ref ddlMedicinesName, lblMedicinesType.Text);
                ddlMedicinesName.SelectedValue = lblMedicines_Name.Text;


            }
        }


        public void BindMedicines(ref DropDownList ddlMedicinesName, string MaterialType)
        {


            AllData = objMedicines.GetAllMedicines("", MaterialType);

            ddlMedicinesName.DataSource = AllData;
            ddlMedicinesName.DataTextField = "MedicinesName";
            ddlMedicinesName.DataValueField = "MedicinesId";
            ddlMedicinesName.DataBind();
            ddlMedicinesName.Items.Insert(0, new ListItem("---Medicines---", "0"));

        }



        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddMedicinesRow(true);
        }

        protected void GridMedicinesDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<MedicinesDetails> objinvoice = ViewState["ojbpro"] as List<MedicinesDetails>;
            objinvoice.RemoveAt(e.RowIndex);
            GridMedicinesDetails.DataSource = objinvoice;
            GridMedicinesDetails.DataBind();


        }

        protected void ddlMedicinesType_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlMedicinesType = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlMedicinesType.NamingContainer;
            if (row != null)
            {
                DropDownList ddlMedicinesName = (DropDownList)row.FindControl("ddlMedicinesName");
                TextBox txtMedicinesName = (TextBox)row.FindControl("txtMedicinesName");
                string MedicinesType = "0";

                //txtMedicinesName.Visible = false;
                //ddlMedicinesName.Visible = true;

                MedicinesType = ddlMedicinesType.SelectedValue;
                AllData = objMedicines.GetAllMedicines("", MedicinesType);
                ddlMedicinesName.DataSource = AllData;
                ddlMedicinesName.DataTextField = "MedicinesName";
                ddlMedicinesName.DataValueField = "MedicinesId";
                ddlMedicinesName.DataBind();
                ddlMedicinesName.Items.Insert(0, new ListItem("---Medicines---", "0"));

            }


        }

        protected void CheckBoxInHouse_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox InHouse = (CheckBox)sender;
            GridViewRow row = (GridViewRow)InHouse.NamingContainer;
            if (row != null)
            {
                DropDownList ddlMedicinesName = (DropDownList)row.FindControl("ddlMedicinesName");
                TextBox txtMedicinesName = (TextBox)row.FindControl("txtMedicinesName");

                if (InHouse.Checked)
                {

                    txtMedicinesName.Visible = false;
                    ddlMedicinesName.Visible = true;

                }
                else
                {

                    txtMedicinesName.Visible = true;
                    ddlMedicinesName.Visible = false;


                }

            }
        }

        protected void btnMedicines_Click(object sender, EventArgs e)
        {
            int SelectedItems = 0;
            int _isInserted = -1;

            int CNo = 0;
            CNo = objCT.CNoMaster();

            foreach (GridViewRow row in GridMedicinesDetails.Rows)
            {
                string Morning1 = "";
                string Afternoon1 = "";
                string Evening1 = "";
                string InHouse = "";
                string MedicinesName = "";
                int Medicines = 0;
                int MedicinesPrice = 0;
                int TotalPrice = 0, TotalG = 0, PreAmount = 0, DiscountAmount = 0;


                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox txtMedicinesName = (row.Cells[0].FindControl("txtMedicinesName") as TextBox);
                    //TextBox txtMtype = (row.Cells[0].FindControl("txtMtype") as TextBox);
                    TextBox txtTotal = (row.Cells[0].FindControl("txtTotalDose") as TextBox);
                    TextBox txtTotalDay = (row.Cells[0].FindControl("txtTotalNoofDays") as TextBox);
                    CheckBox CheckBoxMorning = (row.Cells[0].FindControl("CheckBoxMorningN") as CheckBox);
                    CheckBox CheckBoxAfternoon = (row.Cells[0].FindControl("CheckBoxAfternoonN") as CheckBox);
                    CheckBox CheckBoxEvening = (row.Cells[0].FindControl("CheckBoxEveningN") as CheckBox);
                    TextBox txtRemarks = (row.Cells[0].FindControl("txtRemarksN") as TextBox);
                    TextBox txtStrip = (row.Cells[0].FindControl("txtStrip") as TextBox);

                    CheckBox CheckBoxInHouse = (row.Cells[0].FindControl("CheckBoxInHouse") as CheckBox);

                    DropDownList ddlMedicinesName = (row.Cells[0].FindControl("ddlMedicinesName") as DropDownList);
                    DropDownList ddlMedicinesType = (row.Cells[0].FindControl("ddlMedicinesType") as DropDownList);

                    if (CheckBoxInHouse.Checked == true)
                    {
                        InHouse = "Yes";
                        MedicinesName = ddlMedicinesName.SelectedItem.Text;
                        Medicines = Convert.ToInt32(ddlMedicinesName.SelectedValue);
                    }
                    else
                    {
                        MedicinesName = txtMedicinesName.Text;
                        InHouse = "No";
                        Medicines = 0;
                    }

                    if (CheckBoxMorning.Checked == true)
                    {
                        Morning1 = "Yes";

                    }
                    else
                    {

                        Morning1 = "No";
                    }



                    if (CheckBoxAfternoon.Checked == true)
                    {
                        Afternoon1 = "Yes";

                    }
                    else
                    {

                        Afternoon1 = "No";
                    }

                    if (CheckBoxEvening.Checked == true)
                    {
                        Evening1 = "Yes";

                    }
                    else
                    {

                        Evening1 = "No";
                    }
                    int Price = 0;
                    DataTable Dt = objMedicines.GetSelectMedicines(Medicines);
                    if (Dt != null && Dt.Rows.Count > 0)
                    {
                        DiscountAmount = Convert.ToInt32(txtMDiscount.Text);
                        Price = Convert.ToInt32(Dt.Rows[0]["Price"]);
                        MedicinesPrice = Convert.ToInt32(Dt.Rows[0]["Price"]) * Convert.ToInt32(txtStrip.Text);
                        PreAmount = (MedicinesPrice * Convert.ToInt32(DiscountAmount)) / 100;
                        TotalG = MedicinesPrice - PreAmount;
                    }

                    _isInserted = objCT.Add_Medicines(patientid, MedicinesName, Medicines, ddlMedicinesType.SelectedItem.Text, txtTotal.Text, txtTotalDay.Text, Morning1, Afternoon1, Evening1, txtRemarks.Text, InHouse, CNo, Convert.ToInt32(DoctorID), MedicinesPrice, Convert.ToDecimal(DiscountAmount), Convert.ToDecimal(PreAmount), Convert.ToDecimal(TotalG), txtStrip.Text);
                    SelectedItems++;


                }




            }


            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Medicines Added Successfully')", true);


            lblMessage.ForeColor = System.Drawing.Color.Green;
            getAlaGridViewViewMedicines(patientid);
            GridMedicinesDetails.DataSource = null;
            GridMedicinesDetails.DataBind();

            AddMedicinesRow(true);

            txtMDiscount.Text = "";

            if (_isInserted == -1)
            {
                lblMessage.Text = "Failed to Add Medicines";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Medicines Added Successfully')", true);

                lblMessage.Text = "Medicines Added Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Clear();

                getAlaGridViewViewMedicines(patientid);


            }

        }



        public void getAlaGridViewViewMedicines(long Pid)
        {

            DataTable AllData14 = objinv.GetViewMedicinesInvoice(Convert.ToInt32(Pid));

            if (AllData14 != null && AllData14.Rows.Count > 0)
            {
                GridViewViewMedicines.DataSource = AllData14;
                GridViewViewMedicines.DataBind();


            }
        }
        protected void BtlMedicinesPrint_Click(object sender, EventArgs e)
        {
            //  Response.Redirect("MedicinesPrint.aspx?Cno=" + Cno + "&Fid=" + 1 + "&Back=" + 1);

        }

        protected void GridViewViewMedicines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int CNo = Convert.ToInt32(GridViewViewMedicines.DataKeys[rowIndex].Values[0]);
            int patientid = Convert.ToInt32(GridViewViewMedicines.DataKeys[rowIndex].Values[1]);
            Response.Redirect("MedicinesPrint.aspx?CNo=" + CNo + "&patientid=" + patientid);
        }
    }
}