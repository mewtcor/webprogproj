<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Management System</title>


  <link href="Scripts/css/style2.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            font: 1.8em/48px "Tenor Sans", sans-serif;
            color: white;
            text-align: center;
        }
        .auto-style2 {
            margin-top: 50px;
            width: 450px;
            text-align: right;
        }
    </style>

    <link href="Scripts/css/Login.css" rel="stylesheet" />
</head>
<body>

     <form id="form1" runat="server">
        <div class="container">
  <div class="auto-style2">
  	<h1 class="auto-style1">
        &nbsp;</h1>
      <h1 class="auto-style1">
          <strong>ATTENDANCE Management System</strong></h1>
      <h1 class="login-heading">
          </h1>
      <h2 class="login-heading">
          Please login.</h2>
        <input type="text" id="email" name="email" placeholder="Email" runat="server" required="required" class="input-txt" />
          <input type="password" id="password" name="password" placeholder="Password" required="required" class="input-txt" runat="server" />
          <div class="login-footer">
             <a href="ForgotPW.aspx" class="lnk">
              &nbsp;Forgot Password?
            </a>
    
          </div>
            <input type="submit" value="Login" id = "btnSignIn" runat="server" onserverclick="btnSignIn_Click">
        </div>
</div>
    </form>
</body>
</html>
