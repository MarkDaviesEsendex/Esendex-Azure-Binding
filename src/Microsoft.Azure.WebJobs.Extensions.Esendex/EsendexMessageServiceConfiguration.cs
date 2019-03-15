using com.esendex.sdk.sent;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Microsoft.Azure.WebJobs.Extensions.Esendex
{
    public class EsendexMessageServiceConfiguration : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<EsendexMessagingAttribute>()
                .BindToInput<IMessageDispatchService>(attr =>
                    new EsendexDispatchService(attr.Username, attr.Password, attr.AccountId));

            context.AddBindingRule<EsendexSentServiceAttribute>()
                .BindToInput<IMessageSentService>(attr =>
                    new EsendexSentService(attr.Username, attr.Password, attr.AccountId));
        }
    }
}