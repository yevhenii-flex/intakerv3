using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces.Messaging;

public interface IServiceBusHandler
{
    Task SendMessageAsync<T>(T message);
    Task ReceiveMessagesAsync();
}