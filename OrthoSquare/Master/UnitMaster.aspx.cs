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
    public partial class UnitMaster : System.Web.UI.Page
    {
        Bal_UnitMaster objUnit = new Bal_UnitMaster();
        public static DataTable AllData = new DataTable();
        General objGeneral = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                getAllUnit();
            }
        }

        private long UnitId
        {
            get
            {
                if (ViewState["UnitId"] != null)
                {
                    return (long)ViewState["UnitId"];
                }
                return 0;
            }
            set
            {
                ViewState["UnitId"] = value;
            }
        }

        public DataTable getAllUnit()
        {
            try
            {
                string IsMedi = "";

                if (RadioBtnIsMedicalSearch.SelectedValue == "All")
                {
                    IsMedi = "";
                }
                else
                {
                    IsMedi = RadioBtnIsMedicalSearch.SelectedValue;
                }

                AllData = objUnit.GetAllUnit(txtSearch.Text.Trim(), IsMedi);
                gvShow.DataSource = AllData;
                gvShow.DataBind();

                return AllData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;


                _isInserted = objUnit.AddUnit(UnitId, txtAdd.Text, RadioBtnIsMedical.SelectedValue);

                if (_isInserted == -1)
                {
                    string CloseWindow;
                    CloseWindow = "alert('Failed to Add Unit')";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "CloseWindow", CloseWindow, true);

                }
                else
                {

                    string CloseWindow;
                    CloseWindow = "alert('Unit Added Successfully')";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "CloseWindow", CloseWindow, true);

                    txtAdd.Text = "";
                    RadioBtnIsMedical.ClearSelection();
                    getAllUnit();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            RadioBtnIsMedicalSearch.ClearSelection();
            RadioBtnIsMedicalSearch.Items.FindByText("All").Selected = true;
            getAllUnit();

        }

        protected void RadioBtnIsMedicalSearch_Select(object sender, EventArgs e)
        {

            getAllUnit();
        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getAllUnit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            getAllUnit();
        }



        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objUnit.DeleteUnit(ID);
                if (_isDeleted != -1)
                {
                    getAllUnit();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SortDirection direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }

        protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";

            }
            else
            {

                direction = SortDirection.Ascending;
                sortingDirection = "Asc";

            }
            DataView sortedView = new DataView(getAllUnit());
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            gvShow.DataSource = sortedView;
            gvShow.DataBind();
        }



        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit1")
            {
                try
                {

                    Edit.Visible = false;
                    Add.Visible = true;
                    int Id = Convert.ToInt32(e.CommandArgument);
                    UnitId = Id;
                    DataTable Dt = objUnit.GetSelectUnit(Id);
                    if (Dt != null && Dt.Rows.Count > 0)
                    {
                        txtAdd.Text = Dt.Rows[0]["UnitName"].ToString();
                        if (Dt.Rows[0]["IsMedical"].ToString() != "")
                        {
                            RadioBtnIsMedical.Items.FindByText(Dt.Rows[0]["IsMedical"].ToString()).Selected = true;
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;

            getAllUnit();

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAdd.Text = "";
            Edit.Visible = false;
            Add.Visible = true;
        }


    }
}