using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using CustomBindingsSamples.TeamsBinding;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class FunctionsHostBuilderExtensionsForTeamsBinding
    {
        public static IFunctionsHostBuilder AddTeamsOutputBinding(this IFunctionsHostBuilder builder)
        {
            if (builder == null) throw new ArgumentException(nameof(builder));

            builder.Services.AddHttpClient();
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IExtensionConfigProvider, TeamsBindingConfigProvider>());

            return builder;
        }
    }
}