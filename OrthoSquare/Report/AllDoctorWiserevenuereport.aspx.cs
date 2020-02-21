﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrthoSquare.BAL_Classes;

using OrthoSquare.Utility;
namespace OrthoSquare.Report
{
    public partial class AllDoctorWiserevenuereport : System.Web.UI.Page
    {
        BAL_DoctorsDetails objdoc = new BAL_DoctorsDetails();
        decimal sumFooterValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                BindDocter();
                BindDocterCollection();
            }
        }


        public void BindDocter()
        {
            ddlDoctor.DataSource = objdoc.GetAllDocters(SessionUtilities .Empid );
            ddlDoctor.DataTextField = "FirstName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();

            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDocterCollection.PageIndex = e.NewPageIndex;
            BindDocterCollection();
        }
        public void BindDocterCollection()
        {

            DataTable dt = objdoc.GetAllDoctersRevenue(Convert.ToInt32(ddlDoctor.SelectedValue));
            GridDocterCollection.DataSource = dt;

            GridDocterCollection.DataBind();


        }

        protected void GridDocterCollection_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label PaidAmount = (Label)e.Row.FindControl("lblTotalSum");
                sumFooterValue += Convert.ToDecimal(PaidAmount.Text);
            }

            lblTotalTop.Text = sumFooterValue.ToString();
          
        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDocterCollection();
        }
    }
}