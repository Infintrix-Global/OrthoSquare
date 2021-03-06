<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="PatientCollectionReport.aspx.cs" Inherits="OrthoSquare.Report.PatientCollectionReport" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                                <span>Patient Collection Report</span>
                            </li>
                        </ul>

                    </div>
                    <div class="row">
                        <div class="col-md-12 pad">
                            <div class="portlet light portlet-fit portlet-form bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-settings font-red"></i>
                                        <span class="caption-subject font-red sbold uppercase">Patient Collection Report</span>
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

                                                    <asp:DropDownList ID="ddlDocter" class="form-control" OnSelectedIndexChanged="ddlDocter_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>



                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <asp:TextBox ID="txtPatientName" runat="server" OnTextChanged="txtPatientName_TextChanged" placeholder="Patient Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                                    <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                                        MinimumPrefixLength="2"
                                                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                        TargetControlID="txtPatientName"
                                                        ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                                    </cc1:AutoCompleteExtender>



                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control" placeholder="From Date"
                                                        ClientIDMode="Static"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFromEnquiryDate_CalendarExtender" runat="server"
                                                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                    </asp:CalendarExtender>


                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">

                                                    <asp:TextBox ID="txtToDate" runat="server" class="form-control" placeholder="To Date"
                                                        ClientIDMode="Static"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtToEnquiryDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                        Enabled="True" TargetControlID="txtToDate">
                                                    </asp:CalendarExtender>


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
                                                class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound"
                                                OnPageIndexChanging="gvShow_PageIndexChanging">

                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sr No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                                            <asp:Label ID="lblpatientid" Visible="false" runat="server" Text='<%# Eval("patientid")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="Clinic Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("ClinicName")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Doctor Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDname" runat="server" Text='<%# Eval("DFirstName") +"  "+ Eval("DLastName") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Patient Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPatientCode" runat="server" Text='<%# Eval("PatientCode") %>'></asp:Label>


                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Patient Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVisitorPname" runat="server" Text='<%# Eval("FristName") +"  "+ Eval("LastName") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Grand Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGrandTotal" runat="server" Text='<%# Eval("GrandTotal")%>'></asp:Label>
                                                        </ItemTemplate>


                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Paid Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPaidAmount" runat="server" Text='<%# Eval("PaidAmount")%>'></asp:Label>
                                                        </ItemTemplate>


                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Pending Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPendingAmount" runat="server" Text='<%# Eval("PendingAmount")%>'></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
