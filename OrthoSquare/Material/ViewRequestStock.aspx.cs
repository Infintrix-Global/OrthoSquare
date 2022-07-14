using OrthoSquare.BAL_Classes;
using OrthoSquare.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrthoSquare.Material
{
    public partial class ViewRequestStock : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_Clinic objc = new BAL_Clinic();
        Bal_MaterilaType objMT = new Bal_MaterilaType();
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        GeneralNew objG = new GeneralNew();
        decimal GTotal = 0;
        decimal GMTotal = 0;
        int SelectedItems = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindClinic();
                BindMaterialType();
                getAllCollection();
            }
        }

        private long MaterialID
        {
            get
            {
                if (ViewState["MaterialID"] != null)
                {
                    return (long)ViewState["MaterialID"];
                }
                return 0;
            }
            set
            {
                ViewState["MaterialID"] = value;
            }
        }


        private string  orderNo
        {
            get
            {
                if (ViewState["orderNo"] != null)
                {
                    return ViewState["orderNo"].ToString();
                }
                return "0";
            }
            set
            {
                ViewState["orderNo"] = value;
            }
        }





        public void BindMaterialType()
        {

            ddlMaterialType.DataSource = objMT.GetAllMaterialType("", "Material");
            ddlMaterialType.DataValueField = "MaterialTypeId";
            ddlMaterialType.DataTextField = "MaterialName";
            ddlMaterialType.DataBind();
            ddlMaterialType.Items.Insert(0, new ListItem("--- Select Inventory Type---", "0"));
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


        public void getAllCollection()
        {

            NameValueCollection nv = new NameValueCollection();
            nv.Add("@MaterialID", MaterialID.ToString());
            nv.Add("@MaterialTypeId", ddlMaterialType.SelectedValue);
            nv.Add("@ClinicID", ddlClinic.SelectedValue);
            nv.Add("@FromDate", txtFromDate.Text);
            nv.Add("@ToDate", txtToDate.Text);
            nv.Add("@OrderNo", "0");

            nv.Add("@Mode", "1");

            DataTable dt = objG.GetDataTable("GET_MaterialStockRequestView", nv);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalTop.Text = dt.Rows.Count.ToString();

                gvShow.DataSource = dt;
                gvShow.DataBind();
            }
            else
            {
                gvShow.DataSource = null;
                gvShow.DataBind();
                lblTotalTop.Text = "0";
            }
        }



        protected void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objM.GetMaterialSelect(txtMaterial.Text);
            MaterialID = Convert.ToInt32(dt.Rows[0]["MaterialId"]);
            getAllCollection();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllCollection();
        }
        protected void ddlMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllCollection();
        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllCollection();
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchMaterial(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {


                    cmd.CommandText = "Select * from MaterialMaster where IsActive =1 and  MaterialName like '%" + prefixText + "%'";


                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["MaterialName"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



            }



        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Assign")
            {
                PanelAdd.Visible = true;
                Mlist.Visible = false;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                orderNo = gvShow.DataKeys[rowIndex].Values[0].ToString();

                txtClinicNameShow.Text = gvShow.DataKeys[rowIndex].Values[1].ToString();
                lblClinicId.Text = gvShow.DataKeys[rowIndex].Values[2].ToString();
                txtROderDate.Text = Convert.ToDateTime(gvShow.DataKeys[rowIndex].Values[3]).ToString("dd-MM-yyyy");

                txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                NameValueCollection nv1 = new NameValueCollection();
                nv1.Add("@OrderNo", orderNo.ToString());
                nv1.Add("@MaterialID", "0");
                nv1.Add("@MaterialTypeId", "0");
                nv1.Add("@ClinicID", "0");
                nv1.Add("@FromDate", txtFromDate.Text);
                nv1.Add("@ToDate", txtToDate.Text);
                nv1.Add("@Mode", "2");

                DataTable dt1 = objG.GetDataTable("GET_MaterialStockRequestView", nv1);

                gvAssignMaterial.DataSource = dt1;
                gvAssignMaterial.DataBind();
            }
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvAssignMaterial.Rows)
            {
                int _isInserted = -1;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    General objGeneral = new General();
                    Label lblMaterialId = (row.Cells[0].FindControl("lblMaterialId") as Label);


                    Label lblClinicQty = (row.Cells[0].FindControl("lblClinicQty") as Label);
                    TextBox txtAssign = (row.Cells[0].FindControl("txtAssign") as TextBox);
                    TextBox txtRemark = (row.Cells[0].FindControl("txtRemark") as TextBox);
                    TextBox txtPrice = (row.Cells[0].FindControl("txtPrice") as TextBox);

                    NameValueCollection nv = new NameValueCollection();

                    //nv.Add("@ID","0");
                    //nv.Add("@MaterialId", lblMaterialId.Text);
                    //nv.Add("@RequestQty", lblClinicQty.Text);
                    //nv.Add("@ReceiveQty", txtAssign.Text);
                    //nv.Add("@RequestCode", orderNo.ToString());
                    //nv.Add("@ClinicId", lblClinicId.Text);
                    //nv.Add("@SendOrderBy", SessionUtilities.Empid.ToString());
                    //// nv.Add("@SendOrderDate", objGeneral.getDatetime(txtDate.Text).ToString() );
                    //nv.Add("@SendOrderDate", txtDate.Text);

                    //  _isInserted = objG.GetDataExecuteScaler("SP_AddRequestQtyClinic", nv);



                    _isInserted = objM.AddRequestStockMaterial(0, Convert.ToInt32(lblMaterialId.Text), Convert.ToInt32(lblClinicQty.Text), Convert.ToInt32(txtAssign.Text),orderNo, Convert.ToInt32(lblClinicId.Text), Convert.ToInt32(SessionUtilities.Empid), txtDate.Text, txtRemark.Text,Convert.ToDecimal(txtPrice.Text));



                    SelectedItems++;

                }

            }

            string message = "Added Successful";
            string url = "ViewRequestStock.aspx";

            objcommon.ShowMessageAndRedirect(this, message, url);
        }

        protected void btBack_Click(object sender, EventArgs e)
        {

        }

        protected void gvAssignMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOrderNo = (DropDownList)e.Row.FindControl("ddlOrderNo");
                Label lblMaterialID = (Label)e.Row.FindControl("lblMaterialID");
                TextBox txtPrice = (TextBox)e.Row.FindControl("txtPrice");

                Label lblCurrentStock = (Label)e.Row.FindControl("lblCurrentStock");
                Label lblClinicQty = (Label)e.Row.FindControl("lblClinicQty");
                TextBox txtAssign = (TextBox)e.Row.FindControl("txtAssign");


                NameValueCollection nv1 = new NameValueCollection();
                nv1.Add("@MaterialId", lblMaterialID.Text);
                nv1.Add("@Mode", "1");

                DataTable dt1 = objG.GetDataTable("GET_PurchaseOrderNo", nv1);


                ddlOrderNo.DataSource = dt1;
                ddlOrderNo.DataValueField = "OrderCode";
                ddlOrderNo.DataTextField = "OrderCode";
                ddlOrderNo.DataBind();
                ddlOrderNo.Items.Insert(0, new ListItem("--- Select Order No---", "0"));

                NameValueCollection nv11 = new NameValueCollection();
                nv11.Add("@MaterialId", lblMaterialID.Text);
                nv11.Add("@Mode", "2");

                DataTable dt2 = objG.GetDataTable("GET_PurchaseOrderNo", nv11);
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    txtPrice.Text = Convert.ToDecimal(dt2.Rows[0]["Hprice"]).ToString("N");
                }
                else
                {
                    txtPrice.Text = "0";
                }


                if(Convert.ToInt32(lblCurrentStock.Text ) ==0)
                {
                    txtAssign.ReadOnly = true;
                }
                else
                {
                    txtAssign.ReadOnly = false;
                }
            }
        }
    }
}