<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="TREATMENT_STATISTICS.aspx.cs" Inherits="OrthoSquare.Master.TREATMENT_STATISTICS" %>
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
					<span>TREATMENT STATISTICS</span>
				</li>
			</ul>

		</div>
        <div class="row">
            <div class="col-md-12 pad">
                <div class="portlet light portlet-fit portlet-form bordered">
                    <div class="portlet-title">
						<div class="caption">
							<i class="icon-settings font-red"></i>
							<span class="caption-subject font-red sbold uppercase">TREATMENT STATISTICS</span>
						</div>
						
					</div>
                    <div class="portlet-body">
                        <!-- BEGIN FORM-->
                        <div class="form-body">

                               <div class="table-scrollable">
                                    <asp:GridView ID="GridTREATMENTWISEPATIENT" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" 
                                GridLines="None" OnPageIndexChanging="GridTREATMENTWISEPATIENT_PageIndexChanging"
                                 ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Treatment Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTreatmentName" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patient Total">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPatientTotal" runat="server" Text='<%# Eval("PatientTotal") %>'></asp:Label>
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
