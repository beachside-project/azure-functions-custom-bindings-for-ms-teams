using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomBindingsSamples.TeamsBinding
{
    public class TeamsBindingContext
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public TeamsAttribute ResolvedAttribute { get; set; }

        public TeamsBindingContext(IHttpClientFactory httpClientFactory, ILogger logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
        }

        public async Task SendTeamsMessageAsync(TeamsMessage teamsMessage)
        {
            try
            {
                var content = new StringContent(teamsMessage.ToJson());
                var response = await _httpClient.PostAsync(ResolvedAttribute.WebhookUrl, content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                // TODO error handling
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}