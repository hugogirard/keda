using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KedaFunction
{
    public class ReadFromQueue
    {
        [FunctionName("ReadFromQueue")]
        public void Run([ServiceBusTrigger("test", Connection = "SrvBusCnxString")]string myQueueItem,
                         ExecutionContext context,
                        [CosmosDB(databaseName: "keda",
                                  collectionName: "event",
                                  ConnectionStringSetting = "CosmosDBConnection")]out dynamic document,
                         ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            var indentedJsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };

            var executionContextJson = JsonConvert.SerializeObject(context, indentedJsonSerializerSettings);

            document = new { Context = executionContextJson, Message = myQueueItem };
        }
    }
}
