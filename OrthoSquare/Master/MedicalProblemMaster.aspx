<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="MedicalProblemMaster.aspx.cs" Inherits="OrthoSquare.Master.MedicalProblemMaster" %>
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
                    <span>MEDICAL PROBLEM</span>
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
                            <span class="caption-subject bold uppercase">MEDICAL PROBLEM</span>
                        </div>
                       <%-- <div class="actions">
                            <div class="btn-group">
                                <a class="btn btn-sm green dropdown-toggle" href="javascript:;" data-toggle="dropdown">Actions
                                                <i class="fa fa-angle-down"></i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-pencil"></i>Edit </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-trash-o"></i>Delete </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-ban"></i>Ban </a>
                                    </li>
                                    <li class="divider"></li>
                                    <li>
                                        <a href="javascript:;">Make admin </a>
                                    </li>
                                </ul>
                            </div>
                        </div>--%>
                    </div>
                    <div class="row">

                        <div class="col-md-6 ">

                            <div class="portlet-body form">

                                <div class="form-body">

                                    <div class="form-group">
                                        <label>Medical Problem<span class="required">*</span></label>
                                       
                                        <asp:TextBox ID="txtAdd" class="form-control" placeholder="Medical Problem"
                                            runat="server"></asp:TextBox>

                                        <span class="help-block">
                                                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlDesignation"  runat ="server" ControlToValidate="txtAdd"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Medical Problem" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                   </span>
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
                    <span>Medical Problem</span>
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
                            <span class="caption-subject font-red sbold uppercase">Medical Problem</span>
                        </div>
                        
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-6">
                               <div class="form-group">
                                             
                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                        ClientIDMode="Static"></asp:TextBox>
                                  
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group form-md-line-input ">
                                   <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                            OnClick="btSearch_Click" />
                                    
                                 <asp:Button ID="Button1" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                            CausesValidation="False" OnClick="btnAddNew_Click" />
                                        
                                </div>
                            </div>
                            </div>
                        

                            <!-- Usage as a class -->
                      <div class="text-right mb-20">
                                            Total :
                                            <asp:Label ID="lblTotaCount" runat="server" Text=""></asp:Label>
                       </div>
                                 </div>
                        <div class="table-scrollable">
                             
                            <asp:GridView ID="gvShow" runat="server" class="table table-bordered table-hover"
                                    GridLines="None" DataKeyNames="MedicalProid" AutoGenerateColumns="false" OnRowUpdating="gvShow_RowUpdating"
                                    OnRowDeleting="gvShow_RowDeleting" OnRowCancelingEdit="gvShow_RowCancelingEdit"
                                    OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true" AllowPaging="true"
                                    OnPageIndexChanging="gvShow_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("MedicalProid") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="60%" HeaderText="Medical Problem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' class="form-control input-sm"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="../Images/edit15x15.png"
                                            CausesValidation="False"  UpdateImageUrl="../Images/right15x15.png"
                                            CancelImageUrl="../Images/cancel15x15.png" ItemStyle-Width="5%" />
                                        <asp:TemplateField ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lbtDelete" runat="server" CommandName="delete" ImageUrl="../Images/delete15x15.png"
                                                    CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete this Source Name?');" />
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
