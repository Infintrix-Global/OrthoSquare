﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrthoSquare.BAL_Classes;
using System.Globalization;
namespace OrthoSquare.Doctor
{
    public partial class MedicinesPrint : System.Web.UI.Page
    {
        BAL_InvoiceDetails objinv = new BAL_InvoiceDetails();
        public static DataTable AllData = new DataTable();
        public static DataTable dtFid = new DataTable();
        int Cno = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["InvoiceCode"] != null)
            {
                Cno = Convert.ToInt32(Request.QueryString["Cno"]);


                BindInvoice(Cno);
            }

            if (Request.QueryString["Back"] != null)
            {
                if (Convert.ToInt32(Request.QueryString["Back"]) == 1)
                {
                    ImageButton1.Visible = true;
                    btnBack.Visible = true;
                }
            }

            // BindInvoice(16);
        }


        public void BindInvoice(int Cno)
        {
            if (Cno != 0)
            {

                try
                {

                 

                        dtFid = objinv.GetAllInvoiceDetails(Cno);
                   
                    if (dtFid != null)
                    {
                        lblpatient.Text = dtFid.Rows[0]["PFristName"].ToString() + " " + dtFid.Rows[0]["PLastName"].ToString();
                     //   lblDoctername.Text = dtFid.Rows[0]["DFirstName"].ToString() + " " + dtFid.Rows[0]["DLastName"].ToString();

                      //  lblDoctorSig.Text = dtFid.Rows[0]["DFirstName"].ToString() + " " + dtFid.Rows[0]["DLastName"].ToString();
                      
                        lblMNo.Text = dtFid.Rows[0]["Mobile"].ToString();
                        lblEmail.Text = dtFid.Rows[0]["Email"].ToString();
                        lblGender.Text = dtFid.Rows[0]["Gender"].ToString();
                        lblAge.Text = dtFid.Rows[0]["Age"].ToString();
                        lblBloodGroup.Text = dtFid.Rows[0]["BloodGroup"].ToString();

                        lblAddress.Text = dtFid.Rows[0]["Address"].ToString() + " ," + dtFid.Rows[0]["Area"].ToString();
                        //  lblTotal.Text = Convert.ToDecimal(dt.Rows[0]["GrandTotal"]).ToString("#,##0.00");
                        lblInvoiceDate.Text = Convert.ToDateTime(dtFid.Rows[0]["PayDate"]).ToString("dd-MM-yyyy");
                        lblInvoiceNo.Text = dtFid.Rows[0]["InvoiceCode"].ToString();


                        lblTotalFooter.Text = Convert.ToDecimal(dtFid.Rows[0]["TotalCostAmount"]).ToString("N", CultureInfo.GetCultureInfo("en-IN"));
                        lblTaxAmount.Text = Convert.ToDecimal(dtFid.Rows[0]["TotalTax"]).ToString("N", CultureInfo.GetCultureInfo("en-IN"));
                        lblNetAmount.Text = Convert.ToDecimal(dtFid.Rows[0]["GrandTotal"]).ToString("N", CultureInfo.GetCultureInfo("en-IN"));


                        lblpaidAmount.Text = Convert.ToDecimal(dtFid.Rows[0]["PaidAmount"]).ToString("N", CultureInfo.GetCultureInfo("en-IN"));
                        lblpendingAmount.Text = Convert.ToDecimal(dtFid.Rows[0]["Pending_Amount"]).ToString("N", CultureInfo.GetCultureInfo("en-IN"));


                        lblTotalCoust1.Text = Convert.ToDecimal(dtFid.Rows[0]["TotalCost"]).ToString("N", CultureInfo.GetCultureInfo("en-IN"));
                        lbldiscount1.Text = Convert.ToDecimal(dtFid.Rows[0]["TotalDiscount"]).ToString("N", CultureInfo.GetCultureInfo("en-IN"));


                        lblWordsAmount.Text = "Rupees " + NumberToWords_Large(Convert.ToInt32(dtFid.Rows[0]["PaidAmount"])) + " only";


                        lblClinic.Text = dtFid.Rows[0]["ClinicName"].ToString();
                        lblMobailNo.Text = dtFid.Rows[0]["PhoneNo2"].ToString();
                        lblAddress1.Text = dtFid.Rows[0]["AddressLine1"].ToString();
                        lblEmail1.Text = dtFid.Rows[0]["EmailID"].ToString();
                        patientID.Text = dtFid.Rows[0]["PatientCode"].ToString();
                        BindInvoiceAmount(Cno);



                    }


                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void BindInvoiceAmount(int Cno)
        {
            //DataTable dt =

            AllData = objinv.GetAllMedicinPrint(Cno);
            grdInvoice.DataSource = AllData;
            grdInvoice.DataBind();

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