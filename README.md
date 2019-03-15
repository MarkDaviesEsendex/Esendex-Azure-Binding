# Azure Input Binding for Esendex - Unofficial
Input binding for esendex sms sending

*Note* - This is not supported by Esendex and should not be thought of as an official Esendex project or solution

## How to use
```
public static class Function1
{
    [FunctionName("Function1")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        [EsendexMessaging(AccountId = "EsendexAccountReference", Username = "EsendexUserName", Password = "EsendexPassword")] IMessageService messageService,
        ILogger log)
    {
        return new OkObjectResult(messageService.SendMessage("", "azure hello"));
    }
}
```


Currently only supports sms messaging - even though it would be trivial to implement voice messaging