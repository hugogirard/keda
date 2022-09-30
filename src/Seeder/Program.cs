using Azure.Messaging.ServiceBus;

const string QUEUE_NAME = "test";
string SrvBusCnxString = "";

int iteration = int.Parse(Environment.GetCommandLineArgs()[1]);

try
{
    await using var client = new ServiceBusClient(SrvBusCnxString);
    
    // create the sender
    ServiceBusSender sender = client.CreateSender(QUEUE_NAME);

    Console.WriteLine("Sending message");

    for (int i = 0; i < iteration; i++)
    {
        await sender.SendMessageAsync(new ServiceBusMessage($"Message iteration {i}"));
    }
    
    Console.WriteLine("Done");
}
catch (System.Exception ex)
{    
    Console.WriteLine(ex.Message);
}