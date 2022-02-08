using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrthoSquare.BAL_Classes;
using OrthoSquare.Utility;
using System.IO;


namespace OrthoSquare.Report
{
    public partial class LebInoutReport : System.Web.UI.Page
    {

        BAL_Patient objp = new BAL_Patient();
        BAL_LabsDetails objLab = new BAL_LabsDetails();
        clsCommonMasters objcomm = new clsCommonMasters();
        int cid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack )
            {
              
                BindInoutRepot();
            }
        }


     

        public void BindInoutRepot()
        {
            if (SessionUtilities.RoleID == 1)
            {
                cid = SessionUtilities.Empid;
            }

            DataTable dt = objLab.GetLabsInoutReportnew(txtNameS.Text,txtLastNameS.Text,txtLabName.Text, cid);
            GridinoutLab.DataSource = dt;
            GridinoutLab.DataBind();
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridinoutLab.PageIndex = e.NewPageIndex;
            BindInoutRepot();
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblinEnqDate = (Label)e.Row.FindControl("lblinEnqDate");

                Label lbloutEnqDate = (Label)e.Row.FindControl("lbloutEnqDate");

                Label lblToothNo = (Label)e.Row.FindControl("lblToothNo");


                if (lblinEnqDate.Text == "01-01-1990")
                {
                    lblinEnqDate.Text = "";
                }


                if (lbloutEnqDate.Text == "01-01-1990")
                {
                    lbloutEnqDate.Text = "";
                }

                string toothName = "";
                DataTable dt1 = objcomm.GettoothDetails(lblToothNo.Text.Trim());

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        toothName += dt1.Rows[i]["toothNo"] + ",";

                    }
                    lblToothNo.Text = toothName;
                }
            }
        }



        protected void btSearch_Click(object sender, EventArgs e)
        {
            BindInoutRepot();
        }
    }
}