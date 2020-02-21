using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Drawing;
using System.IO;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace PreconFinal.Utility
{
    public static class Common
    {
        public enum StudentEntryFrom
        {
            SeminarRegistration,
            VisitorRegistration,
            StudentRegistration,
        }

        public enum Mode
        {
            NewEnquiry,
            NewFollowupEnquiry,
            VisitorEnquiry,
            VisitorFollowupEnquiry,
            GeneralEnquiry

        }

        public static DateTime DateFormatChange(string date)
        {
            try
            {
                if (date != "")
                {
                    string Seprator = "";
                    string DTSeprator = "";
                    if (date.Contains("/"))
                    {
                        DTSeprator = "dd/MM/yyyy";
                        Seprator = "/";
                    }
                    else if (date.Contains("-"))
                    {
                        DTSeprator = "dd-MM-yyyy";
                        Seprator = "-";
                    }
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = DTSeprator;
                    dtfi.DateSeparator = Seprator;
                    string startdate = date;
                    return Convert.ToDateTime(startdate, dtfi);

                }
                else
                {
                    return Convert.ToDateTime("01-01-1900");
                }
            }
            catch (Exception ex)
            {
                return Convert.ToDateTime("01-01-1900");
            }
        }

        public static string CheckNullandEmpty(object obj)
        {
            if (obj != null && obj.ToString().ToLower() != "null" && obj != System.DBNull.Value)
                return obj.ToString();
            else
                return "";
        }

        public static string RemoveSpecialChars(string CheckString)
        {
            string[] chars = new string[] { "'", ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (CheckString.Contains(chars[i]))
                    CheckString = CheckString.Replace(chars[i].ToString(), "");
            }

            return CheckString;
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        //public static DataTable GetGroupingRecords(DataTable dtData)
        //{

        //}

        public static DataTable ToADOTable<T>(this IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            // Use reflection to get property names, to create table
            // column names
            PropertyInfo[] oProps = typeof(T).GetProperties();
            foreach (PropertyInfo pi in oProps)
            {
                Type colType = pi.PropertyType;
                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    colType = colType.GetGenericArguments()[0];
                dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
            }
            foreach (T rec in varlist)
            {
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                dtReturn.Rows.Add(dr);
            }

            return (dtReturn);
        }

        public static DataTable ConvertToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static string GenerateUniqueStudentPassword()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            string sPwd = string.Format("{0:x}", i - DateTime.Now.Ticks);
            return sPwd.Substring(0, 6);
        }

        public static string GenerateUniqueStudentUserID()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            String finalString = new String(stringChars);
            return finalString;
        }

        public static Guid GenerateNewGUID()
        {
            return Guid.NewGuid();
        }

        public static int CheckNullandEmpty_Int(object obj)
        {
            if (obj != null && obj.ToString().ToLower() != "null" && obj != System.DBNull.Value)
                return Convert.ToInt32(obj.ToString());
            else
                return 0;
        }
    }
}