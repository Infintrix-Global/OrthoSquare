<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="UserAccess.aspx.cs" Inherits="OrthoSquare.Master.UserAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
    <script type="text/javascript" language="javascript">
        function SelectAllCheckboxes11(spanChk) {

            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].id.indexOf("chkSelectMenuId") != -1) {
                        if (elm[i].checked != xState)
                            elm[i].click();
                    }


                }
            }
        }
    </script>



    <script type="text/javascript" language="javascript">
        function SelectAllCheckboxesEmp(spanChk) {

            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].id.indexOf("chkCtrl") != -1) {
                        if (elm[i].checked != xState)
                            elm[i].click();
                    }


                }
            }
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Edit" runat="server" class="page-content">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>User Access</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                            <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                        </div>
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-settings font-red"></i>
                            <span class="caption-subject font-red sbold uppercase">User Access</span>
                        </div>
                        <%--<div class="actions">
                            <div class="btn-group btn-group-devided" data-toggle="buttons">
                                <label class="btn grey-salsa btn-sm active">
                                    <input type="radio" name="options" class="toggle" id="option1">Actions</label>
                                <label class="btn grey-salsa btn-sm">
                                    <input type="radio" name="options" class="toggle" id="option2">Settings</label>
                            </div>
                        </div>--%>
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-6">
                               <div class="form-group">
                                   <asp:DropDownList ID="ddlRole" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged"></asp:DropDownList>
                                  
                                </div>
                            </div>
                            </div>
                        

                          
                        <div class="table-scrollable">
                             <asp:Panel ID="PanelMenu" runat="server" Visible="false" >
                    <asp:GridView ID="GrdMenu" runat="server" AutoGenerateColumns="False"  class="table table-bordered table-hover"
                    Width="200px" onrowdatabound="GrdMenu_RowDataBound" >
                        <Columns >
                            <asp:TemplateField  >
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:SelectAllCheckboxes11(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelectMenuId" runat="server"  />
                                <%--  <asp:HiddenField ID="hidMenuID" runat="server" Value='<%# Bind("MenuID") %>' />--%>
                                    <asp:Label ID="LabelParentMenuID" runat="server" Visible="false" Text='<%# Bind("MenuID") %>'></asp:Label>
                                 <%--   <asp:Label ID="lblorderno" runat="server" Visible="false" Text='<%# Bind("orderno") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns  >
                            <asp:TemplateField>
                                <HeaderTemplate  >
                                 Menu Name:
                                    <asp:DropDownList ID="ddlParent" runat="server"   OnSelectedIndexChanged = "MenuChanged" 
                                AutoPostBack = "true"
                                AppendDataBoundItems = "true">
                                         <asp:ListItem Text = "ALL" Value = "ParentId"></asp:ListItem>
                                         
                                    </asp:DropDownList>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# Eval("MenuName")%>
                                     
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%--  <asp:BoundField DataField="MenuName" HeaderText="MenuName" />--%>
                        </Columns>
                    </asp:GridView>

                    <div>
                     
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                           
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" class="btn blue" onclick="btnSave_Click" Text="Save" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                           
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                           
                        </table>
                    </div>

                </asp:Panel>
                            
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
