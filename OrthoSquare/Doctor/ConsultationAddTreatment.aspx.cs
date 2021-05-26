﻿using System;
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

namespace OrthoSquare.Doctor
{
    public partial class ConsultationAddTreatment : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        public static DataTable AllData1 = new DataTable();
        public static DataTable AllData2 = new DataTable();
        public static DataTable AllData3 = new DataTable();
        public static DataTable AllData4 = new DataTable();
        BAL_Appointment ojbApp =new BAL_Appointment ();
        BAL_Patient objPatient = new BAL_Patient();
        BAL_ConsultationAddTreatment objCT = new BAL_ConsultationAddTreatment();
        BAL_Treatment objT = new BAL_Treatment();
        BAL_Patient objp = new BAL_Patient();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_LabsDetails objL = new BAL_LabsDetails();
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
                   
                    patientTm(Pid,0);
                    
                    Edit.Visible = false;
                    Add.Visible = true;
                }
                else
                {
                    getAllDetails();

                }


                bindDentalTreatmentWorkDone();
                invoiceTreatmen();
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
            txtToothNo.Attributes.Add("autocomplete", "off");
            txtTreatment.Attributes.Add("autocomplete", "off");
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
            ddltooth11.Items.Insert(0, new ListItem("--- Select ---", "0"));


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

            ddlToothNo1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        protected void ddlToothNo1_SelectedIndexChangedToothNo1(object sender, EventArgs e)
        {
            string name = "";

            for (int i = 0; i < ddlToothNo1.Items.Count; i++)
            {
                if (ddlToothNo1.Items[i].Selected)
                {
                    name += ddlToothNo1.Items[i].Text + ",";
                    lID += ddlToothNo1.Items[i].Value + ",";
                }
            }
            txtToothNo.Text = name;

        }



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
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            string name = "";

            for (int i = 0; i < ddltooth11.Items.Count; i++)
            {
                if (ddltooth11.Items[i].Selected)
                {
                    name += ddltooth11.Items[i].Text + ",";
                    lID += ddltooth11.Items[i].Value + ",";
                }
            }
            TextBox1.Text = name;

        }

        protected void GridTreatment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddltooth1 = (DropDownList)e.Row.FindControl("ddltooth");

                Label lblTooth = (Label)e.Row.FindControl("lblTooth");
                Label lblStartedTreatments = (Label)e.Row.FindControl("lblStartedTreatments");
                CheckBox CheckBoxT = (CheckBox)e.Row.FindControl("CheckBoxT");

                
                DataTable dt = objcommon.Gettooth();


                ddltooth1.DataSource = dt;
                ddltooth1.DataTextField = "toothNo";
                ddltooth1.DataValueField = "toothID";
                ddltooth1.DataBind();


              //  ddltooth1.SelectedItem.Text = lblTooth.Text;



                if(lblStartedTreatments.Text =="No")
                {
                     lblStartedTreatments.ForeColor = System.Drawing.Color.Red;
                     CheckBoxT.Checked = false;
                }
                else
                {
                    lblStartedTreatments.ForeColor = System.Drawing.Color.Green;
                    CheckBoxT.Checked = true;
                    CheckBoxT.Enabled = false;
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


            if(AllData2.Rows .Count != 0)
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

             patientTm(pid,1);

         }

         public void bindDoctorMaster(int did,int Rolid)
         {
             ddl_DocterDetils.DataSource = objcommon.DoctersMasterNew(did, Rolid);

          //  ddl_DocterDetils.DataSource = objcommon.DoctersMasterNew(did, Rolid);

             ddl_DocterDetils.DataValueField = "DoctorID";
             ddl_DocterDetils.DataTextField = "FirstName";
             ddl_DocterDetils.DataBind();
             ddl_DocterDetils.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

         }
         public void patientTm(int pid,int id)
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
             DoctorID = Convert.ToInt32(ddl_DocterDetils.SelectedValue);

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


                _isInserted = objCT.Add_TreatmentbyPatient(patientid, Convert.ToInt32 (ddl_DocterDetils.SelectedValue), TreatmentID);
                bindDentalCategory();
                txtTreatment.Text = ""; 
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

            int TPD = objCT.Update_TreatmentbyPatientWorkDone(Convert.ToInt32(Request.QueryString["pid"]), Convert.ToInt32(ddlTreatmentbyworkDone .SelectedValue ), ddlToothNoWOrkname .SelectedItem .Text,txtNotsWorkDone.Text);
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
                 DropDownList ddltooth = (item.Cells[0].FindControl("ddltooth") as DropDownList);
                 TextBox txtCost = (item.Cells[0].FindControl("txtCost") as TextBox);
                 Label lblStartedTreatments = (item.Cells[0].FindControl("lblStartedTreatments") as Label);
                  TextBox txtSdate = (item.Cells[0].FindControl("txtSdate") as TextBox);
                if (item.RowType == DataControlRowType.DataRow)
                 {
                     if (chkSelect.Checked == true)
                     {
                         StartedTreatments = "Yes";

                        if (lblStartedTreatments.Text == "No" || lblStartedTreatments.Text=="")
                        {
                            int TPD = objCT.Update_TreatmentbyPatientYES(Convert.ToInt32(lblID.Text), txtCost.Text, ddltooth.SelectedItem.Text, StartedTreatments, txtNots.Text, txtSdate.Text);

                        }
                       
                       
                    }
                     else
                     {

                         StartedTreatments = "No";
                         int TPD = objCT.Update_TreatmentbyPatient(Convert.ToInt32(lblID.Text), txtCost.Text, ddltooth.SelectedItem.Text, StartedTreatments, txtNots.Text,txtSdate.Text);
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
                     search += "PatientCode ='"+txtPatientNo .Text +"'";
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
                     ClinicID =0,
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
                     Email ="",
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
             CleartextBoxes(this);
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
                         ToothNo1 += ddlToothNo1.Items[i].Value + ",";



                     }
                 }

                 if (ToothNo1 != "")
                 {
                     ToothNo1 = ToothNo1.Remove(ToothNo1.Length - 1);
                 }

                 LabDetails objLab = new LabDetails()
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


                 }
             }
             catch (Exception ex)
             {
             }
         }



        public void getAlaGridelb(long Pid)
        {

         DataTable    AllData12 = objL.GetLabsViewDetsilsNEW(Pid);

            if (AllData12 != null && AllData12.Rows.Count > 0)
            {
                GridViewLEBDetais.DataSource = AllData12;
                GridViewLEBDetais.DataBind();


            }
        }




        protected void btAddPTDetails_Click(object sender, EventArgs e)
         {
             InsertMultipleImage();

             //int _isInserted = -1;

             //_isInserted = objCT.Add_PTGallreryDetails(0, patientid, Convert.ToInt32(ddlTreatmentDetails.SelectedValue), txtRemarks.Text, lbl_filepath1.Text);



             //if (_isInserted == -1)
             //{
             //    lblMessage.Text = "Failed to Add Treatment Image";
             //    lblMessage.ForeColor = System.Drawing.Color.Red;
             //}
             //else
             //{

             //    lblMessage.Text = "Treatment Image Added Successfully";
             //    lblMessage.ForeColor = System.Drawing.Color.Green;
             //    Clear();


             //}

         }

         protected void btBackPT_Click(object sender, EventArgs e)
         {

         }
         private void invoiceTreatmen()
         {
             DataTable dt = new DataTable();
             DataRow dr = null;
             dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
             dt.Columns.Add(new DataColumn("Column1", typeof(string)));
             dt.Columns.Add(new DataColumn("Column2", typeof(string)));
             dt.Columns.Add(new DataColumn("Column3", typeof(string)));
             dt.Columns.Add(new DataColumn("Column4", typeof(string)));
             dt.Columns.Add(new DataColumn("Column5", typeof(string)));
             dt.Columns.Add(new DataColumn("Column6", typeof(string)));
             dt.Columns.Add(new DataColumn("Column7", typeof(string)));
             dt.Columns.Add(new DataColumn("Column8", typeof(string)));

             dr = dt.NewRow();
             dr["RowNumber"] = 1;
             dr["Column1"] = string.Empty;
             dr["Column2"] = string.Empty;
             dr["Column3"] = string.Empty;
             dr["Column4"] = string.Empty;
             dr["Column5"] = string.Empty;
             dr["Column6"] = string.Empty;
             dr["Column7"] = string.Empty;
             dr["Column8"] = string.Empty;


             dt.Rows.Add(dr);
             //dr = dt.NewRow();
             //Store the DataTable in ViewState
             ViewState["CurrentTableGridDrowers"] = dt;

             Gridinvoice.DataSource = dt;
             Gridinvoice.DataBind();
         }

         private void AddNewRowToGridSetInitialInvoice()
         {
             int rowIndex = 0;

             if (ViewState["CurrentTableGridDrowers"] != null)
             {
                 DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableGridDrowers"];


                 DataRow drCurrentRow = null;
                 if (dtCurrentTable.Rows.Count > 0)
                 {
                     for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                     {
                         //extract the TextBox values
                         TextBox box1 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[1].FindControl("txtMedicinesName");
                         TextBox box2 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[2].FindControl("txtMtype");
                         TextBox box3 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[3].FindControl("txtTotal");
                         TextBox box4 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[4].FindControl("txtTotalDay");
                         CheckBox box5 = (CheckBox)Gridinvoice.Rows[rowIndex].Cells[5].FindControl("CheckBoxMorning");
                         CheckBox box6 = (CheckBox)Gridinvoice.Rows[rowIndex].Cells[6].FindControl("CheckBoxAfternoon");
                         CheckBox box7 = (CheckBox)Gridinvoice.Rows[rowIndex].Cells[7].FindControl("CheckBoxEvening");
                         TextBox box8 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[8].FindControl("txtRemarks");



                         drCurrentRow = dtCurrentTable.NewRow();
                         drCurrentRow["RowNumber"] = i + 1;

                         dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                         dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                         dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                         dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
                         dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;
                         dtCurrentTable.Rows[i - 1]["Column6"] = box6.Text;
                         dtCurrentTable.Rows[i - 1]["Column7"] = box7.Text;
                         dtCurrentTable.Rows[i - 1]["Column8"] = box8.Text;
                         rowIndex++;
                     }
                     dtCurrentTable.Rows.Add(drCurrentRow);
                     ViewState["CurrentTableGridDrowers"] = dtCurrentTable;

                     Gridinvoice.DataSource = dtCurrentTable;
                     Gridinvoice.DataBind();
                 }
             }
             else
             {
                 Response.Write("ViewState is null");
             }

             //Set Previous Data on Postbacks
             SetPreviousDataSetInitialinvoide();
         }

         private void SetPreviousDataSetInitialinvoide()
         {
             int rowIndex = 0;
             if (ViewState["CurrentTableGridDrowers"] != null)
             {
                 DataTable dt = (DataTable)ViewState["CurrentTableGridDrowers"];
                 if (dt.Rows.Count > 0)
                 {
                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                         TextBox box1 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[1].FindControl("txtMedicinesName");
                         TextBox box2 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[2].FindControl("txtMtype");
                         TextBox box3 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[3].FindControl("txtTotal");
                         TextBox box4 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[4].FindControl("txtTotalDay");
                         CheckBox box5 = (CheckBox)Gridinvoice.Rows[rowIndex].Cells[5].FindControl("CheckBoxMorning");
                         CheckBox box6 = (CheckBox)Gridinvoice.Rows[rowIndex].Cells[6].FindControl("CheckBoxAfternoon");
                         CheckBox box7 = (CheckBox)Gridinvoice.Rows[rowIndex].Cells[7].FindControl("CheckBoxEvening");
                         TextBox box8 = (TextBox)Gridinvoice.Rows[rowIndex].Cells[8].FindControl("txtRemarks");


                         box1.Text = dt.Rows[i]["Column1"].ToString();
                         box2.Text = dt.Rows[i]["Column2"].ToString();
                         box3.Text = dt.Rows[i]["Column3"].ToString();
                         box4.Text = dt.Rows[i]["Column4"].ToString();
                         box5.Text = dt.Rows[i]["Column5"].ToString();

                         box6.Text = dt.Rows[i]["Column6"].ToString();
                         box7.Text = dt.Rows[i]["Column7"].ToString();
                         box8.Text = dt.Rows[i]["Column8"].ToString();



                         rowIndex++;
                     }
                 }
             }
         }
         protected void ButtonAddGridInvoice_Click(object sender, EventArgs e)
         {
             AddNewRowToGridSetInitialInvoice();
         }

         protected void Gridinvoice_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 DropDownList ddlTreatment = (DropDownList)e.Row.FindControl("ddlTreatment");

               //  BindTREATMENTS(ref ddlTreatment);



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



                   _isInserted = objCT.Add_complaintinsert(patientid, txtcomplaint.Text, txtlistDentalTreatment.Text, lID);
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
                 BindComplaints();
                 Panel4.Visible = true;
                 Panel3.Visible = false;
             }

         }



         protected void btnMedicines_Click(object sender, EventArgs e)
         {
             int SelectedItems = 0;
             int _isInserted = -1;

             string Morning1 = "";
             string Afternoon1 = "";
             string Evening1 = "";

             foreach (GridViewRow row in Gridinvoice.Rows)
             {
                 if (row.RowType == DataControlRowType.DataRow)
                 {
                     TextBox txtMedicinesName = (row.Cells[0].FindControl("txtMedicinesName") as TextBox);
                     TextBox txtMtype = (row.Cells[0].FindControl("txtMtype") as TextBox);
                     TextBox txtTotal = (row.Cells[0].FindControl("txtTotal") as TextBox);
                     TextBox txtTotalDay = (row.Cells[0].FindControl("txtTotalDay") as TextBox);
                     CheckBox CheckBoxMorning = (row.Cells[0].FindControl("CheckBoxMorning") as CheckBox);
                     CheckBox CheckBoxAfternoon = (row.Cells[0].FindControl("CheckBoxAfternoon") as CheckBox);
                     CheckBox CheckBoxEvening = (row.Cells[0].FindControl("CheckBoxEvening") as CheckBox);
                     TextBox txtRemarks = (row.Cells[0].FindControl("txtRemarks") as TextBox);


                     if (CheckBoxMorning.Checked ==true )
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


                     _isInserted = objCT.Add_Medicines(patientid, txtMedicinesName.Text, txtMtype.Text, txtTotal.Text, txtTotalDay.Text, Morning1, Afternoon1, Evening1, txtRemarks.Text);

                     SelectedItems++;

                 }

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Medicines Added Successfully')", true);

                lblMessage.Text = "Medicines Added Successfully";
                 lblMessage.ForeColor = System.Drawing.Color.Green;
                 getAlaGridViewViewMedicines(patientid);
                invoiceTreatmen();
             }
             
             
             


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

          DataTable   AllData14 = objCT.GetAdd_Medicines(Pid);

            if (AllData14 != null && AllData14.Rows.Count > 0)
            {
                GridViewViewMedicines.DataSource = AllData14;
                GridViewViewMedicines.DataBind();

               
            }
        }


        protected void ButtonInvoice_Click(object sender, EventArgs e)
         {
             //Response.Redirect = "~/Invoice/InvoiceAdd.aspx";

             Response.Redirect("../Invoice/InvoiceAdd.aspx?pid=" + patientid );
         }



         protected void btAddTreatmentPlan_Click(object sender, EventArgs e)
         {

             int _isInserted = -1;

             _isInserted = objCT.Add_TreatmentbyPlan(patientid, Convert.ToInt32(ddl_DocterDetils.SelectedValue), txtPlanDetails.Text);



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
                 Clear();
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

                string lbl_filepath11 = "" ;

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



         protected void CheckBoxList1_SelectedIndexChangedTreatment(object sender, EventArgs e)
         {
             string name = "";

             for (int i = 0; i < ddlTreatment.Items.Count; i++)
             {
                 if (ddlTreatment.Items[i].Selected)
                 {
                     name += ddlTreatment.Items[i].Text + ",";
                     lID += ddlTreatment.Items[i].Value + ",";
                 }
             }
             txtTreatment.Text = name;

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

        //protected void BtnTphotos_Click(object sender, EventArgs e)
        //{


        //}
    }
}