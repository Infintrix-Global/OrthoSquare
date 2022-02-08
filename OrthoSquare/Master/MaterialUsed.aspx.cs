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
    public partial class MaterialUsed : System.Web.UI.Page
    {
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        BAL_Vendor objVendor = new BAL_Vendor();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Clinic objc = new BAL_Clinic();
        BAL_Patient objp = new BAL_Patient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMaterial();
                BindPatient();
                getAllTreatment(0);

                //  getAllGridplaceorder(0);

                bindClinic();


                ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));


                if (SessionUtilities.RoleID == 1)
                {
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindDocter(Convert.ToInt32(SessionUtilities.Empid));
                }
            }
        }


        public void getAllTreatment(int Mid)
        {

            DataTable AllData = objM.GetAllMaterial(Mid);

            if (AllData != null && AllData.Rows.Count > 0)
            {
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
        }
        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label lblInstock = (Label)e.Row.FindControl("lblInstock");

                if (lblInstock.Text == "")
                {
                    lblInstock.Text = "0";

                }

                //Label lblInstock = (Label)e.Row.FindControl("lblInstock");

                //int MaterialTotal = objM.GetAllMaterialOder1(Convert.ToInt32(lblMID.Text));
                //lblInstock.Text = MaterialTotal.ToString();
            }

        }
        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            // btSearch_Click(sender, e);
            getAllTreatment(0);
        }
        public void BindMaterial()
        {


            ddlMaterialSearch.DataSource = objM.GetAllMaterial(0);
            ddlMaterialSearch.DataTextField = "MaterialName";
            ddlMaterialSearch.DataValueField = "MaterialId";
            ddlMaterialSearch.DataBind();
            ddlMaterialSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }
        public void BindPatient()
        {
            ddlpatient.DataSource = objp.GetPatientlist();
            ddlpatient.DataTextField = "Fname";
            ddlpatient.DataValueField = "patientid";
            ddlpatient.DataBind();

            ddlpatient.Items.Insert(0, new ListItem("--- Select ---", "0"));
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

        protected void ddlClinic_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindDocter(Convert.ToInt32(ddlClinic.SelectedValue));
        }


        public void BindDocter(int Cid)
        {
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDoctor.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);

            }
            else
            {
                ddlDoctor.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);

            }


            ddlDoctor.DataTextField = "DoctorName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();
            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            getAllTreatment(Convert.ToInt32(ddlMaterialSearch.SelectedValue));


        }
        protected void btAdd_Click(object sender, EventArgs e)
        {

            try
            {
                int _isInserted = -1;
                int SelectedItems = 0;
                foreach (GridViewRow item in gvShow.Rows)
                {

                    if (item.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkSelect = (CheckBox)item.FindControl("chkSelectMaterialId");
                        if (chkSelect != null && chkSelect.Checked == true)
                        {

                            Label lblMaterialId = (item.Cells[0].FindControl("lblMaterialId") as Label);
                            Label lblInstock = (item.Cells[0].FindControl("lblInstock") as Label);
                            TextBox txtUsedQty = (item.Cells[0].FindControl("txtUsedQty") as TextBox);

                            if (Convert.ToInt32(lblInstock.Text) > Convert.ToInt32(txtUsedQty.Text))
                            {
                                _isInserted = objM.AddUsedMaterial(Convert.ToInt32(lblMaterialId.Text), Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), Convert.ToInt32(ddlpatient.SelectedValue), System.DateTime.Now.ToString("dd-MM-yyyy"), Convert.ToInt32(txtUsedQty.Text));

                                int StTotal = Convert.ToInt32(lblInstock.Text) - Convert.ToInt32(txtUsedQty.Text);

                                int a = objM.AddmaterialstocReceive(0, Convert.ToInt32(lblMaterialId.Text), StTotal);
                            }


                            SelectedItems++;

                        }
                    }
                }





                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add In out Material Order";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblMessage.Text = "In out Material Order Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                   // Response.Redirect("AddMaterialOrder.aspx");

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}