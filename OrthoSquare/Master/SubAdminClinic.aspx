<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="SubAdminClinic.aspx.cs" Inherits="OrthoSquare.Master.SubAdminClinic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                    <span>Sub Admin Clinic</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblmsg1223" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Sub Admin Clinic</span>
                        </div>

                    </div>
                    <div class="row">



                        <div class="col-xs-12">
                            <div class="form-group">
                                <div class="col-md-4 ">
                                    <div class="form-body">
                                        
                                     <%--   <asp:DropDownList ID="ddl_DocterDetils" AutoPostBack="true" OnSelectedIndexChanged="ddl_DocterDetils_SelectedIndexChanged" class="form-control" runat="server"></asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldddl_DocterDetils" runat="server" ControlToValidate="ddl_DocterDetils" InitialValue="0"
                                            SetFocusOnError="true" ErrorMessage="Please Select Doctor" ForeColor="Red"></asp:RequiredFieldValidator>--%>


                                       <asp:TextBox ID="txtDocter" runat="server" OnTextChanged="txtDocter_TextChanged" placeholder="Doctor Name" AutoPostBack="true" class="form-control"></asp:TextBox>

                                <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                    MinimumPrefixLength="2"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                    TargetControlID="txtDocter"
                                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                </cc1:AutoCompleteExtender>

                                  <asp:RequiredFieldValidator ID="RequiredFieldddl_DocterDetils" runat="server" ControlToValidate="txtDocter" 
                                    SetFocusOnError="true" ErrorMessage="Please Select Doctor" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-body">
                                       


                                        <asp:UpdatePanel ID="updatepanel2" runat="server">
                                            <ContentTemplate>
                                               
 <asp:TextBox ID="TextBox1" class="form-control "  placeholder=" Select Clinic" runat="server"></asp:TextBox>  
                                                <asp:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server"
                                                    Enabled="True" ExtenderControlID="" TargetControlID="TextBox1" PopupControlID="Panel1"
                                                    OffsetY="22">
                                                </asp:PopupControlExtender>
                                                <asp:Panel ID="Panel1" runat="server" Height="300px" Width="256px"
                                                    BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto"
                                                    Style="display: none">
                                                    <asp:CheckBox ID="cbAll" OnSelectedIndexChanged="cbAll_SelectedIndexChanged" AutoPostBack="True" runat="server" Text="Select All" onclick="CheckAll();" />

                                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" BackColor="White" Height="300px" Width="256px"
                                                        DataTextField="holiday_name" DataValueField="holiday_name" AutoPostBack="True" onclick="UnCheckAll();"
                                                        OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                                                    </asp:CheckBoxList>

                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="col-sm-4">
                                </div>

                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-actions text-center">

                            <asp:Button ID="btnDbyCSubmit" runat="server" Text="Submit" class="btn blue" ClientIDMode="Static" OnClick="btnDbyCSubmit_Click" />

                            <asp:Button ID="BtnDyc" runat="server" Text="Cancel" Class="btn default" ClientIDMode="Static"
                                OnClick="BtnDyc_Click" CausesValidation="False" />

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
     function CheckAll() {
            var count = 0;
            $('#' + '<%=CheckBoxList1.ClientID %>' + '  input:checkbox').each(function () {
                count = count + 1;
            });
            for (i = 0; i < count; i++) {
                if ($('#' + '<%=cbAll.ClientID %>').prop('checked') == true) {
                    if ('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i) {
                        if (('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i).disabled != true)
                            $('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i + ':checkbox').prop('checked', true);
                    }
                }
                else {
                    if ('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i) {
                        if (('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i).disabled != true)
                            $('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i + ':checkbox').prop('checked', false);
                    }
                }
            }
        }



        function UnCheckAll() {
            var flag = 0;
            var count = 0;
            $('#' + '<%=CheckBoxList1.ClientID %>' + '  input:checkbox').each(function () {
                count = count + 1;
            });
            for (i = 0; i < count; i++) {
                if ('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i) {
                    if ($('#' + '<%=CheckBoxList1.ClientID %>' + '_' + i).prop('checked') == true) {
                        flag = flag + 1;
                    }
                }
            }
            if (flag == count)
                $('#' + '<%=cbAll.ClientID %>' + ':checkbox').prop('checked', true);
            else
                $('#' + '<%=cbAll.ClientID %>' + ':checkbox').prop('checked', false);
        }

    </script>
</asp:Content>
