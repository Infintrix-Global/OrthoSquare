<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="VendorMaster.aspx.cs" Inherits="OrthoSquare.Master.VendorMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-content" id="Add" visible="false" runat="server">
                <!-- BEGIN PAGE HEADER-->


                <div class="page-bar">
                    <ul class="page-breadcrumb">
                        <li>
                            <i class="icon-home"></i>
                            <a href="index-2.html">Home</a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            <span>VENDOR</span>
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
                                    <span class="caption-subject bold uppercase">VENDOR</span>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-6">
                             

                                            <asp:DropDownList ID="ddl_Clinic" class="form-control" runat="server"></asp:DropDownList>


                                            <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_Clinic" InitialValue="0"
                                                    SetFocusOnError="true" ErrorMessage="Please select  Clinic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                        <div class="col-sm-6">
                                          

                                            <asp:DropDownList ID="ddlVendorType" class="form-control" runat="server"></asp:DropDownList>

                                            <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlVendorType" InitialValue="0"
                                                    SetFocusOnError="true" ErrorMessage="Please select Vendor Type" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-6">
                                           
                                            <asp:TextBox ID="txtAdd" class="form-control" placeholder="Vendor Name"
                                                runat="server"></asp:TextBox>

                                            <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlDesignation" runat="server" ControlToValidate="txtAdd"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Vendor Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                    ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtAdd"
                                                    SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"> </asp:RegularExpressionValidator>

                                            </span>
                                        </div>

                                        <div class="col-sm-6">
                                           
                                            <asp:TextBox ID="txtMobile" class="form-control" placeholder="Enter Mobile" TabIndex="15" runat="server"></asp:TextBox>

                                            <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredMobile" runat="server" ControlToValidate="txtMobile"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server"
                                                    Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobile"
                                                    SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="form-actions text-center">

                                    <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />

                                    <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btnclear_Click" Class="btn default" ClientIDMode="Static"
                                        CausesValidation="False" />


                                </div>

                            </div>

                            <!-- END CONTENT BODY -->
                        </div>

                    </div>
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
                            <span>VENDOR</span>
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
                                    <span class="caption-subject font-red sbold uppercase">VENDOR</span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                                                                      <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                                ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-group form-md-line-input ">
                                            <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                                OnClick="btSearch_Click" />

                                            <asp:Button ID="Button1" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                        CausesValidation="False" OnClick="btnAddNew_Click" />

                                        </div>
                                    </div>
                                </div>


                                <!-- Usage as a class -->
                                  <div class="text-right mb-20">
                                            Total :
                                            <asp:Label ID="lblTotaCount" runat="server" Text=""></asp:Label>
                       </div>
                          
                                <div class="table-scrollable">

                                    <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover"
                                        GridLines="None" DataKeyNames="VendorID" AutoGenerateColumns="false" OnRowUpdating="gvShow_RowUpdating"
                                        OnRowDeleting="gvShow_RowDeleting" OnRowCancelingEdit="gvShow_RowCancelingEdit"
                                        OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true" AllowPaging="true"
                                        OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("VendorID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clinic Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNameClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vendor Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVendorType" runat="server" Text='<%# Eval("VendorType") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Vendor Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%# Eval("VendorID") %>' runat="server" CommandName="Update1" ImageUrl="../Images/edit15x15.png"
                                                        CausesValidation="False" />

                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                     <asp:ImageButton ID="lbtDelete" runat="server" CommandName="delete" ImageUrl="../Images/delete15x15.png"
                                                        CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this Vendor?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
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

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
