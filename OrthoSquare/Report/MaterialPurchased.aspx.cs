using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.IO;

namespace OrthoSquare.Report
{
    public partial class MaterialPurchased : System.Web.UI.Page
    {
        BAL_Clinic objc = new BAL_Clinic();
        public static DataTable AllData = new DataTable();
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        clsCommonMasters objcommon = new clsCommonMasters();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindClinic();
                bindDoctorMaster(0);
                getAllMaterialpurchased();
            }
        }


        public void bindClinic()
        {

            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcommon.GetDoctorByClinic(SessionUtilities.Empid);
            }
            else if (SessionUtilities.RoleID == 1)
            {
                dt = objc.GetAllClinicDetaisNew(SessionUtilities.Empid);
            }
            else
            {
                dt = objc.GetAllClinicDetais();

            }
            ddlClinic.DataSource = dt;


            ddlClinic.DataValueField = "ClinicID";
            ddlClinic.DataTextField = "ClinicName";
            ddlClinic.DataBind();
            ddlClinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        public void bindDoctorMaster(int Cid)
        {


            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDocter.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);


            }
            else
            {
                ddlDocter.DataSource = objcommon.DoctersMaster(Cid, 3);

            }


            ddlDocter.DataValueField = "DoctorID";
            ddlDocter.DataTextField = "FirstName";
            ddlDocter.DataBind();
            ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDoctorMaster(Convert.ToInt32(ddlClinic.SelectedValue));
        }



        public void getAllMaterialpurchased()
        {

            AllData = objM.GetMaterialpurchased(Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDocter.SelectedValue), txtToDate.Text.Trim(), txtFromDate.Text.Trim());

            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllMaterialpurchased();

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            

                  Response.Redirect("MaterialPurchased.aspx");

            //txtFromDate.Text = "";
            //txtToDate.Text = "";

            //bindClinic();
            ////  ddlDocter.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));
            //bindDoctorMaster(0);
            //getAllMaterialpurchased();

        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            //   btSearch_Click(sender, e);
            getAllMaterialpurchased();
        }
    }
}