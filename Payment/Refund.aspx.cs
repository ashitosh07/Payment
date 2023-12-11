using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Util;


namespace Payment
{
    public partial class WebFormRefund : Page
    {
        private const string SR_URL = "https://sr-test.payone.io/SmartRoutePaymentWeb/SRMsgHandler";
        private const string AUTHENTICATION_TOKEN = "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Generate a unique transaction ID (e.g., using a GUID)
                long transactionId = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);

                // Request Hashing
                StringBuilder requestOrderedString = new StringBuilder(AUTHENTICATION_TOKEN);
                requestOrderedString
                    .Append(transactionId)
                    .Append("3000000113")
                    .Append("4")
                    .Append("2000")
                    .Append(6383756355332)
                    .Append("784")
                    .Append("1.0");

                // Generate SecureHash with SHA256 for Request
                using (SHA256 sha256Request = SHA256.Create())
                {
                    byte[] bytesRequest = Encoding.UTF8.GetBytes(requestOrderedString.ToString());
                    byte[] hashRequest = sha256Request.ComputeHash(bytesRequest);

                    string secureHash = string.Join("", hashRequest.Select(x => x.ToString("x2")));

                    // Include generated secure hash in the request
                    requestOrderedString.Replace("SecureHash=", "SecureHash=" + secureHash);

                    // Refund Request Building
                    StringBuilder requestQuery = new StringBuilder();
                    requestQuery
                              .Append("TransactionID").Append("=").Append(transactionId).Append("&")
                              .Append("MerchantID").Append("=").Append("3000000113").Append("&")
                              .Append("MessageID").Append("=").Append("4").Append("&")
                              .Append("Amount").Append("=").Append("2000").Append("&")
                              .Append("OriginalTransactionID").Append("=").Append(6383756355332).Append("&")
                              .Append("CurrencyISOCode").Append("=").Append("784").Append("&")
                              .Append("Version").Append("=").Append("1.0").Append("&")
                              .Append("SecureHash").Append("=").Append(secureHash).Append("&");

                    // Send the refund request
                    string data = requestQuery.ToString();

                    using (var webClient = new WebClient())
                    {
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        byte[] responseBytes = webClient.UploadData(SR_URL, "POST", Encoding.UTF8.GetBytes(data));

                        // Handling the Refund Response
                        string response = Encoding.UTF8.GetString(responseBytes);

                        // Parsing and Verifying the Refund Response
                        NameValueCollection result = HttpUtility.ParseQueryString(response);
                        StringBuilder responseOrderedString = new StringBuilder(AUTHENTICATION_TOKEN);

                        foreach (string key in result.AllKeys)
                        {
                            if (!"Response.SecureHash".Equals(key))
                            {
                                if ("Response.StatusDescription".Equals(key) || "Response.GatewayStatusDescription".Equals(key))
                                {
                                    responseOrderedString.Append(HttpUtility.UrlEncode(result[key], Encoding.UTF8));
                                }
                                else
                                {
                                    responseOrderedString.Append(result[key]);
                                }
                            }
                        }

                        // Generate SecureHash with SHA256
                        using (SHA256 sha256 = SHA256.Create())
                        {
                            byte[] bytesGenerated = Encoding.UTF8.GetBytes(responseOrderedString.ToString());
                            byte[] hashGenerated = sha256.ComputeHash(bytesGenerated);

                            string generatedSecureHash = string.Join("", hashGenerated.Select(x => x.ToString("x2")));

                            // Get the received secure hash from the result
                            string receivedSecureHash = result["Response.SecureHash"];

                            if (generatedSecureHash != receivedSecureHash)
                            {
                                // If they are not equal, the response shall not be accepted
                                //StatusLabel.Text = "Received Secure Hash does not equal generated Secure hash";
                            }
                            else
                            {
                                // Complete the action, get other parameters from the result dictionary and do your processes
                                // Please refer to the Integration Manual to see the list of received parameters
                                string status = result["Response.Status"];
                                //StatusLabel.Text = "Status is: " + status;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and inform the user about the error
                //StatusLabel.Text = "Error: " + ex.Message;
            }
        }
    }
}

