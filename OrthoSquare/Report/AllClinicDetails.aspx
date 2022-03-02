<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="AllClinicDetails.aspx.cs" Inherits="OrthoSquare.Report.AllClinicDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Clinic by details</span>
                </li>
            </ul>

        </div>

        <div class="row">
            <div class="col-lg-12 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption caption-md">
                            <i class="icon-bar-chart font-dark hide"></i>
                            <span class="caption-subject font-dark bold uppercase">Search</span>

                        </div>
                        <div class="actions">
                            <div class="btn-group">
                            </div>
                        </div>
                    </div>
                    <div class="portlet-body">

                        <div class="row">


                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:DropDownList ID="ddlClinic" AutoPostBack="true" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged1" class="form-control" runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:DropDownList ID="ddlDoctors" class="form-control" runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                </div>
                            </div>
                        </div>


                        <div class="row">


                            <div class="col-md-3">
                                <div class="form-group">


                                    <asp:TextBox ID="txtFromEnquiryDate" runat="server" class="form-control" placeholder="From Enquiry Date"
                                        ClientIDMode="Static"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFromEnquiryDate_CalendarExtender" runat="server"
                                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromEnquiryDate">
                                    </asp:CalendarExtender>

                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:TextBox ID="txtToEnquiryDate" runat="server" class="form-control" placeholder="To Enquiry Date"
                                        ClientIDMode="Static"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtToEnquiryDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                        Enabled="True" TargetControlID="txtToEnquiryDate">
                                    </asp:CalendarExtender>


                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                        OnClick="btSearch_Click" />

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>


        <div class="row">
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <span class="caption-subject bold uppercase font-dark">Enquiries</span>
                            <span class="badge badge-info badge-roundless">
                                <asp:Label ID="lblEnquiriesCount" runat="server" Text="0"></asp:Label>
                            </span>
                        </div>
                        <div class="actions">
                        </div>

                    </div>

                    <div class="portlet-body">
                        <div class="table-scrollable table-scrollable-borderless">
                            <asp:GridView ID="GridViewEnquiry" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="10"
                                class="table table-hover table-light" OnPageIndexChanging="GridViewEnquiry_PageIndexChanging"
                                GridLines="None"
                                ShowHeaderWhenEmpty="true">
                                <Columns>

                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpaEFirstName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Clinic Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAEClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>

                                            <asp:Label ID="lblEnquiryDate" runat="server" Text='<%# Eval("EnquiryDate","{0:dd/MMM/yyyy}") %>'></asp:Label>


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


                        <div class="actions text-center">
                            <div class="btn-group btn-group-devided">
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption ">
                            <span class="caption-subject font-dark bold uppercase">Followup</span>
                               <span class="badge badge-info badge-roundless">
                                <asp:Label ID="lblFollowupCount" runat="server" Text="0"></asp:Label>
                            </span>
                        </div>
                        <div class="actions">
                            <div class="btn-group">
                            </div>
                        </div>
                    </div>
                    <div class="portlet-body">

                        <asp:GridView ID="GridViewFollowup" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                            class="table table-bordered table-hover" DataKeyNames="ClinicID"
                            GridLines="None" OnPageIndexChanging="GridViewFollowup_PageIndexChanging"
                            ShowHeaderWhenEmpty="true" PageSize="10">
                            <Columns>

                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpaEFirstName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Clinic Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAEClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>


                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>

                                        <asp:Label ID="lblEnquiryDate" runat="server" Text='<%# Eval("Followupdate","{0:dd/MMM/yyyy}") %>'></asp:Label>


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



        <div class="row">
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <span class="caption-subject bold uppercase font-dark">Appointments</span>
                            <span class="badge badge-info badge-roundless">
                                <asp:Label ID="lblAppointmentsCount" runat="server" Text="0"></asp:Label>
                            </span>
                        </div>
                        <div class="actions">
                        </div>

                    </div>

                    <div class="portlet-body">
                        <div class="table-scrollable table-scrollable-borderless">
                            <asp:GridView ID="GridAppoinment" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="10"
                                class="table table-hover table-light" OnPageIndexChanging="GridAppoinment_PageIndexChanging"
                                GridLines="None"
                                ShowHeaderWhenEmpty="true">
                                <Columns>


                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpaFirstName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Clinic Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>

                                            <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("start_date","{0:dd/MMM/yyyy}") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Time">
                                        <ItemTemplate>

                                            <asp:Label ID="lblstart_Time" runat="server" Text='<%# Eval("start_date","{0:HH mm tt}") %>'></asp:Label>


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


                        <div class="actions text-center">
                            <div class="btn-group btn-group-devided">
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption ">
                            <span class="caption-subject font-dark bold uppercase">Consultation</span>
                               <span class="badge badge-info badge-roundless">
                                <asp:Label ID="lblConsultationCount" runat="server" Text="0"></asp:Label>
                            </span>
                        </div>
                        <div class="actions">
                            <div class="btn-group">
                            </div>
                        </div>
                    </div>
                    <div class="portlet-body">

                        <asp:GridView ID="gvShowConsultation" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                            class="table table-bordered table-hover" DataKeyNames="patientid"
                            GridLines="None" OnPageIndexChanging="gvShowConsultation_PageIndexChanging"
                            ShowHeaderWhenEmpty="true" PageSize="10">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Patient No">
                                    <ItemTemplate>

                                        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("patientid","../Doctor/ConsultationAddTreatment.aspx?pid={0}")%>' Text='<%#Eval("PatientCode") %>' Font-Underline="true" />

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Clinic Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateC" runat="server" Text='<%# Eval("TDate") %>'></asp:Label>

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


        <div class="row">
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <span class="caption-subject bold uppercase font-dark">Expense</span>
                             <span class="badge badge-info badge-roundless">
                                <asp:Label ID="lblExpenseTotal" runat="server" Text="0"></asp:Label>
                            </span>
                        </div>
                        <div class="actions">
                        </div>

                    </div>

                    <div class="portlet-body">
                        <div class="table-scrollable table-scrollable-borderless">
                            <asp:GridView ID="GridViewExpenseMaster" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="10"
                                class="table table-hover table-light" OnPageIndexChanging="GridViewExpenseMaster_PageIndexChanging"
                                GridLines="None"
                                ShowHeaderWhenEmpty="true">
                                <Columns>




                                    <asp:TemplateField HeaderText="Clinic Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAExpClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Vendor Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>

                                            <asp:Label ID="lblExpDate" runat="server" Text='<%# Eval("ExpDate","{0:dd/MMM/yyyy}") %>'></asp:Label>


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


                        <div class="actions text-center">
                            <div class="btn-group btn-group-devided">
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption ">
                            <span class="caption-subject font-dark bold uppercase">Collection</span>
                             <span class="badge badge-info badge-roundless">
                                <asp:Label ID="lblCollectionCount" runat="server" Text="0"></asp:Label>
                            </span>
                        </div>
                        <div class="actions">
                            <div class="btn-group">
                            </div>
                        </div>
                    </div>
                    <div class="portlet-body">

                        <asp:GridView ID="GridViewInvoiceMaster" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                            class="table table-bordered table-hover" DataKeyNames="ClinicID"
                            GridLines="None" OnPageIndexChanging="GridViewInvoiceMaster_PageIndexChanging"
                            ShowHeaderWhenEmpty="true" PageSize="10">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblinvPName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Clinic Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblinvClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paid Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaidAmount" runat="server" Text='<%# Eval("PaidAmount") %>'></asp:Label>


                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Pay Date">
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


                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
