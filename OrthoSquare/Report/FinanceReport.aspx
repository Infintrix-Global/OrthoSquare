<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="FinanceReport.aspx.cs" Inherits="OrthoSquare.Report.FinanceReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                <span>Finance Report</span>
                            </li>
                        </ul>

                    </div>
                    <div class="row">
                        <div class="col-md-12 pad">
                            <div class="portlet light portlet-fit portlet-form bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-settings font-red"></i>
                                        <span class="caption-subject font-red sbold uppercase">Finance Report</span>
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


                                                    <asp:TextBox ID="txtDocter" runat="server" OnTextChanged="txtDocter_TextChanged"  placeholder="Doctor Name" AutoPostBack="true"  class="form-control"></asp:TextBox>

                                                    <cc1:autocompleteextender servicemethod="SearchCustomers"
                                                        minimumprefixlength="2"
                                                        completioninterval="100" enablecaching="false" completionsetcount="10"
                                                        targetcontrolid="txtDocter"
                                                        id="AutoCompleteExtender1" runat="server" firstrowselected="false">
                                                    </cc1:autocompleteextender>


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
                                                    
                                                    <asp:DropDownList ID="ddlFinance" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFinance_SelectedIndexChanged" runat="server"></asp:DropDownList>


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
                                            


                                            <div class="table-scrollable">

                                                <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false" ShowFooter="true"
                                                    class="table table-bordered table-hover" 
                                                    OnPageIndexChanging="gvShow_PageIndexChanging">

                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Invoice No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInvoiceCode" runat="server" Text='<%# Eval("InvoiceCode") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Patient Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPatientName" runat="server" Text='<%# Eval("PatientName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                          
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Finance Mode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaymentMode" runat="server" Text='<%# Eval("PaymentMode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                          
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Approval Amount">
                                                            <ItemTemplate>
                                                                 <asp:Label ID="lblApprovalAmount" runat="server" Text='<%# Eval("ApprovalAmount","{0:N2}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                           
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Interest Rate Amount">
                                                            <ItemTemplate>
                                                                 <asp:Label ID="lblInterestRate" runat="server" Text='<%# Eval("InterestRateAmount" ,"{0:N2}") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Total Approval Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalApprovalAmount" runat="server" Text='<%# Eval("TotalApprovalAmount","{0:N2}") %>'></asp:Label>
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
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
