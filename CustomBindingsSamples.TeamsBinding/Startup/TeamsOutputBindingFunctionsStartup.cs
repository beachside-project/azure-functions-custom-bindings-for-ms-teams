using CustomBindingsSamples.TeamsBinding.Startup;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(TeamsOutputBindingFunctionsStartup))]

namespace CustomBindingsSamples.TeamsBinding.Startup
{
    public class TeamsOutputBindingFunctionsStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddTeamsOutputBinding();
        }
    }
}