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
    public partial class AssignMaterial : System.Web.UI.Page
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
                txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                bindClinic();
    
                if (SessionUtilities.RoleID == 1)
                {
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindDocter(Convert.ToInt32(SessionUtilities.Empid));
                }
                else
                {
                    BindDocter(0);
                }
               
                BindMaterialType();
                getAllMaterialStock();
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
            Session["Cid"] = ddlClinic.SelectedValue;
        }


        public void BindDocter(int Cid)
        {
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDoctor.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);

            }
            else
            {
                ddlDoctor.DataSource = objcommon.DoctersMasterNewENQ11(Cid, SessionUtilities.RoleID);

            }

            ddlDoctor.DataTextField = "DoctorName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();
            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }



        public void BindMaterialType()
        {

            ddlMaterialType.DataSource = objMT.GetAllMaterialType("", "Material");
            ddlMaterialType.DataValueField = "MaterialTypeId";
            ddlMaterialType.DataTextField = "MaterialName";
            ddlMaterialType.DataBind();
            ddlMaterialType.Items.Insert(0, new ListItem("--- Select Material Type---", "0"));
        }


        public void getAllMaterialStock()
        {

            NameValueCollection nv = new NameValueCollection();
            nv.Add("@MaterialID", MaterialID.ToString());
            nv.Add("@MaterialTypeId", ddlMaterialType.SelectedValue);
            nv.Add("@ClinicID", SessionUtilities.Empid.ToString());
            nv.Add("@FromDate", txtFromDate.Text);
            nv.Add("@ToDate", txtToDate.Text);
            

            DataTable dt = objG.GetDataTable("GET_ViewReceiveMaterailStock", nv);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalTop.Text = dt.Rows.Count.ToString();

                GridMateialStock.DataSource = dt;
                GridMateialStock.DataBind();
            }
            else
            {
                GridMateialStock.DataSource = null;
                GridMateialStock.DataBind();
                lblTotalTop.Text = "0";
            }
        }



        protected void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objM.GetMaterialSelect(txtMaterial.Text);
            MaterialID = Convert.ToInt32(dt.Rows[0]["MaterialId"]);
            getAllMaterialStock();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getAllMaterialStock();
        }
        protected void ddlMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllMaterialStock();
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

        protected void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                int _isInserted = -1;
                int SelectedItems = 0;

                Button btnReceive = (Button)sender;
                GridViewRow row = (GridViewRow)btnReceive.NamingContainer;
                if (row != null)
                {
                    General objGeneral = new General();
                    Label lblReceiveMaterialId = (Label)row.FindControl("lblReceiveMaterialId");
                    Label lblMaterialId = (Label)row.FindControl("lblMaterialId");
                    Label lblClinicId = (Label)row.FindControl("lblClinicId");
                    Label lblReceiveQty = (Label)row.FindControl("lblReceiveQty");

                    Label lblRequestQty = (Label)row.FindControl("lblRequestQty");
                    Label lblRequestCode = (Label)row.FindControl("lblRequestCode");

                    TextBox txtActualQty = (TextBox)row.FindControl("txtActualQty");
                    TextBox txtRemark = (TextBox)row.FindControl("txtRemark");


                    //NameValueCollection nv = new NameValueCollection();

                    //nv.Add("@ReceiveMaterialId", lblReceiveMaterialId.Text);
                    //nv.Add("@MaterialId", lblMaterialId.Text);
                    //nv.Add("@RequestQty", lblRequestQty.Text);
                    //nv.Add("@ReceiveQty", lblReceiveQty.Text);
                    //nv.Add("@ClinicId", ddlClinic.SelectedValue);
                    //nv.Add("@orderNo", lblRequestCode.Text);
                    //nv.Add("@ReceiveBy", ddlDoctor.SelectedValue);
                    ////nv.Add("@ReceiveDate", objGeneral.getDatetime(txtDate.Text).ToString() );
                    //nv.Add("@ReceiveDate", txtDate.Text);

                    _isInserted = objM.AddReceiveStockMaterial(Convert.ToInt32(lblReceiveMaterialId.Text), Convert.ToInt32(lblMaterialId.Text), Convert.ToInt32(lblRequestQty.Text), Convert.ToInt32(lblReceiveQty.Text), Convert.ToInt32(ddlClinic.SelectedValue),lblRequestCode.Text,Convert.ToInt32(ddlDoctor.SelectedValue),txtDate.Text, txtRemark.Text, Convert.ToInt32(txtActualQty.Text));
                   
                   // _isInserted = objG.GetDataExecuteScaler("SP_AddReceiveMaterialStockClinic", nv);
                }
                getAllMaterialStock();

            }
            catch (Exception ex)
            {
            }
        }
    }
}