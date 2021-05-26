using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using System.Configuration;
using OrthoSquare.Utility;

namespace OrthoSquare.Help
{
    public partial class HelpMaster : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        clsCommonMasters com = new clsCommonMasters();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getAllAdvertis();
            }
        }

        public void getAllAdvertis()
        {
            AllData = com.GetAllHelp(txtSearch .Text .Trim ());
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }


        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            //btSearch_Click(sender, e);
            getAllAdvertis();
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int Vid = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditAd")
            {

                com.UserLoginhistoryNew(SessionUtilities.Empid, SessionUtilities.RoleID,Vid);


            }
               



        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            getAllAdvertis();

        }


        }
}