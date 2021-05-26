<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ReportIssueNew.aspx.cs" Inherits="OrthoSquare.Help.ReportIssueNew" %>

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
                    <span>Add Issue</span>
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
                            <span class="caption-subject bold uppercase">Add Issue</span>
                        </div>

                    </div>
                    <div class="row">

                        <div class="col-md-4 ">

                            <div class="form-body">

                                <label>Issue Type</label>
                                <asp:DropDownList ID="ddlIssueType" class="form-control" runat="server"></asp:DropDownList>

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

                        <div class="col-md-4 ">

                        

                                    <div class="form-group">
                                        <label>Title</label>

                                        <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>

                                   
                            </div>

                        </div>


                        <div class="col-md-4">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                </div>
                            </div>
                        </div>
                        <!-- END CONTENT BODY -->
                    </div>

                    <div class="row">

                        <div class="col-md-6 ">

                           

                                    <div class="form-group">
                                        <label>Report your Issue</label>
                                        <asp:TextBox ID="txtissue" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>

                                   
                            </div>

                        </div>


                        <div class="col-md-6">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                </div>
                            </div>
                        </div>

                        <!-- END CONTENT BODY -->
                    </div>


                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <label>Attachment File</label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:FileUpload ID="FileUploadAttachment" runat="server" />

                                    <br />
                                    <asp:Label ID="Label2" ForeColor="Red" runat="server" Text="(jpeg , png, jpg, bmp)"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="btnAttachment" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                        runat="server" Text="Upload Image" OnClick="btnAttachment_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Image ID="ImageAttachment" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                        ImageUrl="~/Images/no-photo.jpg" />
                                    <asp:Label ID="lblAttachment" runat="server" Visible="False"></asp:Label>
                                </div>
                            </div>
                            .
                        </div>

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
                    <span>View Issue Status</span>
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
                            <span class="caption-subject font-red sbold uppercase">View Issue Status</span>
                        </div>


                    </div>
                    <div class="row">

                        <div class="col-md-4 ">



                            <div class="form-group">
                                <label>Issue Type</label>
                                <asp:DropDownList ID="ddlIssueTypeSearch" class="form-control" runat="server"></asp:DropDownList>


                            </div>

                        </div>


                        <div class="col-md-4">

                            <div class="form-group">
                                <label>Status</label>
                                <asp:DropDownList ID="ddlStateus" class="form-control" runat="server"></asp:DropDownList>



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



                        <!-- Usage as a class -->
                        <div class="text-right mb-20">
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />
                        </div>
                        <div class="table-scrollable">
                            <asp:GridView ID="GridIssue" class="table table-bordered table-hover" runat="server"
                                OnPageIndexChanging="GridIssue_PageIndexChanging" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" OnRowCommand="GridIssue_RowCommand"
                                ShowHeaderWhenEmpty="True">
                                <Columns>

                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date","{0:dd/MMM/yyyy}") %>'></asp:Label>


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

                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")  %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Comment">
                                        <ItemTemplate>
                                            <asp:Label ID="lblComment" runat="server" Text='<%# Eval("Comment")  %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comment Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCommentDate" runat="server" Text='<%# Eval("CommentDate","{0:dd/MMM/yyyy}") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                           
                                            <asp:LinkButton ID="LinkViewAttachment" CommandName ="ViewAttachment" CommandArgument='<%# Eval("Attachment") %>' runat="server">View Attachment</asp:LinkButton>
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
