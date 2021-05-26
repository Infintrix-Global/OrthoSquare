using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;

namespace OrthoSquare.Report
{
    public partial class ContactMasterReport : System.Web.UI.Page
    {

        public static DataTable AllData = new DataTable();
        BAL_Vendor objVendor = new BAL_Vendor();
        int cid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                getAllTreatment();
            }
        }



        public void getAllTreatment()
        {
            if (SessionUtilities.RoleID == 1)
            {
                cid = SessionUtilities.Empid;
            }

            AllData = objVendor.GetAllVendor(cid,0);
            gvShow.DataSource = AllData;
            gvShow.DataBind();
        }


        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string search = "";
                if (txtSearch.Text != "")
                {
                    search += "VendorName like '%" + txtSearch.Text + "%'";
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
            getAllTreatment();
        }

    }
}