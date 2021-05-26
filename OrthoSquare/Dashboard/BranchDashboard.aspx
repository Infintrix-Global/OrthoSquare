<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="BranchDashboard.aspx.cs" Inherits="OrthoSquare.Dashboard.BranchDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="page-content">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Dashboard</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->
        <div class="row">
            <div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">
                        Doctors
                    </h4>
                    <div class="widget-thumb-wrap">

                        <i class="fa fa-user-md widget-thumb-icon bg-green"></i>

                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">TOTAL</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup">
                                <asp:LinkButton ID="lbtDoc" PostBackUrl="~/Doctor/Add_Doctor.aspx" runat="server"><asp:Label ID="lblDoctors" runat="server" Text=""></asp:Label></asp:LinkButton></span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>
            <div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">
                       Enquiries
                    </h4>
                    <div class="widget-thumb-wrap">

                        <i class="fa fa-envelope widget-thumb-icon bg-red"></i>
                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">TOTAL</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup" data-value="1,293">
                                <asp:LinkButton ID="LbtEnquiries" PostBackUrl="~/Enquiry/EnquiryDetails.aspx" runat="server"> <asp:Label ID="lblEnq" runat="server" Text=""></asp:Label></asp:LinkButton></span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>
            <div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">
                        Follow Ups
                    </h4>
                    <div class="widget-thumb-wrap">
                        <i class="fa fa-arrow-up widget-thumb-icon bg-purple"></i>
                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">TOTAL</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup" data-value="815">
                               <asp:LinkButton ID="lbtFollowUps" PostBackUrl="~/Enquiry/ViewFolloupDetials.aspx" runat="server"> <asp:Label ID="lblFollwupCOunt" runat="server" Text=""></asp:Label></asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>
            <div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">
                        Patient
                    </h4>
                    <div class="widget-thumb-wrap">
                        <i class="fa fa-bed widget-thumb-icon bg-blue"></i>
                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">TOTAL</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup" data-value="5,071">
                               <asp:LinkButton ID="lbtPatient" PostBackUrl="~/patient/PatientMaster.aspx" runat="server"> <asp:Label ID="lblPatient" runat="server" Text=""></asp:Label></asp:LinkButton></span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>

            <div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">Invoice(Monthly)</h4>
                    <div class="widget-thumb-wrap">
                        <i class="fa fa-copy widget-thumb-icon bg-yellow-gold"></i>
                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">Rs.</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup" data-value="5,071">

                               <asp:LinkButton ID="LinkButtonINV" PostBackUrl="~/Invoice/ViewInvice.aspx" runat="server"> <asp:Label ID="totalinvoice" runat="server" Text=""></asp:Label> </asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>

            <div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">Expense(Monthly)</h4>
                    <div class="widget-thumb-wrap">
                        <i class="fa fa-money widget-thumb-icon bg-greens"></i>
                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">Rs.</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup" data-value="5,071">
                                 <asp:LinkButton ID="LinkButtonEXP" PostBackUrl="~/Report/ViewClinicwishExpenseReport.aspx" runat="server"> <asp:Label ID="lblExp" runat="server" Text=""></asp:Label></asp:LinkButton></span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <span class="caption-subject bold uppercase font-dark">Todays Appointment</span>
                            <span class="badge badge-info badge-roundless">
                                <asp:Label ID="lblTotalTodayAppoiment" runat="server" Text=""></asp:Label>
                            </span>
                        </div>
                        <%--<div class="actions">
                            <div class="btn-group ">
                                <a class="btn dark btn-outline btn-circle btn-sm" href="javascript:;" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" aria-expanded="true">Doctors
                                                <i class="fa fa-angle-down"></i>
                                </a>

                                <asp:DropDownList ID="ddlDocter" class="dropdown-menu pull-right" runat="server"></asp:DropDownList>
                                <ul class="dropdown-menu pull-right">
                                                <li>
                                                    <a href="javascript:;"> Option 1</a>
                                                </li>
                                                 <li>
                                                    <a href="javascript:;">Option 2</a>
                                                </li>
                                                <li>
                                                    <a href="javascript:;">Option 3</a>
                                                </li>
                                                <li>
                                                    <a href="javascript:;">Option 4</a>
                                                </li>
                                            </ul>
                            </div>

                            <div class="btn-group">
                                <a class="btn dark btn-outline btn-circle btn-sm" href="javascript:;" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" aria-expanded="true">Status
                                                <i class="fa fa-angle-down"></i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="javascript:;">Option 1</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Option 2</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Option 3</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Option 4</a>
                                    </li>
                                </ul>
                            </div>
                        </div>--%>
                    </div>

                    <div class="portlet-body">
                        <div class="table-scrollable table-scrollable-borderless">

                            <asp:GridView ID="GridAppoinment" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-hover table-light" DataKeyNames="Appointmentid" OnRowCommand="GridAppoinment_RowCommand"
                                GridLines="None" OnRowDataBound="GridAppoinment_RowDataBound"
                                ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
											<ItemTemplate>
												<asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
												<asp:Label ID="lblAp" runat="server" Text='<%# Eval("Appointmentid") %>' Visible="false"></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpaFirstName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Doctor Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDoctortName" runat="server" Text='<%# Eval("DFirstName") +"  "+ Eval("DLastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>

                                            <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("start_date","{0:dd/MMM/yyyy}") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Time">
                                        <ItemTemplate>

                                            <asp:Label ID="lblstart_Time" runat="server" Text='<%# Eval("start_date","{0:HH mm tt}") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="grey">
                                                <asp:Label ID="lblstatus" Visible="false" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                <asp:LinkButton ID="linkApporuval" CommandArgument='<%# Eval("Appointmentid") %>' CommandName="Approve" ToolTip="Approve" runat="server"><i class="fa fa-check"></i></asp:LinkButton>
                                                <asp:LinkButton ID="LinkRegect" CommandArgument='<%# Eval("Appointmentid") %>' CommandName="Reject" ToolTip="Reject" runat="server"> <i class="fa fa-times-circle"></i></asp:LinkButton>


                                            </div>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>



                            <%--  <table class="table table-hover table-light">
                                    
                                            <tr>
                                                <td>
                                                    <a href="javascript:;" class="primary-link">Patient Name</a>
                                                </td>
                                                <td> Doctors Name </td>
                                                <td> 17th july 18 </td>
                                                <td> 10 Am </td>
                                                <td><div class="grey"><i class="fa fa-check"></i><i class="fa fa-times-circle"></i></div> </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <a href="javascript:;" class="primary-link">Patient Name</a>
                                                </td>
                                                <td> Doctors Name </td>
                                                <td> 17th july 18 </td>
                                                <td> 10 Am </td>
                                                <td><div class="grey"><i class="fa fa-check"></i><i class="fa fa-times-circle"></i></div>                                                  
                                                </td>
                                            </tr>
                                              <tr>
                                                <td>
                                                    <a href="javascript:;" class="primary-link">Patient Name</a>
                                                </td>
                                                <td> Doctors Name </td>
                                                <td> 17th july 18 </td>
                                                <td> 10 Am </td>
                                                <td><div class="grey"><i class="fa fa-check"></i><i class="fa fa-times-circle"></i></div> 
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <a href="javascript:;" class="primary-link">Patient Name</a>
                                                </td>
                                                <td> Doctors Name </td>
                                                <td> 17th july 18 </td>
                                                <td> 10 Am </td>
                                                <td><div class="grey"><i class="fa fa-check"></i><i class="fa fa-times-circle"></i></div>  </td>
                                            </tr>
                                        </table>--%>
                        </div>


                        <div class="actions text-center">
                            <div class="btn-group btn-group-devided">

                                <asp:Button ID="Button1" runat="server" class="btn green btn-outline btn-sm active" Text="Book An Appointment" OnClick="Button1_Click" />

                                <asp:Button ID="Button2" class="btn  green btn-outline btn-sm" runat="server" Text="View More" OnClick="Button2_Click" />

                            </div>

                        </div>

                        <%--<div class="actions text-center">
                                        <div class="btn-group btn-group-devided" data-toggle="buttons">
                                            
                                            <label class="btn green btn-outline btn-sm active">
                                                <input type="radio" name="options" class="toggle" id="option1"> <asp:HyperLink ID="HyperLink1" NavigateUrl="/fullcalendar/demos/NewAppointmentClinic.aspx" runat="server"> Book An Appointment </asp:HyperLink> </label>
                                            <label class="btn  green btn-outline btn-sm">
                                                <input type="radio" name="options" class="toggle" id="option2">View More</label>
                                        </div>
                                    </div>--%>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption ">
                            <span class="caption-subject font-dark bold uppercase">Gallery</span>

                        </div>
                        <div class="actions">
                            <div class="btn-group">

                            <asp:DropDownList ID="ddlpatient1" class="btn dark btn-outline btn-circle btn-sm " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlpatient_SelectedIndexChanged">
                              
                            </asp:DropDownList>
                                </div>


                            <%--<div class="btn-group">
                                <a class="btn dark btn-outline btn-circle btn-sm" href="javascript:;" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">Select Patient Name
                                                <i class="fa fa-angle-down"></i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="javascript:;">Patient 1</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Patient 2</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Patient 3</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Patient 4</a>
                                    </li>
                                </ul>
                            </div>--%>
                        </div>
                    </div>
                    <div class="portlet-body">

                        <asp:DataList ID="grdProducts" runat="server" CssClass="gridproducts" RepeatDirection="Horizontal" RepeatColumns="4">
                            <ItemTemplate>
                                <div>
                                    
                                                    <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("TreatmentImage") %>' NavigateUrl='<%# Bind("TreatmentImage", "..\\TreatmentDoc/{0}") %>' runat="server">
                                                    <asp:Image Width="100" ID="Image1" ImageUrl='<%# Bind("TreatmentImage", "..\\TreatmentDoc/{0}") %>' runat="server" />
                                                    </asp:HyperLink>
                                          
                                </div>
                            </ItemTemplate>
                             <ItemStyle BorderColor="Brown" BorderStyle="dotted" BorderWidth="3px" HorizontalAlign="Center" VerticalAlign="Bottom" />
                        </asp:DataList>




                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption caption-md">
                            <i class="icon-bar-chart font-dark hide"></i>
                            <span class="caption-subject font-dark bold uppercase">Today Follow ups</span>

                        </div>
                        <div class="actions">
                            <div class="btn-group">
                               <asp:DropDownList ID="ddlYEARENQ"  Visible="false" class="btn dark btn-outline btn-circle btn-sm " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYEARENQ_SelectedIndexChanged">
                              
                            </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                    <div class="portlet-body">
                          <%--<div id="morris_chart_2" style="height: 500px;">--%>
                     
                            <div class="table-responsive">
                            
                                <asp:GridView ID="GridViewFolloupDetils1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        class="table table-bordered table-hover" DataKeyNames="EnquiryID" OnPageIndexChanging="GridViewFolloupDetils1_PageIndexChanging"
                                        GridLines="None" 
                                        ShowHeaderWhenEmpty="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo1" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                                  
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Name" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryName" runat="server" Text='<%# Eval("Ename") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryDate11" runat="server" Text='<%# Eval("Followupdate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Follow up Mode" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFollowupmode1" runat="server" Text='<%# Eval("Followupmode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         
                                             <asp:TemplateField HeaderText="Status" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatusName1" runat="server" Text='<%# Eval("statusName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           

                                          <asp:TemplateField HeaderText="Follow up By" ItemStyle-Width="26%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyName1" runat="server" Text='<%# Eval("Dname") %>'></asp:Label>
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


<%--                        </div>--%>

                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <!-- BEGIN REGIONAL STATS PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-share font-dark hide"></i>
                            <span class="caption-subject font-dark bold uppercase">Treatmentwise Patient Statistics</span>
                        </div>
                        <div class="actions">
                            <div class="btn-group">
                              
                                  <asp:DropDownList ID="ddlyear" class="btn dark btn-outline btn-circle btn-sm " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                              
                            </asp:DropDownList>
                                
                                
                                
                                
                                
                                 <%-- <a class="btn dark btn-outline btn-circle btn-sm" href="javascript:;" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" aria-expanded="true">Year
                                                <i class="fa fa-angle-down"></i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                   <li>
                                        <a href="javascript:;">2018</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">2019</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">2020</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">2021</a>
                                    </li>
                                </ul>--%>
                            </div>

                            <div class="btn-group">


                                  <asp:DropDownList ID="ddlMonth" class="btn dark btn-outline btn-circle btn-sm " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                              
                            </asp:DropDownList>

                               <%-- <a class="btn dark btn-outline btn-circle btn-sm" href="javascript:;" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" aria-expanded="true">month
                                                <i class="fa fa-angle-down"></i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="javascript:;">Option 1</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Option 2</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Option 3</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Option 4</a>
                                    </li>
                                </ul>--%>
                            </div>
                            <%--<div class="btn-group">
                                <a class="btn dark btn-outline btn-circle btn-sm" href="javascript:;" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" aria-expanded="true">Treatment Type
                                                <i class="fa fa-angle-down"></i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="javascript:;">Option 1</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Option 2</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Option 3</a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">Option 4</a>
                                    </li>
                                </ul>
                            </div>--%>
                        </div>
                    </div>
                    <div class="portlet-body">
                       <%-- <div id="morris_chart_4" style="height: 500px;">--%>
                          <div id="morris_chart_4" >

                             <asp:GridView ID="GridTREATMENTWISEPATIENT" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" 
                                GridLines="None" OnPageIndexChanging="GridTREATMENTWISEPATIENT_PageIndexChanging"
                                 ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Treatment Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTreatmentName" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patient Total">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPatientTotal" runat="server" Text='<%# Eval("PatientTotal") %>'></asp:Label>
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
            <div class="col-lg-6 col-xs-12 col-sm-12">
                <!-- BEGIN PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title tabbable-line">
                        <div class="caption">
                            <i class="icon-globe font-dark hide"></i>
                            <span class="caption-subject font-dark bold uppercase">Collection & Expenses</span>
                        </div>
                        <div class="actions">
                            <div class="btn-group">

                                 
                              
                                  <asp:DropDownList ID="ddlyesrEXP1"  AutoPostBack="True" OnSelectedIndexChanged="ddlyesrEXP11_SelectedIndexChanged" class="btn dark btn-outline btn-circle btn-sm " runat="server">
                              
                                   </asp:DropDownList>
                          
                        </div>
                    </div>
                    <div class="portlet-body">

                        <div id="morris_chart_3" style="height: 500px;">
                             <br />  <br />  <br />
                             <asp:Literal ID="lt" runat="server"></asp:Literal>   
                               <div id="chart_div"></div>

                        </div>

                    </div>
                </div>
                <!-- END PORTLET-->
            </div>
        </div>

    </div>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
