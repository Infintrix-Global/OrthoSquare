<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="InvoiceAdd.aspx.cs" Inherits="OrthoSquare.Invoice.InvoiceAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">

    <link rel='stylesheet' href='https://afeld.github.io/emoji-css/emoji.css'>

    <link rel="stylesheet" href="../feedback/css/style.css">

    <script type="text/javascript">
        function checkDate1(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select future Date!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
    </script>
    <asp:UpdatePanel runat="server" ID="upFilter">
        <ContentTemplate>
            <div class="page-content" id="Add" runat="server">
                <!-- BEGIN PAGE HEADER-->


                <div class="page-bar">
                    <ul class="page-breadcrumb">
                        <li>
                            <i class="icon-home"></i>
                            <a href="#">Home</a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            <span>Generate Invoice</span>
                        </li>
                    </ul>

                </div>
                <!-- END PAGE HEADER-->
                <div class="row">
                    <div class="col-md-12">
                        <div style="margin-bottom: 5px;">
                            <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                            <asp:Label ID="lblinvCode" Visible="false" runat="server" Text=""></asp:Label>
                        </div>
                        <!-- BEGIN SAMPLE FORM PORTLET-->
                        <div class="portlet light ">
                            <div class="portlet-title">
                                <div class="caption font-red-sunglo">
                                    <i class="icon-settings font-red-sunglo"></i>
                                    <span class="caption-subject bold uppercase">Generate Invoice</span>
                                </div>
                                
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

                                            <label>Patient Name</label>
                                            <asp:DropDownList ID="ddlpatient" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlpatient_SelectedIndexChanged"></asp:DropDownList>
                                            <span class="help-block">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlpatient" InitialValue="0"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter patient" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-sm-3">
                                             <label>Payment Date</label>
                                            <asp:TextBox ID="txtPayDate" class="form-control" autocomplete="Off" placeholder="Payment Date"  TabIndex="5" AutoPostBack="true" runat="server"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtBDate_CalendarExtender" runat="server" Enabled="True" OnClientDateSelectionChanged="checkDate1"
                                                TargetControlID="txtPayDate" Format="dd-MM-yyyy">
                                            </asp:CalendarExtender>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>

                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">

                                        <div class="col-sm-3">


                                            <label>PAID AMOUNT(₹)</label><br />
                                            <asp:TextBox ID="txtPAID1" class="form-control" ReadOnly="true" runat="server" AutoPostBack="True" OnTextChanged="txtPaidAmount_TextChanged"></asp:TextBox>



                                        </div>
                                        
                                        <div class="col-sm-3">
                                        </div>
                                        <div class="col-sm-3">
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">

                                        <div class="table-responsive">


                                            <asp:GridView ID="gvInformation" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                                                ForeColor="#333333" Width="100%" OnRowCommand="gvInformation_RowCommand" class="table table-bordered table-hover"
                                                OnRowDataBound="gvInformation_RowDataBound">

                                                <Columns>
                                                    <asp:BoundField DataField="RowNumber" HeaderText="Sr.No" />
                                                    <asp:TemplateField HeaderText="Treatment" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnWOEmployeeID" runat="server" Value='<%# Eval("ID")%>'></asp:HiddenField>

                                                            <asp:Label ID="lblTreatment" Visible="false" runat="server" Text='<%# Eval("TreatmentID")%>'></asp:Label>
                                                            <asp:DropDownList ID="ddlTreatment1" Width="200px" class="form-control" runat="server"></asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtSeatings1" Width="80px" OnTextChanged="txtSeatings1_TextChanged" AutoPostBack="true" class="form-control" Text='<%# Eval("Unit")%>' runat="server"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilUnUnit" runat="server"
                                                                Enabled="True" TargetControlID="txtSeatings1" FilterType="Numbers">
                                                            </cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCost1" Width="200px" OnTextChanged="txtCost1_TextChanged" AutoPostBack="true" CssClass="form-control" Text='<%# Eval("Cost")%>' runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCost1" ErrorMessage="Please Enter Cost Amount" ForeColor="Red" SetFocusOnError="true" ValidationGroup="e"></asp:RequiredFieldValidator>
                                                            <cc1:FilteredTextBoxExtender ID="FilUnCost" runat="server"
                                                                Enabled="True" TargetControlID="txtCost1" FilterType="Numbers">
                                                            </cc1:FilteredTextBoxExtender>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Discount">
                                                        <ItemTemplate>

                                                            <asp:TextBox ID="txtDiscount1" Width="200px" OnTextChanged="txtDiscount1_TextChanged" AutoPostBack="true" class="form-control" Text='<%# Eval("Discount")%>' runat="server"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilUnDiscount" runat="server"
                                                                Enabled="True" TargetControlID="txtDiscount1" FilterType="Numbers">
                                                            </cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tax">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlTAX1" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="Invoice_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblTax11" Visible="false" runat="server" Text='<%# Eval("Tex")%>'></asp:Label>
                                                            <asp:Label ID="lblISInvoice" Visible="false" runat="server" Text='<%# Eval("ISInvoice")%>'></asp:Label>

                                                        </ItemTemplate>

                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <FooterTemplate>
                                                            <asp:Button ID="btn_AddEmployee" runat="server" Text="+Add New Row" class="btn blue"
                                                                CausesValidation="true" ValidationGroup="AddExperianceGrp" OnClick="btn_AddEmployee_Click" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" ImageUrl="~/Images/remove-icon-png-26.png" Width="30px" CommandArgument='<%# Eval("ID") %>' runat="server" OnClientClick="return confirm('Do you really want to delete Treatment?');" />

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>


                                            </asp:GridView>


                                        </div>
                                    </div>
                                </div>
                            </div>




                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">



                                        <asp:GridView ID="GridinvoiceDetails" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                            class="table table-bordered table-hover">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Treatment Name" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPriceTreatmentName" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Unit" ItemStyle-Width="18%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("Unit") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Cost" ItemStyle-Width="18%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Discount" ItemStyle-Width="18%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Tax" ItemStyle-Width="18%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTax" runat="server" Text='<%# Eval("Tax") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>


                                    </div>
                                </div>

                            </div>
                            <br />

                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-3">

                                            <label>TOTAL COST (₹)</label><br />
                                            <asp:Label ID="lblTotalCost" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-sm-3">

                                            <label>TOTAL DISCOUNT (₹)</label>
                                            <br />
                                            <asp:Label ID="lblTotalDiscount" runat="server" Text=""></asp:Label>


                                        </div>
                                        <div class="col-sm-3">

                                            <label>TOTAL TAX (₹)</label>
                                            <br />
                                            <asp:Label ID="lblTotalTax" runat="server" Text=""></asp:Label>


                                        </div>

                                        <div class="col-sm-3">

                                            <label>GRAND TOTAL(₹)</label>
                                            <br />
                                            <asp:Label ID="lblGrandTotal" runat="server" Text=""></asp:Label>


                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-3">
                                            <label>PAY AMOUNT(₹)</label><br />
                                            <asp:TextBox ID="txtPaidAmount" class="form-control" runat="server" Text="0" AutoPostBack="True" OnTextChanged="txtPaidAmount_TextChanged"></asp:TextBox>

                                        </div>
                                        <div class="col-sm-3">

                                            <label>PENDING AMOUNT(₹)</label>
                                            <br />
                                            <asp:TextBox ID="txtPendingAmount" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>

                                        </div>


                                        <div class="col-sm-3">
                                        </div>
                                        <div class="col-sm-3">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- END CONTENT BODY -->
                            <br />
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-3">

                                            <label>Payment Mode</label><br />

                                            <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                <asp:ListItem Value="1">Cash</asp:ListItem>
                                                <asp:ListItem Value="2">Cheque</asp:ListItem>
                                                <asp:ListItem Value="3">Credit Card</asp:ListItem>
                                                <asp:ListItem Value="4">Debit Card</asp:ListItem>
                                                <asp:ListItem Value="5">Finance</asp:ListItem>
                                                <asp:ListItem Value="6">UPI</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                        </div>
                                        <div class="col-sm-3">
                                        </div>

                                        <div class="col-sm-3">
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <asp:Panel ID="Panel1" Visible="false" runat="server">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">

                                                <label>Bank Name</label><br />
                                                <asp:TextBox ID="txtBankName" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <label>Branch Name</label><br />
                                                <asp:TextBox ID="txtBranchName" class="form-control" runat="server"></asp:TextBox>


                                            </div>
                                            <div class="col-sm-3">

                                                <label>IFSC Code</label><br />
                                                <asp:TextBox ID="txtIRFC" class="form-control" runat="server"></asp:TextBox>


                                            </div>

                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">

                                                <label>Cheque  No</label><br />
                                                <asp:TextBox ID="txtCheckNO" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <label>Cheque  Date</label><br />
                                                <asp:TextBox ID="txtCheckDate" class="form-control" runat="server"></asp:TextBox>

                                                <asp:CalendarExtender ID="txtCheckDate_CalendarExtender" runat="server" Enabled="True"
                                                    TargetControlID="txtCheckDate" Format="dd-MM-yyyy">
                                                </asp:CalendarExtender>
                                            </div>
                                            <div class="col-sm-3">

                                                <%--                                        <label>Card No</label><br />
                                        <asp:TextBox ID="txtCardNo" class="form-control" runat="server"></asp:TextBox>--%>
                                            </div>

                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="Panel2" Visible="false" runat="server">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">

                                                <label>No</label><br />
                                                <asp:TextBox ID="txtCardNo" class="form-control" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                            <div class="col-sm-3">
                                            </div>

                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="Panel3" Visible="false" runat="server">

                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="form-group">
                                                <div class="col-sm-6">
                                                    <asp:RadioButtonList ID="RadioButtonListFinance" Width="300px" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Selected="True" Text="Bajaj finance" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Kotak finance" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Liqui Loans" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="IDFC First Bank" Value="4"></asp:ListItem>
                                                    </asp:RadioButtonList>

                                                </div>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">

                                                <label>Approved Loan Amount</label><br />
                                                <asp:TextBox ID="txtApprovalAmount" class="form-control" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-3">
                                                <label>Interest on loan (%) </label>
                                                <br />
                                                <asp:TextBox ID="txtInterest" class="form-control" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-3">

                                                <label>Down payment</label><br />
                                                <asp:TextBox ID="txtDownpayment" class="form-control" runat="server"></asp:TextBox>


                                            </div>

                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">



                                                <label>EMIs start Date</label>
                                                <asp:TextBox ID="txtEMIStartDate" class="form-control" runat="server"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtTextBox1_CalendarExtender" runat="server" Enabled="True"
                                                    TargetControlID="txtEMIStartDate" Format="dd-MM-yyyy">
                                                </asp:CalendarExtender>
                                                <asp:Label ID="lblSdate" runat="server" Visible="false" Text=""></asp:Label>
                                            </div>
                                            <div class="col-sm-3">

                                                <label>Total EMIs</label>
                                                <asp:TextBox ID="txtTotalEmi" class="form-control" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-3">
                                                <br />
                                                <asp:Button ID="AddInstmt"
                                                    class="btn blue" runat="server" Text="Add"
                                                    Width="100px" OnClick="AddInstmt_Click" />

                                            </div>



                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-xs-12">


                                        <div class="form-group">
                                            <div class="col-sm-9">

                                                <asp:GridView ID="GridViewInstallment" GridLines="Horizontal" Width="80%" AutoGenerateColumns="false" ShowFooter="true" runat="server" OnRowDataBound="GridViewInstallment_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="10%">Sr.No</td>
                                                                        <td width="45%">EMIs Amount</td>
                                                                        <td width="45%">Date of  EMI</td>
                                                                    </tr>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="10%">
                                                                            <asp:Label ID="SrNo" runat="server" Text="<%#Container.DataItemIndex + 1%>"></asp:Label></td>
                                                                        <td width="45%">
                                                                            <asp:TextBox ID="txtEMIsAmount" class="form-control" runat="server" Text=""></asp:TextBox></td>
                                                                        <td width="45%">
                                                                            <asp:TextBox ID="txtDateofEMI" class="form-control" runat="server" Text=""></asp:TextBox>

                                                                            <asp:CalendarExtender ID="txtDateofEMI_CalendarExtender" runat="server" Enabled="True"
                                                                                TargetControlID="txtDateofEMI" Format="dd-MM-yyyy">
                                                                            </asp:CalendarExtender>
                                                                        </td>
                                                                    </tr>


                                                                </table>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>


                                                                <table width="100%">
                                                                    <tr>
                                                                        <td width="10%">Total</td>
                                                                        <td width="45%">
                                                                            <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></td>
                                                                        <td width="45%"></td>
                                                                    </tr>
                                                                </table>

                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <label>
                                                    Document
                                                </label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:FileUpload ID="FuImage1" runat="server" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Button ID="btnUploadimage" class="btn blue" ClientIDMode="Static" CausesValidation="false"
                                                    runat="server" Text="Upload Image" OnClick="btnUploadimage_Click" />
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Image ID="ImagePhoto1" runat="server" Height="80px" Width="80px" GenerateEmptyAlternateText="True"
                                                    ImageUrl="~/Images/no-photo.jpg" />
                                                <asp:Label ID="lbl_filepath1" runat="server" Visible="False"></asp:Label>
                                            </div>
                                        </div>
                                        .
                                    </div>
                                </div>



                            </asp:Panel>
                            <br />
                            <br />
                            <div class="row">
                                <div class="form-actions text-center">

                                    <asp:Button ID="btAdd" runat="server" Text="Submit" Enabled="false" class="btn blue" ValidationGroup="e" OnClientClick="return Disable();" ClientIDMode="Static" OnClick="btAdd_Click" />
                                    <asp:Button ID="btFeedback" ClientIDMode="Static" class="btn blue" runat="server" Visible="false" CausesValidation="false" OnClick="btFeedback_Click"
                                        Text="Feedback" />
                                    <asp:Button ID="btBack" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                        CausesValidation="False" />

                                    <asp:Button ID="btninvoice" runat="server" Visible="false" class="btn blue" Text="Print Invoice" OnClick="btninvoice_Click" />


                                </div>

                            </div>
                        </div>
                    </div>
                    <!-- END CONTENT BODY -->
                </div>


            </div>


            <div class="page-content" id="Div1" visible="false" runat="server">
                <!-- BEGIN PAGE HEADER-->


                <div class="page-bar">
                    <ul class="page-breadcrumb">
                        <li>
                            <i class="icon-home"></i>
                            <a href="index-2.html">Home</a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            <span>Feedback</span>
                        </li>
                    </ul>

                </div>
                <!-- END PAGE HEADER-->

                <div class="row">
                    <div class="col-md-12">
                        <div style="margin-bottom: 5px;">
                            <asp:Label ID="Label1" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                        </div>
                        <!-- BEGIN SAMPLE FORM PORTLET-->
                        <div class="portlet light ">
                            <div class="portlet-title">
                                <div class="caption font-red-sunglo">
                                    <i class="icon-settings font-red-sunglo"></i>
                                    <span class="caption-subject bold uppercase">Feedback</span>
                                </div>

                            </div>
                            <div class="row">

                                <div class="rating-wrapper">
                                    <label class="rating-label">
                                        How helpful was this?
    <div class="ratingItemList">

        <input class="rating rating-2" id="rating-2-2" type="radio" value="2" name="rating" />
        <label class="rating rating-2" for="rating-2-2">
            <i class="em em-disappointed"></i>
            <h6>Unsatisfactory</h6>
        </label>


        <%--  <asp:RadioButton class="rating rating-2" ID ="RadioButton1"  value="2" name="rating" runat="server" />
      <label class="rating rating-2" for="RadioButton1"><i class="em em-disappointed"></i><h6>Unsatisfactory</h6></label>--%>
        <input class="rating rating-3" id="rating-3-2" type="radio" value="3" name="rating" />
        <label class="rating rating-3" for="rating-3-2">
            <i class="em em-expressionless"></i>
            <h6>Satisfactory </h6>
        </label>
        <input class="rating rating-4" id="rating-4-2" type="radio" value="4" name="rating" />
        <label class="rating rating-4" for="rating-4-2">
            <i class="em em-grinning"></i>
            <h6>Very Satisfactory </h6>
        </label>

    </div>
                                    </label>
                                    <div class="feedback">
                                        <%-- <textarea placeholder="What can we do to improve?"></textarea>--%>

                                        <asp:TextBox ID="txtFreedbackDetails" runat="server" TextMode="MultiLine" Height="100Px" Width="500px" placeholder="What can we do to improve?"></asp:TextBox>

                                        <asp:Button ID="btnSendSendFeedback" class="btn blue" runat="server" OnClick="btnSendSendFeedback_Click" Text="Send Your Feedback" />


                                        <asp:Button ID="btnSkit" class="btn blue" runat="server" OnClick="btnSkit_Click" Text="Skip" />
                                        <%--  <button class="submit">Send Your Feedback</button>--%>
                                    </div>

                                </div>

                                <!-- END CONTENT BODY -->
                            </div>

                        </div>
                    </div>
                    <!-- END CONTENT BODY -->
                </div>


            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script>



    <script src="../feedback/js/index.js"></script>

</asp:Content>
