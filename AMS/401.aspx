<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="401.aspx.cs" Inherits="AMS.http404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style3 {
            font-size: larger;
        }
        .auto-style4 {
            text-align: center;
            color: #FFFFFF;
            background-color: #FF0000;
        }
        .auto-style5 {
            width: 356px;
            height: 415px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
             <br /><br /><br /><br />
             <img alt="401" class="auto-style5" longdesc="unauthorized access" src="Images/401.png" /><div><h1 class="auto-style4">Unauthorized Access!</h1>
        <p class="auto-style1">
            <asp:LinkButton ID="lnkbLogin" runat="server" Font-Bold="True" Font-Size="XX-Large" OnClick="lnkbLogin_Click" CssClass="auto-style3">Back To Login</asp:LinkButton>
        </p></div>
        </div>
    </form>
</body>
</html>
