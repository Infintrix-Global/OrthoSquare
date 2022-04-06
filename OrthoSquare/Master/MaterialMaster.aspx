<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="MaterialMaster.aspx.cs" Inherits="OrthoSquare.Master.MaterialMaster" %>
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
                    <span>MATERIAL</span>
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
                            <span class="caption-subject bold uppercase">MATERIAL</span>
                        </div>
                       
                    </div>

                      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-6">
                                            <label>Material Type </label>

                                            <%--<asp:TextBox ID="txtBrandname" class="form-control" placeholder="Enter Brand" TabIndex ="15" runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlMaterialType" class="form-control" runat="server"></asp:DropDownList>
                                            <span class="help-block"></span>
                                        </div>

                                        <div class="col-sm-6">
                                        </div>


                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-6">
                                            <label>Brand Name </label>

                                            <%--<asp:TextBox ID="txtBrandname" class="form-control" placeholder="Enter Brand" TabIndex ="15" runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlBrand" class="form-control" runat="server"></asp:DropDownList>
                                            <span class="help-block"></span>
                                        </div>

                                        <div class="col-sm-6">
                                            <label>Material Name<span class="required">*</span></label>

                                            <asp:TextBox ID="txtAdd" class="form-control" placeholder="Material Name"
                                                runat="server"></asp:TextBox>

                                            
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlDesignation" runat="server" ControlToValidate="txtAdd"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Material Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                          
                                        </div>


                                    </div>

                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-6">
                                            <label>Pack </label>

                                            <%--<asp:TextBox ID="txtBrandname" class="form-control" placeholder="Enter Brand" TabIndex ="15" runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlPack" class="form-control" runat="server"></asp:DropDownList>
                                           
                                        </div>

                                        <div class="col-sm-6">
                                            <label>Price<span class="required">*</span></label>

                                            <asp:TextBox ID="txtPrice" Text="0" class="form-control" placeholder="Price"
                                                runat="server"></asp:TextBox>

                                          
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server"
                                                    Display="Dynamic" ErrorMessage="Please enter only numeric value." ControlToValidate="txtPrice"
                                                    SetFocusOnError="True" ValidationExpression="^\d+$" ForeColor="Red"></asp:RegularExpressionValidator>

                                        </div>


                                    </div>

                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
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
                    <span>MATERIAL</span>
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
                            <span class="caption-subject font-red sbold uppercase">MATERIAL</span>
                        </div>
                        
                    </div>
                    <div class="portlet-body">
                         <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Search</label>
                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                        ClientIDMode="Static"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-6">
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
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New Material" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />
                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover"
                                GridLines="None" DataKeyNames="MaterialId" AutoGenerateColumns="false"
                                OnRowDeleting="gvShow_RowDeleting"
                                ShowHeaderWhenEmpty="true" AllowPaging="true"
                                OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("MaterialId") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Material Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaterialType" runat="server" Text='<%# Eval("MaterialType") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Material Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Brand Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrandname" runat="server" Text='<%# Eval("BrandName") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pack Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPackName" runat="server" Text='<%# Eval("PackName") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" ToolTip="Edit" runat="server" CommandName="Update1" ImageUrl="../Images/edit15x15.png"
                                                CausesValidation="False" CommandArgument='<%# Eval("MaterialId") %>' ItemStyle-Width="5%" />

                                            <asp:ImageButton ID="lbtDelete" ToolTip="Delete" runat="server" CommandName="delete" ImageUrl="../Images/delete15x15.png"
                                                CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this Material?');" />
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
