<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="AddConsultationDetails.aspx.cs" Inherits="OrthoSquare.patient.AddConsultationDetails" %>

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
                    <span>Consultation Details</span>
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
                            <span class="caption-subject font-red sbold uppercase">Consultation Details</span>
                        </div>

                    </div>
                    <div class="portlet-body">
                        <div class="row">


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
                            <div class="col-md-3">
                                <div class="form-group">


                                    <asp:TextBox ID="txtPatientNos" runat="server" class="form-control" placeholder="Patient No"
                                        ClientIDMode="Static"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:TextBox ID="txttxtMobailNoss" runat="server" class="form-control" placeholder="Mobile No"
                                        ClientIDMode="Static"></asp:TextBox>

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
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                        CausesValidation="False" OnClick="btnSearch_Click" />



                                </div>
                            </div>
                        </div>
                        <!-- Usage as a class -->
                        <div class="text-right mb-20">
                            Total :
                                            <asp:Label ID="lblTotaCount" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" DataKeyNames="patientid" OnRowDataBound="gvShow_RowDataBound"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("patientid") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patient No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Visible="false" Text='<%# Eval("PatientCode") %>'></asp:Label>

                                            <asp:HyperLink runat="server" NavigateUrl='<%# Eval("patientid","../Doctor/ConsultationAddTreatment.aspx?pid={0}")%>' Text='<%#Eval("PatientCode") %>' Font-Underline="true" />

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Case File No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCaseFileNo" runat="server" Text='<%# Eval("CaseFileNo") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPName" runat="server" Text='<%# Eval("FristName") +"  "+ Eval("LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Mobile No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Registration Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("RegistrationDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patient Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPstatus1" runat="server" Text='<%# Eval("PCstatus") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--Dhaval--%>
                                    <asp:TemplateField HeaderText="Last Consultation Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblConsultationDate" runat="server" Text=''></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Clinic Name" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>

                                            <asp:ImageButton ID="btnview" ToolTip="View" CausesValidation="false" runat="server" Height="10px" Width="20px" CommandArgument='<%# Eval("patientid") %>'
                                                CommandName="viewPDetails" ImageUrl="../Images/images.png" />

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
                            <asp:ImageButton ID="btExcel" runat="server" CausesValidation="false" Height="40px"
                                ImageUrl="~/Images/excel-icon.png" Text="Download" ToolTip="Download" Width="40px"
                                OnClick="btExcel_Click" />
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>


    <div class="page-content" id="Add" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Generate Invoice</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->
        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="lblinvCode" Visible="false" runat="server" Text=""></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Generate Invoice</span>
                        </div>

                    </div>

                    <!-- END PAGE HEADER-->

                    <asp:Panel ID="Panel3" runat="server">
                        <div class="row">
                            <div class="col-xs-12">


                                <div class="form-group">
                                    <div class="col-sm-6">
                                        <div class="form-body">
                                            <label>What is your complaint? </label>
                                            <asp:TextBox ID="txtcomplaint" class="form-control" placeholder="Enter complaint." runat="server"></asp:TextBox>

                                        </div>

                                    </div>



                                    <div class="col-sm-6">
                                        <div class="form-body">

                                            <div class="form-group">
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                .
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-12">


                                <div class="form-group">
                                    <div class="col-sm-6">
                                        <div class="form-body">
                                            <label>List any dental treatment done in the one year. </label>
                                            <asp:TextBox ID="txtlistDentalTreatment" class="form-control" placeholder="Enter List any dental treatment." runat="server"></asp:TextBox>

                                        </div>

                                    </div>



                                    <div class="col-sm-6">
                                        <div class="form-body">

                                            <div class="form-group">
                                                <label>Tooth No.</label>


                                                <asp:ListBox ID="ddltooth" SelectionMode="Multiple" runat="server" CssClass="multiSelect custom__dropdown robotomd"></asp:ListBox>


                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <asp:GridView ID="GridConsultationDetails" class="table table-bordered table-hover" ShowFooter="true" runat="server" OnRowDeleting="GridConsultationDetails_RowDeleting"
                                    AutoGenerateColumns="false" OnRowDataBound="GridConsultationDetails_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="RowNumber" Visible="false" HeaderText="NO." />



                                        <asp:TemplateField HeaderText="Treatment">
                                            <ItemTemplate>

                                                <asp:ListBox ID="ddlTreatment" SelectionMode="Multiple" runat="server" CssClass="multiSelect custom__dropdown robotomd"></asp:ListBox>


                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Tooth">
                                            <ItemTemplate>
                                                <asp:ListBox ID="ddlTreatmenttooth" SelectionMode="Multiple" runat="server" CssClass="multiSelect custom__dropdown robotomd"></asp:ListBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTooth" ControlToValidate="ddltoothM" InitialValue="" runat="server" ValidationGroup="pay" ErrorMessage="Please select Tooth No" ForeColor="Red"></asp:RequiredFieldValidator>

                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Confom To User">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBoxConfomToUser" runat="server" />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Start Date">
                                            <ItemTemplate>

                                                <asp:TextBox ID="txtSdate" Text="" runat="server"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtBDate_CalendarExtender" runat="server" Enabled="True"
                                                    TargetControlID="txtSdate" Format="dd-MM-yyyy">
                                                </asp:CalendarExtender>

                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Work Done">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBoxWorkDone" runat="server" />
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Work Done Date">
                                            <ItemTemplate>

                                                <asp:TextBox ID="txtWorkdate" Text="" runat="server"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtBDate_CalendarExtender" runat="server" Enabled="True"
                                                    TargetControlID="txtWorkdate" Format="dd-MM-yyyy">
                                                </asp:CalendarExtender>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="15%">
                                            <ItemTemplate>

                                                <asp:TextBox ID="txtRemarks" class="form-control" Text="" runat="server"></asp:TextBox>


                                            </ItemTemplate>

                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:Button ID="ButtonAdd" OnClick="ButtonAdd_Click" runat="server" ValidationGroup="e" CausesValidation="false" Text="Add New" CssClass="btn yellow-gold" />

                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="#">
                                            <ItemTemplate>


                                                <asp:ImageButton ID="btnRemove" CausesValidation="false" runat="server" CommandName="Delete" ToolTip="Delete"
                                                    ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this record?');" />


                                            </ItemTemplate>



                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </asp:Panel>

                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>


    </div>
</asp:Content>
