﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ClinicCollectionReport.aspx.cs" Inherits="OrthoSquare.Report.ClinicCollectionReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
					<span>Clinic Collection Report</span>
				</li>
			</ul>

		</div>
        <div class="row">
            <div class="col-md-12 pad">
                <div class="portlet light portlet-fit portlet-form bordered">
                    <div class="portlet-title">
						<div class="caption">
							<i class="icon-settings font-red"></i>
							<span class="caption-subject font-red sbold uppercase">Clinic Collection Report</span>
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
                                <div class="col-md-6">
                                    <div class="form-group">
                                         <label for="form_control_1">
                                            Clinic Name <span class="required"></span>
                                        </label>
                                           <asp:DropDownList ID="ddlClinic" class="form-control"  AutoPostBack="true"  runat="server"></asp:DropDownList>

                                       
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                       
                                       
                                    </div>
                                </div>
                               
                            </div>
                            
                            <div class="row">
                            <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                            CausesValidation="False" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                            </div>

                             <div class="text-right mb-20">
  
                                  Total : <asp:Label ID="lblTotalTop" runat="server" Text="Label"></asp:Label>
                                 </div>
                            <div class="table-scrollable">
							 
							 <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"  ShowFooter ="true" 
                                class="table table-bordered table-hover" OnRowDataBound="gvShow_RowDataBound"
                                OnPageIndexChanging="gvShow_PageIndexChanging">
                                
                                <Columns>
                                     
                                    <asp:TemplateField HeaderText="Sr No." >
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                           
                                               <asp:Label ID="lblClinicID" Visible="false" runat="server" Text='<%# Eval("ClinicID")%>'></asp:Label>
                                           
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    
                                    
                                     <asp:TemplateField HeaderText="Clinic Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("ClinicName")%>'></asp:Label>
                                        </ItemTemplate>
                                          <FooterStyle HorizontalAlign="Right" />
												<FooterTemplate>
                                                    <asp:Label ID="lblTotal1" runat="server" Text="Total"></asp:Label>
												</FooterTemplate>
                                    </asp:TemplateField>
                                  
                                     <asp:TemplateField HeaderText="Paid Amount" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaidAmount" runat="server" Text='<%# Eval("PaidAmount")%>'></asp:Label>
                                        </ItemTemplate>

                                          <FooterStyle HorizontalAlign="Left" />
												<FooterTemplate>
                                                    <asp:Label ID="lblPaidAmountTotal" runat="server" Text=""></asp:Label>
												</FooterTemplate>
                                         </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Pending Amount" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPendingAmount" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                          <FooterStyle HorizontalAlign="Left" />
												<FooterTemplate>
                                                    <asp:Label ID="lblPendingAmountTotal" runat="server" Text=""></asp:Label>
												</FooterTemplate>
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
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
