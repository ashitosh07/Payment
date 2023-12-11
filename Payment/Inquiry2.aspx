<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inquiry2.aspx.cs" Inherits="Payment.Inquiry2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction Inquiry Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnInquire" runat="server" Text="Inquire Transaction" OnClick="btnInquire_Click" />
                    <br />
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                    <asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
