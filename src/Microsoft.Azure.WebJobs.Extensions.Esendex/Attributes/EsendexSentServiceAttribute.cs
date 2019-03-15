using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.Esendex.Attributes
{
    [Binding, AttributeUsage(AttributeTargets.Parameter)]
    public class EsendexSentServiceAttribute : Attribute
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountId { get; set; }
    }
}