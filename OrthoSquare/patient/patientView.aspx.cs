using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;
using System.Configuration;
using System.IO;
using System.Net;

namespace OrthoSquare.patient
{
    public partial class patientView : System.Web.UI.Page
    {
        BAL_Patient objP = new BAL_Patient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(Request.QueryString["pid"]);
            bindDoctorProfile(pid);
        }


        public void bindDoctorProfile(int pid)
        {


            DataTable dt1 = objP.GetPatientDetils(pid);

            if (dt1 != null && dt1.Rows.Count > 0)
            {

                lblName.Text = dt1.Rows[0]["FristName"].ToString() + " " + dt1.Rows[0]["LastName"].ToString();

                if (dt1.Rows[0]["ProfileImage"] != "")
                {
                    ImagePhoto11.ImageUrl = "~/EmployeeProfile/" + dt1.Rows[0]["ProfileImage"].ToString();
                }
                else
                {
                    ImagePhoto11.ImageUrl = "~/Images/no-photo.jpg";

                }

              //  lblbirthDate.Text = Convert.ToDateTime(dt1.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                lblGender.Text = dt1.Rows[0]["Gender"].ToString();
                lblAddress.Text = dt1.Rows[0]["Address"].ToString() + ", " + dt1.Rows[0]["Area"].ToString() ;
                lblMobileNo.Text = dt1.Rows[0]["Mobile"].ToString() + " ," + dt1.Rows[0]["Telephone"].ToString();
                lblEmail.Text = dt1.Rows[0]["Email"].ToString();
                lblBloodGroup.Text = dt1.Rows[0]["BloodGroup"].ToString();

                DataTable dt11 = objP.GetPatientMedicalHistory(pid);
                if (dt11 != null && dt11.Rows.Count > 0)
                {
                    txtListMedicine.Text = dt11.Rows[0]["ListofMedicine"].ToString();
                    txtDoctorAddres.Text = dt11.Rows[0]["DrAddress"].ToString();

                    txtFDoctorName.Text = dt11.Rows[0]["FamilyDoctorName"].ToString();

                    RadPregnant1.SelectedValue = dt11.Rows[0]["Pregnant"].ToString();
                    RadPanMasala.SelectedValue = dt11.Rows[0]["PanMasalaChewing"].ToString();
                    RadTobacco.SelectedValue = dt11.Rows[0]["Tobacco"].ToString();
                    RadSomking.SelectedValue = dt11.Rows[0]["Somking"].ToString();


                    if (Convert.ToDateTime(dt11.Rows[0]["DueDate"]).ToString("dd-MM-yyyy") == "01-01-1990")
                    {
                        txtPreganetDueDate.Visible = false;
                        
                    }
                    else
                    {
                        txtPreganetDueDate.Visible = true;
                        txtPreganetDueDate.Text = Convert.ToDateTime(dt11.Rows[0]["DueDate"]).ToString("dd-MM-yyyy");
                    }

                    if (dt11.Rows[0]["Somking"].ToString() == "Yes")
                    {
                        txtNofoCigrattes.Visible = true;
                        txtNofoCigrattes.Text = dt11.Rows[0]["cigrattesInDay"].ToString();
                    }
                   
                }
                DataTable dt111 = objP.GetPatientMedicalProblem(pid);
                if (dt111 != null && dt111.Rows.Count > 0)
                {
                    GridMproblem.DataSource = dt111;
                    GridMproblem.DataBind();
                }
                DataTable dtalg = objP.GetPatientbyAllergic(pid);
                if (dtalg != null && dtalg.Rows.Count > 0)
                {
                    Gridallergic.DataSource = dtalg;
                    Gridallergic.DataBind();
                }
            }
        }
    }
}