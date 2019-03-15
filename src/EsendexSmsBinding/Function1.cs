using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.Esendex;

namespace EsendexSmsBinding
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [EsendexMessaging(AccountId = "", Username = "", Password = "")] IMessageDispatchService messageDispatchService,
            [EsendexSentService(AccountId = "", Username = "", Password = "")] IMessageSentService sentService,
            ILogger log)
        {
            var messagingResult = messageDispatchService.SendMessage("", "azure hello");
            var messages = sentService.GetMessages(0, 10);
            return new OkObjectResult(messagingResult);
        }
    }
}
