<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="EnquiryDetails.aspx.cs" Inherits="OrthoSquare.Enquiry.EnquiryDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function OpenWindow()
    {
	//Open the Popup window
	//Change the pagename here
        window.open('EnquirySource.aspx', '_blank', 'height=450,width=500,scrollbars=0,location=1,toolbar=0');
    }
    </script>

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
                            <span>Enquiry </span>
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
                                    <span class="caption-subject bold uppercase">Enquiry</span>
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
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                            <div class="row">



                                <div class="col-md-6 ">

                                    <div class="portlet-body form">

                                        <div class="form-body">

                                            <div class="form-group">
                                                <label>Enquiry No.</label>
                                                <asp:TextBox ID="txtEnquiryNO" class="form-control" placeholder="Enter Enquiry No" TabIndex ="1"
                                                    runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>First Name</label>
                                                <asp:TextBox ID="txtFname" class="form-control" placeholder="First Name" TabIndex ="3" runat="server"></asp:TextBox>
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
                                                <asp:TextBox ID="txtBDate" class="form-control" placeholder="Date of Birth" OnTextChanged="txtBDate_TextChanged" TabIndex ="5" AutoPostBack="true" runat="server"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtBDate_CalendarExtender" runat="server" Enabled="True"
                                                    TargetControlID="txtBDate" Format="dd-MM-yyyy">
                                                </asp:CalendarExtender>
                                            </div>

                                            <div class="form-group">
                                                <label>Gender</label>
                                               
                                                    <asp:RadioButtonList ID="RadGender" runat="server" Width="300px" class="md-radio-inline " TabIndex ="7" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="Male"> Male </asp:ListItem>
                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                    </asp:RadioButtonList>
                                              
                                            </div>

                                            <div class="form-group">
                                                <label>Address</label>
                                                <asp:TextBox ID="txtAddress" class="form-control" placeholder="Enter Address" runat="server" TabIndex ="9"
                                                    TextMode="MultiLine"></asp:TextBox>

                                                <span class="help-block">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredtxtAddress" runat="server" ControlToValidate="txtAddress"
											SetFocusOnError="true" ErrorMessage="Please Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                </span>
                                            </div>

                                            <div class="form-group">
                                                <label>Country</label>
                                                <asp:DropDownList ID="ddlCountry" class="form-control" runat="server" AutoPostBack="True" TabIndex ="11"
                                                    OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="form-group">
                                                <label>City</label>
                                                <asp:DropDownList ID="ddlCity" class="form-control" TabIndex ="13" runat="server">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="form-group">
                                                <label>Mobile No 1.  <span class="required">*</span></label>

                                                <asp:TextBox ID="txtMobile" class="form-control" placeholder="Enter Mobile" TabIndex ="15" runat="server"></asp:TextBox>

                                                <span class="help-block">
                                                    <asp:RequiredFieldValidator ID="RequiredMobile" runat="server" ControlToValidate="txtMobile"
                                                        SetFocusOnError="true" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server"
                                                        Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobile"
                                                        SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </span>


                                            </div>

                                            <div class="form-group">
                                                <label>Clinic Name <span class="required">*</span></label>
                                                <asp:DropDownList ID="ddlclinic" class="form-control" TabIndex ="17" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclinic_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClinic" runat="server" ControlToValidate="ddlclinic" InitialValue="0"
                                                        SetFocusOnError="true" ErrorMessage="Please Select Clinic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>
                                            </div>



                                            <div class="form-group">

                                                 <label>Patient / Followup<span class="required">*</span></label>

                                                <div class="form-group form-md-line-input ">
                                                    <asp:RadioButtonList ID="Rabinfo" runat="server" RepeatDirection="Horizontal" TabIndex ="19" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="Rabinfo_SelectedIndexChanged">
                                                        <asp:ListItem Value="Patient">Patient</asp:ListItem>
                                                        <asp:ListItem Value="Followup">Followup</asp:ListItem>
                                                    </asp:RadioButtonList>

                                                     <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Rabinfo"
                                                            SetFocusOnError="true" ErrorMessage="Select Patient / Followup" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>





                                            </div>

                                            <div class="form-group">
                                                <label>Interest Level <span class="required">*</span></label>

                                                <div class="form-group form-md-line-input ">
                                                    <asp:RadioButtonList ID="RadInterestLavel" runat="server" RepeatDirection="Horizontal" TabIndex ="21"
                                                        Width="300px">
                                                        <asp:ListItem Selected="True" Text="1">1</asp:ListItem>
                                                        <asp:ListItem Text="2">2</asp:ListItem>
                                                        <asp:ListItem Text="3">3</asp:ListItem>
                                                        <asp:ListItem Text="4">4</asp:ListItem>
                                                        <asp:ListItem Text="5">5</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorInterest" runat="server" ControlToValidate="RadInterestLavel"
                                                            SetFocusOnError="true" ErrorMessage="Select Interest Lavel" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>

                                                </div>





                                            </div>


                                            <div class="form-group">
                                                <label>Patient Status <span class="required">*</span></label>

                                                <div class="form-group form-md-line-input ">
                                                    <asp:RadioButtonList ID="RBtnLstPsta" runat="server" RepeatDirection="Horizontal" TabIndex ="21"
                                                        Width="500px">
                                                        <asp:ListItem Selected="True" Text="1">Less Co-operative </asp:ListItem>
                                                        <asp:ListItem Text="2">Co-operative </asp:ListItem>
                                                        <asp:ListItem Text="3">Very Co-operative </asp:ListItem>
                                                        
                                                    </asp:RadioButtonList>
                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadInterestLavel"
                                                            SetFocusOnError="true" ErrorMessage="Select Interest Lavel" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </span>

                                                </div>





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
                                                    <label>Enquiry Date</label>
                                                    <asp:TextBox ID="txtENqDate" class="form-control" TabIndex ="2" runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtENqDate_CalendarExtender" runat="server" Enabled="True"
                                                        TargetControlID="txtENqDate" Format="dd-MM-yyyy">
                                                    </asp:CalendarExtender>

                                                </div>
                                                <div class="form-group">
                                                    <label>Last Name <span class="required">*</span></label>
                                                    <asp:TextBox ID="txtLname" class="form-control" TabIndex ="4" placeholder="Enter Last Name" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RequiredFieldValidator ID="RequiredLname" runat="server" ControlToValidate="txtLname"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Last name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorLname" runat="server"
                                                            ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtLname"
                                                            SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                                        </asp:RegularExpressionValidator>
                                                    </span>

                                                </div>
                                                <div class="form-group">
                                                    <label>Age</label>
                                                    <asp:TextBox ID="txtAge" class="form-control" TabIndex ="6" placeholder="Enter Age" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red"
                                                            ErrorMessage="Only Number is allowed" Display="Dynamic" ControlToValidate="txtAge"
                                                            SetFocusOnError="True" ValidationExpression="^\d+$">
                                                        </asp:RegularExpressionValidator>
                                                    </span>
                                                </div>
                                                <div class="form-group">
                                                    <label>Email</label>
                                                    <asp:TextBox ID="txtEmail" class="form-control" TabIndex ="8" placeholder="Enter Email" runat="server"></asp:TextBox>

                                                    <span class="help-block">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                            ForeColor="Red" ErrorMessage="Enter Proper Email ID" Display="Dynamic" ControlToValidate="txtEmail"
                                                            SetFocusOnError="True" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">
                                                        </asp:RegularExpressionValidator>
                                                    </span>
                                                </div>

                                                <div class="form-group">
                                                    <label>Area  </label>

                                                    <asp:TextBox ID="txtArea" class="form-control" TabIndex ="10" placeholder="Enter Area" TextMode="MultiLine"
                                                        runat="server"></asp:TextBox>

                                                </div>

                                                <div class="form-group">
                                                    <label>State</label>
                                                    <asp:DropDownList ID="ddlState" class="form-control" runat="server" AutoPostBack="True" TabIndex ="12"
                                                        OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>Enquiry Source <span class="required">*</span></label>
                                                    <asp:DropDownList ID="ddlEnquirySource" class="form-control" TabIndex ="14" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlEnquirySource_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="LinkButton1" Visible="false" runat="server" OnClientClick="OpenWindow();return false;">Add</asp:LinkButton>
                                                </div>
                                                <div class="form-group">
                                                    <label>Mobile No 2.</label>
                                                    <asp:TextBox ID="txtTelephone" class="form-control" placeholder="Enter Telephone" TabIndex ="16"
                                                        runat="server"></asp:TextBox>
                                                    <span class="help-block">
                                                      
                                                     
                                                           <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile2" runat="server"
                                                            Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtTelephone"
                                                            SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </span>

                                                </div>
                                                <br />
                                                <div class="form-group">
                                                    <label>Assign To</label>
                                                    <asp:DropDownList ID="ddlAssign" class="form-control" TabIndex ="18" runat="server">
                                                    </asp:DropDownList>
                                                </div>

                                                <div class="form-group"  runat="server" visible="false"  id ="IDF">
                                                    <label>Followup date</label>
                                                    <asp:TextBox ID="txtFollowupDate"  placeholder="Enter Followup" class="form-control" TabIndex ="20"
                                                        runat="server"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFollowupDate_CalendarExtender" runat="server" Enabled="True"
                                                        TargetControlID="txtFollowupDate" Format="dd-MM-yyyy">
                                                    </asp:CalendarExtender>

                                                </div>
                                                <br />
                                                 <div class="form-group">
                                                     <label >
                                                    Conversation details 
                                                  </label>
                                                      <asp:TextBox ID="txtConversion" TextMode="MultiLine" class="form-control" TabIndex ="22" runat="server"></asp:TextBox>
                                               
                                                 </div>
                                                <br />
                                                 <div class="form-group">
                                                     <label >
                                                    Enquiry For  <span class="required">*</span>
                                                  </label>
                                                     <asp:DropDownList ID="ddlTreatment" class="form-control" TabIndex ="24"  runat="server"></asp:DropDownList>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorMobileddlTreatment" runat="server" ControlToValidate="ddlTreatment" InitialValue ="0"
                                                            SetFocusOnError="true" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                                     
                                                    
                                                 </div>
                                                   
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <!-- END CONTENT BODY -->
                            </div>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="row">
                                <div class="form-actions text-center">

                                    <asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static"
                                        OnClick="btAdd_Click" />
                                    <asp:Button ID="btUpdate" ClientIDMode="Static" class="btn blue" runat="server"
                                        Text="Update" Visible="False" OnClick="btUpdate_Click" />
                                    <asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                        OnClick="btBack_Click" CausesValidation="False" />



                                </div>

                            </div>

                        </div>
                        <!-- END CONTENT BODY -->
                    </div>


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
                            <span>Enquiry</span>
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
                                    <span class="caption-subject font-red sbold uppercase">Enquiry</span>
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
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Search</label>
                                            <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Name"
                                                ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Search</label>
                                            <asp:DropDownList ID="ddlEnquirysourceSearch" class="form-control" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group form-md-line-input ">




                                            <asp:Button ID="btSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                                OnClick="btSearch_Click" />

                                        </div>
                                    </div>
                                </div>


                                <!-- Usage as a class -->
                                <div class="text-right mb-20">
                                     <asp:Button ID="Button1" runat="server" Text="excel upload" class="btn blue-madison" ClientIDMode="Static"
                                        CausesValidation="False" OnClick="btnAddexcelupload_Click" />

                                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn blue-madison" ClientIDMode="Static"
                                        CausesValidation="False" OnClick="btnAddNew_Click" />
                                </div>
                                <div class="table-scrollable">

                                    <asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        class="table table-bordered table-hover" DataKeyNames="EnquiryID"
                                        GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" OnRowCommand="gvShow_RowCommand"
                                        OnRowDeleting="gvShow_RowDeleting" OnRowEditing="gvShow_RowEditing" ShowHeaderWhenEmpty="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("EnquiryID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Enquiry No" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Enquiryno") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" ItemStyle-Width="26%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Source Name" ItemStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBrandName" runat="server" Text='<%# Eval("Sourcename") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryDate" runat="server" Text='<%# Eval("EnquiryDate","{0:dd/MMM/yyyy}") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                           
                                            <asp:TemplateField  ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    
                                                    <asp:ImageButton ID="btnUpdate" CausesValidation="false" runat="server" CommandArgument='<%# Eval("EnquiryID") %>' ToolTip ="Edit"
                                                        CommandName="EditEnquiry" ImageUrl="../Images/right15x15.png" />

                                                     <asp:ImageButton ID="btnview" CausesValidation="false" runat="server" Height="15px"  CommandArgument='<%# Eval("EnquiryID") %>' ToolTip="View"
                                                CommandName="viewEnqDetails" ImageUrl="../Images/view2.png" />
                                                    
                                                    <asp:ImageButton ID="lbtDelete" CausesValidation="false" runat="server" CommandName="delete" ToolTip="Delete"
                                                        ImageUrl="../Images/delete15x15.png" OnClientClick="return confirm('Are you sure you want to delete this Enquiry?');" />
                                              
                                                    
                                                    
                                                    
                                                    
                                                    
                                                      </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <EmptyDataTemplate>
                                            No Record Available
                                        </EmptyDataTemplate>
                                    </asp:GridView>

                                    

                                     <asp:LinkButton ID="btnExcel1" class="btn btn-sm btn-outline-primary btn-round" runat="server"
                                    CausesValidation="false" OnClick="btnExcel1_Click1" >
                                <i class="fa fa-cloud-download"></i>
                               <span class="text">Export</span></asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>
      
        
        <div class="page-content" id="Div2" visible="false"  runat="server">
                <!-- BEGIN PAGE HEADER-->


                <div class="page-bar">
                    <ul class="page-breadcrumb">
                        <li>
                            <i class="icon-home"></i>
                            <a href="index-2.html">Home</a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            <span>Enquiry </span>
                        </li>
                    </ul>

                </div>
                <!-- END PAGE HEADER-->

                <div class="row">
                    <div class="col-md-12">
                        <div style="margin-bottom: 5px;">
                            <asp:Label ID="lblMSG1" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                        </div>
                        <!-- BEGIN SAMPLE FORM PORTLET-->
                        <div class="portlet light ">
                            <div class="portlet-title">
                                <div class="caption font-red-sunglo">
                                    <i class="icon-settings font-red-sunglo"></i>
                                    <span class="caption-subject bold uppercase">Enquiry</span>
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
                                    <div class="col-sm-5">
                                        <label>
                                            Select Enquiry file: </label>

                                         <asp:FileUpload ID="flOptional" runat="server" Height="30px" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Button ID="btnOptionalUpload" runat="server" CausesValidation="false" class="btn blue-madison" Text="Upload"
                                    OnClick="btnOptionalUpload_Click" />
                                    </div>
                                    <div class="col-sm-4">
                                         <asp:Button ID="btndownloadOptional" runat="server" CausesValidation="false" class="btn blue-madison"
                                                Text="Download Blank Sheet" OnClick="btndownloadOptional_Click" />

                                    </div>
                                   
                                </div>
                            </div>
                                </div>
                            <br />
                            <div class="row">
                                <div class="form-actions text-center">

                                   
                                    <asp:Button ID="btnExlCancel" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                        OnClick="btbtnExlCancel_Click" CausesValidation="False" />



                                </div>

                            </div>
                            </div>
                        </div>
                    </div>
            </div>
           
        
        
        
       

</asp:Content>
