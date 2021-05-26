<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="patientView.aspx.cs" Inherits="OrthoSquare.patient.patientView" %>
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
                    <span>Patient</span>
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
                            <span class="caption-subject font-red sbold uppercase">Patient</span>
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

                          
                            </div>
                              <hr style="border-color:#4d79ff; border-width: 1px" />
                          
                        
                        <div class="row">
                            <div class="col-md-12">
                                <table style="width: 100%;">
                                   <%-- <tr>
                                        <td>BirthDate : <asp:Label ID="lblbirthDate" runat="server" Text="Label"></asp:Label></td>
                                        
                                    </tr>--%>
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
                        <br />
                         <br />
                           <hr style="border-color:#4d79ff; border-width: 1px" />
                          <div class="row">
                                    <div class="col-md-6 ">
                                         <div class="form-group">
                                                    <label><b>Medical History</b></label>
                                             </div>
                                        </div>
                              </div>

                            <div class="row">
                                    <div class="col-md-6 ">

                                        <div class="portlet-body form">

                                            <div class="form-body">

                                                <div class="form-group">
                                                    <label><b>Family Doctor's Name   : </b></label>
                                                  
                                                    <asp:Label ID="txtFDoctorName" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class="form-group">
                                                    <label><b>Have you Suffered from any of the following</b></label>

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
                                                        <label><b>Address & Telephone no.   : </b>   </label>
                                                       

                                                        <asp:Label ID="txtDoctorAddres" runat="server" Text="Label"></asp:Label>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">

                                       
                                        <div class="form-group">
                                            <asp:GridView ID="GridMproblem"  runat="server" AutoGenerateColumns="False">


                                             <Columns>
                                    <asp:TemplateField HeaderText="Sr. No." >
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="SpecialityName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        .
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label><b>Woman</b> </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">


                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                        <label>Are you Pregnant</label>
                                                      
                                                         
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-sm-2">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                        <asp:RadioButtonList ID="RadPregnant1" class="mt-radio-list"  AutoPostBack ="true"  Width ="100px" RepeatDirection="Horizontal" runat="server">

                                                             <asp:ListItem Value ="Yes" Text ="Yes"></asp:ListItem>
                                                            <asp:ListItem Value ="No" Text ="No" Selected="True"></asp:ListItem>
                                                        </asp:RadioButtonList>

                                                         
                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="col-sm-3">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtPreganetDueDate" Visible="false" class="form-control" placeholder="Enter Due Date." runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="col-sm-2">
                                                <div class="form-body">

                                                    

                                                        </div>
                                                    </div>
                                            </div>

                                        </div>
                                        .
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <label><b>Habits</b> </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">


                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                        <label>Pan Masala Chewing</label>
                                                        
                                                         
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-sm-2">
                                                <div class="form-body">

                                                    <div class="form-group">

                                                         <asp:RadioButtonList ID="RadPanMasala" class="mt-radio-list"  Width ="100px" RepeatDirection="Horizontal" runat="server">

                                                             <asp:ListItem Value ="Yes" Text ="Yes"></asp:ListItem>
                                                            <asp:ListItem Value ="No" Text ="No" Selected="True"></asp:ListItem>
                                                        </asp:RadioButtonList>

                                                       
                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="col-sm-4">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                       

                                                        </div>
                                                    </div>
                                            </div>

                                        </div>
                                        .
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">


                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                        <label>Pan Chewing(Tobacco)</label>
                                                        
                                                         
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-sm-2">
                                                <div class="form-body">

                                                    <div class="form-group">

                                                         <asp:RadioButtonList ID="RadTobacco" class="mt-radio-list"  Width ="100px" RepeatDirection="Horizontal" runat="server">

                                                             <asp:ListItem Value ="Yes" Text ="Yes"></asp:ListItem>
                                                            <asp:ListItem Value ="No" Text ="No" Selected="True"></asp:ListItem>
                                                        </asp:RadioButtonList>

                                                       
                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="col-sm-4">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                       

                                                        </div>
                                                    </div>
                                            </div>

                                        </div>
                                        .
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">


                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                        <label>Smoking </label>
                                                        
                                                         
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-sm-2">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                         <asp:RadioButtonList ID="RadSomking" AutoPostBack ="true" class="mt-radio-list"    Width ="100px" RepeatDirection="Horizontal" runat="server">

                                                             <asp:ListItem Value ="Yes" Text ="Yes"></asp:ListItem>
                                                            <asp:ListItem Value ="No" Text ="No" Selected="True"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                       
                                                        </div>
                                                    </div>
                                                </div>

                                            <div class="col-sm-3">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                       <asp:TextBox ID="txtNofoCigrattes" Visible="false" class="form-control" placeholder="How many cigrattes in day." runat="server"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="col-sm-3">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                       


                                                     

                                                         <span class="help-block">
                                                         

                                                        </span>
                                                        </div>
                                                    </div>
                                            </div>

                                        </div>
                                        .
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-12">


                                        <div class="form-group">
                                            <div class="col-sm-6">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                        <label><b>List of Medicine you are taking currently, if any : </b>  </label>
                                                        

                                                         <asp:Label ID="txtListMedicine" runat="server" Text="Label"></asp:Label>
                                                         
                                                    </div>
                                                </div>

                                            </div>
                                            

                                            
                                            <div class="col-sm-2">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                       

                                                        </div>
                                                    </div>
                                            </div>

                                        </div>
                                        .
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-12">


                                        <div class="form-group">
                                            <div class="col-sm-6">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                        <label><b>Are you allergic to any of the following</b></label>
                                                        
                                                         
                                                    </div>
                                                </div>

                                            </div>
                                            

                                            
                                            <div class="col-sm-2">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                     

                                                        </div>
                                                    </div>
                                            </div>

                                        </div>
                                        .
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">


                                        <div class="form-group">
                                            <div class="col-sm-10">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                       <asp:GridView ID="Gridallergic"  runat="server" AutoGenerateColumns="False">


                                             <Columns>
                                    <asp:TemplateField HeaderText="Sr. No." >
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="SpecialitallergicName" runat="server" Text='<%# Eval("allergicName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                                    </div>
                                                </div>

                                            </div>
                                            

                                            
                                            <div class="col-sm-2">
                                                <div class="form-body">

                                                    <div class="form-group">
                                                      

                                                        </div>
                                                    </div>
                                            </div>

                                        </div>
                                        .
                                    </div>
                                </div>
                        
                               


                         

                    </div>
                </div>

            </div>

        </div>


</asp:Content>
