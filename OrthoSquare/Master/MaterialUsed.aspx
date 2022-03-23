<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="MaterialUsed.aspx.cs" Inherits="OrthoSquare.Master.MaterialUsed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="cc1" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <script src="chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function SelectAllCheckboxes11(spanChk) {

            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].id.indexOf("chkSelectMaterialId") != -1) {
                        if (elm[i].checked != xState)
                            elm[i].click();
                    }


                }
            }
        }
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                    <span>Add Received Material</span>

                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-settings font-red"></i>
                            <span class="caption-subject font-red sbold uppercase">Add Received Material</span>
                        </div>

                    </div>
                    <div class="portlet-body">


                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <div class="col-sm-4">
                                        

                                        <asp:TextBox ID="txtMaterial" runat="server" OnTextChanged="txtMaterial_TextChanged" placeholder="Material Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                        <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                            MinimumPrefixLength="2"
                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                            TargetControlID="txtMaterial"
                                            ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                        </cc1:AutoCompleteExtender>

                                        <asp:RequiredFieldValidator ID="RequiredFieldddl_DocterDetils" runat="server" ControlToValidate="txtMaterial"
                                            SetFocusOnError="true" ErrorMessage="Please Select Doctor" ForeColor="Red"></asp:RequiredFieldValidator>


                                        <asp:DropDownList ID="ddlMaterialSearch" Visible="false" class="form-control" runat="server"></asp:DropDownList>
                                        <span class="help-block"></span>
                                    </div>

                                    <div class="col-sm-4">
                                        <label></label>
                                        <asp:Button ID="btSearch" runat="server" Visible="false" Text="Search" class="btn blue-hoki" ClientIDMode="Static" OnClick="btSearch_Click" />
                                    </div>

                                    <div class="col-sm-4">
                                    </div>
                                </div>

                            </div>
                        </div>


                        <div class="text-right mb-20">
                        </div>


                        <!-- Usage as a class -->

                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-striped table-bordered table-hover" DataKeyNames="MaterialId"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowDataBound="gvShow_RowDataBound"
                                ShowHeaderWhenEmpty="true">


                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:SelectAllCheckboxes11(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelectMaterialId" runat="server" />

                                            <asp:Label ID="lblMaterialId" runat="server" Text='<%# Eval("MaterialId") %>' Visible="false"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>



                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

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


                                    <asp:TemplateField HeaderText="In stock">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInstock" runat="server" Text='<%# Eval("TotalMaterial") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Used Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtUsedQty" TextMode="Number" runat="server"></asp:TextBox>
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




                        <br />
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">

                                    <div class="col-sm-3">
                                        <label for="form_control_1">
                                            Clinic Name 
                                        </label>
                                        <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged1"></asp:DropDownList>





                                    </div>
                                    <div class="col-sm-3">
                                        <label>Doctor Name</label>

                                        <asp:DropDownList ID="ddlDoctor" class="form-control" runat="server"></asp:DropDownList>




                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Patient Name</label>

                                            <asp:DropDownList ID="ddlpatient" class="form-control" runat="server" AutoPostBack="True"></asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <br />

                        <div class="row">
                            <div class="form-actions text-center">

                                <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />
                                <%-- 
                            <asp:Button ID="btBack" runat="server" Text="Cancel"   Class="btn default" ClientIDMode="Static"
                                CausesValidation="False"  />--%>
                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }
    </script>
</asp:Content>
