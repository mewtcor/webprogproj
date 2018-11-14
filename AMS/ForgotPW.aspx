<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPW.aspx.cs" Inherits="AMS.ForgotPW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Password Helper</title>
    <link href="Scripts/css/style2.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 500px;
            height: 302px;
            margin: 0 auto;
        }
        .auto-style2 {
            color: #FFFFFF;
        }
        .auto-style3 {
            text-align: center;
            width: 150px;
            height: 52px;
        }
        .auto-style4 {
            height: 52px;
            width: 375px;
        }
        .auto-style5 {
            width: 375px;
        }
        .auto-style6 {
            width: 300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
</div>



        <div>
            <table class="auto-style6"; style="border: 1px solid black" align="center"  >
        <tr>
            <td style="width: 150px" class="auto-style2"><strong>Reset Password</strong></td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 150px" class="auto-style2">Email</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="btnResetPass" runat="server" Text="Show Password Hint" OnClick="btnResetPass_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblMSG" runat="server" CssClass="auto-style2"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
        </div>
    </form>
</body>
</html>
