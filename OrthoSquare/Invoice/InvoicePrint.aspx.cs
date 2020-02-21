﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrthoSquare.BAL_Classes;

namespace OrthoSquare.Invoice
{
    public partial class InvoicePrint : System.Web.UI.Page
    {
        BAL_InvoiceDetails objinv =new BAL_InvoiceDetails ();
        public static DataTable AllData = new DataTable();
        public static DataTable dtFid = new DataTable();
        int InvCode = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["InvoiceCode"] != null)
            {
                InvCode = Convert.ToInt32(Request.QueryString["InvoiceCode"]);
                BindInvoice(InvCode);
            }
           // BindInvoice(16);
        }


        public void BindInvoice(int InvCode)
        {
            if (InvCode != 0)
            {

                try
                {

                    string  Fid = Request.QueryString["Fid"].ToString ();

                    if (Fid == "1")
                    {

                        dtFid = objinv.GetAllInvoiceDetails(InvCode);
                    }
                    else
                    {

                        dtFid = objinv.GetAllInvoiceDetailsFid(InvCode, Fid);


                    }
                    if (dtFid != null)
                    {
                        lblpatient.Text = dtFid.Rows[0]["PFristName"].ToString() + " " + dtFid.Rows[0]["PLastName"].ToString();
                        lblDoctername.Text = dtFid.Rows[0]["DFirstName"].ToString() + " " + dtFid.Rows[0]["DLastName"].ToString();
                        //lblPanNo.Text = dt.Rows[0]["PatientCode"].ToString();
                        lblMNo.Text = dtFid.Rows[0]["Mobile"].ToString();
                        lblEmail.Text = dtFid.Rows[0]["Email"].ToString();
                        lblGender.Text = dtFid.Rows[0]["Gender"].ToString();
                        lblAge.Text = dtFid.Rows[0]["Age"].ToString();
                        lblBloodGroup.Text = dtFid.Rows[0]["BloodGroup"].ToString();

                        lblAddress.Text = dtFid.Rows[0]["Address"].ToString();
                      //  lblTotal.Text = Convert.ToDecimal(dt.Rows[0]["GrandTotal"]).ToString("#,##0.00");
                        lblInvoiceDate.Text = Convert.ToDateTime(dtFid.Rows[0]["PayDate"]).ToString("dd-MM-yyyy");
                        lblInvoiceNo.Text = dtFid.Rows[0]["InvoiceCode"].ToString();

                        lblTotalFooter.Text = Convert.ToDecimal(dtFid.Rows[0]["TotalCostAmount"]).ToString("#,##0.00");
                        lblTaxAmount.Text = Convert.ToDecimal(dtFid.Rows[0]["TotalTax"]).ToString("#,##0.00");
                        lblNetAmount.Text = Convert.ToDecimal(dtFid.Rows[0]["GrandTotal"]).ToString("#,##0.00");
                        lblpaidAmount.Text = Convert.ToDecimal(dtFid.Rows[0]["PaidAmount"]).ToString("#,##0.00");
                        lblpendingAmount.Text = Convert.ToDecimal(dtFid.Rows[0]["PendingAmount"]).ToString("#,##0.00");


                        lblTotalCoust1.Text = Convert.ToDecimal(dtFid.Rows[0]["TotalCost"]).ToString("#,##0.00");
                        lbldiscount1.Text = Convert.ToDecimal(dtFid.Rows[0]["TotalDiscount"]).ToString("#,##0.00");

                        lblWordsAmount.Text = "Rupees " + NumberToWords_Large(Convert.ToInt32(dtFid.Rows[0]["PaidAmount"])) + " only";


                        lblClinic.Text = dtFid.Rows[0]["ClinicName"].ToString();
                        lblMobailNo.Text = dtFid.Rows[0]["PhoneNo2"].ToString();
                        lblAddress1.Text = dtFid.Rows[0]["AddressLine1"].ToString();
                        lblEmail1.Text = dtFid.Rows[0]["EmailID"].ToString();
                        BindInvoiceAmount(InvCode);



                        BindInvoicePaymentDetils(InvCode);
                    }

                 
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

         public void BindInvoiceAmount(int INV)
        {
            //DataTable dt =

             AllData = objinv.GetAllInvoiceAmount(INV);
             grdInvoice.DataSource = AllData;
            grdInvoice.DataBind();

        }

         public void BindInvoicePaymentDetils(int INV)
        {
            DataTable dt = objinv.GetAllInvoicePaymentDetila(INV);
            GridpayDetails.DataSource = dt;
            GridpayDetails.DataBind();

        }

         protected void Button1_Click(object sender, EventArgs e)
         {
             Response.Redirect("ViewInvice.aspx");
         }
        
         public string NumberToWords_Large(Int64 number)
         {
             if (number == 0)
                 return "Zero";

             if (number < 0)
                 return "Minus " + NumberToWords_Large(Math.Abs(number));

             string words = "";

             //if ((number / 1000000) > 0)
             //{
             //    words += NumberToWords_Large(number / 1000000) + " Million ";
             //    number %= 1000000;
             //}

             if ((number / 100000) > 0)
             {
                 words += NumberToWords_Large(number / 100000) + " Lacs ";
                 number %= 100000;
             }
             if ((number / 1000) > 0)
             {
                 words += NumberToWords_Large(number / 1000) + " Thousand ";
                 number %= 1000;
             }

             if ((number / 100) > 0)
             {
                 words += NumberToWords_Large(number / 100) + " Hundred ";
                 number %= 100;
             }

             if (number > 0)
             {
                 if (words != "")
                     words += "And ";

                 var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                 var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                 if (number < 20)
                     words += unitsMap[number];
                 else
                 {
                     words += tensMap[number / 10];
                     if ((number % 10) > 0)
                         words += "-" + unitsMap[number % 10];
                 }
             }

             return words;
         }
    }
}