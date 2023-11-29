// PaymentRequestPage.aspx.cs
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Payment
{
    public partial class PaymentRequestPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string secureHashData = "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi";
                //string secureHash = SecureHashHelper.GenerateSecureHash(secureHashData);

                Dictionary<string, string> paymentRequestData = new Dictionary<string, string>
                {
                    {"TransactionID", "63786757657210"},
                    {"MerchantID", "3000000113"},
                    {"Amount", "2000"},
                    {"CurrencyISOCode", "784"},
                    {"MessageID", "6"},
                    {"Quantity", "1"},
                    {"Channel", "0"},
                    {"Language", "en"},
                    {"ThemeID", "1000000001"},
                    {"ResponseBackURL", "http://MerchantSite/RedirectPaymentResponsePage"},
                    {"Version", "1.0"},
                    {"RedirectURL", "https://sr-test.payone.io/SmartRoutePaymentWeb/SRPayMsgHandler"},
                    {"SecureHash", "1df6abd5423f417f6c726ac4c6c7e75ca7799745b72e56f1f65dfdeffebbff0c"}
                };


                Session["SmartRouteParams"] = paymentRequestData;

                // Generate secure hash
                string secureHash = SecureHashHelper.GenerateSecureHash(paymentRequestData);
                paymentRequestData["SecureHash"] = secureHash;

                // Redirect to the SubmitRedirectPaymentRequest.aspx page
                Response.Redirect("SubmitRedirectPaymentRequest.aspx", false);
            }
        }
    }
}
