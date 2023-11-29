using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Payment
{
    public partial class Default : Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Step 1: Generate Secure Hash
            string SECRET_KEY = "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi";
            SortedDictionary<string, string> parameters = new SortedDictionary<string, string>(StringComparer.Ordinal);

            // Populate parameters for secure hash generation
            parameters.Add("TransactionID", "12345678901234567890");
            parameters.Add("MerchantID", "3000000113");
            parameters.Add("Amount", "2000");
            parameters.Add("CurrencyISOCode", "840");
            parameters.Add("MessageID", "1");
            parameters.Add("Quantity", "1");
            parameters.Add("Channel", "0");
            parameters.Add("Language", "en");
            parameters.Add("ThemeID", "1000000001");
            parameters.Add("ResponseBackURL", "http://MerchantSite/RedirectPaymentResponsePage");
            parameters.Add("Version", "1.0");

            // Complete implementation of secure hash generation
            string secureHash = SecureHashGenerator.GenerateSecureHash(SECRET_KEY, parameters);

            // Step 2: Prepare Payment Request and Redirect
            // Populate parameters for payment request
            Context.Items.Add("TransactionID", "12345678901234567890");
            Context.Items.Add("MerchantID", "3000000113");
            Context.Items.Add("Amount", "2000");
            Context.Items.Add("CurrencyISOCode", "840");
            Context.Items.Add("MessageID", "1");
            Context.Items.Add("Quantity", "1");
            Context.Items.Add("Channel", "0");
            Context.Items.Add("Language", "en");
            Context.Items.Add("ThemeID", "1000000001");
            Context.Items.Add("ResponseBackURL", "http://MerchantSite/RedirectPaymentResponsePage");
            Context.Items.Add("Version", "1.0");
            Context.Items.Add("SecureHash", secureHash);


            Server.Transfer("SubmitRedirectPaymentRequest.aspx", true);
        }
    }
}
