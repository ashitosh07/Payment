// SubmitRedirectPaymentRequest.aspx.cs
using System;
using System.Web.UI;

namespace Payment
{
    public partial class SubmitRedirectPaymentRequest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Step 3: Create ASP Page to send Request
            // ... retrieve parameters from Context.Items and add as hidden fields
            string merchantID = (string)Context.Items["MerchantID"];
            string amount = (string)Context.Items["Amount"];
            string currencyCode = (string)Context.Items["CurrencyISOCode"];
            // ... retrieve other parameters

            // Assign the correct redirectURL
            string redirectURL = "https://sr-test.payone.io/SmartRoutePaymentWeb/SRPayMsgHandler"; // replace with your actual redirect URL

            // Output the HTML form with hidden fields
            Response.Write("<!DOCTYPE html>");
            Response.Write("<html xmlns='http://www.w3.org/1999/xhtml'>");
            Response.Write("<head runat='server'><title></title></head>");
            Response.Write("<body>");

            // Create the form tag
            Response.Write("<form action='" + redirectURL + "' method='post' id='redirectForm'>");

            // Add hidden input fields for payment parameters
            Response.Write($"<input name='MerchantID' type='hidden' value='{merchantID}'/>");
            Response.Write($"<input name='Amount' type='hidden' value='{amount}'/>");
            Response.Write($"<input name='CurrencyISOCode' type='hidden' value='{currencyCode}'/>");
            // ... add other hidden fields

            // You can add more fields as needed

            // Close the form tag
            Response.Write("</form>");

            // Auto-submit the form using JavaScript
            Response.Write("<script type='text/javascript'>");
            Response.Write("document.getElementById('redirectForm').submit();");
            Response.Write("</script>");

            Response.Write("</body></html>");

            // Important: End the response to prevent further processing
            Response.End();
        }
    }
}

