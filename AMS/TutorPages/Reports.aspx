<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="AMS.TutorPages.Tutor" EnableEventValidation="false" %>
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
    </ul>
    <p>&nbsp;</p>
    <ul>
    <li><a href="Tutor.aspx">Tutor Dashboard</a></li>
    <li></li>
    <li></li>
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
    <table class="nav-justified">
        <tr>
            <td class="text-center">Select Class:<asp:DropDownList ID="ClassReportDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ClassReportDropDownList_SelectedIndexChanged" style="margin-bottom: 0" CssClass="col-md-offset-0" Width="428px">
                </asp:DropDownList>
    
            </td>
        </tr>
        </table>
    
    <div>

        <div id="divExport" runat="server"> 
    <table class="nav-justified">
        <tr>
            <td class="text-right" style="width: 173px">
                Class Name: </td>
            <td style="width: 250px">
                
                    <input type="text" id="inClassName" name="ClassName" placeholder="ClassName" runat="server" class="input-txt" style="width:100%" /></td>
            <td class="text-right" style="width: 251px">
                Status:
                </td>
            <td style="width: 250px">
                <input type="text" id="inStatus" name="Status" placeholder="Status" runat="server" class="input-txt" style="width:100%" /></td>
            <td class="text-right" style="width: 195px">
                Theory: </td>
            <td style="width: 250px">
                <input type="text" id="inTheory" name="Theory" placeholder="Theory" runat="server" class="input-txt" style="width:100%" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 173px; height: 52px;">
                <asp:Label ID="Label6" runat="server" Text="Date: "></asp:Label>
              </td>
            <td style="width: 250px; height: 52px;">
                <input type="text" id="inDate" name="Date" placeholder="Date" runat="server" class="input-txt" style="width:100%" />
            </td>
            <td class="text-right" style="width: 251px; height: 52px;">
                <asp:Label ID="Label9" runat="server" Text="Hours:"></asp:Label>
                </td>
            <td style="width: 250px; height: 52px;">
                <input type="text" id="inHours" name="Hours" placeholder="Hours" runat="server" class="input-txt" style="width:100%" />
            </td>
            <td class="text-right" style="width: 195px; height: 52px;">
                <asp:Label ID="Label12" runat="server" Text="Enrollment: "></asp:Label>
            </td>
            <td style="width: 250px; height: 52px;">
                <input type="text" id="inEnrolment" name="Enrolment" placeholder="Enrolment" runat="server" class="input-txt" style="width:100%" />
            </td>
            <td style="height: 52px">
                </td>
            <td style="height: 52px">
                </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 173px; height: 52px;">
                <asp:Label ID="Label7" runat="server" Text="Start Time: "></asp:Label>
                </td>
            <td style="width: 250px; height: 51px;">
                <input type="text" id="inStartTime" name="StartTime" placeholder="Start Time" runat="server" class="input-txt" style="width:100%" />
            </td>
            <td class="text-right" style="width: 251px; height: 51px;">
                <asp:Label ID="Label10" runat="server" Text="Practical: "></asp:Label>
                </td>
            <td style="width: 250px; height: 51px;">
                <input type="text" id="inPractical" name="Practical" placeholder="Practical" runat="server" class="input-txt" style="width:100%" />
            </td>
            <td class="text-right" style="width: 195px; height: 51px;">
                <asp:Label ID="Label13" runat="server" Text="Trainer: "></asp:Label>
                </td>
            <td style="width: 250px; height: 51px;">
                `<input type="text" id="inTrainer" name="Trainer" placeholder="Trainer" runat="server" class="input-txt" style="width:100%" />
            </td>
            <td style="height: 51px">
                </td>
            <td style="height: 51px">
                </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 173px">
                <asp:Label ID="Label8" runat="server" Text="End Time: "></asp:Label>
                </td>
            <td style="width: 250px">
                <input type="text" id="inEndTime" name="EndTime" placeholder="End Time" runat="server" class="input-txt" style="width:100%" />
            </td>
            <td class="text-right" style="width: 251px">
                &nbsp;</td>
            <td style="width: 250px">
                &nbsp;</td>
            <td class="text-right" style="width: 195px">
                <asp:Label ID="Label14" runat="server" Text="Venue: "></asp:Label>
                </td>
            <td style="width: 250px">
                <input type="text" id="inVenue" name="Venue" placeholder="Venue" runat="server" class="input-txt" style="width:100%" />
            </td>
            <td>
                &nbsp;</td>

            <td>
                &nbsp;</td>
        </tr>
    </table>


        <asp:Button ID="ExportButton" runat="server" OnClick="ExportButton_Click" Text="Export Data" Width =" 12%" />

    <br />
                     <div style="width: 100%" >

                         <asp:GridView ID="gdwConfirm" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="5" HorizontalAlign="Center">
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
    </div>

    </div>

    
    <div class="text-center">
        <br />

    </div>

    <br />
    <br />

    <br />
 
</article>

<footer>Copyright &copy; Our Awesome Group</footer>

</div>

</asp:Content>
