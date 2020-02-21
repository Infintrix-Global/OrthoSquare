<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ViewDoctor.aspx.cs" Inherits="OrthoSquare.Doctor.ViewDoctor" %>

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

                                    <asp:Image ID="ImagePhoto11" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                        ImageUrl="~/Images/no-photo.jpg" />
                                    <br />
                                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>


                                </div>
                            </div>


                        </div>
                        <div class="text-right mb-20">

                            <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
                        </div>
                        <hr style="border-color: #4d79ff; border-width: 1px" />


                        <div class="row">
                            <div class="col-md-12">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>BirthDate :
                                            <asp:Label ID="lblbirthDate" runat="server" Text="Label"></asp:Label></td>

                                    </tr>
                                    <tr>
                                        <td>Gender :
                                            <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label></td>

                                    </tr>
                                    <tr>
                                        <td>Blood Group :
                                            <asp:Label ID="lblBloodGroup" runat="server" Text="Label"></asp:Label></td>


                                    </tr>
                                    <tr>
                                        <td>Address:
                                            <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></td>

                                    </tr>
                                    <tr>
                                        <td>Mobile No :
                                            <asp:Label ID="lblMobileNo" runat="server" Text="Label"></asp:Label></td>


                                    </tr>
                                    <tr>
                                        <td>Email ID :
                                            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>


                                    </tr>

                                </table>
                            </div>
                        </div>
                        <br />
                        <br />
                        <hr style="border-color: #4d79ff; border-width: 1px" />
                        <div class="row">
                            <div class="col-md-12">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>Clinic Name </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="GridDoctorbyClinic" class="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="False">


                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Clinic Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SpecialityName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>


                                        </td>

                                    </tr>
                                </table>
                            </div>
                        </div>
                        <hr style="border-color: #4d79ff; border-width: 1px" />
                        <div class="row">
                            <div class="col-md-12">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>Degree :
                                            <asp:Label ID="lblDegree" runat="server" Text="Label"></asp:Label></td>
                                        <td>
                                            <asp:Image ID="ImageDegree" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                ImageUrl="~/Images/no-photo.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Speciality </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="GridSpeciality" class="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="False">


                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SpecialityName" runat="server" Text='<%# Eval("SpecialityName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>


                                        </td>

                                    </tr>
                                </table>
                            </div>
                        </div>
                        <br />
                        <br />
                        <hr style="border-color: #4d79ff; border-width: 1px" />
                        <div class="row">
                            <div class="col-md-12">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>Adhar Card No :
                                            <asp:Label ID="lblAdharcard" runat="server" Text="Label"></asp:Label></td>
                                        <td>
                                            <asp:Image ID="ImageAdhar" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                ImageUrl="~/Images/no-photo.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Pan Card No :
                                            <asp:Label ID="lblPanCardNo" runat="server" Text="Label"></asp:Label></td>
                                        <td>
                                            <asp:Image ID="ImagePanCardNo1" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                ImageUrl="~/Images/no-photo.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Registration No :
                                            <asp:Label ID="lblRegistrationNo" runat="server" Text="Label"></asp:Label></td>
                                        <td>
                                            <asp:Image ID="ImageRegistrationNo" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                ImageUrl="~/Images/no-photo.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Identity Policy No :
                                            <asp:Label ID="lblIdentityPolicyNo" runat="server" Text="Label"></asp:Label></td>
                                        <td>
                                            <asp:Image ID="ImageIdentityPolicyNo" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                ImageUrl="~/Images/no-photo.jpg" />
                                        </td>
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
