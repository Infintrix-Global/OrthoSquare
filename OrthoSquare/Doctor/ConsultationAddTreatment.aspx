<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ConsultationAddTreatment.aspx.cs" Inherits="OrthoSquare.Doctor.ConsultationAddTreatment" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script src="jquery.sumoselect.min.js"></script>
    <link href="sumoselect.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
           // $(<%=ddlTreatment.ClientID%>).SumoSelect({ selectAll: true });
        });
    </script>

    <script type="text/javascript" language="javascript">
        function SelectAllCheckboxesEmp(spanChk) {

            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].id.indexOf("chkCtrl") != -1) {
                        if (elm[i].checked != xState)
                            elm[i].click();
                    }


                }
            }
        }
    </script>
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
                    <span>Consultation Add Treatment</span>
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
                            <span class="caption-subject font-red sbold uppercase">Consultation Add Treatment</span>
                        </div>

                    </div>
                    <div class="portlet-body">


                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">


                                    <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Patient Name"
                                        ClientIDMode="Static" MaxLength="80"></asp:TextBox>
                                    <span class="help-block">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorSearch" runat="server"
                                            ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtName"
                                            SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                        </asp:RegularExpressionValidator>
                                    </span>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:TextBox ID="txtPatientNo" runat="server" class="form-control" placeholder="Patient No."
                                        ClientIDMode="Static" MaxLength="15"></asp:TextBox>


                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">

                                    <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static" OnClick="btSearch_Click" />


                                </div>
                            </div>
                            <!-- Usage as a class -->
                            <div class="col-md-4">
                                <div class="form-group">
                                </div>
                            </div>
                        </div>




                        <%--   <asp:DropDownList ID="ddlTreatment" class="form-control" runat="server"></asp:DropDownList>--%>


                        <!-- Usage as a class -->
                        <div class="text-right mb-20">
                            <asp:Button ID="btnAddNew" runat="server" Text="ADD DETAILS" Visible="false" class="btn yellow-gold" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />
                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover"
                                GridLines="None" DataKeyNames="Appointmentid" AutoGenerateColumns="false"
                                ShowHeaderWhenEmpty="true" AllowPaging="true"
                                OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand">

                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelect" class="btn blue" CommandArgument='<%# Eval("patientid") %>' runat="server" Text="Select" />


                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Appointmentid") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patient No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("PatientCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patient Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("PFristName") +"  "+ Eval("PLastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mobile No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("PMobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Doctors">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocterName" runat="server" Text='<%# Eval("DFirstName") +"  "+ Eval("DLastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
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


    <div class="page-content" id="Add" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Consultation Add Treatment</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Consultation Add Treatment</span>
                        </div>

                    </div>



                    <div class="row">
                        <div class="col-md-6 ">

                            <div class="portlet-body form">

                                <div class="form-body">

                                    <table style="width: 100%;">
                                        <tr>
                                            <td rowspan="3">
                                                <asp:Image ID="Image1" Height="80px" Width="80px" runat="server" /></td>
                                            <td>
                                                <asp:Label ID="lblPname" runat="server" Text=""></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPmobialNo" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>


                                </div>
                            </div>

                        </div>

                        <div class="col-md-6">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">

                                        <div class="form-group">
                                            <div class="text-right mb-20">
                                                <asp:Button ID="ButtonInvoice" Visible="false" runat="server" Text="Generate Bill" class="btn blue" ClientIDMode="Static"
                                                    CausesValidation="False" OnClick="ButtonInvoice_Click" />

                                                <asp:Button ID="Button1" runat="server" Text="Book Appointments" PostBackUrl="~/fullcalendar/demos/NewAppointmentClinic.aspx" class="btn blue" ClientIDMode="Static"
                                                    CausesValidation="False" />

                                            </div>

                                        </div>



                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row" style="margin-bottom: 10px;">

                        <div class="col-md-4">
                            <div class="form-body">



                                <asp:TextBox ID="txtDocter" runat="server" OnTextChanged="txtDocter_TextChanged" placeholder="Doctor Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                    MinimumPrefixLength="2"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                    TargetControlID="txtDocter"
                                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                </cc1:AutoCompleteExtender>

                                <asp:RequiredFieldValidator ID="RequiredFieldddl_DocterDetils" runat="server" ControlToValidate="txtDocter"
                                    SetFocusOnError="true" ErrorMessage="Please Select Doctor" ForeColor="Red"></asp:RequiredFieldValidator>


                            </div>
                        </div>

                        <div class="col-md-8 ">
                            <div class="form-body">
                                <asp:RadioButtonList ID="RBtnLstPsta" runat="server" RepeatDirection="Horizontal" TabIndex="21" AutoPostBack="true"
                                    Width="500px" OnSelectedIndexChanged="RBtnLstPsta_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Less Co-operative </asp:ListItem>
                                    <asp:ListItem Selected="True" Value="2">Co-operative </asp:ListItem>
                                    <asp:ListItem Value="3">Very Co-operative </asp:ListItem>

                                </asp:RadioButtonList>

                            </div>
                        </div>

                    </div>



                    <div class="row">
                        <div class="panel-group accordion" id="accordion3">

                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" runat="server" id="Complaints" data-toggle="collapse" data-parent="#accordion3" aria-expanded="false" href="#collapse_3_1">Complaints </a>
                                    </h4>
                                </div>
                                <div id="collapse_3_1" class="panel-collapse collapse in">
                                    <div class="panel-body">

                                        <asp:Panel ID="Panel3" Visible="false" runat="server">
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
                                                                    <%--  <asp:DropDownList ID="ddltooth" class="form-control" runat="server">
                                                                        
                                                                    </asp:DropDownList>--%>

                                                                    <%--<asp:UpdatePanel ID="updatepanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="TextBox1" class="form-control " runat="server"></asp:TextBox>
                                                                            <asp:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server"
                                                                                Enabled="True" ExtenderControlID="" TargetControlID="TextBox1" PopupControlID="Panel5"
                                                                                OffsetY="22">
                                                                            </asp:PopupControlExtender>
                                                                            <asp:Panel ID="Panel5" runat="server" Height="300px" Width="256px"
                                                                                BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto"
                                                                                Style="display: none">
                                                                                <asp:CheckBoxList ID="ddltooth11" runat="server" BackColor="White" Height="300px" Width="256px"
                                                                                    AutoPostBack="True"
                                                                                    OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                                                                                </asp:CheckBoxList>

                                                                            </asp:Panel>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>--%>


                                                                    <asp:ListBox ID="ddltooth11" SelectionMode="Multiple" runat="server" CssClass="multiSelect custom__dropdown robotomd"></asp:ListBox>


                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                </div>
                                            </div>
                                            <div class="text-center" style="padding: 10px; margin: 0; background-color: #f5f5f5; border-top: 1px solid #e7ecf1">

                                                <asp:Button ID="btnCompains" runat="server" OnClick="btAddCompains_Click" Text="Submit" class="btn blue" ClientIDMode="Static" />

                                            </div>


                                        </asp:Panel>


                                        <asp:Panel ID="Panel4" runat="server">
                                            <div class="text-right mb-20">

                                                <asp:Button ID="btnaddnewComplaints" runat="server" Text="Add details" class="btn yellow-gold" ClientIDMode="Static"
                                                    CausesValidation="False" OnClick="btnAddNewComplaints_Click" />

                                            </div>
                                            <asp:GridView ID="GirdComplaints" runat="server" class="table table-bordered table-hover"
                                                GridLines="None" DataKeyNames="DentalinfoID" AutoGenerateColumns="false"
                                                ShowHeaderWhenEmpty="true" AllowPaging="true">

                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SrNoq" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                            <asp:Label ID="lblDentalinfoID" runat="server" Text='<%# Eval("DentalinfoID") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Complaint">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblComplaint" runat="server" Text='<%# Eval("Complaint") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Dental Treatment">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDentalTreatment" runat="server" Text='<%# Eval("DentalTreatment") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Tooth No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDentalTreatment1" runat="server" Text='<%# Eval("ToothNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("CreateOn","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                <PagerSettings Mode="NumericFirstLast" />

                                            </asp:GridView>

                                        </asp:Panel>

                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_6">Medicines </a>
                                    </h4>
                                </div>
                                <div id="collapse_3_6" class="panel-collapse collapse in">
                                    <div class="panel-body">


                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="form-group">
                                                    <div class="table-responsive">

                                                        <asp:GridView ID="GridViewViewMedicines" runat="server"
                                                            AutoGenerateColumns="false" class="table table-bordered table-hover">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr. No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Eval("Medicinesid") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Medicines Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMedicinesName" runat="server" Text='<%# Eval("MedicinesName") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Medicines Type">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMtype" runat="server" Text='<%# Eval("txtMtype") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Dose">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTotalMedicines" runat="server" Text='<%# Eval("TotalMedicines") %>'></asp:Label>

                                                                    </ItemTemplate>

                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="No. of Days">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDayMedicines" runat="server" Text='<%# Eval("DayMedicines") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Morning">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMorningMedicines" runat="server" Text='<%# Eval("MorningMedicines") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Afternoon">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAfternoonMedicines" runat="server" Text='<%# Eval("AfternoonMedicines") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Evening">
                                                                    <ItemTemplate>

                                                                        <asp:Label ID="lblEveningMedicines" runat="server" Text='<%# Eval("EveningMedicines") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Remarks">
                                                                    <ItemTemplate>

                                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>


                                                                    </ItemTemplate>




                                                                </asp:TemplateField>

                                                            </Columns>


                                                        </asp:GridView>

                                                        <br />
                                                        <asp:GridView ID="Gridinvoice" Visible="false" runat="server" ShowFooter="true"
                                                            AutoGenerateColumns="false" OnRowDataBound="Gridinvoice_RowDataBound" class="table table-bordered table-hover">
                                                            <Columns>
                                                                <asp:BoundField DataField="RowNumber" HeaderText="NO." />
                                                                <asp:TemplateField HeaderText="Medicines Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                                                    <ItemTemplate>

                                                                        <%--<asp:DropDownList ID="ddlTreatment" runat="server"></asp:DropDownList>--%>
                                                                        <asp:TextBox ID="txtMedicinesName" Text="" MaxLength="100" runat="server"></asp:TextBox>


                                                                        <%--                                                                        <asp:RequiredFieldValidator ID="RequiredFieldddl_txtMedicinesName" runat="server" ControlToValidate="txtMedicinesName"
                                                                            SetFocusOnError="true" ErrorMessage="Please Enter Medicines Name" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Medicines Type">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtMtype" Text="" MaxLength="100" runat="server"></asp:TextBox>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Dose">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtTotal" Text="" MaxLength="20" Width="100%" runat="server"></asp:TextBox>

                                                                    </ItemTemplate>

                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="No. of Days">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtTotalDay" Width="100%" MaxLength="2" runat="server"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Morning">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxMorning" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Afternoon">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxAfternoon" HeaderStyle-HorizontalAlign="Center" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Evening">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxEvening" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Remarks">
                                                                    <ItemTemplate>

                                                                        <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>


                                                                    </ItemTemplate>


                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <asp:Button ID="ButtonAdd" OnClick="ButtonAddGridInvoice_Click" runat="server" CausesValidation="false"
                                                                            Text="ADD DETAILS" class="btn yellow-gold" />
                                                                    </FooterTemplate>



                                                                </asp:TemplateField>

                                                            </Columns>


                                                        </asp:GridView>

                                                        <asp:CheckBox ID="CheckBox1" Text="Prescribe Medicines" runat="server" />

                                                        <asp:GridView ID="GridMedicinesDetails" class="table table-bordered table-hover" ShowFooter="true" runat="server" OnRowDeleting="GridMedicinesDetails_RowDeleting"
                                                            AutoGenerateColumns="false" OnRowDataBound="GridMedicinesDetails_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="RowNumber" Visible="false" HeaderText="NO." />
                                                                <asp:TemplateField HeaderText="Type" ItemStyle-Width="25%">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlMedicinesType" OnSelectedIndexChanged="ddlMedicinesType_SelectedIndexChanged" AutoPostBack="true" class="form-control" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hdnWOEmployeeID" runat="server" Value='<%# Eval("ID")%>'></asp:HiddenField>
                                                                        <asp:Label ID="lblMedicinesType" Visible="false" Text='<%# Eval("MedicinesType")%>' runat="server"></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="In House" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>

                                                                        <asp:CheckBox ID="CheckBoxInHouse" OnCheckedChanged="CheckBoxInHouse_CheckedChanged" AutoPostBack="true" runat="server" />
                                                                        <asp:Label ID="lblInHouse" Visible="false" Text='<%# Eval("InHouse")%>' runat="server"></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Medicines" ItemStyle-Width="25%">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlMedicinesName" Visible="false" class="form-control" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtMedicinesName" class="form-control" Text="" runat="server"></asp:TextBox>

                                                                        <asp:Label ID="lblMedicines_Name" Visible="false" Text='<%# Eval("MedicinesName")%>' runat="server"></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Dose" ItemStyle-Width="7%">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtTotalDose" Text='<%# Eval("Dose")%>' class="form-control" MaxLength="5" runat="server"></asp:TextBox>

                                                                    </ItemTemplate>

                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="No.of Days" ItemStyle-Width="7%">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtTotalNoofDays" class="form-control" MaxLength="2" Text='<%# Eval("NoOfDays")%>' runat="server"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Morning" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxMorningN" runat="server" />
                                                                        <asp:Label ID="lblMorning" Visible="false" Text='<%# Eval("Morning")%>' runat="server"></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Afternoon" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxAfternoonN" HeaderStyle-HorizontalAlign="Center" runat="server" />
                                                                        <asp:Label ID="lblAfternoon" Visible="false" Text='<%# Eval("Afternoon")%>' runat="server"></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Evening" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxEveningN" runat="server" />
                                                                        <asp:Label ID="lblEvening" Visible="false" Text='<%# Eval("Evening")%>' runat="server"></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="21%">
                                                                    <ItemTemplate>

                                                                        <asp:TextBox ID="txtRemarksN" class="form-control" Text='<%# Eval("Remarks")%>' runat="server"></asp:TextBox>


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

                                                <div class="row">
                                            <div class="col-xs-12">


                                                <div class="form-group">
                                                    <div class="col-sm-3">
                                                        <div class="form-body">
                                                            <label>Discount </label>
                                                            <asp:TextBox ID="txtMDiscount" class="form-control" placeholder="Discount %" runat="server"></asp:TextBox>

                                                        </div>

                                                    </div>



                                                    <div class="col-sm-6">
                                                        <div class="form-body">

                                                            <div class="form-group">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <div class="form-body">

                                                            <div class="text-right mb-20">
                                                              
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                                <br />
                                            </div>

                                        </div>
                                        



                                        <div class="row">
                                            <div class="text-center" style="padding: 10px; margin: 0; background-color: #f5f5f5; border-top: 1px solid #e7ecf1">

                                                <asp:Button ID="btnMedicines" runat="server" ValidationGroup="aa" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btnMedicines_Click" />


                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_3">Previous Consultation Details </a>
                                    </h4>
                                </div>
                                <div id="collapse_3_3" class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">

                                                    <div class="table-scrollable">

                                                        <asp:GridView ID="GridPreviousConsultation" runat="server" class="table table-bordered table-hover"
                                                            GridLines="None" DataKeyNames="ID" AutoGenerateColumns="false"
                                                            ShowHeaderWhenEmpty="true" AllowPaging="true">

                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr. No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Treatment Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Doctor Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDocterName1" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Tooth No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbltoothNo" runat="server" Text='<%# Eval("toothNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Notes">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTNotes" runat="server" Text='<%# Eval("TNotes") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("CtrateDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>



                                                            </Columns>
                                                            <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
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
                            </div>

                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_4">Treatment Plan [ORAL EXAMINATION AND ALL TREATMENT REQUIRED BY THE PT]</a>
                                    </h4>
                                </div>
                                <div id="collapse_3_4" class="panel-collapse collapse in">
                                    <div class="panel-body">

                                        <asp:Panel ID="PanelTreatmentPlan" Visible="false" runat="server">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">

                                                        <div class="table-scrollable">

                                                            <asp:GridView ID="GridViewTreatment" runat="server" class="table table-bordered table-hover"
                                                                GridLines="None" DataKeyNames="treatmentplanid" AutoGenerateColumns="false"
                                                                ShowHeaderWhenEmpty="true" AllowPaging="true">

                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("treatmentplanid") %>' Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Plan Details">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTNotes" runat="server" Text='<%# Eval("PlanDetails") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Doctor Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDocterName1" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                </Columns>
                                                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                                <PagerSettings Mode="NumericFirstLast" />
                                                                <EmptyDataTemplate>
                                                                    No Record Available
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>

                                                    </div>
                                                </div>


                                            </div>
                                        </asp:Panel>

                                        <div class="row">
                                            <div class="col-xs-12">


                                                <div class="form-group">
                                                    <div class="col-sm-6">
                                                        <div class="form-body">
                                                            <label>Treatment Plan </label>
                                                            <asp:TextBox ID="txtPlanDetails" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>

                                                        </div>

                                                    </div>

                                                </div>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="text-center" style="padding: 10px; margin: 0; background-color: #f5f5f5; border-top: 1px solid #e7ecf1">

                                                <asp:Button ID="btnTplan" runat="server" OnClick="btAddTreatmentPlan_Click" Text="Submit" class="btn blue" ClientIDMode="Static" />




                                            </div>

                                        </div>



                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_5">Treatment Advice [TREATMENT CHOOSEN BY THE PT TO START] </a>
                                    </h4>
                                </div>
                                <div id="collapse_3_5" class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        <div class="col-md-12 ">

                                            <div class="portlet-body form">

                                                <div class="form-body">

                                                    <div class="form-group">
                                                        <div class="row">
                                                            <div class="col-md-9">
                                                                <div class="form-group griddata">

                                                                    <div class="table-responsive">

                                                                        <asp:GridView ID="GridTreatment" runat="server" class="table table-bordered table-hover" OnRowCommand="GridTreatment_OnRowCommand"
                                                                            GridLines="None" DataKeyNames="ID" AutoGenerateColumns="false" OnRowDataBound="GridTreatment_RowDataBound"
                                                                            ShowHeaderWhenEmpty="true" AllowPaging="true">

                                                                            <Columns>

                                                                                <asp:TemplateField HeaderText="#">
                                                                                    <ItemTemplate>
                                                                                        <asp:Button ID="btnSelect" class="btn blue" Visible="false" CommandArgument='<%# Eval("ID") %>' CommandName="SelectT" runat="server" Text="Select" />

                                                                                        <asp:CheckBox ID="CheckBoxT" runat="server" />

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="#">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>



                                                                                <asp:TemplateField HeaderText="Treatment Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTreatmentName" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="false" HeaderText="Cost">
                                                                                    <ItemTemplate>


                                                                                        <asp:TextBox ID="txtCost" Width="90px" Text='<%# Eval("TreatmentsCost") %>' runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>





                                                                                <asp:TemplateField HeaderText="Tooth No">
                                                                                    <ItemTemplate>
                                                                                        <asp:ListBox ID="ddltoothM" SelectionMode="Multiple" runat="server" CssClass="multiSelect custom__dropdown robotomd"></asp:ListBox>
                                                                                        <asp:Label ID="lblTooth1" runat="server" Visible="false" Text='<%# Eval("toothNo") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>


                                                                                <asp:TemplateField HeaderText="Started">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStartedTreatments" runat="server" Text='<%# Eval("StartedTreatments") %>'></asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>



                                                                                <asp:TemplateField HeaderText="Date">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblstart_date" Visible="false" runat="server" Text='<%# Eval("CtrateDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                                        <asp:TextBox ID="txtSdate" Text='<%# Eval("CtrateDate","{0:dd/MM/yyyy}") %>' runat="server"></asp:TextBox>
                                                                                        <asp:CalendarExtender ID="txtBDate_CalendarExtender" runat="server" Enabled="True"
                                                                                            TargetControlID="txtSdate" Format="dd-MM-yyyy">
                                                                                        </asp:CalendarExtender>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="#">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete123" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>'
                                                                                            ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Doctor?');" />

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>



                                                                            </Columns>
                                                                            <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                                            <PagerSettings Mode="NumericFirstLast" />
                                                                            <EmptyDataTemplate>
                                                                                No Record Available
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <asp:ListBox ID="ddlTreatment" SelectionMode="Multiple" runat="server" CssClass="multiSelect custom__dropdown robotomd"></asp:ListBox>

                                                                    <%--                                                                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtTreatment" class="form-control " placeholder="Select Treatment" runat="server"></asp:TextBox>
                                                                            <asp:PopupControlExtender ID="PopupControlExtender1" runat="server"
                                                                                Enabled="True" ExtenderControlID="" TargetControlID="txtTreatment" PopupControlID="Panel8"
                                                                                OffsetY="22">
                                                                            </asp:PopupControlExtender>

                                                                            <asp:Panel ID="Panel8" Height="300px" Width="256px"
                                                                                BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto" runat="server">
                                                                                <asp:CheckBoxList ID="ddlTreatment" runat="server" BackColor="White" Height="300px" Width="256px"
                                                                                    DataTextField="holiday_name" DataValueField="holiday_name" AutoPostBack="True"
                                                                                    OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChangedTreatment">
                                                                                </asp:CheckBoxList>

                                                                            </asp:Panel>


                                                                            <asp:Panel ID="Panel6" runat="server" Height="300px" Width="256px"
                                                                                BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto"
                                                                                Style="display: none;">
                                                                            </asp:Panel>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>--%>

                                                                    <%--   <asp:ListBox ID="ddlTreatment" runat="server" SelectionMode="Multiple"></asp:ListBox>--%>

                                                                    <br />
                                                                    <br />
                                                                    <asp:Button ID="btnAdd" class="btn yellow-gold" runat="server" Text="ADD DETAILS" OnClick="btnAdd_Click" />

                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label>
                                                                        Notes</label>
                                                                    <asp:TextBox ID="txtNots" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>


                                                                </div>
                                                            </div>
                                                        </div>

                                                        <%--<div class="col-xl-2 col-md-4 col-sm-6 mb-3">
                                                            <label>Bench Location </label>
                                                            <div class="notranslate">
                                                                <asp:ListBox ID="ddlBenchLocation" SelectionMode="Multiple" runat="server" CssClass="multiSelect custom__dropdown robotomd form-control">
                                                                    <asp:ListItem Text="AAA" Value="AAA"></asp:ListItem>
                                                                    <asp:ListItem Text="bbb" Value="bbb"></asp:ListItem>
                                                                    <asp:ListItem Text="ccc" Value="ccc"></asp:ListItem>

                                                                    <asp:ListItem Text="ddd" Value="ddd"></asp:ListItem>
                                                                </asp:ListBox>

                                                            </div>
                                                        </div>--%>


                                                        <div class="row" runat="server" visible="false" id="TreatmentSubmit">
                                                            <div class="text-center" style="padding: 10px; margin: 0; background-color: #f5f5f5; border-top: 1px solid #e7ecf1">

                                                                <asp:Button ID="btnUpdateTreatment" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btnUpdateTreatment_Clicklab" />




                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>



                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_10">Work  Done</a>

                                    </h4>
                                </div>

                                <div id="collapse_3_10" class="panel-collapse collapse in">
                                    <div class="panel-body">

                                        <div class="row">
                                            <div class="col-md-12 ">

                                                <div class="portlet-body form">

                                                    <div class="form-body">

                                                        <asp:Panel ID="PanelAddWOrkDone" Visible="false" runat="server">
                                                            <div class="row">
                                                                <div class="col-md-3 ">
                                                                    <div class="form-group">
                                                                        <label>Treatment Name</label>

                                                                        <asp:DropDownList ID="ddlTreatmentbyworkDone" class="form-control" runat="server"></asp:DropDownList>

                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3 ">
                                                                    <div class="form-group">
                                                                        <label>Tooth No.</label>
                                                                        <%--   <asp:DropDownList ID="ddlToothNoWOrkname" class="form-control" runat="server"></asp:DropDownList>--%>
                                                                        <asp:ListBox ID="ddlToothNoWOrkname" SelectionMode="Multiple" runat="server" CssClass="multiSelect custom__dropdown robotomd"></asp:ListBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-6 ">
                                                                    <div class="form-group">
                                                                        <label>Notes</label>

                                                                        <asp:TextBox ID="txtNotsWorkDone" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-6 ">
                                                                    <div class="form-group">
                                                                        <asp:Button ID="btnTDoneWork" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btnTDoneWork_Clicklab" />
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </asp:Panel>
                                                        <asp:Panel ID="PanelListWOrkDone" runat="server">
                                                            <div class="text-right mb-20">


                                                                <asp:Button ID="btnWDAddNew" runat="server" Text="ADD DETAILS" class="btn yellow-gold" ClientIDMode="Static"
                                                                    CausesValidation="False" OnClick="btnWDAddNew_Click" />

                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group">

                                                                        <div class="table-scrollable">

                                                                            <asp:GridView ID="GridTretmetWorkDone" runat="server" class="table table-bordered table-hover" OnPageIndexChanging="GridTretmetWorkDone_PageIndexChanging"
                                                                                GridLines="None" AutoGenerateColumns="false"
                                                                                ShowHeaderWhenEmpty="true" AllowPaging="true">

                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Treatment Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTwork" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>



                                                                                    <asp:TemplateField HeaderText="Tooth No">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbltoothNoWD" runat="server" Text='<%# Eval("TootNo") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Notes">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTWDNotes" runat="server" Text='<%# Eval("Notes") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Date">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCtrateDateWD" runat="server" Text='<%# Eval("CreateDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>



                                                                                </Columns>
                                                                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                                                <PagerSettings Mode="NumericFirstLast" />
                                                                                <EmptyDataTemplate>
                                                                                    No Record Available
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                        </div>

                                                                    </div>
                                                                </div>


                                                            </div>
                                                        </asp:Panel>

                                                    </div>

                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_7">Lab Orders</a>

                                    </h4>
                                </div>
                                <div id="collapse_3_7" class="panel-collapse collapse in">
                                    <div class="panel-body">

                                        <div class="row">

                                            <div class="col-md-6 ">

                                                <div class="portlet-body form">

                                                    <div class="form-body">



                                                        <div class="form-group">
                                                            <label>Lab Name</label>
                                                            <asp:TextBox ID="txtLabname" class="form-control" runat="server"></asp:TextBox>

                                                        </div>
                                                        <div class="form-group">
                                                            <label>Tooth No.</label>
                                                            <%-- <asp:TextBox ID="txtToothNo" class="form-control" runat="server"></asp:TextBox>--%>


                                                            <%--<asp:UpdatePanel ID="updatepanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtToothNo" class="form-control " runat="server"></asp:TextBox>
                                                                    <asp:PopupControlExtender ID="PopupControlExtender2" runat="server"
                                                                        Enabled="True" ExtenderControlID="" TargetControlID="txtToothNo" PopupControlID="Panel7"
                                                                        OffsetY="22">
                                                                    </asp:PopupControlExtender>
                                                                    <asp:Panel ID="Panel7" runat="server" Height="300px" Width="256px"
                                                                        BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto"
                                                                        Style="display: none">
                                                                        <asp:CheckBoxList ID="ddlToothNo1" runat="server" BackColor="White" Height="300px" Width="256px"
                                                                            DataTextField="holiday_name" DataValueField="holiday_name" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="ddlToothNo1_SelectedIndexChangedToothNo1">
                                                                        </asp:CheckBoxList>

                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>--%>


                                                            <asp:ListBox ID="ddlToothNo1" SelectionMode="Multiple" runat="server" CssClass="multiSelect custom__dropdown robotomd"></asp:ListBox>





                                                        </div>

                                                    </div>
                                                </div>

                                            </div>


                                            <div class="col-md-6">
                                                <div class="portlet light form-fit ">

                                                    <div class="portlet-body form">
                                                        <!-- BEGIN FORM-->
                                                        <div class="form-body">



                                                            <div class="form-group">
                                                                <label>Type Of Work</label>
                                                                <asp:DropDownList ID="ddlTypeOfwork" class="form-control" runat="server"></asp:DropDownList>


                                                            </div>





                                                        </div>

                                                    </div>
                                                </div>
                                            </div>

                                            <!-- END CONTENT BODY -->
                                        </div>
                                        <div class="row">
                                            <div class="text-center" style="padding: 10px; margin: 0; background-color: #f5f5f5; border-top: 1px solid #e7ecf1">

                                                <asp:Button ID="Button4" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Clicklab" />
                                                <asp:Button ID="btUpdate" ClientIDMode="Static" class="btn blue" runat="server"
                                                    Text="Update" Visible="False" />



                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="table-scrollable">

                                                        <asp:GridView ID="GridViewLEBDetais" runat="server" class="table table-bordered table-hover"
                                                            GridLines="None" AutoGenerateColumns="false"
                                                            ShowHeaderWhenEmpty="true" AllowPaging="true">

                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr. No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="SrNoq" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                                        <asp:Label ID="lblDentalinfoID" runat="server" Text='<%# Eval("Labid") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Lab Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLabName" runat="server" Text='<%# Eval("LabName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Tooth No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblToothNo22" runat="server" Text='<%# Eval("ToothNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Type Of Work">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTypeName" runat="server" Text='<%# Eval("TypeName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>



                                                            </Columns>
                                                            <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                            <PagerSettings Mode="NumericFirstLast" />

                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_2">Medical History </a>

                                    </h4>
                                </div>
                                <div id="collapse_3_2" class="panel-collapse in">
                                    <div class="panel-body">

                                        <asp:Panel ID="Panel2" Visible="false" runat="server">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <div class="table-scrollable">

                                                            <asp:GridView ID="GridMedicalHistory" runat="server" class="table table-bordered table-hover"
                                                                GridLines="None" DataKeyNames="ID" AutoGenerateColumns="false" OnRowDataBound="GridMedicalHistoryBound"
                                                                ShowHeaderWhenEmpty="true" AllowPaging="true">

                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Family Doctor Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFamilyDoctorName" runat="server" Text='<%# Eval("FamilyDoctorName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Dr Address">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDrAddress" runat="server" Text='<%# Eval("DrAddress") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Pregnant">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPregnant" runat="server" Text='<%# Eval("Pregnant") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DueDate">
                                                                        <ItemTemplate>


                                                                            <asp:Label ID="lblDueDate" runat="server" Text='<%# Eval("DueDate","{0:dd/MM/yyyy}") %>'></asp:Label>


                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="PanMasala Chewing">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPanMasalaChewing" runat="server" Text='<%# Eval("PanMasalaChewing") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                    <asp:TemplateField HeaderText="Tobacco">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTobacco" runat="server" Text='<%# Eval("Tobacco") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Smoking">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSomkinge" runat="server" Text='<%# Eval("Somking") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cigrattes In Day">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcigrattesInDay" runat="server" Text='<%# Eval("cigrattesInDay") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="List of Medicine">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblListofMedicine" runat="server" Text='<%# Eval("ListofMedicine") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>



                                                                </Columns>
                                                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                                <PagerSettings Mode="NumericFirstLast" />
                                                                <EmptyDataTemplate>
                                                                    No Record Available
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>

                                                    </div>
                                                </div>


                                            </div>

                                        </asp:Panel>

                                        <asp:Panel ID="Panel1" Visible="false" runat="server">
                                            <div class="row">
                                                <div class="col-md-6 ">

                                                    <div class="portlet-body form">

                                                        <div class="form-body">

                                                            <div class="form-group">
                                                                <label>Family Doctor's Name</label>
                                                                <asp:TextBox ID="txtFDoctorName" class="form-control" placeholder="Enter Family Doctor's Name"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label><b>Have you Suffered from any of the following</b></label>

                                                            </div>
                                                        </div>


                                                    </div>
                                                </div>

                                                <div class="col-md-6">
                                                    <div class="portlet light form-fit ">

                                                        <div class="portlet-body form">
                                                            <!-- BEGIN FORM-->
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Address & Telephone no.</label>
                                                                    <asp:TextBox ID="txtDoctorAddres" class="form-control" placeholder="Enter Address & Telephone no." runat="server"></asp:TextBox>


                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">

                                                    <asp:CheckBoxList ID="ChkMedicalProblem1" Width="800px" RepeatColumns="4" RepeatDirection="Vertical" class="mt-checkbox-list" runat="server"></asp:CheckBoxList>

                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                        </div>
                                                        <div class="col-sm-3">
                                                        </div>
                                                        <div class="col-sm-3">
                                                        </div>
                                                        <div class="col-sm-3">
                                                        </div>
                                                    </div>
                                                    .
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <label><b>Woman</b> </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Are you Pregnant</label>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <asp:RadioButtonList ID="RadPregnant" class="mt-radio-list" OnSelectedIndexChanged="RadPregnant_SelectedIndexChanged" AutoPostBack="true" Width="100px" RepeatDirection="Horizontal" runat="server">

                                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                                    </asp:RadioButtonList>


                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>(If Yes, your due date?)</label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtPreganetDueDate" Visible="false" class="form-control" placeholder="Enter Due Date." runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendartxtPreganetDueDate" runat="server" Enabled="True"
                                                                        TargetControlID="txtPreganetDueDate" Format="dd-MM-yyyy">
                                                                    </asp:CalendarExtender>

                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <label><b>Habits</b> </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Pan Masala Chewing</label>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">

                                                                    <asp:RadioButtonList ID="RadPanMasala" class="mt-radio-list" Width="100px" RepeatDirection="Horizontal" runat="server">

                                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                                    </asp:RadioButtonList>


                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Pan Chewing(Tobacco)</label>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">

                                                                    <asp:RadioButtonList ID="RadTobacco" class="mt-radio-list" Width="100px" RepeatDirection="Horizontal" runat="server">

                                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                                    </asp:RadioButtonList>


                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Smoking </label>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <asp:RadioButtonList ID="RadSomking" AutoPostBack="true" class="mt-radio-list" OnSelectedIndexChanged="RadSomking_SelectedIndexChanged" Width="100px" RepeatDirection="Horizontal" runat="server">

                                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                                    </asp:RadioButtonList>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>if yes, How many cigrattes in day   </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtNofoCigrattes" Visible="false" class="form-control" placeholder="How many cigrattes in day." runat="server"></asp:TextBox>

                                                                    <span class="help-block">
                                                                        <asp:RegularExpressionValidator ID="RegularNofoCigrattes" runat="server" ForeColor="Red"
                                                                            ErrorMessage="Only Number is allowed" Display="Dynamic" ControlToValidate="txtNofoCigrattes"
                                                                            SetFocusOnError="True" ValidationExpression="^\d+$">
                                                                        </asp:RegularExpressionValidator>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-6">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>List of Medicine you are taking currently, if any   </label>
                                                                    <asp:TextBox ID="txtListMedicine" class="form-control" placeholder="Enter List of Medicine." runat="server"></asp:TextBox>


                                                                </div>
                                                            </div>

                                                        </div>



                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-6">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <label>Are you allergic to any of the following</label>


                                                                </div>
                                                            </div>

                                                        </div>



                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">


                                                    <div class="form-group">
                                                        <div class="col-sm-10">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                    <asp:CheckBoxList ID="checkallergic" Width="600px" RepeatDirection="Horizontal" RepeatColumns="6" runat="server">
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </div>

                                                        </div>



                                                        <div class="col-sm-2">
                                                            <div class="form-body">

                                                                <div class="form-group">
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    .
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="text-center" style="padding: 10px; margin: 0; background-color: #f5f5f5; border-top: 1px solid #e7ecf1">

                                                    <asp:Button ID="Button2" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static"
                                                        OnClick="btAdd_Click1" />




                                                </div>
                                            </div>

                                        </asp:Panel>


                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_22">GALLERY </a>

                                    </h4>
                                </div>
                                <div id="collapse_3_22" class="panel-collapse in">
                                    <div class="panel-body">

                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="form-group">
                                                    <div class="col-sm-3">
                                                        <label>
                                                            Treatment</label>

                                                        <asp:DropDownList ID="ddlTreatmentDetails" class="form-control" runat="server"></asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="form-group">
                                                    <div class="col-sm-3">
                                                        <label>
                                                            Treatment Photo</label>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:FileUpload ID="FuImage1" AllowMultiple="true" runat="server" />
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
                                                        <label>
                                                            Remark</label>

                                                        <asp:TextBox ID="txtRemarks" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <br />


                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="form-group">
                                                    <div class="col-sm-6">

                                                        <asp:DataList ID="grdProducts" runat="server" CssClass="gridproducts" RepeatDirection="Horizontal" RepeatColumns="6">
                                                            <ItemTemplate>
                                                                <div>

                                                                    <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("TreatmentImage") %>' NavigateUrl='<%# Bind("TreatmentImage", "..\\TreatmentDoc/{0}") %>' runat="server">
                                                                        <asp:Image Width="100" ID="Image1" ImageUrl='<%# Bind("TreatmentImage", "..\\TreatmentDoc/{0}") %>' runat="server" />
                                                                    </asp:HyperLink>

                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle BorderColor="Brown" BorderStyle="dotted" BorderWidth="3px" HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                        </asp:DataList>


                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <br />

                                        <div class="row">
                                            <div class="text-center" style="padding: 10px; margin: 0; background-color: #f5f5f5; border-top: 1px solid #e7ecf1">

                                                <asp:Button ID="btAddPTDetails" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAddPTDetails_Click" />

                                                <asp:Button ID="btBackPT" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                                    CausesValidation="False" OnClick="btBackPT_Click" />




                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />



                    </div>
                </div>
                <!-- END CONTENT BODY -->
            </div>


        </div>
    </div>
    <%--  <script type="text/javascript">
        $(document).ready(function () {
            $('#example-getting-started').multiselect();
        });
    </script>--%>

    <script type="text/javascript">
        $('.griddata .table-responsive').on('show.bs.dropdown', function () {
            $('.griddata .table-responsive').css("overflow", "inherit");
        });

        $('griddata .table-responsive').on('hide.bs.dropdown', function () {
            $('.griddata .table-responsive').css("overflow", "auto");
        })
    </script>
</asp:Content>
