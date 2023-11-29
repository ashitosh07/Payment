using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Payment
{
    public partial class SubmitRedirectPaymentRequest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Read parameters from the session
            var paymentRequestData = (Dictionary<string, string>)Session["SmartRouteParams"];

            if (paymentRequestData != null)
            {
                // Step 3: Create ASP Page to send Request
                string redirectURL = paymentRequestData["RedirectURL"];

                // Build the HTML form dynamically
                var formHtml = new System.Text.StringBuilder();

                formHtml.Append("<form action='" + redirectURL + "' method='post' name='redirectForm'>");

                foreach (var entry in paymentRequestData)
                {
                    formHtml.Append("<input name='" + entry.Key + "' type='hidden' value='" + entry.Value + "'/>");
                }

                formHtml.Append("</form>");

                // Render the HTML form and submit it using JavaScript
                Response.Write(formHtml.ToString());
                Response.Write("<script type='text/javascript'>document.forms['redirectForm'].submit();</script>");

                // Verify the received secure hash
                VerifySecureHash(paymentRequestData);
            }
        }

        private void VerifySecureHash(Dictionary<string, string> paymentData)
        {
            // Get the received secure hash from the result dictionary
            string receivedSecureHash = paymentData["SecureHash"];

            // Your authentication token
            string authenticationToken = "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi";

            // Store all response parameters to generate Response Secure Hash
            SortedDictionary<string, string> responseParameters = new SortedDictionary<string, string>(StringComparer.Ordinal);

            // Get All Request Parameters
            foreach (string parameterName in Request.Form.Keys)
            {
                if (!"Response.SecureHash".Equals(parameterName))
                {
                    if ("Response.StatusDescription".Equals(parameterName) || "Response.GatewayStatusDescription".Equals(parameterName))
                    {
                        responseParameters.Add(parameterName, HttpUtility.UrlEncode(Request.Form[parameterName], System.Text.Encoding.UTF8));
                    }
                    else
                    {
                        responseParameters.Add(parameterName, Request.Form[parameterName]);
                    }
                }
            }

            // Order the parameters to generate secure hash
            StringBuilder responseOrderedString = new StringBuilder();
            responseOrderedString.Append(authenticationToken);
            foreach (var kv in responseParameters)
            {
                responseOrderedString.Append(kv.Value);
            }

            // Generate SecureHash with SHA256
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256Managed.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(responseOrderedString.ToString());
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder generatedSecureHash = new StringBuilder();
                foreach (byte x in hash)
                {
                    generatedSecureHash.AppendFormat("{0:x2}", x);
                }

                // Compare generated secure hash with the received one
                if (receivedSecureHash != generatedSecureHash.ToString())
                {
                    // If they are not equal, the response shall not be accepted
                    Console.WriteLine("Received Secure Hash does not equal generated Secure Hash");
                }
                else
                {
                    // Complete the action, get other parameters from the result dictionary, and perform your processes
                    // Please refer to The Integration Manual to see the list of the received parameters
                    string status = Request.Form["Response.Status"];
                    Console.WriteLine("Status is: " + status);
                }
            }
        }
    }
}
