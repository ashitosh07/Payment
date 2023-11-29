<!-- Default.aspx -->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payment.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Request</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Payment Request</h2>
            <!-- Add your HTML form elements for payment details here -->
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Payment" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
