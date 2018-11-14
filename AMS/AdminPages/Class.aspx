<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="AMS.AdminPages.Class" %>
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
    <li><a href="Administrator.aspx">Admin Dashboard</a></li>
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

<article>
  <h1 class="text-center">Class Schedule</h1>
  
    <br />
    <table style="width: 1195px; height: 181px">
        <tr>
            <td></td>
            <td class="text-left" style="width: 168px">
                &nbsp;</td>
            <td class="text-center" colspan="5">
                <asp:Label ID="lblMSG" runat="server"></asp:Label>
            </td>
            <td class="text-left" style="width: 163px">
                &nbsp;</td>
            <td class="text-left" style="width: 47px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px">Class Name: </td>
            <td class="text-left" style="width: 224px">
                <asp:TextBox ID="txtClass" runat="server" ValidationGroup="ClassSched" Width="200px"></asp:TextBox>
            </td>
            <td class="text-left" style="width: 95px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtClass" ErrorMessage="required" ForeColor="Red" ValidationGroup="ClassSched"></asp:RequiredFieldValidator>
            </td>
            <td class="text-right">
                Start Time:
            </td>
            <td class="text-left">
                <asp:TextBox ID="txtStartTime" runat="server" TextMode="Time" ValidationGroup="ClassSched"></asp:TextBox>
                : </td>
            <td class="text-left" style="width: 95px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtStartTime" ErrorMessage="required" ForeColor="Red" ValidationGroup="ClassSched"></asp:RequiredFieldValidator>
            </td>
            <td class="text-right" style="width: 163px">
                Theory :</td>
            <td class="text-left">
                <asp:TextBox ID="txtTheory" runat="server"></asp:TextBox>
            </td>
            <td class="text-left" style="width: 71px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px">Status: </td>
            <td class="text-left" style="width: 224px">
                <asp:DropDownList ID="DropDownListStt" runat="server" Height="16px" ValidationGroup="ClassSched" Width="200px">
                    <asp:ListItem>Select a status</asp:ListItem>
                    <asp:ListItem>Open</asp:ListItem>
                    <asp:ListItem>Closed</asp:ListItem>
                    <asp:ListItem>Accepted</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="text-left" style="width: 95px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="DropDownListStt" ErrorMessage="required" ForeColor="Red" ValidationGroup="ClassSched"></asp:RequiredFieldValidator>
            </td>
            <td class="text-right">
                End Time:
            </td>
            <td class="text-left">
                <asp:TextBox ID="txtEndTime" runat="server" TextMode="Time" ValidationGroup="ClassSched"></asp:TextBox>
            </td>
            <td class="text-left" style="width: 95px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtEndTime" ErrorMessage="required" ForeColor="Red" ValidationGroup="ClassSched"></asp:RequiredFieldValidator>
            </td>
            <td class="text-right" style="width: 163px">
                Enrolments: </td>
            <td class="text-left">
                <asp:TextBox ID="txtEnrolments" runat="server" ValidationGroup="ClassSched"></asp:TextBox>
            </td>
            <td class="text-left" style="width: 71px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtEnrolments" ErrorMessage="required" ForeColor="Red" ValidationGroup="ClassSched"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px">Date Of Class:&nbsp; </td>
            <td class="text-left" style="width: 224px">
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date" ValidationGroup="ClassSched" Width="200px"></asp:TextBox>
            </td>
            <td class="text-left" style="width: 95px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtDate" ErrorMessage="required" ForeColor="Red" ValidationGroup="ClassSched"></asp:RequiredFieldValidator>
            </td>
            <td class="text-right">
                Hours :
            </td>
            <td class="text-left">
                <asp:TextBox ID="txtHours" runat="server" ValidationGroup="ClassSched"></asp:TextBox>
            </td>
            <td class="text-left" style="width: 95px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtHours" ErrorMessage="required" ForeColor="Red" ValidationGroup="ClassSched"></asp:RequiredFieldValidator>
            </td>
            <td class="text-right" style="width: 163px">
                Venue :</td>
            <td class="text-left">
                <asp:TextBox ID="txtVenue" runat="server" ValidationGroup="ClassSched"></asp:TextBox>
            </td>
            <td class="text-left" style="width: 71px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtVenue" ErrorMessage="required" ForeColor="Red" ValidationGroup="ClassSched"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="height: 23px; width: 168px;">Tutor : </td>
            <td class="text-left" style="height: 23px; width: 224px;">
                <asp:DropDownList ID="drpLstTutors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PopulateTxt" Height="23px" Width="200px">
                    <asp:ListItem>Select A Tutor</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="text-left" style="height: 23px; width: 95px;">
                &nbsp;</td>
            <td class="text-right" style="height: 23px">
                Practical :</td>
            <td class="text-left" style="height: 23px">
                <asp:TextBox ID="txtPractical" runat="server"></asp:TextBox>
            </td>
            <td class="text-left" style="height: 23px; width: 95px;">
                </td>
            <td style="height: 23px; width: 163px;" class="text-right">
                Attendance Status :</td>
            <td style="height: 23px" class="text-left">
                <asp:DropDownList ID="DropDownListAttStt" runat="server" Visible="False">
                    <asp:ListItem>Choose Status</asp:ListItem>
                    <asp:ListItem>True</asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="height: 23px; width: 71px;" class="text-left">
                </td>
        </tr>
        <tr>
            <td class="text-right" style="height: 23px; width: 168px;">Tutor&#39;s Email :</td>
            <td class="text-left" style="height: 23px; width: 224px;">
                <asp:TextBox ID="txtTrainerEmail" runat="server" ValidationGroup="ClassSched" Width="200px"></asp:TextBox>
                </td>
            <td class="text-left" style="height: 23px; width: 95px;">
                &nbsp;</td>
            <td class="text-right" style="height: 23px">
                </td>
            <td class="text-left" style="height: 23px"></td>
            <td class="text-left" style="height: 23px; width: 95px;"></td>
            <td class="text-right" style="height: 23px; width: 163px;">
                </td>
            <td class="text-left" style="height: 23px">
                </td>
            <td class="text-left" style="height: 23px; width: 71px;">
                </td>
        </tr>
        <tr>
            <td class="text-right" style="height: 23px; width: 168px;"></td>
            <td class="text-left" style="height: 23px; width: 224px;">
                &nbsp;</td>
            <td class="text-left" style="height: 23px; width: 95px;">
                &nbsp;</td>
            <td class="text-left" style="height: 23px">
                </td>
            <td class="text-left" style="height: 23px"></td>
            <td class="text-right" style="height: 23px; width: 95px;"></td>
            <td style="height: 23px; width: 163px;">
                </td>
            <td class="text-left" style="height: 23px">
                &nbsp;</td>
            <td class="text-left" style="height: 23px; width: 71px;">
                </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px; height: 27px"></td>
            <td class="text-center" colspan="6" style="height: 27px">
                <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Width="75px" ValidationGroup="ClassSched" />
                <asp:Button ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Update" Width="75px" ValidationGroup="ClassSched" />
                <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete" Width="75px" ValidationGroup="ClassSched" />
            </td>
            <td class="text-center" style="height: 27px">
                <asp:Label ID="lblClass" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="text-center" style="width: 71px; height: 27px;">
                </td>
        </tr>
    </table>
    <br />
    
    <div>

    </div>
    <br />
    <div style="width: 100%; height: 400px;" >

        <asp:GridView ID="gdwClass" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="5" HorizontalAlign="Center" OnSelectedIndexChanged="gdwClass_SelectedIndexChanged" AutoGenerateSelectButton="True">
    <Columns>
<asp:BoundField ItemStyle-Width="150px" DataField="Id" HeaderText="Id" />
        <asp:BoundField ItemStyle-Width="150px" DataField="ClassName" HeaderText="Class" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Status" HeaderText="Status" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Date" HeaderText="Date" />
        <asp:BoundField ItemStyle-Width="150px" DataField="StartTime" HeaderText="Start Time" />
        <asp:BoundField ItemStyle-Width="150px" DataField="EndTime" HeaderText="End Time" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Hours" HeaderText="Hours" />
        
        <asp:BoundField ItemStyle-Width="150px" DataField="Enrolments" HeaderText="Enrolments" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Trainer" HeaderText="Trainer" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Venue" HeaderText="Venue" />
        <asp:BoundField ItemStyle-Width="150px" DataField="AttStatus" HeaderText="AttStatus" />
        <asp:BoundField ItemStyle-Width="150px" DataField="TrainerEmail" HeaderText="TrainerEmail" />

    </Columns>
</asp:GridView>

                                 
        </div>
    <br />

  
</article>

<footer>Copyright &copy; Our Awesome Grouprouper>

</div>
</asp:Content>
