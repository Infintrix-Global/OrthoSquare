<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ViewRequestStock.aspx.cs" Inherits="OrthoSquare.Material.ViewRequestStock" %>

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
    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <asp:Panel ID="Mlist" runat="server">
        <div id="Div1" runat="server" class="page-content">
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="icon-home"></i>
                        <a href="index-2.html">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <span>View Request Inventory </span>
                    </li>
                </ul>

            </div>
            <div class="row">
                <div class="col-md-12 pad">
                    <div class="portlet light portlet-fit portlet-form bordered">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-red"></i>
                                <span class="caption-subject font-red sbold uppercase">View Request Inventory </span>
                            </div>

                        </div>
                        <div class="portlet-body">
                            <!-- BEGIN FORM-->
                            <div class="form-body">

                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Clinic Name 
                                            </label>
                                            <asp:DropDownList ID="ddlClinic" class="form-control" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>


                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Inventory Type
                                            </label>
                                            <asp:DropDownList ID="ddlMaterialType" class="form-control" OnSelectedIndexChanged="ddlMaterialType_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>


                                        </div>
                                    </div>


                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Item Name
                                            </label>


                                            <asp:TextBox ID="txtMaterial" runat="server" OnTextChanged="txtMaterial_TextChanged" placeholder="Item Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                            <cc1:AutoCompleteExtender ServiceMethod="SearchMaterial"
                                                MinimumPrefixLength="2"
                                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                TargetControlID="txtMaterial"
                                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                            </cc1:AutoCompleteExtender>


                                        </div>
                                    </div>

                                </div>
                                <div class="row">


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
                                            <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                Enabled="True" TargetControlID="txtToDate">
                                            </asp:CalendarExtender>


                                        </div>
                                    </div>
                                    <div class="col-md-3" style="margin-top: 25px;">
                                        <div class="form-group">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                                CausesValidation="False" OnClick="btnSearch_Click" />

                                        </div>
                                    </div>
                                </div>


                                <div class="text-right mb-20">
                                    Total :
                                            <asp:Label ID="lblTotalTop" runat="server" Text=""></asp:Label>
                                </div>

                                <div class="table-scrollable">

                                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" PageSize="31" DataKeyNames="RequestCode,ClinicName,ClinicId,CreateOn" OnRowCommand="gvShow_RowCommand"
                                        class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound">


                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo11" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clinic Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Order No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("RequestCode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreateOn" runat="server" Text='<%# Eval("CreateOn","{0:dd/MMM/yyyy}")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>


                                                    <asp:Button ID="btnview" CommandName="Assign" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' class="btn blue-madison" runat="server" Text="Assign Inventory" />


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


    <asp:Panel ID="PanelAdd" Visible="false" runat="server">
        <div id="Div2" runat="server" class="page-content">
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="icon-home"></i>
                        <a href="index-2.html">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <span>Assign Inventory </span>
                    </li>
                </ul>

            </div>
            <div class="row">
                <div class="col-md-12 pad">
                    <div class="portlet light portlet-fit portlet-form bordered">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-red"></i>
                                <span class="caption-subject font-red sbold uppercase">Assign Inventory</span>
                            </div>

                        </div>
                        <div class="portlet-body">
                            <!-- BEGIN FORM-->
                            <div class="form-body">

                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Clinic Name 
                                            </label>
                                            <asp:TextBox ID="txtClinicNameShow" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lblClinicId" Visible="false" runat="server" Text=""></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Order Date
                                            </label>
                                            <asp:TextBox ID="txtROderDate" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>



                                        </div>
                                    </div>


                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="form_control_1">
                                                Date
                                            </label>


                                            <asp:TextBox ID="txtDate" runat="server" placeholder="Material Name" class="form-control"></asp:TextBox>

                                            <asp:CalendarExtender ID="txtBDate_CalendarExtender" runat="server" Enabled="True" OnClientDateSelectionChanged="checkDate1"
                                                TargetControlID="txtDate" Format="dd-MM-yyyy">
                                            </asp:CalendarExtender>
                                        </div>
                                    </div>

                                </div>

                                <br />

                                <div class="table-scrollable">

                                    <asp:GridView ID="gvAssignMaterial" runat="server" AutoGenerateColumns="false" PageSize="31" OnRowDataBound="gvAssignMaterial_RowDataBound"
                                        class="table table-bordered table-hover">

                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr. No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo1" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inventory Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMaterialNameType" runat="server" Text='<%# Eval("MaterialNameType") %>'></asp:Label>
                                                    <asp:Label ID="lblMaterialTypeId" Visible="false" runat="server" Text='<%# Eval("MaterialTypeId") %>'></asp:Label>
                                                </ItemTemplate>


                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Item Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("MaterialName")%>'></asp:Label>
                                                    <asp:Label ID="lblMaterialId" Visible="false" runat="server" Text='<%# Eval("MaterialId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Packaging">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPackName" runat="server" Text='<%# Eval("PackName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total Stock">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCurrentStock" runat="server" Text='<%# Eval("CurrentStock")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField HeaderText="Request Stock">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClinicQty" runat="server" Text='<%# Eval("Qty")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Assign Stock">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAssign" Width="80px" class="form-control minInp" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField Visible="false" HeaderText="Order No">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlOrderNo" AutoPostBack="true" class="form-control" runat="server">
                                                    </asp:DropDownList>

                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPrice" Width="80px" class="form-control minInp" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>

                                                    <asp:TextBox ID="txtRemark" class="form-control" Text="" runat="server"></asp:TextBox>


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

                                <div class="row">
                                    <div class="form-actions text-center">

                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn blue" ValidationGroup="e" OnClick="btnSubmit_Click" />

                                        <asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static" OnClick="btBack_Click"
                                            CausesValidation="False" />


                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- / .panel -->
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>

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
