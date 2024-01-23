<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Images.aspx.cs" Inherits="Pruba.Views.Images" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Image Viewer</title>
    <link rel="stylesheet" type="text/css" href="../Styles/index.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Nombre de la pieza:<br />
                Diametro horizontal:<br />
                Diametro Vertical:<br />
                Profundidad:<br />
            </p>
            <asp:Image ID="imgViewer" runat="server" CssClass="centerImage" />
            <div class="buttonContainer">
                <asp:Button ID="btnPrev" runat="server" Text="Anterior" OnClick="btnPrev_Click" CssClass="btnPrev" />
                <asp:Button ID="btnNext" runat="server" Text="Siguiente" OnClick="btnNext_Click" CssClass="btnNext" />
            </div>
        </div>
    </form>
</body>
</html>
