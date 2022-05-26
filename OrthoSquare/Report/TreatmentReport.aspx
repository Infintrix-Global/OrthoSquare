<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="TreatmentReport.aspx.cs" Inherits="OrthoSquare.Report.TreatmentReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                <span>Treatments Collection Report</span>
                            </li>
                        </ul>

                    </div>
                    <div class="row">
                        <div class="col-md-12 pad">
                            <div class="portlet light portlet-fit portlet-form bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-settings font-red"></i>
                                        <span class="caption-subject font-red sbold uppercase">Treatments Collection Report</span>
                                    </div>

                                </div>
                                <div class="portlet-body">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">

                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="form-group">

                                                    <div class="col-sm-6">
                                                        <asp:RadioButtonList ID="RadioButtonListFinance" Width="100%" OnSelectedIndexChanged="RadioButtonListFinance_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" runat="server">

                                                            <asp:ListItem Text="Treatments Started" Selected="True" Value="1"></asp:ListItem>
                                                    <%--<asp:ListItem Text="Invoices Created " Selected="False" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Payments Collected" Selected="False" Value="3"></asp:ListItem>--%>
                                                        </asp:RadioButtonList>




                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged" runat="server"></asp:DropDownList>


                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">

                                            <asp:DropDownList ID="ddlTreatmentGroup" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTreatmentGroup_SelectedIndexChanged" runat="server"></asp:DropDownList>


                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">

                                                    <asp:TextBox ID="txtSFromFollowDate" runat="server" class="form-control" placeholder="From Date "
                                                        ClientIDMode="Static"></asp:TextBox>

                                                    <cc1:CalendarExtender ID="txtSFromFollowDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                        Enabled="True" TargetControlID="txtSFromFollowDate">
                                                    </cc1:CalendarExtender>

                                                    <span class="help-block"></span>

                                                </div>
                                            </div>

                                    <div class="col-md-2">
                                                <div class="form-group">

                                                    <asp:TextBox ID="txtSToFollowDate" runat="server" class="form-control" placeholder="To Date"
                                                        ClientIDMode="Static"></asp:TextBox>

                                                    <cc1:CalendarExtender ID="txtSToFollowDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                        Enabled="True" TargetControlID="txtSToFollowDate">
                                                    </cc1:CalendarExtender>

                                                    <span class="help-block"></span>

                                                </div>
                                            </div>


                                    <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                                        CausesValidation="False" OnClick="btnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>

                                        <br />


                                        <div class="row">

                                             <div class="text-right mb-20">
                                        <div class="row ">
                                            <div class="col-md-2">
                                                Total Count :
                                             <asp:Label ID="lblTotalCount" runat="server" Text="500"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                Grand Total:
                                             <asp:Label ID="lblGrandTotal" runat="server" Text="1000000"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                Total Paid :
                                             <asp:Label ID="lblPaidAmount" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-4">
                                                </div>
                                            </div>

                                    </div>

                                    <br />
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

                                                        <asp:TemplateField HeaderText="TreatmentName Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Patient Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("PatientName") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Treatment Start Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQty" runat="server" Text='<%# Eval("treatmentstartdate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Tooth No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltoothNo" runat="server" Text='<%# Eval("toothNo") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Grand Total">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGrandTotal" runat="server" Text='<%# Eval("GrandTotal") %>'></asp:Label>
                                                            </ItemTemplate>


                                                        </asp:TemplateField>


                                                <%--                                                        <asp:TemplateField HeaderText="Total Collection">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaidamount" runat="server" Text='<%# Eval("Paidamount") %>'></asp:Label>
                                                            </ItemTemplate>


                                                        </asp:TemplateField>--%>
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
                </div>
            </asp:Panel>
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
