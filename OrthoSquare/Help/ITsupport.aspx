<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ITsupport.aspx.cs" Inherits="OrthoSquare.Help.ITsupport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content" id="Add" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>IT / Support</span>
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
                            <span class="caption-subject bold uppercase">IT / Support</span>
                        </div>

                    </div>
                    <div class="row">

                        <div class="col-md-4 ">

                            <div class="form-body">

                             
                                <asp:DropDownList ID="ddlStatus" class="form-control" runat="server"></asp:DropDownList>

                            </div>
                        </div>


                        <div class="col-md-4">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->


                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->


                                </div>
                            </div>
                        </div>
                        <!-- END CONTENT BODY -->
                    </div>


                    <div class="row">

                        <div class="col-md-6 ">

                        

                                    <div class="form-group">
                                        <label>Comment</label>

                                        <asp:TextBox ID="txtComment" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>

                                   
                            </div>

                        </div>


                        <div class="col-md-3">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                </div>
                            </div>
                        </div>
                        <!-- END CONTENT BODY -->
                    </div>

                   


                    

                    <div class="row">
                        <div class="form-actions text-center">


                            <asp:Button ID="btnissue" runat="server" class="btn blue" ClientIDMode="Static" OnClick="btnissue_Click" Text="Submit" />


                        </div>

                    </div>
                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>


    </div>

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
                    <span>IT / Support</span>
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
                            <span class="caption-subject font-red sbold uppercase">IT / Support</span>
                        </div>


                    </div>
                    <div class="row">

                        <div class="col-md-4 ">



                            <div class="form-group">
                               
                                <asp:DropDownList ID="ddlIssueTypeSearch" class="form-control" placeholder="Issue Type" runat="server"></asp:DropDownList>


                            </div>

                        </div>


                        <div class="col-md-4">

                            <div class="form-group">
                              
                                <asp:DropDownList ID="ddlSearchStateus" class="form-control" placeholder="Status" runat="server"></asp:DropDownList>



                            </div>
                        </div>
                        <div class="col-md-4">

                            <div class="portlet-body form">
                            </div>

                        </div>

                        <!-- END CONTENT BODY -->
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">

                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control" placeholder="From Date"
                                    ClientIDMode="Static"></asp:TextBox>
                                <asp:CalendarExtender ID="txtFromEnquiryDate_CalendarExtender" runat="server"
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                </asp:CalendarExtender>
                                <span class="help-block"></span>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">

                                <asp:TextBox ID="txtToDate" runat="server" class="form-control" placeholder="To Date"
                                    ClientIDMode="Static"></asp:TextBox>
                                <asp:CalendarExtender ID="txtToEnquiryDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                    Enabled="True" TargetControlID="txtToDate">
                                </asp:CalendarExtender>


                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="btSearch" OnClick="btSearch_Click" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static" />
                        </div>
                        <!-- Usage as a class -->

                    </div>
                    <div class="portlet-body">

                          <div class="text-right mb-20">
                                            Total :
                                            <asp:Label ID="lblTotaCount" runat="server" Text=""></asp:Label>
                       </div>


                        <!-- Usage as a class -->
                       
                        <div class="table-scrollable">
                            <asp:GridView ID="GridIssue" class="table table-bordered table-hover" runat="server"
                                OnPageIndexChanging="GridIssue_PageIndexChanging" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" OnRowCommand="GridIssue_RowCommand" 
                                ShowHeaderWhenEmpty="True">
                                <Columns>

                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date","{0:dd/MMM/yyyy}") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lbluserName" runat="server" Text='<%# Eval("ClinicName")  %>'></asp:Label></a>--%>
                                            <asp:Label ID="lbluserName" runat="server" Text='<%# Eval("DoctorName")  %>'></asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issue Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssueType" runat="server" Text='<%# Eval("IssueType")  %>'></asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title")  %>'></asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Issue">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIssue" runat="server" Text='<%# Eval("Description")  %>'></asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View Attachment">
                                        <ItemTemplate>
                                           
                                            <asp:LinkButton ID="LinkViewAttachment" CommandName ="ViewAttachment" CommandArgument='<%# Eval("Attachment") %>' runat="server">View Attachment</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")  %>'></asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Comment">
                                        <ItemTemplate>

                                            <asp:Label ID="lblComment" runat="server" Text='<%# Eval("Comment")  %>'></asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                           
                                            <asp:Button ID="btnissue" runat="server" CommandName ="ITSelect" CommandArgument='<%# Eval("ID") %>'  class="btn blue" ClientIDMode="Static"  Text="Select" />
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>

                                              <asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete1" CommandArgument='<%# Eval("ID") %>'
                                                ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Issue?');" />
 
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
</asp:Content>
