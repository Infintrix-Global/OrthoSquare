<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MedicinesPrint.aspx.cs" Inherits="OrthoSquare.Doctor.MedicinesPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/css-print.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="~/css/print.css" type="text/css" media="print" />
    <style type="text/css">
        body {
            position: relative;
            margin: 0;
            padding-bottom: 6em;
            min-height: 100%;
            font-family: Century Gothic; /*"Helvetica Neue" , Arial, sans-serif;*/
            margin: 0px; /**  <%--padding-top:2.5cm;
            padding-bottom:2.5cm;
            margin:.100in .5in .5in .5in; --%>  */
        }

        .demo {
            margin: 0 auto;
            padding-top: 64px;
            max-width: 640px;
            width: 94%;
        }

            .demo h1 {
                margin-top: 0;
            }
        /**
 * Footer Styles
 */

        .footer {
            position: fixed;
            right: 0;
            bottom: 0;
            left: 0; /*padding: 1rem;*/
            background-color: #efefef;
            text-align: center;
        }


        @page {
            size: auto; /* auto is the initial value */ /* this affects the margin in the printer settings */
            margin: .2in .4in .2in .4in;
        }
    </style>
    <style type="text/css">
        @media print {
            #ImageButton1 {
                display: none;
            }

            #btnBack {
                display: none;
            }

            #RadioButtonList1 {
                display: none;
            }
        }

        .style1 {
            height: 20px;
        }

        .style2 {
            font-size: x-small;
        }
    </style>
    <script type="text/javascript">
        function PrintPage() {
            window.print();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButton1" Visible="false" ImageUrl="~/Images/printdetail.jpg" OnClientClick="javascript:PrintPage();"
                            runat="server" Width="50px" Height="50px" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" Visible="false" OnClick="Button1_Click" CssClass="btn btn-warning" />
                    </td>
                    <td></td>
                    <td>&nbsp;
                    </td>
                </tr>

            </table>


        </div>
        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <div>
                <div align="left">
                    <table style='width: 100%; font-size: 14px; font-family: Century Gothic;' border='0'>


                        <tr>
                            <td colspan="4" align="right">
                                <asp:Label ID="lblCopy" runat="server" Style="font-style: italic;"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td width="10%">
                                <asp:Image ID="ImageLogo" runat="server" ImageUrl="~/Images/Orthosquarelogo-s.jpg" CssClass="img" />
                            </td>
                            <td colspan="2" width="62%">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="2" style="-webkit-print-color-adjust: exact;">
                                            <asp:Label ID="lblComapnyName" runat="server" Text="Orthosquare Multispeciality Dental Clinic Pvt Ltd" CssClass="head"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Branch:
                                            <asp:Label ID="lblClinic" runat="server" Text=""></asp:Label>
                                            <br />
                                            <asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label>

                                            <br />
                                            <asp:Label ID="lblMobailNo" runat="server" Text=""></asp:Label>,
                                             <asp:Label ID="lblEmail1" runat="server" Text=""></asp:Label>
                                        </td>

                                    </tr>
                                </table>
                            </td>

                            <td width="28%" align="right">
                                <table style="width: 100%;">

                                    <tr>
                                        <td width="50%" align="left">Date :
                                        
                                       
                                        </td>
                                        <td width="50%" align="right">
                                            <asp:Label ID="lblInvoiceDate" runat="server" Text="" CssClass="right"></asp:Label>


                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr style="border-color: #4d79ff; border-width: 1px" />
                            </td>

                        </tr>
                        <tr>

                            <td align="center" colspan="4">
                                <asp:Label ID="lblTexIn" runat="server" Text="INVOICE" CssClass="invoiceheader"></asp:Label>
                            </td>

                        </tr>

                        <tr>
                            <td colspan="2" valign="top">

                                <asp:Label ID="lblpatient" Font-Bold="True" runat="server" Text="Gopal Traders"></asp:Label>
                                <br />

                                <asp:Label ID="lblpatientIDH" runat="server" Text="Patient ID:" Font-Size="Small"></asp:Label>

                                <asp:Label ID="patientID" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lblMNo" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="Label1By" Font-Bold="True" runat="server" Text="By"></asp:Label>
                                <asp:Label ID="lblDoctername" Font-Bold="True" runat="server" Text=""></asp:Label>

                            </td>
                            <td valign="top">
                                <%--<div style="float: right; text-align: left">--%>

                                <asp:Label ID="lblGender" runat="server" Text="M" Font-Bold="False"
                                    Font-Size="Small"></asp:Label>,
                            
                            <asp:Label ID="lblAge" runat="server" Font-Bold="False" Font-Size="Small"></asp:Label>
                                Years
                            <br />
                                <asp:Label ID="lblBlood" runat="server" Font-Bold="False" Text="Blood Group:" Font-Size="Small"></asp:Label>
                                <asp:Label ID="lblBloodGroup" runat="server" Font-Bold="False" Font-Size="Small" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lblAddress" runat="server" Font-Bold="False" Font-Size="Small" Text=""></asp:Label>
                                <%--</div>--%>
                            </td>

                        </tr>

                        <tr>
                            <td style="height: 20px" />
                        </tr>
                        <tr>
                            <td colspan="4" style="-webkit-print-color-adjust: exact;">
                                <asp:GridView ID="grdMedicinesInvoice" runat="server" AutoGenerateColumns="false" Width="100%" Style="font-size: 12px;"
                                    GridLines="None">
                                    <HeaderStyle CssClass="yellow" />
                                    <RowStyle CssClass="white" />
                                    <AlternatingRowStyle CssClass="yellowrow" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.no." ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("txtMtype") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Medicines Name" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHSN" runat="server" Text='<%# Eval("MedicinesName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Doses" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalMedicines" runat="server" Text='<%# Eval("TotalMedicines") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Days" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDayMedicines" runat="server" Text='<%# Eval("DayMedicines") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Morning" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMorningMedicines" runat="server" Text='<%# Eval("MorningMedicines") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="After noon" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAfternoonMedicines" runat="server" Text='<%# Eval("AfternoonMedicines") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Evening" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEveningMedicines" runat="server" Text='<%# Eval("EveningMedicines") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText=" Price (INR)" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("Price")).ToString("N", System.Globalization.CultureInfo.GetCultureInfo("en-IN")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" height="10px">
                                <hr style="border-color: Black; border-width: 1px;" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                            <td align="right">


                                <asp:Label ID="lblTotalCost" runat="server" Text="Total" Font-Bold="True"></asp:Label>

                                <br />
                                <asp:Label ID="lbldiscount" runat="server" Text="Less discount" Font-Bold="True"></asp:Label>
                                <asp:Label ID="lbldsc" runat="server" Text="" Font-Bold="True"></asp:Label>

                                <br />

                                <asp:Label ID="lblNet" runat="server" Text="Total Amount" Font-Bold="True"></asp:Label>
                                <br />


                                <br />

                              
                            </td>
                            <td align="Center" >

                                <asp:Label ID="lblTotalCoust1" runat="server" Text=""></asp:Label>

                                <br />
                                <asp:Label ID="lbldiscount1" runat="server" Text=""></asp:Label>

                                <br />
                                <asp:Label ID="lblNetAmount" runat="server" Text=""></asp:Label>
                                <br />



                                <br />
                               
                            </td>
                        </tr>
                        <tr>
                             <td ></td>
                              <td >
                                    <asp:Label ID="lblWords"  runat="server" Text="Received Amount(in Words)" Font-Bold="True"></asp:Label>
                              </td>
                              <td colspan="2" >
                                   <asp:Label ID="lblWordsAmount"  runat="server" Font-Size="Small" Text=""></asp:Label>
                              </td>
                            

                             
                        </tr>


                        <tr>
                            <td colspan="3"></td>
                            <td align="center">
                                <%--</h2>

                                    </div>
                                </div>
                            </div>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="footer">
                <table width="100%">
                    <tr>
                        <td width="70%"></td>
                        <td width="30%">
                            <asp:Label ID="lblDoctorSig" runat="server" Text=""></asp:Label>
                            <hr style="border-color: #4d79ff; border-width: 1px;" />

                            <br />

                        </td>
                    </tr>

                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblThankyou" runat="server" Text="Thank You For Your Business" Visible="false" CssClass="head"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr style="border-color: #4d79ff; border-width: 1px; width: 111%;" />
                            <asp:Label ID="lblfooterCompany" runat="server" Text="This is computer generated invoice and hence no signature required" Font-Bold="True"
                                Font-Size="Medium" ForeColor="#4d79ff"></asp:Label>
                        </td>
                    </tr>

                </table>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
