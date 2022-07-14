<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="PaymentModeClinicReport.aspx.cs" Inherits="OrthoSquare.Report.PaymentModeClinicReport" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= ResolveUrl("~/JS1/jquery.min.js") %>"></script>

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
                                <span>Payment Collection Report</span>
                            </li>
                        </ul>

                    </div>
                    <div class="row">
                        <div class="col-md-12 pad">
                            <div class="portlet light portlet-fit portlet-form bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-settings font-red"></i>
                                        <span class="caption-subject font-red sbold uppercase">Payment Collection Report</span>
                                    </div>

                                </div>
                                <div class="portlet-body">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">

                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Clinic Name 
                                                    </label>
                                                    <asp:DropDownList ID="ddlClinic" class="form-control" runat="server"></asp:DropDownList>


                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Doctor Name
                                                    </label>


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
                                                    <label for="form_control_1">
                                                        Year
                                                    </label>
                                                    <asp:DropDownList ID="ddlYear" class="form-control" AutoPostBack="true" runat="server">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        Month
                                                    </label>
                                                    <asp:DropDownList ID="ddlMonths" class="form-control" AutoPostBack="true" runat="server">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        From Date
                                                    </label>

                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control" placeholder="From Date"
                                                        ClientIDMode="Static"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server"
                                                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                    </asp:CalendarExtender>


                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="form_control_1">
                                                        To Date
                                                    </label>

                                                    <asp:TextBox ID="txtToDate" runat="server" class="form-control" placeholder="To Date"
                                                        ClientIDMode="Static"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                        Enabled="True" TargetControlID="txtToDate">
                                                    </asp:CalendarExtender>


                                                </div>
                                            </div>

                                            <div class="col-md-3" style="margin-top: 25px;">
                                                <div class="form-group">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                                        CausesValidation="False" OnClick="btnSearch_Click" />

                                                </div>
                                            </div>
                                        </div>


                                        <div class="text-right mb-20">
                                            Total :
                                            <asp:Label ID="lblTotalTop" runat="server" Text=""></asp:Label>
                                        </div>

                                        <div class="table-scrollable">

                                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" PageSize="31"
                                                class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound">


                                                <Columns>


                                                    <asp:TemplateField HeaderText="Month">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMonthPay" Visible="false" runat="server" Text='<%# Eval("MonthPay") %>'></asp:Label>
                                                            <asp:Label ID="lblMonthNo" runat="server" Visible="false" Text='<%# Eval("MonthNo") %>'></asp:Label>

                                                            <asp:HyperLink ID="HyperLink1" Class="d1" Text='<%# Eval("MonthPay") %>' runat="server"></asp:HyperLink>
                                                            <%-- <img alt="" style="cursor: pointer" src="../Images/plus.png" runat="server" id="img" />--%>


                                                            <asp:Panel ID="Panel1" runat="server" Style="display: none">
                                                                <asp:GridView ID="gvPaymonthDay" runat="server" AutoGenerateColumns="false" PageSize="31"
                                                                    class="table table-bordered table-hover" OnRowDataBound="gvPaymonthDay_RowDataBound">


                                                                    <Columns>


                                                                        <asp:TemplateField HeaderText="Clinic Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDay" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>


                                                                            </ItemTemplate>


                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Cash">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCash" runat="server" Text='<%# Eval("Cash")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Cheque">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCheque" runat="server" Text='<%# Eval("Cheque")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Debit Card">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDebitCard" runat="server" Text='<%# Eval("Debit Card")%>'></asp:Label>

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Credit Card">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCreditCard" runat="server" Text='<%# Eval("Credit Card")%>'></asp:Label>
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="UPI">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUPI" runat="server" Text='<%# Eval("UPI")%>'></asp:Label>
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bajaj finance">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblBajajfinance" runat="server" Text='<%# Eval("Bajaj finance") %>'></asp:Label>
                                                                            </ItemTemplate>


                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Kotak finance">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblKotakfinance" runat="server" Text='<%# Eval("Kotak finance") %>'></asp:Label>
                                                                            </ItemTemplate>


                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Liqui Loans">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblLiquiLoans" runat="server" Text='<%# Eval("Liqui Loans") %>'></asp:Label>
                                                                            </ItemTemplate>


                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false" HeaderText="IDFC First Bank">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblIDFCFirstBank" runat="server" Text='<%# Eval("IDFC First Bank") %>'></asp:Label>
                                                                            </ItemTemplate>


                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Shopse">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblShopse" runat="server" Text='<%# Eval("Shopse") %>'></asp:Label>
                                                                            </ItemTemplate>


                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Shopse Debit Card">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblShopsePreapproved" runat="server" Text='<%# Eval("Shopse - Preapproved Debit Card + Cardless EMI") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Shopse HDFC & Citi">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblShopseHDFC" runat="server" Text='<%# Eval("Shopse- Credid Card No Cost HDFC & Citi") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Shopse Credit Card">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblShopseCreditCard" runat="server" Text='<%# Eval("Shopse- Credit Card Bank") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>



                                                                        <asp:TemplateField HeaderText="Shopse- Amex">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblShopseAmex" runat="server" Text='<%# Eval("Shopse- Amex") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="NEFT">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblNEFT" runat="server" Text='<%# Eval("NEFT") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Total">
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
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
                                                        </ItemTemplate>


                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cash">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCash1" runat="server" Text='<%# Eval("Cash")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cheque">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCheque1" runat="server" Text='<%# Eval("Cheque")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Debit Card">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDebitCard1" runat="server" Text='<%# Eval("Debit Card")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Credit Card">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCreditCard1" runat="server" Text='<%# Eval("Credit Card")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="UPI">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUPI1" runat="server" Text='<%# Eval("UPI")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bajaj finance">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblBajajfinance1" runat="server" Text='<%# Eval("Bajaj finance") %>'></asp:Label>
                                                        </ItemTemplate>


                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Kotak finance">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblKotakfinance1" runat="server" Text='<%# Eval("Kotak finance") %>'></asp:Label>
                                                        </ItemTemplate>


                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Liqui Loans">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblLiquiLoans1" runat="server" Text='<%# Eval("Liqui Loans") %>'></asp:Label>
                                                        </ItemTemplate>


                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false" HeaderText="IDFC First Bank">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblIDFCFirstBank1" runat="server" Text='<%# Eval("IDFC First Bank") %>'></asp:Label>
                                                        </ItemTemplate>


                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Shopse">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblShopse1" runat="server" Text='<%# Eval("Shopse") %>'></asp:Label>
                                                        </ItemTemplate>


                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Shopse Debit Card">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblShopsePreapproved1" runat="server" Text='<%# Eval("Shopse - Preapproved Debit Card + Cardless EMI") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Shopse HDFC & Citi">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblShopseHDFC1" runat="server" Text='<%# Eval("Shopse- Credid Card No Cost HDFC & Citi") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Shopse Credit Card">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblShopseCreditCard1" runat="server" Text='<%# Eval("Shopse- Credit Card Bank") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Shopse- Amex">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblShopseAmex1" runat="server" Text='<%# Eval("Shopse- Amex") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="NEFT">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblNEFT1" runat="server" Text='<%# Eval("NEFT") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="Total">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblTotal1" runat="server" Text=""></asp:Label>
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


       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
<script type="text/javascript">
    $("[src*=plus]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "<%= ResolveUrl("~/Images/minus.png") %>");
        });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "<%= ResolveUrl("~/Images/plus.png") %>");
            $(this).closest("tr").next().remove();
        });
</script>


    <script type="text/javascript">
        $(".d1").on("click", function () {
            debugger
            if ($(this).hasClass('d2')) {
                $(this).closest("tr").next().remove();
                $(this).removeClass('d2');
            } else {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                $(this).addClass("d2");
            }


        });

    </script>
</asp:Content>
