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
            [EsendexMessaging(AccountId = "", Username = "", Password = "")] IMessageService messageService,
            ILogger log)
        {
            return new OkObjectResult(messageService.SendMessage("", "azure hello"));
        }
    }
}
