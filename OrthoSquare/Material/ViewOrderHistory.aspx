<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ViewOrderHistory.aspx.cs" Inherits="OrthoSquare.Material.ViewOrderHistory" %>

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
                        <span>View Order History</span>
                    </li>
                </ul>

            </div>
            <div class="row">
                <div class="col-md-12 pad">
                    <div class="portlet light portlet-fit portlet-form bordered">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-red"></i>
                                <span class="caption-subject font-red sbold uppercase">View Order History</span>
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


                                            <asp:TextBox ID="txtMaterial" runat="server" OnTextChanged="txtMaterial_TextChanged" placeholder="Material Name" AutoPostBack="true" class="form-control"></asp:TextBox>

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

                                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" PageSize="31" 
                                        class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound">


                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo11" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clinic Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClinicNamereq" runat="server" Text='<%# Eval("ClinicName")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreateOn" runat="server" Text='<%# Eval("CreateOn","{0:dd/MMM/yyyy}")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Order No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRequestCode" Visible="false" runat="server" Text='<%# Eval("RequestCode")%>'></asp:Label>

                                                    <asp:HyperLink ID="HyperLink1" Class="d1" Text='<%# Eval("RequestCode") %>' runat="server"></asp:HyperLink>


                                                    <asp:Panel ID="Panel1" runat="server" Style="display: none">
                                                        <asp:GridView ID="gvviewOrder" runat="server" AutoGenerateColumns="false" PageSize="31"
                                                            class="table table-bordered table-hover">


                                                            <Columns>


                                                                <asp:TemplateField HeaderText="Item Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>


                                                                    </ItemTemplate>


                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Request Stock">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRequestQty" runat="server" Text='<%# Eval("RequestQty")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Receive Stock">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblReceiveQty" runat="server" Text='<%# Eval("ReceiveQty")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>



                                                                <asp:TemplateField HeaderText="Actual Stock">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblActualQty" runat="server" Text='<%# Eval("ActualQty")%>'></asp:Label>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Clinic Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName")%>'></asp:Label>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Received Stock">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblreceivedqty" runat="server" Text='<%# Eval("DoctorName")%>'></asp:Label>
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
