using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Table;



public class GridViewExportUtil
{
    public static void Export(string fileName, GridView gv)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
        "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a form to contain the grid
                Table table = new Table();

                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    GridViewExportUtil.PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    //Export Gridview Data to Excel File and Save Excel file to Server Folder Rather than
    //allowing user to Open or Save it.
    public static void ExportToFolder(string fileName, GridView gv)
    {

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        using (StringWriter sw = new StringWriter(sb))
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a form to contain the grid
                Table table = new Table();

                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    GridViewExportUtil.PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //Create file
                System.IO.TextWriter w = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~") + "\\" + fileName);
                w.Write(sb.ToString());
                w.Flush();
                w.Close();

            }
        }
    }

    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                GridViewExportUtil.PrepareControlForExport(current);
            }
        }
    }

    public static void ExportToExcelFromDataTable(string sFileName, DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            string filename = sFileName + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dt;
            dgGrid.DataBind();

            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            //Response.ContentType = application/vnd.ms-excel;
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            //this.EnableViewState = false;
            HttpContext.Current.Response.Write(tw.ToString());
            //table.Caption = "Header Text";
            //table.CaptionAlign = TableCaptionAlign.Top;
            HttpContext.Current.Response.End();
        }
    }

    public static  bool ExportToExcelManual(string Filename, List<ExcelRows> Columns, DataTable ExportData1, DataTable ExportData2)
    {

        try
        {
            if (ExportData1 != null && ExportData1.Rows.Count > 0)
            {
                string strExcelName = Filename;
                if (Filename.ToLower().Contains("xls") == false)
                    strExcelName = Filename + ".xlsx";

                string FolderPath = HttpContext.Current.Server.MapPath("~/temp");
               string ExcelPath = FolderPath + "\\" + strExcelName;

                //Delete existing file with same file name.
                if (File.Exists(ExcelPath))
                    File.Delete(ExcelPath);

                var newFile = new FileInfo(ExcelPath);

                //Step 1 : Create object of ExcelPackage class and pass file path to constructor.
                using (var package = new ExcelPackage(newFile))
                {
                    //Step 2 : Add a new worksheet to ExcelPackage object and give a suitable name
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(strExcelName);
                    //  worksheet.Cells.AutoFilter = false;
                    if (Columns != null && Columns.Count > 0)
                    {

                        for (int i = 0; i < Columns.Count; i++)
                        {
                            string cellheadername = "A" + (i + 1).ToString();
                            string cellvaluename = "B" + (i + 1).ToString();
                            worksheet.SetValue(cellheadername, Columns[i].ColumnHeaderName);
                            worksheet.SetValue(cellvaluename, Columns[i].ColumnValue);
                        }
                    }

                    //Step 3 : Start loading datatable form A1 cell of worksheet.
                    // First Data table export
                    string datatablecellname = "A";
                    if (Columns != null && Columns.Count > 0)
                        datatablecellname = "A" + (Columns.Count + 2).ToString();
                    else
                        datatablecellname = "A1";
                    worksheet.Cells[datatablecellname].LoadFromDataTable(ExportData1, true, TableStyles.None);


                    // secondData table export

                    if (ExportData2 != null && ExportData2.Rows.Count > 0)
                    {
                        datatablecellname = "A";
                        int rowscounts = 0;
                        if (ExportData1 != null && ExportData1.Rows.Count > 0)
                        {
                            if (Columns != null && Columns.Count > 0)
                                rowscounts = Columns.Count;
                            rowscounts = rowscounts + ExportData1.Rows.Count + 4;
                            datatablecellname = "A" + rowscounts.ToString();
                        }
                        else
                            datatablecellname = "A1";
                        worksheet.Cells[datatablecellname].LoadFromDataTable(ExportData2, true, TableStyles.None);
                    }

                    //worksheet.Cells.AutoFilter = false;
                    //Step 5 : Save all changes to ExcelPackage object which will create Excel 2007 file.
                    package.Save();

                    if (ExportData1 != null && ExportData1.Rows.Count > 0)
                    {
                        FolderPath = HttpContext.Current.Server.MapPath("~/temp");
                        ExcelPath = FolderPath + "\\" + strExcelName;

                        if (System.IO.File.Exists(ExcelPath))
                        {
                            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                            response.ClearContent();
                            response.Clear();
                            response.ContentType = "text/plain";
                            response.AddHeader("Content-Disposition", "attachment; filename=" + strExcelName + "");
                            response.TransmitFile(ExcelPath);
                            response.Flush();
                            response.End();
                        }
                    }

                }
                // return true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
            return false;
        }        
        return true;
    }

}

public class ExcelRows
{
    public string ColumnHeaderName
    {
        get;
        set;
    }
    public string ColumnValue
    {
        get;
        set;
    }
}