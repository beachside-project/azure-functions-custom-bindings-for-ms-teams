using Microsoft.Azure.WebJobs;
using System.Threading;
using System.Threading.Tasks;

namespace CustomBindingsSamples.TeamsBinding
{
    public class TeamsBindingAsyncCollector : IAsyncCollector<TeamsMessage>
    {
        private readonly TeamsBindingContext _teamsBindingContext;

        public TeamsBindingAsyncCollector(TeamsBindingContext teamsBindingContext)
        {
            _teamsBindingContext = teamsBindingContext;
        }

        public async Task AddAsync(TeamsMessage teamsMessage, CancellationToken cancellationToken = new CancellationToken())
        {
            await _teamsBindingContext.SendTeamsMessageAsync(teamsMessage);
        }

        public Task FlushAsync(CancellationToken cancellationToken = new CancellationToken()) => Task.CompletedTask;
    }
}