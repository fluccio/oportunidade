<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true"
    CodeBehind="LerBlog.aspx.cs" Inherits="LerBlogMinutoSeguros._Default" %>

    <head>
        <style type="text/css">
            .style1
            {
                width: 181px;
            }
            .style2
            {
                width: 178px;
            }
        </style>


        <script type="text/javascript" language="javascript">
            function SomenteNumero(e) {
                var tecla = (window.event) ? event.keyCode : e.which;
                if (((tecla > 47 && tecla < 58))) return true;
                else {
                    if (tecla != 8) return false;
                    else return true;
                }
            }
</script>


</head>
<form id="form1" runat="server">

    <h2 style="text-align: center">
       MINUTO SEGUROS
    </h2>

    <table style="width:100%;">
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="11pt" 
                    Text="Quantidade de Caracteres:"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox id="txt_QtdCarac" runat="server" 
                    onkeypress="return SomenteNumero(event)">4</asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnPesquisa" runat="server" onclick="btnPesquisa_Click" 
                    Text="Confirmar" />
            </td>
        </tr>
</table>
<br />
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="12pt" 
                    Text="Total Geral" Font-Bold="True" Font-Underline="True"></asp:Label>
<br />
<br />

    <asp:Label ID="lblTexto" runat="server" Font-Names="Arial" Font-Size="11pt"></asp:Label>



<br />
    <br />
    <br />
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="12pt" 
                    Text="Total Por Tópico" Font-Bold="True" Font-Underline="True"></asp:Label>
            <br />
    <br />

    <asp:Label ID="lblTextoPorTopico" runat="server" Font-Names="Arial" Font-Size="11pt"></asp:Label>



<br />
</form>




