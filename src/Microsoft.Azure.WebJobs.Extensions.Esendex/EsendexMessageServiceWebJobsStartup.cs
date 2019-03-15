using Microsoft.Azure.WebJobs.Extensions.Esendex;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(EsendexMessageServiceWebJobsStartup))]
namespace Microsoft.Azure.WebJobs.Extensions.Esendex
{
    public class EsendexMessageServiceWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<EsendexMessageServiceConfiguration>();
        }
    }
}
