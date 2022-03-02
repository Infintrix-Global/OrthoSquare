<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="LabDetails.aspx.cs" Inherits="OrthoSquare.Master.LabDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Panel ID="Add" Visible="false" runat="server">
                <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="container-fluid">
                            <div class="row mb-2">

                                <div class="col-sm-6">
                                    <ol class="breadcrumb float-sm-left">
                                        <li class="breadcrumb-item"><a href="Settings.aspx">Home</a></li>
                                        <li class="breadcrumb-item active">LAB</li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                        <!-- /.container-fluid -->
                    </section>

                    <!-- Main content -->
                    <section class="content">
                        <div class="container-fluid">

                            <div class="card card-warning">
                                <div class="card-header">
                                    <h3 class="card-title">LAB</h3>


                                </div>

                                <div class="card-body">



                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtLabName" class="form-control" placeholder="Lab Name"
                                                    runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLabName"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Category Name" ForeColor="Red"></asp:RequiredFieldValidator>

                                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                    ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtLabName"
                                                    SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"> </asp:RegularExpressionValidator>

                                            </div>


                                        </div>
                                        <div class="col-md-6">
                                            </span>
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="col-md-6 ">

                                            <div class="form-body">
                                                <asp:RadioButtonList ID="RadioCommissionType" RepeatDirection="Horizontal" Width="300px" runat="server">
                                                    <asp:ListItem Value="%" Text="Percentage (%)"></asp:ListItem>
                                                    <asp:ListItem Value="₹" Text="Rupee (₹)"></asp:ListItem>

                                                </asp:RadioButtonList>
                                            </div>
                                        </div>

                                        <div class="col-md-6 ">

                                            <div class="form-body">
                                                <asp:TextBox ID="txtCommission" class="form-control" placeholder="Commission"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />

                                    <div class="text-center mt-12 mb-3">


                                        <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn btn-md btn-info" ClientIDMode="Static" OnClick="btAdd_Click" />

                                        <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btnclear_Click" Class="btn btn-md btn-secondary" ClientIDMode="Static"
                                            CausesValidation="False" />

                                    </div>
                                </div>





                            </div>

                        </div>

                    </section>


                </div>
            </asp:Panel>
            <asp:Panel ID="Edit" runat="server">
                <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="container-fluid">
                            <div class="row mb-2">

                                <div class="col-sm-6">
                                    <ol class="breadcrumb float-sm-left">
                                        <li class="breadcrumb-item"><a href="Settings.aspx">Home</a></li>
                                        <li class="breadcrumb-item active">LAB LIST</li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                        <!-- /.container-fluid -->
                    </section>

                    <!-- Main content -->
                    <section class="content">
                        <div class="container-fluid">

                            <div class="card card-warning">
                                <div class="card-header">
                                    <h3 class="card-title">LAB LIST</h3>


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
                                                <asp:Button ID="btSearch" runat="server" Text="Search" class="btn btn-md btn-success"
                                                    OnClick="btSearch_Click" />

                                                <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-md btn-secondary"
                                                    OnClick="btnClear_Click" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New Lab" class="btn btn-md btn-info"
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
                                            <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound"
                                                GridLines="None" DataKeyNames="LabId" AutoGenerateColumns="false" OnRowCommand="gvShow_RowCommand"
                                                OnRowDeleting="gvShow_RowDeleting" AllowPaging="true" OnSorting="gvShow_Sorting" AllowSorting="true"
                                                OnPageIndexChanging="gvShow_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="30%" HeaderText="Sr. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("LabId") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Lab Name" SortExpression="LabName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("LabName") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Commission Type" SortExpression="CommissionType">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCommissionType" runat="server" Text='<%# Eval("CommissionType") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Commission" SortExpression="Commission">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCommission" runat="server" Text='<%# Eval("Commission") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="#">
                                                        <ItemTemplate>

                                                            <asp:ImageButton ID="btnUpdate" ToolTip="Update" CommandArgument='<%# Eval("LabId") %>' runat="server" CommandName="Update1" ImageUrl="../Images/right15x15.png"
                                                                CausesValidation="False" />

                                                            <asp:LinkButton ID="LinkBtnEdit" ToolTip="Edit" CommandName="Update1" CausesValidation="False" CommandArgument='<%# Eval("LabId") %>' runat="server"> <i class="fas fa-user-edit"></i></asp:LinkButton>

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

                    </section>


                </div>
            </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
