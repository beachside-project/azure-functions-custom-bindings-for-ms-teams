using System;
using Microsoft.Azure.WebJobs.Description;

namespace CustomBindingsSamples.TeamsBinding
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class TeamsAttribute : Attribute
    {
        public TeamsAttribute()
        {
        }

        public TeamsAttribute(string webhookUrl)
        {
            WebhookUrl = webhookUrl;
        }

        [AutoResolve]
        public string WebhookUrl { get; set; }
    }
}
