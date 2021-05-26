<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="MaterialPurchased.aspx.cs" Inherits="OrthoSquare.Report.MaterialPurchased" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
					<a href="#">Home</a>
					<i class="fa fa-angle-right"></i>
				</li>
				<li>
					<span>Doctor Report</span>
				</li>
			</ul>

		</div>
        <div class="row">
            <div class="col-md-12 pad">
                <div class="portlet light portlet-fit portlet-form bordered">
                    <div class="portlet-title">
						<div class="caption">
							<i class="icon-settings font-red"></i>
							<span class="caption-subject font-red sbold uppercase">Material Purchased Report</span>
						</div>
						
					</div>
                    <div class="portlet-body">
                        <!-- BEGIN FORM-->
                        <div class="form-body">
                               <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        
                                           <asp:DropDownList ID="ddlClinic" class="form-control"   AutoPostBack="true" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged"  runat="server"></asp:DropDownList>

                                       
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                       
                                       <asp:DropDownList ID="ddlDocter" class="form-control"  AutoPostBack="true" runat="server"></asp:DropDownList>

                                       
                                       
                                    </div>
                                </div>
                               
                            </div>
                             <div class="row">
                                     <div class="col-md-4">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtFromDate" runat="server" class="form-control" placeholder="From Date "
                                            ClientIDMode="Static"></asp:TextBox>
                                      
                                        <asp:CalendarExtender ID="txtSFromFollowDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                            Enabled="True" TargetControlID="txtFromDate">
                                        </asp:CalendarExtender>
                                      
                                        <span class="help-block">
                                           
                                        </span>
                                       
                                    </div>
                                </div>
                                 
                                <!-- Usage as a class -->
                                <div class="col-md-4">
                                    <div class="form-group">
                                      
                                        <asp:TextBox ID="txtToDate" runat="server" class="form-control" placeholder="To Date"
                                            ClientIDMode="Static"></asp:TextBox>
                                      
                                        <asp:CalendarExtender ID="txtSToFollowDate_CalendarExtender" runat="server"  Format="dd-MM-yyyy"
                                            Enabled="True" TargetControlID="txtToDate">
                                        </asp:CalendarExtender>
                                      
                                        <span class="help-block">
                                           
                                        </span>
                                       
                                    </div>
                                </div>

                                 <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                            CausesValidation="False" OnClick="btnSearch_Click" />
                                         <asp:Button ID="btnclear" runat="server" Text="Clear " class="btn blue-hoki" ClientIDMode="Static"
                                            CausesValidation="False" OnClick="btnclear_Click" />
                                    </div>
                                </div>
                            </div>
                             

                             <div class="row">
                          

                            
                            <div class="table-scrollable">
							 
							 <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"  
                                class="table table-bordered table-hover" 
                                OnPageIndexChanging="gvShow_PageIndexChanging">
                                
                                <Columns>
                                     
                                    <asp:TemplateField HeaderText="Sr No." >
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                          
                                        
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    
                                    
                                     <asp:TemplateField HeaderText="Name of the party" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblDoctoname" runat="server" Text='<%# Eval("Dname") %>'></asp:Label>
                                        </ItemTemplate>
                                         
                                    </asp:TemplateField>
                            

                                     <asp:TemplateField HeaderText="Mobile No" >
                                        <ItemTemplate>
                                           <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Address" >
                                        <ItemTemplate>
                                           <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>



                                     <asp:TemplateField HeaderText="Invoice No" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvNo" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>

                                        
                                         </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Amount" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server"   Text='<%# Eval("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                         
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Pan No (if applicale)" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblpanNo" runat="server"   Text=""></asp:Label>
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
             </div>
    </asp:Panel>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
