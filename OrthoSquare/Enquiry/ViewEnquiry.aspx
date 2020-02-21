<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ViewEnquiry.aspx.cs" Inherits="OrthoSquare.Enquiry.ViewEnquiry" %>
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
                            <div class="col-md-12">
                                <table style="width: 100%;">
                                      <tr>
                                        <td>Source : <asp:Label ID="lblSource" runat="server" Text=""></asp:Label></td>
                                        
                                    </tr>
                                      <tr>
                                        <td>Treatment : <asp:Label ID="lblTreatment" runat="server" Text=""></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        <td>Name : <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        <td>BirthDate : <asp:Label ID="lblbirthDate" runat="server" Text=""></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        <td>Gender : <asp:Label ID="lblGender" runat="server" Text=""></asp:Label></td>
                                       
                                    </tr>
                                     <tr>
                                        <td>Blood Group : <asp:Label ID="lblBloodGroup" runat="server" Text=""></asp:Label></td>
                                        
                                       
                                    </tr>
                                    <tr>
                                        <td>Address: <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        <td>Mobile No : <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label></td>
                                        
                                       
                                    </tr>
                                    <tr>
                                        <td>Email ID : <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
                                        
                                       
                                    </tr>
                                   
                                </table>
                                </div>
                            </div>
                      
                          
                               


                         

                    </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
