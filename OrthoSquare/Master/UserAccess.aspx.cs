using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using System.IO;
using OrthoSquare.Utility;


namespace OrthoSquare.Master
{
    public partial class UserAccess : System.Web.UI.Page
    {
        clsCommonMasters objcommon = new clsCommonMasters();
        UserMasterBLL objUser = new UserMasterBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Filter"] = "ParentId";
                BindRole();
            }
        }


        public void BindRole()
        {
            ddlRole.DataSource = objcommon.GetRoleNEW();
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataValueField = "RoleID";
            ddlRole.DataBind();

            ddlRole.Items.Insert(0, new ListItem("--- Select ---", "0"));

        }


        private void bindSelectitem(int Empid)
        {
            DataTable checkdt = objUser.RetriveRoleWiseMenu(Empid);
            ViewState["checkdt"] = checkdt;
            MenuDetials(ViewState["Filter"].ToString());
            PanelMenu.Visible = true;

        }



        public void MenuDetials(string menuNamme)
        {
            DataTable dt = objUser.RetriveMenus(menuNamme);
            int a = dt.Rows.Count;
            GrdMenu.DataSource = dt;

            // int s = GrdMenu.Rows.Count;
            GrdMenu.DataBind();



            DropDownList ddlParent =
            (DropDownList)GrdMenu.HeaderRow.FindControl("ddlParent");

            this.BindmenuList(ddlParent);

        }





        private void BindmenuList(DropDownList ddlParent)
        {


            ddlParent.DataSource = objUser.RetriveParentMenuDetails();

            ddlParent.DataTextField = "MenuName";
            ddlParent.DataValueField = "MenuID";
            ddlParent.DataBind();


            string pid = ViewState["Filter"].ToString();

            if (pid == "ParentId")
            {
                ddlParent.Items.FindByText("ALL").Selected = true;
            }
            else
            {
                string Menu_Name = objUser.RetriveParentMenuName(ViewState["Filter"].ToString());

                ddlParent.Items.FindByText(Menu_Name)
                .Selected = true;
            }

           




        }


        protected void MenuChanged(object sender, EventArgs e)
        {
            DropDownList ddlParent = (DropDownList)sender;
            ViewState["Filter"] = ddlParent.SelectedValue;
            this.MenuDetials((ViewState["Filter"]).ToString());
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindSelectitem(Convert .ToInt32(ddlRole.SelectedValue));
        }


        protected void GrdMenu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //  GridView GridView1 = (GridView)sender;
                // DataListItem dlItem = (DataListItem)GridView1.Parent;
                //DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);
                //  foreach (GridViewRow a  in GrdMenu.Rows)
                // string  row1 = GrdMenu.Rows[1].ToString();



                int i = GrdMenu.Rows.Count;
                GridViewRow myRow = e.Row;

                //foreach (GridViewRow a in GrdMenu.Rows )
                //{
                // int i = a.RowIndex;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label Menuid = (myRow.Cells[0].FindControl("LabelParentMenuID") as Label);
                    //Label Menuid = (a.Cells[0].FindControl("LabelParentMenuID") as Label);
                    int MenuID = Convert.ToInt32(Menuid.Text);
                    CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelectMenuId");
                    if (chkSelect != null)
                        chkSelect.Checked = IsMenuSelected(MenuID);
                    //else
                    //    chkSelect.Checked = false;

                }


                // }

                //int RowCount = 0;
                //for (RowCount = 0; RowCount < GrdMenu.Rows.Count; RowCount++)
                //{
                //    if (e.Row.RowType == DataControlRowType.DataRow)
                //    {
                //        Label Menuid = (item.Cells[0].FindControl("LabelParentMenuID") as Label);


                //        int MenuID = Convert.ToInt32(Menuid.Text);
                //        CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelectMenuId");
                //        if (chkSelect != null)
                //            chkSelect.Checked = IsMenuSelected(MenuID);
                //        //else
                //        //    chkSelect.Checked = false;
                //    }


                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private bool IsMenuSelected(int MenuID)
        {
            if (ViewState["checkdt"] != null)
            {

                DataTable dt = (DataTable)ViewState["checkdt"];
                DataRow[] dr = dt.Select("MenuID =" + MenuID + " ");
                if (dr != null && dr.Length > 0)
                    return true;
                else
                    return false;
            }

            return false;

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dtMenuMaster = objUser.RetriveChild_Menu(ViewState["Filter"].ToString());


                if (dtMenuMaster != null && dtMenuMaster.Rows.Count > 0)
                {
                    foreach (DataRow item in dtMenuMaster.Rows)
                    {

                        objUser.DeleteRoleMenu(Convert.ToInt32(ddlRole.SelectedValue), int.Parse(item["MenuID"].ToString()));

                    
                    }
                }
                
                
                
                
                if (dtMenuMaster != null && dtMenuMaster.Rows.Count > 0)
                {


                    int SelectedItems = 0;
                    foreach (GridViewRow item in GrdMenu.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)item.FindControl("chkSelectMenuId");
                        if (item.RowType == DataControlRowType.DataRow)
                        {
                            if (chkSelect != null && chkSelect.Checked == true)
                            {
                                Label Menuid = (item.Cells[0].FindControl("LabelParentMenuID") as Label);

                                //objUser.DeleteRoleMenu(Convert.ToInt32(EmPID.Text), int.Parse(item["MenuID"].ToString()));

                                objUser.SaveRoleMenu(Convert.ToInt32(ddlRole.SelectedValue), int.Parse(Menuid.Text));
                                SelectedItems++;

                            }
                        }
                    }

                }

                lblMessage.Text = ">User Access Rights Added Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}