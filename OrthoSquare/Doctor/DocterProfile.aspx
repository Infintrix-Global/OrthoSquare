<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="DocterProfile.aspx.cs" Inherits="OrthoSquare.Doctor.DocterProfile" %>
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
                    <span>Doctor</span>
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
                            <span class="caption-subject font-red sbold uppercase">Doctor</span>
                        </div>

                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-12">
                                 <div class="form-group">
                                               
                                          <asp:Image ID="ImagePhoto1" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                            ImageUrl="~/Images/no-photo.jpg" />
                                            <br />
                                     <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>   
                                   
                                  
                                </div>
                            </div>

                           
                        </div>
                        <div class="text-right mb-20">

                            <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
                            </div>
                              <hr style="border-color:#4d79ff; border-width: 1px" />
                          
                        
                        <div class="row">
                            <div class="col-md-12">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>BirthDate : <asp:Label ID="lblbirthDate" runat="server" Text="Label"></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        <td>Gender : <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label></td>
                                       
                                    </tr>
                                     <tr>
                                        <td>Blood Group : <asp:Label ID="lblBloodGroup" runat="server" Text="Label"></asp:Label></td>
                                        
                                       
                                    </tr>
                                    <tr>
                                        <td>Address: <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></td>
                                        
                                    </tr>
                                    <tr>
                                        <td>Mobile No : <asp:Label ID="lblMobileNo" runat="server" Text="Label"></asp:Label></td>
                                        
                                       
                                    </tr>
                                    <tr>
                                        <td>Email ID : <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
                                        
                                       
                                    </tr>
                                   
                                </table>
                                </div>
                            </div>
                           <hr style="border-color:#4d79ff; border-width: 1px" />
                          
                           

                               <%--<div class="row">
                                    <div class="col-xs-12">
                                        <label>Degree </label>
                                      
                                       
                                        <asp:GridView ID="GridDegree"  class="table table-striped table-bordered table-hover"  runat="server">
                                            <Columns >
                                                  
                                                 <asp:TemplateField >
                                                       <ItemTemplate >

                                                           <asp:Label ID="lblDname" runat="server" Text='<%# Eval("Name") %>'></asp:Label>

                                                       </ItemTemplate>

                                                 </asp:TemplateField>

                                                    
                                                 <asp:TemplateField >
                                                       <ItemTemplate >

                                                           <asp:Image ID="Image1" Width="100px" Height="100px" ImageUrl='<%# "../EmployeeProfile/"+ Eval("ProfileImageUrl") %>' runat="server" />

                                                       </ItemTemplate>

                                                 </asp:TemplateField>

                                            </Columns>

                                        </asp:GridView>
                                    </div>
                                </div>--%>


                         

                    </div>
                </div>

            </div>

        </div>

    </div>



</asp:Content>
