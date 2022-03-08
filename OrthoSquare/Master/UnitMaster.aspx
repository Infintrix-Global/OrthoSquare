<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="UnitMaster.aspx.cs" Inherits="OrthoSquare.Master.UnitMaster" %>

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
                            <span>Unit</span>
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
                                    <span class="caption-subject bold uppercase">Unit</span>
                                </div>
                                <%-- <div class="actions">
                            <div class="btn-group">
                                <a class="btn btn-sm green dropdown-toggle" href="javascript:;" data-toggle="dropdown">Actions
                                                <i class="fa fa-angle-down"></i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-pencil"></i>Edit </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-trash-o"></i>Delete </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-ban"></i>Ban </a>
                                    </li>
                                    <li class="divider"></li>
                                    <li>
                                        <a href="javascript:;">Make admin </a>
                                    </li>
                                </ul>
                            </div>
                        </div>--%>
                            </div>
                            <div class="row">

                                <div class="col-md-6 ">

                                    <div class="portlet-body form">

                                        <div class="form-body">

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <asp:RadioButtonList ID="RadioBtnIsMedical" RepeatDirection="Horizontal"
                                                            Width="350px" runat="server">
                                                            <asp:ListItem Text="Material">Material</asp:ListItem>
                                                            <asp:ListItem Text="Medicine">Medicine</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>


                                                </div>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txtAdd" MaxLength="100" class="form-control" placeholder="Unit Name"
                                                        runat="server"></asp:TextBox>
                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredtxtAdd" runat="server" ControlToValidate="txtAdd"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Unit Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                            ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtAdd"
                                                            SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"> </asp:RegularExpressionValidator>
                                                    </span>
                                                </div>
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
                                                    <label></label>

                                                </div>



                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <!-- END CONTENT BODY -->
                            </div>
                            <div class="row">
                                <div class="form-actions text-center">

                                    <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />

                                    <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btnclear_Click" Class="btn default" ClientIDMode="Static"
                                        CausesValidation="False" />


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
                            <span>Unit</span>
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
                                    <span class="caption-subject font-red sbold uppercase">Unit</span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                                ClientIDMode="Static"></asp:TextBox>

                                        </div>


                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group">

                                            <asp:RadioButtonList ID="RadioBtnIsMedicalSearch" AutoPostBack="true" OnSelectedIndexChanged="RadioBtnIsMedicalSearch_Select" RepeatDirection="Horizontal"
                                                Width="300px" runat="server">
                                                <asp:ListItem Value="Material">Material</asp:ListItem>
                                                <asp:ListItem Value="Medicine">Medicine</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="All">All</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:Button ID="btSearch" runat="server" Text="Search" class="btn btn-md btn-success"
                                                OnClick="btSearch_Click" />

                                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-md btn-secondary"
                                                OnClick="btnClear_Click" />
                                            <asp:Button ID="btnAddNew" runat="server" Text="Add New Unit" class="btn btn-md btn-info"
                                                CausesValidation="False" OnClick="btnAddNew_Click" />
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                        </div>
                                    </div>

                                </div>

                                <div class="card">

                                    <!-- /.card-header -->


                                    <div class="table-scrollable">

                                        <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover" OnSorting="gvShow_Sorting" AllowSorting="true"
                                            GridLines="None" DataKeyNames="UnitId" AutoGenerateColumns="false" OnRowCommand="gvShow_RowCommand"
                                            OnRowDeleting="gvShow_RowDeleting"
                                            ShowHeaderWhenEmpty="true" AllowPaging="true"
                                            OnPageIndexChanging="gvShow_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("UnitId") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit Name" SortExpression="UnitName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit Type" SortExpression="IsMedical">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsMedical" runat="server" Text='<%# Eval("IsMedical") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="#">
                                                    <ItemTemplate>

                                                       
                                                         <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Edit1" ImageUrl="../Images/edit15x15.png"
                                                        CausesValidation="False" CommandArgument='<%# Eval("UnitId") %>' ItemStyle-Width="5%" />

                                                    <asp:ImageButton ID="lbtDelete" runat="server" CommandName="delete" ImageUrl="../Images/delete15x15.png"
                                                        CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this Unit?');" />

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

                                    <!-- /.card-body -->
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
