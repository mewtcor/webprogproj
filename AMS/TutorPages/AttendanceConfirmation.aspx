<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AttendanceConfirmation.aspx.cs" Inherits="AMS.TutorPages.AttendanceConfirmation" %>
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
    <li><a href="Tutor.aspx">Tutor Dashboard</a></li>
    <li><a href="#"></a></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
  </ul>
</nav>

<article class="text-center">
  <h1 class="text-center">&nbsp;Tutor Attendance Confirmation</h1>
  
    <div class="text-center">
  
    <br />
        <table class="nav-justified">
            <tr>
                <td class="text-right" style="width: 168px">
                    &nbsp;</td>
                <td class="text-left">
                    <asp:DropDownList ID="drpDown" runat="server" AutoPostBack="True" Width="40%" Enabled="False" OnSelectedIndexChanged="drpDown_SelectedIndexChanged">
                        <asp:ListItem>Please select a subject</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td class="text-right">
                    &nbsp;</td>
                <td class="text-left">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 23px; width: 168px;"></td>
                <td style="height: 23px"></td>
                <td style="height: 23px"></td>
                <td style="height: 23px" class="text-left">&nbsp;</td>
                <td style="height: 23px"></td>
                <td style="height: 23px"></td>
            </tr>
            <tr>
                <td class="text-right" style="width: 168px">Student Name</td>
                <td class="text-left">
                    <asp:Label ID="lblName" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                </td>
                <td class="text-right">&nbsp;</td>
                <td class="text-left">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="text-right" style="width: 168px">Comment: </td>
                <td class="text-left">
                    <input type="text" id="inComment" name="Comment" placeholder="Comment" runat="server" class="input-txt" style="width:60%" />
                    </td>
                <td class="text-right">&nbsp; </td>
                <td class="text-left">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="text-right" style="width: 168px">&nbsp;</td>
                <td class="text-left">
                    <asp:Button ID="btnSaveComment" runat="server" OnClick="btnSaveComment_Click" Text="Save Comment" Width="20%" />
                    &nbsp;
                    <asp:Button ID="btnExclude" runat="server" OnClick="btnExclude_Click" Text="Exclude Student" Width="20%" />
                &nbsp;<asp:Button ID="btnConfirm" runat="server" Font-Bold="True" Width="20%" Height="36px" OnClick="btnConfirm_Click" Text="Confirm Attendance" />
                </td>
                <td class="text-right">
                    <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="text-left">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <br />
         <div >
             <asp:GridView ID="gdwDaysAttendance" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="5" HorizontalAlign="Center" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gdwUsers_SelectedIndexChanged">
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="AId" HeaderText="Id" />
        <asp:BoundField ItemStyle-Width="150px" DataField="UFName" HeaderText="First Name" />
        <asp:BoundField ItemStyle-Width="0px" DataField="ULName" HeaderText="Last Name" />
        <asp:BoundField ItemStyle-Width="150px" DataField="UEmail" HeaderText="Email" />
        <asp:BoundField ItemStyle-Width="150px" DataField="ATimeIn" HeaderText="Time In" />
        <asp:BoundField ItemStyle-Width="150px" DataField="ATimeOut" HeaderText="Time Out" />
        <asp:BoundField ItemStyle-Width="0px" DataField="AComment" HeaderText="Comment" />

    </Columns>
</asp:GridView>
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
    <br />

  
    </div>

  
</article>

<footer>Copyright &copy; Our Awesome Group</footer>

</div>
</asp:Content>
