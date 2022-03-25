<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ReceiveMaterialbyClinic.aspx.cs" Inherits="OrthoSquare.Master.ReceiveMaterialbyClinic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <span>Receive Material</span>

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
                            <span class="caption-subject font-red sbold uppercase">Receive Material</span>
                        </div>

                    </div>
                    <div class="portlet-body">


                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <label>Vendor Name<span class="required">*</span></label>



                                        <asp:DropDownList ID="ddlvenderSearch" class="form-control" placeholder="Vendor Name" runat="server"></asp:DropDownList>
                                        <span class="help-block"></span>
                                    </div>

                                    <div class="col-sm-4">
                                        <label>Material Name </label>



                                        <asp:DropDownList ID="ddlMaterialSearch" class="form-control" runat="server"></asp:DropDownList>
                                        <span class="help-block"></span>
                                    </div>

                                    <div class="col-sm-4">
                                        <label></label>



                                        <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                            OnClick="btSearch_Click" />
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                            </div>
                        </div>





                        <!-- Usage as a class -->
                        <div class="text-right mb-20">
                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-striped table-bordered table-hover" DataKeyNames="InoutID"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                ShowHeaderWhenEmpty="true" OnRowDataBound="gvShow_RowDataBound">

                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:SelectAllCheckboxes11(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelectMaterialId" runat="server" />

                                            <asp:Label ID="LabelMaterialId" runat="server" Visible="false" Text='<%# Bind("InoutID") %>'></asp:Label>
                                            <asp:Label ID="lblMaterialId" runat="server" Visible="false" Text='<%# Bind("MaterialId") %>'></asp:Label>
                                            <asp:Label ID="lblVendorID" runat="server" Visible="false" Text='<%# Bind("VendorID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>



                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Material Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Brand Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrandname" runat="server" Text='<%# Eval("Brandname")  %>'>  </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Clinic Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Doctor Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDname" runat="server" Text='<%# Eval("Dname") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("OrderDate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Recived Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtOrderRecQty" TextMode="Number" Width="100px" runat="server"></asp:TextBox>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Recived Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRecivedDate" Width="110px" runat="server"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True"
                                                TargetControlID="txtRecivedDate" Format="dd-MM-yyyy">
                                            </asp:CalendarExtender>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Pending Order Qty">
                                        <ItemTemplate>

                                            <asp:Label ID="lblPending" runat="server" Text=""></asp:Label>

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

                                    <div class="col-sm-4">
                                        <label for="form_control_1">
                                            Clinic Name 
                                        </label>
                                        <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged1"></asp:DropDownList>





                                    </div>
                                    <div class="col-sm-4">
                                        <label>Doctor Name</label>

                                        <asp:DropDownList ID="ddlDoctor" class="form-control" runat="server"></asp:DropDownList>




                                    </div>
                                </div>
                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="form-actions text-center">

                                <asp:Button ID="btnUpdateIOtime" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btnUpdateIOMaterial_Click" />

                                <asp:Button ID="btnIOCancel" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                    CausesValidation="False" OnClick="btnIOCancel_Click" />


                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>



</asp:Content>
