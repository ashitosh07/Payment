using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Payment
{
    public partial class Default : Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ///MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi 2000 0 840 en 3000000113 1 1 http://MerchantSite/RedirectPaymentResponsePage 100000000163837020092496 1.0
            //Step 1 : Generate Secure Hash
            String SECRET_KEY = "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi"; 

            SortedDictionary<string, string> parameters = new SortedDictionary<String, String>(StringComparer.Ordinal);

            // getting time in milliseconds
            long transactionId = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
             StringBuilder orderedString = new StringBuilder();
            orderedString.Append(SECRET_KEY);
            // fill required parameters
            //parameters.Add("Amount", "2000");
            orderedString.Append("2000");
            // parameters.Add("Channel", "0");
            orderedString.Append("0");
            //  parameters.Add("CurrencyISOCode", "840");
            orderedString.Append("784");
            // parameters.Add("Language", "en");
            orderedString.Append("en");
            //  parameters.Add("MerchantID", "3000000113");
            orderedString.Append("3000000113");
            // parameters.Add("MessageID", "1");
            orderedString.Append("1");
            //  parameters.Add("PaymentDescription", "Sample+Payment+Description");
            //orderedString.Append("Sample+Payment+Description");
            // parameters.Add("Quantity", "1");
            orderedString.Append("1");
            // fill some optional parameters
            //  parameters.Add("ResponseBackURL", "http://MerchantSite/RedirectPaymentResponsePage");
            orderedString.Append("http://MerchantSite/RedirectPaymentResponsePage");
            // parameters.Add("ThemeID", "theme1");
            orderedString.Append("1000000001");
            //  parameters.Add("TransactionID", transactionId.ToString());
            orderedString.Append(transactionId.ToString());
            // if this URL is configured for the merchant it's not required
            //parameters.Add("Version", "1.0");
            orderedString.Append("1.0");


          

            // Create an Ordered String of The Parameters Dictionary with Secret Key

            //foreach (KeyValuePair<string, string> kv in parameters)
            //{
            //    orderedString.Append(kv.Value);
            //}
            Console.WriteLine("orderdString: " + orderedString);

            // Generate SecureHash with SHA256
            SHA256 sha256;
            byte[] bytes, hash;
            string secureHash = string.Empty;

            bytes = Encoding.UTF8.GetBytes(orderedString.ToString().ToString());
            sha256 = SHA256Managed.Create();
            hash = sha256.ComputeHash(bytes);
            foreach (byte x in hash)
            {
                secureHash += String.Format("{0:x2}", x);
            }

            
            //Step 2 : Post the request to https://sr-test.payone.io/SmartRoutePaymentWeb/SRPayMsgHandler
            this.Context.Items.Add("Amount", "2000");
            this.Context.Items.Add("Channel", "0");
            this.Context.Items.Add("CurrencyISOCode", "784");
            this.Context.Items.Add("Language", "en");
            this.Context.Items.Add("MerchantID", "3000000113");
            this.Context.Items.Add("MessageID", "1");
            //this.Context.Items.Add("PaymentDescription", "Sample+Payment+Description");
            this.Context.Items.Add("Quantity", "1");
            // if this url is configured for the merchant it's not required, else it is required
            this.Context.Items.Add("ResponseBackURL", "http://MerchantSite/RedirectPaymentResponsePage");
            this.Context.Items.Add("ThemeID", "1000000001");
            this.Context.Items.Add("TransactionID", transactionId.ToString());
            // set secure hash in the request
            this.Context.Items.Add("Version", "1.0");
            this.Context.Items.Add("RedirectURL", "https://sr-test.payone.io/SmartRoutePaymentWeb/SRPayMsgHandler");
            this.Context.Items.Add("SecureHash", secureHash);
            Server.Transfer("SubmitRedirectPaymentRequest.aspx", true);

           
        }
    }
}
