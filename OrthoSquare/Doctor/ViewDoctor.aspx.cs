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

namespace OrthoSquare.Doctor
{
    public partial class ViewDoctor : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BasePage objBasePage = new BasePage();
        BAL_DoctorsDetails objDoc = new BAL_DoctorsDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int Did = Convert.ToInt32(Request.QueryString["DoctorID"]);
                //  DoctorDegree();
                bindDoctorProfile(Did);

            }
        }

        public void bindDoctorProfile(int Did)
        {


            DataTable dt1 = objDoc.GetDoctersInouttime(Did);

            if (dt1 != null && dt1.Rows.Count > 0)
            {

                lblName.Text = dt1.Rows[0]["FirstName"].ToString() + " " + dt1.Rows[0]["LastName"].ToString();

                if (dt1.Rows[0]["ProfileImageUrl"] != "")
                {
                    ImagePhoto11.ImageUrl = "~/EmployeeProfile/" + dt1.Rows[0]["ProfileImageUrl"].ToString();
                }
                else
                {
                    ImagePhoto11.ImageUrl = "~/Images/no-photo.jpg";

                }

                lblbirthDate.Text = Convert.ToDateTime(dt1.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                lblGender.Text = dt1.Rows[0]["Gender"].ToString();
                lblAddress.Text = dt1.Rows[0]["Line1"].ToString() + ", " + dt1.Rows[0]["Line2"].ToString() + " ," + dt1.Rows[0]["AreaPin"].ToString() ;
                lblMobileNo.Text = dt1.Rows[0]["Mobile1"].ToString() + " ," + dt1.Rows[0]["Mobile2"].ToString();
                lblEmail.Text = dt1.Rows[0]["Email"].ToString();
                lblBloodGroup.Text = dt1.Rows[0]["BloodGroup"].ToString();
                lblTime.Text = "In Time: " + dt1.Rows[0]["InTime"].ToString() + ", Out Time: " + dt1.Rows[0]["OutTime"].ToString();

                if (dt1.Rows[0]["AdharCardImageUrl"] != "")
                {
                    ImageAdhar.ImageUrl = "~/Documents/" + dt1.Rows[0]["AdharCardImageUrl"].ToString();
                }
                else
                {
                    ImageAdhar.ImageUrl = "~/Images/no-photo.jpg";

                }

                if (dt1.Rows[0]["PanCardImageUrl"] != "")
                {
                    ImagePanCardNo1.ImageUrl = "~/Documents/" + dt1.Rows[0]["PanCardImageUrl"].ToString();
                }
                else
                {
                    ImagePanCardNo1.ImageUrl = "~/Images/no-photo.jpg";

                }
                if (dt1.Rows[0]["RegistrationImageUrl"] != "")
                {
                    ImageRegistrationNo.ImageUrl = "~/Documents/" + dt1.Rows[0]["RegistrationImageUrl"].ToString();
                }
                else
                {
                    ImageRegistrationNo.ImageUrl = "~/Images/no-photo.jpg";

                }

                if (dt1.Rows[0]["IdentityPolicyImageUrl"] != "")
                {
                    ImageIdentityPolicyNo.ImageUrl = "~/Documents/" + dt1.Rows[0]["IdentityPolicyImageUrl"].ToString();
                }
                else
                {
                    ImageIdentityPolicyNo.ImageUrl = "~/Images/no-photo.jpg";

                }
               
               
                
                
                
                lblAdharcard.Text = dt1.Rows[0]["AdharCardNo"].ToString();
                lblPanCardNo.Text = dt1.Rows[0]["PanCardNo"].ToString();
                lblRegistrationNo.Text = dt1.Rows[0]["RegistrationNo"].ToString();
                lblIdentityPolicyNo.Text = dt1.Rows[0]["IdentityPolicyNo"].ToString();


                DataTable dt11 = objDoc.GetDocterstbl_Doctor_Degree(Did);
                if (dt11 != null && dt11.Rows.Count > 0)
                {

                    lblDegree.Text = dt11.Rows[0]["Name"].ToString();
                    ImageDegree.ImageUrl = "~/Documents/" + dt11.Rows[0]["DegreeUpload1"].ToString();
                }
                DataTable dt111 = objDoc.GetDocterstbl_DrSpeciality(Did);

                if (dt111 != null && dt111.Rows.Count > 0)
                {
                    GridSpeciality.DataSource = dt111;
                    GridSpeciality.DataBind();
                }


                DataTable dtDbC = objDoc.GetDoctorbyClinic(Did);

                if (dtDbC != null && dtDbC.Rows.Count > 0)
                {
                    GridDoctorbyClinic.DataSource = dtDbC;
                    GridDoctorbyClinic.DataBind();
                }
            }
            //DataTable dt11 = objDoc.GetDocterstbl_Doctor_Degree(SessionUtilities.Empid);
            //  DoctorDegree();



            //ImagePhoto1.ImageUrl = "~/Images/no-photo.jpg";
            //ImageAdharcard.ImageUrl = "~/Images/no-photo.jpg";
            //Imagepancard.ImageUrl = "~/Images/no-photo.jpg";
            //ImageCrtificat.ImageUrl = "~/Images/no-photo.jpg";
            //Image_Degree1.ImageUrl = "~/Images/no-photo.jpg";
            //ImageDegree2.ImageUrl = "~/Images/no-photo.jpg";
            //ImagePolicy.ImageUrl = "~/Images/no-photo.jpg";


            //for (int p=0; dt11.Rows.Count > 0; p++)
            //{
            //    foreach (ListItem item in ddl_Degree1.Items)
            //    {
            //        if (item.Value == dt1.Rows[p]["DegreeID"])
            //            item.Selected = true;
            //        else
            //            item.Selected = false;



            //    }
            //}








            //DoctorID = DoctorID;
            //DoctorTypeNew();
            //ddlDoctorTypeNew.SelectedValue = dt1.Rows[0]["DoctorTypeID"].ToString();

            //txtFristName.Text = dt1.Rows[0]["FirstName"].ToString();
            //txtLastName.Text = dt1.Rows[0]["LastName"].ToString();
            //txtBirthDate.Text = dt1.Rows[0]["DOB"].ToString();
            ////   RADGender .SelectedItem.Text=dt1.Rows[0]["Gender"].ToString() ; 
            //txtAddress1.Text = dt1.Rows[0]["Line1"].ToString();
            //txtAddress2.Text = dt1.Rows[0]["Line2"].ToString();
            //BindCountry();
            //ddlCountry.SelectedValue = dt1.Rows[0]["CountryID"].ToString();
            //BindState();
            //ddlState.SelectedValue = dt1.Rows[0]["StateID"].ToString();
            //BindCity();
            //ddlCity.SelectedValue = dt1.Rows[0]["CityID"].ToString();
            //txtPinCode.Text = dt1.Rows[0]["AreaPin"].ToString();
            //txtMobileNo1.Text = dt1.Rows[0]["Mobile1"].ToString();
            //txtMobileNo2.Text = dt1.Rows[0]["Mobile2"].ToString();
            //txtEmail.Text = dt1.Rows[0]["Email"].ToString();
            //txtBloodGroup.Text = dt1.Rows[0]["BloodGroup"].ToString();
            ////txtPanCard.Text ,
            ////PanCardImageUrl=PanCardImageUrl,
            ////AdharCardNo =txtAdharNo .Text ,
            ////AdharCardImageUrl =AdharCarImageUrl ,
            ////ProfileImageUrl =profileImageUrl, 
            //txtUserName.Text = dt1.Rows[0]["UserName1"].ToString();
            //txtPassword.Text = dt1.Rows[0]["Password1"].ToString();
            //txtInTime.Text = dt1.Rows[0]["InTime"].ToString();
            //txtOutTime.Text = dt1.Rows[0]["OutTime"].ToString();
            //Bindddlclinic();
            //ddlclinic.SelectedValue = dt1.Rows[0]["ClinicID"].ToString();


            //ImagePhoto1.ImageUrl = "~/EmployeeProfile/" + dt1.Rows[0]["ProfileImageUrl"].ToString();
            //ImageAdharcard.ImageUrl = "~/Documents/" + dt1.Rows[0]["AdharCardImageUrl"].ToString();
            //Imagepancard.ImageUrl = "~/Documents/" + dt1.Rows[0]["PanCardImageUrl"].ToString();
            //ImageCrtificat.ImageUrl = "~/Documents/" + dt1.Rows[0]["RegistrationImageUrl"].ToString();

            //ImagePolicy.ImageUrl = "~/Documents/" + dt1.Rows[0]["IdentityPolicyImageUrl"].ToString();

            //txtAdharNo.Text = dt1.Rows[0]["AdharCardNo"].ToString();
            //txtPanCard.Text = dt1.Rows[0]["PanCardNo"].ToString();
            //txtRegNo.Text = dt1.Rows[0]["RegistrationNo"].ToString();
            //txtIdentity.Text = dt1.Rows[0]["IdentityPolicyNo"].ToString();
        }
    }
}