<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="AllAppointmentList.aspx.cs" Inherits="OrthoSquare.Master.AllAppointmentList" %>
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
					<span>All Appointment List</span>
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
							<span class="caption-subject font-red sbold uppercase">All Appointment List</span>
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                         
                                        <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Visitor Name"
                                            ClientIDMode="Static" MaxLength="80"></asp:TextBox>
                                        <span class="help-block">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorSearch" runat="server"
                                                ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtName"
                                                SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                            </asp:RegularExpressionValidator>
                                        </span>
                                       
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Mobile No."
                                            ClientIDMode="Static" MaxLength="15"></asp:TextBox>
                                        <span class="help-block">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server"
                                                Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobile"
                                                SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                       
                                    </div>
                                </div>
                                <div class="col-sm-3">

                                  
                                    <asp:DropDownList ID="ddlClinic" class="form-control"  AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged1"></asp:DropDownList>

<%--                                       <span class="help-block">
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClinic" InitialValue="0"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Clinic" ForeColor="Red"></asp:RequiredFieldValidator>
                                           </span>--%>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        
                                        
                                         <asp:DropDownList ID="ddlDocter" class="form-control" runat="server"></asp:DropDownList>
                                        <span class="help-block">
                                        
                                        </span>
                                       
                                    </div>
                                </div>
                            </div>.
                            <div class="row">
                                
                                <div class="col-md-3">
                                    <div class="form-group form-md-line-input">
                                                
                                                <asp:RadioButtonList ID="RadlistAp" runat="server" RepeatDirection="Horizontal"
                                                    Width="300px">
                                                    <asp:ListItem Value="1">Approve</asp:ListItem>
                                                    <asp:ListItem Value="2">Reject</asp:ListItem>
                                                   
                                                </asp:RadioButtonList>
                                               
                                            </div>
                                </div>
                               <div class="col-md-3">
                                    <div class="form-group">
                                          
                                      <asp:TextBox ID="txtSFromFollowDate" runat="server" class="form-control" placeholder="From Date "
                                            ClientIDMode="Static"></asp:TextBox>
                                      
                                        <asp:CalendarExtender ID="txtSFromFollowDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                            Enabled="True" TargetControlID="txtSFromFollowDate">
                                        </asp:CalendarExtender>
                                      
                                        <span class="help-block">
                                        
                                        </span>
                                       
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                             
                                        <asp:TextBox ID="txtSToFollowDate" runat="server" class="form-control" placeholder="To Date"
                                            ClientIDMode="Static"></asp:TextBox>
                                      
                                        <asp:CalendarExtender ID="txtSToFollowDate_CalendarExtender" runat="server"  Format="dd-MM-yyyy"
                                            Enabled="True" TargetControlID="txtSToFollowDate">
                                        </asp:CalendarExtender>
                                               
                                            </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
											OnClick="btSearch_Click" />
                                    </div>
                                </div>
                            </div>
                      
                        
                        
							<!-- Usage as a class -->
					   <div class="text-right mb-20">
							   
							   
							<asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn blue-madison" Visible="false" ClientIDMode="Static"
											CausesValidation="False" OnClick="btnAddNew_Click" />    
							 </div>
						<div class="table-scrollable">
							 
							<asp:GridView ID="GridAppoinment" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" DataKeyNames="Appointmentid" OnRowCommand="GridAppoinment_RowCommand"
                                GridLines="None" OnRowDataBound="GridAppoinment_RowDataBound" OnPageIndexChanging="Appoinment_PageIndexChanging"
                                ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
											<ItemTemplate>
												<asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
												<asp:Label ID="lblAp" runat="server" Text='<%# Eval("Appointmentid") %>' Visible="false"></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>

                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpaFirstName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Doctor Name">
                                        <ItemTemplate>
                                               <asp:Label ID="lblDoctortName" runat="server" Text='<%# Eval("DFirstName") +"  "+ Eval("DLastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>

                                            <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("start_date","{0:dd/MMM/yyyy}") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Time">
                                        <ItemTemplate>

                                            <asp:Label ID="lblstart_Time" runat="server" Text='<%# Eval("start_date","{0:HH mm tt}") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="grey">
                                                <asp:Label ID="lblstatus" Visible="false" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                <asp:LinkButton ID="linkApporuval" CommandArgument='<%# Eval("Appointmentid") %>'  ToolTip="Approve" CommandName="Approve" runat="server"><i class="fa fa-check"></i></asp:LinkButton>
                                                <asp:LinkButton ID="LinkRegect" CommandArgument='<%# Eval("Appointmentid") %>' ToolTip="Reject" CommandName="Reject" runat="server"> <i class="fa fa-times-circle"></i></asp:LinkButton>


                                            </div>

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



</asp:Content>
