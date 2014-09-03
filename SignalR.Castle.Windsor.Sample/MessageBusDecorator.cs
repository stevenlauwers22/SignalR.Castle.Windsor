using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Messaging;

namespace SignalR.Castle.Windsor.Sample
{
    public class MessageBusDecorator : IMessageBus
    {
        private readonly IMessageBus _messageBus;

        public MessageBusDecorator(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public Task Publish(Message message)
        {
            Debug.WriteLine("Publish: " + message.Value);
            return _messageBus.Publish(message);
        }

        public IDisposable Subscribe(ISubscriber subscriber, string cursor, Func<MessageResult, Task<bool>> callback, int maxMessages)
        {
            Debug.WriteLine("Subscribe: " + subscriber.Identity);
            return _messageBus.Subscribe(subscriber, cursor, callback, maxMessages);
        }
    }
}