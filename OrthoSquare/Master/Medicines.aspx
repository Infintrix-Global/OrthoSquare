<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="Medicines.aspx.cs" Inherits="OrthoSquare.Master.Medicines" %>

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
                            <span>MEDICINES</span>
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
                                    <span class="caption-subject bold uppercase">MEDICINES</span>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlMaterialType" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtMedicines" class="form-control" placeholder="Medicine Name"
                                            runat="server"></asp:TextBox>

                                        <span class="help-block">
                                            <asp:RequiredFieldValidator ID="RequiredMedicines" runat="server" ControlToValidate="txtMedicines"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Medicines Name" ForeColor="Red"></asp:RequiredFieldValidator>

                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtMedicines"
                                                SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"> </asp:RegularExpressionValidator>
                                        </span>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlUnit" class="form-control" runat="server"></asp:DropDownList>

                                    </div>


                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">

                                        <asp:TextBox ID="txtPrice" class="form-control" placeholder="Price"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCompanyName" class="form-control" placeholder="Company Name"
                                            runat="server"></asp:TextBox>
                                    </div>


                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                    </div>
                                </div>
                            </div>



                            <div class="text-center mt-12 mb-3">
                                <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn btn-md btn-info" ClientIDMode="Static" OnClick="btAdd_Click" />

                                <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btnclear_Click" Class="btn btn-md btn-secondary" ClientIDMode="Static"
                                    CausesValidation="False" />

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
                            <span>MEDICINES</span>
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
                                    <span class="caption-subject font-red sbold uppercase">MEDICINES</span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtMedicinesSearch" runat="server" class="form-control" placeholder="Name"
                                                ClientIDMode="Static"></asp:TextBox>

                                        </div>


                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlMaterialTypeSearch" class="form-control" runat="server"></asp:DropDownList>


                                        </div>


                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Button ID="btSearch" runat="server" Text="Search" class="btn btn-md btn-success"
                                                OnClick="btSearch_Click" />

                                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-md btn-secondary"
                                                OnClick="btnClear_Click" />
                                            <asp:Button ID="btnAddNew" runat="server" Text="Add New Medicines" class="btn btn-md btn-info"
                                                CausesValidation="False" OnClick="btnAddNew_Click" />
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
                                            GridLines="None" DataKeyNames="MedicinesId" AutoGenerateColumns="false" OnRowCommand="gvShow_RowCommand"
                                            OnRowDeleting="gvShow_RowDeleting" OnSorting="gvShow_Sorting" AllowSorting="true"
                                            ShowHeaderWhenEmpty="true" AllowPaging="true"
                                            OnPageIndexChanging="gvShow_PageIndexChanging">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("MedicinesId") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Medicines Type" SortExpression="MaterialName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="MedicinesId Name" SortExpression="MedicinesName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMedicinesName" runat="server" Text='<%# Eval("MedicinesName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit" SortExpression="UnitName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Price" SortExpression="Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Company" SortExpression="MedicinesCompany">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMedicinesCompany" runat="server" Text='<%# Eval("MedicinesCompany") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>



                                                <asp:TemplateField>
                                                    <ItemTemplate>

                                                        <%--  <asp:LinkButton ID="LinkBtnEdit" ToolTip="Edit" CommandName="UpdateDetials" CausesValidation="False" CommandArgument='<%# Eval("MedicinesId") %>' runat="server"> <i class="fas fa-user-edit"></i></asp:LinkButton>

                                                        <asp:LinkButton ID="LinkBtnDelete" ToolTip="Delete" CommandName="delete" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this Medicines?');" runat="server"> <i class="far fa-trash-alt"></i></asp:LinkButton>--%>


                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="UpdateDetials" ImageUrl="../Images/edit15x15.png"
                                                            CausesValidation="False" CommandArgument='<%# Eval("MedicinesId") %>' ItemStyle-Width="5%" />

                                                        <asp:ImageButton ID="lbtDelete" runat="server" CommandName="Delete" ImageUrl="../Images/delete15x15.png"
                                                            CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this Medicines?');" />

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
