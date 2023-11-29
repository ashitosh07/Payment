// PaymentResponsePage.aspx.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Payment
{
    public partial class PaymentResponsePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Step 4: Handle Payment Response
            string AUTHENTICATION_TOKEN = "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi"; // Use Yours, Please Store Your Authentication Token in a safe place (e.g., database)

            // Store all response parameters to generate Response Secure Hash
            SortedDictionary<string, string> responseParameters = new SortedDictionary<string, string>(StringComparer.Ordinal);

            // Get all request parameters
            foreach (string key in Request.Form.Keys)
            {
                if (!"Response.SecureHash".Equals(key))
                {
                    if ("Response.StatusDescription".Equals(key) || "Response.GatewayStatusDescription".Equals(key))
                    {
                        responseParameters.Add(key, HttpUtility.UrlEncode(Request.Form[key], Encoding.UTF8));
                    }
                    else
                    {
                        responseParameters.Add(key, Request.Form[key]);
                    }
                }
            }

            // Now that we have the dictionary, order it to generate secure hash and compare it with the received one
            StringBuilder responseOrderedString = new StringBuilder();
            responseOrderedString.Append(AUTHENTICATION_TOKEN);
            foreach (KeyValuePair<string, string> kv in responseParameters)
            {
                responseOrderedString.Append(kv.Value);
            }

            // Generate SecureHash with SHA256
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(responseOrderedString.ToString());
            byte[] hash = sha256.ComputeHash(bytes);
            string generatedSecureHash = string.Join("", hash.Select(x => x.ToString("x2")));

            // Get the received secure hash from the result dictionary
            string receivedSecureHash = Request.Form["Response.SecureHash"];

            if (receivedSecureHash != generatedSecureHash)
            {
                // If they are not equal then the response shall not be accepted
                Console.WriteLine("Received Secure Hash does not Equal generated Secure hash");
            }
            else
            {
                // Complete the Action: get other parameters from the result dictionary and perform your processes
                // Please refer to The Integration Manual to see the list of received parameters
                string status = Request.Form["Response.Status"];
                Console.WriteLine("Status is: " + status);
            }
        }
    }
}
