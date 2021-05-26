<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="SuperAdminDashboard.aspx.cs" Inherits="OrthoSquare.Dashboard.SuperAdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChartline);
        function drawChartline() {
            var options = {
                title: '',
                backgroundColor: 'Enquiry',
                width: 1060,
                height: 500,
                is3D: true,
                bar: { groupWidth: "10%" },
                legend: { position: "none" },


                hAxis: {
                    title: 'Months',
                    textStyle: {
                        color: '#3838A8',
                        fontSize: 20,
                        fontName: 'Arial',
                        bold: true,
                        italic: true
                    },

                    titleTextStyle: {
                        color: '#3838A8',
                        fontSize: 16,
                        fontName: 'Arial',
                        bold: false,
                        italic: true
                    }
                },

                vAxis: {
                    title: 'Enquiry',
                    textStyle: {
                        color: '#3838A8',
                        fontSize: 20,
                        bold: true
                    },
                    titleTextStyle: {
                        color: '#3838A8',
                        fontSize: 16,
                        bold: true
                    }
                },


                isStacked: true
            };
            $.ajax({
                type: "POST",
                url: "SuperAdminDashboard.aspx/GetChartDataline",
                // data: '{}',
                data: "{monthsid: '" + $("[id*=ddlyear]").val() + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.LineChart($("#chartline")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
</script>


     <script type="text/javascript">
         google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'SuperAdminDashboard.aspx/GetDatapai',
                data: "{monthsid: '" + $("[id*=ddlYearSOE]").val() + "'}",
                //data: '{}',
                success:
                    function (response) {
                        drawVisualization(response.d);
                    }

            });
        })

        function drawVisualization(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].ColumnName, dataValues[i].Value]);
            }

            new google.visualization.PieChart(document.getElementById('visualization')).
                draw(data, { title: "" });
        }

    </script>
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
                          <asp:Button ID="btnTimeOut"  class="btn  green btn-outline btn-sm" runat="server" Text="Clinic Activity" PostBackUrl="~/Report/AllClinicDetails.aspx" ValidationGroup="P" />
                        
                      </div>
                    </div>
        <div class="page-bar">
                          
                    </div>
                    <!-- END PAGE HEADER-->
                    <div class="row">
                           <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Clinics</h4>
                                <div class="widget-thumb-wrap">
                                
                                <i class="fa fa-hospital-o widget-thumb-icon bg-green"></i>
                                   
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">TOTAL</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="150">
                                            <asp:LinkButton ID="LinkButtonClinic" PostBackUrl="~/Master/clinic-setup.aspx" runat="server"><asp:Label ID="lblClinics" runat="server" Text=""></asp:Label></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                       <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Enquiries</h4>
                                <div class="widget-thumb-wrap">
                                
                                <i class="fa fa-copy widget-thumb-icon bg-red"></i>
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">TOTAL</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="1,293"><asp:LinkButton ID="LinkButtonEnQ" PostBackUrl="~/Enquiry/EnquiryDetails.aspx" runat="server"><asp:Label ID="lblEnq" runat="server" Text=""></asp:Label></asp:LinkButton></span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                  <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Follow Ups</h4>
                                <div class="widget-thumb-wrap">
                                <i class="fa fa-arrow-up widget-thumb-icon bg-purple"></i>
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">TOTAL</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="815"> <asp:LinkButton ID="LinkButtonFollup" PostBackUrl="~/Enquiry/ViewFolloupDetials.aspx" runat="server"><asp:Label ID="lblFollwupCOunt" runat="server" Text=""></asp:Label></asp:LinkButton></span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                    <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Converted&nbsp;Enquiries</h4>
                                <div class="widget-thumb-wrap">
                                <i class="fa fa-copy widget-thumb-icon bg-blue"></i>
                                   <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">TOTAL</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="90">

                                            <asp:Label ID="lblConvertedEnd" runat="server" Text=""></asp:Label>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                        
                           <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Employee</h4>
                                <div class="widget-thumb-wrap">
                                <i class="fa fa-user widget-thumb-icon bg-yellow-gold"></i>
                                <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">Total</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="">

                                            <asp:LinkButton ID="LinkButtonEMP" PostBackUrl="~/Employee/EmployeeDetails.aspx" runat="server"> <asp:Label ID="lblEmpTotal" runat="server" Text=""></asp:Label></asp:LinkButton>    
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                        
                                  <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Collection</h4>
                                <div class="widget-thumb-wrap">
                                <i class="fa fa-money widget-thumb-icon bg-greens"></i>
                                 <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">Rs.</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="5,071"> 

                                              <asp:LinkButton ID="LinkButtoninvoice" PostBackUrl="~/Invoice/ViewInvice.aspx" runat="server">  <asp:Label ID="totalinvoice" runat="server" Text=""></asp:Label> </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                    </div>
                    
                    <div class="row">
                           <div class="col-md-2 col-md-offset-1 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Expenses</h4>
                                <div class="widget-thumb-wrap">
                                
                                <i class="fa fa-money widget-thumb-icon bg-green"></i>
                                   
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">TOTAL</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="2150">

                                           <asp:LinkButton ID="LinkButtonEXP" PostBackUrl="~/Report/ClinicwishExpenseReport.aspx" runat="server">    <asp:Label ID="lblExp" runat="server" Text=""></asp:Label> </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                       <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Doctors</h4>
                                <div class="widget-thumb-wrap">
                                
                                <i class="fa fa-user-md widget-thumb-icon bg-red"></i>
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">TOTAL</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="1,293">  <asp:LinkButton ID="LinkButtonDr" PostBackUrl="~/Doctor/Add_Doctor.aspx" runat="server">   <asp:Label ID="lblDoctors" runat="server" Text=""></asp:Label> </asp:LinkButton></span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                  <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">DAILY&nbsp;APPOINTMENTS</h4>
                                <div class="widget-thumb-wrap">
                                <i class="fa fa-calendar-check-o widget-thumb-icon bg-purple"></i>
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">TOTAL</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="815">

                                            <asp:Label ID="lblDailyAppontment" runat="server" Text="Label"></asp:Label>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                    <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Patients</h4>
                                <div class="widget-thumb-wrap">
                                <i class="fa fa-bed widget-thumb-icon bg-blue"></i>
                                   <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">TOTAL</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="90">  <asp:LinkButton ID="LinkButtonPatient" PostBackUrl="~/patient/PatientMaster.aspx" runat="server">   <asp:Label ID="lblPatient" runat="server" Text=""></asp:Label></asp:LinkButton></span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                        
                           <div class="col-md-2 col-sm-2 col-xs-6">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Treatment&nbsp;Statistics</h4>
                                <div class="widget-thumb-wrap">
                                <i class="fa fa-user widget-thumb-icon bg-yellow-gold"></i>
                                <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">TOTAL</span>
                                        <span class="widget-thumb-body-stat" data-counter="counterup" data-value="">

                                         <asp:LinkButton ID="LinkButtonTreatment" PostBackUrl="~/Master/TREATMENT_STATISTICS.aspx" runat="server">   <asp:Label ID="lblTreatmentTotal" runat="server" Text=""></asp:Label></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                        
               
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-xs-12 col-sm-12">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <span class="caption-subject bold uppercase font-dark">Appointments</span>
                                        <span class="badge badge-info badge-roundless">

                                            <asp:Label ID="lblTodayAppoinment" runat="server" Text="Label"></asp:Label>
                                        </span>
                                        </div>
                                        <div class="actions">
                                     <%--   <div class="btn-group ">
                                            <a class="btn dark btn-outline btn-circle btn-sm" href="javascript:;" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" aria-expanded="true"> Year
                                                <i class="fa fa-angle-down"></i>
                                            </a>
                                            <ul class="dropdown-menu pull-right">
                                                <li>
                                                    <a href="javascript:;"> Option 1</a>
                                                </li>
                                                 <li>
                                                    <a href="javascript:;">Option 2</a>
                                                </li>
                                                <li>
                                                    <a href="javascript:;">Option 3</a>
                                                </li>
                                                <li>
                                                    <a href="javascript:;">Option 4</a>
                                                </li>
                                            </ul>
                                        </div>
                                   
                                 <div class="btn-group">
                                            <a class="btn dark btn-outline btn-circle btn-sm" href="javascript:;" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" aria-expanded="true"> Month
                                                <i class="fa fa-angle-down"></i>
                                            </a>
                                            <ul class="dropdown-menu pull-right">
                                                <li>
                                                    <a href="javascript:;"> Option 1</a>
                                                </li>
                                                 <li>
                                                    <a href="javascript:;">Option 2</a>
                                                </li>
                                                <li>
                                                    <a href="javascript:;">Option 3</a>
                                                </li>
                                                <li>
                                                    <a href="javascript:;">Option 4</a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="btn-group">
                                            <a class="btn dark btn-outline btn-circle btn-sm" href="javascript:;" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" aria-expanded="true"> Clinic
                                                <i class="fa fa-angle-down"></i>
                                            </a>
                                            <ul class="dropdown-menu pull-right">
                                                <li>
                                                    <a href="javascript:;"> Option 1</a>
                                                </li>
                                                 <li>
                                                    <a href="javascript:;">Option 2</a>
                                                </li>
                                                <li>
                                                    <a href="javascript:;">Option 3</a>
                                                </li>
                                                <li>
                                                    <a href="javascript:;">Option 4</a>
                                                </li>
                                            </ul>
                                        </div>--%>
                                    </div>
                                                                    
                                    </div>
                               
                                <div class="portlet-body">
                                 <div class="table-scrollable table-scrollable-borderless">
                                       <asp:GridView ID="GridAppoinment" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-hover table-light" DataKeyNames="Appointmentid" OnRowCommand="GridAppoinment_RowCommand"
                                GridLines="None" OnRowDataBound="GridAppoinment_RowDataBound"
                                ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
											<ItemTemplate>
												<asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
												<asp:Label ID="lblAp" runat="server" Text='<%# Eval("Appointmentid") %>' Visible="false"></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>--%>

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
                                                <asp:LinkButton ID="linkApporuval" CommandArgument='<%# Eval("Appointmentid") %>' CommandName="Approve" ToolTip="Approve" runat="server"><i class="fa fa-check"></i></asp:LinkButton>
                                                <asp:LinkButton ID="LinkRegect" CommandArgument='<%# Eval("Appointmentid") %>' CommandName="Reject" ToolTip="Reject" runat="server"> <i class="fa fa-times-circle"></i></asp:LinkButton>


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
                                

                                    <div class="actions text-center">
                            <div class="btn-group btn-group-devided">

                                <asp:Button ID="Button1" runat="server" class="btn green btn-outline btn-sm active" Text="Book An Appointment" OnClick="Button1_Click" />

                                <asp:Button ID="Button2" class="btn  green btn-outline btn-sm" runat="server" Text="View More" OnClick="Button2_Click" />

                            </div>

                        </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-xs-12 col-sm-12">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption ">
                                        <span class="caption-subject font-dark bold uppercase">Branches/Clinics</span>
                                        
                                    </div>
                                    <div class="actions">
                                       <div class="btn-group">
                                         
                                            <asp:DropDownList ID="ddlstate" class="btn dark btn-outline btn-circle btn-sm " runat="server" AutoPostBack="True" OnSelectedIndexChanged="State_SelectedIndexChanged">
                              
                                              </asp:DropDownList>
                                      
                                        </div>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                 
                                    <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" DataKeyNames="ClinicID" 
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging"
                                 ShowHeaderWhenEmpty="true" PageSize="7">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No." >
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Clinic Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClinicName" runat="server" Text='<%# Eval("ClinicName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone No." >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("PhoneNo1") + ",</br> " + Eval("PhoneNo2")%>'></asp:Label>
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
                                      
                    <div class="row">
                        <div class="col-lg-12 col-xs-12 col-sm-12">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption caption-md">
                                        <i class="icon-bar-chart font-dark hide"></i>
                                        <span class="caption-subject font-dark bold uppercase">Enquiries</span>
                                       
                                    </div>
                                    <div class="actions">
                                        <div class="btn-group">
                                            <asp:DropDownList ID="ddlyear1" class="btn dark btn-outline btn-circle btn-sm " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                              
                                              </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                   <div id="morris_chart_2" style="height:500px;">
                                    

                                      <div class="row">


                                            <div id="chartline">
                                            </div>

                                        </div>




                                    <%--<asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                class="table table-bordered table-hover" DataKeyNames="EnquiryID"
                                GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging"
                                OnRowDeleting="gvShow_RowDeleting" OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("EnquiryID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enquiry No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Enquiryno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Source Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrandNameSourcename" runat="server" Text='<%# Eval("Sourcename") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mobile No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrandNameMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Email ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBrandNameEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnquiryDate" runat="server" Text='<%# Eval("EnquiryDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit" Visible="false">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" CommandArgument='<%# Eval("EnquiryID") %>'
                                                CommandName="EditEnquiry" ImageUrl="../Images/right15x15.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" Visible="false">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete"
                                                ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Enquiry?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <EmptyDataTemplate>
                                    No Record Available
                                </EmptyDataTemplate>
                            </asp:GridView>--%>

                                    </div>
                                </div>
                            </div>
                        </div>
                      
                    </div>
                   
                    <div class="row">
                        <div class="col-lg-6 col-xs-12 col-sm-12">
                            <!-- BEGIN REGIONAL STATS PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-share font-dark hide"></i>
                                        <span class="caption-subject font-dark bold uppercase">Source Of Enquiries</span>
                                    </div>
                                    <div class="actions">
                                         <asp:DropDownList ID="ddlClinic" class="btn dark btn-outline btn-circle btn-sm "  Visible="false" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged">
                              
                                              </asp:DropDownList>
                                   
                                 <div class="btn-group">
                                             
                                        </div>
                                        <div class="btn-group">
                                            <asp:DropDownList ID="ddlYearSOE" class="btn dark btn-outline btn-circle btn-sm " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYearSOE_SelectedIndexChanged">
                              
                                              </asp:DropDownList>
                                        </div>
                                        
                                    </div>
                                </div>
                                <div class="portlet-body">
                                  <div id="morris_chart_4" style="height:500px;">

                                      <div id="visualization" style="width: 460px; height: 350px;">
                                      </div>


                                  </div>
                                </div>
                            </div>
                            
                        </div>
                        <div class="col-lg-6 col-xs-12 col-sm-12">
                            <!-- BEGIN PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title tabbable-line">
                                    <div class="caption">
                                        <i class="icon-globe font-dark hide"></i>
                                        <span class="caption-subject font-dark bold uppercase">Collection & Expenses</span>
                                    </div>
                                  <div class="actions">
                                        <div class="btn-group">
                                          <asp:DropDownList ID="ddlClinicCollection" class="btn dark btn-outline btn-circle btn-sm " Visible="false" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClinicCollection_SelectedIndexChanged">
                              
                                              </asp:DropDownList>
                                        </div>
                                        
                                        <div class="btn-group">
                                              


                                              <asp:DropDownList ID="ddlYearCollection" class="btn dark btn-outline btn-circle btn-sm " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYearCollection_SelectedIndexChanged">
                              
                                              </asp:DropDownList>
                                        </div>
                                        </div>
                                </div>
                                <div class="portlet-body">
                                
                                    <div id="morris_chart_3" style="height:500px;">

                                        <div>

        <asp:Literal ID="lt" runat="server"></asp:Literal>   

       <div id="chart_div"></div>



                                    </div>

                                </div>
                            </div>
                            <!-- END PORTLET-->
                        </div>
                    </div>
                 
                </div>
        </div>
</asp:Content>
