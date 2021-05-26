using OrthoSquare.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
namespace OrthoSquare
{
    public partial class OrthoSquare1 : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString);
        clsCommonMasters objcomm = new clsCommonMasters();
        public string imgPath;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (SessionUtilities.UserID != null)
            {
               
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }

          BindMenu();
          BindName();
        }

        private void BindName()
        {

            if (SessionUtilities.RoleID == 1)
            {

                DataTable dt1 = objcomm.GetAlltblClinicDetails(SessionUtilities.Empid);

                lblCname.Text = dt1.Rows[0]["ClinicName"].ToString();
                // lblName1.Text = dt1.Rows[0]["FirstName"].ToString();
                //Dhaval
                imgPath = "../assets/layouts/layout2/img/avatar3_small.jpg";
            }

            if (SessionUtilities.RoleID == 3)
            {

                DataTable dt1 = objcomm.GetAllDoctorDetails(SessionUtilities.Empid);

                lblCname.Text = dt1.Rows[0]["ClinicName"].ToString();
                lblName1.Text = dt1.Rows[0]["FirstName"].ToString();
                //Dhaval
                imgPath = "../EmployeeProfile/" + dt1.Rows[0]["ProfileImageUrl"].ToString();
            }


        }

        private void BindMenu()
        {
            DataTable User = (DataTable)Session["User"];

            string query = "select LG.UserID,LG.RoleID,RL.RoleName,MR.MenuID,MR.Page_Add,MR.Page_Delete,MR.Page_Edit,MR.Page_View ";
            query += " ,MN.MenuName,MN.MenuIcon,MN.OrderNo,MN.ParentId,MN.Path from [Login] LG  ";
            query += " Left outer join Role RL on RL.RoleID = LG.RoleID Left outer join MenuRight MR on MR.RoleID = LG.RoleID ";
            query += " Left outer join Menu MN on MN.MenuID = MR.MenuID where UserID='" + User.Rows[0]["UserID"].ToString() + "' and MN.IsActive= 1 and ISNULL(MenuName,'')<>'' order by ParentID,MR.MenuID, OrderNo asc";


           


            if (con.State == ConnectionState.Closed)
                con.Open();



            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Menu");
            DataTable AllMenu = ds.Tables[0];

            var MenuParent = (from DataRow dr in AllMenu.Rows
                              where dr["ParentID"].ToString() == "0"
                              select dr
                           );
            DataTable dtMenu = MenuParent != null ? MenuParent.CopyToDataTable() : null;


            foreach (DataRow row in dtMenu.Rows)
            {
                DataRow[] dtSubMenu = AllMenu.Select("ParentID=" + row["MenuID"].ToString());

                if (dtSubMenu.Count() != 0)
                {
                    var literalMenu = new LiteralControl("<li class='nav-item  '><a  href='javascript:;' class='nav-link nav-toggle'><i class='" + row["MenuIcon"].ToString() + "'></i>" + "<span class='title'>" + row["MenuName"].ToString() + "</span>" + "  <span class='selected'></span>"  + "<i class='nav-link nav-toggle'></i></a>");
                    PlhldrMenu.Controls.Add(literalMenu);
                }
                else
                {
                    var literalMenu = new LiteralControl("<li class='nav-item  '><a href='" + ResolveClientUrl("~/" + row["Path"].ToString()) + "'><i class='" + row["MenuIcon"].ToString() + "'></i>" + "<span class='title'>" + row["MenuName"].ToString() + "</span>" + "</a>");
                    PlhldrMenu.Controls.Add(literalMenu);
                }
               
                //if (dtSubMenu.Count() >= 2)
              
                //{
                //    var literalSubMenuolds = new LiteralControl("<ul class='sub-menu sub-menu1'>");
                //    PlhldrMenu.Controls.Add(literalSubMenuolds);
                //}
                //else
                //{
                //     var literalSubMenuolds = new LiteralControl("<ul class='sub-menu '>");
                //     PlhldrMenu.Controls.Add(literalSubMenuolds);

                //}

                var literalSubMenuolds = new LiteralControl("<ul class='sub-menu '>");
                PlhldrMenu.Controls.Add(literalSubMenuolds);
                foreach (DataRow rowSubMenu in dtSubMenu)
                {
                    var literalSubMenu = new LiteralControl("<li><a href=" + ResolveClientUrl("~/" + rowSubMenu["Path"].ToString()) + "> " + rowSubMenu["MenuName"].ToString() + " </a></li>");
                    PlhldrMenu.Controls.Add(literalSubMenu);
                }
                var literalSubMenuoldclose = new LiteralControl("</ul>");
                PlhldrMenu.Controls.Add(literalSubMenuoldclose);
                var literalMenu1 = new LiteralControl("</li>");
                PlhldrMenu.Controls.Add(literalMenu1);

            }
        }

        //Dhaval
        public void Logout(object sender, System.EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx", true);
        }

    }
}