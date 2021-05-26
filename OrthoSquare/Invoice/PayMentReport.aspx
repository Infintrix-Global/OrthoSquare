<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="PayMentReport.aspx.cs" Inherits="OrthoSquare.Invoice.PayMentReport" %>

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
                    <span>Payment Report</span>
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
                            <span class="caption-subject font-red sbold uppercase">Payment Report</span>
                        </div>

                    </div>
                    <div class="portlet-body">
                        <div class="row">


                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:DropDownList ID="ddlclinicSearch" OnSelectedIndexChanged="ddlclinicSearch_SelectedIndexChanged" AutoPostBack="true" class="form-control" runat="server"></asp:DropDownList>


                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:DropDownList ID="ddlDoctors" class="form-control" runat="server"></asp:DropDownList>


                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:DropDownList ID="ddlPayMode" class="form-control" runat="server">
                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                        <asp:ListItem Value="1">Cash</asp:ListItem>
                                        <asp:ListItem Value="2">Cheque</asp:ListItem>
                                        <asp:ListItem Value="3">Credit Card</asp:ListItem>
                                        <asp:ListItem Value="4">Debit Card</asp:ListItem>
                                        <asp:ListItem Value="5">Finance</asp:ListItem>
                                        <asp:ListItem Value="6">UPI</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>






                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>From Date</label>
                                    <asp:TextBox ID="txtFromPayDate" TextMode="Date" runat="server" class="form-control" placeholder="From Pay Date"
                                        ClientIDMode="Static"></asp:TextBox>

                                    <span class="help-block"></span>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>To Date</label>
                                    <asp:TextBox ID="txtToPayDate" TextMode="Date" runat="server" class="form-control" placeholder="To Pay Date"
                                        ClientIDMode="Static"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <br />
                                <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                    OnClick="btSearch_Click" />
                            </div>
                            <!-- Usage as a class -->
                            <div class="col-md-3">
                                <div class="form-group">
                                </div>
                            </div>
                        </div>


                        <!-- Usage as a class -->

                        <div class="table-scrollable">
                            <asp:Panel ID="PanelPayMode"  runat="server">
                                <asp:GridView ID="GridViewPaymode" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                    class="table table-bordered table-hover" OnRowCommand="GridViewPaymode_RowCommand"
                                    GridLines="None" OnPageIndexChanging="GridViewPaymode_PageIndexChanging" ShowHeaderWhenEmpty="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Payment Mode">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButtonPaymode" CommandArgument ='<%# Eval("PaymentMode") %>' runat="server">
                                                <asp:Label ID="lblPaymentMode" runat="server" Text='<%# Eval("PaymentMode") %>'></asp:Label>
                                                  </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GrandTotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrandTotal" runat="server" Text='<%# Eval("GrandTotal") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Cash Paid">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaidAmount" runat="server" Text='<%# Eval("PaidAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Totla Pending">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPending" runat="server" Text='<%# Eval("PendingAmount") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                    </Columns>
                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="PanelViewDetails" Visible="false" runat="server">
                                <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                    class="table table-bordered table-hover"
                                    GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" ShowHeaderWhenEmpty="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceCode" runat="server" Text='<%# Eval("InvoiceCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GrandTotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrandTotal" runat="server" Text='<%# Eval("GrandTotal") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Cash Paid">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaidAmount" runat="server" Text='<%# Eval("PaidAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Totla Pending">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPending" runat="server" Text='<%# Eval("PendingAmount") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Payment Mode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaymentMode" runat="server" Text='<%# Eval("PaymentMode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPayDate" runat="server" Text='<%# Eval("PayDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>



                                    </Columns>
                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <EmptyDataTemplate>
                                        No Record Available
                                    </EmptyDataTemplate>
                                </asp:GridView>



                                <asp:LinkButton ID="btnExcel1" class="btn btn-sm btn-outline-primary btn-round" runat="server"
                                    CausesValidation="false" OnClick="btnExcel1_Click">
                                <i class="fa fa-cloud-download"></i>
                               <span class="text">Export</span></asp:LinkButton>
                            </asp:Panel>

                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
