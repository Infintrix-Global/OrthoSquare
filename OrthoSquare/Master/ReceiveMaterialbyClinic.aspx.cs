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
using PreconFinal.Utility;
using System.Data.OleDb;

namespace OrthoSquare.Master
{
    public partial class ReceiveMaterialbyClinic : System.Web.UI.Page
    {

        BAL_MaterialMaster objm = new BAL_MaterialMaster();
        BAL_Vendor objVendor = new BAL_Vendor();
        public static DataTable AllData = new DataTable();
        BAL_Clinic objc = new BAL_Clinic();
        clsCommonMasters objcommon = new clsCommonMasters();
        BAL_DoctorsDetails objdoc = new BAL_DoctorsDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindMaterial();
                BindVendor();
                bindClinic();


                if (SessionUtilities.RoleID == 1)
                {
                    ddlClinic.SelectedValue = SessionUtilities.Empid.ToString();
                    BindDocter(Convert .ToInt32 (SessionUtilities.Empid));
                }
             
                getAllinoutmaterial();

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

        public void BindDocter(int Cid)
        {
            if (SessionUtilities.RoleID == 3 || SessionUtilities.RoleID == 1)
            {

                ddlDoctor.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);
               
            }
            else
            {
                ddlDoctor.DataSource = objcommon.DoctersMaster(Cid, SessionUtilities.RoleID);
             
            }



          
            ddlDoctor.DataTextField = "FirstName";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();
            ddlDoctor.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }
        public void BindMaterial()
        {




            ddlMaterialSearch.DataSource = objm.GetAllMaterial(0);
            ddlMaterialSearch.DataTextField = "MaterialName";
            ddlMaterialSearch.DataValueField = "MaterialId";
            ddlMaterialSearch.DataBind();
            ddlMaterialSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }

        public void BindVendor()
        {

            DataTable dt = objVendor.GetAllVendor(0,0);

            ddlvenderSearch.DataSource = dt;
            ddlvenderSearch.DataTextField = "VendorName";
            ddlvenderSearch.DataValueField = "VendorID";
            ddlvenderSearch.DataBind();
            ddlvenderSearch.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }

        public void getAllinoutmaterial()
        {



            AllData = objm.GetAllinoutmaterial(Convert.ToInt32(ddlvenderSearch.SelectedValue), Convert.ToInt32(ddlMaterialSearch.SelectedValue));
            gvShow.DataSource = AllData;
            gvShow.DataBind();

        }
        protected void btSearch_Click(object sender, EventArgs e)
        {
            getAllinoutmaterial();
        }
        protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShow.PageIndex = e.NewPageIndex;
            // btSearch_Click(sender, e);
            getAllinoutmaterial();
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        

        protected void btnUpdateIOMaterial_Click(object sender, EventArgs e)
        {


            try
            {
                int _isInserted = -1;

                int Qtr1=0;

                int SelectedItems = 0;
                foreach (GridViewRow item in gvShow.Rows)
                {

                    if (item.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkSelect = (CheckBox)item.FindControl("chkSelectMaterialId");
                        if (chkSelect != null && chkSelect.Checked == true)
                        {

                            Label ID = (item.Cells[0].FindControl("LabelMaterialId") as Label);

                            Label lblOrderQty = (item.Cells[0].FindControl("lblOrderQty") as Label);

                            Label lblMaterialId = (item.Cells[0].FindControl("lblMaterialId") as Label);
                            Label lblVendorID = (item.Cells[0].FindControl("lblVendorID") as Label);


                            Label lblPending = (item.Cells[0].FindControl("lblPending") as Label);

                            TextBox txtOrderRecQty = (item.Cells[0].FindControl("txtOrderRecQty") as TextBox);

                            TextBox txtRecivedDate = (item.Cells[0].FindControl("txtRecivedDate") as TextBox);




                            if (Convert.ToInt32(lblOrderQty.Text) > Convert.ToInt32(txtOrderRecQty.Text) || Convert.ToInt32(lblOrderQty.Text) == Convert.ToInt32(txtOrderRecQty.Text))
                            {


                                if (Convert.ToInt32(lblPending.Text) > Convert.ToInt32(txtOrderRecQty.Text) || Convert.ToInt32(lblPending.Text) == Convert.ToInt32(txtOrderRecQty.Text))
                                {
                                    _isInserted = objm.AddInOutMaterialClinicReceive(Convert.ToInt32(ID.Text), Convert.ToInt32(ddlClinic.SelectedValue), Convert.ToInt32(ddlDoctor.SelectedValue), txtRecivedDate.Text, Convert.ToInt32(txtOrderRecQty.Text));


                                    DataTable SRid = objm.GetmaterialRecvered11(Convert.ToInt32(Convert.ToInt32(ID.Text)));

                                    if (SRid.Rows[0]["ReceiveQty"].ToString() == "0")
                                    {
                                        _isInserted = objm.UpdateInOutMaterialClinicReceive(Convert.ToInt32(ID.Text), Convert.ToInt32(txtOrderRecQty.Text));
                                    }
                                    else
                                    {
                                         int RtTotal = Convert.ToInt32(SRid.Rows[0]["ReceiveQty"]) + Convert.ToInt32(txtOrderRecQty.Text);
                                         _isInserted = objm.UpdateInOutMaterialClinicReceive(Convert.ToInt32(ID.Text), RtTotal);
                                    }
                                   

                                    DataTable  Sid = objm.GetmaterialstocRecvered(Convert.ToInt32(lblMaterialId.Text));

                                    if (Sid != null && Sid.Rows .Count > 0)
                                       {
                                          
                                           int StTotal = Convert.ToInt32(Sid.Rows[0]["TotalMaterial"]) + Convert.ToInt32(txtOrderRecQty.Text);
                                           int a = objm.AddmaterialstocReceive(0, Convert.ToInt32(lblMaterialId.Text), StTotal);
                                       }
                                    else
                                       {

                                           int a = objm.AddmaterialstocReceive(1, Convert.ToInt32(lblMaterialId.Text), Convert.ToInt32(txtOrderRecQty.Text));
                                       }

                                }
                            }



                            SelectedItems++;

                        }
                    }
                }



                if (_isInserted == -1)
                {
                     lblMessage.Text = "Failed to Add  Material Received Order ";
                     lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                      lblMessage.Text = " Material Received Order Added Successfully";
                     lblMessage.ForeColor = System.Drawing.Color.Green;
                    // Response.Redirect("ReceiveMaterialbyClinic.aspx");
                  
                    getAllinoutmaterial();
                }
                      
            }
            catch (Exception ex)
            {
            }
        }
        protected void btnIOCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReceiveMaterialbyClinic.aspx");
          
            Edit.Visible = true;
            getAllinoutmaterial();
        }

        protected void ddlClinic_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindDocter(Convert.ToInt32(ddlClinic.SelectedValue));
        }

        protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                //TextBox txtOrderQty = (TextBox)e.Row.FindControl("lblOrderQty");



                Label InoutID = (Label)e.Row.FindControl("LabelMaterialId");
                Label lblPending = (Label)e.Row.FindControl("lblPending");
                Label lblOrderQty = (Label)e.Row.FindControl("lblOrderQty");

                int RecQty = objm.GetMaterialOderRecvered(Convert.ToInt32(InoutID.Text));


                lblPending.Text = (Convert.ToInt32(lblOrderQty.Text) - RecQty).ToString ();
            }   
        }
    }
}