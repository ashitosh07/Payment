<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmitRedirectPaymentRequest.aspx.cs" Inherits="Payment.SubmitRedirectPaymentRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="javascript:document.redirectForm.submit();">
    <!-- STEP 3: Create ASP Page send Request -->
  <%--  this.Context.Items.Add("Amount", "2000");
this.Context.Items.Add("Channel", "0");
this.Context.Items.Add("CurrencyISOCode", "840");
this.Context.Items.Add("Language", "en");
this.Context.Items.Add("MerchantID", "3000000113");
this.Context.Items.Add("MessageID", "1");
//this.Context.Items.Add("PaymentDescription", "Sample+Payment+Description");
this.Context.Items.Add("Quantity", "1");
// if this url is configured for the merchant it's not required, else it is required
this.Context.Items.Add("ResponseBackURL", "http://MerchantSite/RedirectPaymentResponsePage");
this.Context.Items.Add("ThemeID", "theme1");
this.Context.Items.Add("TransactionID", transactionId.ToString());
// set secure hash in the request
this.Context.Items.Add("Version", "1.0");
this.Context.Items.Add("RedirectURL", "https://sr-test.payone.io/SmartRoutePaymentWeb/SRPayMsgHandler");--%>





    <%    
        String amount = (String)this.Context.Items["Amount"];
        String channel = (String)this.Context.Items["Channel"];
        String currencyCode = (String)this.Context.Items["CurrencyISOCode"];
        String language = (String)this.Context.Items["Language"];
        String merchantID = (String)this.Context.Items["MerchantID"];
        String messageID = (String)this.Context.Items["MessageID"];
        String quantity = (String)this.Context.Items["Quantity"]; 
        String responseBackURL = (String)this.Context.Items["ResponseBackURL"]; 
        String themeID = (String)this.Context.Items["ThemeID"];
        String transactionID = (String)this.Context.Items["TransactionID"];
        String version = (String)this.Context.Items["Version"];
        String secureHash = (String)this.Context.Items["SecureHash"];
        String redirectURL = (String)this.Context.Items["RedirectURL"];
    %>
    <form action="<%=redirectURL%>" method="post" name="redirectForm">
        <input name="Amount" type="hidden" value="<%=amount%>" />
        <input name="Channel" type="hidden" value="<%=channel%>" />
        <input name="CurrencyISOCode" type="hidden" value="<%=currencyCode%>" />
        <input name="Language" type="hidden" value="<%=language%>" />
        <input name="MerchantID" type="hidden" value="<%=merchantID%>" />
        <input name="MessageID" type="hidden" value="<%=messageID%>" />
        <input name="Quantity" type="hidden" value="<%=quantity%>" />
        <input name="ResponseBackURL" type="hidden" value="<%=responseBackURL%>" />
        <input name="ThemeID" type="hidden" value="<%=themeID%>" />
        <input name="TransactionID" type="hidden" value="<%=transactionID%>" />
        <input name="Version" type="hidden" value="<%=version%>" />
        <input name="SecureHash" type="hidden" value="<%=secureHash%>" />
    </form>
</body>
</html>
