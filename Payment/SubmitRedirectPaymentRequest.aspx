<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitRedirectPaymentRequest.aspx.cs" Inherits="Payment.SubmitRedirectPaymentRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="javascript:document.redirectForm.submit();">
 
    <%
        // Read the parameters from the query string
        String redirectURL = Request.QueryString["RedirectURL"];
        String amount = Request.QueryString["Amount"];
        String currencyCode = Request.QueryString["CurrencyISOCode"];
        String transactionID = Request.QueryString["TransactionID"];
        String merchantID = Request.QueryString["MerchantID"];
        String language = Request.QueryString["Language"];
        String messageID = Request.QueryString["MessageID"];
        String secureHash = Request.QueryString["SecureHash"];
        String themeID = Request.QueryString["ThemeID"];
        String responseBackURL = Request.QueryString["ResponseBackURL"];
        String channel = Request.QueryString["Channel"];
        String quantity = Request.QueryString["Quantity"];
        String version = Request.QueryString["Version"];
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
</html>--%>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitRedirectPaymentRequest.aspx.cs" Inherits="Payment.SubmitRedirectPaymentRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="javascript:document.redirectForm.submit();">
  
    <%
      
        String redirectURL = "https://sr-test.payone.io/SmartRoutePaymentWeb/SRPayMsgHandler";
        String amount = "100";
        String currencyCode = "840";
        String transactionID = "1440954863817";
        String merchantID = "3000000113";
        String language = "en";
        String messageID = "1";
        String secureHash = "e41e37f325630b4987815632db19e269552e4f5b935ba50ca491fd0e03d5a0b3";
        String themeID = "Theme1";
        String responseBackURL = "http://MerchantSite/RedirectPaymentResponsePage";
        String channel = "0";
        String quantity = "1";
        String version = "1.0";
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
