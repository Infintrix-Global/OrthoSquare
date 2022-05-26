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
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

namespace OrthoSquare.Material
{
    public partial class ClinicRequestStock : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
       
        Bal_MaterilaType objMT = new Bal_MaterilaType();
       
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        clsCommonMasters objcommon = new clsCommonMasters();
        GeneralNew objG = new GeneralNew();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddMedicinesRow(true);
            }
        }



 
        private void AddMedicinesRow(bool AddBlankRow)
        {
            try
            {

                string MaterialType = "", MaterialName = "", hdnWOEmployeeIDVal = "";
                string SlotPositionStart = "", SlotPositionEnd = "";

                List<MaterialDetails> objMedi = new List<MaterialDetails>();

                foreach (GridViewRow item in GridMateialStock.Rows)
                {
                    string inHouseValues = "";
                    string Morning = "";
                    string Afternoon = "";
                    string Evening = "";
                    hdnWOEmployeeIDVal = ((HiddenField)item.FindControl("hdnWOEmployeeID")).Value;
                    MaterialType = ((DropDownList)item.FindControl("ddlMaterialType")).SelectedValue;
                    MaterialName = ((DropDownList)item.FindControl("ddlMaterialName")).SelectedValue;

                    TextBox txtQty = (TextBox)item.FindControl("txtQty");
                
                    TextBox txtRemark = (TextBox)item.FindControl("txtRemark");
                  
                    AddMedicines(ref objMedi, Convert.ToInt32(hdnWOEmployeeIDVal), MaterialType, MaterialName, txtQty.Text, txtRemark.Text);
                }
                if (AddBlankRow)
                    AddMedicines(ref objMedi, 1, "0", "0", "0", "");
                //GrowerPutData = objinvoice;
                GridMateialStock.DataSource = objMedi;
                GridMateialStock.DataBind();
                ViewState["Data"] = objMedi;
            }
            catch (Exception ex)
            {

            }
        }

        private void AddMedicines(ref List<MaterialDetails> objGP, int ID, string MaterialTypeId, string MaterialID, string Qty, string Remarks)
        {
            MaterialDetails objM = new MaterialDetails();
            objM.ID = ID;
            objM.RowNumber = objGP.Count + 1;
            objM.MaterialTypeId = MaterialTypeId;
            objM.MaterialID = MaterialID;
            objM.Qty = Qty;
            
            objM.Remarks = Remarks;
         
            objGP.Add(objM);
            ViewState["ojbpro"] = objGP;
        }

        public void GridSplitjob()
        {
            GridMateialStock.DataSource = ViewState["Data"];
            GridMateialStock.DataBind();
        }

        protected void GridMateialStock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlMaterialType = (DropDownList)e.Row.FindControl("ddlMaterialType");
                DropDownList ddlMaterialName = (DropDownList)e.Row.FindControl("ddlMaterialName");
                Label lblMaterialTypeid = (Label)e.Row.FindControl("lblMaterialTypeid");
               
                Label lblMaterialID = (Label)e.Row.FindControl("lblMaterialID");


                ddlMaterialType.DataSource = objMT.GetAllMaterialType("", "Material");
                ddlMaterialType.DataValueField = "MaterialTypeId";
                ddlMaterialType.DataTextField = "MaterialName";
                ddlMaterialType.DataBind();
                ddlMaterialType.Items.Insert(0, new ListItem("--- Select Material Type---", "0"));

                //ddlMedicinesType.Items.Insert(ddlMedicinesType.Items.Count, new ListItem("Other", "Other"));
                ddlMaterialType.SelectedValue = lblMaterialTypeid.Text;

                BindMedicines(ref ddlMaterialName, lblMaterialTypeid.Text);
                ddlMaterialName.SelectedValue = lblMaterialID.Text;


            }
        }


        public void BindMedicines(ref DropDownList ddlMaterialName, string MaterialType)
        {


            AllData = objM.GetGtMaterial(MaterialType,"");

            ddlMaterialName.DataSource = AllData;
            ddlMaterialName.DataTextField = "MaterialName";
            ddlMaterialName.DataValueField = "MaterialId";
            ddlMaterialName.DataBind();
            ddlMaterialName.Items.Insert(0, new ListItem("---Material Name---", "0"));

        }



        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddMedicinesRow(true);
        }

        protected void GridMateialStock_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<MaterialDetails> objinvoice = ViewState["ojbpro"] as List<MaterialDetails>;
            objinvoice.RemoveAt(e.RowIndex);
            GridMateialStock.DataSource = objinvoice;
            GridMateialStock.DataBind();


        }

        protected void ddlMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlMaterialType = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlMaterialType.NamingContainer;
            if (row != null)
            {
                DropDownList ddlMaterialName = (DropDownList)row.FindControl("ddlMaterialName");
           
                string MedicinesType = "0";


                AllData = objM.GetGtMaterial(ddlMaterialType.SelectedValue, "");

                ddlMaterialName.DataSource = AllData;
                ddlMaterialName.DataTextField = "MaterialName";
                ddlMaterialName.DataValueField = "MaterialId";
                ddlMaterialName.DataBind();
                ddlMaterialName.Items.Insert(0, new ListItem("---Material Name---", "0"));

            }


        }

    
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int SelectedItems = 0;
            int _isInserted = -1;

            int MNo = 0;
            MNo = objM.MaterialStock();

            foreach (GridViewRow row in GridMateialStock.Rows)
            {
              

                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox txtRemark = (row.Cells[0].FindControl("txtRemark") as TextBox);
                    TextBox txtQty = (row.Cells[0].FindControl("txtQty") as TextBox);


                    DropDownList ddlMaterialType = (row.Cells[0].FindControl("ddlMaterialType") as DropDownList);
                    DropDownList ddlMaterialName = (row.Cells[0].FindControl("ddlMaterialName") as DropDownList);

                    NameValueCollection nv = new NameValueCollection();

                    nv.Add("@RequestStockid","0");
                    nv.Add("@ClinicId", Session["Empid"].ToString());
                    nv.Add("@RequestCode", MNo.ToString());
                    
                    nv.Add("@MaterialId", ddlMaterialName.SelectedValue);
                    nv.Add("@MaterialTypeId", ddlMaterialType.SelectedValue);
                    nv.Add("@Qty", txtQty.Text);
                    nv.Add("@Remark", txtRemark.Text);

                    
                    nv.Add("@CreateBy", Session["Empid"].ToString());
                    nv.Add("@mode", "1");

                    _isInserted = objG.GetDataExecuteScaler("SP_AddMaterialRequestStock", nv);

                
                    SelectedItems++;


                }




            }


           
            objcommon.ShowMessage(this, "Material Added Successfully");
          

            GridMateialStock.DataSource = null;
            GridMateialStock.DataBind();

            AddMedicinesRow(true);

           

        }

      

        protected void btnClear_Click(object sender, EventArgs e)
        {
            GridMateialStock.DataSource = null;
            GridMateialStock.DataBind();


            AddMedicinesRow(true);
        }
    }
}