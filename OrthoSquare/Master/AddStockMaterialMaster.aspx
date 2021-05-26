<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="AddStockMaterialMaster.aspx.cs" Inherits="OrthoSquare.Master.AddStockMaterialMaster" %>

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



    <div class="page-content" id="Add"  runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Add Material</span>
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
                            <span class="caption-subject bold uppercase"><span>Add Material</span>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">

                                <div class="col-sm-4">
                                    <label for="form_control_1">
                                        Clinic Name 
                                    </label>
                                    <asp:DropDownList ID="ddlClinic" class="form-control" runat="server" ></asp:DropDownList>

                                </div>
                                <div class="col-sm-4">
                                   <%-- <label>Doctor Name</label>

                                    <asp:DropDownList ID="ddlDoctor" class="form-control" runat="server"></asp:DropDownList>
                              --%>
                                    
                                      </div>
                            </div>
                        </div>

                    </div>
                    <br />  <br />
                    <div class="table-responsive">
                        <asp:GridView ID="Gridplaceorder" runat="server" AutoGenerateColumns="false"
                            class="table table-striped table-bordered table-hover" DataKeyNames="MaterialId"
                            GridLines="None"
                            ShowHeaderWhenEmpty="true" OnRowDataBound="Gridplaceorder_RowDataBound">

                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:SelectAllCheckboxes11(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelectMaterialId" runat="server" />

                                        <asp:Label ID="LabelMaterialId" runat="server" Visible="false" Text='<%# Bind("MaterialId") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>



                            <Columns>


                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <asp:Label ID="SrNo1" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Material Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>

                                    </ItemTemplate>

                                </asp:TemplateField>

                                 <asp:TemplateField  HeaderText="Unit">
                                    <ItemTemplate>

                                        <asp:DropDownList ID="ddlUnit" class="form-control" runat="server"></asp:DropDownList>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOrderQty" Width="100px" class="form-control"  runat="server"></asp:TextBox>
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
                    
                    <br />

                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />

                            <%--    <asp:Button ID="btBack" runat="server" Text="Cancel"   Class="btn default" ClientIDMode="Static"
                                CausesValidation="False"  />--%>
                        </div>

                    </div>

                    <!-- END CONTENT BODY -->
                </div>

            </div>
        </div>


    </div>
    </span>
</asp:Content>
