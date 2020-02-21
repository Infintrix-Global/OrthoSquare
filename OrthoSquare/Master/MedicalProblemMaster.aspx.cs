﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;

namespace OrthoSquare.Master
{
    public partial class MedicalProblemMaster : System.Web.UI.Page
    {
        BAL_MedicalProblem objES = new BAL_MedicalProblem();
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                getAllEnquirySource();
            }
        }


        public void getAllEnquirySource()
        {

            AllData = objES.GetAllMPDetails();
            gvShow.DataSource = AllData;
            gvShow.DataBind();
        }


        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;


                _isInserted = objES.AddMProblems(txtAdd.Text);

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Medical Prolbem";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblMessage.Text = "Medical Prolbem  Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtAdd.Text = "";
                    getAllEnquirySource();
                    Response.Redirect("MedicalProblemMaster.aspx");
                    btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                if (txtSearch.Text != "")
                {
                    search += "Sourcename like '%" + txtSearch.Text + "%'";
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
                }
                else
                {
                    gvShow.DataSource = AllData;
                    gvShow.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            btSearch_Click(sender, e);
        }

        protected void gvShow_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShow.EditIndex = -1;
            btSearch_Click(sender, e);
        }

        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objES.DeleteMP(ID);
                if (_isDeleted != -1)
                {
                    DataTable UserLog = (DataTable)Session["User"];

                    lblMessage.Text = "Medical Prolbem Deleted Enqiry Source.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("MedicalProblemMaster.aspx");
                    btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShow.EditIndex = e.NewEditIndex;
            btSearch_Click(sender, e);
            GridView gvGrid = sender as GridView;
            GridViewRow dr = gvGrid.Rows[e.NewEditIndex];
            TextBox txtEditSearch = (TextBox)dr.FindControl("txtName");

            txtEditSearch.Focus();
        }

        protected void gvShow_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int isUpdated = -1;
            GridViewRow row = (GridViewRow)gvShow.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
            TextBox txtName = (TextBox)row.FindControl("txtName");


            isUpdated = objES.UpdateMP(txtName.Text, Convert.ToInt32(lblID.Text));
            if (isUpdated == 1)
            {
                // DataTable UserLog = (DataTable)Session["User"];

                lblMessage.Text = "Medical Prolbem Updated Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                //gvShow.EditIndex = -1;
                //  getAllCategoryGrid();
                Response.Redirect("MedicalProblemMaster.aspx");

                btSearch_Click(sender, e);
            }
            else
            {
                lblMessage.Text = "Failed to Update Medical Prolbem";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
        }
    }
}