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
                       
                    </div>
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>


                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-6">
                                            <label>Unit Type</label>
                                            <asp:RadioButtonList ID="RadioBtnIsMedical" RepeatDirection="Horizontal"
                                                Width="300px" runat="server">
                                                <asp:ListItem Text="Material">Material</asp:ListItem>
                                                <asp:ListItem Text="Medicine">Medicine</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label>Unit Name</label>
                                                <asp:TextBox ID="txtAdd" class="form-control"
                                                    runat="server"></asp:TextBox>


                                                <span class="help-block">
                                                    <asp:RequiredFieldValidator ID="RequiredtxtAdd" runat="server" ControlToValidate="txtAdd"
                                                        SetFocusOnError="true" ErrorMessage="Please Enter Unit Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </span>
                                            </div>
                                        </div>


                                    </div>

                                </div>
                            </div>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />
                           
                            <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btnclear_Click"  Class="btn default" ClientIDMode="Static"
                                CausesValidation="False"  />


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
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Search</label>
                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                        ClientIDMode="Static"></asp:TextBox>

                                </div>
                            </div>


                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Search</label>
                                    <asp:RadioButtonList ID="RadioBtnIsMedicalSearch" RepeatDirection="Horizontal"
                                                Width="300px" runat="server">
                                                <asp:ListItem Value="Material">Material</asp:ListItem>
                                                <asp:ListItem Value="Medicine">Medicine</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="All">All</asp:ListItem>
                                            </asp:RadioButtonList>

                                </div>
                            </div>

                             

                            <div class="col-md-4">
                                <div class="form-group form-md-line-input ">
                                    <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                        OnClick="btSearch_Click" />

                                    <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn blue-hoki" ClientIDMode="Static"
                                        OnClick="btnClear_Click" />





                                </div>
                            </div>
                        </div>


                        <!-- Usage as a class -->
                        <div class="text-right mb-20">
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New Unit" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />
                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover"
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
                                    <asp:TemplateField HeaderText="Unit Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsMedical" runat="server" Text='<%# Eval("IsMedical") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageEdit" CommandArgument='<%# Eval("UnitId") %>' ToolTip="Edit" runat="server" CommandName="Edit1" ImageUrl="../Images/edit15x15.png"
                                                CausesValidation="False" />

                                            <asp:ImageButton ID="lbtDelete" ToolTip="Delete" runat="server" CommandName="delete" ImageUrl="../Images/delete15x15.png"
                                                CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this Unit Name?');" />
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
