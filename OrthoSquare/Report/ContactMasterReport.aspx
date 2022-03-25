<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ContactMasterReport.aspx.cs" Inherits="OrthoSquare.Report.ContactMasterReport" %>
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
                    <span>CONTACT DETAILS</span>
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
                            <span class="caption-subject font-red sbold uppercase">CONTACT DETAILS</span>
                        </div>
                        
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-6">
                               <div class="form-group">
                                                
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
                        

                          
                       <div class="text-right mb-20">
                               
                                 </div>
                        <div class="table-scrollable">
                             
                            <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover"
                                    ShowHeaderWhenEmpty="true" AllowPaging="true" GridLines="None"  AutoGenerateColumns="false"  
                                    OnPageIndexChanging="gvShow_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField  HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("VendorID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField  HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="Mobile No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
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
