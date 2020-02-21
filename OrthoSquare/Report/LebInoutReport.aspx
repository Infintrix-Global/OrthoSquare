<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="LebInoutReport.aspx.cs" Inherits="OrthoSquare.Report.LebInoutReport" %>
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
					<span> Lab Outward and Inward Report </span>
				</li>
			</ul>

		</div>
        <div class="row">
            <div class="col-md-12 pad">
                <div class="portlet light portlet-fit portlet-form bordered">
                    <div class="portlet-title">
						<div class="caption">
							<i class="icon-settings font-red"></i>
							<span class="caption-subject font-red sbold uppercase">Lab Outward and Inward Report  </span>
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
                            .
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                         <label>Patient Name</label>
											 
										<asp:DropDownList ID="ddlpatient"  class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlpatient_SelectedIndexChanged"></asp:DropDownList>
									   
                                    </div>
                                </div>
                                
                                <div class="col-md-3">
                                    <div class="form-group">
                                       
                                       
                                    </div>
                                </div>
                                <!-- Usage as a class -->
                                <div class="col-md-3">
                                    <div class="form-group">
                                        
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="form_control_1">
                                           
                                        </label>
                                       
                                        
                                    </div>
                                </div>
                            </div>
                            

                             

                            <div class="table-scrollable">
							 

                                  <asp:GridView ID="GridinoutLab" runat="server" AllowPaging="true" AutoGenerateColumns="false"     OnPageIndexChanging="gvShow_PageIndexChanging"
									class="table table-bordered table-hover" >

                                         <Columns>
										<asp:TemplateField HeaderText="Sr. No." >
											<ItemTemplate>
												<asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
												
											</ItemTemplate>
										</asp:TemplateField>
										
										<asp:TemplateField HeaderText="Patient Name" >
											<ItemTemplate>
												<asp:Label ID="lblVisitorName1" runat="server" Text='<%# Eval("FristName") +"  "+ Eval("LastName") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										
                                             <asp:TemplateField HeaderText="Lab Name" >
											<ItemTemplate>
												<asp:Label ID="lblLabName" runat="server" Text='<%# Eval("LabName") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>

                                             <asp:TemplateField HeaderText="Tooth No." >
											<ItemTemplate>
												<asp:Label ID="lblToothNo" runat="server" Text='<%# Eval("ToothNo")  %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										
										<asp:TemplateField HeaderText="Type of Work">
											<ItemTemplate>
												<asp:Label ID="lblpatientidCount" runat="server" Text='<%# Eval("TypeName") %>'></asp:Label>
											</ItemTemplate>

                                        
                                           
									     	</asp:TemplateField>


                                           

                                               <asp:TemplateField HeaderText="Outward Date" >
											<ItemTemplate>
											<asp:Label ID="lblinEnqDate" runat="server" Text='<%# Eval("OutwardDate","{0:dd/MM/yyyy}") %>'></asp:Label>
											</ItemTemplate>
									     	</asp:TemplateField>

                                              <asp:TemplateField HeaderText="Inward Date" >
											<ItemTemplate>
											<asp:Label ID="lbloutEnqDate" runat="server" Text='<%# Eval("InwardDate","{0:dd/MM/yyyy}") %>'></asp:Label>
											</ItemTemplate>
									     	</asp:TemplateField>

                                             <asp:TemplateField HeaderText="Work Status" >
                                        <ItemTemplate>
                                           <asp:Label ID="lblWorkcompletion" runat="server" Text='<%# Eval("Workcompletion") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Work Completed" >
                                        <ItemTemplate>
                                             <asp:Label ID="lblWorkcompletion" runat="server" Text='<%# Eval("WorkStatus") %>'></asp:Label>
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
                    <!-- / .panel -->
                </div>
            </div>
        </div>
         </div>
    </asp:Panel>
</ContentTemplate>
            </asp:UpdatePanel>

</asp:Content>
