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
    public partial class ViewOrderHistory : System.Web.UI.Page
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

                if (SessionUtilities.RoleID == 1)
                {
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();

                }
                BindMaterialType();
                getAllCollection();
            }
        }

        private long orderNo
        {
            get
            {
                if (ViewState["orderNo"] != null)
                {
                    return (long)ViewState["orderNo"];
                }
                return 0;
            }
            set
            {
                ViewState["orderNo"] = value;
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




        public void BindMaterialType()
        {

            ddlMaterialType.DataSource = objMT.GetAllMaterialType("", "Material");
            ddlMaterialType.DataValueField = "MaterialTypeId";
            ddlMaterialType.DataTextField = "MaterialName";
            ddlMaterialType.DataBind();
            ddlMaterialType.Items.Insert(0, new ListItem("--- Select Material Type---", "0"));
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
            nv.Add("@DoctorId", "0");
            nv.Add("@FromDate", txtFromDate.Text);
            nv.Add("@ToDate", txtToDate.Text);
            nv.Add("@OrderNo", "0");

            nv.Add("@Mode", "1");

            DataTable dt = objG.GetDataTable("GET_MaterialStockOrderhistory", nv);
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
                GridView gvviewOrder = e.Row.FindControl("gvviewOrder") as GridView;
                Label lblRequestCode = (Label)e.Row.FindControl("lblRequestCode");
                NameValueCollection nv = new NameValueCollection();
                nv.Add("@MaterialID", MaterialID.ToString());
                nv.Add("@MaterialTypeId", ddlMaterialType.SelectedValue);
                nv.Add("@ClinicID", ddlClinic.SelectedValue);
                nv.Add("@DoctorId", "0");
                nv.Add("@FromDate", txtFromDate.Text);
                nv.Add("@ToDate", txtToDate.Text);
                nv.Add("@OrderNo", lblRequestCode.Text);

                nv.Add("@Mode", "2");

                DataTable dt = objG.GetDataTable("GET_MaterialStockOrderhistory", nv);

                gvviewOrder.DataSource = dt;
                gvviewOrder.DataBind();
            }



        }

    }
}