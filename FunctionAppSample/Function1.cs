using CustomBindingsSamples.TeamsBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FunctionAppSample
{
    public class Function1
    {
        [FunctionName("Function1")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] TeamsMessage teamsMessage,
            [Teams("%TeamsWebhookUri%")] IAsyncCollector<TeamsMessage> asyncCollector,
            ILogger log)
        {
            await asyncCollector.AddAsync(teamsMessage);
        }
    }
}