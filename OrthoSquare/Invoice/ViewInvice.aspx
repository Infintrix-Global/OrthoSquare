<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ViewInvice.aspx.cs" Inherits="OrthoSquare.Invoice.ViewInvice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
					<span>View Invice</span>
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
							<span class="caption-subject font-red sbold uppercase">View Invice</span>
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
							   
							   
							<asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
											CausesValidation="False" OnClick="btnAddNew_Click" />    
							 </div>
						<div class="table-scrollable">
							 
							<asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
									class="table table-bordered table-hover" DataKeyNames="InvoiceNo"
									GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
									 ShowHeaderWhenEmpty="true">
									<Columns>
										<asp:TemplateField HeaderText="Sr. No." >
											<ItemTemplate>
												<asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("InvoiceNo") %>' Visible="false"></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Invoice No.">
											<ItemTemplate>
												<asp:Label ID="lblInvoiceCode" runat="server" Text='<%# Eval("InvoiceCode") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Patient Name" >
											<ItemTemplate>
												<asp:Label ID="lblPatientName" runat="server" Text='<%# Eval("PFristName") +"  "+ Eval("PLastName") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Doctor Name" >
											<ItemTemplate>
												<asp:Label ID="lblDoctor" runat="server" Text='<%# Eval("DFirstName") +"  "+ Eval("DLastName") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Grand Total" >
											<ItemTemplate>
												<asp:Label ID="lblGrandTotal" runat="server" Text='<%# Eval("GrandTotal") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Paid Amount" >
											<ItemTemplate>
												<asp:Label ID="lblPaidAmount" runat="server" Text='<%# Eval("PaidAmount") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pending Amount" >
											<ItemTemplate>
												<asp:Label ID="lblPendingAmount" runat="server" Text='<%# Eval("PendingAmount") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>



                                        <asp:TemplateField HeaderText="Registration Date" >
											<ItemTemplate>
												  <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("PayDate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                            
											</ItemTemplate>
										</asp:TemplateField>

										<asp:TemplateField  >
											<ItemTemplate>
												<%--<asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" CommandArgument='<%# Eval("patientid") %>'
													CommandName="EditEnquiry" ImageUrl="../Images/right15x15.png" />--%>

                                                <asp:Button ID="btnview" CommandArgument ='<%# Eval("InvoiceNo") %>' CommandName ="Viewinv" class="btn blue-madison" runat="server" Text="View" />
											</ItemTemplate>
										</asp:TemplateField>
										<%--<asp:TemplateField HeaderText="Delete" ItemStyle-Width="2%">
											<ItemTemplate>
												<asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete"
													ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Enquiry?');" />
											</ItemTemplate>
										</asp:TemplateField>--%>
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
</asp:Content>
