using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Payment
{
    public partial class Inquiry2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // You can perform any initialization here if needed
            PerformTransactionInquiry();
        }

        protected void btnInquire_Click(object sender, EventArgs e)
        {
            // Perform the transaction inquiry when the button is clicked
            //PerformTransactionInquiry();
        }

        private void PerformTransactionInquiry()
        {

            string AUTHENTICATION_TOKEN = "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi";
            string secureHash = "";

            // Request Hashing
            StringBuilder requestOrderedString = new StringBuilder();
            requestOrderedString
                .Append(AUTHENTICATION_TOKEN)
                .Append("3000000113") // MerchantID
                .Append("2")          // MessageID
                .Append(63837563553324) // OriginalTransactionID
                .Append("1.0");       // Version

            // Generate SecureHash with SHA256 for Request
            SHA256 sha256Request = SHA256.Create();
            byte[] bytesRequest = Encoding.UTF8.GetBytes(requestOrderedString.ToString());
            byte[] hashRequest = sha256Request.ComputeHash(bytesRequest);

            foreach (byte x in hashRequest)
            {
                secureHash += String.Format("{0:x2}", x);
            }

            // Include generated secure hash in the request
            requestOrderedString.Replace("SecureHash=", "SecureHash=" + secureHash);

            // Transaction Inquiry Code
            StringBuilder requestQuery = new StringBuilder();
            requestQuery
                .Append("MerchantID").Append("=").Append("3000000113").Append("&")
                .Append("MessageID").Append("=").Append("2").Append("&")
                .Append("OriginalTransactionID").Append("=").Append(63837563553324).Append("&")
                .Append("Version").Append("=").Append("1.0").Append("&")
                .Append("SecureHash").Append("=").Append(secureHash).Append("&");

            // Send the request
            string data = requestQuery.ToString();
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            string urlPath = "https://sr-test.payone.io/SmartRoutePaymentWeb/SRMsgHandler";

            string request = urlPath;
            WebRequest webRequest = WebRequest.Create(request);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = dataStream.Length;
            Stream newStream = webRequest.GetRequestStream();

            // Send the data.
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();

            WebResponse webResponse = webRequest.GetResponse();
            String output = null;

            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                output = reader.ReadToEnd();
            }

            // Response Hashing (as in your existing code)
            StringBuilder responseOrderedString = new StringBuilder();
            responseOrderedString.Append(AUTHENTICATION_TOKEN);

            // Create the result dictionary before using it
            SortedDictionary<string, string> result = new SortedDictionary<String, String>(StringComparer.Ordinal);
            NameValueCollection qscoll = HttpUtility.ParseQueryString(output);

            foreach (String kv in qscoll.AllKeys)
            {
                result.Add(kv, qscoll[kv]);
            }

            foreach (KeyValuePair<string, string> kv in result)
            {
                if (!"Response.SecureHash".Equals(kv.Key))
                {
                    if ("Response.StatusDescription".Equals(kv.Key) || "Response.GatewayStatusDescription".Equals(kv.Key))
                    {
                        responseOrderedString.Append(HttpUtility.UrlEncode(kv.Value, System.Text.Encoding.UTF8));
                    }
                    else
                    {
                        responseOrderedString.Append(kv.Value);
                    }
                }
            }

            Console.WriteLine("Response Ordered String is " + responseOrderedString.ToString());

                // Generate SecureHash with SHA256
                SHA256 sha256Generated;
                byte[] bytesGenerated, hashGenerated;

                bytesGenerated = Encoding.UTF8.GetBytes(responseOrderedString.ToString());
                sha256Generated = SHA256.Create(); // Use SHA256.Create() instead of SHA256Managed.Create()
                hashGenerated = sha256Generated.ComputeHash(bytesGenerated);
                String generatedSecureHash = String.Empty;

                foreach (byte x in hashGenerated)
                {
                    generatedSecureHash += String.Format("{0:x2}", x);
                }

                // Get the received secure hash from result SortedDictionary
                String receivedSecureHash = result["Response.SecureHash"];

                if (generatedSecureHash != receivedSecureHash)
                {
                    // If they are not equal then the response shall not be accepted
                    Console.WriteLine("Received Secure Hash does not Equal generated Secure hash");
                }
                else
                {
                    // Complete the Action, get other parameters from the result dictionary, and do your processes
                    // Please refer to The Integration Manual to See The List of The Received Parameters
                    String status = result["Response.StatusDescription"];
                StatusLabel.Text = "Status is: " + status;
                Console.WriteLine("Status is :" + status);
                }

            }
    }
}
