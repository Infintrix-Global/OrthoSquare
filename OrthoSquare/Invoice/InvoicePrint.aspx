<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoicePrint.aspx.cs" Inherits="OrthoSquare.Invoice.InvoicePrint" %>

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
            runat="server" Width="50px" Height ="50px" />
        <asp:Button ID="btnBack" runat="server" Text="Back" Visible="false" OnClick="Button1_Click" CssClass="btn btn-warning" />
                </td>
                <td>
                  
                </td>
                <td>
                    &nbsp;
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
                                        <td colspan="2">
                                          Branch: <asp:Label ID="lblClinic" runat="server" Text=""></asp:Label>
                                            <br />
                                            <asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label>
                                            
                                            <br />
                                            <asp:Label ID="lblMobailNo" runat="server" Text=""></asp:Label>,
                                             <asp:Label ID="lblEmail1" runat="server" Text=""></asp:Label>
                                        </td>
                                       
                                    </tr>
                                </table>
                            </td>
                          <%--  <td width="1%"></td>--%>
                            <td width="28%" align="right">
                                <table style="width: 100%;">
                                  
                                    <tr>
                                        <td width="50%" align="left">Date :
                                        
                                       
                                        </td>
                                        <td width="50%" align="right">
                                            <asp:Label ID="lblInvoiceDate" runat="server" Text="" CssClass="right"></asp:Label>
                                            
                                          
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                           Invoice No:

                                        </td>
                                        <td align="right">
                                              <asp:Label ID="lblInvoiceNo" runat="server" Text="" CssClass="right"></asp:Label>

                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                             <td colspan="4">
                                    <hr style="border-color:#4d79ff; border-width: 1px" />
                             </td>

                        </tr>
                        <tr>
<%--                            <td colspan="2">
                                <hr style="border-color:#4d79ff; border-width: 3px" />
                            </td>--%>
                            <td align="center"  colspan="4">
                                <asp:Label ID="lblTexIn" runat="server" Text="INVOICE"  CssClass="invoiceheader"></asp:Label>
                            </td>
                          <%--  <td>
                                <hr style="border-color: #4d79ff; border-width: 3px" />
                            </td>--%>
                        </tr>
                        <%--<tr>
                            <td colspan="4" height="10px"></td>
                        </tr>--%>
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
                                <asp:GridView ID="grdInvoice" runat="server" AutoGenerateColumns="false" Width="100%" Style="font-size: 12px;"
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
                                        <asp:TemplateField HeaderText="Treatments & Products " ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("TreatmentName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Unit " ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHSN" runat="server" Text='<%# Eval("Unit") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Cost (INR)" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%# Convert.ToDecimal(Eval("Cost")).ToString("N", System.Globalization.CultureInfo.GetCultureInfo("en-IN")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Discount" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnit" runat="server" Text='<%# Convert.ToDecimal(Eval("Discount")).ToString("N", System.Globalization.CultureInfo.GetCultureInfo("en-IN")) %>'></asp:Label>
                                            
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tax (INR)" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTax" runat="server" Text='<%#  Convert.ToDecimal(Eval("TotalTax")).ToString("N", System.Globalization.CultureInfo.GetCultureInfo("en-IN"))  %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="Label1" runat="server" Visible="false" Text='<%#  Eval("Tax") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total Cost (INR)" ItemStyle-Width="8%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Text='<%#  Convert.ToDecimal(Eval("GrandTotal")).ToString("#,##0.00") %>'></asp:Label>
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
                            <td></td>
                            <td align="right">
                               
                                
                                 <asp:Label ID="lblTotalCost" runat="server" Text="Total" Font-Bold="True"></asp:Label>
                                
                                <br />
                                <asp:Label ID="lbldiscount" runat="server" Text="Less discount" Font-Bold="True"></asp:Label>
                                
                                <br />
                                 <asp:Label ID="lbltotaltext" runat="server" Text="Taxable Total" Font-Bold="True"></asp:Label>
                                <%-- <br />
                            <asp:Label ID="lblWordsTotal" runat="server" Text="Amount(in Words)" Font-Bold="True"></asp:Label>--%>
                                <br />


                                <asp:Label ID="lblTax" runat="server" Text="Total Tax (0 %)" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:Label ID="lblNet" runat="server" Text="Total Amount" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:Label ID="lblRAmount" runat="server" Text="Received Amount" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:Label ID="lblTAmont" runat="server" Text="Balance Amount" Font-Bold="True"></asp:Label>
                                <br />
                                <br />

                                <asp:Label ID="lblWords" runat="server" Text="Received Amount(in Words)" Font-Bold="True"></asp:Label>
                            </td>
                            <td align="right" colspan="2">

                                 <asp:Label ID="lblTotalCoust1" runat="server" Text="" ></asp:Label>
                                
                                <br />
                                <asp:Label ID="lbldiscount1" runat="server" Text="" ></asp:Label>
                                
                                <br />
                                <asp:Label ID="lblTotalFooter" runat="server" Text=""></asp:Label>
                                <br />

                                <asp:Label ID="lblTaxAmount" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lblNetAmount" runat="server" Text=""></asp:Label>
                                <br />
                              
                                <asp:Label ID="lblpaidAmount" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lblpendingAmount" runat="server" Text=""></asp:Label>
                                  <br /><br />
                                <asp:Label ID="lblWordsAmount" runat="server" Font-Size="Small" Text=""></asp:Label>
                            </td>
                        </tr>
                     


                        <tr>
                            <td colspan="4">
                                   <br />
                                <asp:GridView ID="GridpayDetails" runat="server" AutoGenerateColumns="false" Width="100%" Style="font-size: 12px;"
                                    GridLines="None">
                                    <HeaderStyle CssClass="yellow" />
                                    <RowStyle CssClass="white" />
                                    <AlternatingRowStyle CssClass="yellowrow" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="#" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber1" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescriptionCreateDate" runat="server" Text='<%# Eval("payDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText=" Payment Mode " ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaymentMode" runat="server" Text='<%# Eval("PaymentMode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText=" Grand Total" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrandTotal" runat="server" Text='<%# Eval("GrandTotal") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        
                                        <asp:TemplateField HeaderText="Received Amount (INR) " ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaidAmount" runat="server" Text='<%# Convert.ToDecimal(Eval("PaidAmount")).ToString("#,##0.00") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Balance Amount (INR)" Visible="false" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPendingAmount" runat="server" Text='<%# Convert.ToDecimal(Eval("PendingAmount")).ToString("#,##0.00") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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
                           <%-- <span class="center" style="-webkit-print-color-adjust: exact;">SIGNATURE</span>--%>
                        </td>
                    </tr>
                    <%--   <tr style="height:50px"></tr>--%>
                    <tr>
                        <td align="center"  colspan="2">
                            <asp:Label ID="lblThankyou" runat="server" Text="Thank You For Your Business" Visible="false"  CssClass="head"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr style="border-color: #4d79ff; border-width: 1px; width: 111%;" />
                            <asp:Label ID="lblfooterCompany" runat="server" Text="This is computer generated invoice and hence no signature required" Font-Bold="True"
                                 Font-Size="Medium" ForeColor="#4d79ff"></asp:Label>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblProfileAddress" runat="server" Text="" Font-Bold="True" Font-Size="Medium"
                                ForeColor="#F08080"></asp:Label>
                            <br />
                            Email:-<asp:Label ID="lblCoampyEmailID" runat="server" Text="" Font-Bold="True" Font-Size="Medium"
                                ForeColor="#F08080"></asp:Label>
                            &nbsp; &nbsp;Phone:-
                        <asp:Label ID="lblComapyPhone" runat="server" Text="" Font-Bold="True" Font-Size="Medium"
                            ForeColor="#F08080"></asp:Label>
                        </td>
                    </tr>--%>
                </table>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
