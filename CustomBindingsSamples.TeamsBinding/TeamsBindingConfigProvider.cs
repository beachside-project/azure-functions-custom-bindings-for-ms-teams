using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CustomBindingsSamples.TeamsBinding
{
    public class TeamsBindingConfigProvider : IExtensionConfigProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public TeamsBindingConfigProvider(IHttpClientFactory httpClientFactory, ILogger logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var rule = context.AddBindingRule<TeamsAttribute>();
            rule.AddValidator(ValidateTeamsAttribute);
            rule.BindToCollector<TeamsBindingOpenType>(typeof(TeamsBindingConverter), this);
        }

        internal TeamsBindingContext CreateTeamsBindingContext(TeamsAttribute attribute)
        {
            return new TeamsBindingContext(_httpClientFactory, _logger)
            {
                ResolvedAttribute = attribute
            };
        }

        internal void ValidateTeamsAttribute(TeamsAttribute attribute, Type pramType)
        {
            if (string.IsNullOrEmpty(attribute.WebhookUrl))
                throw new ArgumentNullException(nameof(attribute.WebhookUrl));
        }

        private class TeamsBindingOpenType : OpenType.Poco
        {
            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>)) return false;
                if (type.FullName == "System.Object") return true;

                return base.IsMatch(type, context);
            }
        }
    }
}