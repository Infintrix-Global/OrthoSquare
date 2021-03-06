<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="PushNotification.aspx.cs" Inherits="OrthoSquare.Master.PushNotification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="page-content" id="Add"  runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Push Notification</span>
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
                            <span class="caption-subject bold uppercase">Push Notification</span>
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
                                        <label>Enter Title</label>
                                        <asp:TextBox ID="txtTitle" class="form-control"
                                            runat="server"></asp:TextBox>


                                         
                                    </div>






                                </div>
                            </div>

                        </div>


                        <div class="col-md-6">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">

                                       <span class="help-block">
                                         <asp:RequiredFieldValidator ID="RequiredtxtAdd" runat="server" ControlToValidate="txtTitle"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Title" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </span>


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
                                        <label>Message</label>
                                        <asp:TextBox ID="txtMessage" class="form-control"
                                            runat="server"></asp:TextBox>


                                        
                                    </div>






                                </div>
                            </div>

                        </div>


                        <div class="col-md-6">
                             <span class="help-block">
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMessage"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Message" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </span>
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
            </ContentTemplate>
          </asp:UpdatePanel>
</asp:Content>
