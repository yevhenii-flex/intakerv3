using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using TaskManagement.Domain.Interfaces.Messaging;

namespace TaskManagement.Infrastructure.Messaging;

public class ServiceBusHandler : IServiceBusHandler
{
    private readonly ServiceBusClient _client;
    private readonly ServiceBusProcessor _processor;

    public ServiceBusHandler(ServiceBusClient client, string queueName)
    {
        _client = client;
        _processor = _client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
    }

    public async Task SendMessageAsync<T>(T message)
    {
        var sender = _client.CreateSender(_processor.EntityPath);
        var messageBody = JsonSerializer.Serialize(message);
        var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));
        await sender.SendMessageAsync(serviceBusMessage);
    }

    public async Task ReceiveMessagesAsync()
    {
        _processor.ProcessMessageAsync += async args =>
        {
            var messageBody = Encoding.UTF8.GetString(args.Message.Body);
            
            await args.CompleteMessageAsync(args.Message);
        };

        _processor.ProcessErrorAsync += args =>
        {
            return Task.CompletedTask;
        };

        await _processor.StartProcessingAsync();
    }
}