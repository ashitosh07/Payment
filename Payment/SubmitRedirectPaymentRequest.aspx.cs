// SubmitRedirectPaymentRequest.aspx.cs
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Payment
{
    public partial class SubmitRedirectPaymentRequest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Step 3: Create ASP Page to send Request
            // ... retrieve parameters from Context.Items and add as hidden fields
            //string merchantID = (string)Context.Items["MerchantID"];
            //int amount = (int)Context.Items["Amount"];
            //int currencyCode = (int)Context.Items["CurrencyISOCode"];
            //string messageID = (string)Context.Items["MessageID"];
            //string transactionID = (string)Context.Items["TransactionID"];
            //string secureHash = (string)Context.Items["SecureHash"]; 
            
            
            //string merchantID = "MID0001";
            //int amount = 100;
            //int currencyCode = 840;
            //string messageID = "1";
            //string transactionID = "1440954863817";
            //string secureHash = "e9fbb3c46ec9c7dec2a318edc283bbbea27bc5d7bf7da30f4f2e62b89df74a2e";






            // ... retrieve other parameters

            // Assign the correct redirectURL
            //string redirectURL = "https://sr-test.payone.io/SmartRoutePaymentWeb/SRPayMsgHandler"; // replace with your actual redirect URL

           
            
            //// Output the HTML form with hidden fields
            //Response.Write("<!DOCTYPE html>");
            //Response.Write("<html xmlns='http://www.w3.org/1999/xhtml'>");
            //Response.Write("<head runat='server'><title></title></head>");
            //Response.Write("<body>");

            //// Create the form tag
            //Response.Write("<form action='" + redirectURL + "' method='post' id='redirectForm'>");

            //// Add hidden input fields for payment parameters
            //Response.Write($"<input name='MerchantID' type='hidden' value='{merchantID}'/>");
            //Response.Write($"<input name='Amount' type='hidden' value='{amount}'/>");
            //Response.Write($"<input name='CurrencyISOCode' type='hidden' value='{currencyCode}'/>");
            //Response.Write($"<input name='MessageID' type='hidden' value='{messageID}'/>");
            //Response.Write($"<input name='TransactionID' type='hidden' value='{transactionID}'/>");
            //Response.Write($"<input name='SecureHash' type='hidden' value='{secureHash}'/>");




            //// ... add other hidden fields

            //// You can add more fields as needed

            //// Close the form tag
            //Response.Write("</form>");

            //// Auto-submit the form using JavaScript
            //Response.Write("<script type='text/javascript'>");
            //Response.Write("document.getElementById('redirectForm').submit();");
            //Response.Write("</script>");

            //Response.Write("</body></html>");

            // Important: End the response to prevent further processing
            //Response.End();
        }
     
    }
}

