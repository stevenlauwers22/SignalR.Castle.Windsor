using System;
using System.Diagnostics;
using System.Text;
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
            Debug.WriteLine("Publish: " + message.Encoding.GetString(message.Value.Array));
            return _messageBus.Publish(message);
        }

        public IDisposable Subscribe(ISubscriber subscriber, string cursor, Func<MessageResult, object, Task<bool>> callback, int maxMessages, object state)
        {
            Debug.WriteLine("Subscribe: " + subscriber.Identity);
            return _messageBus.Subscribe(subscriber, cursor, callback, maxMessages, state);
        }
    }
}