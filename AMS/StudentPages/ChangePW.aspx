<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePW.aspx.cs" Inherits="AMS.StudentPages.ChangePW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br /><br />

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
    <li><a href="StudentPage.aspx">Student Dashboard</a></li>
    <li></li>
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
  <h1 class="text-center">Change Your Password?</h1>
  
    <br />
    <br />
    <div class="text-center">

        <table class="nav-justified">
            <tr>
                <td class="text-right" style="width: 431px">&nbsp;</td>
                <td class="text-left">
                    <asp:Label ID="LblMSG" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="width: 431px">Current Password : </td>
                <td class="text-left">
                    <asp:TextBox ID="txtCurrentPass" runat="server" ValidationGroup="ChangePW"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentPass" ErrorMessage="required field" ForeColor="Red" ValidationGroup="ChangePW"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="width: 431px">New Password: </td>
                <td class="text-left">
                    <asp:TextBox ID="TxtNewPass" runat="server" ValidationGroup="ChangePW"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNewPass" ErrorMessage="required field" ForeColor="#CC0000" ValidationGroup="ChangePW"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="width: 431px">Confirm Password: </td>
                <td class="text-left">
                    <asp:TextBox ID="txtConfNewPass" runat="server" ValidationGroup="ChangePW"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfNewPass" ErrorMessage="required field" ForeColor="Red" ValidationGroup="ChangePW"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="text-right" style="width: 431px">&nbsp;</td>
                <td class="text-left">
                    <asp:Button ID="btnChangePass" runat="server" OnClick="btnChangePass_Click" Text="Change Password" ValidationGroup="ChangePW" Width="126px" />
                </td>
            </tr>
            <tr>
                <td class="text-right" style="width: 431px">&nbsp;</td>
                <td class="text-left">&nbsp;</td>
            </tr>
        </table>

    </div>
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
