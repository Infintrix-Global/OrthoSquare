<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="FollowupDetails.aspx.cs" Inherits="OrthoSquare.Enquiry.FollowupDetails" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
   
   <asp:Panel ID="AddPane" Visible="false" runat="server">
        <div class="page-content"   runat="server">
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
        <div style="margin-bottom: 5px;">
        <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
        </div>
        <div class="row">
            <div class="col-xs-12 pad">
                <!-- Basic form -->
                <div class="portlet light ">
					<div class="portlet-title">
						<div class="caption font-red-sunglo">
							<i class="icon-settings font-red-sunglo"></i>
							<span class="caption-subject bold uppercase">Enquiry</span>
						</div>
                        </div>
                    <div class="panel-body">
                        <asp:Label ID="lblEqNo" runat="server" Visible="false" Text=""></asp:Label>
                        <asp:Label ID="lblEmpNo" runat="server" Visible="false" Text=""></asp:Label>
                        <asp:Label ID="lblEnqID" runat="server" Visible="false" Text=""></asp:Label>
                        <div class="form-horizontal">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label>
                                            Visitor Name</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblName" class="form-control-lable" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label>
                                            Enquiry Date</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblEnqDate" class="form-control-lable" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label>
                                            Address
                                        </label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblAddress" class="form-control-lable" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label>
                                            Mobile No
                                        </label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblMobileNo" class="form-control-lable" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label>
                                            Source</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblSourse" class="form-control-lable" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label>
                                           Email Id
                                        </label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblEmail" class="form-control-lable" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>



                            <div class="col-xs-12">
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        

                                        <asp:GridView ID="GridViewFolloup" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        class="table table-bordered table-hover" DataKeyNames="EnquiryID"
                                        GridLines="None" 
                                        ShowHeaderWhenEmpty="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                                  
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Docter Name" ItemStyle-Width="26%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("FirstName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Conversation Details" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblConversationDetails" runat="server" Text='<%# Eval("ConversationDetails") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Followupdate Date" ItemStyle-Width="18%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryDate1" runat="server" Text='<%# Eval("Followupdate","{0:dd/MMM/yyyy}") %>'></asp:Label>

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
                            <!-- Usage as a class -->
                        </div>
                    </div>
                    <div class="portlet-title">
						<div class="caption font-red-sunglo">
							<i class="icon-settings font-red-sunglo"></i>
							<span class="caption-subject bold uppercase">Today's Followup Information</span>
						</div>
                        </div>
                    <div class="portlet-body">
                                <!-- BEGIN FORM-->
                                <div class="form-body">
                                    <div class="row">
                                        <div class="col-md-6">
                                           <div class="form-group">
											<label>  Followup ID  <span class="required">*</span> </label>
                                                <asp:TextBox ID="txtFollowupID" class="form-control" runat="server"></asp:TextBox>
                                                <span class="help-block"></span>
                                               
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="form_control_1">
                                                    Today's FollowUp Date <span class="required">*</span>
                                                </label>
                                                <asp:TextBox ID="txtTodayFollowupdate" class="form-control" runat="server"></asp:TextBox>
                                               
                                                <span class="help-block"></span>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="form_control_1">
                                                    Employee Name <span class="required">*</span>
                                                </label>
                                                <asp:TextBox ID="txtEmployee" class="form-control" runat="server"></asp:TextBox>
                                                
                                                <span class="help-block"></span>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="form_control_1">
                                                    Follow Up Mode <span class="required">*</span>
                                                </label>
                                                <asp:DropDownList ID="ddlFollowupmode" class="form-control" runat="server">
                                                </asp:DropDownList>
                                               
                                                <span class="help-block">
                                                    <asp:RequiredFieldValidator ID="requiredFollowupmode" runat="server" SetFocusOnError="true"
                                                        ControlToValidate="ddlFollowupmode" ErrorMessage="Select Followup mode" InitialValue="0"
                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                 <label for="form_control_1">
                                                    Conversation details 
                                                </label>
                                                <asp:TextBox ID="txtConversion" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                               
                                                <span class="help-block"></span>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="form_control_1">
                                                    Next FollowUp Date <span class="required">*</span>
                                                </label>
                                                <asp:TextBox ID="txtNextFollowupDate" class="form-control" runat="server"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtNextFollowupDate_CalendarExtender" runat="server" Enabled="True"
                                                    TargetControlID="txtNextFollowupDate" Format="dd-MM-yyyy">
                                                </asp:CalendarExtender>
                                               
                                                <span class="help-block">
                                                    <asp:RequiredFieldValidator ID="RequiredNextFollowupDate" runat="server" SetFocusOnError="true"
                                                        ControlToValidate="txtNextFollowupDate" ErrorMessage="Select Next Followup Date"
                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="form_control_1">
                                                    Status <span class="required">*</span>
                                                </label>
                                                <asp:DropDownList ID="ddlStatus" class="form-control" runat="server">
                                                </asp:DropDownList>
                                               
                                                <span class="help-block">
                                                    <asp:RequiredFieldValidator ID="RequiredStatus" runat="server" SetFocusOnError="true"
                                                        ControlToValidate="ddlStatus" ErrorMessage="Select Status" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div class="col-md-12">
                                            <div class="form-group form-md-line-input">
                                                <label for="form_control_1">
                                                    Interest Level<span class="required">*</span>
                                                </label>
                                                <asp:RadioButtonList ID="RadInterestLavel" runat="server" RepeatDirection="Horizontal"
                                                    Width="300px">
                                                    <asp:ListItem Text="1">1</asp:ListItem>
                                                    <asp:ListItem Text="2">2</asp:ListItem>
                                                    <asp:ListItem Text="3">3</asp:ListItem>
                                                    <asp:ListItem Text="4">4</asp:ListItem>
                                                    <asp:ListItem Text="5">5</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <span class="help-block">
                                                    <asp:RequiredFieldValidator ID="RequiredRadInterestLavel" runat="server" ControlToValidate="RadInterestLavel"
                                                        SetFocusOnError="true" ErrorMessage="Select Interest Lavel" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                        <div class="col-md-12">
                                             
                                           <div class="form-group">
                                               <label for="form_control_1">
                                                    Remark
                                                </label>
                                                <asp:TextBox ID="txtRemark" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                               
                                                <span class="help-block"></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
						<div class="form-actions text-center">

							<asp:Button ID="btAdd" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static"
                                                OnClick="btAdd_Click" />
                                            <asp:Button ID="btnCancel1" runat="server" Text="Cancel" class="btn default" CausesValidation="False"
                                                OnClick="btnCancel1_Click" />


						</div>

					</div>

                                   
                                </div>
                            </div>
                    </div>
                
            </div>
        </div>
        </div>
   </asp:Panel>
     
  
    
     
    <asp:Panel ID="Edit" runat="server">
         <div id="Div1" runat="server" class="page-content">
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
                        <!-- BEGIN FORM-->
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                         <label for="form_control_1">
                                            Visitor Name <span class="required"></span>
                                        </label>
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
                                         <label for="form_control_1">
                                            Mobile No. <span class="required"></span>
                                        </label>
                                        <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Mobile No."
                                            ClientIDMode="Static" MaxLength="15"></asp:TextBox>
                                        <span class="help-block">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" runat="server"
                                                Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobile"
                                                SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                       
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="form_control_1">
                                            Source Type <span class="required"></span>
                                        </label>
                                        <asp:DropDownList ID="ddlSource" class="form-control" runat="server">
                                        </asp:DropDownList>
                                      
                                        <span class="help-block">
                                           
                                        </span>
                                       
                                    </div>
                                </div>
                                <!-- Usage as a class -->
                                <div class="col-md-3">
                                    <div class="form-group">
                                       <label for="form_control_1">
                                            Recieved by <span class="required"></span>
                                        </label>
                                      <%--  <asp:DropDownList ID="ddlRecievedby" class="form-control" runat="server">
                                        </asp:DropDownList>--%>
                                      
                                         <asp:DropDownList ID="ddlRecievedby" class="form-control" runat="server" >
                                         </asp:DropDownList>

                                        <span class="help-block">
                                           
                                        </span>
                                        
                                    </div>
                                </div>
                            </div>.
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                         <label for="form_control_1">
                                            From Enquiry Date <span class="required"></span>
                                        </label>
                                        <asp:TextBox ID="txtFromEnquiryDate" runat="server" class="form-control" placeholder="From Enquiry Date"
                                            ClientIDMode="Static"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtFromEnquiryDate_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromEnquiryDate">
                                        </asp:CalendarExtender>
                                        <span class="help-block">
                                         <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                ForeColor="Red" ErrorMessage="Only text is allowed" Display="Dynamic" ControlToValidate="txtSearch"
                                                SetFocusOnError="True" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$">
                                            </asp:RegularExpressionValidator>--%>
                                        </span>
                                       
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="form_control_1">
                                            To Enquiry Date <span class="required"></span>
                                        </label>
                                        <asp:TextBox ID="txtToEnquiryDate" runat="server" class="form-control" placeholder="To Enquiry Date"
                                            ClientIDMode="Static"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtToEnquiryDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                            Enabled="True" TargetControlID="txtToEnquiryDate">
                                        </asp:CalendarExtender>
                                        <span class="help-block">
                                           <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                Display="Dynamic" ErrorMessage="Please enter valid Mobile Number" ControlToValidate="txtMobile"
                                                SetFocusOnError="True" ValidationExpression="\+?\d[\d -]{8,12}\d" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                        </span>
                                        
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="form_control_1">
                                            From Followup Date  <span class="required"></span>
                                        </label>
                                      <asp:TextBox ID="txtSFromFollowDate" runat="server" class="form-control" placeholder="From Followup Date "
                                            ClientIDMode="Static"></asp:TextBox>
                                      
                                        <asp:CalendarExtender ID="txtSFromFollowDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                            Enabled="True" TargetControlID="txtSFromFollowDate">
                                        </asp:CalendarExtender>
                                      
                                        <span class="help-block">
                                           
                                        </span>
                                       
                                    </div>
                                </div>
                                <!-- Usage as a class -->
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="form_control_1">
                                            To Followup Date <span class="required"></span>
                                        </label>
                                        <asp:TextBox ID="txtSToFollowDate" runat="server" class="form-control" placeholder="To Followup Date"
                                            ClientIDMode="Static"></asp:TextBox>
                                      
                                        <asp:CalendarExtender ID="txtSToFollowDate_CalendarExtender" runat="server"  Format="dd-MM-yyyy"
                                            Enabled="True" TargetControlID="txtSToFollowDate">
                                        </asp:CalendarExtender>
                                      
                                        <span class="help-block">
                                           
                                        </span>
                                       
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn blue-hoki" ClientIDMode="Static"
                                            CausesValidation="False" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                            </div>


                            <div class="table-scrollable">
							 
							<asp:GridView ID="gvShow" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                            class="table table-bordered table-hover" DataKeyNames="EnquiryID"
                            GridLines="None" OnPageIndexChanging="gvShow_PageIndexChanging" ShowHeaderWhenEmpty="true"
                            OnRowCommand="gvShow_RowCommand" OnRowDataBound="gvShow_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("EnquiryID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblEnqNo" runat="server" Text='<%# Eval("Enquiryno") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enquiry Details" ItemStyle-Width="80%">
                                    <ItemTemplate>
                                        <table style="width: 100%;" border="1">
                                            <tr style="width: 100%;">
                                                <td style="width: 10%">
                                                    <asp:Label ID="LabelName" runat="server" Text=" Visitor Name: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblVisitorName" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                                </td>
                                                <%--Dhaval--%>
                                                 <td style="width: 10%">
                                                    <asp:Label ID="Label10" runat="server" Text="Enquiry For: " Font-Bold="true"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                                </td>
                                              
                                            </tr>
                                            <tr style="width: 100%">
                                                <td style="width: 10%">
                                                    <asp:Label ID="Label2" runat="server" Text=" Mobile No: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                                </td>
                                                <td style="width: 10%">
                                                    <asp:Label ID="Label3" runat="server" Text="Telephone No: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblTelephoneNo" runat="server" Text='<%# Eval("Telephone") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="width: 100%">
                                                <td style="width: 10%">
                                                    <asp:Label ID="Label4" runat="server" Text=" Enquiry Date: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblEnqDate" runat="server" Text='<%# Eval("EnquiryDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </td>
                                                <td style="width: 10%">
                                                    <asp:Label ID="Label5" runat="server" Text="Followup Date: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblFollowupDate" runat="server" Text='<%# Eval("Folllowupdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    <asp:Label ID="lblFollowupNextDate" runat="server" Text=""></asp:Label>
                                                    
                                                    </td>
                                            </tr>
                                            <tr style="width: 100%">
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label6" runat="server" Text="Source Type: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblSourceType" runat="server" Text='<%# Eval("Sourcename") %>'></asp:Label>
                                                </td>
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label7" runat="server" Text="Total Followups: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblTotalfollowUp" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="width: 25%">
                                                <td style="width: 15%">
                                                    <asp:Label ID="Label8" runat="server" Text=" Assign To: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                 <asp:Label ID="lblAssignTo" runat="server" Text='<%# Eval("FirstName") +"  "+ Eval("LastName") %>'></asp:Label>
                                                </td>
                                                <td style="width: 10%">
                                                    <asp:Label ID="Label9" runat="server" Text="Enquiry Type: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblEnquiryType" runat="server" Text='<%# Eval("InterestLevelCode") %>'></asp:Label>
                                                    <asp:Label ID="lblInterestLevel" Visible="false" runat="server" Text='<%# Eval("InterestLevel") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr style="width: 100%">
                                                <td style="width: 10%">
                                                    <asp:Label ID="Label10" runat="server" Text=" Assign To: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                   
                                                </td>
                                                <td style="width: 10%">
                                                    <asp:Label ID="Label11" runat="server" Text="Remark: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="Label13" runat="server" Text="NA"></asp:Label>
                                                </td>
                                            </tr>--%>
                                            <tr style="width: 100%">
                                                <td style="width: 10%">
                                                    <asp:Label ID="Label12" runat="server" Text="Recieved by: " Font-Bold="true"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblRecivedby" runat="server" Text='<%# Eval("ClinicName") %>'></asp:Label>
                                                </td>
                                                          <td style="width: 10%">


                                                    <asp:Label ID="lblFollowups" runat="server" Text="Followups Status"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                      <asp:Label ID="lblFollowupsStatus" runat="server" Text=""></asp:Label>
                                                </td>
                                           
                                            </tr>
                                            <tr>

                                              <%--Dhaval--%>
                                                  <td style="width: 10%">
                                                    <asp:Label ID="Label1" runat="server" Text=" EmailId: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="lblEMailID" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                </td>
                                                 <td style="width: 10%">
                                                    <asp:Label ID="Label15" runat="server" Text="Patient Status: " Font-Bold="false"></asp:Label>
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("Pstatus") %>'></asp:Label>
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnFollowup" runat="server" ToolTip="Followup" CausesValidation="false"
                                            CommandArgument='<%# Eval("EnquiryID") %>' CommandName="FollowupEnquiry" Height="30px"
                                            Width="30px" ImageUrl="../Images/followup.jpg" />
                                        <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Add To Patient" CausesValidation="false"
                                            CommandArgument='<%# Eval("EnquiryID") %>' CommandName="AddCustomer" Height="30px"
                                            Width="30px" ImageUrl="../Images/minus.png" />
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
  
            </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
