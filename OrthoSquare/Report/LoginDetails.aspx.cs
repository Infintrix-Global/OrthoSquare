using OrthoSquare.BAL_Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrthoSquare.Report
{
    public partial class LoginDetails : System.Web.UI.Page
    {
        GeneralNew objG = new GeneralNew();
        public static DataTable AllData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                getLogin();
            }
        }



        public void getLogin()
        {

            NameValueCollection nv = new NameValueCollection();
            nv.Add("@Name", txtSearch.Text);
            nv.Add("@MobileNo", txtMNo.Text);
            if (RadioButtonRole.SelectedValue == "1")
            {
                nv.Add("@Mode", "1");
            }
            else
            {
                nv.Add("@Mode", "2");
            }
            DataTable dt = objG.GetDataTable("GET_LoginDetails", nv);


            gvShow.DataSource = dt;
            gvShow.DataBind();
        }



        protected void btSearch_Click(object sender, EventArgs e)
        {
            getLogin();
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

            lblMSG1.Text = "";
        }


        protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShow.EditIndex = e.NewEditIndex;
            btSearch_Click(sender, e);
            GridView gvGrid = sender as GridView;
            GridViewRow dr = gvGrid.Rows[e.NewEditIndex];
            TextBox txtEditSearch = (TextBox)dr.FindControl("txtName");
            TextBox txtEditSearch1 = (TextBox)dr.FindControl("txtPassword");
            txtEditSearch.Focus();
            txtEditSearch1.Focus();

        }





        protected void gvShow_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int isUpdated = -1;
            GridViewRow row = (GridViewRow)gvShow.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
            Label lblRole = (Label)row.FindControl("lblRole");
            TextBox txtName = (TextBox)row.FindControl("txtName");
            TextBox txtPassword = (TextBox)row.FindControl("txtPassword");

            NameValueCollection nv = new NameValueCollection();

            nv.Add("@ID", lblID.Text);
            nv.Add("@UserName", txtName.Text);
            nv.Add("@Password", txtPassword.Text);
            nv.Add("@Role", lblRole.Text);

            isUpdated = objG.GetDataExecuteScaler("SP_UpdatePasswor", nv);
            Response.Redirect("LoginDetails.aspx");

            btSearch_Click(sender, e);

        }

        protected void RadioButtonRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            getLogin();
        }
    }



}
