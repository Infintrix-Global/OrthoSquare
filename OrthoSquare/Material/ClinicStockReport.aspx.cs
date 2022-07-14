using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Configuration;

namespace OrthoSquare.Material
{
    public partial class ClinicStockReport : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        BAL_MaterialMaster objM = new BAL_MaterialMaster();
        BAL_Vendor objVendor = new BAL_Vendor();
        clsCommonMasters objcommon = new clsCommonMasters();
        Bal_MaterilaType objMtype = new Bal_MaterilaType();
        BAL_Clinic objc = new BAL_Clinic();
        GeneralNew objG = new GeneralNew();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                MaterialType();
                getAllGridplaceorder();


            }
        }

        public void MaterialType()
        {
            try
            {
                ddlMaterialType.DataSource = objMtype.GetAllMaterialType("", "Material");
                ddlMaterialType.DataValueField = "MaterialTypeId";
                ddlMaterialType.DataTextField = "MaterialName";
                ddlMaterialType.DataBind();
                ddlMaterialType.Items.Insert(0, new ListItem("--- Select Material Type---", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void getAllGridplaceorder()
        {

            DataTable AllData1 = objM.GetMaterialStock(ddlMaterialType.SelectedValue, txtMaterial.Text.Trim(), 5, Convert.ToInt32(Session["Empid"].ToString()));
            if (AllData1 != null && AllData1.Rows.Count > 0)
            {
                Gridplaceorder.DataSource = AllData1;
                Gridplaceorder.DataBind();
            }
            else
            {
                Gridplaceorder.DataSource = null;
                Gridplaceorder.DataBind();
            }
        }


        protected void Gridplaceorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
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


            }

        }

     
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllGridplaceorder();
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


    }
}