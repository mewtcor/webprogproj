<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="StudentPageTest.StudentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

<nav>
  <ul>
      <li>
          
          <asp:LinkButton ID="lgOff" runat="server" OnClick="lgOff_Click">LogOff</asp:LinkButton>
      </li>
      <li>
           
          <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Change Password</asp:LinkButton>
           
      </li>
    <li>Current User: 
        <asp:Label ID="lblCurrentUser" runat="server" Font-Size="XX-Small" ForeColor="#5C6984" style="font-size: small">CurrentUser</asp:Label>
        <br />                         
    </li>
    <li>Time: 
    <br />                     <!-- Real Time Digital Clock -->
                            <asp:Timer ID="TimerTime" runat="server" Interval="1000" OnTick="TimerTime_Tick">
                            </asp:Timer>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>   
                            <asp:Label ID="lblCurrentTime" runat="server" Font-Size="Small" ForeColor="#5C6984" style="font-size: small"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="TimerTime" EventName="Tick" />
                            </Triggers>
                            </asp:UpdatePanel>
    </li>
    <li>Date: <br /><asp:Label ID="lblCurrentDate" runat="server" Font-Size="XX-Small" ForeColor="#5C6984" style="font-size: small">lblCurrentDate</asp:Label></li>
    </ul>
    <p>&nbsp;</p>
    <ul>
    <li></li>
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
  <h1 class="text-center">Student Dashboard</h1>
  
    <table class="nav-justified">
        <tr>
            <td class="text-center">&nbsp;</td>
            <td class="text-center" style="width: 700px"><strong>
                <asp:Label ID="lblTimeIn" runat="server" ForeColor="Red" style="font-size: xx-large" Text="lblTimeIn"></asp:Label>
                </strong></td>
            <td class="text-center"><strong>
                <asp:Label ID="lblTimeOut" runat="server" ForeColor="Red" style="font-size: xx-large" Text="lblTimeOut"></asp:Label>
                </strong></td>
            <td class="text-center">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" style="height: 55px">
            </td>
            <td class="text-center" style="width: 700px; height: 55px">
        <asp:Button ID="TimeInButton" runat="server" Text="Record Time In" OnClick="TimeInButton_Click" style="width: 30%" />
            </td>
            <td class="text-center" style="width:700px; height: 55px">
        <asp:Button ID="TimeOutButton" runat="server" Text="Record Time Out" OnClick="TimeOutButton_Click" Width="30%" OnClientClick="return confirm('Are you sure you want to Clock Out?');" Enabled="False"/>
            </td>
            <td class="text-center" style="height: 55px">
            </td>
        </tr>
        <tr>
            <td class="text-center" style="height: 21px">
                </td>
            <td class="text-center" style="height: 21px; width: 700px;">
                </td>
            <td class="text-center" style="height: 21px">
                </td>
            <td class="text-center" style="height: 21px">
                </td>
        </tr>
        <tr>
            <td class="text-right">&nbsp;</td>
            <td class="text-right" style="width: 700px">Select Class Schedule: </td>
            <td class="text-left" style="height:58px">
                <asp:DropDownList ID="drpDown" runat="server" AutoPostBack="True" Width="40%" OnSelectedIndexChanged="drpDown_SelectedIndexChanged" Height="43px" CssClass="col-md-offset-0">
                <asp:ListItem>Please select a subject</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                
            </td>
            <td class="text-left">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right">&nbsp;</td>
            <td class="text-right" style="width: 700px">&nbsp;</td>
            <td class="text-left">&nbsp;</td>
            <td class="text-left">&nbsp;</td>
        </tr>
        </table>

    <table class="nav-justified">
        <tr>
            <td class="text-right" style="height: 25px">Class Name:
                            </td>
            <td style="height: 25px">
                                <asp:TextBox ID="txtClassName" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td class="text-right" style="height: 25px">Status: </td>
            <td style="height: 25px">
                                <asp:TextBox ID="txtStatus" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td class="text-right" style="height: 25px">Date: </td>
            <td style="height: 25px">
                                <asp:TextBox ID="txtDate" runat="server" Width="150px"></asp:TextBox>
                            </td>
        </tr>
        <tr>
            <td class="text-right" style="height: 28px">Start Time: </td>
            <td style="height: 28px">
                                <asp:TextBox ID="txtStartTime" runat="server" Font-Bold="True" ForeColor="Blue" Width="150px"></asp:TextBox>
                            </td>
            <td class="text-right" style="height: 28px">Hours: </td>
            <td style="height: 28px">
                                <asp:TextBox ID="txtHours" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td class="text-right" style="height: 28px">Practical: </td>
            <td style="height: 28px">
                                <asp:TextBox ID="txtPractical" runat="server" Width="150px"></asp:TextBox>
                            </td>
        </tr>
        <tr>
            <td class="text-right">End Time: </td>
            <td>
                                <asp:TextBox ID="txtEndTime" runat="server" Font-Bold="True" ForeColor="Blue" Width="150px"></asp:TextBox>
                            </td>
            <td class="text-right">Theory: </td>
            <td>
                                <asp:TextBox ID="txtTheory" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td class="text-right">Enrolments:</td>
            <td>
                                <asp:TextBox ID="txtEnrolments" runat="server" Width="150px"></asp:TextBox>
                            </td>
        </tr>
        <tr>
            <td class="text-right" style="height: 25px">Trainer :</td>
            <td style="height: 25px">
                                <asp:TextBox ID="txtTrainer" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td class="text-right" style="height: 25px">Venue: </td>
            <td style="height: 25px">
                                <asp:TextBox ID="txtVenue" runat="server" Width="150px"></asp:TextBox>
                            </td>
            <td style="height: 25px"></td>
            <td style="height: 25px"></td>
        </tr>
        </table>

    
</article>
<br /><br />
<footer>Copyright © Our Awesome Group</footer>

   
</div>

</asp:Content>
