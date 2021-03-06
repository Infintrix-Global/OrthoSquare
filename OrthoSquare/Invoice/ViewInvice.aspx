<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ViewInvice.aspx.cs" Inherits="OrthoSquare.Invoice.ViewInvice" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                    <span>View Invoice</span>
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
                            <span class="caption-subject font-red sbold uppercase">View Invoice</span>
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
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <div class="col-sm-3">

                                        <label>Clinic Name</label>
                                        <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged1"></asp:DropDownList>

                                        <span class="help-block"></span>
                                    </div>


                                    <div class="col-sm-3">

                                        <label>Doctor Name</label>

                                        <asp:DropDownList ID="ddlDoctor" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                        <span class="help-block"></span>

                                    </div>
                                    <div class="col-sm-3">

                                        <label>Patient Name</label>

                                        <asp:TextBox ID="txtPatientName" runat="server" OnTextChanged="txtPatientName_TextChanged" placeholder="Patient Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                        <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                            MinimumPrefixLength="2"
                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                            TargetControlID="txtPatientName"
                                            ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                        </cc1:AutoCompleteExtender>
                                    </div>
                                    <div class="col-sm-3">
                                        <label>Mobile No</label>

                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" placeholder="Mobile No"
                                            ClientIDMode="Static"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                        </div>




                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtFromEnquiryDate" runat="server" class="form-control" placeholder="From Payment Date"
                                            ClientIDMode="Static"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtFromEnquiryDate_CalendarExtender" runat="server"
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromEnquiryDate">
                                        </asp:CalendarExtender>
                                        <span class="help-block"></span>
                                    </div>


                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtToEnquiryDate" runat="server" class="form-control" placeholder="To Payment Date"
                                            ClientIDMode="Static"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtToEnquiryDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                            Enabled="True" TargetControlID="txtToEnquiryDate">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div class="col-sm-3">

                                        <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                            OnClick="btSearch_Click" />

                                    </div>
                                    <div class="col-sm-3">
                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- Usage as a class -->
                        <div class="text-right mb-20">

                            <asp:Button ID="btnAddNew" runat="server" Visible="false" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />

                        </div>
                        <br />
                        <div class="row ">
                            <div class="col-md-3">
                                Grand Total :
                                             <asp:Label ID="lblGrandTotal" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3">
                                Paid Total:
                                             <asp:Label ID="lblPaid" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3">
                                Pending Total :
                                             <asp:Label ID="lblPending" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                        <br />
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" DataKeyNames="InvoiceNo" OnRowDataBound="gvShow_RowDataBound"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("InvoiceNo") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblDownpayment" runat="server" Text='<%# Eval("Downpayment") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceCode" runat="server" Text='<%# Eval("InvoiceCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Clinic Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Patient Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPatientCode" runat="server" Text='<%# Eval("PatientCode") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Patient Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPatientName1" runat="server" Text='<%# Eval("PFristName") +"  "+ Eval("PLastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPatientName" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Doctor Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDoctor" runat="server" Text='<%# Eval("DFirstName") +"  "+ Eval("DLastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Grand Total">
                                        <ItemTemplate>

                                            <asp:Label ID="lblGrandTotal" runat="server" Text='<%# Convert.ToDecimal(Eval("GrandTotal")).ToString("N", System.Globalization.CultureInfo.GetCultureInfo("en-IN")) %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField Visible="false" HeaderText="Paid Before">
                                        <ItemTemplate>

                                            <asp:Label ID="lblPaidBefore" runat="server" Text='<%# Convert.ToDecimal(Eval("PaidBefore")).ToString("N", System.Globalization.CultureInfo.GetCultureInfo("en-IN")) %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Paid Amount">
                                        <ItemTemplate>


                                            <asp:Label ID="lblPaidAmount" runat="server" Text='<%# Convert.ToDecimal(Eval("PaidAmount")).ToString("N", System.Globalization.CultureInfo.GetCultureInfo("en-IN")) %>'></asp:Label>
                                            <asp:Label ID="lblSumPaid" runat="server" Visible="false" Text='<%# Convert.ToDecimal(Eval("SumPaid")).ToString("N", System.Globalization.CultureInfo.GetCultureInfo("en-IN")) %>'></asp:Label>



                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pending Amount">
                                        <ItemTemplate>

                                            <asp:Label ID="lblPendingAmount" runat="server" Text='<%# Convert.ToDecimal(Eval("PendingAmount")).ToString("N", System.Globalization.CultureInfo.GetCultureInfo("en-IN")) %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <%--                                    <asp:TemplateField HeaderText="Payment Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("PayDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--<asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" CommandArgument='<%# Eval("patientid") %>'
													CommandName="EditEnquiry" ImageUrl="../Images/right15x15.png" />--%>

                                            <asp:Button ID="btnview" CommandArgument='<%# Eval("InvoiceNo") %>' CommandName="Viewinv" class="btn blue-madison" runat="server" Text="View" />

                                            <asp:ImageButton ID="lbtDelete" Visible="false" CausesValidation="false" runat="server" CommandName="delete1" CommandArgument='<%# Eval("InvoiceNo") %>'
                                                ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Invoice?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Delete" Visible="false" ItemStyle-Width="2%">
                                        <ItemTemplate>
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
