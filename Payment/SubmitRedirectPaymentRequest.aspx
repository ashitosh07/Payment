<!-- SubmitRedirectPaymentRequest.aspx -->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitRedirectPaymentRequest.aspx.cs" Inherits="Payment.SubmitRedirectPaymentRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Submitting Payment Request</title>
</head>
<body onload="javascript:document.forms['redirectForm'].submit();">
    <form id="redirectForm" runat="server">
        <!-- Add hidden input fields for payment parameters -->
    </form>
</body>
</html>
