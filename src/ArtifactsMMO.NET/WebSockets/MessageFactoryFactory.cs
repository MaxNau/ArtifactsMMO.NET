using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ArtifactsMMO.NET.WebSockets
{
    internal abstract class MessageFactoryFactory<T> : IMessageFactoryFactory<T>
        where T : IRealTimeMessage
    {
        private IEnumerable<IMessageFactory<T>> _factories;

        public MessageFactoryFactory()
        {
            RegisterFactories();
        }


        public T Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions)
        {
            IMessageFactory<T> factory = _factories.FirstOrDefault(f => f.IsApplicable(messageText));
            if (factory == null)
            {
                throw new InvalidOperationException("No factory available for the message " + messageText);
            }

            return factory.Deserialize(messageText, jsonSerializerOptions);
        }

        protected abstract IEnumerable<IMessageFactory<T>> GetFactories();

        private void RegisterFactories()
        {
            _factories = GetFactories();

        }
    }
}
