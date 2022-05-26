<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ClinicRequestStock.aspx.cs" Inherits="OrthoSquare.Material.ClinicRequestStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content" id="Add" runat="server">


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Add Material Stock</span>
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
                            <span class="caption-subject bold uppercase"><span>Add Material Request Stock</span>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">

                                <asp:DropDownList ID="ddlMaterialType" class="form-control" runat="server"></asp:DropDownList>



                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">

                                <asp:TextBox ID="txtMaterial" runat="server" class="form-control" placeholder="Material"
                                    ClientIDMode="Static"></asp:TextBox>



                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                    CausesValidation="False" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="table-responsive">
                        <asp:GridView ID="GridMateialStock" class="table table-bordered table-hover" ShowFooter="true" runat="server" OnRowDeleting="GridMateialStock_RowDeleting"
                            AutoGenerateColumns="false" OnRowDataBound="GridMateialStock_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="RowNumber" Visible="false" HeaderText="NO." />
                                <asp:TemplateField HeaderText="Type" ItemStyle-Width="25%">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlMaterialType" OnSelectedIndexChanged="ddlMaterialType_SelectedIndexChanged" AutoPostBack="true" class="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hdnWOEmployeeID" runat="server" Value='<%# Eval("ID")%>'></asp:HiddenField>
                                        <asp:Label ID="lblMaterialTypeid" Visible="false" Text='<%# Eval("MaterialTypeId")%>' runat="server"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Material Name" ItemStyle-Width="25%">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlMaterialName" class="form-control" runat="server">
                                        </asp:DropDownList>

                                        <asp:Label ID="lblMaterialID" Visible="false" Text='<%# Eval("MaterialID")%>' runat="server"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Qty" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQty" class="form-control" MaxLength="4" Text='<%# Eval("Qty")%>' runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="20%">
                                    <ItemTemplate>

                                        <asp:TextBox ID="txtRemark" class="form-control" Text='<%# Eval("Remarks")%>' runat="server"></asp:TextBox>


                                    </ItemTemplate>

                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="ButtonAdd" OnClick="ButtonAdd_Click" runat="server" ValidationGroup="e" CausesValidation="false" Text="Add New" CssClass="btn yellow-gold" />

                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>


                                        <asp:ImageButton ID="btnRemove" CausesValidation="false" runat="server" CommandName="Delete" ToolTip="Delete"
                                            ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this record?');" />


                                    </ItemTemplate>



                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>

                    <div class="row">
                        <div class="text-center" style="padding: 10px; margin: 0; background-color: #f5f5f5; border-top: 1px solid #e7ecf1">

                            <asp:Button ID="btnSubmit" runat="server" ValidationGroup="aa" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btnSubmit_Click" />

                            <asp:Button ID="btnClear" runat="server" ValidationGroup="aa" Visible="false" Text="Clear" class="btn blue" ClientIDMode="Static" OnClick="btnClear_Click" />

                        </div>

                    </div>
                </div>

            </div>
        </div>


    </div>
</asp:Content>
