<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="AMS.AdminPages.Reg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container">


<nav>
  <ul>
      <li>
          <asp:LinkButton ID="lgOff" runat="server" OnClick="lgOff_Click">LogOff</asp:LinkButton>
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
    <li></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>

    <li></li>
  </ul>
</nav>

<article>
  <h2 class="text-center">User Registration</h2>

    <table class="nav-justified">
        <tr>
            <td style="width: 180px; height: 23px;" class="text-right"></td>
            <td style="width: 58px; height: 23px;">
                    </td>
            <td style="width: 600px; height: 23px;" class="text-center">
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblUId" runat="server" Text="lblUId" Visible="False"></asp:Label>
                            <asp:Label ID="lblProdId" runat="server" Text="lblProdId" Visible="False"></asp:Label>
                            <asp:Label ID="lblRoleId" runat="server" Text="lblRoleId" Visible="False"></asp:Label>
                            </td>
            <td style="width: 102px; height: 23px;">
                            </td>
            <td class="text-center" style="height: 23px; width: 600px">
                    </td>
            <td class="text-center" style="height: 23px">
                    &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 180px" class="text-right">
                   
                     <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="80%" ValidationGroup="UserG" />
                    </td>
            <td style="width: 58px">
                &nbsp;</td>
            <td style="width: 600px" class="text-center">
            <input type="text" id="inputEmail" name="Email" placeholder="Email" runat="server" required="required" class="input-txt" style="width:80%" />
            </td>
            <td style="width: 102px">
                &nbsp;</td>
            <td class="text-center" style="width: 600px">
                <input type="text" id="inputPassword" name="Password" placeholder="Password" runat="server" required="required" class="input-txt" style="width: 80%" /></td>
            <td class="text-center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 180px" class="text-right"> 
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Width="80%" />
                    </td>
            <td style="width: 58px">
                            &nbsp;</td>
            <td style="width: 600px" class="text-center">
                            <input type="text" id="inputFirstName" name="FirstName" placeholder="FirstName" runat="server" required="required" class="input-txt" style="width: 80%" /></td>
            <td style="width: 102px">
                            &nbsp;</td>
            <td class="text-center" style="width: 600px">
                            <input type="text" id="inputLastName" name="LastName" placeholder="LastName" runat="server" required="required" class="input-txt" style="width: 80%" /></td>
            <td class="text-center">
                            &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 180px" class="text-right">
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" Width="80%" />
                    </td>
            <td style="width: 58px">

                            &nbsp;</td>
            <td style="width: 600px" class="text-center">

                            &nbsp; <asp:DropDownList ID="drpUAccess" runat="server" ValidationGroup="UserG" Width="60%" OnSelectedIndexChanged="drpUAccess_SelectedIndexChanged">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Administrator</asp:ListItem>
                                                    <asp:ListItem>Tutor</asp:ListItem>
                                                    <asp:ListItem>Student</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="drpUAccess" ErrorMessage="User Role is required." ForeColor="Red" ValidationGroup="UserG"></asp:RequiredFieldValidator>

              </td>
            <td style="width: 102px">

                            &nbsp;</td>
            <td class="text-center" style="width: 600px">

                            &nbsp;</td>
            <td class="text-center">

                            &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px; width: 180px;" class="text-right">    
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Width="80%" />
                        </td>
            <td style="height: 23px; width: 58px;">

                            &nbsp;</td>
            <td style="height: 23px; width: 600px;" class="text-center">

                            &nbsp;
                                                

                                                </td>
            <td style="height: 23px; width: 102px;">

                            &nbsp;</td>
            <td style="height: 23px; width: 600px;" class="text-center">

                            &nbsp;</td>
            <td style="height: 23px" class="text-center">

                            &nbsp;</td>
        </tr>
        </table>
                                 
                                 <div class="text-center">
                                 <asp:GridView ID="gdwUsers" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="5" HorizontalAlign="Center" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gdwUsers_SelectedIndexChanged">
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="Id" HeaderText="Id" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Email" HeaderText="Email" />
        <asp:BoundField ItemStyle-Width="0px" DataField="Password" HeaderText="Password" />
        <asp:BoundField ItemStyle-Width="150px" DataField="FirstName" HeaderText="First Name" />
        <asp:BoundField ItemStyle-Width="150px" DataField="LastName" HeaderText="Last Name" />
        <asp:BoundField ItemStyle-Width="150px" DataField="UAccess" HeaderText="Role" />
        <asp:BoundField ItemStyle-Width="0px" DataField="roleId" HeaderText="Role Id" />

    </Columns>
</asp:GridView>                             
                                 </div>
    <br />
</article>
<footer>Copyright &copy; Our Awesome Group</footer>
</div>
</asp:Content>
