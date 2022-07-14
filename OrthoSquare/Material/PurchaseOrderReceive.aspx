<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderReceive.aspx.cs" Inherits="OrthoSquare.Material.PurchaseOrderReceive" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panellist" runat="server">
        <div id="Div1" runat="server" class="page-content">
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="icon-home"></i>
                        <a href="index-2.html">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <span>View Purchase Order</span>
                    </li>
                </ul>

            </div>
            <div class="row">
                <div class="col-md-12 pad">
                    <div class="portlet light portlet-fit portlet-form bordered">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-red"></i>
                                <span class="caption-subject font-red sbold uppercase">View Purchase Order</span>
                            </div>

                        </div>
                        <div class="portlet-body">
                            <!-- BEGIN FORM-->
                            <div class="form-body">

                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Vendor Name 
                                            </label>

                                            <asp:TextBox ID="txtVendor" runat="server" OnTextChanged="txtVendor_TextChanged" placeholder="Vendor Name " AutoPostBack="true" class="form-control"></asp:TextBox>

                                            <cc1:AutoCompleteExtender ServiceMethod="SearchVendorName"
                                                MinimumPrefixLength="2"
                                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                TargetControlID="txtVendor"
                                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                            </cc1:AutoCompleteExtender>

                                        </div>
                                    </div>



                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Order No 
                                            </label>

                                            <asp:TextBox ID="txtOrderNo" runat="server" OnTextChanged="txtOrderNo_TextChanged" placeholder="Vendor Name " AutoPostBack="true" class="form-control"></asp:TextBox>

                                            <cc1:AutoCompleteExtender ServiceMethod="SearchOrderNo"
                                                MinimumPrefixLength="2"
                                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                TargetControlID="txtOrderNo"
                                                ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false">
                                            </cc1:AutoCompleteExtender>

                                        </div>
                                    </div>


                                    <div class="col-md-3" style="margin-top: 25px;">
                                        <div class="form-group">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static" OnClick="btnSearch_Click"
                                                CausesValidation="False" />

                                        </div>
                                    </div>
                                </div>



                                <div class="text-right mb-20">
                                    Total :
                                            <asp:Label ID="lblTotalTop" runat="server" Text=""></asp:Label>
                                </div>

                                <div class="table-scrollable">

                                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" DataKeyNames="PurchaseOrderId,OrderCode,OrderDate"
                                        PageSize="31" OnRowCommand="gvShow_RowCommand"
                                        class="table table-bordered table-hover">


                                        <Columns>


                                            <asp:TemplateField HeaderText="Sr. No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo11" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Order No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPurchaseOrderId" Visible="false" runat="server" Text='<%# Eval("PurchaseOrderId")%>'></asp:Label>

                                                    <asp:Label ID="lblOrderCode" runat="server" Text='<%# Eval("OrderCode")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Vendor Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                               <asp:TemplateField HeaderText="Order Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderStatus" runat="server" Text='<%# Eval("OrderStatus")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Order Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("OrderDate","{0:dd/MMM/yyyy}")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField>
                                                <ItemTemplate>


                                                    <asp:Button ID="btnview" CommandName="Receive" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' class="btn blue-madison" runat="server" Text="Receive" />


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
                        <!-- / .panel -->
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>



    <asp:Panel ID="PanelAdd" Visible="false" runat="server">
        <div id="Div2" runat="server" class="page-content">
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="icon-home"></i>
                        <a href="index-2.html">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <span>Assign Material</span>
                    </li>
                </ul>

            </div>
            <div class="row">
                <div class="col-md-12 pad">
                    <div class="portlet light portlet-fit portlet-form bordered">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-red"></i>
                                <span class="caption-subject font-red sbold uppercase">Receive  Material</span>
                            </div>

                        </div>
                        <div class="portlet-body">
                            <!-- BEGIN FORM-->
                            <div class="form-body">

                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                               Order No
                                            </label>
                                            <asp:TextBox ID="txtOrder_No" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                         

                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Order Date
                                            </label>
                                            <asp:TextBox ID="txtROderDate" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>



                                        </div>
                                    </div>


                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Date
                                            </label>


                                            <asp:TextBox ID="txtDate" runat="server" placeholder="Material Name" class="form-control"></asp:TextBox>

                                            <asp:CalendarExtender ID="txtBDate_CalendarExtender" runat="server" Enabled="True" OnClientDateSelectionChanged="checkDate1"
                                                TargetControlID="txtDate" Format="dd-MM-yyyy">
                                            </asp:CalendarExtender>
                                        </div>
                                    </div>

                                </div>

                                <br />

                                <div class="table-scrollable">

                                    <asp:GridView ID="gvAssignMaterial" runat="server" AutoGenerateColumns="false" PageSize="31" OnRowDataBound="gvAssignMaterial_RowDataBound"
                                        class="table table-bordered table-hover">

                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr. No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo1" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                      <asp:Label ID="lblPurchaseOrderId" Visible="false" runat="server" Text='<%# Eval("PurchaseOrderId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Inventory Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMaterialNameType" runat="server" Text='<%# Eval("MaterialNameType") %>'></asp:Label>
                                                    <asp:Label ID="lblMaterialTypeId" Visible="false" runat="server" Text='<%# Eval("MaterialTypeId") %>'></asp:Label>
                                                </ItemTemplate>


                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Item Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("MaterialName")%>'></asp:Label>
                                                    <asp:Label ID="lblMaterialId" Visible="false" runat="server" Text='<%# Eval("MaterialId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Packaging">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPackName" runat="server" Text='<%# Eval("PackName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Request Stock">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClinicQty" runat="server" Text='<%# Eval("Qty")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Receive Stock">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAssign" Width="80px" class="form-control minInp" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPrice" Width="80px" class="form-control minInp" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                          
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>

                                                    <asp:TextBox ID="txtRemark" class="form-control" Text="" runat="server"></asp:TextBox>


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

                                <div class="row">
                                    <div class="form-actions text-center">

                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn blue" ValidationGroup="e" OnClick="btnSubmit_Click"  />

                                        <asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"  OnClick="btBack_Click"
                                            CausesValidation="False" />


                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- / .panel -->
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>


</asp:Content>
