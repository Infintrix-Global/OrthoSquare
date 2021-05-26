using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OrthoSquare.BAL_Classes;

using OrthoSquare.Utility;
using System.IO;

namespace OrthoSquare.Doctor
{
    public partial class DeactiveDoctors : System.Web.UI.Page
    {
        public static DataTable AllData = new DataTable();
        BAL_Clinic objc = new BAL_Clinic();
        clsCommonMasters objcomm = new clsCommonMasters();
        BAL_DeactiveDoctors objDeActive = new BAL_DeactiveDoctors();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindClinic();
            }
        }


        public void bindClinic()
        {

            DataTable dt;

            if (SessionUtilities.RoleID == 3)
            {
                dt = objcomm.GetDoctorByClinic(SessionUtilities.Empid);
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


        public void GetDoctors(int ClinicID)
        {
            AllData = objDeActive.GetDoctorsDetails(ClinicID);
            if (AllData != null && AllData.Rows.Count > 0)
            {
                CheckBox_Doctor.DataSource = AllData;
                CheckBox_Doctor.DataValueField = "DCID";
                CheckBox_Doctor.DataTextField = "DName";
                CheckBox_Doctor.DataBind();
                DataTable Dt = objDeActive.GetDoctorsSelect(ClinicID);

                if (Dt != null && Dt.Rows.Count > 0)
                {
                    for (int j = 0; j < Dt.Rows.Count; j++)
                    {
                        for (int i = 0; i < CheckBox_Doctor.Items.Count; i++)
                        {
                            if (CheckBox_Doctor.Items[i].Value == Dt.Rows[j]["DCID"].ToString())
                            {
                                CheckBox_Doctor.Items[i].Selected = true;
                            }
                        }
                    }
                }
            }
            else
            {
                CheckBox_Doctor.Items.Clear();
                CheckBox_Doctor.DataSource = null;
                CheckBox_Doctor.DataBind();
            }
        }

        protected void ddlClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDoctors(Convert.ToInt32(ddlClinic.SelectedValue));
            lblMessage.Text = "";
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            int _isInserted = -1;

            int IsDeactive = 0;
            int IsActive = 0;
            for (int i = 0; i < CheckBox_Doctor.Items.Count; i++)
            {


                if (CheckBox_Doctor.Items[i].Selected)
                {
                    IsActive = Convert.ToInt32(CheckBox_Doctor.Items[i].Value);

                    _isInserted = objDeActive.UpdateIsActive(IsActive);
                }
                else
                {
                    IsDeactive = Convert.ToInt32(CheckBox_Doctor.Items[i].Value);

                    _isInserted = objDeActive.UpdateIsDeactive(IsDeactive);

                }
            }




            if (_isInserted == -1)
            {
                lblMessage.Text = "Failed to Doctors deactivated";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {

                lblMessage.Text = "Doctors deactivated successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                bindClinic();
                GetDoctors(0);
                CheckBox_Doctor.ClearSelection();
              

            }


        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            bindClinic();
            CheckBox_Doctor.ClearSelection();
            lblMessage.Text = "";
            GetDoctors(0);
        }
    }
}