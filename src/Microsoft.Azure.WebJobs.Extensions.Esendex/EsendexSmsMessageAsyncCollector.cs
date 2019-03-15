using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using com.esendex.sdk.messaging;
using Microsoft.Azure.WebJobs.Extensions.Esendex.Models;

namespace Microsoft.Azure.WebJobs.Extensions.Esendex
{
    public class EsendexSmsMessageAsyncCollector : IAsyncCollector<EsendexSms>
    {
        private readonly string _accountId;
        private readonly string _username;
        private readonly string _password;
        private readonly ConcurrentQueue<EsendexSms> _messages = new ConcurrentQueue<EsendexSms>();

        public EsendexSmsMessageAsyncCollector(string username, string password, string accountId)
        {
            _password = password;
            _username = username;
            _accountId = accountId;
        }

        public Task AddAsync(EsendexSms item, CancellationToken cancellationToken = new CancellationToken())
        {
            _messages.Enqueue(item);
            return Task.CompletedTask;
        }

        public Task FlushAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var messageService = new MessagingService(_username, _password);

            while (_messages.TryDequeue(out var message))
            {
                // this create will initiate the send operation
                messageService.SendMessage(new SmsMessage(message.To, message.Body, _accountId));
            }
            return Task.CompletedTask;
        }
    }
}