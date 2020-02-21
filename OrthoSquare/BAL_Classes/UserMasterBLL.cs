using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace OrthoSquare.BAL_Classes
{
    public class UserMasterBLL
    {
        General objGeneral = new General();

        public string strQuery = string.Empty;
        public DataTable RetriveMenus(string MenuName)
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();


               
                    strQuery = "Select * from Menu Where IsActive=1 and ParentId=" + MenuName + "    order by MenuName ASC";
               

                return objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable RetriveParentMenuDetails()
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();

                strQuery = "Select  * from Menu  where IsActive=1 and ISNULL(ParentId,0)=0";

                return objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable RetriveRoleWiseMenu(int RoleID)
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();
                strQuery = "Select * from MenuRight where RoleID=@RoleID ";
                objGeneral.AddParameterWithValueToSQLCommand("@RoleID", RoleID);

                return objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public String RetriveParentMenuName(string PidID)
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();
                //strQuery = "Select * from Menu  inner join menuright on menuright.menuid=menu.menuid  where IsActive=1 and ISNULL(ParentId,0)=0";         
                strQuery = "Select MenuName from Menu  where IsActive=1 and ISNULL(ParentId,0)=0 and MenuID =" + PidID + "";

                return objGeneral.GetExecuteScalarByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable RetriveChild_Menu(String ParentID)
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();
                // if (Convert .ToInt32 (ParentID) > 0)
                strQuery = "Select * from Menu where IsActive=1 and ISNULL(ParentId,0)=" + ParentID + "  order by orderno ";
                // else
                //  strQuery = "Select * from Menu where IsActive=1 order by orderno ";
                return objGeneral.GetDatasetByCommand(strQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteRoleMenu(int RoleID, int MenuID)
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();
                strQuery = "Delete from MenuRight where RoleID=@RoleID and MenuID=@MenuID ";
                objGeneral.AddParameterWithValueToSQLCommand("@RoleID", RoleID);
                objGeneral.AddParameterWithValueToSQLCommand("@MenuID", MenuID);

                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool SaveRoleMenu(int RoleID, int MenuID)
        {
            try
            {
                strQuery = string.Empty;
                General objGeneral = new General();
                strQuery = "Insert into MenuRight(MenuID,RoleID,Page_Add,Page_Edit,Page_Delete,Page_View) Values('" + MenuID + "','" + RoleID + "',1,1,1,1)";
                objGeneral.GetExecuteNonQueryByCommand(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}