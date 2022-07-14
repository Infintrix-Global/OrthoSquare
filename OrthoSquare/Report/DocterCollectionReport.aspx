<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="DocterCollectionReport.aspx.cs" Inherits="OrthoSquare.Report.DocterCollectionReport" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
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
                                <span>Docter Collection Report</span>
                            </li>
                        </ul>

                    </div>
                    <div class="row">
                        <div class="col-md-12 pad">
                            <div class="portlet light portlet-fit portlet-form bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-settings font-red"></i>
                                        <span class="caption-subject font-red sbold uppercase">Docter Collection Report</span>
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
                                        

                                        <div class="row">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                                            CausesValidation="False" OnClick="btnSearch_Click" />
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="table-scrollable">

                                                <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false" ShowFooter="true"
                                                    class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound"
                                                    OnPageIndexChanging="gvShow_PageIndexChanging">

                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                                                <asp:Label ID="lblDoctor" Visible="false" runat="server" Text='<%# Eval("DoctorId")%>'></asp:Label>
                                                                <asp:Label ID="lblClinicID" Visible="false" runat="server" Text='<%# Eval("ClinicId")%>'></asp:Label>
                                                                <asp:Label ID="lblIsDelete" Visible="false" runat="server" Text='<%# Eval("isDeleted")%>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="Clinic Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Doctor Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVisitorName1" runat="server" Text='<%# Eval("DoctorName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <%--<FooterStyle HorizontalAlign="Right" />
												<FooterTemplate>
                                                    <asp:Label ID="lblTotal1" runat="server" Text="Total"></asp:Label>
												</FooterTemplate>--%>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Mobile No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMobile1" runat="server" Text='<%# Eval("Mobile1") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <%--<FooterStyle HorizontalAlign="Right" />
												<FooterTemplate>
                                                    <asp:Label ID="lblTotal1" runat="server" Text="Total"></asp:Label>
												</FooterTemplate>--%>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Total Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Left" />
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblGTotla" runat="server" Text=""></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Paid Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaidAmount" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Left" />
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblPaidAmountTotal" runat="server" Text=""></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Pending Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPendingAmount" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Left" />
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblPendingAmountTotal" runat="server" Text=""></asp:Label>
                                                            </FooterTemplate>
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
