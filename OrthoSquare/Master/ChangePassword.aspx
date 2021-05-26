<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="OrthoSquare.Master.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <span>Change Password</span>
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
                            <span class="caption-subject bold uppercase">Change Password</span>
                        </div>
                       
                    </div>
                    <div class="row">

                        <div class="col-md-6 ">

                            <div class="portlet-body form">

                                <div class="form-body">

                                    <div class="form-group">
                                        <label>Old Password</label>
                                        <asp:TextBox ID="txtOldPassword" class="form-control"
                                            runat="server"></asp:TextBox>


                                          <span class="help-block">
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOldPassword"
                                                 ErrorMessage="Please Enter Old Password" ForeColor="red"></asp:RequiredFieldValidator>
                                      
                                            </span>
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
                                            <label></label>
                                            
                                        </div>
                                       


                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- END CONTENT BODY -->
                    </div>
                  
                    <div class="row">

                        <div class="col-md-6 ">

                            <div class="portlet-body form">

                                <div class="form-body">

                                    <div class="form-group">
                                        <label>New Password</label>
                                        <asp:TextBox ID="txtPassword" class="form-control"
                                            runat="server"></asp:TextBox>


                                          <span class="help-block">
                                        <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter New Password"
                    ForeColor="red"></asp:RequiredFieldValidator>
                                            </span>
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
                                            <label></label>
                                            
                                        </div>
                                       


                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- END CONTENT BODY -->
                    </div>
                    
                    <div class="row">

                        <div class="col-md-6 ">

                            <div class="portlet-body form">

                                <div class="form-body">

                                    <div class="form-group">
                                        <label>Confirm Password </label>
                                        <asp:TextBox ID="txtConfirmPswd" class="form-control"
                                            runat="server"></asp:TextBox>


                                          <span class="help-block">
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                        runat="server" ControlToValidate="txtConfirmPswd" ErrorMessage="Please Enter Password"
                        ForeColor="red"></asp:RequiredFieldValidator>
                                              <asp:CompareValidator ID="CompareValidator1"
                            runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPswd"
                            ErrorMessage="ComparePasswords" ForeColor="red">Enter Correct Password.</asp:CompareValidator>
                                            </span>
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
                                            <label></label>
                                            
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
                           
                            <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btnclear_Click"  Class="btn default" ClientIDMode="Static"
                                CausesValidation="False"  />


                        </div>

                    </div>
                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>


    </div>
</asp:Content>
