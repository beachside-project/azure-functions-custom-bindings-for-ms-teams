using System;
using System.Collections.Generic;
using System.Text;

namespace CustomBindingsSamples.TeamsBinding
{
    public class TeamsMessageHelper
    {
        private static string BaseJson = "{{\"title\":\"{0}\",\"text\":\"{1}\",\"themeColor\":\"{2}\",\"@context\":\"https://schema.org/extensions\",\"@type\":\"MessageCard\",\"potentialAction\":[{{\"@type\":\"OpenUri\",\"name\":\"View More\",\"targets\":[{{\"os\":\"default\",\"uri\":\"{3}\"}}]}}]}}\n";

        public static string GetJson(string title, string text, string linkUri, string themeColor = "0072C6")
        {
            // TODO: validation
            return string.Format(BaseJson, title, text, themeColor, linkUri);
        }
    }

}
