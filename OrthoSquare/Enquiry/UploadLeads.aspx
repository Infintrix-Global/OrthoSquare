<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="UploadLeads.aspx.cs" Inherits="OrthoSquare.Enquiry.UploadLeads" %>

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
                    <span>Leads</span>
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
                            <span class="caption-subject font-red sbold uppercase">Leads</span>
                        </div>

                    </div>
                    <div class="portlet-body">

                        <button style="margin-bottom: 10px;" type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
                            <i class="fa fa-plus-circle"></i>Import Excel
                        </button>
                        <div class="modal fade" id="myModal">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Import Excel File</h4>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>Choose excel file</label>
                                                    <div class="input-group">
                                                        <div class="custom-file">
                                                            <asp:FileUpload ID="FileUpload1" CssClass="custom-file-input" runat="server" />
                                                            <label class="custom-file-label"></label>
                                                        </div>
                                                        <label id="filename"></label>
                                                        <div class="input-group-append">
                                                            <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-outline-primary" Text="Upload" OnClick="btnUpload_Click" />
                                                        </div>
                                                    </div>
                                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>



                        <div class="table-scrollable">
                            <asp:GridView ID="GridLeads"  ShowHeaderWhenEmpty="true" runat="server"
                                OnPageIndexChanging="GridLeads_PageIndexChanging"
                                AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" 
                                GridLines="None">

                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("EnquiryID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enquiry Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnquiryno" runat="server" Text='<%# Eval("EnquiryDate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ad Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblad_id" runat="server" Text='<%# Eval("ad_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ad Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblad_name" runat="server" Text='<%# Eval("ad_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Ad Set Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lbladset_id" runat="server" Text='<%# Eval("adset_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Ad Set Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbladset_name" runat="server" Text='<%# Eval("adset_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Ad Set Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcampaign_id" runat="server" Text='<%# Eval("campaign_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Campaign Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcampaign_name" runat="server" Text='<%# Eval("campaign_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Form Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblform_id" runat="server" Text='<%# Eval("form_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Form Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblform_name" runat="server" Text='<%# Eval("form_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Is Organic">
                                        <ItemTemplate>
                                            <asp:Label ID="lblis_organic" runat="server" Text='<%# Eval("is_organic") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Plat Form">
                                        <ItemTemplate>
                                            <asp:Label ID="lblplatform" runat="server" Text='<%# Eval("platform") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Email Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail_id" runat="server" Text='<%# Eval("Email_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mobile">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="City Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Post Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpost_code" runat="server" Text='<%# Eval("post_code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Retailer Item Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblretailer_item_id" runat="server" Text='<%# Eval("retailer_item_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="REgion">
                                        <ItemTemplate>
                                            <asp:Label ID="lblREgion" runat="server" Text='<%# Eval("REgion") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Clinic Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClinic" runat="server" Text='<%# Eval("Clinic") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                       <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="lblClinic">
                                        <ItemTemplate>
                                            <asp:Label ID="lblComment" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>



                                <EmptyDataTemplate>
                                    <div class="text-center">No record found</div>
                                </EmptyDataTemplate>

                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
