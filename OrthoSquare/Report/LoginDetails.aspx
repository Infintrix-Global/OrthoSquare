<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="LoginDetails.aspx.cs" Inherits="OrthoSquare.Report.LoginDetails" %>

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
                    <span>Login</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMSG1" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-settings font-red"></i>
                            <span class="caption-subject font-red sbold uppercase">Login</span>
                        </div>

                    </div>
                    <div class="portlet-body">

                        <div class="row">


                            <div class="col-md-6">
                                <div class="form-group form-md-line-input ">
                                    <asp:RadioButtonList ID="RadioButtonRole" Width="70%" OnSelectedIndexChanged="RadioButtonRole_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Text="Clinic" Selected="True" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Doctor" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>



                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                        ClientIDMode="Static"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">

                                    <asp:TextBox ID="txtMNo" runat="server" class="form-control" placeholder="Mobile No"
                                        ClientIDMode="Static"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group form-md-line-input ">
                                    <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                        OnClick="btSearch_Click" />



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
                                GridLines="None" DataKeyNames="ID" AutoGenerateColumns="false" OnRowUpdating="gvShow_RowUpdating"
                                OnRowCancelingEdit="gvShow_RowCancelingEdit"
                                OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true" AllowPaging="true"
                                OnPageIndexChanging="gvShow_PageIndexChanging">
                                <RowStyle ForeColor="#333333" HorizontalAlign="Center" Font-Bold="true" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblRole" runat="server" Text='<%# Eval("RoleID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>

                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNameUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("UserName") %>' class="form-control input-sm"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Password">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPassword" runat="server" Text='<%# Eval("Password") %>' class="form-control input-sm"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="../Images/edit15x15.png"
                                        CausesValidation="False" UpdateImageUrl="../Images/right15x15.png"
                                        CancelImageUrl="../Images/cancel15x15.png" ItemStyle-Width="5%" />

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
</asp:Content>
