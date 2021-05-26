<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ViewEnquiry.aspx.cs" Inherits="OrthoSquare.Enquiry1.ViewEnquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
    </style>
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
                    <span>Enquiry</span>
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
                            <span class="caption-subject font-red sbold uppercase">Enquiry</span>
                        </div>

                    </div>
                    <div class="portlet-body">
                        <div class="row"> 
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <b>Source : </b>
                                    </div>
                                </div>
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <asp:Label ID="lblSource" runat="server" Text=""></asp:Label>
                                       
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                         
                                       <b>Treatment :</b>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                         
                                       <asp:Label ID="lblTreatment" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                    </div>
                         <div class="row"> 
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <b>Name: </b>
                                    </div>
                                </div>
                             <div class="col-md-9">
                                    <div class="form-group">
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                             </div>
                        <div class="row"> 
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <b>BirthDate :</b>
                                    </div>
                                </div>
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <asp:Label ID="lblbirthDate" runat="server" Text=""></asp:Label>
                                       
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                         
                                       <b>Age :</b>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                         
                                       <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                    </div>

                        <div class="row"> 
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <b>Gender :</b>
                                    </div>
                                </div>
                          <div class="col-md-3">
                                    <div class="form-group">
                                       <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                         
                                       <b>Blood Group :</b>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                     <asp:Label ID="lblBloodGroup" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                    </div>
                        <div class="row"> 
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <b>Address: </b>
                                    </div>
                                </div>
                             <div class="col-md-9">
                                    <div class="form-group">
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                             </div>


                        <div class="row"> 
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <b>Mobile No : </b>
                                    </div>
                                </div>
                          <div class="col-md-3">
                                    <div class="form-group">
                                     <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                         
                                       <b>Email ID :  </b>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                     <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                    </div>


                        <div class="row"> 
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <b>Clinic Name : </b>
                                    </div>
                                </div>
                          <div class="col-md-3">
                                    <div class="form-group">
                                  <asp:Label ID="lblClinicName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                         
                                       <b>Assign To : </b>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                    <asp:Label ID="lblAssignToEmpId" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                    </div>


                        <div class="row"> 
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <b>Status : </b>
                                    </div>
                                </div>
                          <div class="col-md-3">
                                    <div class="form-group">
                               <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                         
                                       <b>Folllowup date : </b>
                                    </div>
                                </div>
                        <div class="col-md-3">
                                    <div class="form-group">
                                   <asp:Label ID="lblFolllowupdate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                    </div>

                        <div class="row"> 
                          <div class="col-md-3">
                                    <div class="form-group">
                                         <b>Conversation : </b>
                                    </div>
                                </div>
                             <div class="col-md-9">
                                    <div class="form-group">
                                       <asp:Label ID="lblConversation" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                             </div>
                        
                      
                          
                               


                         

                    </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
