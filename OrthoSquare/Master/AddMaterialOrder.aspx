<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="AddMaterialOrder.aspx.cs" Inherits="OrthoSquare.Master.AddMaterialOrder" %>

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
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                            <span>Add Material Order</span>

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
                            <span class="caption-subject font-red sbold uppercase">Add Material Order</span>
                        </div>

                    </div>
                    <div class="portlet-body">


                        <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-4">
                                        <label>Material Name </label>

                                                  
                                        
                                        <asp:DropDownList ID="ddlMaterialSearch" class="form-control" runat="server"></asp:DropDownList>
                                                    <span class="help-block">
                                                        
                                                    </span>
                                    </div>

                                    <div class="col-sm-4">
                                         <label></label>
                                           <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static" OnClick="btSearch_Click"  />
                                    </div>

                                    <div class="col-sm-4">
                                        
                                
                                    </div>
                                </div>

                                </div>
                            </div>


                          <div class="text-right mb-20">

                         
                            <asp:Button ID="btnAddNew" runat="server" Text="Add Order" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />

                        </div>


                        <!-- Usage as a class -->
                    
                        <%--<div class="table-scrollable">--%>
                            <div class="table-responsive">
                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-striped table-bordered table-hover" DataKeyNames="MaterialId"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" 
                              ShowHeaderWhenEmpty="true" OnRowDataBound="gvShow_RowDataBound" >
                                <Columns>
                                        <asp:TemplateField  HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("MaterialId") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Material Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="Brand Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBrandname" runat="server" Text='<%# Eval("BrandName") %>'></asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                       <asp:TemplateField  HeaderText="Pack Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPackName" runat="server" Text='<%# Eval("PackName") %>'></asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                       
                                   
                               
                                         <asp:TemplateField  HeaderText="In stock">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInstock" runat="server" Text='<%# Eval("TotalMaterial") %>'></asp:Label>
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
                        <%--</div>--%>
                    </div>
                </div>

            </div>

        </div>

    </div>
    
    <div class="page-content" id="Add" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Add Material Order</span>
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
                            <span class="caption-subject bold uppercase">                    <span>Add Material Order</span>

                        </div>
                       
                    </div>
                           <div class="table-responsive">
                    <asp:GridView ID="Gridplaceorder" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-striped table-bordered table-hover" DataKeyNames="MaterialId"
                                GridLines="None" OnPageIndexChanging="Gridplaceorder_PageIndexChanging" 
                              ShowHeaderWhenEmpty="true" OnRowDataBound="Gridplaceorder_RowDataBound">
                              
                         <Columns >
                            <asp:TemplateField  >
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:SelectAllCheckboxes11(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelectMaterialId" runat="server"  />
                             
                                    <asp:Label ID="LabelMaterialId" runat="server" Visible="false" Text='<%# Bind("MaterialId") %>'></asp:Label>
                              
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        
                        
                        
                          <Columns>


                                        <asp:TemplateField  HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="SrNo1" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                              
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Material Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>
                                            
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="Brand Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBrandname1" runat="server" Text='<%# Eval("BrandName") %>'></asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                       <asp:TemplateField  HeaderText="Pack Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPackName1" runat="server" Text='<%# Eval("PackName") %>'></asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice1"  runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                       
                                   

                                         <asp:TemplateField  HeaderText="Vendor Name">
                                            <ItemTemplate>
                                                   <asp:DropDownList ID="ddlVendor" class="form-control" runat="server"></asp:DropDownList>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>


                             
                               
                                         <asp:TemplateField  HeaderText="Order Qty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtOrderQty" TextMode="Number" Width="100px" AutoPostBack="true" OnTextChanged="Invoice_SelectedIndexChanged" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Cost">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCost" Enabled="false" TextMode="Number" Width="100px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>
                               <asp:TemplateField  HeaderText="Order Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtOrderDate" Width="110px" runat="server"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True"
                                                                    TargetControlID="txtOrderDate" Format="dd-MM-yyyy">
                                                                </asp:CalendarExtender>
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
                                           <asp:DropDownList ID="ddlClinic" class="form-control"  AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged1"></asp:DropDownList>





                                </div>
                                <div class="col-sm-4">
                                   <label>Doctor Name</label>
											 
										<asp:DropDownList ID="ddlDoctor"  class="form-control" runat="server"></asp:DropDownList>
									   
                                       


                                </div>
                            </div>
                        </div>

                    </div>
                         <br />
                  
                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btAdd" runat="server" Text="Place Order " class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />
                           
                        <%--    <asp:Button ID="btBack" runat="server" Text="Cancel"   Class="btn default" ClientIDMode="Static"
                                CausesValidation="False"  />--%>


                        </div>

                    </div>
              
            <!-- END CONTENT BODY -->
        </div>

</div>
    </div>


         </div>
  
</asp:Content>
