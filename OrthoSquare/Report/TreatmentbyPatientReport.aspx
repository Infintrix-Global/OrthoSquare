<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="TreatmentbyPatientReport.aspx.cs" Inherits="OrthoSquare.Report.TreatmentbyPatientReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
					<span>Patient</span>
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
							<span class="caption-subject font-red sbold uppercase">Patient</span>
						</div>
						
					</div>
					<div class="portlet-body">
						
						<div class="row">
                            <div class="col-md-3">
							<div class="form-group">
								  
									  <asp:DropDownList ID="ddlDocterSearch"  class="form-control"   runat="server"></asp:DropDownList>
 
								</div>
							</div>
                            <div class="col-md-3">
							<div class="form-group">
								  
									  <asp:DropDownList ID="ddlTreatment"  class="form-control"   runat="server"></asp:DropDownList>
 
								</div>
							</div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtFromEnquiryDate" runat="server" class="form-control" placeholder="From Date"
                                            ClientIDMode="Static"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtFromEnquiryDate_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromEnquiryDate">
                                        </asp:CalendarExtender>
                                        <span class="help-block">
                                      
                                        </span>
                                       
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtToEnquiryDate" runat="server" class="form-control" placeholder="To Date"
                                            ClientIDMode="Static"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtToEnquiryDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                            Enabled="True" TargetControlID="txtToEnquiryDate">
                                        </asp:CalendarExtender>
                                        
                                        
                                    </div>
                                </div>
                                <div class="col-md-3">
                                      <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                                OnClick="btSearch_Click" />
                                </div>
                                <!-- Usage as a class -->
                                
                            </div>
							<!-- Usage as a class -->
					  
                                     
					 </div>
						<div class="table-scrollable">
							 
							<asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
									class="table table-bordered table-hover" DataKeyNames="patientid"
									GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" 
									 ShowHeaderWhenEmpty="true">
									<Columns>
										<asp:TemplateField HeaderText="Sr. No." >
											<ItemTemplate>
												<asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
												
											</ItemTemplate>
										</asp:TemplateField>
										
										<asp:TemplateField HeaderText="Name" >
											<ItemTemplate>
												<asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("Pname") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										
										<asp:TemplateField HeaderText="Doctor Name" >
											<ItemTemplate>
												<asp:Label ID="lblDane" runat="server" Text='<%# Eval("Dname") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										
                                        <asp:TemplateField HeaderText="Date" >
											<ItemTemplate>
												  <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("CtrateDate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                            
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
                           
                             </div>
					</div>
				</div>

			</div>

		</div>

	</div>
</asp:Content>
