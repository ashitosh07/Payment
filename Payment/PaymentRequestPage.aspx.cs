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
                string secureHashData = "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi";
                string secureHash = SecureHashHelper.GenerateSecureHash(secureHashData);

                Dictionary<string, string> paymentRequestData = new Dictionary<string, string>
                {
                    {"TransactionID", "1440954863817"},
                    {"MerchantID", "3000000113"},
                    {"Amount", "2000"},
                    {"CurrencyISOCode", "840"},
                    {"MessageID", "6"},
                    {"Quantity", "1"},
                    {"Channel", "0"},
                    {"Language", "en"},
                    {"ThemeID", "1000000001"},
                    {"ResponseBackURL", "http://MerchantSite/RedirectPaymentResponsePage"},
                    {"Version", "1.0"},
                    {"RedirectURL", "https://sr-test.payone.io/SmartRoutePaymentWeb/SRPayMsgHandler"},
                    {"SecureHash", "3a2fa566707d0519fbda939bbb818fde896cd2db20abf0425353af60fbfaa0bc"}
                };

                Session["SmartRouteParams"] = paymentRequestData;

                // Redirect to the SubmitRedirectPaymentRequest.aspx page
                Response.Redirect("SubmitRedirectPaymentRequest.aspx", false);
            }
        }
    }
}
