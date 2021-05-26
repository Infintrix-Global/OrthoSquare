using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;


namespace OrthoSquare.Enquiry
{
    public partial class ViewFolloupDetials : System.Web.UI.Page
    {
        BAL_EnquiryDetails objENQ = new BAL_EnquiryDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFolloupview();
            }
        }

        public void BindFolloupview()
        {


          
            GridViewFolloupDetils1.DataSource = objENQ.GetViewAllEnquiryFollowup(Convert.ToInt32(SessionUtilities.Empid), Convert.ToInt32(SessionUtilities.RoleID));
            GridViewFolloupDetils1.DataBind();



        }

        protected void GridViewFolloupDetils1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFolloupDetils1.PageIndex = e.NewPageIndex;
            BindFolloupview();
        }
    }
}