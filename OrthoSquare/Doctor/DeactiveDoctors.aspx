<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="DeactiveDoctors.aspx.cs" Inherits="OrthoSquare.Doctor.DeactiveDoctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="page-content" id="Add" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Deactive Doctor</span>
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
                            <span class="caption-subject bold uppercase">Deactive Doctor</span>
                        </div>

                    </div>
                    <div class="row">

                        <div class="col-md-6 ">

                            <div class="portlet-body form">

                                <div class="form-body">

                                    <div class="form-group">
                                        <label>Clinic Name</label>
                                        <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged"></asp:DropDownList>

                                    </div>



                                </div>
                            </div>

                        </div>


                        <div class="col-md-6">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->


                                </div>
                            </div>
                        </div>

                        <!-- END CONTENT BODY -->
                    </div>

                    <div class="row">
                        <div class="col-xs-12">
                            <label>  Doctor </label>
                            <asp:CheckBoxList ID="CheckBox_Doctor" Width="800px" RepeatColumns="4" RepeatDirection="Vertical" class="mt-checkbox-list" runat="server"></asp:CheckBoxList>


                            .
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btAdd" runat="server" Text="Submit" OnClick="btAdd_Click" class="btn blue" ClientIDMode="Static"  />

                            <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btBack_Click" Class="btn default" ClientIDMode="Static"
                                CausesValidation="False"  />


                        </div>

                    </div>
                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>


    </div>
</asp:Content>
