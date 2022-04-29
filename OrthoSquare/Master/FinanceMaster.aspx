<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="FinanceMaster.aspx.cs" Inherits="OrthoSquare.Master.FinanceMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Panel ID="Add" class="page-content" Visible="false" runat="server">
                <div class="page-bar">
                    <ul class="page-breadcrumb">
                        <li>
                            <i class="icon-home"></i>
                            <a href="#">Home</a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            <span>Finance</span>
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
                                    <span class="caption-subject bold uppercase">Finance</span>
                                </div>

                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtFinanceName" class="form-control" placeholder="Finance Name"
                                            runat="server"></asp:TextBox>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFinanceName"
                                            SetFocusOnError="true" ErrorMessage="Please Enter Category Name" ForeColor="Red"></asp:RequiredFieldValidator>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                            ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtFinanceName"
                                            SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"> </asp:RegularExpressionValidator>

                                    </div>


                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <asp:TextBox ID="txtInterestRate" class="form-control" placeholder="Interest Rate"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>



                            <br />

                            <div class="text-center mt-12 mb-3">


                                <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />

                                <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btnclear_Click" Class="btn default" ClientIDMode="Static"
                                    CausesValidation="False" />

                            </div>
                        </div>
                    </div>
                    <!-- END CONTENT BODY -->
                </div>


            </asp:Panel>
            <asp:Panel ID="Edit" class="page-content" runat="server">


                <div class="page-bar">
                    <ul class="page-breadcrumb">
                        <li>
                            <i class="icon-home"></i>
                            <a href="index-2.html">Home</a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            <span>Finance</span>
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
                                    <span class="caption-subject font-red sbold uppercase">Finance</span>
                                </div>
                              
                            </div>

                            <div class="card-body">

                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                                ClientIDMode="Static"></asp:TextBox>


                                        </div>


                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki"
                                                OnClick="btSearch_Click" />

                                            <asp:Button ID="btnClear" runat="server" Text="Cancel" class="btn default"
                                                OnClick="btnClear_Click" />
                                            <asp:Button ID="btnAddNew" runat="server" Text="Add New Lab" class="btn blue-madison"
                                                CausesValidation="False" OnClick="btnAddNew_Click" />
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                            </div>
                                        </div>

                                    </div>


                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                    </div>
                                </div>

                                <div class="card">

                                    <!-- /.card-header -->


                                    <div class="table-scrollable">
                                        <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover" 
                                            GridLines="None" DataKeyNames="LabId" AutoGenerateColumns="false" OnRowCommand="gvShow_RowCommand"
                                            OnRowDeleting="gvShow_RowDeleting" AllowPaging="true" OnSorting="gvShow_Sorting" AllowSorting="true"
                                            OnPageIndexChanging="gvShow_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="30%" HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("Financeid") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lab Name" SortExpression="Finance Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("FinanceName") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                             
                                                <asp:TemplateField HeaderText="Interest Rate" SortExpression="Commission">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCommission" runat="server" Text='<%# Eval("InterestRate") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="#">
                                                    <ItemTemplate>

                                                        <asp:ImageButton ID="btnUpdate" ToolTip="Update" CommandArgument='<%# Eval("Financeid") %>' runat="server" CommandName="Update1" ImageUrl="../Images/right15x15.png"
                                                            CausesValidation="False" />

                                                        <asp:LinkButton ID="LinkBtnEdit" ToolTip="Edit" CommandName="Update1" CausesValidation="False" CommandArgument='<%# Eval("Financeid") %>' runat="server"> <i class="fas fa-user-edit"></i></asp:LinkButton>

                                                        <asp:LinkButton ID="LinkBtnDelete" ToolTip="Delete" CommandName="delete" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this Lab?');" runat="server"> <i class="far fa-trash-alt"></i></asp:LinkButton>


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
            </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
