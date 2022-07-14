<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="AssignMaterial.aspx.cs" Inherits="OrthoSquare.Material.AssignMaterial" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function checkDate1(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select future Date!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
    </script>
    <script type="text/javascript">
        function InIEvent() {
            if ($('.jsDatePicker').length > 0) {
                $('.jsDatePicker').datepicker();
            }

            if ($('.multiSelect').length > 0) {
                $('.multiSelect').multiselect({
                    nonSelectedText: '--- Select ---',
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" id="Add" runat="server">


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>View Material Stock</span>
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
                            <span class="caption-subject bold uppercase"><span>View Material Stock</span>
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="form_control_1">
                                    Inventory Type
                                </label>
                                <asp:DropDownList ID="ddlMaterialType" class="form-control" OnSelectedIndexChanged="ddlMaterialType_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>


                            </div>
                        </div>


                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="form_control_1">
                                   Item Name
                                </label>


                                <asp:TextBox ID="txtMaterial" runat="server" OnTextChanged="txtMaterial_TextChanged" placeholder="Material Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                <cc1:AutoCompleteExtender ServiceMethod="SearchMaterial"
                                    MinimumPrefixLength="2"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                    TargetControlID="txtMaterial"
                                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                </cc1:AutoCompleteExtender>


                            </div>
                        </div>

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

                    </div>
                    <div class="row">



                        <div class="col-md-3" style="margin-top: 25px;">
                            <div class="form-group">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                    CausesValidation="False" OnClick="btnSearch_Click" />

                            </div>
                        </div>
                    </div>



                    <br />
                    <div class="row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Clinic Name</label>
                                <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged1"></asp:DropDownList>

                                <span class="help-block">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClinic" InitialValue="0" ValidationGroup="e"
                                        SetFocusOnError="true" ErrorMessage="Please Enter Clinic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </span>

                            </div>
                        </div>


                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Doctor Name</label>

                                <asp:DropDownList ID="ddlDoctor" class="form-control" runat="server"></asp:DropDownList>

                                <span class="help-block">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDoctor" InitialValue="0" ValidationGroup="e"
                                        SetFocusOnError="true" ErrorMessage="Please Enter Doctor" ForeColor="Red"></asp:RequiredFieldValidator>
                                </span>

                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Date</label>
                                <asp:TextBox ID="txtDate" class="form-control" autocomplete="Off" placeholder="Payment Date" TabIndex="5" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="txtBDate_CalendarExtender" runat="server" Enabled="True" OnClientDateSelectionChanged="checkDate1"
                                    TargetControlID="txtDate" Format="dd-MM-yyyy">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                            </div>
                        </div>

                    </div>



                    <div class="text-right mb-20">
                        Total :
                                            <asp:Label ID="lblTotalTop" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="table-responsive">
                        <asp:GridView ID="GridMateialStock" class="table table-bordered table-hover" ShowFooter="true" runat="server"
                            AutoGenerateColumns="false">
                            <Columns>

                                <asp:TemplateField HeaderText="Item Name" >
                                    <ItemTemplate>
                                        ReceiveMaterialId
                                        <asp:Label ID="lblMaterialName" Text='<%# Eval("MaterialName")%>' runat="server"></asp:Label>
                                        <asp:Label ID="lblReceiveMaterialId" Visible="false" Text='<%# Eval("ReceiveMaterialId")%>' runat="server"></asp:Label>
                                        <asp:Label ID="lblMaterialId" Visible="false" Text='<%# Eval("MaterialId")%>' runat="server"></asp:Label>
                                        <asp:Label ID="lblClinicId" Visible="false" Text='<%# Eval("ClinicId")%>' runat="server"></asp:Label>
                                        <asp:Label ID="lblRequestCode" Visible="false" Text='<%# Eval("RequestCode")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Request Stock" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblRequestQty" Text='<%# Eval("RequestQty")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Receive Stock" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblReceiveQty" Text='<%# Eval("ReceiveQty")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Receive Date" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblReceiveDate" Text='<%# Eval("SendOrderDate","{0:dd/MMM/yyyy}")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="ActualQty Stock">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtActualQty" Width="80px" class="form-control minInp" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>

                                        <asp:TextBox ID="txtRemark" class="form-control" Text="" runat="server"></asp:TextBox>


                                    </ItemTemplate>


                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>


                                        <asp:Button ID="btnReceive" CommandName="Receive" OnClick="btnReceive_Click" class="btn blue-madison" ValidationGroup="e" runat="server" Text="Receive Material" />


                                    </ItemTemplate>



                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>


                </div>

            </div>
        </div>


    </div>




</asp:Content>
