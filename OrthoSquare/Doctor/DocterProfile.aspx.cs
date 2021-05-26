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
    public partial class DocterProfile : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        BasePage objBasePage = new BasePage();
        BAL_DoctorsDetails objDoc = new BAL_DoctorsDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
              //  DoctorDegree();
                bindDoctorProfile();

            }
        }

        //public void DoctorDegree()
        //{
        //    ddl_Degree1.DataSource = objcommon.DoctorDegree();
        //    ddl_Degree1.DataValueField = "DegreeID";
        //    ddl_Degree1.DataTextField = "Name";
        //    ddl_Degree1.DataBind();
        //}


        public void bindDoctorProfile()
        {


            DataTable dt1 = objDoc.GetDoctersInouttime(SessionUtilities.Empid);

            if (dt1 != null && dt1.Rows.Count > 0)
            {

                lblName.Text = dt1.Rows[0]["FirstName"].ToString() + " " + dt1.Rows[0]["LastName"].ToString();
                ImagePhoto1.ImageUrl = "~/EmployeeProfile/" + dt1.Rows[0]["ProfileImageUrl"].ToString();

                if(dt1.Rows[0]["DOB"].ToString() !="")
                {
                    lblbirthDate.Text = Convert.ToDateTime(dt1.Rows[0]["DOB"]).ToString("dd-MM-yyyy");
                }
                lblGender.Text = dt1.Rows[0]["Gender"].ToString();
                lblAddress.Text = dt1.Rows[0]["Line1"].ToString() + ", " + dt1.Rows[0]["Line2"].ToString() + " ," + dt1.Rows[0]["AreaPin"].ToString(); ;
                lblMobileNo.Text = dt1.Rows[0]["Mobile1"].ToString() + " ," + dt1.Rows[0]["Mobile2"].ToString();
                lblEmail.Text = dt1.Rows[0]["Email"].ToString();
                lblBloodGroup.Text = dt1.Rows[0]["BloodGroup"].ToString();
                lblTime.Text = "In Time: " + dt1.Rows[0]["InTime"].ToString() + ", Out Time: " + dt1.Rows[0]["OutTime"].ToString();
            }
            //DataTable dt11 = objDoc.GetDocterstbl_Doctor_Degree(SessionUtilities.Empid);
            //  DoctorDegree();



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