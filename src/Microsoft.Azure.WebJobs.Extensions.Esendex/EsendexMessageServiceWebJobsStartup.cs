using Microsoft.Azure.WebJobs.Extensions.Esendex;
using Microsoft.Azure.WebJobs.Extensions.Esendex.Models;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;

[assembly: WebJobsStartup(typeof(EsendexMessageServiceWebJobsStartup))]
namespace Microsoft.Azure.WebJobs.Extensions.Esendex
{
    public class EsendexMessageServiceWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<EsendexMessageServiceConfiguration>();

            builder.AddExtension<EsendexExtensionConfigProvider>()
                .ConfigureOptions<EsendexSmsOptions>((rootConfig, extensionPath, options) =>
            {
                options.AccountId = rootConfig[EsendexExtensionConfigProvider.EsendexAccountIdConfigName];
                options.Username = rootConfig[EsendexExtensionConfigProvider.EsendexUsernameConfigName];
                options.Password = rootConfig[EsendexExtensionConfigProvider.EsendexPasswordConfigName];
                var section = rootConfig.GetSection(extensionPath);
                section.Bind(options);
            });
        }
    }
}
