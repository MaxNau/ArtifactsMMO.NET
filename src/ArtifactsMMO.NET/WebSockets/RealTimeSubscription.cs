using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Websocket.Client;

namespace ArtifactsMMO.NET.WebSockets
{
    /// <summary>
    /// A subscription represent an active listening channel, ready to receive message from the server, typically through websocket
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RealTimeSubscription<T> : IDisposable where T : IRealTimeMessage
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly IMessageFactoryFactory<T> _messageFactoryFactory;
        private WebsocketClient _clientWebSocket;

        internal RealTimeSubscription(Uri address, JsonSerializerOptions jsonSerializerOptions, IMessageFactoryFactory<T> messageFactoryFactory)
        {
            _jsonSerializerOptions = jsonSerializerOptions;
            _messageFactoryFactory = messageFactoryFactory;
            _clientWebSocket = new WebsocketClient(address);
        }


        internal virtual async Task Start(CancellationToken cancellationToken)
        {
            cancellationToken.Register(Dispose);
            _clientWebSocket.MessageReceived.Subscribe(HandleMessageReceivedInternal);
            await _clientWebSocket.Start();
        }

        private void HandleMessageReceivedInternal(ResponseMessage message)
        {
            T realTimeMessage= _messageFactoryFactory.Deserialize(message.Text, _jsonSerializerOptions);
            HandleMessageReceived(realTimeMessage);
        }

        /// <summary>
        /// Send a message through the websocket, using the internal queue
        /// </summary>
        /// <param name="realTimeMessage"></param>
        protected void SendMessage(IRealTimeMessage realTimeMessage)
        {
            string textMessage = JsonSerializer.Serialize(realTimeMessage, _jsonSerializerOptions);
            _clientWebSocket.Send(textMessage);//The actual send is made on another thread
        }

        /// <summary>
        /// Send a message without going through the queue. Note: .Net doesn't support parallel message.
        /// This allows to wait
        /// </summary>
        /// <param name="realTimeMessage">The message to send</param>
        /// <returns></returns>
        protected async Task SendMessageAsync(IRealTimeMessage realTimeMessage)
        {
            string textMessage = JsonSerializer.Serialize(realTimeMessage, _jsonSerializerOptions);
            await _clientWebSocket.SendInstant(textMessage);//Only one can be made at a time
        }

        /// <summary>
        /// Allow to handle the received message
        /// </summary>
        /// <param name="message">Deserialized message from the server</param>
        protected abstract void HandleMessageReceived(T message);

        /// <inheritdoc />
        public void Dispose()
        {
            _clientWebSocket.Dispose();
        }
    }
}
