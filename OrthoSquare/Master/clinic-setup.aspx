﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="clinic-setup.aspx.cs" Inherits="OrthoSquare.Branch.clinic_setup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <!-- BEGIN CONTENT BODY -->
    <div class="page-content" id="Add" visible="false"  runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Clinic</span>
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
                            <span class="caption-subject bold uppercase">Clinic</span>
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
                    <div class="row">

                        <div class="col-md-6 ">

                            <div class="portlet-body form">

                                <div class="form-body">

                                    <div class="form-group">
                                                   
                                                    <div class="row">
                          <div class="col-xs-12">
                                <div class="form-group">
                                    
                                    <div class="col-sm-3">
                                      <label>
                                          Title </label>
                                         <asp:DropDownList ID="ddlTitla" class="form-control" runat="server">
                                             <asp:ListItem Value="Dr.">Dr.</asp:ListItem>
                                             <asp:ListItem Value="Mr.">Mr.</asp:ListItem>
                                             <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
                                             <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
                                             <asp:ListItem Value="Miss.">Miss.</asp:ListItem>
									   </asp:DropDownList>

                                    </div>
                                     <div class="col-sm-9">
                                              <label>First Name  <span class="required">*</span></label>
                                                    <asp:TextBox ID="txtFristName" TabIndex="1" class="form-control"
                                                        runat="server"></asp:TextBox>
                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldtxtFristName" runat="server" ControlToValidate="txtFristName"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter First name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressiontxtFristName" runat="server"
                                                            ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtFristName"
                                                            SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                        </asp:RegularExpressionValidator>
                                                    </span>
                                         </div>
                                </div>
                            </div>


                      </div>
                                                    
                                                    
                                                    
                                                    
                                                
                                                </div>


                                    <div class="form-group">
                                        <label>Clinic Name <span class="required">*</span></label>
                                        <asp:TextBox ID="txtClinicName" TabIndex="3" class="form-control"
                                            runat="server"></asp:TextBox>
                                        <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorClinicName1" runat="server" ControlToValidate="txtClinicName"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Clinic Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    
                                                    </span>
                                    </div>

                                    <div class="form-group">
                                        <label>Address Line 1</label>
                                        <asp:TextBox ID="txtAddress1" TabIndex="5" class="form-control" runat="server"
                                            TextMode="MultiLine"></asp:TextBox>
                                        <%--  <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredtxtAddress" runat="server" ControlToValidate="txtAddress1"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </span>--%>
                                    </div>

                                    <div class="form-group">
                                        <label>PinCode</label>
                                        <asp:TextBox ID="txtPinCode" TabIndex="7"  MaxLength="6" class="form-control" runat="server"></asp:TextBox>
                                        <span class="help-block">
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorPinCode" runat="server" ControlToValidate="txtPinCode"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter PinCode" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </span>
                                    </div>
                                    <div class="form-group">
                                        <label>State </label>
                                        <asp:DropDownList ID="ddlState" class="form-control" TabIndex="9" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Mobile No 1. <span class="required">*</span></label></label>
                                        <asp:TextBox ID="txtTelephone"  MaxLength="12" class="form-control" TabIndex="11"
                                            runat="server"></asp:TextBox>
                                         <span class="help-block">
                                         <asp:RequiredFieldValidator ID="RequiredMobile" runat="server" ControlToValidate="txtTelephone"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server"
                                                    Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtTelephone"
                                                    SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                         </span>
                                    </div>
                                    <div class="form-group">
                                        <label>Email  <span class="required">*</span></label>


                                        <asp:TextBox ID="txtEmail" class="form-control" TabIndex="13" runat="server"></asp:TextBox>

                                        <span class="help-block">
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                                                    ForeColor="Red" ErrorMessage="Enter Proper Email ID" Display="Dynamic" ControlToValidate="txtEmail"
                                                    SetFocusOnError="True" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">
                                                </asp:RegularExpressionValidator>

                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidatotxtEmail" runat="server" ControlToValidate="txtEmail"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Email" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </span>



                                    </div>
                                    <div class="form-group">
                                        <label>Open Time  <span class="required">*</span></label>
                                        <asp:TextBox ID="txtOpenTime" class="form-control timepicker timepicker-no-seconds" TabIndex="15" runat="server"></asp:TextBox>
                                        <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpenTime" runat="server" ControlToValidate="txtOpenTime"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter OpenTime" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </span>
                                    </div>
                                  <%--  <div class="form-group">
                                        <label>User Name</label>
                                        <asp:TextBox ID="txtUserName" class="form-control" TabIndex="17" runat="server"></asp:TextBox>


                                    </div>--%>

                                    <div class="form-group">
                                        <label>Location <span class="required"></span></label>
                                        <asp:DropDownList ID="ddl_Location" class="form-control" TabIndex="19" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Location_SelectedIndexChanged">
                                        </asp:DropDownList>

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
                                                        <label>Last Name <span class="required">*</span></label>
                                                        <asp:TextBox ID="txtLastName" TabIndex="2" class="form-control"
                                                            runat="server"></asp:TextBox>

                                                        <span class="help-block">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldLastName" runat="server" ControlToValidate="txtLastName"
                                                                SetFocusOnError="true" ErrorMessage="Please Enter Last name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionLastName" runat="server"
                                                                ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtLastName"
                                                                SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                            </asp:RegularExpressionValidator>
                                                        </span>
                                                    </div>
                                        <div class="form-group">
                                            <label>Date <span class="required">*</span></label>
                                            <asp:TextBox ID="txtDate" TabIndex="4"  class="form-control"
                                                runat="server"></asp:TextBox>
                                          
                                             <span class="help-block">
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Date" ForeColor="Red"></asp:RequiredFieldValidator>
                                                 </span>
                                        </div>
                                       
                                        <div class="form-group">
                                            <label>Address Line 2 </label>
                                            <asp:TextBox ID="txtAddress2" TabIndex="6" class="form-control" TextMode="MultiLine"
                                                runat="server"></asp:TextBox>

                                        </div>
                                        <div class="form-group">
                                            <label>Country </label>
                                            <asp:DropDownList ID="ddlCountry" TabIndex="8" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>City</label>
                                            <asp:DropDownList ID="ddlCity" TabIndex="10" class="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Telephone No 
                                                    
                                               
                                            </label>

                                            <asp:TextBox ID="txtMobile" TabIndex="12" class="form-control" MaxLength="12" runat="server"></asp:TextBox>
                                             <span class="help-block">
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidatortxtMobile" runat="server"
                                                    Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobile"
                                                    SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                           
                                                 
                                            </span>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label>Day Of Week  <span class="required">*</span></label>
                                            <asp:DropDownList ID="ddl_DayOfWeek" TabIndex="14" class="form-control" runat="server">
                                                 <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                 <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            </asp:DropDownList>

                                             <span class="help-block">
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorddl_DayOfWeek" InitialValue ="0"  runat ="server" ControlToValidate="ddl_DayOfWeek"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Day Of Week" ForeColor="Red"></asp:RequiredFieldValidator>

                                                 </span>

                                        </div>
                                        <div class="form-group">
                                            <label>Close TIme (HH:MM)<span class="required">*</span></label>
                                            <asp:TextBox ID="txtCloseTime" TabIndex="16" class="form-control timepicker timepicker-no-seconds"
                                                runat="server"></asp:TextBox>

                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1"   runat ="server" ControlToValidate="txtCloseTime"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter CloseTime" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </div>
                                        <%--<div class="form-group">
                                            <label>Password</label>
                                            <asp:TextBox ID="txtPassword" TabIndex="18" class="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group" runat="server" id="locationDiv" visible="false">
                                            <label>Location Name <span class="required"></span></label>
                                            <asp:TextBox ID="txtLocation" TabIndex="20" class="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                        

                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- END CONTENT BODY -->
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
                    <span>Clinic</span>
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
                            <span class="caption-subject font-red sbold uppercase">Clinic</span>
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
                            <div class="col-md-6">
                               <div class="form-group">
                                                <label>Search</label>
                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                        ClientIDMode="Static"></asp:TextBox>
                                  
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
                                class="table table-bordered table-hover" DataKeyNames="ClinicID"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                OnRowDeleting="gvShow_RowDeleting" OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ClinicID")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Clinic Name" ItemStyle-Width="18%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="35%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddressLine" runat="server" Text='<%# Eval("AddressLine1") + ", </br> " + Eval("AddressLine2")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location" ItemStyle-Width="18%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLocationName" runat="server" Text='<%# Eval("LocationName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone No." ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("PhoneNo1") + ",</br> " + Eval("PhoneNo2")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Open Time" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOpenTime" runat="server" Text='<%# Eval("OpenTime")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Close Time" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCloseTime" runat="server" Text='<%# Eval("CloseTime")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day Of Week" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDayOfWeek" runat="server" Text='<%# Eval("DayOfWeek")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" CommandArgument='<%# Eval("ClinicID")%>'
                                                CommandName="EditEnquiry" ImageUrl="../Images/right15x15.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="2%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete"
                                                ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Clinic?');" />
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


</ContentTemplate>
        </asp:UpdatePanel>





</asp:Content>