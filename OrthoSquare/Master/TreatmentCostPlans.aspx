<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="TreatmentCostPlans.aspx.cs" Inherits="OrthoSquare.Master.TreatmentCostPlans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" language="javascript">
        function SelectAllCheckboxesEmp(spanChk) {

            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].id.indexOf("chkCtrl") != -1) {
                        if (elm[i].checked != xState)
                            elm[i].click();
                    }


                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="page-content" id="Add" visible="false"  runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Treatment Cost Plans</span>
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
                            <span class="caption-subject bold uppercase">Treatment Cost Plans</span>
                        </div>
                       
                    </div>
                    <div class="row">

                        <div class="col-md-6 ">

                            <div class="portlet-body form">

                                <div class="form-body">

                                    <div class="form-group">
                                        <label>Treatment Name</label>
                                        

                                        <asp:DropDownList ID="ddlCategory" class="form-control" runat="server"></asp:DropDownList>
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
                                        
                                </div>
                            </div>
                            </div>
                        

                            <!-- Usage as a class -->
                       <div class="text-right mb-20">
                                 
                                 </div>


                                    <div class="form-group">
                                        <label>Treatment</label>
                                       <div class="table-scrollable">
                             
                            <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover"
                                    GridLines="None" DataKeyNames="TreatmentID" AutoGenerateColumns="false" 
                                    ShowHeaderWhenEmpty="true" AllowPaging="true"
                                    OnPageIndexChanging="gvShow_PageIndexChanging">
                                  <Columns >
                                        <asp:TemplateField  >
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkSelectAllEmp" runat="server" onclick="javascript:SelectAllCheckboxesEmp(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkCtrl" runat="server" />
                                                <asp:Label ID="lblTreatmentID" runat="server" Visible="false" Text='<%# Bind("TreatmentID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                    </Columns>
                           
                            
                                    <Columns>



                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("TreatmentID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="60%" HeaderText="Treatment Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("TreatmentName") %>' class="form-control input-sm"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField ItemStyle-Width="60%" HeaderText="Treatment Cost">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCost" runat="server" Text='<%# Eval("TreatmentCost") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtTCost" runat="server" Text='<%# Eval("TreatmentCost") %>' class="form-control input-sm"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                     
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <EmptyDataTemplate>
                                        No Record Available</EmptyDataTemplate>
                                </asp:GridView>
                        </div>
                                    </div>
                                        </div>




                                </div>
                            </div>

                        </div>


                        <div class="col-md-6">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">

                                        <div class="form-group">
                                            <label></label>
                                            
                                        </div>
                                       


                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- END CONTENT BODY -->
                    </div>
                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />
                           
                            <asp:Button ID="btBack" runat="server" Text="Cancel" OnClick="btnclear_Click"  Class="btn default" ClientIDMode="Static"
                                CausesValidation="False"  />


                        </div>

                    </div>
                </div>
            </div>
            <!-- END CONTENT BODY -->
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
                    <span>Treatment Cost Plans</span>
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
                            <span class="caption-subject font-red sbold uppercase">Treatment Cost Plans</span>
                        </div>
                        
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-6">
                               <div class="form-group">
                                                <label>Search</label>
                                    

                                   <asp:DropDownList ID="ddlCategorySearch" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategorySearch_SelectedIndexChanged"></asp:DropDownList>
                                  
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group form-md-line-input ">
                                  
                                        
                                </div>
                            </div>
                            </div>
                        

                            <!-- Usage as a class -->
                       <div class="text-right mb-20">
                                 <asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                            CausesValidation="False" OnClick="btnAddNew_Click" />
                                 </div>
                        <div class="table-scrollable">
                             
                            <asp:GridView ID="GridTreatmentCostPlans" runat="server" class="table table-bordered table-hover"
                                    GridLines="None" DataKeyNames="TreatmentCostPlansid" AutoGenerateColumns="false" 
                                    OnRowDeleting="GridTreatmentCostPlans_RowDeleting" 
                                     ShowHeaderWhenEmpty="true" AllowPaging="true"
                                    OnPageIndexChanging="GridTreatmentCostPlans_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField  HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("TreatmentCostPlansid") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField  HeaderText="Category Name">
                                            <ItemTemplate>
                                              <asp:Label ID="lblName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-Width="30%" HeaderText="Treatment Name">
                                            <ItemTemplate>
                                              <asp:Label ID="lblTreatmentName" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        
                                        

                                        <asp:TemplateField ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lbtDelete" runat="server" CommandName="delete" ImageUrl="../Images/delete15x15.png"
                                                    CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this Treatment Cost Plans?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <EmptyDataTemplate>
                                        No Record Available</EmptyDataTemplate>
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
