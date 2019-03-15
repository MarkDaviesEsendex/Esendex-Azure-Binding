
using com.esendex.sdk;
using com.esendex.sdk.messaging;

namespace Microsoft.Azure.WebJobs.Extensions.Esendex
{
    public interface IMessageService
    {
        MessagingResult SendMessage(string recipients, string body);
    }

    public class EsendexMessageService : IMessageService
    {
        private readonly MessagingService _messagingService;
        private readonly string _accountReference;

        public EsendexMessageService(string username, string password, string accountReference)
        {
            _accountReference = accountReference;
            _messagingService = new MessagingService(true, new EsendexCredentials(username, password));
        }

        public MessagingResult SendMessage(string recipients, string body)
        {
            return _messagingService.SendMessage(new SmsMessage(recipients, body, _accountReference));
        }
    }
}