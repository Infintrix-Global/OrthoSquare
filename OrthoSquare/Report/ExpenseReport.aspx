<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ExpenseReport.aspx.cs" Inherits="OrthoSquare.Report.ExpenseReport" %>


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
                                <span>Expense Report</span>
                            </li>
                        </ul>

                    </div>
                    <div class="row">
                        <div class="col-md-12 pad">
                            <div class="portlet light portlet-fit portlet-form bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-settings font-red"></i>
                                        <span class="caption-subject font-red sbold uppercase">Expense Report</span>
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
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    
                                                    <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged" runat="server"></asp:DropDownList>


                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                   
                                                    <asp:DropDownList ID="ddlDocter" class="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                   
                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control" placeholder="From Date"
                                                        ClientIDMode="Static"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFromEnquiryDate_CalendarExtender" runat="server"
                                                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                    </asp:CalendarExtender>


                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                   
                                                    <asp:TextBox ID="txtToDate" runat="server" class="form-control" placeholder="To Date"
                                                        ClientIDMode="Static"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtToEnquiryDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                        Enabled="True" TargetControlID="txtToDate">
                                                    </asp:CalendarExtender>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                                        CausesValidation="False" OnClick="btnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="text-right mb-20">
                                            <asp:LinkButton ID="btnExcel1" Visible="false" class="btn btn-sm btn-outline-primary btn-round" runat="server"
                                                CausesValidation="false" OnClick="btnExcel1_Click1">
                                <i class="fa fa-cloud-download"></i>
                               <span class="text">Export</span></asp:LinkButton>
                                        </div>
                                        <div class="text-right mb-20">
                                            Total :
                                            <asp:Label ID="lblTotalTop" runat="server" Text="Label"></asp:Label>
                                        </div>
                                        <div class="table-scrollable">

                                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                                class="table table-bordered table-hover" DataKeyNames="ExpenseID" OnRowDataBound="gvShow_RowDataBound"
                                                OnPageIndexChanging="gvShow_PageIndexChanging">

                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sr No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ExpenseID")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Clinic Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Doctor Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDoctor" runat="server" Text='<%# Eval("FirstName") + "  " + Eval("LastName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Vendor Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVendorType" runat="server" Text='<%# Eval("VendorType")%>'></asp:Label>
                                                            <asp:Label ID="lblFormPlace" Visible="false" runat="server" Text='<%# Eval("FromPlace")%>'></asp:Label>
                                                            <asp:Label ID="lblToPlace" Visible="false" runat="server" Text='<%# Eval("ToPlace")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Vendor / Travelling">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotal1" runat="server" Text="Total"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Left" />
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblExpDate" runat="server" Text='<%# Eval("ExpDate","{0:dd/MM/yyyy}") %>'></asp:Label>
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
