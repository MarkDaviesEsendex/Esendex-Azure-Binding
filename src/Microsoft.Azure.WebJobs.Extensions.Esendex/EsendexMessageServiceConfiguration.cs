using Microsoft.Azure.WebJobs.Host.Config;

namespace Microsoft.Azure.WebJobs.Extensions.Esendex
{
    public class EsendexMessageServiceConfiguration : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<EsendexMessagingAttribute>()
                .BindToInput<IMessageService>(attr =>
                    new EsendexMessageService(attr.Username, attr.Password, attr.AccountId));
        }
    }
}