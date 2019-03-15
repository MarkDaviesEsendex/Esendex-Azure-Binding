using System;
using com.esendex.sdk;
using com.esendex.sdk.sent;

namespace Microsoft.Azure.WebJobs.Extensions.Esendex
{
    public interface IMessageSentService
    {
        SentMessageCollection GetMessages(int pageNumber, int pageSize);
    }

    public class EsendexSentService : IMessageSentService
    {
        private SentService _sentMessageService;
        private string _accountReference;

        public EsendexSentService(string username, string password, string accountReference)
        {
            _accountReference = accountReference;
            _sentMessageService = new SentService(username, password);
        }

        public SentMessageCollection GetMessages(int pageNumber, int pageSize)
        {
            return _sentMessageService.GetMessages(_accountReference, pageNumber, pageSize);
        }
    }
}