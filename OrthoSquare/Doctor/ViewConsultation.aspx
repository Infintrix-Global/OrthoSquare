<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ViewConsultation.aspx.cs" Inherits="OrthoSquare.Doctor.ViewConsultation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Edit" runat="server" class="page-content">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>View Consultation</span>
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
                            <span class="caption-subject font-red sbold uppercase">Consultation View Treatment</span>
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

                            <div id="Cid" runat="server" visible="false" class="col-md-3">
                                <div class="form-group">

                                    <asp:DropDownList ID="ddlClinic" class="form-control" runat="server"></asp:DropDownList>


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

                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover"
                                GridLines="None" DataKeyNames="patientid" AutoGenerateColumns="false"
                                ShowHeaderWhenEmpty="true" AllowPaging="true"
                                OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand">
                                <%-- <Columns >
                                        <asp:TemplateField  >
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkSelectAllEmp" runat="server" onclick="javascript:SelectAllCheckboxesEmp(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkCtrl" runat="server" />
                                                <asp:Label ID="lblTreatmentID" runat="server" Visible="false" Text='<%# Bind("Appointmentid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                    </Columns>--%>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelect" CommandName="Pselect" class="btn blue" CommandArgument='<%# Eval("patientid") %>' runat="server" Text="Select" />


                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                            <%--  <asp:Label ID="lblID" runat="server" Text='<%# Eval("Appointmentid") %>' Visible="false"></asp:Label>--%>
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


                                    <asp:TemplateField HeaderText="Clinic Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
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
                    <span>Consultation View Treatment</span>
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
                            <span class="caption-subject bold uppercase">Consultation View Treatment</span>
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




                                    <br />

                                    <br />


                                </div>
                            </div>

                        </div>

                        <div class="col-md-6">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">

                                        <div class="form-group">
                                        </div>



                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>






                    <div class="row">
                        <div class="panel-group accordion" id="accordion3">


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" runat="server" id="Complaints" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_1">Complaints </a>
                                    </h4>
                                </div>
                                <div id="collapse_3_1" class="panel-collapse collapse in">
                                    <div class="panel-body">




                                        <asp:Panel ID="Panel4" runat="server">

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



                                                </Columns>
                                                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                                <PagerSettings Mode="NumericFirstLast" />

                                            </asp:GridView>


                                        </asp:Panel>

                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
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

                                                    <asp:GridView ID="GridViewMedicines" runat="server" class="table table-bordered table-hover"
                                                        GridLines="None" AutoGenerateColumns="false"
                                                        ShowHeaderWhenEmpty="true" AllowPaging="true">

                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr. No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Medicines Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMedicinesName" runat="server" Text='<%# Eval("MedicinesName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Medicines type">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDocterName1" runat="server" Text='<%# Eval("txtMtype") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Medicines Total">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotalMedicines" runat="server" Text='<%# Eval("TotalMedicines") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Day Medicines">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDayMedicines" runat="server" Text='<%# Eval("DayMedicines") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Remarks">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
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

                            <div class="panel panel-default">
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

                                                                <asp:TemplateField HeaderText="Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("CtrateDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="tooth No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblToothno" runat="server" Text='<%# Eval("toothNo") %>'></asp:Label>
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
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_4">Treatment Plan</a>
                                    </h4>
                                </div>
                                <div id="collapse_3_4" class="panel-collapse collapse in">
                                    <div class="panel-body">

                                        <div class="row">
                                            <asp:GridView ID="GridTreatmentPlan" runat="server" class="table table-bordered table-hover"
                                                GridLines="None" AutoGenerateColumns="false"
                                                ShowHeaderWhenEmpty="true" AllowPaging="true">

                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Doctor Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDoctor" runat="server" Text='<%# Eval("FirstName") + "  " + Eval("LastName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Plan Details">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPlanDetails" runat="server" Text='<%# Eval("PlanDetails") %>'></asp:Label>
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
                                        <br />
                                        <br />




                                    </div>
                                </div>
                            </div>







                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_7">Lab Orders</a>

                                    </h4>
                                </div>
                                <div id="collapse_3_7" class="panel-collapse collapse in">
                                    <div class="panel-body">

                                        <asp:GridView ID="GridLab" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                            class="table table-bordered table-hover" DataKeyNames="Labid"
                                            GridLines="None">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("Labid")%>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lab Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLabname" runat="server" Text='<%# Eval("LabName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Patient Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPatient" runat="server" Text='<%# Eval("FristName") + "  " + Eval("LastName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Type of Work">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTypeofWork" runat="server" Text='<%# Eval("TypeName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Tooth No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblToothNo" runat="server" Text='<%# Eval("ToothNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Outward Date" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOutwardDate" runat="server" Text='<%# Eval("OutwardDate")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Inward Date" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInwardDate" runat="server" Text='<%# Eval("InwardDate")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Work Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWorkcompletion" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Work Completed">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWorkStatus" runat="server" Text=""></asp:Label>
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
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle accordion-toggle-styled" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_2">Medical History </a>

                                    </h4>
                                </div>
                                <div id="collapse_3_2" class="panel-collapse in">
                                    <div class="panel-body">

                                        <asp:Panel ID="Panel2" runat="server">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <div class="table-scrollable">

                                                            <asp:GridView ID="GridMedicalHistory" runat="server" class="table table-bordered table-hover"
                                                                GridLines="None" DataKeyNames="ID" AutoGenerateColumns="false"
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
                                                                            <asp:Label ID="lblDueDate" runat="server" Text='<%# Eval("DueDate") %>'></asp:Label>
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
                                                                    <asp:TemplateField HeaderText="Somking">
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




                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">
                                <div class="col-sm-6">

                                    <asp:DataList ID="grdProducts1" runat="server" CssClass="gridproducts" RepeatDirection="Horizontal" RepeatColumns="6">
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

                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>


    </div>

</asp:Content>
