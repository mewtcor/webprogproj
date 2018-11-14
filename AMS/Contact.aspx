<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AMS.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Contact Page</h3>
    <address>
        Aspire 2 International<br />
        Auckland<br />
        <abbr title="Phone">Phone:</abbr>
        000.000.0000
    </address>
    <address>
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:llcorpuz@gmail.com">llcorpuz@gmail.com</a><br />
    </address>
</asp:Content>
