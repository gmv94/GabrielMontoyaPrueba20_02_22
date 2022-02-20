<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GabrielMontoyaPrueba20_02_22.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:label text="" id="lblRoleID" style="display:none;" runat="server" />
            <div class="row">
                <div class="mb-3">
                    <label for="txtUser" class="form-label">* User</label>
                    <input type="text" class="form-control" id="txtUser" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtPw" class="form-label">* Password</label>
                    <input type="password" class="form-control" runat="server" id="txtPw" />
                </div>
                <div class="pull-right">
                    <asp:Button ID="btnConsult"  CssClass="btn btn-finish btn-fill btn-green btn-wd" runat="server" OnClick="btnConsult_Click" Style="height: 30px; width: 100px; font-size: 12px; display: inline-block;" Text="Consult" />
                </div>
            </div>
            <div class="row" visible="false" style="color: red">
                <asp:Label Text="" Visible="false" ID="lblConsult" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
