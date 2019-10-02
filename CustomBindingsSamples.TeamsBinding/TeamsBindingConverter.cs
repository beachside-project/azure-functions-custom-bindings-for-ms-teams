using Microsoft.Azure.WebJobs;

namespace CustomBindingsSamples.TeamsBinding
{
    public class TeamsBindingConverter : IConverter<TeamsAttribute, IAsyncCollector<TeamsMessage>>
    {
        private readonly TeamsBindingConfigProvider _configProvider;

        public TeamsBindingConverter(TeamsBindingConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public IAsyncCollector<TeamsMessage> Convert(TeamsAttribute attribute)
        {
            var context = _configProvider.CreateTeamsBindingContext(attribute);
            return new TeamsBindingAsyncCollector(context);
        }
    }
}