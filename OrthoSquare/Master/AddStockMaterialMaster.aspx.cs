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
    public partial class AddStockMaterialMaster : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        BAL_Vendor objVendor = new BAL_Vendor();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Clinic objc = new BAL_Clinic();
        Bal_UnitMaster objUnit = new Bal_UnitMaster();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
               // BindMaterial();
               // getAllTreatment(0);

               getAllGridplaceorder(0);

                bindClinic();


               // ddlDoctor.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));


                if (SessionUtilities.RoleID == 1)
                {

                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
              //BindDocter(Convert.ToInt32(SessionUtilities.Empid));
                }

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

        public void bindUnit(ref DropDownList ddlunit)
        {
            DataTable dt;
            dt = objUnit.GetAllUnit("", "Material");


            ddlunit.DataSource = dt;
            ddlunit.DataValueField = "UnitId";
            ddlunit.DataTextField = "UnitName";
            ddlunit.DataBind();
            ddlunit.Items.Insert(0, new ListItem("-- Select Unit --", "0", true));

        }

        public void getAllGridplaceorder(int Mid)
        {

            DataTable AllData1 = objM.GetAllMaterial(Mid);
            if (AllData1 != null && AllData1.Rows.Count > 0)
            {
                Gridplaceorder.DataSource = AllData1;
                Gridplaceorder.DataBind();
            }
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
                            DropDownList ddlUnit = (item.Cells[0].FindControl("ddlUnit") as DropDownList);

                            TextBox txtOrderQty = (item.Cells[0].FindControl("txtOrderQty") as TextBox);
                            //TextBox txtCost = (item.Cells[0].FindControl("txtCost") as TextBox);
                           


                            _isInserted = objM.AddInOutMaterialStock(Convert.ToInt32(LabelMaterialId.Text),"", Convert.ToInt32(txtOrderQty.Text), Convert.ToInt32(ddlClinic.Text),0,ddlUnit .SelectedItem .Text );


                            SelectedItems++;

                        }
                    }
                }





                if (_isInserted == -1)
                {
                    lblMessage.Text = "Failed to Add  Material";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblMessage.Text = "Material Order Added Successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                //    Response.Redirect("AddMaterialOrder.aspx");

                }
            }
            catch (Exception ex)
            {
            }


        }

        protected void Gridplaceorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList ddlunit = (DropDownList)e.Row.FindControl("ddlUnit");
                bindUnit(ref ddlunit);
            }

        }
    }
}