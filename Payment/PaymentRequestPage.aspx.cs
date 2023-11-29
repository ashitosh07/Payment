using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Payment
{
    public partial class PaymentRequestPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Step 1: Generate Secure Hash
            string secureHash = GenerateSecureHash("1440954863817",
                                                    "3000000113",
                                                    "2000",
                                                    "784",
                                                    "6",
                                                    "1",
                                                    "0",
                                                    "en",
                                                    "1000000001",
                                                    "http://MerchantSite/RedirectPaymentResponsePage",
                                                    "1.0",
                                                    "https://sr-test.payone.io/SmartRoutePaymentWeb/SRPayMsgHandler",
                                                    "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi");

            // Step 2: Prepare Payment Request
            var paymentRequestParameters = new Dictionary<string, string>
        {
                  {"TransactionID", "1440954863817"},
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
                  { "SecureHash", secureHash }
            // Add other parameters as needed
        };

            // Store parameters in session
            Session["SmartRouteParams"] = paymentRequestParameters;

            // Redirect to the SubmitRedirectPaymentRequest.aspx page
            Response.Redirect("SubmitRedirectPaymentRequest.aspx");
        }

        private string GenerateSecureHash(params string[] values)
        {
            using (var sha256 = SHA256.Create())
            {
                // Concatenate all values
                string concatenatedValues = string.Concat(values);

                // Convert to bytes and compute hash
                byte[] bytes = Encoding.UTF8.GetBytes(concatenatedValues);
                byte[] hash = sha256.ComputeHash(bytes);

                // Convert hash to a hexadecimal string
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

    }
}