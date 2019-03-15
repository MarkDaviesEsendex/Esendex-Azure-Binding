using Microsoft.Azure.WebJobs.Extensions.Esendex.Attributes;
using Microsoft.Azure.WebJobs.Extensions.Esendex.Models;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.Esendex
{
    public class EsendexExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly IOptions<EsendexSmsOptions> _options;
        internal const string EsendexAccountIdConfigName = "AzureWebJobsEsendexAccountId";
        internal const string EsendexUsernameConfigName = "AzureWebJobsEsendexUsername";
        internal const string EsendexPasswordConfigName = "AzureWebJobsEsendexPassword";

        public EsendexExtensionConfigProvider(IOptions<EsendexSmsOptions> options)
        {
            _options = options;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<EsendexSmsAttribute>()
                .BindToCollector(attr => new EsendexSmsMessageAsyncCollector(_options.Value.Username, _options.Value.Password, _options.Value.AccountId));
        }
    }
}