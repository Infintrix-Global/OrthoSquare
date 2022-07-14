using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections.Specialized;
using OrthoSquare.BAL_Classes;

namespace OrthoSquare.Enquiry
{
    public partial class UploadLeads : System.Web.UI.Page
    {

        GeneralNew objG = new GeneralNew();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }

        private void BindGridview()
        {

            NameValueCollection nv = new NameValueCollection();

            DataTable dt = objG.GetDataTable("GetLeads", nv);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridLeads.DataSource = dt;
                GridLeads.DataBind();
            }


        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/UploadFile/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(path);
                    // Connection String to Excel Workbook                    
                    string excelCS = string.Format(ConfigurationManager.ConnectionStrings["ExcelConn"].ConnectionString, path);
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        //Get the name of First Sheet.  
                        con.Open();
                        DataTable dtExcelSchema;
                        dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string sheetName = "Leads$";
                        con.Close();

                        DataTable dt = new DataTable();
                        OleDbCommand cmd = new OleDbCommand("select * from [" + sheetName + "]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        adapter.Fill(dt);
                        // SQL Server Connection String
                        string CS = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;


                        //call SP
                        using (SqlConnection SQLcon = new SqlConnection(CS))
                        {
                            using (SqlCommand SQLcmd = new SqlCommand("AddLeads", SQLcon))
                            {
                                SQLcon.Open();
                                foreach (DataRow dr in dt.Rows)
                                {
                                    SQLcmd.CommandType = CommandType.StoredProcedure;
                                    SQLcmd.Parameters.Clear();
                                    SQLcmd.Parameters.Add("@EnquiryDate", SqlDbType.Date).Value = dr[0];
                                    SQLcmd.Parameters.Add("@ad_id", SqlDbType.BigInt).Value = dr[1];
                                    SQLcmd.Parameters.Add("@ad_name", SqlDbType.NVarChar).Value = dr[2];
                                    SQLcmd.Parameters.Add("@adset_id", SqlDbType.BigInt).Value = dr[3];
                                    SQLcmd.Parameters.Add("@adset_name", SqlDbType.NVarChar).Value = dr[4];
                                    SQLcmd.Parameters.Add("@campaign_id", SqlDbType.BigInt).Value = dr[5];
                                    SQLcmd.Parameters.Add("@campaign_name", SqlDbType.NVarChar).Value = dr[6];
                                    SQLcmd.Parameters.Add("@form_id", SqlDbType.BigInt).Value = dr[7];
                                    SQLcmd.Parameters.Add("@form_name", SqlDbType.NVarChar).Value = dr[8];
                                    SQLcmd.Parameters.Add("@is_organic", SqlDbType.NVarChar).Value = dr[9];
                                    SQLcmd.Parameters.Add("@platform", SqlDbType.NVarChar).Value = dr[10];
                                    SQLcmd.Parameters.Add("@Email_id", SqlDbType.NVarChar).Value = dr[11];
                                    SQLcmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = dr[12];
                                    SQLcmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = dr[13];
                                    SQLcmd.Parameters.Add("@post_code", SqlDbType.NVarChar).Value = dr[14];
                                    SQLcmd.Parameters.Add("@retailer_item_id", SqlDbType.NVarChar).Value = dr[15];
                                    SQLcmd.Parameters.Add("@REgion", SqlDbType.NVarChar).Value = dr[16];
                                    SQLcmd.Parameters.Add("@Clinic", SqlDbType.NVarChar).Value = dr[17];
                                    SQLcmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = dr[18];
                                    SQLcmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = dr[19];
                                    SQLcmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = dr[20];
                                    SQLcmd.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = dr[21];
                                    SQLcmd.ExecuteNonQuery();




                                }
                                SQLcon.Close();
                            }
                        }

                        BindGridview();
                        lblMessage.Text = "Your file uploaded successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;

                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Your file not uploaded" + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;

                }
            }
        }

        protected void GridLeads_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridLeads.PageIndex = e.NewPageIndex;
            BindGridview();

        }
    }
}