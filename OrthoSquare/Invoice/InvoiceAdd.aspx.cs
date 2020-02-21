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
        BAL_InvoiceDetails objinv=new BAL_InvoiceDetails ();
        clsCommonMasters objcomm =new clsCommonMasters ();
        BAL_DoctorsDetails objdoc = new BAL_DoctorsDetails();
        BAL_ConsultationAddTreatment objCT = new BAL_ConsultationAddTreatment();
        public static DataTable AllData = new DataTable();


        BAL_Patient objp = new BAL_Patient();
         decimal  TotalCost;
         decimal TotalDiscount;
         int PID = 0;
       //  int invoiceNo = 0;

         public static DataTable AllData1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                AddEmployeeRow(true);
                BindDocter();
                BindPatient();

                if (Request.QueryString["pid"] != null)
                {
                    PID = int.Parse(Request.QueryString["pid"].ToString());
                    if (PID > 0)
                    {

                        ddlpatient.SelectedValue = PID.ToString ();
                        
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

         

            List<invoiceDetils> objinvoice = objCT.GetInvoiceDetailsyId(Pid);

            gvInformation.DataSource = objinvoice;
            gvInformation.DataBind();
        }



        public void BindDocter()
        {
            ddlDoctor.DataSource = objdoc.GetAllDocters(SessionUtilities .Empid );
            ddlDoctor.DataTextField = "FirstName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();

            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        public void BindPatient()
        {
            ddlpatient.DataSource = objp.GetPatientlist();
            ddlpatient.DataTextField = "FristName";
            ddlpatient.DataValueField = "patientid";
            ddlpatient.DataBind();

            ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
                     
      



        private void AddEmployeeRow(ref List<invoiceDetils> objinvoice,int ID,int TreatmentID, string Unit, string Cost, string Discount, string Tex)
  
        {
            invoiceDetils objInv = new invoiceDetils();
            objInv.ID = ID;
            objInv.TreatmentID = TreatmentID;
            objInv.RowNumber = objinvoice.Count + 1;
            objInv.Tex = Tex;
            objInv.Unit = Unit;
            objInv.Cost = Cost;
            objInv.Discount = Discount;

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


      

        protected void Invoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal Total;
            decimal TextTotal;
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            TextBox txtSeatings = (TextBox)gvr.FindControl("txtSeatings1");
            TextBox txtCost = (TextBox)gvr.FindControl("txtCost1");
            TextBox txtDiscount = (TextBox)gvr.FindControl("txtDiscount1");
            DropDownList ddlTAX = (DropDownList)gvr.FindControl("ddlTAX1");


            if (lblTotalCost.Text == "")
            {
                TotalCost = 0;

            }
            else
            {
                TotalCost = Convert .ToDecimal (lblTotalCost.Text);
            }

            if (lblTotalDiscount.Text == "")
            {
                TotalDiscount = 0;
            }
            else
            {
                TotalDiscount = Convert.ToDecimal(lblTotalDiscount.Text);
            }

         

            TotalCost += Decimal.Parse(txtCost.Text) * Decimal.Parse(txtSeatings.Text);
            TotalDiscount += Decimal.Parse(txtDiscount.Text) ;


            Total = TotalCost - TotalDiscount;
            TextTotal = Total * 12 / 100;


            lblTotalCost.Text = TotalCost.ToString();
            lblTotalDiscount.Text = TotalDiscount.ToString ();


            lblTotalTax.Text = TextTotal.ToString() ;

            lblGrandTotal.Text = (Total + TextTotal).ToString();
           
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {   int _isInserted = -1;
             int _isInserted1 = -1;
             int _isInserted2 = -1;
             int SelectedItems = 0;

             decimal TotalCost1;
             decimal TotalDiscount1;
             decimal TotalTax1;
             decimal GrandTotal1;
              
             
            
            AllData = objinv.GetAllInvoicTreatment(Convert.ToInt32(ddlpatient.SelectedValue));
            decimal paidAmount;
            if (AllData.Rows.Count == 0)
            {
                invoiceNo = objcomm.GetinvoiceNo();
                lblinvCode.Text = invoiceNo.ToString();


                foreach (GridViewRow row in gvInformation.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox txtUnit = (row.Cells[0].FindControl("txtSeatings1") as TextBox);
                        TextBox txtCost = (row.Cells[0].FindControl("txtCost1") as TextBox);
                        TextBox txtDiscount = (row.Cells[0].FindControl("txtDiscount1") as TextBox);
                        DropDownList ddlTreatment = (row.Cells[0].FindControl("ddlTreatment1") as DropDownList);
                        DropDownList ddlTAX = (row.Cells[0].FindControl("ddlTAX1") as DropDownList);

                        TotalCost1 = Convert.ToDecimal(txtCost.Text) * Convert.ToDecimal(txtUnit.Text);
                        TotalDiscount1 = TotalCost1 - Convert.ToDecimal(txtDiscount.Text);
                        TotalTax1 = TotalDiscount1 * Convert.ToDecimal(ddlTAX.SelectedItem.Text) / 100;
                        GrandTotal1 = TotalDiscount1 + TotalTax1;


                        _isInserted = objinv.Add_InvoiceDetails(0, Convert.ToInt32(invoiceNo), Convert.ToInt32(ddlpatient.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), SessionUtilities.Empid, Convert.ToInt32(ddlTreatment.SelectedValue), txtUnit.Text, txtCost.Text, txtDiscount.Text, ddlTAX.SelectedItem.Text, TotalCost1, TotalDiscount1, TotalTax1, GrandTotal1, "0", "0", SessionUtilities.Empid);

                        SelectedItems++;

                    }

                }


            }

                          int F = objinv.InvoicePendingFUpdate(Convert.ToInt32(ddlpatient.SelectedValue));

                        _isInserted1 = objinv.Add_InvoiceDetails(1, Convert .ToInt32(invoiceNo), Convert.ToInt32(ddlpatient.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue),SessionUtilities .Empid , 0, "0", "0", "0", "0", Convert.ToDecimal(lblTotalCost.Text), Convert.ToDecimal(lblTotalDiscount.Text), Convert.ToDecimal(lblTotalTax.Text), Convert.ToDecimal(lblGrandTotal.Text),txtPaidAmount .Text ,txtPendingAmount.Text ,SessionUtilities .Empid);

                        _isInserted2 = objinv.Add_InvoicePaymentDetails(Convert.ToInt32(invoiceNo), DropDownList1.SelectedItem.Text, txtBankName.Text, txtBranchName.Text, txtCheckNO.Text, txtCheckDate.Text, txtCardNo.Text, lbl_filepath1.Text, txtIRFC.Text, txtPaidAmount.Text, txtPendingAmount.Text, SessionUtilities.Empid);

           

                        if (_isInserted1 == -1)
                        {
                            lblMessage.Text = "Failed to Add Invoice";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                           // invoiceNo = 0;
                            lblMessage.Text = "Invoice Added Successfully";
                            lblMessage.ForeColor = System.Drawing.Color.Green;

                           // Response.Redirect("InvoiceAdd.aspx");
                           
                        }
        }

        protected void btninvoice_Click(object sender, EventArgs e)
        {
           // Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + lblinvCode.Text );

            Response.Redirect("InvoicePrint.aspx?InvoiceCode=" + invoiceNo + "&Fid=" + 1);
          
        }

        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {


            DataTable dt = objinv.GetAllInvoicMaster(Convert.ToInt32(ddlpatient.SelectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {


                if (Convert.ToDecimal(txtPaidAmount.Text) > Convert.ToDecimal(txtPendingAmount.Text))
                {

                }
                else
                {
                    txtPendingAmount.Text = (Convert.ToDecimal(txtPendingAmount.Text) - Convert.ToDecimal(txtPaidAmount.Text)).ToString();

                }
            }

            else
            {

                if (Convert.ToDecimal(txtPaidAmount.Text) > Convert.ToDecimal(lblGrandTotal.Text))
                {

                }
                else
                {
                    txtPendingAmount.Text = (Convert.ToDecimal(lblGrandTotal.Text) - Convert.ToDecimal(txtPaidAmount.Text)).ToString();

                }
            }
          
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1 .SelectedItem .Text =="Cash")
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;

            }
            if (DropDownList1.SelectedItem.Text == "Check")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;

            }
            if (DropDownList1.SelectedItem.Text == "Credit Card" || DropDownList1.SelectedItem.Text == "Debit Card")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;

            }
            if (DropDownList1.SelectedItem.Text == "Bajaj finance")
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

            bindDetilsOfinvoice(Convert.ToInt32(ddlpatient.SelectedValue));
         }



        public void bindDetilsOfinvoice(int Pid)
        {

            AllData = objinv.GetAllInvoicTreatment(Pid);
            decimal paidAmount;
            if (AllData != null && AllData.Rows.Count > 0)
            {

                DataTable dt = objinv.GetAllInvoicMaster(Convert.ToInt32(ddlpatient.SelectedValue));

                txtPendingAmount.Text = dt.Rows[0]["PendingAmount"].ToString();
                lblTotalCost.Text = dt.Rows[0]["TotalCost"].ToString();
                lblTotalDiscount.Text = dt.Rows[0]["TotalDiscount"].ToString();
                lblTotalTax.Text = dt.Rows[0]["TotalTax"].ToString();

                lblGrandTotal.Text = dt.Rows[0]["GrandTotal"].ToString();

                ddlDoctor.SelectedValue = dt.Rows[0]["DoctorID"].ToString();
                invoiceNo = Convert.ToInt32(dt.Rows[0]["InvoiceNo"]);

                GridinvoiceDetails.DataSource = AllData;
                GridinvoiceDetails.DataBind();

                gvInformation.DataSource = null;
                gvInformation.DataBind();
            }
            else
            {

                GridinvoiceDetails.DataSource = null;
                GridinvoiceDetails.DataBind();
                getAlltodayConsultation(PID);
                txtPendingAmount.Text = "";
                lblTotalCost.Text = "";
                lblTotalDiscount.Text = "";
                lblTotalTax.Text = "";

                lblGrandTotal.Text = "";

                ddlDoctor.SelectedValue = "0";

            }

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
                    ddlTAX1 = ((DropDownList)item.FindControl("ddlTAX1")).SelectedItem .Text  ;
                    TextBox txtSeatings1 = (TextBox)item.FindControl("txtSeatings1");
                    TextBox txtCost1 = (TextBox)item.FindControl("txtCost1");
                    TextBox txtDiscount1 = (TextBox)item.FindControl("txtDiscount1");
                  


                    AddEmployeeRow(ref objinvoice, Convert.ToInt32(hdnWOEmployeeIDVal), Convert.ToInt32(ddlStatusVal), txtSeatings1.Text, txtCost1.Text, txtDiscount1.Text, ddlTAX1);

                }
                if (AddBlankRow)
                    AddEmployeeRow(ref objinvoice,0, 0, "", "", "", "");
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

                Label lblTreatment = (Label)e.Row.FindControl("lblTreatment");
                Label lblTax11 = (Label)e.Row.FindControl("lblTax11");

                BindTREATMENTS1(ref ddlTreatment1);
                BindTEX(ref ddlTAX1);
                ddlTreatment1.SelectedValue = lblTreatment.Text;
                ddlTAX1.SelectedItem.Text = lblTax11.Text;

              
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

            ddlTAX1.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }


        protected void gvInformation_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int i = Convert.ToInt32(e.CommandArgument);

            if (i == 0)
            {
                getAlltodayConsultation(Convert .ToInt32 (ddlpatient .SelectedValue ));
            }
            else
            {

                int ID = objCT.Delete_TreatmentbyPatient(i);

                getAlltodayConsultation(Convert.ToInt32(ddlpatient.SelectedValue));
            }
        }
           
          // 


       




    }
}