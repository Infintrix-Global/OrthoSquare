<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="TelecallerDashoard.aspx.cs" Inherits="OrthoSquare.Dashboard.TelecallerDashoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
            <div>
            </div>
        </div>
        <div class="page-bar">
        </div>
        <!-- END PAGE HEADER-->
        <div class="row">

            <div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">Pending Follow-ups
                    </h4>
                    <div class="widget-thumb-wrap">

                        <i class="fa fa-user-md widget-thumb-icon bg-green"></i>

                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">TOTAL</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup">
                                <asp:LinkButton ID="lbtDoc" PostBackUrl="~/Enquiry/PendingFollowupDetails.aspx" runat="server">
                                    <asp:Label ID="lblpendingFollowup" runat="server" Text=""></asp:Label>
                                </asp:LinkButton></span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>
            <div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">Assign Enquiries
                    </h4>
                    <div class="widget-thumb-wrap">

                        <i class="fa fa-envelope widget-thumb-icon bg-red"></i>
                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">TOTAL</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup" data-value="1,293">
                                <asp:LinkButton ID="LbtEnquiries" PostBackUrl="~/Enquiry/FollowupDetails.aspx" runat="server">
                                    <asp:Label ID="lblEnq" runat="server" Text=""></asp:Label>
                                </asp:LinkButton></span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>
            <div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">Follow Ups
                    </h4>
                    <div class="widget-thumb-wrap">
                        <i class="fa fa-arrow-up widget-thumb-icon bg-purple"></i>
                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">TOTAL</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup" data-value="815">
                                <asp:LinkButton ID="lbtFollowUps" PostBackUrl="~/Enquiry/ViewFolloupDetials.aspx" runat="server">
                                    <asp:Label ID="lblFollwupCOunt" runat="server" Text=""></asp:Label>
                                </asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>
            <%--<div class="col-md-2 col-sm-2 col-xs-6">
                <!-- BEGIN WIDGET THUMB -->
                <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                    <h4 class="widget-thumb-heading">Patient
                    </h4>
                    <div class="widget-thumb-wrap">
                        <i class="fa fa-bed widget-thumb-icon bg-blue"></i>
                        <div class="widget-thumb-body">
                            <span class="widget-thumb-subtitle">TOTAL</span>
                            <span class="widget-thumb-body-stat" data-counter="counterup" data-value="5,071">
                                <asp:LinkButton ID="lbtPatient" PostBackUrl="~/patient/PatientMaster.aspx" runat="server">
                                    <asp:Label ID="lblPatient" runat="server" Text=""></asp:Label>
                                </asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </div>
                <!-- END WIDGET THUMB -->
            </div>--%>
        </div>



        <div class="row">
            <div class="col-lg-12 col-xs-12 col-sm-12">
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption caption-md">
                            <i class="icon-bar-chart font-dark hide"></i>
                            <span class="caption-subject font-dark bold uppercase">Follow-ups</span>
                            <span class="caption-helper"></span>
                        </div>

                    </div>
                    <div class="portlet-body">
                        <div id="morris_chart_2" style="height: 500px;">


                            <div class="row">
                                <div class="portlet-body">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">

                                        <div class="table-scrollable">
                                            <asp:GridView ID="GridViewFolloupDetils1" runat="server" AllowPaging="true" AutoGenerateColumns="false" OnRowCommand="GridViewFolloupDetils1_RowCommand"
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


                                                    <asp:TemplateField HeaderText="Conversation Details" ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblConversationDetails1" runat="server" Text='<%# Eval("Conversation") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="Follow up By" ItemStyle-Width="26%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCompanyName1" runat="server" Text='<%# Eval("Dname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="#" ItemStyle-Width="26%">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnFollowup" runat="server" ToolTip="Followup" CausesValidation="false"
                                                                CommandArgument='<%# Eval("EnquiryID") %>' CommandName="FollowupEnquiry" Height="30px"
                                                                Width="30px" ImageUrl="../Images/followup.jpg" />
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
                </div>
            </div>

        </div>


    </div>


</asp:Content>
