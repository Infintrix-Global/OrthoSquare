<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="NewAppointmentClinic.aspx.cs" Inherits="OrthoSquare.Master.NewAppointmentClinic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='../fullcalendar.min.css' rel='stylesheet' />
    <link href='../fullcalendar.print.min.css' rel='stylesheet' media='print' />
    <script src='../lib/moment.min.js'></script>
    <script src='../lib/jquery.min.js'></script>
    <script src='../fullcalendar.min.js'></script>

    <script>

        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "NewAppointmentClinic.aspx/TestOnWebService",
                data: "{Docterid: '" + $("[id*=ddlDocter]").val() + "',Docterid1: '" + $("[id*=TextBox1]").val() + "'}",


                //data: "{Docterid: '" + $("[id*=ddlDocter]").val() + "',Docterid1: '" + $(s1).val() + "'}",

              //  data: '{Docterid: "' + s1 + '",Docterid1: "' + s1 + '"}',

              
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (doc) {

                    var events = [];
                    var docd = doc.d;


                    var obj = $.parseJSON(doc.d);
                    console.log(obj);
                    // alert(doc.d);

                    $('#calendar').fullCalendar({
                        header: {
                            left: 'prev,next today',
                            center: 'title',
                            right: 'month,agendaWeek,agendaDay'
                        },
                        navLinks: true, // can click day/week names to navigate views
                        selectable: true,
                        selectHelper: true,
                       
                       
                        select: function (start, end) {
                            // var title = prompt('Even t Title:');

                            url: "default.html";
                            var s1 = start;
                            


                         <%--   $('#<%=TextBox1.ClientID%>').text(s1);--%>

                          <%--  $('#<%=TextBox1.ClientID %>').text(s1);--%>

                            $('#<%= TextBox1.ClientID %>').val(s1);

<%--                            $('#<%= Edit.ClientID %>').hide();--%>
                           

                            //$("#Edit").hide();
                            //url: "~/Master/BookAppointment.aspx?DateTime='" + $("[id*=TextBox1]").val() + "'";

                            window.location = "BookAppointment.aspx?DateTime='" + $("[id*=TextBox1]").val() + "'&ddlDocter='" + $("[id*=ddlDocter]").val() + "'";
                            var eventData;

                            if (title) {
                               
                                eventData = {
                                    title: title,
                                    start: start,
                                    end: end

                                };
                                $('#calendar').fullCalendar('renderEvent', eventData, true); // stick? = true
                                $('#DivID').fullCalendar('renderEvent', eventData, true); // stick? = true

                               
                                
                            }
                            $('#calendar').fullCalendar('unselect');
                        },

                        //eventClick: function () {

                        //},

                        editable: false,

                        events: obj //Just pass obj to events
                    })
                    console.log(events);

                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        });

    </script>



      
    <style>
        body {
            margin: 40px 10px;
            padding: 0;
            font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
            font-size: 14px;
        }

        #calendar {
            max-width: 900px;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content" id="Edit" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Appointment</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Appointment</span>
                        </div>

                    </div>

                    <div class="row ">
                        <div class="col-xs-12">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlClinic" class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                    
                                    
                                </div>
                                <div class="col-sm-3">
                                      <asp:DropDownList ID="ddlDocter" class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlDocter_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPinCode" runat="server" ControlToValidate="ddlDocter" InitialValue ="0"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Docter" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-1">
                                    <label>
                                    </label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="TextBox1" class="form-control" style="display:none"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                   
                   
                     <asp:Label ID="lblDate" runat="server" Visible="false" Text=""></asp:Label>

                   
                     <div id="DivID" ></div>
                    <div class="row ">
                        <div class="col-xs-12">
                           <div class="form-group">
                                <div class="col-sm-8">
                                    <div id='calendar'>

                                    </div>
                                </div>
                                <div class="col-sm-4">
                                      
                                    <div class="row">
                        
                            <div class="portlet light ">
                                
                                <div class="portlet-body">
                                    
                                   
                                        
                                       <div class="mt-widget-3">
                                                <div class="mt-head bg-blue-hoki">
                                                   <div class="mt-head-desc">Today's Schedule</div>
                                                 </div>
                                                 <div class="margin text-center">
                                                 <button class="btn  green btn-outline btn-sm">Walk In Appointment</button>
                                                 </div>
                                                 <div class="tabbable-line">
                                        <ul class="nav nav-tabs ">
                                            <li class="active">
                                                <a href="#tab_15_1" data-toggle="tab"> All </a>
                                            </li>
                                            <li>
                                                <a href="#tab_15_2" data-toggle="tab"> Online </a>
                                            </li>
                                            <li>
                                                <a href="#tab_15_3" data-toggle="tab"> Offline </a>
                                            </li>
                                        </ul>
                                        <div class="tab-content">
                                            <div class="tab-pane active" id="tab_15_1">
                                            <table class="table table-striped">
                                            <tbody>
                                            <tr>
                                            <th>Today</th>
                                            <th>Waiting</th>
                                            <th>confirm </th>
                                            <th>Done</th>
                                            </tr>
                                            <tr>
                                            <td>
                                                <asp:Label ID="lblTotalAppoiment" runat="server" Text="10"></asp:Label></td>
                                            <td><asp:Label ID="lblTotalWaiting" runat="server" Text="10"></asp:Label></td>
                                            <td><asp:Label ID="lblTotalconfirm" runat="server" Text="10"></asp:Label></td>
                                            <td><asp:Label ID="lblTotalDone" runat="server" Text="10"></asp:Label></td>
                                            </tr>
                                            </tbody>
                                            
                                            </table>
                                     
                                            </div>
                                            

                                            <div class="tab-pane" id="tab_15_2">
                                           <table class="table">
                                            <tbody>
                                            <tr>
                                            <th>Today</th>
                                            <th>Waiting</th>
                                            <th>confirm</th>
                                            <th>Done</th>
                                            </tr>
                                            <tr>
                                            <td>
                                                <asp:Label ID="lbltodayonlineTotal" runat="server" Text="2"></asp:Label></td>
                                            <td><asp:Label ID="lblOnlineWaiting" runat="server" Text="5"></asp:Label></td>
                                            <td><asp:Label ID="lblonlineconfirm" runat="server" Text="7"></asp:Label></td>
                                            <td><asp:Label ID="lblonlineeDone" runat="server" Text="3"></asp:Label></td>
                                            </tr>
                                            </tbody>
                                            
                                            </table>
                                            </div>

                                            <div class="tab-pane" id="tab_15_3">
                                            <table class="table">
                                            <tbody>
                                            <tr>
                                            <th>Today</th>
                                            <th>Waiting</th>
                                            <th>Engaged</th>
                                            <th>Done</th>
                                            </tr>
                                            <tr>
                                            <td>
                                                <asp:Label ID="lbltodayOfflineTotal" runat="server" Text="2"></asp:Label></td>
                                            <td><asp:Label ID="lblOfflineWaiting" runat="server" Text="5"></asp:Label></td>
                                            <td><asp:Label ID="lblOfflineconfirm" runat="server" Text="7"></asp:Label></td>
                                            <td><asp:Label ID="lblOfflineeDone" runat="server" Text="3"></asp:Label></td>
                                            </tr>
                                            </tbody>
                                            
                                            </table>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <p>10.45 Patient Name</p>
                                    <p>Dr. ABC Test</p>
                                            
                                            </div>
                                       
                                    </div>
                                </div>
                            </div>
                                     
                                </div>
                           </div>
                        </div>
                    </div>

                    
                    
                </div>
            </div>
        </div>
    </div>








    


    <script type="text/javascript">

        function checkDate(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select a future date !");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }




    </script>
</asp:Content>
