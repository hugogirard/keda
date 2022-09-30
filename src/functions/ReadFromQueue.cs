using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Contoso
{
    public class ReadFromQueue
    {
        [FunctionName("ReadFromQueue")]
        public void Run([ServiceBusTrigger("test", Connection = "hgkedasrvbus_SERVICEBUS")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
