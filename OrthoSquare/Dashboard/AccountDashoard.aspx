<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="AccountDashoard.aspx.cs" Inherits="OrthoSquare.Dashboard.AccountDashoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
                    <!-- BEGIN PAGE HEADER-->
                 
                  
                    <div class="page-bar">
                        <ul class="page-breadcrumb">
                            <li>
                                <i class="icon-home"></i>
                                <a href="#">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                            <li>
                                <span>Dashboard</span>
                            </li>
                        </ul>
                      <div>
                         
                      </div>
                    </div>
        <div class="page-bar">
                          
                    </div>
                    <!-- END PAGE HEADER-->
                    <div class="row">
                         <div class="col-md-2 col-sm-2 col-xs-6" style="width: 20.66667%" >
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Expenses</h4>
                                <div class="widget-thumb-wrap">
                                
                                <i class="fa fa-money widget-thumb-icon bg-green"></i>
                                   
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">Rs.</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="2150">

                                           <asp:LinkButton ID="LinkButtonEXP" PostBackUrl="~/Report/ExpenseReport.aspx" runat="server">    <asp:Label ID="lblExp" runat="server" Text=""></asp:Label> </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>


                        <div class="col-md-2 col-sm-2 col-xs-6" style="width: 20.66667%">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Expenses- <asp:Label ID="lblFEYear" runat="server" Text=""></asp:Label></h4>
                                <div class="widget-thumb-wrap">
                                
                                <i class="fa fa-money widget-thumb-icon bg-green"></i>
                                   
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">Rs.</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="2150">

                                           <asp:LinkButton ID="LinkButton2" PostBackUrl="#" runat="server">    <asp:Label ID="lblFExpenses" runat="server" Text=""></asp:Label> </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                        
                         <div class="col-md-2 col-sm-2 col-xs-6" style="width: 20.66667%">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Collection</h4>
                                <div class="widget-thumb-wrap">
                                <i class="fa fa-money widget-thumb-icon bg-greens"></i>
                                 <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">Rs.</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="5,071"> 

                                              <asp:LinkButton ID="LinkButtoninvoice" PostBackUrl="#" runat="server">  <asp:Label ID="totalinvoice" runat="server" Text=""></asp:Label> </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>


                        <div class="col-md-2 col-sm-2 col-xs-6" style="width: 20.66667%">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Collection- <asp:Label ID="lblCollectionF" runat="server" Text=""></asp:Label></h4>
                                <div class="widget-thumb-wrap">
                                <i class="fa fa-money widget-thumb-icon bg-greens"></i>
                                 <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">Rs.</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="5,071"> 

                                              <asp:LinkButton ID="LinkButton1" PostBackUrl="#" runat="server">  <asp:Label ID="lblFCollecion" runat="server" Text=""></asp:Label> </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                    </div>
                    
                   
                                      
                    <div class="row">
                        <div class="col-lg-6 col-xs-6 col-sm-6">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption caption-md">
                                        <i class="icon-bar-chart font-dark hide"></i>
                                        <span class="caption-subject font-dark bold uppercase">Collection</span>
                                       <span class="caption-helper"> of Last 3 days</span>
                                    </div>
                                    
                                </div>
                                <div class="portlet-body">
                                   <div id="morris_chart_2" style="height:500px;">
                                    

                                      <div class="row">


                                          <asp:GridView ID="GridViewinvAccount" runat="server" AllowPaging="true" AutoGenerateColumns="false"  
                                class="table table-bordered table-hover"
                               >
                                
                                <Columns>
                                     
                                    <asp:TemplateField HeaderText="Sr No." >
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    
                                    
                                     <asp:TemplateField HeaderText="Clinic Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                        </ItemTemplate>
                                         
                                    </asp:TemplateField>
                            

                                     <asp:TemplateField HeaderText="Doctor Name" >
                                        <ItemTemplate>
                                           <asp:Label ID="lblVisitorName1" runat="server" Text='<%# Eval("DoctorName") %>'></asp:Label>
                                        </ItemTemplate>
                                          <%--<FooterStyle HorizontalAlign="Right" />
												<FooterTemplate>
                                                    <asp:Label ID="lblTotal1" runat="server" Text="Total"></asp:Label>
												</FooterTemplate>--%>
                                    </asp:TemplateField>

                                    



                                     <asp:TemplateField HeaderText="Paid Amount" >
                                        <ItemTemplate>
                                         <asp:Label ID="lblTotalPaid" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
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
                      <div class="col-lg-6 col-xs-6 col-sm-6">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption caption-md">
                                        <i class="icon-bar-chart font-dark hide"></i>
                                        <span class="caption-subject font-dark bold uppercase">Expenses</span>
                                         <span class="caption-helper"> of Last 3 days</span>
                                    </div>
                                    
                                </div>
                                <div class="portlet-body">
                                   <div id="morris_chart_2" style="height:500px;">
                                    

                                      <div class="row">

                                          <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" 
                                                class="table table-bordered table-hover" DataKeyNames="ExpenseID" OnRowDataBound="gvShow_RowDataBound"
                                               >

                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sr No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ExpenseID")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Clinic Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Doctor Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDoctor" runat="server" Text='<%# Eval("FirstName") + "  " + Eval("LastName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Vendor Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVendorType" runat="server" Text='<%# Eval("VendorType")%>'></asp:Label>
                                                            <asp:Label ID="lblFormPlace" Visible="false" runat="server" Text='<%# Eval("FromPlace")%>'></asp:Label>
                                                            <asp:Label ID="lblToPlace" Visible="false" runat="server" Text='<%# Eval("ToPlace")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Vendor / Travelling">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Left" />
                                                       
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblExpDate" runat="server" Text='<%# Eval("ExpDate","{0:dd/MM/yyyy}") %>'></asp:Label>
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
                   
                    
        </div>
</asp:Content>
