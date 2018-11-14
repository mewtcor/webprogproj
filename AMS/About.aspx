<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AMS.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Attendance Management System</h3>
    <p>Coders: Enzo Lean and Maikel</p>
    <p>
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
    </p>
</asp:Content>
