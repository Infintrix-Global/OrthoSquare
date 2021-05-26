<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ViewFolloupDetials.aspx.cs" Inherits="OrthoSquare.Enquiry.ViewFolloupDetials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:Panel ID="Panel2"  runat="server">
                 <div id="Div2" runat="server" class="page-content">
                  <div class="page-bar">
			<ul class="page-breadcrumb">
				<li>
					<i class="icon-home"></i>
					<a href="index-2.html">Home</a>
					<i class="fa fa-angle-right"></i>
				</li>
				<li>
					<span>Followup Details</span>
				</li>
			</ul>

		</div>
        <div class="row">
            <div class="col-md-12 pad">
                <div class="portlet light portlet-fit portlet-form bordered">
                    <div class="portlet-title">
						<div class="caption">
							<i class="icon-settings font-red"></i>
							<span class="caption-subject font-red sbold uppercase">Followup Details</span>
						</div>
						
					</div>
                    <div class="portlet-body">
                        <!-- BEGIN FORM-->
                        <div class="form-body">

                               <div class="table-scrollable">
                                    <asp:GridView ID="GridViewFolloupDetils1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        class="table table-bordered table-hover" DataKeyNames="EnquiryID" OnPageIndexChanging="GridViewFolloupDetils1_PageIndexChanging"
                                        GridLines="None" 
                                        ShowHeaderWhenEmpty="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo1" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                                  
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Name" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryName" runat="server" Text='<%# Eval("Ename") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryDate11" runat="server" Text='<%# Eval("Followupdate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Follow up Mode" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFollowupmode1" runat="server" Text='<%# Eval("Followupmode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Conversation Details" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblConversationDetails1" runat="server" Text='<%# Eval("ConversationDetails") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Status" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatusName1" runat="server" Text='<%# Eval("statusName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           

                                          <asp:TemplateField HeaderText="Follow up By" ItemStyle-Width="26%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyName1" runat="server" Text='<%# Eval("Dname") %>'></asp:Label>
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

</asp:Content>
