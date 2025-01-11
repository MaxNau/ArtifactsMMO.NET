using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ArtifactsMMO.NET.WebSockets
{
    /// <summary>
    /// Abstract message factory that could be used for different websocket message deserialization
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class MessageFactoryFactory<T> : IMessageFactoryFactory<T>
        where T : IRealTimeMessage
    {
        private IEnumerable<IMessageFactory<T>> _factories;

        /// <summary>
        /// Create a factory of factory
        /// </summary>
        protected MessageFactoryFactory()
        {
            RegisterFactories();
        }

        /// <inheritdoc />
        public T Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions)
        {
            IMessageFactory<T> factory = _factories.FirstOrDefault(f => f.IsApplicable(messageText));
            if (factory == null)
            {
                throw new InvalidOperationException("No factory available for the message " + messageText);
            }

            return factory.Deserialize(messageText, jsonSerializerOptions);
        }

        /// <summary>
        /// Should list all the possible message factories
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<IMessageFactory<T>> GetFactories();

        private void RegisterFactories()
        {
            _factories = GetFactories();

        }
    }
}
