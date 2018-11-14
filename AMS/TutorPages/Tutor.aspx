<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutor.aspx.cs" Inherits="AMS.TutorPages.Tutor1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
    <li>

    </li>  
  </ul>
    <p>&nbsp;</p>
    <ul>
    <li class="text-primary"><a href="AttendanceConfirmation.aspx">Confirmation</a></li>
    <li class="text-primary"><a href="Reports.aspx">Reports</a></li>
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
  <h1 class="text-center">Tutor Dashboard</h1>
    <br />
    <br />
    <div>

        <table class="nav-justified">
            <tr>
                <td class="text-center">&nbsp;</td>
                <td class="text-center">
                    <asp:RadioButtonList ID="ClassRButton" runat="server" Enabled="False" RepeatDirection="Horizontal" AutoPostBack="True" Font-Size="Smaller" Width="201px" OnSelectedIndexChanged="ClassRButton_SelectedIndexChanged">
                        <asp:ListItem>Enable</asp:ListItem>
                        <asp:ListItem>Disable</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="text-center" style="height: 27px">
                </td>
                <td class="text-left" style="height: 27px">
                    <asp:Button ID="btnClassStatus" runat="server" Enabled="False" Width="30%" OnClick="btnClassStatus_Click" OnClientClick="return confirm('Are you sure you want to change the class status?');" Text="Set Class Status" />
                </td>
            </tr>
            <tr>
                <td class="text-center" style="height: 23px"></td>
                <td class="text-center" style="height: 23px"></td>
            </tr>
            <tr>
                <td class="text-right" style="height: 58px">Select Class Schedule: </td>
                <td class="text-left" style="height: 58px">
                    <asp:DropDownList ID="drpDown" runat="server" AutoPostBack="True" Enabled="False" Width ="40%" OnSelectedIndexChanged="drpDown_SelectedIndexChanged">
                        <asp:ListItem>Please select a subject</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">&nbsp;</td>
            </tr>
        </table>

    </div>

    <asp:Panel ID="pID" runat="server">
        <table class="nav-justified">
            <tr>
                <td class="text-right">Class Name: </td>
                <td>
                    <asp:TextBox ID="txtClassName" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="text-right">Status: </td>
                <td>
                    <asp:TextBox ID="txtStatus" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="text-right">Date: </td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-right">Start Time: </td>
                <td>
                    <asp:TextBox ID="txtStartTime" runat="server" Font-Bold="True" ForeColor="Blue" Width="150px"></asp:TextBox>
                </td>
                <td class="text-right">Hours: </td>
                <td>
                    <asp:TextBox ID="txtHours" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="text-right">Practical: </td>
                <td>
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
                <td class="text-right">Trainer :</td>
                <td>
                    <asp:TextBox ID="txtTrainer" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="text-right">Venue: </td>
                <td>
                    <asp:TextBox ID="txtVenue" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="text-right">Class Status :</td>
                <td>
                    <asp:Label ID="lblClassStatus" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div class="text-center">

        

    </div>
    <br />
    <br />
 
</article>

<footer>Copyright &copy; Our Awesome Group</footer>

</div>

</asp:Content>
