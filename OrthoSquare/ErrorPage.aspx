<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="OrthoSquare.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: left; margin-top: 30px; margin-left: 50px; color: Red">
        <center>
            <b>We apologize,</b><br />
            <br />
            There might be some error occurred during transaction.<br />
            <br />
            Please contact to site administrator.
            <br />
            <br />
            <asp:LinkButton ID="LinkButtonErrorMsg" runat="server" PostBackUrl="~/Login.aspx">Click Here To Go Back!</asp:LinkButton>
        </center>
    </div>
</asp:Content>
