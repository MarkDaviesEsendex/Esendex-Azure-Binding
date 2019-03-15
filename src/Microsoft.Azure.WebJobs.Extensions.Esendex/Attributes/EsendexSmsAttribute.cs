using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.Esendex.Attributes
{
    [Binding, AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public sealed class EsendexSmsAttribute : Attribute
    {
        [AppSetting]
        public string AccountIdSetting { get; set; }

        [AppSetting]
        public string UsernameSetting { get; set; }

        [AppSetting]
        public string PasswordSetting { get; set; }
    }
}