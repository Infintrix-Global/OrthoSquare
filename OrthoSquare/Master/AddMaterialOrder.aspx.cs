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
    public partial class AddMaterialOrder : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        BAL_Vendor objVendor = new BAL_Vendor();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Clinic objc = new BAL_Clinic(); 
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                BindMaterial();
                getAllTreatment(0);
                
                getAllGridplaceorder(0);

                bindClinic();


                ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));
              

                if (SessionUtilities.RoleID == 1)
                {
                   
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindDocter(Convert.ToInt32(SessionUtilities.Empid));
                }
               
            }
        }

        public void bindClinic()
        {
            DataTable dt;
            
                if(SessionUtilities .RoleID ==3)
                {
                    dt = objcommon.GetDoctorByClinic(SessionUtilities .Empid);
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

        public void BindMaterial()
        {


            
            ddlMaterialSearch.DataSource = objM.GetAllMaterial(0);
            
            ddlMaterialSearch.DataTextField = "MaterialName";
            ddlMaterialSearch.DataValueField = "MaterialId";
            ddlMaterialSearch.DataBind();
            ddlMaterialSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));

        
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




            ddlDoctor.DataTextField = "FirstName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();
            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void getAllTreatment(int Mid)
        {

            AllData = objM.GetAllMaterial(Mid);

            if (AllData != null && AllData.Rows.Count > 0 )
            {
                gvShow.DataSource = AllData;
                gvShow.DataBind();
            }
        }

        public void getAllGridplaceorder(int Mid)
        {

           DataTable  AllData1 = objM.GetAllMaterial(Mid);
           if (AllData1 != null && AllData1.Rows.Count > 0 )
           {
               Gridplaceorder.DataSource = AllData1;
               Gridplaceorder.DataBind();
           }
        }

        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            // btSearch_Click(sender, e);
            getAllTreatment(0);
        }

        protected void Gridplaceorder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridplaceorder.PageIndex = e.NewPageIndex;
            // btSearch_Click(sender, e);
            getAllGridplaceorder(0);

        }

        protected void Gridplaceorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

             
                DropDownList ddlVendor = (DropDownList)e.Row.FindControl("ddlVendor");

                ddlVendor.DataSource = objVendor.GetAllVendorNew();
                ddlVendor.DataTextField = "VendorName";
                ddlVendor.DataValueField = "VendorID";
                ddlVendor.DataBind();
                ddlVendor.Items.Insert(0, new ListItem("--- Select ---", "0"));


            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
         
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;

            getAllTreatment(0);
        }
        protected void btAdd_Click(object sender, EventArgs e)
        {


            try
            {
                int _isInserted = -1;
                int SelectedItems = 0;
                foreach (GridViewRow item in Gridplaceorder.Rows)
                {
                   
                    if (item.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkSelect = (CheckBox)item.FindControl("chkSelectMaterialId");
                        if (chkSelect != null && chkSelect.Checked == true)
                        {
                           
                            Label LabelMaterialId = (item.Cells[0].FindControl("LabelMaterialId") as Label);
                            DropDownList ddlVendor = (item.Cells[0].FindControl("ddlVendor") as DropDownList);

                            TextBox txtOrderQty = (item.Cells[0].FindControl("txtOrderQty") as TextBox);
                            TextBox txtCost = (item.Cells[0].FindControl("txtCost") as TextBox);
                            TextBox txtOrderDate = (item.Cells[0].FindControl("txtOrderDate") as TextBox);


                            _isInserted = objM.AddInOutMaterial(Convert.ToInt32(LabelMaterialId.Text), Convert.ToInt32(ddlVendor.SelectedValue), txtOrderDate.Text, Convert.ToInt32(txtOrderQty.Text), Convert.ToInt32(txtCost.Text), Convert.ToInt32(ddlClinic.Text), Convert.ToInt32(ddlDoctor.Text));

                            
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
                  //  Response.Redirect("AddMaterialOrder.aspx");
                 
                }
            }
            catch (Exception ex)
            {
            }


        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label lblInstock = (Label)e.Row.FindControl("lblInstock");
               
                if(lblInstock.Text=="")
                {
                    lblInstock.Text = "0";

                }
                
              
            }

        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            getAllTreatment(Convert .ToInt32 (ddlMaterialSearch .SelectedValue ));

            getAllGridplaceorder(Convert.ToInt32(ddlMaterialSearch.SelectedValue));
        }

        protected void Invoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal Total;
           // decimal TextTotal;
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            Label lblPrice1 = (Label)gvr.FindControl("lblPrice1");
            TextBox txtOrderQty = (TextBox)gvr.FindControl("txtOrderQty");
            TextBox txtCost = (TextBox)gvr.FindControl("txtCost");

            Total = Convert.ToInt16(lblPrice1.Text) * Convert.ToInt16(txtOrderQty.Text);
             txtCost.Text = Total.ToString ();

        }
    }
}