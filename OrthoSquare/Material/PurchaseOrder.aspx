<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="OrthoSquare.Material.PurchaseOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="<%= ResolveUrl("~/JS1/jquery.min.js") %>"></script>

    <script type="text/javascript">
        function checkDate1(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select future Date!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
    </script>
    <script type="text/javascript">
        function InIEvent() {
            if ($('.jsDatePicker').length > 0) {
                $('.jsDatePicker').datepicker();
            }

            if ($('.multiSelect').length > 0) {
                $('.multiSelect').multiselect({
                    nonSelectedText: '--- Select ---',
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Panel ID="Panellist" runat="server">
        <div id="Div1" runat="server" class="page-content">
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="icon-home"></i>
                        <a href="index-2.html">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <span>Purchase Order</span>
                    </li>
                </ul>

            </div>
            <div class="row">
                <div class="col-md-12 pad">
                    <div class="portlet light portlet-fit portlet-form bordered">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-red"></i>
                                <span class="caption-subject font-red sbold uppercase">Purchase Order</span>
                            </div>

                        </div>
                        <div class="portlet-body">
                            <!-- BEGIN FORM-->
                            <div class="form-body">

                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Vendor Name 
                                            </label>

                                            <asp:TextBox ID="txtVendor" runat="server" OnTextChanged="txtVendor_TextChanged" placeholder="Vendor Name " AutoPostBack="true" class="form-control"></asp:TextBox>

                                            <cc1:AutoCompleteExtender ServiceMethod="SearchVendorName"
                                                MinimumPrefixLength="2"
                                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                TargetControlID="txtVendor"
                                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                            </cc1:AutoCompleteExtender>

                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                From Date
                                            </label>

                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control" placeholder="From Date"
                                                ClientIDMode="Static"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server"
                                                Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                            </asp:CalendarExtender>


                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                To Date
                                            </label>

                                            <asp:TextBox ID="txtToDate" runat="server" class="form-control" placeholder="To Date"
                                                ClientIDMode="Static"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy"
                                                Enabled="True" TargetControlID="txtToDate">
                                            </asp:CalendarExtender>


                                        </div>
                                    </div>
                                    <div class="col-md-3" style="margin-top: 25px;">
                                        <div class="form-group">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static" OnClick="btnSearch_Click"
                                                CausesValidation="False" />
                                            <asp:Button ID="btnAddNew" runat="server" Text="Add New Order" class="btn blue-madison" ClientIDMode="Static"
                                                CausesValidation="False" OnClick="btnAddNew_Click" />
                                        </div>
                                    </div>
                                </div>



                                <div class="text-right mb-20">
                                    Total :
                                            <asp:Label ID="lblTotalTop" runat="server" Text=""></asp:Label>
                                </div>

                                <div class="table-scrollable">

                                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" PageSize="31"
                                        class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound">


                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo11" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Order No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPurchaseOrderId" Visible="false" runat="server" Text='<%# Eval("PurchaseOrderId")%>'></asp:Label>

                                                    <asp:HyperLink ID="HyperLink1" Class="d1" Text='<%# Eval("OrderCode") %>' runat="server"></asp:HyperLink>


                                                    <asp:Panel ID="Panel1" runat="server" Style="display: none">
                                                        <asp:GridView ID="gvviewOrder" runat="server" AutoGenerateColumns="false" PageSize="31"
                                                            class="table table-bordered table-hover">


                                                            <Columns>


                                                                <asp:TemplateField HeaderText="Item Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>

                                                                    </ItemTemplate>


                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Packaging">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPackName" runat="server" Text='<%# Eval("PackName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Order Qty">

                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>



                                                            </Columns>
                                                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                                            <PagerSettings Mode="NumericFirstLast" />
                                                            <EmptyDataTemplate>
                                                                No Record Available
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>

                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vendor Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Order Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("OrderDate","{0:dd/MMM/yyyy}")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Order Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderStatus" runat="server" Text='<%# Eval("OrderStatus")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>



                                        </Columns>
                                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <!-- / .panel -->
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>


    <div class="page-content" id="Add" visible="false" runat="server">


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Purchase Order</span>
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
                            <span class="caption-subject bold uppercase"><span>Purchase Order</span>
                        </div>

                    </div>

                    <br />


                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">

                                <asp:TextBox ID="txtPurchaseOrder" runat="server" class="form-control" placeholder="Purchase Order No"
                                    ClientIDMode="Static"></asp:TextBox>

                            </div>
                        </div>



                        <div class="col-md-3">
                            <div class="form-group">


                                <asp:DropDownList ID="ddlVendor" class="form-control" runat="server"></asp:DropDownList>

                                <span class="help-block">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlVendor" InitialValue="0" ValidationGroup="e"
                                        SetFocusOnError="true" ErrorMessage="Please Select Vendor" ForeColor="Red"></asp:RequiredFieldValidator>
                                </span>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:TextBox ID="txtDate" runat="server" class="form-control" placeholder="Purchase Order No"
                                    ClientIDMode="Static"></asp:TextBox>
                                <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                    Enabled="True" TargetControlID="txtDate">
                                </asp:CalendarExtender>

                            </div>
                        </div>
                    </div>




                    <div class="table-responsive">
                        <asp:GridView ID="GridMateialStock" class="table table-bordered table-hover" ShowFooter="true" runat="server" OnRowDeleting="GridMateialStock_RowDeleting"
                            AutoGenerateColumns="false" OnRowDataBound="GridMateialStock_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="RowNumber" Visible="false" HeaderText="NO." />
                                <asp:TemplateField HeaderText="Inventory Type" ItemStyle-Width="25%">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlMaterialType" OnSelectedIndexChanged="ddlMaterialType_SelectedIndexChanged" AutoPostBack="true" class="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hdnWOEmployeeID" runat="server" Value='<%# Eval("ID")%>'></asp:HiddenField>
                                        <asp:Label ID="lblMaterialTypeid" Visible="false" Text='<%# Eval("MaterialTypeId")%>' runat="server"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item Name" ItemStyle-Width="25%">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlMaterialName" class="form-control" runat="server">
                                        </asp:DropDownList>

                                        <asp:Label ID="lblMaterialID" Visible="false" Text='<%# Eval("MaterialID")%>' runat="server"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Packaging" ItemStyle-Width="25%">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPack" class="form-control" runat="server">
                                        </asp:DropDownList>

                                        <asp:Label ID="lblPack" Visible="false" Text='<%# Eval("PackId")%>' runat="server"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Stock" ItemStyle-Width="15%">
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

                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">

                                <asp:TextBox ID="txtshippingAddress" TextMode="MultiLine" runat="server" class="form-control" placeholder="Shipping Address"
                                    ClientIDMode="Static"></asp:TextBox>

                                <span class="help-block">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtshippingAddress" ValidationGroup="e"
                                        SetFocusOnError="true" ErrorMessage="Please Enter Shipping Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                </span>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">

                                <asp:TextBox ID="txtReMarks" TextMode="MultiLine" runat="server" class="form-control" placeholder="Remark"
                                    ClientIDMode="Static"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <br />
                    <div class="row">
                        <div class="text-center" style="padding: 10px; margin: 0; background-color: #f5f5f5; border-top: 1px solid #e7ecf1">

                            <asp:Button ID="btnSubmit" runat="server" ValidationGroup="e" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btnSubmit_Click" />

                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn blue" ClientIDMode="Static" OnClick="btnClear_Click" />

                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn blue" ClientIDMode="Static" OnClick="btnCancel_Click" />

                        </div>

                    </div>


                </div>

            </div>
        </div>


    </div>


    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "<%= ResolveUrl("~/Images/minus.png") %>");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "<%= ResolveUrl("~/Images/plus.png") %>");
            $(this).closest("tr").next().remove();
        });
    </script>


    <script type="text/javascript">
        $(".d1").on("click", function () {
            debugger
            if ($(this).hasClass('d2')) {
                $(this).closest("tr").next().remove();
                $(this).removeClass('d2');
            } else {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                $(this).addClass("d2");
            }


        });

    </script>
</asp:Content>
