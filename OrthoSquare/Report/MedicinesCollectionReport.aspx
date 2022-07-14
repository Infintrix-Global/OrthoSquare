<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="MedicinesCollectionReport.aspx.cs" Inherits="OrthoSquare.Report.MedicinesCollectionReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <asp:Panel ID="Edit" runat="server">
                <div id="Div1" runat="server" class="page-content">
                    <div class="page-bar">
                        <ul class="page-breadcrumb">
                            <li>
                                <i class="icon-home"></i>
                                <a href="index-2.html">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                            <li>
                                <span>Medicines collection Report</span>
                            </li>
                        </ul>

                    </div>
                    <div class="row">
                        <div class="col-md-12 pad">
                            <div class="portlet light portlet-fit portlet-form bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-settings font-red"></i>
                                        <span class="caption-subject font-red sbold uppercase">Medicines Collection Report</span>
                                    </div>

                                </div>
                                <div class="portlet-body">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged" runat="server"></asp:DropDownList>


                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <asp:DropDownList ID="ddlDocter" Visible="false" class="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>


                                                    <asp:TextBox ID="txtDocter" runat="server" OnTextChanged="txtDocter_TextChanged" placeholder="Doctor Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                                    <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                                        MinimumPrefixLength="2"
                                                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                        TargetControlID="txtDocter"
                                                        ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                                    </cc1:AutoCompleteExtender>


                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <asp:TextBox ID="txtSFromFollowDate" runat="server" class="form-control" placeholder="From Date "
                                                        ClientIDMode="Static"></asp:TextBox>

                                                    <cc1:CalendarExtender ID="txtSFromFollowDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                        Enabled="True" TargetControlID="txtSFromFollowDate">
                                                    </cc1:CalendarExtender>

                                                    <span class="help-block"></span>

                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <asp:TextBox ID="txtSToFollowDate" runat="server" class="form-control" placeholder="To Date"
                                                        ClientIDMode="Static"></asp:TextBox>

                                                    <cc1:CalendarExtender ID="txtSToFollowDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                        Enabled="True" TargetControlID="txtSToFollowDate">
                                                    </cc1:CalendarExtender>

                                                    <span class="help-block"></span>

                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <asp:TextBox ID="txtMedicines" runat="server" OnTextChanged="txtMedicines_TextChanged" placeholder="Medicines Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                                    <cc1:AutoCompleteExtender ServiceMethod="SearchMedicines"
                                                        MinimumPrefixLength="2"
                                                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                        TargetControlID="txtMedicines"
                                                        ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false">
                                                    </cc1:AutoCompleteExtender>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                                        CausesValidation="False" OnClick="btnSearch_Click" />
                                                </div>
                                            </div>

                                        </div>
                                        <br />

                                        <div class="row">

                                            <div class="text-right mb-20">
                                                Total :
                                            <asp:Label ID="lblTotaCount" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="table-scrollable">

                                                <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false" ShowFooter="true"
                                                    class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound"
                                                    OnPageIndexChanging="gvShow_PageIndexChanging">

                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Clinic Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Doctor Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDoctorName" runat="server" Text='<%# Eval("DoctorName") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                        


                                                        <asp:TemplateField HeaderText="Medicines Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMedicines" runat="server" Text='<%# Eval("MedicinesName") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Price">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Qty">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Total Discount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalDiscount" runat="server" Text='<%# Eval("TotalDiscount") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Total Collection">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGrandTotal" runat="server" Text='<%# Eval("GrandTotal") %>'></asp:Label>
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


                                            <div class="text-left mb-20">
                                                <asp:ImageButton ID="btExcel" runat="server" Height="40px"
                                                    ImageUrl="~/Images/excel-icon.png" Text="Download" ToolTip="Download" Width="40px"
                                                    OnClick="btExcel_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <!-- / .panel -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
  <%--      </ContentTemplate>
    </asp:UpdatePanel>--%>


</asp:Content>
