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
    public partial class VendorMaster : System.Web.UI.Page
    {

        public static DataTable AllData = new DataTable();
        BAL_Vendor objVendor = new BAL_Vendor();
        BAL_Clinic objc = new BAL_Clinic();
        BAL_VendorType objVt = new BAL_VendorType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Searched"] = null;
                getAllTreatment();

              
                bindVendorType();
                bindClinic();
                if (SessionUtilities.RoleID == 1)
                {

                    ddl_Clinic.SelectedValue = SessionUtilities.Empid.ToString();
                    ddl_Clinic.Enabled = false;


                }
            }
          
        }


        private long VendorID
        {
            get
            {
                if (ViewState["VendorID"] != null)
                {
                    return (long)ViewState["VendorID"];
                }
                return 0;
            }
            set
            {
                ViewState["VendorID"] = value;
            }
        }

        public void bindVendorType()
        {
            ddlVendorType.DataSource = objVt.GetAllVendorType();
            ddlVendorType.DataValueField = "VendorTypeId";
            ddlVendorType.DataTextField = "VendorType";
            ddlVendorType.DataBind();
            ddlVendorType.Items.Insert(0, new ListItem("-- Select vendor Type --", "0", true));

        }

        public void bindClinic()
        {
            ddl_Clinic.DataSource = objc.GetAllClinicDetais();
            ddl_Clinic.DataValueField = "ClinicID";
            ddl_Clinic.DataTextField = "ClinicName";
            ddl_Clinic.DataBind();
            ddl_Clinic.Items.Insert(0, new ListItem("-- Select Clinic --", "0", true));

        }

        public void getAllTreatment()
        {
            int Cid = 0;
            if(SessionUtilities .RoleID ==1)
            {
                Cid = SessionUtilities.Empid;
            }


            AllData = objVendor.GetAllVendor(Cid, 0);
            gvShow.DataSource = AllData;
            gvShow.DataBind();
        }


        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;


                _isInserted = objVendor.AddVendor(VendorID,txtAdd.Text,txtMobile .Text ,Convert .ToInt32 (ddlVendorType .SelectedValue) ,Convert .ToInt32 (ddl_Clinic .SelectedValue ));

                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add Vendor";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblMessage.Text = "Vendor Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtAdd.Text = "";
                    txtMobile.Text = "";
                    bindClinic();
                    bindVendorType();
                    getAllTreatment();
                 //   Response.Redirect("TreatmentMaster.aspx");
                    btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
            }
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
        }

        protected void gvShow_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShow.EditIndex = -1;
            btSearch_Click(sender, e);
        }

        protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            try
            {
                int ID = Convert.ToInt32(gvShow.DataKeys[e.RowIndex].Value);

                int _isDeleted = objVendor.DeleteVendor(ID);
                if (_isDeleted != -1)
                {
                    DataTable UserLog = (DataTable)Session["User"];

                    lblMessage.Text = "Vendor Deleted.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Response.Redirect("VendorMaster.aspx");
                    btSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //gvShow.EditIndex = e.NewEditIndex;
            //btSearch_Click(sender, e);
            //GridView gvGrid = sender as GridView;
            //GridViewRow dr = gvGrid.Rows[e.NewEditIndex];
            //TextBox txtEditSearch = (TextBox)dr.FindControl("txtName");
            //TextBox txtMobileNo = (TextBox)dr.FindControl("txtMobileNo");
            //txtEditSearch.Focus();
            //txtMobileNo.Focus();

        }

        protected void gvShow_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int isUpdated = -1;
            //GridViewRow row = (GridViewRow)gvShow.Rows[e.RowIndex];
            //Label lblID = (Label)row.FindControl("lblID");
            //TextBox txtName = (TextBox)row.FindControl("txtName");
            //TextBox txtMobileNo = (TextBox)row.FindControl("txtMobileNo");


            //isUpdated = objVendor.UpdateVendor(txtName.Text, txtMobileNo.Text , Convert.ToInt32(lblID.Text));
            //if (isUpdated == 1)
            //{
            //    // DataTable UserLog = (DataTable)Session["User"];

            //    lblMessage.Text = "Vendor Updated Successfully";
            //    lblMessage.ForeColor = System.Drawing.Color.Green;
            //    //gvShow.EditIndex = -1;
            //    //  getAllCategoryGrid();
            //    Response.Redirect("VendorMaster.aspx");

            //    btSearch_Click(sender, e);
            //}
            //else
            //{
            //    lblMessage.Text = "Failed to Update Vendor";
            //    lblMessage.ForeColor = System.Drawing.Color.Red;
            //}
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Edit.Visible = true;
            Add.Visible = false;
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Edit.Visible = false;
            Add.Visible = true;
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update1")
            {
                int Vid = Convert.ToInt32(e.CommandArgument);
                VendorID = Vid;
                DataTable dt = objVendor.GetAllVendorSelect(Vid);

                txtAdd.Text = dt.Rows[0]["VendorName"].ToString();
                txtMobile.Text = dt.Rows[0]["MobileNo"].ToString();
                bindClinic();

                ddl_Clinic.SelectedValue = dt.Rows[0]["ClinicID"].ToString();
              //  bindVendorType();
               // ddlVendorType.SelectedValue = dt.Rows[0]["VendorTypeId"].ToString();

                Edit.Visible = false;
                Add.Visible = true;
            }
        }
    }
}