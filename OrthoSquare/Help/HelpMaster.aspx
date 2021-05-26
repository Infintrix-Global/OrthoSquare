<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="HelpMaster.aspx.cs" Inherits="OrthoSquare.Help.HelpMaster" %>
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
                    <span>Help</span>
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
                            <span class="caption-subject font-red sbold uppercase">Help</span>
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
                                                <label>Search</label>
                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                        ClientIDMode="Static"></asp:TextBox>
                                  
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group form-md-line-input ">
                                   <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                            OnClick="btSearch_Click" />
                                        
                                </div>
                            </div>
                            </div>
                        

                            <!-- Usage as a class -->
                       
                        <div class="table-scrollable">
                             
                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" DataKeyNames="VID"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                               ShowHeaderWhenEmpty="true" >
                                <Columns>
                                      
                                    <asp:TemplateField HeaderText="Sr. No." >
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("VID")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblLabname" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                    <asp:TemplateField HeaderText="Link" >
                                        <ItemTemplate>
                                           
                                           <%-- <asp:LinkButton ID="LinkButton1" CommandName="EditAd"   NavigateUrl='<%# Bind("LinkPath") %>' CommandArgument='<%# Eval("VID")%>' Text='<%# Eval("LinkPath")%>' runat ="server"></asp:LinkButton>
                                        --%>
                                        <asp:HyperLink ID="hlnkFileAttachment" runat="server" Target=_blank 
                                             Text='<%# Eval("LinkPath") %>'
                                          NavigateUrl='<%# Bind("LinkPath") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                  
                                </Columns>
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
