<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="App_VersionMaster.aspx.cs" Inherits="OrthoSquare.Master.App_VersionMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <span>App Version</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">

                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-settings font-red"></i>
                            <span class="caption-subject font-red sbold uppercase">App Version</span>
                        </div>
                        
                    </div>
                    <div class="portlet-body">
                        
                        

                            <!-- Usage as a class -->
                       
                        <div class="table-scrollable">
                             
                            <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover"
                                    GridLines="None" DataKeyNames="App_VersionID" AutoGenerateColumns="false" OnRowUpdating="gvShow_RowUpdating"
                                    OnRowCancelingEdit="gvShow_RowCancelingEdit"
                                    OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true" AllowPaging="true" OnRowDataBound="gvShow_RowDataBound"
                                    >
                                    <Columns>
                                        <asp:TemplateField  HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("App_VersionID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Version Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("App_Version") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtApp_Version" class="form-control" runat="server" Text='<%# Eval("App_Version") %>' ></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Version Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApp_VCode" runat="server" Text='<%# Eval("App_VCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtApp_VCode" class="form-control" runat="server" Text='<%# Eval("App_VCode") %>' ></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField  HeaderText="Version Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblForceUpdate" runat="server" Text='<%# Eval("ForceUpdate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                               
                                            
                                                <asp:DropDownList ID="ddlForceUpdate" class="form-control" runat="server">

                                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                                    <asp:ListItem Value="0" Text ="In Active"></asp:ListItem>
                                                </asp:DropDownList >
                                            
                                            </EditItemTemplate>
                                        </asp:TemplateField>


                                        <asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="../Images/edit15x15.png"
                                            CausesValidation="False"  UpdateImageUrl="../Images/right15x15.png"
                                            CancelImageUrl="../Images/cancel15x15.png" ItemStyle-Width="5%" />
                                        
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <EmptyDataTemplate>
                                        No Record Available</EmptyDataTemplate>
                                </asp:GridView>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
