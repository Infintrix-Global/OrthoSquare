using OrthoSquare.BAL_Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrthoSquare.Master
{
    public partial class SubAdminClinic : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        
        BAL_DoctorsDetails objDoc = new BAL_DoctorsDetails();
        BAL_Appointment objApp = new BAL_Appointment();
        BAL_Clinic objclinic = new BAL_Clinic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // bindDoctorMaster(0, 0);
                BindddlclinicAS();
            }
        }

        private long DoctorID
        {
            get
            {
                if (ViewState["DoctorID"] != null)
                {
                    return (long)ViewState["DoctorID"];
                }
                return 0;
            }
            set
            {
                ViewState["DoctorID"] = value;
            }
        }

        //public void bindDoctorMaster(int did, int Rolid)
        //{
        //    ddl_DocterDetils.DataSource = objcommon.DoctersMasterNew(did, Rolid);

        //    ddl_DocterDetils.DataValueField = "DoctorID";
        //    ddl_DocterDetils.DataTextField = "DoctorName";
        //    ddl_DocterDetils.DataBind();
        //    ddl_DocterDetils.Items.Insert(0, new ListItem("-- Select Doctor --", "0", true));

        //}

        public void BindddlclinicAS()
        {

            CheckBoxList1.DataSource = objcommon.clinicMaster();
            CheckBoxList1.DataTextField = "ClinicName";
            CheckBoxList1.DataValueField = "ClinicID";
            CheckBoxList1.DataBind();


            DataTable dt111SP = objDoc.GetSubAdminClinicSelect(Convert.ToInt32(DoctorID));


            if (dt111SP != null && dt111SP.Rows.Count > 0)
            {
                for (int j = 0; j < dt111SP.Rows.Count; j++)
                {
                    for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                    {
                        if (CheckBoxList1.Items[i].Value == dt111SP.Rows[j]["ClinicID"].ToString())
                        {
                            CheckBoxList1.Items[i].Selected = true;
                        }
                    }
                }
            }

        }

        protected void cbAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = "";
            string ID = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    name += CheckBoxList1.Items[i].Text + ",";
                    ID += CheckBoxList1.Items[i].Value + ",";
                }
            }
            TextBox1.Text = name;

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = "";

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    name += CheckBoxList1.Items[i].Text + ",";
                 //   lID += CheckBoxList1.Items[i].Value + ",";
                }
            }
            TextBox1.Text = name;

        }

        protected void btnDbyCSubmit_Click(object sender, EventArgs e)
        {


            try
            {

                int D_id = objDoc.Add_SubAdminClinicDelete(Convert.ToInt32(DoctorID));

                int _isInserted = -1;

                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    string ID = "";
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        ID = CheckBoxList1.Items[i].Value;

                        _isInserted = objDoc.Add_SubAdminClinicClinic(Convert.ToInt32(ID), Convert.ToInt32(DoctorID));

                    }
                }


                if (_isInserted == -1)
                {
                    lblmsg1223.Text = "Failed to Add Doctor";
                    lblmsg1223.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    lblmsg1223.Text = "Doctor Added Successfully";
                    lblmsg1223.ForeColor = System.Drawing.Color.Green;

                    TextBox1.Text = "";
                    BindddlclinicAS();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnDyc_Click(object sender, EventArgs e)
        {

        }

        protected void ddl_DocterDetils_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindddlclinicAS();
        }

        protected void txtDocter_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = objcommon.DoctersSelectDoctorID(txtDocter.Text);

            DoctorID = Convert.ToInt32(dt.Rows[0]["DoctorID"]);
            BindddlclinicAS();
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["OrthoSquareDBConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    int DoctorID = 0, ClinicId = 0;
                    int RoleId = Convert.ToInt32(HttpContext.Current.Session["RoleID"]);
                    DoctorID = Convert.ToInt32(HttpContext.Current.Session["Empid"]);
                    ClinicId = Convert.ToInt32(HttpContext.Current.Session["Empid"]);
                    //cmd.CommandText = " select distinct GPD.jobcode from gti_jobs_seeds_plan GTS inner join GrowerPutAwayDetails GPD on GPD.wo=GTS.wo  where  GPD.FacilityID ='" + Facility + "'  AND GPD.jobcode like '%" + prefixText + "%' union select distinct jobcode from gti_jobs_seeds_plan_Manual where loc_seedline ='" + Facility + "'  AND jobcode like '%" + prefixText + "%' order by jobcode" +
                    //    "";
                    //SessionUtilities.Empid, SessionUtilities.RoleID



                   

                        cmd.CommandText = "Select  FirstName+' '+ isnull(LastName,' ') as DoctorName,* from tbl_DoctorDetails where  IsActive =1  and IsDeleted=0 and  FirstName +' ' + LastName like '%" + prefixText + "%' ";
                        cmd.CommandText += "  order by FirstName ASC";
                    

                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["DoctorName"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }

    }
}