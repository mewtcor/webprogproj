<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="AMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">


<nav>
  <ul>
    <li>
        <asp:LinkButton ID="lnkLogOff" runat="server" OnClick="LinkButton1_Click">LogOff</asp:LinkButton>
    </li>
    <li>Current User: <br /><asp:Label ID="lblCurrentUser" runat="server" Font-Size="XX-Small" ForeColor="#5C6984" style="font-size: small">CurrentUser</asp:Label></li>
    <li>Time: 
    <br />
        <asp:Timer ID="Timer1" runat="server" Interval ="1000" OnTick="Timer1_Tick"></asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>   
        <asp:Label ID="lblCurrentTime" runat="server" Font-Size="XX-Small" ForeColor="#5C6984" style="font-size: small"></asp:Label>                        
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
        </asp:UpdatePanel>
    </li>
    <li>Date: <br /><asp:Label ID="lblCurrentDate" runat="server" Font-Size="XX-Small" ForeColor="#5C6984" style="font-size: small"></asp:Label></li>
    
    
    </ul>
    <p>&nbsp;</p>
    <ul>
    <li><a href="Reg.aspx">User Registration</a></li>
    <li><a href="Class.aspx">Class Schedules</a></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
  </ul>
</nav>

<article>
  <h1 class="text-center">Admin Dashboard</h1>
  
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br /> 
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

  
</article>

<footer>Copyright &copy; Our Awesome Group</footer>

</div>

</asp:Content>
