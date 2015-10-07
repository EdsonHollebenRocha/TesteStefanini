<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebApp.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style type="text/css">
        .trVisible {
            visibility: visible;
        }

        .trInvisible {
            visibility: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="height: 100%; width: 100%;">
            <tr style="height: 100%; width: 100%;">
                <td style="height: 100%; width: 100%;vertical-align:middle;text-align:center;">
                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" Text="E-mail"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Width="300px"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" Text="Password" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="300px" />
                            </td>
                        </tr>
                        <tr runat="server" id="trAlertTr">
                            <td colspan="2">
                                <asp:Label ID="lblLoginError" runat="server" ForeColor="Red" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <%--<asp:Login ID="Login1" runat="server" UserNameLabelText="E-mail" TitleText=""
            LoginButtonText="Login" DisplayRememberMe="false" OnAuthenticate="Login1_Authenticate"
            PasswordLabelText="Password">
        </asp:Login>--%>
    </form>
</body>
</html>
