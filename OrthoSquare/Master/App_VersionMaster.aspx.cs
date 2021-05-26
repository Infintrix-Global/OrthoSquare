using System;
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
    public partial class App_VersionMaster : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        clsCommonMasters objcom = new clsCommonMasters();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                GetApp_Version();
            }
        }

        public void GetApp_Version()
        {

            AllData = objcom.GetApp_Version();
            gvShow.DataSource = AllData;
            gvShow.DataBind();
        }

        protected void gvShow_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShow.EditIndex = -1;
            gvShow.DataSource = AllData;
            gvShow.DataBind();
        }
        protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShow.EditIndex = e.NewEditIndex;
            gvShow.DataSource = AllData;
            gvShow.DataBind();
            GridView gvGrid = sender as GridView;
            GridViewRow dr = gvGrid.Rows[e.NewEditIndex];
            TextBox txtApp_Version1 = (TextBox)dr.FindControl("txtApp_Version");
            TextBox txtApp_VCode = (TextBox)dr.FindControl("txtApp_VCode");
            DropDownList ddlForceUpdate = (DropDownList)dr.FindControl("ddlForceUpdate");
            txtApp_Version1.Focus();
        }

        protected void gvShow_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int isUpdated = -1;
            bool Fupdate;
            GridViewRow row = (GridViewRow)gvShow.Rows[e.RowIndex];

            TextBox txtApp_Version = (TextBox)row.FindControl("txtApp_Version");
            TextBox txtApp_VCode = (TextBox)row.FindControl("txtApp_VCode");
            DropDownList ddlForceUpdate = (DropDownList)row.FindControl("ddlForceUpdate");

            if (ddlForceUpdate.SelectedValue=="0")
            {
                Fupdate = false;
            }
            else
            {

                Fupdate = true;
            }



            isUpdated = objcom.App_VersionUpdate(txtApp_Version.Text, txtApp_VCode.Text,Fupdate);

            Response.Redirect("App_VersionMaster.aspx");

           
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                


            }
        }

    }
}