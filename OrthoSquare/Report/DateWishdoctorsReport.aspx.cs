using System;
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
    public partial class DateWishdoctorsReport : System.Web.UI.Page
    {
        BAL_DoctorsDetails objdoc = new BAL_DoctorsDetails();
        clsCommonMasters objcomm = new clsCommonMasters();
         decimal sumFooterValue = 0;
         int cid = 0;
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

           if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDoctor.DataSource = objcomm.DoctersMasterNew(SessionUtilities.Empid, SessionUtilities.RoleID);
               

            }
            else
            {
                ddlDoctor.DataSource = objcomm.DoctersMasterNew(0, SessionUtilities.RoleID);
               
            }


          
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
            if (SessionUtilities.RoleID == 1)
            {
                cid = SessionUtilities.Empid;
            }

            DataTable dt = objdoc.GetDoctersDate_Collection(Convert.ToInt32(ddlDoctor.SelectedValue), txtSFromFollowDate.Text, txtSToFollowDate.Text,cid);
            if (dt.Rows.Count > 0 && dt != null)
            {
                GridDocterCollection.DataSource = dt;

                GridDocterCollection.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sumFooterValue += Convert.ToDecimal(dt.Rows[i]["PaidAmount"]);
                }

                lblTotalTop.Text = sumFooterValue.ToString();
            }
        }
         protected void btnSearch_Click(object sender, EventArgs e)
         {
             BindDocterCollection();
         }

         protected void GridDocterCollection_RowDataBound(object sender, GridViewRowEventArgs e)
         {

             

             if (e.Row.RowType == DataControlRowType.DataRow)
                  {

                      Label PaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
                      sumFooterValue += Convert.ToDecimal(PaidAmount.Text);
                  }

           
             //if (e.Row.RowType == DataControlRowType.Footer)
             //     {
             //         Label lblTotal = (Label)e.Row.FindControl("lblTotal");
             //         lblTotal.Text = sumFooterValue.ToString();

             //        
             //     }
         }

    }
}