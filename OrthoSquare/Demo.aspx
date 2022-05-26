<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="OrthoSquare.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />

            <asp:GridView ID="GridViewInvoiceDetails" runat="server" ShowFooter="True" AutoGenerateColumns="False" 
                ForeColor="#333333"  Width="100%" class="table table-bordered table-hover">


                <Columns>
                    <asp:TemplateField HeaderText=" Sr.No">
                        <ItemTemplate>
                            <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Invoice No">
                        <ItemTemplate>
                            <asp:Label ID="lblInvoiceTid" runat="server" Text='<%# Eval("InvoiceTid")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Treatment">
                        <ItemTemplate>
                          
                            <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Eval("InvoiceNo")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>



                </Columns>


            </asp:GridView>

        </div>
    </form>
</body>
</html>
