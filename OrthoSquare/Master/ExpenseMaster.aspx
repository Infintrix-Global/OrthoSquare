<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ExpenseMaster.aspx.cs" Inherits="OrthoSquare.Master.ExpenseMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="page-content" id="Add" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Expense</span>
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
                            <span class="caption-subject bold uppercase">Expense</span>
                        </div>
                        <%-- <div class="actions">
                            <div class="btn-group">
                                <a class="btn btn-sm green dropdown-toggle" href="javascript:;" data-toggle="dropdown">Actions
                                                <i class="fa fa-angle-down"></i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-pencil"></i>Edit </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-trash-o"></i>Delete </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-ban"></i>Ban </a>
                                    </li>
                                    <li class="divider"></li>
                                    <li>
                                        <a href="javascript:;">Make admin </a>
                                    </li>
                                </ul>
                            </div>
                        </div>--%>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">

                                <%-- <div class="col-md-6 ">--%>

                                <div class="portlet-body form">

                                    <div class="form-body">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="form_control_1">
                                                    Clinic Name <span class="required">*</span>
                                                </label>
                                                <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged11" runat="server"></asp:DropDownList>
                                                <span class="help-block">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClinic" InitialValue="0"
                                                        SetFocusOnError="true" ErrorMessage="Please select Clinic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="form-group col-md-6">
                                            <label>Doctor Name</label>
                                            <asp:DropDownList ID="ddlDoctor1" class="form-control" runat="server"></asp:DropDownList>
                                            <asp:Label ID="lblclinicId" Visible="false" runat="server" Text=""></asp:Label>
                                        </div>

                                        <div class="form-group col-md-6">
                                            <label>Date <span class="required">*</span></label>
                                            <asp:TextBox ID="txtExpDate" class="form-control"
                                                runat="server"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtBDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtExpDate" Format="dd-MM-yyyy">
                                            </asp:CalendarExtender>

                                            <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtExpDate"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Date" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </span>

                                        </div>
                                        <div class="clearfix"></div>

                                        <div class="col-sm-6">
                                            <label>Vendor Type <span class="required">*</span></label>

                                            <asp:DropDownList ID="ddlVendorType" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlVendorType_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                            <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlVendorType" InitialValue="0"
                                                    SetFocusOnError="true" ErrorMessage="Please select Vendor Type" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <asp:Panel ID="Panelvendor" runat="server">
                                        <div class="form-group col-md-6">
                                            <label>Vendor name <span class="required">*</span></label>

                                            <asp:DropDownList ID="ddlVendor" class="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>


                                            <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlVendor" InitialValue="0"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Vendor Name" ForeColor="Red"></asp:RequiredFieldValidator>

                                            </span>

                                        </div>
                                            </asp:Panel>
                                        <asp:Panel ID="PanelPlace" Visible="false" runat="server">
                                         <div class="clearfix"></div>

                                        <div class="form-group col-md-6">
                                            <label>From Place</label>
                                            <asp:TextBox ID="txtFormPlace" class="form-control" runat="server" MaxLength="150"></asp:TextBox>
                                            <span class="help-block">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" 
                                                                    ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtFormPlace"
                                                                    SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                                </asp:RegularExpressionValidator>
                                            </span>

                                        </div>
                                        <div class="form-group col-md-6">
                                            <label>To Place</label>
                                            <asp:TextBox ID="txtToplace" class="form-control" runat="server" MaxLength="150"></asp:TextBox>
                                            <span class="help-block">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                                    ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtToplace"
                                                                    SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                                </asp:RegularExpressionValidator>
                                            </span>

                                        </div>
                                            </asp:Panel>
                                        <div class="clearfix"></div>
                                        <div class="form-group col-md-6">
                                            <label>Amount <span class="required">*</span></label>
                                            <asp:TextBox ID="txtAmount" class="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                            <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2a" runat="server" ControlToValidate="txtAmount"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Amount" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1a" runat="server"
                                                    ForeColor="Red" ErrorMessage="Only Number is allowed" Display="Dynamic" ControlToValidate="txtAmount"
                                                    SetFocusOnError="True" ValidationExpression="^[0-9]*$">
                                                </asp:RegularExpressionValidator>
                                            </span>

                                        </div>
                                        <div class="form-group col-md-6">
                                            <label>Expense Details</label>
                                            <asp:TextBox ID="txtExpDetails" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>

                                        </div>

                                        <div class="clearfix"></div>



                                    </div>
                                </div>


                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label>Bill photo </label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:FileUpload ID="FileEXP" runat="server" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="ButtonEXP" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                        runat="server" Text="Upload Image" OnClick="btnUploadEXP_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Image ID="ImageEXP" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                        ImageUrl="~/Images/no-photo.jpg" />
                                    <asp:Label ID="lblEXP" runat="server" Visible="False"></asp:Label>
                                </div>
                            </div>
                            .
                        </div>

                    </div>

                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />
                            <asp:Button ID="btUpdate" ClientIDMode="Static" class="btn blue" runat="server"
                                Text="Update" Visible="False" />
                            <asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btBack_Click" />


                        </div>

                    </div>
                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>


    </div>



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
                    <span>Expense</span>
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
                            <span class="caption-subject font-red sbold uppercase">Expense</span>
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
                            <div class="col-md-3">
                                  <div class="form-group">
                                                <label >
                                                    Clinic Name <span class="required">*</span>
                                                </label>
                                                <asp:DropDownList ID="ddlClinicSearch" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlClinicSearch_SelectedIndexChanged11" runat="server"></asp:DropDownList>
                                                <span class="help-block">
                                                 
                                                </span>
                                            </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Doctor</label>
                                    <%-- <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                        ClientIDMode="Static"></asp:TextBox>--%>

                                    <asp:DropDownList ID="ddlDocterSearch" class="form-control" runat="server"></asp:DropDownList>

                                </div>
                            </div>
                            
                            <div class="col-md-6">
                                <div class="form-group form-md-line-input ">
                                    <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                        OnClick="btSearch_Click" />

                                </div>
                            </div>
                        </div>


                        <!-- Usage as a class -->
                        <div class="text-right mb-20">
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />
                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" DataKeyNames="ExpenseID"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                OnRowDeleting="gvShow_RowDeleting" OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true" OnRowDataBound="gvShow_RowDataBound">
                                <Columns>

                                    <asp:TemplateField HeaderText="Sr. No.">
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
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Vendor / Travelling">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>

                                              <asp:Label ID="lblFormPlace" Visible ="false" runat="server" Text='<%# Eval("FromPlace")%>'></asp:Label>
                                              <asp:Label ID="lblToPlace" Visible ="false" runat="server" Text='<%# Eval("ToPlace")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpDate" runat="server" Text='<%# Eval("ExpDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" CommandArgument='<%# Eval("ExpenseID")%>'
                                                CommandName="EditEnquiry" ImageUrl="../Images/right15x15.png" />
                                            <asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete"
                                                ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Expense?');" />
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
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <%--    <script src="../Scripts/jquery.searchabledropdown-1.0.8.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $("select").searchable({
                maxListSize: 200, // if list size are less than maxListSize, show them all
                maxMultiMatch: 300, // how many matching entries should be displayed
                exactMatch: false, // Exact matching on search
                wildcards: true, // Support for wildcard characters (*, ?)
                ignoreCase: true, // Ignore case sensitivity
                latency: 200, // how many millis to wait until starting search
                warnMultiMatch: 'top {0} matches ...',
                warnNoMatch: 'no matches ...',
                zIndex: 'auto'
            });
        });

    </script>

</asp:Content>
