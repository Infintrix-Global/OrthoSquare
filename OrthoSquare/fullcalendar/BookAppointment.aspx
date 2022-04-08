<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="OrthoSquare.Master.BookAppointment" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content" id="Add" visible="false" runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Book Appointment</span>
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
                            <span class="caption-subject bold uppercase">Book Appointment</span>
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

                                    <label>Clinic Name</label>
                                    <asp:DropDownList ID="ddlClinic" class="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged1"></asp:DropDownList>

                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClinic" InitialValue="0"
                                            SetFocusOnError="true" ErrorMessage="Please Enter Clinic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </span>
                                </div>


                                <div class="col-sm-3">

                                    <label>Doctor Name</label>

                                    <asp:DropDownList ID="ddlDoctor" class="form-control" runat="server"></asp:DropDownList>

                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDoctor" InitialValue="0"
                                            SetFocusOnError="true" ErrorMessage="Please Enter Doctor" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </span>

                                </div>
                                <div class="col-sm-3">

                                    
                                  
                                </div>

                            </div>
                        </div>
                    </div>
                          
                    
                    
                    
                        <div class="row">



                        <div class="col-md-6 ">

                            <div class="portlet-body form">

                                <div class="form-body">

                                    <div class="form-group">
                                        <label>Appointment No.</label>
                                        <asp:TextBox ID="txtPatientNo" class="form-control" ReadOnly="true" placeholder="Enter Patient No"
                                            runat="server"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label>First Name</label>
                                        <asp:TextBox ID="txtFname" class="form-control" placeholder="First Name" runat="server"></asp:TextBox>
                                        <span class="help-block">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFname"
                                                SetFocusOnError="true" ErrorMessage="Please Enter First name" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtFname"
                                                SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                            </asp:RegularExpressionValidator>
                                        </span>
                                    </div>

                                    <div class="form-group">
                                        <label>Date of Birth</label>
                                        <asp:TextBox ID="txtBDate" class="form-control" placeholder="Date of Birth" OnTextChanged="txtBDate_TextChanged"  runat="server"></asp:TextBox>
                                     <%--   <asp:CalendarExtender ID="txtBDate_CalendarExtender" OnClientDateSelectionChanged="checkDate" runat="server" Enabled="True"
                                            TargetControlID="txtBDate" Format="dd-MM-yyyy">
                                        </asp:CalendarExtender>--%>


                                          <asp:CalendarExtender ID="CalendarExtender1" OnClientDateSelectionChanged="checkDate" runat="server" Enabled="True"
                                                        TargetControlID="txtBDate" Format="dd-MM-yyyy">
                                                    </asp:CalendarExtender>
                                    </div>

                                    <div class="form-group">
                                        <label>Gender</label>

                                        <asp:RadioButtonList ID="RadGender" runat="server" class="md-radio-inline " RepeatDirection="Horizontal">
                                           <asp:ListItem Selected="True" Value="Male">Male</asp:ListItem>
                                            <asp:ListItem Value="Female" Text="Female">Female</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>


                                    <div class="form-group">
                                        <label>Mobile No.  <span class="required">*</span></label>

                                        <asp:TextBox ID="txtMobile" class="form-control" placeholder="Enter Mobile" runat="server"></asp:TextBox>



                                        <span class="help-block">
                                            <asp:RequiredFieldValidator ID="RequiredMobile" runat="server" ControlToValidate="txtMobile"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server"
                                                Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobile"
                                                SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>



                                    </div>


                                </div>

                            </div>

                        </div>


                        <div class="col-md-6">
                            <div class="portlet light form-fit ">

                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->
                                    <div class="form-body">

                                        <div class="form-group">
                                            <label>Date</label>
                                            <asp:TextBox ID="txtRegDate" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtENqDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtRegDate" Format="dd-MM-yyyy">
                                            </asp:CalendarExtender>

                                        </div>
                                        <div class="form-group">
                                            <label>Last Name <%--<span class="required">*</span>--%></label>
                                            <asp:TextBox ID="txtLname" class="form-control" placeholder="Enter Last Name" runat="server"></asp:TextBox>

                                            <span class="help-block">
                                              <%--  <asp:RequiredFieldValidator ID="RequiredLname" runat="server" ControlToValidate="txtLname"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Last name" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorLname" runat="server"
                                                    ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtLname"
                                                    SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                </asp:RegularExpressionValidator>
                                            </span>

                                        </div>
                                        <div class="form-group">
                                            <label>Age</label>
                                            <asp:TextBox ID="txtAge" class="form-control"  placeholder="Enter Age" runat="server"></asp:TextBox>

                                            <span class="help-block">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red"
                                                    ErrorMessage="Only Number is allowed" Display="Dynamic" ControlToValidate="txtAge"
                                                    SetFocusOnError="True" ValidationExpression="^\d+$">
                                                </asp:RegularExpressionValidator>
                                            </span>
                                        </div>


                                        <div class="form-group">
                                            <label>Email</label>
                                            <asp:TextBox ID="txtEmail" class="form-control" placeholder="Enter Email" runat="server"></asp:TextBox>

                                            <span class="help-block">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                    ForeColor="Red" ErrorMessage="Enter Proper Email ID" Display="Dynamic" ControlToValidate="txtEmail"
                                                    SetFocusOnError="True" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">
                                                </asp:RegularExpressionValidator>
                                            </span>
                                        </div>

                                        <div class="form-group">
                                            <label>Telephone No.</label>
                                            <asp:TextBox ID="txtTelephone" class="form-control" placeholder="Enter Telephone"
                                                runat="server"></asp:TextBox>

                                        </div>



                                    </div>

                                </div>
                            </div>
                        </div>
                        <!-- END CONTENT BODY -->
                    </div>
                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btAdd_Click" />
                            <asp:Button ID="btUpdate" ClientIDMode="Static" class="btn blue" runat="server"
                                Text="Update" Visible="False" />
                            <asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                CausesValidation="False" />


                        </div>

                    </div>
                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>


    </div>


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
                    <span>Book Appointment</span>
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
                            <span class="caption-subject font-red sbold uppercase">Book Appointment</span>
                        </div>
                        
                    </div>
                    <div class="portlet-body">
                       

                        <div class="row">
                              
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:RadioButtonList ID="RadioButtonList1"   OnTextChanged="RadioButtonList1_SelectedIndexChanged" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Text="Enquiry" Selected="True"></asp:ListItem>
                                             <asp:ListItem Value="1" Text="Patient"></asp:ListItem>

                                        </asp:RadioButtonList>
                                       
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                         
                                     
                                       
                                    </div>
                                </div>
                                <!-- Usage as a class -->
                                
                            </div>


                        <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <%-- <label for="form_control_1">
                                            Visitor Name <span class="required"></span>
                                        </label>--%>
                                        <asp:TextBox ID="txtPno" runat="server" class="form-control" placeholder="Patient Name"
                                            ClientIDMode="Static" MaxLength="80"></asp:TextBox>

                                          <asp:Label ID="lblDateTime" runat="server" Visible="false" Text=""></asp:Label>
                                          <asp:Label ID="lblDocterID" runat="server" Visible="false" Text=""></asp:Label>
                                        <span class="help-block">
                                            
                                        </span>
                                       
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                         <%--<label for="form_control_1">
                                            Mobile No. <span class="required"></span>
                                        </label>--%>
                                        <asp:TextBox ID="txtsMobile" runat="server" class="form-control" placeholder="Mobile No."
                                            ClientIDMode="Static" MaxLength="15"></asp:TextBox>
                                        <span class="help-block">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtsMobile"
                                                SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                       
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                         
                                        <asp:Button ID="btSearch" runat="server" Text="Search" CausesValidation="false" class="btn blue-hoki" ClientIDMode="Static"
											OnClick="btSearch_Click" />
                                       
                                    </div>
                                </div>
                                <!-- Usage as a class -->
                                <div class="col-md-4">
                                     <div class="form-group">

                                       
                                    </div>
                                </div>
                            </div>
                        
                         
                        

                            <!-- Usage as a class -->

                       <div class="text-right mb-20">
                                 <asp:Button ID="btnAddNew" runat="server"  Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                            CausesValidation="False" OnClick="btnAddNew_Click" />
                                 </div>
                        <div class="table-scrollable">
                            <asp:Panel ID="PanelPatient" runat="server">
                            <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
									class="table table-bordered table-hover" DataKeyNames="patientid"
									GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
									 ShowHeaderWhenEmpty="true">
                                   <Columns>
                                        <asp:TemplateField >
                                              <ItemTemplate >

                                                  <asp:Button ID="btnSelect" CommandName ="SelectP" CausesValidation="false" runat="server" CommandArgument = '<%# Eval("patientid") %>' class="btn blue" Text="Select" />
                                              </ItemTemplate>


                                        </asp:TemplateField>

                                   </Columns>
									<Columns>


										<asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
											<ItemTemplate>
												<asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
												<asp:Label ID="lblID" runat="server" Text='<%# Eval("patientid") %>' Visible="false"></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Patient No" ItemStyle-Width="10%">
											<ItemTemplate>
												<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("PatientCode") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Name" ItemStyle-Width="26%">
											<ItemTemplate>
												<asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("FristName") +"  "+ Eval("LastName") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										
										<asp:TemplateField HeaderText="Mobile No" ItemStyle-Width="18%">
											<ItemTemplate>
												<asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										
                                        <asp:TemplateField HeaderText="Registration Date" ItemStyle-Width="18%">
											<ItemTemplate>
												  <asp:Label ID="lblstart_date" runat="server" Text='<%# Eval("RegistrationDate","{0:dd/MMM/yyyy}") %>'></asp:Label>
                                            
											</ItemTemplate>
										</asp:TemplateField>

										<%--<asp:TemplateField HeaderText="Edit" Visible="false" ItemStyle-Width="3%">
											<ItemTemplate>
												<asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" CommandArgument='<%# Eval("patientid") %>'
													CommandName="EditEnquiry" ImageUrl="../Images/right15x15.png" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Delete" ItemStyle-Width="2%">
											<ItemTemplate>
												<asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete"
													ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Enquiry?');" />
											</ItemTemplate>
										</asp:TemplateField>--%>
									</Columns>
									<PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
									<PagerSettings Mode="NumericFirstLast" />
									<EmptyDataTemplate>
										No Record Available
									</EmptyDataTemplate>
								</asp:GridView>
                                </asp:Panel>
                              <asp:Panel ID="PanelEnquiry" runat="server">
                                  <asp:GridView ID="GridEnquiry" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        class="table table-bordered table-hover" DataKeyNames="EnquiryID"
                                        GridLines="None" OnPageIndexChanging="GridEnquiry_PageIndexChanging" OnRowCommand="GridEnquiry_RowCommand"
                                       >
                                      <Columns>
                                        <asp:TemplateField >
                                              <ItemTemplate >

                                                  <asp:Button ID="btnSelect1" CommandName ="SelectP" CausesValidation="false" runat="server" CommandArgument = '<%# Eval("EnquiryID") %>' class="btn blue" Text="Select" />
                                              </ItemTemplate>


                                        </asp:TemplateField>

                                   </Columns>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." >
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("EnquiryID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Enquiry No" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryno" runat="server" Text='<%# Eval("Enquiryno") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Mobile No" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         

                                            <asp:TemplateField HeaderText="Date" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%# Eval("EnquiryDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                           
                                            
                                        </Columns>
                                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                  </asp:Panel>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>


</asp:Content>
