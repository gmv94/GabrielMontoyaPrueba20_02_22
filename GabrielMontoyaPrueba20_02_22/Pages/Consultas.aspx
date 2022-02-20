<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="GabrielMontoyaPrueba20_02_22.Pages.Consultas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">

            <div class="col-sm-6">
                <p>Tipo de consulta</p>
                <asp:DropDownList ID="ddlTipoConsulta" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoConsulta_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="1">Autor</asp:ListItem>
                    <asp:ListItem Value="2">Libro</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-6">
                <div id="dvAutor" runat="server">
                    <p>Nombre Autor</p>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    <p>Apellido Autor</p>
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                </div>
                <div id="dvLibro" runat="server" visible="false">
                    <p>Nombre Libro</p>
                    <asp:TextBox ID="txtLibro" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <div class="pull-right">
                    <asp:Button ID="btnHome" CssClass="btn btn-finish btn-fill btn-green btn-wd" runat="server" OnClick="btnHome_Click" Style="height: 30px; width: 100px; font-size: 12px; display: inline-block; margin: 10px;" Text="Home" />
                    <asp:Button ID="btnConsultar" CssClass="btn btn-finish btn-fill btn-green btn-wd" runat="server" OnClick="btnConsultar_Click" Style="height: 30px; width: 100px; font-size: 12px; display: inline-block; margin: 10px;" Text="Consultar" />
                </div>
            </div>
        </div>
        <div class="row">
            <div>
                <asp:GridView ID="gvwLibro" runat="server" CssClass="table table-striped jambo_table bulk_action"
                    AllowPaging="True" AutoGenerateColumns="false" OnPageIndexChanging="gvwLibro_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                        <asp:BoundField DataField="publishDate" HeaderText="publishDate" SortExpression="publishDate" />
                        <asp:BoundField DataField="pageCount" HeaderText="pageCount" SortExpression="pageCount" />
                        <asp:BoundField DataField="excerpt" HeaderText="excerpt" SortExpression="excerpt" />
                        <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row" visible="false" style="color: red">
            <asp:Label Text="" Visible="false" ID="lblConsult" runat="server" />
        </div>
    </form>
</body>
</html>
