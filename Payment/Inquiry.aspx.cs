using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payment
{
    public partial class Inquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AUTHENTICATION_TOKEN = "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi";
            StringBuilder requestQuery = new StringBuilder();
            requestQuery
                .Append("OriginalTransactionID").Append("=").Append(63837476455845).Append("&")
                .Append("MerchantID").Append("=").Append("3000000113").Append("&")
                .Append("MessageID").Append("=").Append("2").Append("&")
                .Append("Version").Append("=").Append("1.0").Append("&")
                .Append("SecureHash").Append("=").Append("secureHashValue").Append("&");

            // Send the request
            string data = requestQuery.ToString().ToString();
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

            // Output the response
            Console.WriteLine(output);

            // This string is formatted as a "Query String" - name=value&name2=value2.......
            String outputString = output.ToString();

            // To read the output string you might want to split it
            // on '&' to get pairs then on '=' to get name and value
            // and for a better and ease on verifying secure hash you should put them in a SortedDictionary
            SortedDictionary<string, string> result = new SortedDictionary<String, String>(StringComparer.Ordinal);
            NameValueCollection qscoll = HttpUtility.ParseQueryString(output);
            foreach (String kv in qscoll.AllKeys)
            {
                result.Add(kv, qscoll[kv]);
            }


            // Now that we have the sorted dictionary, order it to generate a secure hash and compare it with the received one
            StringBuilder responseOrderedString = new StringBuilder();
            responseOrderedString.Append(AUTHENTICATION_TOKEN);
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
            sha256Generated = SHA256Managed.Create();
            hashGenerated = sha256Generated.ComputeHash(bytesGenerated);
            String generatedSecureHash = String.Empty;
            foreach (byte x in hashGenerated)
            {
                generatedSecureHash += String.Format("{0:x2}", x);
            }

            // Get the received secure hash from the result SortedDictionary
            String receivedSecureHash = result["Response.SecureHash"];
            if (generatedSecureHash.ToString() != receivedSecureHash)
            {
                // If they are not equal then the response shall not be accepted
                Console.WriteLine("Received Secure Hash does not Equal generated Secure hash");
            }
            else
            {
                // Complete the Action, get other parameters from the result dictionary, and do your processes
                // Please refer to The Integration Manual to See The List of The Received Parameters
                //String status = result["Response.Status"];
                //Console.WriteLine("Status is: " + status);
            }


        }
    }
}