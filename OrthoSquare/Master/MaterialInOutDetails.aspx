<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="MaterialInOutDetails.aspx.cs" Inherits="OrthoSquare.Master.MaterialInOutDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


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
                    <span>Add MATERIAL</span>
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
                            <span class="caption-subject bold uppercase">                    <span>Add MATERIAL</span>
</span>
                        </div>
                       
                    </div>





                    <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-6">
                                         <label>Vendor Name<span class="required">*</span></label>
                                       
                                       

                                        <asp:DropDownList ID="ddlVendor" class="form-control" runat="server"></asp:DropDownList>
                                          <span class="help-block">
                                                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorlVendor"  runat ="server" ControlToValidate="ddlVendor"
                                                             InitialValue="0" SetFocusOnError="true" ErrorMessage="Please Enter Vendor Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                   </span>
                                    </div>

                                    <div class="col-sm-6">
                                         <label>Material Name </label>

                                                  
                                        
                                        <asp:DropDownList ID="ddlMaterial" class="form-control" runat="server" OnSelectedIndexChanged="ddlMaterial_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                    <span class="help-block">
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorMaterial"  runat ="server" ControlToValidate="ddlMaterial"
                                                             InitialValue="0" SetFocusOnError="true" ErrorMessage="Please Enter Material Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>
                                    </div>
                                </div>

                                </div>
                            </div>
                   
                    <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-6">
                                         <label>Brand Name<span class="required">*</span></label>


                                        <asp:TextBox ID="txtBrandName" class="form-control" runat="server"></asp:TextBox>
                                       
                                          <span class="help-block">
                                                            
                                                                   </span>
                                    </div>

                                    <div class="col-sm-6">
                                         <label>Price</label>

                                                  
                                          <asp:TextBox ID="txtPrice" class="form-control" runat="server"></asp:TextBox>
                                         
                                             <span class="help-block">
                                                         
                                                    </span>
                                    </div>
                                </div>

                                </div>
                            </div>
                      <br />
                    <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-6">
                                         <label>Order Qty<span class="required">*</span></label>


                                        <asp:TextBox ID="txtOrderQty" class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtOrderQty_TextChanged"></asp:TextBox>
                                       
                                          <span class="help-block">
                                                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderQty"  runat ="server" ControlToValidate="txtOrderQty"
                                                              SetFocusOnError="true" ErrorMessage="Please Enter Order Qty" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                   </span>
                                    </div>

                                    <div class="col-sm-6">
                                         <label>Total </label>

                                                  
                                          <asp:TextBox ID="txtTotal" class="form-control" runat="server"></asp:TextBox>
                                        
                                    </div>
                                </div>

                                </div>
                            </div>
               


                    <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-6">
                                          <label>Order Date </label>

                                                  
                                          <asp:TextBox ID="txtOrderDate" class="form-control" runat="server"></asp:TextBox>
                                         <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True"
                                                                    TargetControlID="txtOrderDate" Format="dd-MM-yyyy">
                                                                </asp:CalendarExtender>
                                                    <span class="help-block">
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat ="server" ControlToValidate="txtOrderDate"
                                                             InitialValue="0" SetFocusOnError="true" ErrorMessage="Please Enter Order Date" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>
                                    </div>

                                    <div class="col-sm-6">
                                       
                                    </div>
                                </div>

                                <%--</div>--%>
                            </div>
                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />
                           
                            <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btnclear_Click"  Class="btn default" ClientIDMode="Static"
                                CausesValidation="False"  />


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
                            <span>Add MATERIAL</span>

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
                            <span class="caption-subject font-red sbold uppercase">Add MATERIAL</span>
                        </div>

                    </div>
                    <div class="portlet-body">


                        <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-4">
                                         <label>Vendor Name<span class="required">*</span></label>
                                       
                                       

                                        <asp:DropDownList ID="ddlvenderSearch" class="form-control" runat="server"></asp:DropDownList>
                                          <span class="help-block">
                                                             
                                                                   </span>
                                    </div>

                                    <div class="col-sm-4">
                                         <label>Material Name </label>

                                                  
                                        
                                        <asp:DropDownList ID="ddlMaterialSearch" class="form-control" runat="server"></asp:DropDownList>
                                                    <span class="help-block">
                                                        
                                                    </span>
                                    </div>

                                    <div class="col-sm-4">
                                         <label></label>

                                                  
                                        
                                       <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                        OnClick="btSearch_Click" />
                                                    <span class="help-block">
                                                        
                                                    </span>
                                    </div>
                                </div>

                                </div>
                            </div>


                        


                        <!-- Usage as a class -->
                        <div class="text-right mb-20">

                         
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                CausesValidation="False" OnClick="btnAddNew_Click" />

                        </div>
                        <div class="table-scrollable">

                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-striped table-bordered table-hover" DataKeyNames="InoutID"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                OnRowDeleting="gvShow_RowDeleting" OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true" OnRowDataBound="gvShow_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No." >
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Vendor Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Brand Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrandname" runat="server" Text='<%# Eval("BrandName")  %>'>  </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Material Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaterialName" runat="server" Text='<%# Eval("MaterialName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Pack Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPackName" runat="server" Text='<%# Eval("PackName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Order Qty" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Order Total" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text ="" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Order Date" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("OrderDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Receive Qty" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceiveQty" runat="server" Text='<%# Eval("ReceiveQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Receive Total" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalRec" runat="server" Text ="" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Received Date" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceiveddate" runat="server" Text='<%# Eval("Receiveddate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="" >
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" CommandArgument='<%# Eval("InoutID") %>' ToolTip="Edit"
                                                CommandName="EditDocterDetails" ImageUrl="../Images/right15x15.png" />

                                         

                                            <asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete" ToolTip="Delete"
                                                ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this in Out Order?');" />

                                            <asp:ImageButton ID="btnUpdate1" CausesValidation="false" runat="server" CommandArgument='<%# Eval("InoutID") %>'  ToolTip ="Add Received Order"
                                                CommandName="EditInouttime" ImageUrl="../Images/view1.png" />


                                            

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

            </div>

        </div>

    </div>
    
               <div class="page-content" id="Div2" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>In Out MATERIAL</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblmsg1" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">In Out MATERIAL</span>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">

                                <div class="col-sm-4">
                                    <label>Receive Qty</label>

                                    <asp:TextBox ID="txtReceiveQty" class="form-control"
                                        runat="server"></asp:TextBox>




                                </div>
                                <div class="col-sm-4">
                                    <label>Received Date</label>


                                    <asp:TextBox ID="txtReceiveddate" class="form-control"
                                        runat="server"></asp:TextBox>

                                      <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                                    TargetControlID="txtReceiveddate" Format="dd-MM-yyyy">
                                                                </asp:CalendarExtender>


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
            <!-- END CONTENT BODY -->
        </div>


    </div>

            </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>
