using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

namespace OrthoSquare.Utility
{
    public class SessionUtilities
    {
        public static string DateFormat
        {
            get { return ConfigurationManager.AppSettings["DateFormat"]; }
        }
        public static int UserID
        {
            get
            {
                if (!string.IsNullOrEmpty(GetFromSession("UserID")))
                    return Convert.ToInt32(GetFromSession("UserID"));
                else
                    return 0;
            }
            set { SetOnSession("UserID", value); }
        }


        public static int RoleID
        {
            get
            {
                if (!string.IsNullOrEmpty(GetFromSession("RoleID")))
                    return Convert.ToInt32(GetFromSession("RoleID"));
                else
                    return 0;
            }
            set { SetOnSession("RoleID", value); }
        }

        public static int Empid
        {
            get
            {
                if (!string.IsNullOrEmpty(GetFromSession("Empid")))
                    return Convert.ToInt32(GetFromSession("Empid"));
                else
                    return 0;
            }
            set { SetOnSession("Empid", value); }
        }



        private static string GetFromSession(string key)
        {
            string strRet = "";
            try
            {
                strRet = System.Web.HttpContext.Current.Session[key].ToString().Trim();
            }
            catch (Exception ex)
            {
                strRet = "";
            }
            return strRet;
        }

        private static void SetOnSession(string key, object value)
        {
            System.Web.HttpContext.Current.Session[key] = value;
        }



        public static string DateFormatted { get { return ConfigurationManager.AppSettings["DateFormat"]; } }
    }

}