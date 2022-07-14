<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ClinicStockReport.aspx.cs" Inherits="OrthoSquare.Material.ClinicStockReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" id="Add" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Clinic Stock</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->




        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase"><span>Clinic Stock</span>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">

                                <asp:DropDownList ID="ddlMaterialType" class="form-control" runat="server"></asp:DropDownList>



                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">

                                <asp:TextBox ID="txtMaterial" runat="server" class="form-control" placeholder="Material"
                                    ClientIDMode="Static"></asp:TextBox>

                                <cc1:autocompleteextender servicemethod="SearchMaterial"
                                    minimumprefixlength="2"
                                    completioninterval="100" enablecaching="false" completionsetcount="10"
                                    targetcontrolid="txtMaterial"
                                    id="AutoCompleteExtender1" runat="server" firstrowselected="false">
                                </cc1:autocompleteextender>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                    CausesValidation="False" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="table-responsive">
                        <asp:GridView ID="Gridplaceorder" runat="server" AutoGenerateColumns="false"
                            class="table table-striped table-bordered table-hover" DataKeyNames="MaterialId" OnRowDataBound="Gridplaceorder_RowDataBound"
                            GridLines="None"
                            ShowHeaderWhenEmpty="true">

                            <Columns>


                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <asp:Label ID="SrNo1" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inventory Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialType" runat="server" Text='<%# Eval("MaterialType") %>'></asp:Label>

                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>


                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Brand Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBrandname1" runat="server" Text='<%# Eval("BrandName") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Packaging">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUUnit" runat="server" Text='<%# Eval("PackName") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Current Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCurrentStock" runat="server" Text='<%# Eval("CurrentStock") %>'></asp:Label>

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
</asp:Content>
