using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Payment
{
    public partial class SubmitRedirectPaymentRequest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Step 3: Create ASP Page to send Request

            // Read parameters from session
            var paymentRequestParameters = (Dictionary<string, string>)Session["SmartRouteParams"];

            // Build the form dynamically
            var formBuilder = new StringBuilder();
            formBuilder.Append("<form action=\"http://SmartrouteURL/SmartRoutePaymentWEB/SRPayMsgHandler\" method=\"post\" name=\"redirectForm\">");

            foreach (var parameter in paymentRequestParameters)
            {
                formBuilder.AppendFormat("<input name=\"{0}\" type=\"hidden\" value=\"{1}\"/>", parameter.Key, parameter.Value);
            }

            formBuilder.Append("</form>");

            // Output the form to the page
            Response.Write(formBuilder.ToString());
        }
    }
}