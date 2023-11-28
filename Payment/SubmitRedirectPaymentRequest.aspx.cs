// SubmitRedirectPaymentRequest.aspx.cs
using System;
using System.Collections.Generic;
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
                // Build the HTML form dynamically
                var formHtml = new System.Text.StringBuilder();

                formHtml.Append("<form action='" + paymentRequestData["RedirectURL"] + "' method='post' name='redirectForm'>");

                foreach (var entry in paymentRequestData)
                {
                    formHtml.Append("<input name='" + entry.Key + "' type='hidden' value='" + entry.Value + "'/>");
                }

                formHtml.Append("</form>");

                // Render the HTML form and submit it using JavaScript
                Response.Write(formHtml.ToString());
                Response.Write("<script type='text/javascript'>document.forms['redirectForm'].submit();</script>");
            }
        }
    }
}
