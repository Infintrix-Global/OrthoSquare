<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnquirySource.aspx.cs" Inherits="OrthoSquare.Enquiry1.EnquirySource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 204px;
        }
        .auto-style2 {
            width: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style2">Name</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" /></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
           
        </table>
    </div>
    </form>
</body>
</html>
