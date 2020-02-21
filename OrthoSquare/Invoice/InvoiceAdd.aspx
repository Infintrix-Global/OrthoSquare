<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="InvoiceAdd.aspx.cs" Inherits="OrthoSquare.Invoice.InvoiceAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="page-content" id="Add"  runat="server">
		<!-- BEGIN PAGE HEADER-->


		<div class="page-bar">
			<ul class="page-breadcrumb">
				<li>
					<i class="icon-home"></i>
					<a href="index-2.html">Home</a>
					<i class="fa fa-angle-right"></i>
				</li>
				<li>
					<span>Generate Invoice</span>
				</li>
			</ul>

		</div>
		<!-- END PAGE HEADER-->

		<div class="row">
			<div class="col-md-12">
				<div style="margin-bottom: 5px;">
					<asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="lblinvCode" runat="server" Text=""></asp:Label>
				</div>
				<!-- BEGIN SAMPLE FORM PORTLET-->
				<div class="portlet light ">
					<div class="portlet-title">
						<div class="caption font-red-sunglo">
							<i class="icon-settings font-red-sunglo"></i>
							<span class="caption-subject bold uppercase">Generate Invoice</span>
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
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-3">
									 
										<label>Patient Name</label>
										   <asp:DropDownList ID="ddlpatient"  class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlpatient_SelectedIndexChanged"></asp:DropDownList>
								   
									</div>
									<div class="col-sm-3">
									   
										<label>Doctor Name</label>
											 
										<asp:DropDownList ID="ddlDoctor"  class="form-control" runat="server"></asp:DropDownList>
									   
									</div>
									
								</div>
							</div>
						</div>
					<br />


                     <div class="row" >
						<div class="col-xs-12">
								 <div class="form-group"> 
                                    



                                     <asp:GridView ID="gvInformation" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                                                 ForeColor="#333333"  Width="100%" onrowcommand="gvInformation_RowCommand"
                                                OnRowDataBound="gvInformation_RowDataBound">
                                            
                                                <Columns>
                                                    <asp:BoundField DataField="RowNumber" HeaderText="Sr.No" />
                                                    <asp:TemplateField HeaderText="Treatment" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnWOEmployeeID" runat="server" Value='<%# Eval("ID")%>'></asp:HiddenField>
                                                        
                                                            <asp:Label ID="lblTreatment" Visible="false"  runat="server" Text='<%# Eval("TreatmentID")%>'></asp:Label>
                                                           <asp:DropDownList ID="ddlTreatment1" class="form-control" runat="server"></asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit" >
                                                        <ItemTemplate>
                                                           <asp:TextBox ID="txtSeatings1" class="form-control" Text='<%# Eval("Unit")%>' runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost">
                                                        <ItemTemplate>
                                                           <asp:TextBox ID="txtCost1" class="form-control" Text='<%# Eval("Cost")%>' runat   ="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Discount">
                                                        <ItemTemplate>
                                                           
                                                          <asp:TextBox ID="txtDiscount1" class="form-control" Text='<%# Eval("Discount")%>' runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tax" >
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlTAX1" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="Invoice_SelectedIndexChanged">
                                                           
                                                          </asp:DropDownList>
                                                             <asp:Label ID="lblTax11" Visible="false"  runat="server" Text='<%# Eval("Tex")%>' ></asp:Label>
                                                        </ItemTemplate>

                                                          <FooterStyle HorizontalAlign="Right" />
												<FooterTemplate>
													  <asp:Button ID="btn_AddEmployee" runat="server" Text="+Add New Row" class="btn blue"
                                                CausesValidation="true" ValidationGroup="AddExperianceGrp" OnClick="btn_AddEmployee_Click" />
												</FooterTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    
                                                    <asp:TemplateField >
                                                      <ItemTemplate >
                                                          <asp:ImageButton ID="ImageButton1"  ImageUrl="~/Images/remove-icon-png-26.png" Width="30px" CommandArgument ='<%# Eval("ID") %>' runat="server" OnClientClick="return confirm('Do you really want to delete this Team Member?');" />
                                                      
                                                      </ItemTemplate>
                                                   </asp:TemplateField>
                                                </Columns>
                                               
                                                <EmptyDataTemplate>
                                                    There is no Record exist.
                                                </EmptyDataTemplate>
                                            </asp:GridView>

                                     </div>
                            </div>
                     </div>









						 <div class="row" >
						<div class="col-xs-12">
								 <div class="form-group">  
								   
									<%--<asp:GridView ID="Gridinvoice" runat="server" Width="100%" ShowFooter="true" class=""
										AutoGenerateColumns="false" OnRowDataBound="Gridinvoice_RowDataBound">
										<Columns>


											<asp:BoundField DataField="RowNumber" HeaderText="NO." />
											<asp:TemplateField HeaderText="TREATMENTS"   ItemStyle-Width="5%">
												<ItemTemplate>
                                                 
													<asp:DropDownList ID="ddlTreatment" runat="server"></asp:DropDownList>
													
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="UNIT" ItemStyle-Width="10%">
												<ItemTemplate>
													<asp:TextBox ID="txtSeatings" Text="" runat="server"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Cost(₹)"  ItemStyle-Width="10%">
												<ItemTemplate>
													<asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
												</ItemTemplate>
											  
											</asp:TemplateField>
										   
												<asp:TemplateField HeaderText="DISCOUNT(₹)"  ItemStyle-Width="10%">
												<ItemTemplate>
													<asp:TextBox ID="txtDiscount" runat="server"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>  
										   
										  
										   
												<asp:TemplateField HeaderText="TAX"  ItemStyle-Width="10%">
												<ItemTemplate>
													
                                                    <asp:DropDownList ID="ddlTAX" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Invoice_SelectedIndexChanged">
                                                         <asp:ListItem  Value="0">------ Select ------</asp:ListItem>
                                                          <asp:ListItem  Value ="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                
                                                
                                                </ItemTemplate>

												  <FooterStyle HorizontalAlign="Right" />
												<FooterTemplate>
													<asp:Button ID="ButtonAdd" OnClick="ButtonAddGridInvoice_Click" runat="server" CausesValidation="false"
														Text="Add New Row" />
												</FooterTemplate>
											</asp:TemplateField> 

										</Columns>
									</asp:GridView>--%>

                                     <asp:GridView ID="GridinvoiceDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
									class="table table-bordered table-hover">

                                         <Columns>
										<asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
											<ItemTemplate>
												<asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
												
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Treatment Name" ItemStyle-Width="10%">
											<ItemTemplate>
												<asp:Label ID="lblPriceTreatmentName" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										
										
										<asp:TemplateField HeaderText="Unit" ItemStyle-Width="18%">
											<ItemTemplate>
												<asp:Label ID="lblUnit" runat="server" Text='<%# Eval("Unit") %>'></asp:Label>
											</ItemTemplate>
									     	</asp:TemplateField>


                                             <asp:TemplateField HeaderText="Cost" ItemStyle-Width="18%">
											<ItemTemplate>
												<asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost") %>'></asp:Label>
											</ItemTemplate>
									     	</asp:TemplateField>

                                             <asp:TemplateField HeaderText="Discount" ItemStyle-Width="18%">
											<ItemTemplate>
												<asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>'></asp:Label>
											</ItemTemplate>
									     	</asp:TemplateField>

                                             <asp:TemplateField HeaderText="Tax" ItemStyle-Width="18%">
											<ItemTemplate>
												<asp:Label ID="lblTax" runat="server" Text='<%# Eval("Tax") %>'></asp:Label>
											</ItemTemplate>
									     	</asp:TemplateField>
                                             </Columns>
                                     </asp:GridView>


								</div>
							</div>

							 </div>
                    <br />

					<div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-3">
									 
										<label>	TOTAL COST (₹)</label><br />
										<asp:Label ID="lblTotalCost"  runat="server" Text=""></asp:Label>
									</div>
									<div class="col-sm-3">
									   
										<label>TOTAL DISCOUNT (₹)</label>  <br />
								   <asp:Label ID="lblTotalDiscount" runat="server" Text=""></asp:Label>
									  
									   
									</div>
									 <div class="col-sm-3">
									   
										<label>TOTAL TAX (₹)</label> <br />
									  <asp:Label ID="lblTotalTax" runat="server" Text=""></asp:Label>
									   
									   
									</div>

									<div class="col-sm-3">
									   
										<label>GRAND TOTAL(₹)</label> <br />
										<asp:Label ID="lblGrandTotal" runat="server" Text=""></asp:Label>
									   
									   
									</div>
								</div>
							</div>
						</div>

                     <br />

                    <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-3">
									 
										<label>PAID AMOUNT(₹)</label><br />
                                        <asp:TextBox ID="txtPaidAmount" class="form-control"  runat="server" AutoPostBack="True" OnTextChanged="txtPaidAmount_TextChanged"></asp:TextBox>
									</div>
									<div class="col-sm-3">
									   
										<label>PENDING AMOUNT(₹)</label>  <br />
								        <asp:TextBox ID="txtPendingAmount" class="form-control"  runat="server"></asp:TextBox>
									   
									</div>
									 <div class="col-sm-3">
									   
										
									   
									</div>

									<div class="col-sm-3">
									   
										
									   
									</div>
								</div>
							</div>
						</div>
						<!-- END CONTENT BODY -->
				    <br />
                    <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-3">
									 
										<label>Payment Mode</label><br />
                                         
                                        <asp:DropDownList ID="DropDownList1" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                            <asp:ListItem Value="1">Cash</asp:ListItem>
                                            <asp:ListItem Value="2">Check</asp:ListItem>
                                            <asp:ListItem Value="3">Credit Card</asp:ListItem>
                                            <asp:ListItem Value="4">Debit Card</asp:ListItem>
                                            <asp:ListItem Value="5">Bajaj finance</asp:ListItem>
                                           
                                        </asp:DropDownList>
									</div>
									<div class="col-sm-3">
									   
										
									   
									</div>
									 <div class="col-sm-3">
									   
										
									   
									</div>

									<div class="col-sm-3">
									   
										
									   
									</div>
								</div>
							</div>
						</div>

                     <br />
                    <asp:Panel ID="Panel1" Visible="false" runat="server">
                    <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-3">
									 
										<label>Bank Name</label><br />
                                        <asp:TextBox ID="txtBankName" class="form-control"  runat="server"></asp:TextBox>
									</div>
									<div class="col-sm-3">
									   <label>Branch Name</label><br />
                                        <asp:TextBox ID="txtBranchName" class="form-control"  runat="server"></asp:TextBox>
										
									   
									</div>
									 <div class="col-sm-3">
									   
										 <label>IRFC Code</label><br />
                                        <asp:TextBox ID="txtIRFC" class="form-control"  runat="server"></asp:TextBox>
										
									   
									</div>

									<div class="col-sm-3">
									   
										
									   
									</div>
								</div>
							</div>
						</div>
                     <br />

                    <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-3">
									 
										<label>CHeck No</label><br />
                                        <asp:TextBox ID="txtCheckNO" class="form-control"  runat="server"></asp:TextBox>
									</div>
									<div class="col-sm-3">
									   <label>Check Date</label><br />
                                        <asp:TextBox ID="txtCheckDate" class="form-control"   runat="server"></asp:TextBox>
										
									   
									</div>
									 <div class="col-sm-3">
									   
										 <label>Card No</label><br />
                                        <asp:TextBox ID="txtCardNo" class="form-control"  runat="server"></asp:TextBox>
										
									   
									</div>

									<div class="col-sm-3">
									   
										
									   
									</div>
								</div>
							</div>
						</div>
                        </asp:Panel>
                    <br />
                      <asp:Panel ID="Panel2" Visible="false" runat="server">
                    <div class="row">
						<div class="col-xs-12">
								<div class="form-group">
									<div class="col-sm-3">
									 
										 <label>Card No</label><br />
                                        <asp:TextBox ID="TextBox3" class="form-control"  runat="server"></asp:TextBox>
										
									</div>
									<div class="col-sm-3">
									 
									   
									</div>
									 <div class="col-sm-3">
									   
										
									   
									</div>

									<div class="col-sm-3">
									   
										
									   
									</div>
								</div>
							</div>
						</div>
                      </asp:Panel>
                     <br />
                    <asp:Panel ID="Panel3" Visible="false" runat="server">
                    <div class="row">

                        <div class="col-xs-12">
                                                        <div class="form-group">
                                                            <div class="col-sm-3">
                                                                <label>
                                                                    Document </label>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <asp:FileUpload ID="FuImage1" runat="server" />
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <asp:Button ID="btnUploadimage" class="btn green" ClientIDMode="Static" CausesValidation="false"
                                                                    runat="server" Text="Upload Image" OnClick="btnUploadimage_Click" />
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <asp:Image ID="ImagePhoto1" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                                    ImageUrl="~/Images/no-photo.jpg" />
                                                                <asp:Label ID="lbl_filepath1" runat="server" Visible="False"></asp:Label>
                                                            </div>
                                                        </div>
                                                        .
                                                    </div>
                     </div>

                    </asp:Panel>
                     <br />
                     <br />
					<div class="row">
						<div class="form-actions text-center">

							<asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />
							<asp:Button ID="btUpdate" ClientIDMode="Static" class="btn blue" runat="server"
								Text="Update" Visible="False" />
							<asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
								CausesValidation="False" />

                            <asp:Button ID="btninvoice" runat="server" class="btn blue" Text="Print Invoice" OnClick="btninvoice_Click" />


						</div>

					</div>
				</div>
			</div>
			<!-- END CONTENT BODY -->
		</div>


	</div>


</asp:Content>
