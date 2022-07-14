<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="AreaManagerReport.aspx.cs" Inherits="OrthoSquare.Report.AreaManagerReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= ResolveUrl("~/JS1/jquery.min.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Edit" runat="server">
        <div id="Div1" runat="server" class="page-content">
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="icon-home"></i>
                        <a href="index-2.html">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <span>Area Manager Report</span>
                    </li>
                </ul>

            </div>
            <div class="row">
                <div class="col-md-12 pad">
                    <div class="portlet light portlet-fit portlet-form bordered">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="icon-settings font-red"></i>
                                <span class="caption-subject font-red sbold uppercase">Area Manager Report</span>
                            </div>
                            <%--<div class="actions">
							<div class="btn-group btn-group-devided" data-toggle="buttons">
								<label class="btn grey-salsa btn-sm active">
									<input type="radio" name="options" class="toggle" id="option1">Actions</label>
								<label class="btn grey-salsa btn-sm">
									<input type="radio" name="options" class="toggle" id="option2">Settings</label>
							</div>
						</div>--%>
                        </div>
                        <div class="portlet-body">
                            <!-- BEGIN FORM-->
                            <div class="form-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">

                                            <asp:TextBox ID="txtDocter" runat="server" OnTextChanged="txtDocter_TextChanged" placeholder="Area Manager Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                            <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                                MinimumPrefixLength="2"
                                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                TargetControlID="txtDocter"
                                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                            </cc1:AutoCompleteExtender>

                                        </div>
                                    </div>


                                    <div class="col-md-3">
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

                                    <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound"
                                        OnPageIndexChanging="gvShow_PageIndexChanging">

                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                                    <asp:Label ID="lblDoctorId" Visible="false" runat="server" Text='<%# Eval("DoctorId")%>'></asp:Label>


                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField HeaderText="Area Manager">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# Eval("DoctorName")%>'></asp:Label>

                                                    <asp:HyperLink ID="HyperLink1" Class="d1" Text='<%# Eval("DoctorName") %>' runat="server"></asp:HyperLink>
                                                    <%-- <img alt="" style="cursor: pointer" src="../Images/plus.png" runat="server" id="img" />--%>


                                                    <asp:Panel ID="Panel1" runat="server" Style="display: none">
                                                        <asp:GridView ID="gvClinicPay" runat="server" AutoGenerateColumns="false" PageSize="31"
                                                            class="table table-bordered table-hover">


                                                            <Columns>


                                                                <asp:TemplateField HeaderText="Clinic Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>


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

                                <div class="text-left mb-20">
                                    <asp:ImageButton ID="btExcel" runat="server" Height="40px"
                                        ImageUrl="~/Images/excel-icon.png" Text="Download" ToolTip="Download" Width="40px"
                                        OnClick="btExcel_ClickClinic" />
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
