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
using System.Data.SqlClient;
using System.Configuration;

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
        BAL_Finance objF = new BAL_Finance();
        clsCommonMasters objcommon = new clsCommonMasters();
        decimal TotalCost;
        decimal TotalDiscount;
        int PID = 0;
        decimal sumFooterValue = 0;
        //  int invoiceNo = 0;

        public static DataTable AllData1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPayDate.Text = Request.Form[txtPayDate.UniqueID];

            if (!Page.IsPostBack)
            {
                txtBDate_CalendarExtender.StartDate = DateTime.Now.AddDays(-2);

                // txtBDate_CalendarExtender.StartDate = DateTime.Now.AddDays(-2);
                txtPayDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                // AddEmployeeRow(true);
                // BindDocter();
                bindClinic();
                BindDocter(0);
                //if (SessionUtilities.RoleID == 1)
                //{
                //    //ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                //    BindDocter(Convert.ToInt32(SessionUtilities.Empid));
                //    // BindPatient();
                //}
                //else
                //{

                //}



                if (Request.QueryString["pid"] != null)
                {
                    PatientId = int.Parse(Request.QueryString["pid"].ToString());
                    if (PatientId > 0)
                    {
                        bindSelectPatient(Convert.ToInt32(PatientId));
                        bindPatientInvoiceNo(Convert.ToInt32(PatientId));

                        GetPatientInvoiceDetsils(Convert.ToInt32(PatientId));
                        // bindPatientInvoiceNo(Convert.ToInt32(PatientId));
                        // ddlpatient.Enabled = false;

                        txtPatientName.ReadOnly = true;
                        ddlInvoiceNo.Attributes.Add("disabled", "disabled");
                        BindTOClinicandDOctor(Convert.ToInt32(PatientId));
                        bindDetilsOfinvoice(Convert.ToInt32(PatientId), 0);
                        gvInformationId.Visible = true;

                    }
                }
                else
                {

                }

            }
        }


        public void bindFinance()
        {

            DataTable dt;

            dt = objF.GetAllFinance();
            RadioButtonListFinance.DataSource = dt;
            RadioButtonListFinance.DataValueField = "Financeid";
            RadioButtonListFinance.DataTextField = "FinanceName";
            RadioButtonListFinance.DataBind();
            RadioButtonListFinance.Items.Insert(0, new ListItem("-- Select Finance --", "0", true));
        }
        public void bindSelectPatient(int pid)
        {

            DataTable dt = objp.GETPatientSelect(pid);
            txtPatientName.Text = dt.Rows[0]["Fname"].ToString();


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


        private string invoiceCode
        {
            get
            {
                if (ViewState["invoiceCode"] != null)
                {
                    return (string)ViewState["invoiceCode"];
                }
                return "";
            }
            set
            {
                ViewState["invoiceCode"] = value;
            }
        }


        private string Downpayment
        {
            get
            {
                if (ViewState["Downpayment"] != null)
                {
                    return (string)ViewState["Downpayment"];
                }
                return "";
            }
            set
            {
                ViewState["Downpayment"] = value;
            }
        }

        //private string invoiceCode
        //{
        //    get
        //    {
        //        if (ViewState["invoiceCode"] != null)
        //        {
        //            return (long)ViewState["invoiceCode"];
        //        }
        //        return 0;
        //    }
        //    set
        //    {
        //        ViewState["invoiceCode"] = value;
        //    }
        //}

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



        public void getAlltodayConsultation(long Pid, int InvoiceNo)
        {

            txtPAID1.Text = Convert.ToDecimal(objinv.GetPaidInvoicMaster(Convert.ToInt32(PatientId), Convert.ToInt32(InvoiceNo))).ToString();

            List<invoiceDetils> objinvoice = objCT.GetInvoiceDetailsyId(Pid, Convert.ToInt32(InvoiceNo));

            if (objinvoice != null && objinvoice.Count > 0)
            {

                gvInformation.DataSource = objinvoice;
                gvInformation.DataBind();

                CalData();
            }
            else
            {
                AddEmployeeRow(true);
                // AddEmployeeRow(true);
            }
        }

        public void bindPatientInvoiceNo(int Pid)
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
            Session["Cid"] = ddlClinic.SelectedValue;
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

        private void AddEmployeeRow(ref List<invoiceDetils> objinvoice, int ID, int TreatmentID, string Unit, string Cost, string Discount, string Tex, int ISInvoice, string toothno)
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
            objInv.toothNo = toothno;
            objinvoice.Add(objInv);
            ViewState["ojbpro"] = objinvoice;
        }

        public void BindTREATMENTS(ref DropDownList ddlTreatment)
        {
            ddlTreatment.DataSource = objt.GetAllTreatment("");
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


                    TexTotal = Total * Convert.ToDecimal(ddlTAX.SelectedItem.Text) / 100;

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

            PaidAmount = Convert.ToDecimal(objinv.GetPaidInvoice(Convert.ToInt32(PatientId), Convert.ToInt32(invoiceNo)));

            txtPAID1.Text = PaidAmount.ToString();

            if (CheckBoxFinance.Checked)
            {
                txtPendingAmount.Text = Downpayment.ToString();
                lblPendingAmt.Text = Downpayment.ToString();
            }
            else
            {
                txtPendingAmount.Text = (Convert.ToDecimal(lblGrandTotal.Text) - PaidAmount).ToString();
                lblPendingAmt.Text = (Convert.ToDecimal(lblGrandTotal.Text) - PaidAmount).ToString();
            }

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

            //  invoiceNo = 0;


            //int INVDELETE = objinv.InvoiceDetilsDelete(Convert.ToInt32(ddlpatient.SelectedValue));

            if (invoiceNo == 0)
            {

                invoiceNo = objcomm.GetinvoiceNo();
                lblinvCode.Text = invoiceNo.ToString();

                InvoiceCode = objcomm.GetPaymentinvoiceNo();

                invoiceCode = "INV" + InvoiceCode;


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
                        Label lblTooth = (row.Cells[0].FindControl("lblTooth") as Label);
                        ListBox ddltooth = (row.Cells[0].FindControl("ddltooth") as ListBox);


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

                            int c = 0;
                            string x = "";
                            string chkSelectedTooth = "";
                            int toothCont = 0;
                            foreach (ListItem item1 in ddltooth.Items)
                            {
                                if (item1.Selected)
                                {
                                    c += 1;
                                    x += item1.Text + ",";
                                }
                            }
                            if (c > 0)
                            {
                                chkSelectedTooth = x.Remove(x.Length - 1, 1);
                                toothCont = c;
                            }

                            if (lblISInvoice.Text == "0")
                            {
                                _isInserted123 = objinv.InvoiceDetailsTritment(Convert.ToInt32(Tid.Value), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, lblISInvoice.Text, chkSelectedTooth, txtPayDate.Text, ddlClinic.SelectedValue);
                                _isInserted = objinv.Add_InvoiceDetails(0, Convert.ToInt32(invoiceNo), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, TotalCost1, TotalDiscount1, TotalTax1, GrandTotal1, "0", "0", SessionUtilities.Empid, txtPayDate.Text, Convert.ToInt32(lblISInvoice.Text), InvCode, chkSelectedTooth, 0, "", 0, 0);

                            }
                            else
                            {
                                _isInserted123 = objinv.InvoiceDetailsTritment(Convert.ToInt32(Tid.Value), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, lblISInvoice.Text, lblTooth.Text, txtPayDate.Text, ddlClinic.SelectedValue);
                                _isInserted = objinv.Add_InvoiceDetails(0, Convert.ToInt32(invoiceNo), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, TotalCost1, TotalDiscount1, TotalTax1, GrandTotal1, "0", "0", SessionUtilities.Empid, txtPayDate.Text, Convert.ToInt32(lblISInvoice.Text), InvCode, lblTooth.Text, 0, "", 0, 0);

                            }


                        }
                        else
                        {
                            _isInserted123 = objinv.InvoiceDetailsTritment(Convert.ToInt32(Tid.Value), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, lblISInvoice.Text, lblTooth.Text, txtPayDate.Text,ddlClinic.SelectedValue);
                            _isInserted = objinv.Add_InvoiceDetails(0, Convert.ToInt32(invoiceNo), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, TotalCost1, TotalDiscount1, TotalTax1, GrandTotal1, "0", "0", SessionUtilities.Empid, txtPayDate.Text, Convert.ToInt32(lblISInvoice.Text), InvCode, lblTooth.Text, 0, "", 0, 0);

                        }



                        SelectedItems++;

                    }

                }

            }
            else
            {
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
                        ListBox ddltooth = (row.Cells[0].FindControl("ddltooth") as ListBox);
                        Label lblTooth = (row.Cells[0].FindControl("lblTooth") as Label);

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

                        int c = 0;
                        string x = "";
                        string chkSelectedTooth = "";
                        int toothCont = 0;
                        foreach (ListItem item1 in ddltooth.Items)
                        {
                            if (item1.Selected)
                            {
                                c += 1;
                                x += item1.Text + ",";
                            }
                        }
                        if (c > 0)
                        {
                            chkSelectedTooth = x.Remove(x.Length - 1, 1);
                            toothCont = c;
                        }


                        if (lblISInvoice.Text == "0" || lblISInvoice.Text == "2")
                        {
                            _isInserted123 = objinv.InvoiceDetailsTritment(Convert.ToInt32(Tid.Value), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, lblISInvoice.Text, lblTooth.Text, txtPayDate.Text,ddlClinic.SelectedValue);
                            _isInserted = objinv.Add_InvoiceDetails(0, Convert.ToInt32(invoiceNo), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, Discount1.ToString(), ddlTAX.SelectedItem.Text, TotalCost1, TotalDiscount1, TotalTax1, GrandTotal1, "0", "0", SessionUtilities.Empid, txtPayDate.Text, Convert.ToInt32(lblISInvoice.Text), InvCode, lblTooth.Text, 0, "", 0, 0);

                        }

                        SelectedItems++;

                    }

                }



            }

            decimal DownPayment = 0;
            decimal FinanceAmount = 0;
            decimal RevenueAmount = 0;
            string FinanceType = "";



            if (txtApprovalAmount.Text == "")
            {
                ApprovalAmount = "0.0";

            }
            else
            {
                ApprovalAmount = txtApprovalAmount.Text;
            }

            if (txtrevenueamounts.Text == "")
            {
                Interest = "0.0";
            }
            else
            {
                Interest = txtrevenueamounts.Text;
            }

            if (RadioButtonListFinance.SelectedValue != "")
            {
                Finance = RadioButtonListFinance.SelectedItem.Text;
            }
            else
            {
                Finance = "";
            }


            if (CheckBoxFinance.Checked)
            {

                if (txtDownpayment.Text == "0")
                {
                    FinanceAmount = 0;
                    FinanceType = "";
                    RevenueAmount = 0;
                    DownPayment = 0;
                }
                else
                {
                    FinanceAmount = Convert.ToDecimal(txtApprovalAmount.Text) - Convert.ToDecimal(txtDownpayment.Text);
                    FinanceType = "Finance";
                    RevenueAmount = Convert.ToDecimal(txtrevenueamounts.Text);
                    DownPayment = Convert.ToDecimal(txtDownpayment.Text);
                }
                int invoiceNoF = 0;
                int InvoiceCodeF = 0;
                string Fno = "";

                if (Convert.ToDecimal(txtDownpayment.Text) > 0)
                {
                   
                    _isInserted1 = objinv.Add_InvoiceDetails(1, Convert.ToInt32(invoiceNo), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), 0, "0", "0", "0", "0", Convert.ToDecimal(lblTotalCost.Text), Convert.ToDecimal(lblTotalDiscount.Text), Convert.ToDecimal(lblTotalTax.Text), Convert.ToDecimal(lblGrandTotal.Text), txtPaidAmount.Text, txtPendingAmount.Text, SessionUtilities.Empid, txtPayDate.Text, 0, invoiceCode, "", 0, FinanceType, FinanceAmount, RevenueAmount);

                    _isInserted2 = objinv.Add_InvoicePaymentDetails(Convert.ToInt32(invoiceNo), DropDownList1.SelectedItem.Text, txtBankName.Text, txtBranchName.Text, txtCheckNO.Text, txtCheckDate.Text, txtCardNo.Text, lbl_filepath1.Text, ApprovalAmount, Interest, ApprovalAmount, txtEMIStartDate.Text, txtIRFC.Text, txtPaidAmount.Text, txtPendingAmount.Text, SessionUtilities.Empid, Finance, txtPayDate.Text);

                    InvoiceCodeF = objcomm.GetPaymentinvoiceNo();
                    Fno = "INV" + InvoiceCodeF;
                }
                else
                {
                    Fno = invoiceCode;
                }
                
              

                _isInserted1 = objinv.Add_InvoiceDetails(1, Convert.ToInt32(invoiceNo), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), 0, "0", "0", "0", "0", Convert.ToDecimal(lblTotalCost.Text), Convert.ToDecimal(lblTotalDiscount.Text), Convert.ToDecimal(lblTotalTax.Text), Convert.ToDecimal(lblGrandTotal.Text), FinanceAmount.ToString(), txtPendingAmount.Text, SessionUtilities.Empid, txtPayDate.Text, 0, Fno, "", Convert.ToDecimal(txtDownpayment.Text), FinanceType, 0, RevenueAmount);
                _isInserted2 = objinv.Add_InvoicePaymentDetails(Convert.ToInt32(invoiceNo), RadioButtonListFinance.SelectedItem.Text, txtBankName.Text, txtBranchName.Text, txtCheckNO.Text, txtCheckDate.Text, txtCardNo.Text, lbl_filepath1.Text, ApprovalAmount, Interest, ApprovalAmount, txtEMIStartDate.Text, txtIRFC.Text, txtPaidAmount.Text, txtPendingAmount.Text, SessionUtilities.Empid, Finance, txtPayDate.Text);





            }
            else
            {

                _isInserted1 = objinv.Add_InvoiceDetails(1, Convert.ToInt32(invoiceNo), Convert.ToInt32(PatientId), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlClinic.SelectedValue), 0, "0", "0", "0", "0", Convert.ToDecimal(lblTotalCost.Text), Convert.ToDecimal(lblTotalDiscount.Text), Convert.ToDecimal(lblTotalTax.Text), Convert.ToDecimal(lblGrandTotal.Text), txtPaidAmount.Text, txtPendingAmount.Text, SessionUtilities.Empid, txtPayDate.Text, 0, invoiceCode, "", 0, FinanceType, FinanceAmount, RevenueAmount);

                _isInserted2 = objinv.Add_InvoicePaymentDetails(Convert.ToInt32(invoiceNo), DropDownList1.SelectedItem.Text, txtBankName.Text, txtBranchName.Text, txtCheckNO.Text, txtCheckDate.Text, txtCardNo.Text, lbl_filepath1.Text, ApprovalAmount, Interest, ApprovalAmount, txtEMIStartDate.Text, txtIRFC.Text, txtPaidAmount.Text, txtPendingAmount.Text, SessionUtilities.Empid, Finance, txtPayDate.Text);

            }


            //if (DropDownList1.SelectedItem.Text == "Bajaj finance")
            //{


            //    foreach (GridViewRow row in GridViewInstallment.Rows)
            //    {
            //        if (row.RowType == DataControlRowType.DataRow)
            //        {
            //            TextBox txtEMIsAmount = (row.Cells[0].FindControl("txtEMIsAmount") as TextBox);
            //            TextBox txtDateofEMI = (row.Cells[0].FindControl("txtDateofEMI") as TextBox);


            //            int p = objinv.SaveBajaEMI(Convert.ToInt32(invoiceNo), Convert.ToInt32(PatientId), txtEMIsAmount.Text, txtDateofEMI.Text);
            //        }
            //    }
            //}



            if (_isInserted1 == -1)
            {
                lblMessage.Text = "Failed to Add Invoice (Please make sure you have filled all fields, where not required there should be 0)";
                lblMessage.ForeColor = System.Drawing.Color.Red;

                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please make sure you have filled all fields, where not required there should be 0')", true);
                objcomm.ShowMessage(this, "Please make sure you have filled all fields, where not required there should be 0");

                txtPaidAmount.Text = "";
                txtApprovalAmount.Text = "";
            }
            else
            {
                // invoiceNo = 0;
                string msg;
                string msgP;
                lblMessage.Text = "Invoice Added Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                btFeedback.Visible = true;

                txtPayDate.Text = "";
                //   this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invoice Added Successfully')", true);

                objcomm.ShowMessage(this, "Invoice Added Successfully");

                txtPaidAmount.Text = "0";
                txtPAID1.Text = "0";
                txtPaidAmount.Text = "0";
                gvInformation.DataSource = null;
                gvInformation.DataBind();

                txtPendingAmount.Text = "0";

                Panel3.Visible = false;
                bindFinance();
                bindFinanceSchemes(0);

                txtApprovalAmount.Text = "";
                txtDownpayment.Text = "";

                txtrevenueamounts.Text = "";
             
                 this.CheckBoxFinance.Checked = false;
                txtCheckNO.Text = "";
                txtCardNo.Text = "";
                DropDownList1.SelectedValue = "0";

                GetPatientInvoiceDetsils(Convert.ToInt32(PatientId));

                btAdd.Attributes.Add("class", "btn blue disabled");
                btAdd.Attributes.Add("disabled", "disabled");
                DataTable DTP = objp.GetPatient(Convert.ToInt32(PatientId));

                // msg = "Your Appoinment Date :" + txtRegDate.Text + " " + "Time : " + txtRegDate.Text + " has been Booked Appoinment";
                msg = "Your Consultation has been completed. ";
                msgP = "Your Payment :" + txtPaidAmount.Text + " has been received on Date: " + System.DateTime.Now.ToString("dd-MM-yyyy") + " and Pending Amount " + txtPendingAmount.Text;
                if (DTP.Rows[0]["registrationToken"].ToString() != "")
                {
                    objN.SendMessage(PatientId.ToString(), DTP.Rows[0]["registrationToken"].ToString(), msg, "Feedback", "5");

                    objN.SendMessage(PatientId.ToString(), DTP.Rows[0]["registrationToken"].ToString(), msgP, "Payment", "6");
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


            }
            if (DropDownList1.SelectedValue == "2")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;


            }
            if (DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "4" || DropDownList1.SelectedValue == "6" || DropDownList1.SelectedValue == "7")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;


            }
            if (DropDownList1.SelectedValue == "5")
            {
                Panel1.Visible = false;
                Panel2.Visible = false;

                bindFinance();
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

                            string Imgname = txtPatientName.Text + PatientId;

                            string path = Server.MapPath(@"~\BajajFinanceDoc\");
                            System.IO.Directory.CreateDirectory(path);
                            FuImage1.SaveAs(path + @"\" + txtPatientName.Text + PatientId + ext);

                            ImagePhoto1.ImageUrl = @"~\BajajFinanceDoc\" + txtPatientName.Text + PatientId + ext;
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



        protected void ddlInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDetilsOfinvoice(Convert.ToInt32(PatientId), 0);

            // bindPatientInvoiceNo(Convert.ToInt32(ddlpatient.SelectedValue));
        }


        public void bindDetilsOfinvoice(int Pid, int InvoiceCode)
        {
            getAlltodayConsultation(Pid, InvoiceCode);

        }





        //------------------------


        protected void btn_AddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeRow(true);

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

                    Label lblTooth = (Label)item.FindControl("lblTooth");


                    AddEmployeeRow(ref objinvoice, Convert.ToInt32(hdnWOEmployeeIDVal), Convert.ToInt32(ddlStatusVal), txtSeatings1.Text, txtCost1.Text, txtDiscount1.Text, "0", Convert.ToInt32(lblISInvoice.Text), lblTooth.Text);

                }
                if (AddBlankRow)
                    AddEmployeeRow(ref objinvoice, 0, 0, "1", "0", "0", "0", 0, "0");
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
                ListBox ddltooth = (ListBox)e.Row.FindControl("ddltooth");
                ImageButton ImageButton1 = (ImageButton)e.Row.FindControl("ImageButton1");
                
                TextBox txtSeatings1 = (TextBox)e.Row.FindControl("txtSeatings1");
                TextBox txtCost1 = (TextBox)e.Row.FindControl("txtCost1");
                TextBox txtDiscount1 = (TextBox)e.Row.FindControl("txtDiscount1");

                Label lblTreatment = (Label)e.Row.FindControl("lblTreatment");
                Label lblTax11 = (Label)e.Row.FindControl("lblTax11");
                Label lblISInvoice = (Label)e.Row.FindControl("lblISInvoice");
                Label lblTooth = (Label)e.Row.FindControl("lblTooth");


                BindTEX(ref ddlTAX1);

                ddltooth.DataSource = objcommon.Gettooth();
                ddltooth.DataTextField = "toothNo";
                ddltooth.DataValueField = "toothID";
                ddltooth.DataBind();
                //ddltooth.Items.Insert(0, new ListItem("--- Select ---", "0"));



                if (lblISInvoice.Text == "1")
                {
                    //txtSeatings1.ReadOnly = true;
                    //txtCost1.ReadOnly = true;
                    //txtDiscount1.ReadOnly = true;
                    BindTREATMENTSold(ref ddlTreatment1);
                    txtSeatings1.Attributes.Add("disabled", "disabled");
                    txtCost1.Attributes.Add("disabled", "disabled");
                    txtDiscount1.Attributes.Add("disabled", "disabled");

                    ddlTAX1.Attributes.Add("disabled", "disabled");
                    ddlTreatment1.Attributes.Add("disabled", "disabled");
                    ImageButton1.Visible = false;

                }
                else
                {
                    BindTREATMENTSNew(ref ddlTreatment1);
                    //txtSeatings1.Attributes.Add("", "");
                    //  txtCost1.Attributes.Add("", "");
                    //txtCost1.Attributes.Add("disabled", "disabled");
                    //txtDiscount1.Attributes.Add(" ", "");
                    txtSeatings1.ReadOnly = false;
                    //   txtCost1.ReadOnly = false;
                    txtDiscount1.ReadOnly = false;

                }


                ddlTAX1.SelectedItem.Text = "0";
                ddlTreatment1.SelectedValue = lblTreatment.Text;

                if (lblTooth.Text == "0")
                {
                    ddltooth.Visible = true;
                    lblTooth.Visible = false;
                }
                else
                {
                    ddltooth.Visible = false;
                    lblTooth.Visible = true;
                }
            }
        }

        public void BindtoothNo(ref DropDownList ddltoothNo)
        {




        }
        public void BindTREATMENTSNew(ref DropDownList ddlTreatment1)
        {

            ddlTreatment1.DataSource = objt.GetAllTreatment("");
            ddlTreatment1.DataTextField = "TreatmentName";
            ddlTreatment1.DataValueField = "TreatmentID";
            ddlTreatment1.DataBind();

            ddlTreatment1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindTREATMENTSold(ref DropDownList ddlTreatment1)
        {

            ddlTreatment1.DataSource = objt.GetAllTreatmentoldAndNew();
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
            ddlTAX1.SelectedItem.Text = "0";
            //   ddlTAX1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        protected void gvInformation_RowCommand(object sender, GridViewCommandEventArgs e)
        {

           // int i = Convert.ToInt32(e.CommandArgument);

            //if (i == 0)
            //{
            //    getAlltodayConsultation(Convert.ToInt32(PatientId), 0);
            //}
            //else
            //{



           //     int ID = objCT.Delete_TreatmentbyPatient(i);

              //  getAlltodayConsultation(Convert.ToInt32(PatientId), 0);
           // }
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

            int A = objinv.SaveFeedBack(Convert.ToInt32(PatientId), "", txtFreedbackDetails.Text, System.DateTime.Now.ToString("dd-MM-yyyy"));

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

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvoiceAdd.aspx");
        }


        public void GetPatientInvoiceDetsils(int Pid)
        {

            DataTable dt;

            dt = objp.GetPatientInvoiceDetsils(Pid);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridViewInvoiceDetails.DataSource = dt;
                GridViewInvoiceDetails.DataBind();
            }

        }

        protected void GridViewInvoiceDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectView")
            {
                gvInformation.DataSource = null;
                gvInformation.DataBind();
                gvInformationId.Visible = true;
                lblMessage.Visible = false;

                PaymentMode.Visible = true;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                invoiceNo = Convert.ToInt32(GridViewInvoiceDetails.DataKeys[rowIndex].Values[0]);
                invoiceCode = GridViewInvoiceDetails.DataKeys[rowIndex].Values[1].ToString();


                int invcode1 = Convert.ToInt32(e.CommandArgument);
                bindDetilsOfinvoice(Convert.ToInt32(PatientId), Convert.ToInt32(invoiceNo));
                btAdd.Attributes.Add("class", "btn blue");
                //  btAdd.Attributes.Add("class", "btn blue");
                btAdd.Attributes.Remove("disabled");
            }


            if (e.CommandName == "PrintView")
            {
                decimal Downpayment = 0;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                invoiceNo = Convert.ToInt32(GridViewInvoiceDetails.DataKeys[rowIndex].Values[0]);
                invoiceCode = GridViewInvoiceDetails.DataKeys[rowIndex].Values[1].ToString();
                Downpayment = Convert.ToDecimal(GridViewInvoiceDetails.DataKeys[rowIndex].Values[2]);
                // Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + invoiceNo + "&Fid=" + 1 + "&Back=" + 1);
                if (Downpayment > 0)
                {
                    Response.Redirect("FinancePrintPage.aspx?InvoiceCode=" + invoiceNo + "&Fid=" + invoiceCode + "&Back=" + 1);

                }
                else
                {
                    Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + invoiceNo + "&Fid=" + invoiceCode + "&Back=" + 1);

                }

            }
        }

        protected void GridViewInvoiceDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal Downpayment = 0;
                Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                Label lblPaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
                Label lblDownpayment = (Label)e.Row.FindControl("lblDownpayment");

                Label lblTreatmentName = (Label)e.Row.FindControl("lblTreatmentName");
                Label lblInvoiceNo = (Label)e.Row.FindControl("lblInvoiceNo");

                Button ButtonSelect = (Button)e.Row.FindControl("ButtonSelect");
                Button btnPrintinv = (Button)e.Row.FindControl("btnPrintinv");



                Downpayment = Convert.ToDecimal(lblDownpayment.Text);
                if (Convert.ToDecimal(lblGrandTotal.Text) == Convert.ToDecimal(lblPaidAmount.Text))
                {
                    ButtonSelect.Visible = false;
                }
                else
                {
                    ButtonSelect.Visible = true;
                }

                if (Downpayment > 0)
                {
                    ButtonSelect.Visible = false;
                    btnPrintinv.Text = "Finance Print";

                }
                string Selected = "";
                string SelectedTreatment = "";
                DataTable dt = objt.GetinvoiceTreatment(lblInvoiceNo.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        Selected += dt.Rows[i]["TreatmentName"] + ",";

                    }
                }

                SelectedTreatment = Selected.Remove(Selected.Length - 1, 1);
                lblTreatmentName.Text = SelectedTreatment;



            }
        }

        protected void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objp.PatientSelect(txtPatientName.Text);
            PatientId = Convert.ToInt32(dt.Rows[0]["PatientId"]);

            bindPatientInvoiceNo(Convert.ToInt32(PatientId));
            // bindDetilsOfinvoice(Convert.ToInt32(ddlpatient.SelectedValue));
            GetPatientInvoiceDetsils(Convert.ToInt32(PatientId));
            gvInformation.DataSource = null;
            gvInformation.DataBind();

            AddEmployeeRow(true);
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




                    cmd.CommandText = "Select *,P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' as Fname from PatientMaster P left join Enquiry E on E.EnquiryID=P.EnquiryId where  P.IsActive =1 and   P.FristName+' '+ isnull(p.LastName,'')+'  ('+P.PatientCode +')'+  +'  ('+P.Mobile +')' like '%" + prefixText + "%'";


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

        protected void ddlTreatment1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlTreatment1 = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlTreatment1.NamingContainer;

            TextBox txtCost = (TextBox)row.FindControl("txtCost1");
            DataTable dt1 = new DataTable();



            dt1 = objinv.GetTreatmentCost(Convert.ToInt32(ddlTreatment1.SelectedValue));

            if (dt1 != null && dt1.Rows.Count > 0)
            {
                txtCost.Text = dt1.Rows[0]["TreatmentCost"].ToString();
                CalData();

            }
        }

        protected void ddltooth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox ddltooth = (ListBox)sender;
            GridViewRow row = (GridViewRow)ddltooth.NamingContainer;

            TextBox Unit = (TextBox)row.FindControl("txtSeatings1");

            int c = 0;
            string x = "";
            string chkSelectedTooth = "";
            int toothCont = 0;
            foreach (ListItem item1 in ddltooth.Items)
            {
                if (item1.Selected)
                {
                    c += 1;
                    x += item1.Text + ",";
                }
            }
            if (c > 0)
            {
                chkSelectedTooth = x.Remove(x.Length - 1, 1);
                toothCont = c;
            }

            Unit.Text = toothCont.ToString();
            CalData();


        }


        public void bindFinanceSchemes(int Fid)
        {

            DataTable dt;

            dt = objinv.GetFinanceSchemes(Fid, 1);
            ddlFinanceSchemes.DataSource = dt;
            ddlFinanceSchemes.DataValueField = "Scheme_ID";
            ddlFinanceSchemes.DataTextField = "Scheme_Name";
            ddlFinanceSchemes.DataBind();
            ddlFinanceSchemes.Items.Insert(0, new ListItem("-- Select Finance Schemes --", "0", true));

        }



        protected void RadioButtonListFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindFinanceSchemes(Convert.ToInt32(RadioButtonListFinance.SelectedValue));
        }

        protected void ddlFinanceSchemes_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            dt = objinv.GetFinanceSchemes(Convert.ToInt32(ddlFinanceSchemes.SelectedValue), 3);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataTable dtFinanceTerms = new DataTable();
                decimal AddAmount = 0;
                decimal SubAmount = 0;

                dtFinanceTerms = objinv.GetFinanceSchemes(Convert.ToInt32(dt.Rows[0]["Scheme_ID"]), 2);
                if (dtFinanceTerms != null && dtFinanceTerms.Rows.Count > 0)
                {
                    for (int i = 0; i < dtFinanceTerms.Rows.Count; i++)
                    {
                        if (dtFinanceTerms.Rows[i]["CalculationMode"].ToString() == "p")
                        {
                            AddAmount += Convert.ToDecimal(dtFinanceTerms.Rows[i]["TermValue"]);
                        }

                        if (dtFinanceTerms.Rows[i]["CalculationMode"].ToString() == "m")
                        {
                            SubAmount += Convert.ToDecimal(dtFinanceTerms.Rows[i]["TermValue"]);
                        }
                    }
                }

                int NoOfEMI = 0;
                decimal DownpaymentF = 0;
                decimal ApprovalAmount = 0;
                decimal PendingAmountF = 0;
                decimal RevenueAmounts = 0;
                decimal NoOfEMIAmounts = 0;
                NoOfEMI = Convert.ToInt32(dt.Rows[0]["No_Of_EMIs"]);

                //   txtInterest.Text = dt.Rows[0]["DownPayment"].ToString();
                //PendingAmountF = (Convert.ToDecimal(txtPendingAmount.Text) + AddAmount) - SubAmount;
                PendingAmountF = Convert.ToDecimal(lblPendingAmt.Text);
                NoOfEMIAmounts = Convert.ToDecimal(lblPendingAmt.Text) / NoOfEMI;

                //Downpayment = (PendingAmountF * Convert.ToDecimal(dt.Rows[0]["DownPayment"]) / 100);

                DownpaymentF = NoOfEMIAmounts * Convert.ToDecimal(dt.Rows[0]["DownPayment"]);
                Downpayment = DownpaymentF.ToString();
                ApprovalAmount = PendingAmountF - DownpaymentF;
                txtApprovalAmount.Text = PendingAmountF.ToString("###0.00");
                txtrevenueamounts.Text = ((ApprovalAmount + AddAmount) - SubAmount).ToString("###0.00");

                if (DownpaymentF > 0)
                {
                    txtPaidAmount.Text = DownpaymentF.ToString("###0.00");

                    txtPendingAmount.Text = DownpaymentF.ToString("###0.00");

                    txtDownpayment.Text = DownpaymentF.ToString("###0.00");

                    PaymentMode.Visible = true;
                }
                else
                {

                    txtPaidAmount.Text = PendingAmountF.ToString("###0.00");
                    txtPendingAmount.Text = DownpaymentF.ToString("###0.00");
                    txtDownpayment.Text = DownpaymentF.ToString("###0.00");
                    PaymentMode.Visible = false;
                }

                txtEMIStartDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");


            }

        }



        protected void CheckBoxFinance_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxFinance.Checked)
            {
                Panel3.Visible = true;
                bindFinance();
                bindFinanceSchemes(0);
            }
            else
            {
                Panel3.Visible = false;
            }


        }

        protected void txtApprovalAmount_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = objinv.GetFinanceSchemes(Convert.ToInt32(ddlFinanceSchemes.SelectedValue), 3);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataTable dtFinanceTerms = new DataTable();
                decimal AddAmount = 0;
                decimal SubAmount = 0;

                dtFinanceTerms = objinv.GetFinanceSchemes(Convert.ToInt32(dt.Rows[0]["Scheme_ID"]), 2);
                if (dtFinanceTerms != null && dtFinanceTerms.Rows.Count > 0)
                {
                    for (int i = 0; i < dtFinanceTerms.Rows.Count; i++)
                    {
                        if (dtFinanceTerms.Rows[i]["CalculationMode"].ToString() == "p")
                        {
                            AddAmount += Convert.ToDecimal(dtFinanceTerms.Rows[i]["TermValue"]);
                        }

                        if (dtFinanceTerms.Rows[i]["CalculationMode"].ToString() == "m")
                        {
                            SubAmount += Convert.ToDecimal(dtFinanceTerms.Rows[i]["TermValue"]);
                        }
                    }
                }

                int NoOfEMI = 0;
                decimal DownpaymentF = 0;
                decimal ApprovalAmount = 0;
                decimal PendingAmountF = 0;
                decimal RevenueAmounts = 0;
                decimal NoOfEMIAmounts = 0;
                decimal ApprovalAmountPending = 0;
                NoOfEMI = Convert.ToInt32(dt.Rows[0]["No_Of_EMIs"]);

                ApprovalAmountPending = Convert.ToDecimal(lblPendingAmt.Text) - Convert.ToDecimal(txtApprovalAmount.Text);
                //   txtInterest.Text = dt.Rows[0]["DownPayment"].ToString();
                //PendingAmountF = (Convert.ToDecimal(txtPendingAmount.Text) + AddAmount) - SubAmount;
                PendingAmountF = Convert.ToDecimal(txtApprovalAmount.Text);
                NoOfEMIAmounts = Convert.ToDecimal(txtApprovalAmount.Text) / NoOfEMI;

                //Downpayment = (PendingAmountF * Convert.ToDecimal(dt.Rows[0]["DownPayment"]) / 100);

                DownpaymentF = NoOfEMIAmounts * Convert.ToDecimal(dt.Rows[0]["DownPayment"]);
                Downpayment = (DownpaymentF + ApprovalAmountPending).ToString();
                ApprovalAmount = PendingAmountF - DownpaymentF;
                txtApprovalAmount.Text = PendingAmountF.ToString("###0.00");
                txtrevenueamounts.Text = ((ApprovalAmount + AddAmount) - SubAmount).ToString("###0.00");

                if (DownpaymentF > 0)
                {
                    txtPaidAmount.Text = (DownpaymentF + ApprovalAmountPending).ToString("###0.00");
                    txtPendingAmount.Text = (DownpaymentF + ApprovalAmountPending).ToString("###0.00");
                    txtDownpayment.Text = DownpaymentF.ToString("###0.00");

                    PaymentMode.Visible = true;
                }
                else
                {


                   // txtPaidAmount.Text = (PendingAmountF + ApprovalAmountPending).ToString("###0.00");
                    txtPaidAmount.Text = Convert.ToDecimal(txtApprovalAmount.Text).ToString("###0.00");
                    txtPendingAmount.Text = (DownpaymentF + ApprovalAmountPending).ToString("###0.00");

                    txtDownpayment.Text = DownpaymentF.ToString("###0.00");
                    PaymentMode.Visible = false;
                }

                txtEMIStartDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");


            }
        }

        protected void gvInformation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<invoiceDetils> objinvoice = ViewState["ojbpro"] as List<invoiceDetils>;
            objinvoice.RemoveAt(e.RowIndex);
            gvInformation.DataSource = objinvoice;
            gvInformation.DataBind();

            CalData();
        }
    }
}