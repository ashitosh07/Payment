<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitRedirectPaymentRequest.aspx.cs" Inherits="Payment.SubmitRedirectPaymentRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="javascript:document.redirectForm.submit();">
    <!-- STEP 3: Create ASP Page send Request -->
    <% 
        // read the parameters from request
        String redirectURL = (String) this.Context.Items["RedirectURL"];
        String amount = (String) this.Context.Items["Amount"];
        String currencyCode = (String) this.Context.Items["CurrencyISOCode"];
        String transactionID = (String) this.Context.Items["TransactionID"];
        String merchantID = (String) this.Context.Items["MerchantID"];
        String language = (String) this.Context.Items["Language"];
        String messageID = (String) this.Context.Items["MessageID"];
        String secureHash = (String) this.Context.Items["SecureHash"];
        String themeID = (String) this.Context.Items["ThemeID"];
        String responseBackURL = (String) this.Context.Items["ResponseBackURL"];
        String channel = (String) this.Context.Items["Channel"];
        String quantity = (String) this.Context.Items["Quantity"];
        String version = (String) this.Context.Items["Version"];
    %>

    <form action="<%=redirectURL%>" method="post" name="redirectForm">
        <input name="MerchantID" type="hidden" value="<%=merchantID%>" />
        <input name="Amount" type="hidden" value="<%=amount%>" />
        <input name="CurrencyISOCode" type="hidden" value="<%=currencyCode%>" />
        <input name="Language" type="hidden" value="<%=language%>" />
        <input name="MessageID" type="hidden" value="<%=messageID%>" />
        <input name="TransactionID" type="hidden" value="<%=transactionID%>" />
        <input name="ThemeID" type="hidden" value="<%=themeID%>" />
        <input name="ResponseBackURL" type="hidden" value="<%=responseBackURL%>" />
        <input name="Quantity" type="hidden" value="<%=quantity%>" />
        <input name="Channel" type="hidden" value="<%=channel%>" />
        <input name="Version" type="hidden" value="<%=version%>" />
        <input name="SecureHash" type="hidden" value="<%=secureHash%>" />
    </form>
</body>
</html>
