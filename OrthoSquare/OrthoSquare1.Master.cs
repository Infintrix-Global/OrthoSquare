using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrthoSquare
{
    public partial class OrthoSquare : System.Web.UI.MasterPage
    
    {
       // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString);

       
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["User"] != null)
            //{
            //    if (!IsPostBack)
            //    {

            //    }
            //    BindMenu();
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}

          //  BindMenu();

        }

        //private void BindMenu()
        //{
        //    DataTable User = (DataTable)Session["User"];

        //    string query = "select LG.UserID,LG.RoleID,RL.RoleName,MR.MenuID,MR.Page_Add,MR.Page_Delete,MR.Page_Edit,MR.Page_View ";
        //    query += " ,MN.MenuName,MN.MenuIcon,MN.OrderNo,MN.ParentId,MN.Path from [Login] LG  ";
        //    query += " Left outer join Role RL on RL.RoleID = LG.RoleID Left outer join MenuRight MR on MR.RoleID = LG.RoleID ";
        //    query += " Left outer join Menu MN on MN.MenuID = MR.MenuID where UserID='" + User.Rows[0]["UserID"].ToString() + "' and MN.IsActive= 1 and ISNULL(MenuName,'')<>'' order by ParentID, OrderNo asc";

        //    if (con.State == ConnectionState.Closed)
        //        con.Open();

        //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "Menu");
        //    DataTable AllMenu = ds.Tables[0];

        //    var MenuParent = (from DataRow dr in AllMenu.Rows
        //                      where dr["ParentID"].ToString() == "0"
        //                      select dr
        //                   );
        //    DataTable dtMenu = MenuParent != null ? MenuParent.CopyToDataTable() : null;


        //    foreach (DataRow row in dtMenu.Rows)
        //    {
        //        DataRow[] dtSubMenu = AllMenu.Select("ParentID=" + row["MenuID"].ToString());

        //        if (dtSubMenu.Count() != 0)
        //        {
        //            var literalMenu = new LiteralControl("<li class='nav-item  '><a href='#'><i class='" + row["MenuIcon"].ToString() + "'></i>" + row["MenuName"].ToString() + "<i class='nav-link nav-toggle'></i></a>");
        //            PlhldrMenu.Controls.Add(literalMenu);
        //        }
        //        else
        //        {
        //            var literalMenu = new LiteralControl("<li class='nav-item  '><a href='" + row["Path"].ToString() + "'><i class='" + row["MenuIcon"].ToString() + "'></i>" + row["MenuName"].ToString() + "</a>");
        //            PlhldrMenu.Controls.Add(literalMenu);
        //        }

        //        var literalSubMenuolds = new LiteralControl("<ul class='sub-menu'>");
        //        PlhldrMenu.Controls.Add(literalSubMenuolds);
        //        foreach (DataRow rowSubMenu in dtSubMenu)
        //        {
        //            var literalSubMenu = new LiteralControl("<li><a href=" + rowSubMenu["Path"].ToString() + "> " + rowSubMenu["MenuName"].ToString() + " </a></li>");
        //            PlhldrMenu.Controls.Add(literalSubMenu);
        //        }
        //        var literalSubMenuoldclose = new LiteralControl("</ul>");
        //        PlhldrMenu.Controls.Add(literalSubMenuoldclose);
        //        var literalMenu1 = new LiteralControl("</li>");
        //        PlhldrMenu.Controls.Add(literalMenu1);

        //    }
        //}
    }
}