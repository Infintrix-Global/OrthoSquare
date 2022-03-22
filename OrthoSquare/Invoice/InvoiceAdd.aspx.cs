using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrthoSquare.BAL_Classes;

using OrthoSquare.Utility;
using System.IO;
namespace OrthoSquare.Invoice
{
    public partial class InvoiceAdd : System.Web.UI.Page
    {
        BAL_Treatment objt = new BAL_Treatment();
        BAL_InvoiceDetails objinv = new BAL_InvoiceDetails();
        clsCommonMasters objcomm = new clsCommonMasters();
        BAL_DoctorsDetails objdoc = new BAL_DoctorsDetails();
        BAL_ConsultationAddTreatment objCT = new BAL_ConsultationAddTreatment();
        public static DataTable AllData = new DataTable();
        BAL_Clinic objc = new BAL_Clinic();
        Notificationnew objN = new Notificationnew();
        BAL_Patient objp = new BAL_Patient();
        decimal TotalCost;
        decimal TotalDiscount;
        int PID = 0;
        decimal sumFooterValue = 0;
        //  int invoiceNo = 0;

        public static DataTable AllData1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtPayDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                AddEmployeeRow(true);
                // BindDocter();
                bindClinic();

                if (SessionUtilities.RoleID == 1)
                {
                    //ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindDocter(Convert.ToInt32(SessionUtilities.Empid));
                    // BindPatient();
                }




                if (Request.QueryString["pid"] != null)
                {
                    PID = int.Parse(Request.QueryString["pid"].ToString());
                    if (PID > 0)
                    {
                        BindPatient();
                        bindPatientInvoiceNo(Convert.ToInt32(ddlpatient.SelectedValue));

                        ddlpatient.SelectedValue = PID.ToString();
                        bindPatientInvoiceNo(Convert.ToInt32(ddlpatient.SelectedValue));
                        //   ddlpatient.Enabled = false;
                        ddlpatient.Attributes.Add("disabled", "disabled");
                        ddlInvoiceNo.Attributes.Add("disabled", "disabled");
                        BindTOClinicandDOctor(PID);
                        bindDetilsOfinvoice(PID);
                    }
                }

            }
        }


        private long invoiceNo
        {
            get
            {
                if (ViewState["invoiceNo"] != null)
                {
                    return (long)ViewState["invoiceNo"];
                }
                return 0;
            }
            set
            {
                ViewState["invoiceNo"] = value;
            }
        }



        public void BindTOClinicandDOctor(int Pid)
        {

            DataTable dt = objcomm.GetDataInTritmentByPai(Pid);

            if (dt.Rows.Count > 0 && dt != null)
            {
                ddlClinic.SelectedValue = dt.Rows[0]["ClinicID"].ToString();
                BindDocter(Convert.ToInt32(ddlClinic.SelectedValue));
                ddlDoctor.SelectedValue = dt.Rows[0]["DoctorID"].ToString();
            }
        }

        private List<invoiceDetils> EmployeeInfo
        {
            get
            {
                if (ViewState["EmployeeInfo"] != null)
                {
                    return (List<invoiceDetils>)ViewState["EmployeeInfo"];
                }
                return new List<invoiceDetils>();
            }
            set
            {
                ViewState["EmployeeInfo"] = value;
            }
        }



        public void getAlltodayConsultation(long Pid)
        {



            txtPAID1.Text = Convert.ToDecimal(objinv.GetPaidInvoicMaster(Convert.ToInt32(ddlpatient.SelectedValue), Convert.ToInt32(ddlInvoiceNo.SelectedValue))).ToString();

            List<invoiceDetils> objinvoice = objCT.GetInvoiceDetailsyId(Pid, Convert.ToInt32(ddlInvoiceNo.SelectedValue));


            if (objinvoice != null && objinvoice.Count > 0)
            {

                gvInformation.DataSource = objinvoice;
                gvInformation.DataBind();

                CalData();
            }
            else
            {
                //  AddEmployeeRow(true);
                // AddEmployeeRow(true);
            }
        }

        public void bindPatientInvoiceNo(int  Pid)
        {

            DataTable dt;

            dt = objp.GetPatientInvoiceNo(Pid);
            ddlInvoiceNo.DataSource = dt;
            ddlInvoiceNo.DataValueField = "InvoiceNo";
            ddlInvoiceNo.DataTextField = "InvoiceCode";
            ddlInvoiceNo.DataBind();
            ddlInvoiceNo.Items.Insert(0, new ListItem("-- Select Invoice No --", "0", true));

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
                dt = objc.GetAllClinicDetais();

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
            BindPatient();
        }



        public void BindDocter(int Cid)
        {
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDoctor.DataSource = objcomm.DoctersMaster(Cid, SessionUtilities.RoleID);

            }
            else
            {
                ddlDoctor.DataSource = objcomm.DoctersMasterNewENQ11(Cid, SessionUtilities.RoleID);

            }

            ddlDoctor.DataTextField = "DoctorName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();
            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        //public void BindDocter()
        //{
        //    int Did=0;
        //    if(SessionUtilities .RoleID ==3 )
        //    {

        //        Did = SessionUtilities.Empid;

        //    }
        //    else if(SessionUtilities.RoleID == 1)
        //    {

        //        Did = SessionUtilities.Empid;
        //    }
        //    else
        //    {

        //        Did = 0;
        //    }

        //    ddlDoctor.DataSource = objcomm.DoctersMasterNew(Did, Convert .ToInt32 (SessionUtilities.RoleID));
        //    ddlDoctor.DataTextField = "FirstName";
        //    ddlDoctor.DataValueField = "DoctorID";
        //    ddlDoctor.DataBind();

        //    ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        //}


        public void BindPatient()
        {
            ddlpatient.DataSource = objp.NewGetPatientlist(Convert.ToInt32(ddlClinic.SelectedValue));
            ddlpatient.DataTextField = "Fname";
            ddlpatient.DataValueField = "patientid";
            ddlpatient.DataBind();

            ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        private void AddEmployeeRow(ref List<invoiceDetils> objinvoice, int ID, int TreatmentID, string Unit, string Cost, string Discount, string Tex, int ISInvoice)

        {
            invoiceDetils objInv = new invoiceDetils();
            objInv.ID = ID;
            objInv.TreatmentID = TreatmentID;
            objInv.RowNumber = objinvoice.Count + 1;
            objInv.Tex = Tex;
            objInv.Unit = Unit;
            objInv.Cost = Cost;
            objInv.Discount = Discount;
            objInv.ISInvoice = ISInvoice;
            objinvoice.Add(objInv);
        }

        public void BindTREATMENTS(ref DropDownList ddlTreatment)
        {
            ddlTreatment.DataSource = objt.GetAllTreatment();
            ddlTreatment.DataTextField = "TreatmentName";
            ddlTreatment.DataValueField = "TreatmentID";
            ddlTreatment.DataBind();

            ddlTreatment.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void CalData()
        {
            lblGrandTotal.Text = "0";
            decimal Total = 0;
            decimal TextTotal = 0;
            decimal TexTotal = 0;
            decimal Qty = 0;
            decimal TotalCost1 = 0;
            decimal TotalDiscount1 = 0;
            decimal PaidAmount = 0;


            foreach (GridViewRow row in gvInformation.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    TextBox txtSeatings1 = (row.Cells[0].FindControl("txtSeatings1") as TextBox);
                    TextBox txtCost1 = (row.Cells[0].FindControl("txtCost1") as TextBox);
                    TextBox txtDiscount1 = (row.Cells[0].FindControl("txtDiscount1") as TextBox);
                    DropDownList ddlTAX = (row.Cells[0].FindControl("ddlTAX1") as DropDownList);

                    if (txtSeatings1.Text != "")
                    {
                        Qty = Decimal.Parse(txtSeatings1.Text);
                    }

                    string A = TotalCost1.ToString();

                    if (txtCost1.Text != "")
                    {
                        TotalCost1 = TotalCost1 + (Decimal.Parse(txtCost1.Text) * Qty);
                    }
                    if (txtDiscount1.Text != "")
                    {
                        TotalDiscount1 += Decimal.Parse(txtDiscount1.Text);

                        Total = (Decimal.Parse(txtCost1.Text) * Qty) - Decimal.Parse(txtDiscount1.Text);

                    }

                    //   Total = TotalCost1 - TotalDiscount1;


                    TexTotal = Total * Convert.ToInt32(ddlTAX.SelectedItem.Text) / 100;

                    if (TexTotal != 0)
                    {
                        TextTotal += Convert.ToDecimal(TexTotal);
                    }
                }
            }


            lblTotalCost.Text = TotalCost1.ToString();
            //  lblTotalDiscount.Text = TotalDiscount.ToString();
            lblTotalDiscount.Text = TotalDiscount1.ToString();

            lblTotalTax.Text = Convert.ToString(TextTotal);

            // lblGrandTotal.Text = (Total + TextTotal).ToString();

            lblGrandTotal.Text = ((Convert.ToDecimal(lblTotalCost.Text) + (TextTotal)) - Convert.ToDecimal(lblTotalDiscount.Text)).ToString();

            PaidAmount = Convert.ToDecimal(objinv.GetPaidInvoicMaster(Convert.ToInt32(ddlpatient.SelectedValue), Convert.ToInt32(ddlInvoiceNo.SelectedValue)));

            txtPAID1.Text = PaidAmount.ToString();

            txtPendingAmount.Text = (Convert.ToDecimal(lblGrandTotal.Text) - PaidAmount).ToString();
            btAdd.Enabled = true;

        }

        protected void txtSeatings1_TextChanged(object sender, EventArgs e)
        {
            CalData();


        }




        protected void txtCost1_TextChanged(object sender, EventArgs e)
        {
            CalData();
        }


        protected void txtDiscount1_TextChanged(object sender, EventArgs e)
        {
            CalData();
        }




        protected void Invoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalData();
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            TextBox txtSeatings = (TextBox)gvr.FindControl("txtSeatings1");

        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            int _isInserted = -1;
            int _isInserted1 = -1;
            int _isInserted2 = -1;
            int SelectedItems = 0;
            int InvoiceCode = 0;
            decimal TotalCost1 = 0;
            decimal TotalDiscount1 = 0;
            decimal Discount1 = 0;
            decimal TotalTax1 = 0;
            decimal GrandTotal1 = 0;
            string TotalAmount1 = "0.0";
            string ApprovalAmount = "0";
            string Interest = "0";
            string Finance = "";
            string InvCode = "";
            // AllData = objinv.GetAllInvoicTreatment(Convert.ToInt32(ddlpatient.SelectedValue));
            decimal paidAmount;
            // if (AllData.Rows.Count == 0)
            //  {

            invoiceNo = 0;
         

            //int INVDELETE = objinv.InvoiceDetilsDelete(Convert.ToInt32(ddlpatient.SelectedValue));

            if (ddlInvoiceNo.SelectedValue == "0")
            {
                invoiceNo = objcomm.GetinvoiceNo();
                lblinvCode.Text = invoiceNo.ToString();

                InvoiceCode = objcomm.GetPaymentinvoiceNo();

                InvCode = "INV" + InvoiceCode;

                foreach (GridViewRow row in gvInformation.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox txtUnit = (row.Cells[0].FindControl("txtSeatings1") as TextBox);
                        TextBox txtCost = (row.Cells[0].FindControl("txtCost1") as TextBox);
                        TextBox txtDiscount = (row.Cells[0].FindControl("txtDiscount1") as TextBox);
                        DropDownList ddlTreatment = (row.Cells[0].FindControl("ddlTreatment1") as DropDownList);
                        DropDownList ddlTAX = (row.Cells[0].FindControl("ddlTAX1") as DropDownList);
                        HiddenField Tid = (row.Cells[0].FindControl("hdnWOEmployeeID") as HiddenField);
                        Label lblISInvoice = (row.Cells[0].FindControl("lblISInvoice") as Label);
                        TotalCost1 = Convert.ToDecimal(txtCost.Text) * Convert.ToDecimal(txtUnit.Text);
                        if (txtDiscount.Text != "")
                        {
                            Discount1 = Convert.ToDecimal(txtDiscount.Text);
                            TotalDiscount1 = TotalCost1 - Convert.ToDecimal(txtDiscount.Text);
                        }
                        else
                        {
                            TotalDiscount1 = 0;
                            Discount1 = 0;
                        }

                        TotalTax1 = TotalDiscount1 * Convert.ToDecimal(ddlTAX.SelectedItem.Text) / 100;
                        GrandTotal1 = TotalDiscount1 + TotalTax1;

                        int _isInserted123 = 0;


                        if (lblISInvoice.Text == "0" || lblISInvoice.Text == "2")
                        {
                            _isInserted123 = objinv.InvoiceDetailsTritment(Convert.ToInt32(Tid.Value), Convert.ToInt32(ddlpatient.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, lblISInvoice.Text);

                            _isInserted = objinv.Add_InvoiceDetails(0, Convert.ToInt32(invoiceNo), Convert.ToInt32(ddlpatient.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, TotalCost1, TotalDiscount1, TotalTax1, GrandTotal1, "0", "0", SessionUtilities.Empid, txtPayDate.Text, Convert.ToInt32(lblISInvoice.Text), InvCode);

                        }
                        else
                        {
                            _isInserted123 = objinv.InvoiceDetailsTritment(Convert.ToInt32(Tid.Value), Convert.ToInt32(ddlpatient.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, lblISInvoice.Text);

                            _isInserted = objinv.Add_InvoiceDetails(0, Convert.ToInt32(invoiceNo), Convert.ToInt32(ddlpatient.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, TotalCost1, TotalDiscount1, TotalTax1, GrandTotal1, "0", "0", SessionUtilities.Empid, txtPayDate.Text, Convert.ToInt32(lblISInvoice.Text), InvCode);

                        }

                        SelectedItems++;

                    }

                }

            }
            else
            {
                invoiceNo = Convert.ToInt32(ddlInvoiceNo.SelectedValue);
                InvCode = ddlInvoiceNo.SelectedItem.Text;
            }


            _isInserted1 = objinv.Add_InvoiceDetails(1, Convert.ToInt32(invoiceNo), Convert.ToInt32(ddlpatient.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), 0, "0", "0", "0", "0", Convert.ToDecimal(lblTotalCost.Text), Convert.ToDecimal(lblTotalDiscount.Text), Convert.ToDecimal(lblTotalTax.Text), Convert.ToDecimal(lblGrandTotal.Text), txtPaidAmount.Text, txtPendingAmount.Text, SessionUtilities.Empid, txtPayDate.Text,0, InvCode);

            if (DropDownList1.SelectedItem.Text == "Bajaj finance")
            {
                decimal InterestAmount1 = Convert.ToDecimal(txtApprovalAmount.Text) * Convert.ToDecimal(txtInterest.Text) / 100;
                TotalAmount1 = (Convert.ToDecimal(txtApprovalAmount.Text) + InterestAmount1).ToString();
            }

            if (txtApprovalAmount.Text == "")
            {
                ApprovalAmount = "0.0";

            }
            else
            {
                ApprovalAmount = txtApprovalAmount.Text;
            }

            if (txtInterest.Text == "")
            {
                Interest = "0.0";
            }
            else
            {
                Interest = txtInterest.Text;
            }

            if (RadioButtonListFinance.SelectedValue != "")
            {
                Finance = RadioButtonListFinance.SelectedItem.Text;
            }
            else
            {
                Finance = "";
            }




            _isInserted2 = objinv.Add_InvoicePaymentDetails(Convert.ToInt32(invoiceNo), DropDownList1.SelectedItem.Text, txtBankName.Text, txtBranchName.Text, txtCheckNO.Text, txtCheckDate.Text, txtCardNo.Text, lbl_filepath1.Text, ApprovalAmount, Interest, TotalAmount1, txtEMIStartDate.Text, txtIRFC.Text, txtPaidAmount.Text, txtPendingAmount.Text, SessionUtilities.Empid, Finance);

            if (DropDownList1.SelectedItem.Text == "Bajaj finance")
            {


                foreach (GridViewRow row in GridViewInstallment.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox txtEMIsAmount = (row.Cells[0].FindControl("txtEMIsAmount") as TextBox);
                        TextBox txtDateofEMI = (row.Cells[0].FindControl("txtDateofEMI") as TextBox);


                        int p = objinv.SaveBajaEMI(Convert.ToInt32(invoiceNo), Convert.ToInt32(ddlpatient.SelectedValue), txtEMIsAmount.Text, txtDateofEMI.Text);
                    }
                }
            }



            if (_isInserted1 == -1)
            {
                lblMessage.Text = "Failed to Add Invoice (Please make sure you have filled all fields, where not required there should be 0)";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // invoiceNo = 0;
                string msg;
                string msgP;
                lblMessage.Text = "Invoice Added Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                btFeedback.Visible = true;

                //  btAdd.Attributes["disabled"] == "disabled"; // Attributes["disabled"] = "disabled";
                // btAdd.Attributes.Add["disabled"];

                // btAdd.Style["disabled"] = "disabled";



                btAdd.Attributes.Add("class", "btn blue disabled");

                DataTable DTP = objp.GetPatient(Convert.ToInt32(ddlpatient.SelectedValue));

                // msg = "Your Appoinment Date :" + txtRegDate.Text + " " + "Time : " + txtRegDate.Text + " has been Booked Appoinment";
                msg = "Your Consultation has been completed. ";
                msgP = "Your Payment :" + txtPaidAmount.Text + " has been received on Date: " + System.DateTime.Now.ToString("dd-MM-yyyy") + " and Pending Amount " + txtPendingAmount.Text;
                if (DTP.Rows[0]["registrationToken"].ToString() != "")
                {
                    objN.SendMessage(ddlpatient.SelectedValue.ToString(), DTP.Rows[0]["registrationToken"].ToString(), msg, "Feedback", "5");

                    objN.SendMessage(ddlpatient.SelectedValue.ToString(), DTP.Rows[0]["registrationToken"].ToString(), msgP, "Payment", "6");
                }

                // Response.Redirect("InvoiceAdd.aspx");

            }
        }

        protected void btninvoice_Click(object sender, EventArgs e)
        {
            // Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + lblinvCode.Text );

            Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + invoiceNo + "&Fid=" + 1 + "&Back=" + 1);

        }

        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            //  txtPendingAmount.Text = "";
            if (Convert.ToDecimal(txtPaidAmount.Text) == Convert.ToDecimal(txtPendingAmount.Text))
            {
                CalData();
                txtPendingAmount.Text = (Convert.ToDecimal(txtPendingAmount.Text) - Convert.ToDecimal(txtPaidAmount.Text)).ToString();

            }
            else
            {
                if (Convert.ToDecimal(txtPaidAmount.Text) > Convert.ToDecimal(txtPendingAmount.Text))
                {
                    txtPaidAmount.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Pay Amount must be less than or equal to Pending Amount.');", true);
                    CalData();

                }
                else
                {
                    CalData();
                    txtPendingAmount.Text = (Convert.ToDecimal(txtPendingAmount.Text) - Convert.ToDecimal(txtPaidAmount.Text)).ToString();

                }
            }




        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;

            }
            if (DropDownList1.SelectedValue == "2")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;

            }
            if (DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "4" || DropDownList1.SelectedValue == "6" || DropDownList1.SelectedValue == "7")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;

            }
            if (DropDownList1.SelectedValue == "5")
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;

            }
        }

        protected void btnUploadimage_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        public void UploadImage()
        {

            string filename = "", newfile = "";
            string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

            if (!FuImage1.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                FuImage1.Focus();
            }
            // string DD = txtFname.Text;
            string aa = FuImage1.FileName;
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
                    if (!System.IO.Directory.Exists(@"~\BajajFinanceDoc"))
                    {
                        try
                        {



                            //int imgID = objHeandle.HandlmaxID(Convert.ToInt32(ddlBrand.SelectedValue));

                            //int AddImageiD = imgID + 1;

                            string Imgname = ddlpatient.SelectedItem.Text + ddlpatient.SelectedItem;

                            string path = Server.MapPath(@"~\BajajFinanceDoc\");
                            System.IO.Directory.CreateDirectory(path);
                            FuImage1.SaveAs(path + @"\" + ddlpatient.SelectedItem.Text + ddlpatient.SelectedItem + ext);

                            ImagePhoto1.ImageUrl = @"~\BajajFinanceDoc\" + ddlpatient.SelectedItem.Text + ddlpatient.SelectedItem + ext;
                            ImagePhoto1.Visible = true;

                            lbl_filepath1.Text = Imgname + ext;


                        }
                        catch (Exception ex)
                        {
                            lbl_filepath1.Text = "Not able to create new directory";
                        }

                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
            }


        }

        protected void ddlpatient_SelectedIndexChanged(object sender, EventArgs e)
        {
           bindPatientInvoiceNo(Convert.ToInt32(ddlpatient.SelectedValue));
           // bindDetilsOfinvoice(Convert.ToInt32(ddlpatient.SelectedValue));

          
        }

        protected void ddlInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDetilsOfinvoice(Convert.ToInt32(ddlpatient.SelectedValue));

           // bindPatientInvoiceNo(Convert.ToInt32(ddlpatient.SelectedValue));
        }


        public void bindDetilsOfinvoice(int Pid)
        {
            getAlltodayConsultation(Pid);

            int PID1 = 0;
            //AllData = objinv.GetAllInvoicTreatment(Pid);
            //decimal paidAmount;
            //if (AllData != null && AllData.Rows.Count > 0)
            //{

            //    DataTable dt = objinv.GetAllInvoicMaster(Convert.ToInt32(ddlpatient.SelectedValue));

            //    txtPendingAmount.Text = dt.Rows[0]["PendingAmount"].ToString();
            //    lblTotalCost.Text = dt.Rows[0]["TotalCost"].ToString();
            //    lblTotalDiscount.Text = dt.Rows[0]["TotalDiscount"].ToString();
            //    lblTotalTax.Text = dt.Rows[0]["TotalTax"].ToString();

            //    lblGrandTotal.Text = dt.Rows[0]["GrandTotal"].ToString();

            //    ddlDoctor.SelectedValue = dt.Rows[0]["DoctorID"].ToString();
            //    invoiceNo = Convert.ToInt32(dt.Rows[0]["InvoiceNo"]);

            //    //GridinvoiceDetails.DataSource = AllData;
            //    //GridinvoiceDetails.DataBind();

            //    getAlltodayConsultation(PID);

            //    if (txtPendingAmount.Text=="0.00")
            //    {
            //        txtPaidAmount.Enabled = true;
            //        btAdd.Enabled = true;
            //   }
            //}
            //else
            //{
            //    gvInformation.DataSource = null;
            //    gvInformation.DataBind();
            //    //GridinvoiceDetails.DataSource = null;
            //    //GridinvoiceDetails.DataBind();

            //    if (PID ==0)
            //    {
            //        PID = Convert .ToInt32 (ddlpatient .SelectedValue );
            //    }



            //    txtPendingAmount.Text = "";
            //    lblTotalCost.Text = "";
            //    lblTotalDiscount.Text = "";
            //    lblTotalTax.Text = "";

            //    lblGrandTotal.Text = "";

            //   // ddlDoctor.SelectedValue = "0";

            //}

        }





        //------------------------


        protected void btn_AddEmployee_Click(object sender, EventArgs e)
        {



            AddEmployeeRow(true);
            // if (gvInformation.Rows.Count <= 0)
            //WorkoderCoordinator();
        }






        private void AddEmployeeRow(bool AddBlankRow)
        {
            try
            {
                string unit = "", ddlTAX1 = "", ddlStatusVal = "", hdnWOEmployeeIDVal = "";
                int ddlTreatment1;


                List<invoiceDetils> objinvoice = new List<invoiceDetils>();

                foreach (GridViewRow item in gvInformation.Rows)
                {
                    hdnWOEmployeeIDVal = ((HiddenField)item.FindControl("hdnWOEmployeeID")).Value;

                    ddlStatusVal = ((DropDownList)item.FindControl("ddlTreatment1")).SelectedValue;
                    ddlTAX1 = ((DropDownList)item.FindControl("ddlTAX1")).SelectedValue;
                    TextBox txtSeatings1 = (TextBox)item.FindControl("txtSeatings1");
                    TextBox txtCost1 = (TextBox)item.FindControl("txtCost1");
                    TextBox txtDiscount1 = (TextBox)item.FindControl("txtDiscount1");
                    Label lblISInvoice = (Label)item.FindControl("lblISInvoice");
                    AddEmployeeRow(ref objinvoice, Convert.ToInt32(hdnWOEmployeeIDVal), Convert.ToInt32(ddlStatusVal), txtSeatings1.Text, txtCost1.Text, txtDiscount1.Text, ddlTAX1, Convert.ToInt32(lblISInvoice.Text));

                }
                if (AddBlankRow)
                    AddEmployeeRow(ref objinvoice, 0, 0, "1", "0", "0", "0", 0);
                EmployeeInfo = objinvoice;
                gvInformation.DataSource = objinvoice;
                gvInformation.DataBind();


            }
            catch (Exception ex)
            {
                //  divMessage.Visible = true;
                //  divMessageSub.Attributes.Remove("class");
                // divMessageSub.Attributes.Add("class", "errormsg");
                //  lblMsg.Text = "Unable to process request. Please verify the details.<br />" + ex;
            }

        }

        protected void gvInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList ddlTreatment1 = (DropDownList)e.Row.FindControl("ddlTreatment1");
                DropDownList ddlTAX1 = (DropDownList)e.Row.FindControl("ddlTAX1");

                TextBox txtSeatings1 = (TextBox)e.Row.FindControl("txtSeatings1");
                TextBox txtCost1 = (TextBox)e.Row.FindControl("txtCost1");
                TextBox txtDiscount1 = (TextBox)e.Row.FindControl("txtDiscount1");

                Label lblTreatment = (Label)e.Row.FindControl("lblTreatment");
                Label lblTax11 = (Label)e.Row.FindControl("lblTax11");
                Label lblISInvoice = (Label)e.Row.FindControl("lblISInvoice");


                BindTREATMENTS1(ref ddlTreatment1);
                BindTEX(ref ddlTAX1);
                ddlTreatment1.SelectedValue = lblTreatment.Text;
                ddlTAX1.SelectedValue = lblTax11.Text;

                if (lblISInvoice.Text == "1")
                {
                    txtSeatings1.ReadOnly = true;
                    txtCost1.ReadOnly = true;
                    txtDiscount1.ReadOnly = true;
                }
                else
                {

                    txtSeatings1.ReadOnly = false;
                    txtCost1.ReadOnly = false;
                    txtDiscount1.ReadOnly = false;
                }


            }
        }


        public void BindTREATMENTS1(ref DropDownList ddlTreatment1)
        {

            ddlTreatment1.DataSource = objt.GetAllTreatment11();
            ddlTreatment1.DataTextField = "TreatmentName";
            ddlTreatment1.DataValueField = "TreatmentID";
            ddlTreatment1.DataBind();

            ddlTreatment1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }



        public void BindTEX(ref DropDownList ddlTAX1)
        {
            ddlTAX1.DataSource = objt.GetTax();
            ddlTAX1.DataTextField = "GSTRate";
            ddlTAX1.DataValueField = "GSTid";
            ddlTAX1.DataBind();
            ddlTAX1.SelectedValue = "5";
            //   ddlTAX1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        protected void gvInformation_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int i = Convert.ToInt32(e.CommandArgument);

            if (i == 0)
            {
                getAlltodayConsultation(Convert.ToInt32(ddlpatient.SelectedValue));
            }
            else
            {

                int ID = objCT.Delete_TreatmentbyPatient(i);

                getAlltodayConsultation(Convert.ToInt32(ddlpatient.SelectedValue));
            }
        }



        public void bindinstallments()
        {
            if (txtTotalEmi.Text != null && txtTotalEmi.Text != "")
            {
                int noofinstallments = Convert.ToInt32(txtTotalEmi.Text);
                DataTable dt = new DataTable();

                dt.Columns.Add("txtEMIsAmount");
                dt.Columns.Add("txtDateofEMI");

                for (int i = 1; i <= noofinstallments; i++)
                {

                    // add new row
                    DataRow dr = dt.NewRow();

                    dr[0] = "";
                    dr[1] = "";

                    dt.Rows.Add(dr);
                }

                GridViewInstallment.DataSource = dt;
                GridViewInstallment.DataBind();
            }
        }


        protected void AddInstmt_Click(object sender, EventArgs e)
        {
            if (GridViewInstallment.Rows.Count > 0)
            {
                GridViewInstallment.DataSourceID = null;
                GridViewInstallment.DataBind();
            }
            bindinstallments();



        }

        protected void GridViewInstallment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DateTime EMIDate1;

                TextBox txtEMIsAmount = (TextBox)e.Row.FindControl("txtEMIsAmount");
                TextBox txtDateofEMI = (TextBox)e.Row.FindControl("txtDateofEMI");


                decimal InterestAmount = Convert.ToDecimal(txtApprovalAmount.Text) * Convert.ToDecimal(txtInterest.Text) / 100;
                decimal TotalAmount = Convert.ToDecimal(txtApprovalAmount.Text) + InterestAmount;
                decimal EMIAMT = TotalAmount / Convert.ToDecimal(txtTotalEmi.Text);

                if (txtDateofEMI.Text == "")
                {
                    string EMIDate;
                    if (txtEMIStartDate.Text != "")
                    {

                        EMIDate = (Convert.ToDateTime(txtEMIStartDate.Text)).ToString("dd-MM-yyyy");
                        txtDateofEMI.Text = EMIDate;
                        lblSdate.Text = EMIDate;
                        txtEMIStartDate.Text = "";
                    }
                    else
                    {
                        EMIDate1 = (Convert.ToDateTime(lblSdate.Text)).AddDays(1).AddMonths(1).AddDays(-1);
                        txtDateofEMI.Text = EMIDate1.ToString("dd-MM-yyyy");
                        lblSdate.Text = EMIDate1.ToString("dd-MM-yyyy");
                    }
                }


            }



        }


        // 



        protected void btFeedback_Click(object sender, EventArgs e)
        {
            // Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + lblinvCode.Text );

            Add.Visible = false;
            Div1.Visible = true;

        }

        protected void btnSendSendFeedback_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            int A = objinv.SaveFeedBack(Convert.ToInt32(ddlpatient.SelectedValue), "", txtFreedbackDetails.Text, System.DateTime.Now.ToString("dd-MM-yyyy"));

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Login", "alert('Thanks for your feedback')", true);
            btninvoice.Visible = true;
            Add.Visible = true;
            Div1.Visible = false;

        }
        protected void btnSkit_Click(object sender, EventArgs e)
        {
            btninvoice.Visible = true;
            Add.Visible = true;
            Div1.Visible = false;

        }

    }
}