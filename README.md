# Azure Input Binding for Esendex - Unofficial
Input binding for esendex sms sending

*Note* - This is not supported by Esendex and should not be thought of as an official Esendex project or solution

## How to use
Some code examples:

### Sending an sms 
```
public static class Function1
{
    [FunctionName("Function1")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        [EsendexMessaging(AccountId = "EsendexAccountReference", Username = "EsendexUserName", Password = "EsendexPassword")] IMessageService messageService,
        ILogger log)
    {
        var messageResult = messageService.SendMessage("+441234567890", "azure hello");
        return new OkObjectResult(messageResult);
    }
}
```

*Note*: Currently only supports sms messaging - even though it would be trivial to implement voice messaging

## Retrieving sms information

```
[FunctionName("Function1")]
public static IActionResult Run(
    [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
    [EsendexSentService(AccountId = "EsendexAccountReference", Username = "EsendexUserName", Password = "EsendexPassword")] IMessageSentService sentService,
    ILogger log)
{
    var messages = sentService.GetMessages(0, 10);
    return new OkObjectResult(messages);
}
```

## Output binding 

You can specify a output binding like so:
```
[FunctionName("Function1")]
[return: EsendexSms(AccountIdSetting = "AzureWebJobsEsendexAccountId", UsernameSetting = "AzureWebJobsEsendexUsername", PasswordSetting = "AzureWebJobsEsendexPassword")]
public static EsendexSms Run2(
    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "message/send2")] HttpRequestMessage req,
    ILogger log)
{
    return new EsendexSms { Body = "hello", To = "+441234567890" };
}
```

In the `EsendexSms` attribute you can specify the settings to read the accountid, username and password, these default to the following:
* AzureWebJobsEsendexAccountId
* AzureWebJobsEsendexUsername
* AzureWebJobsEsendexPassword