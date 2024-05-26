using RISEProject.Domain.Entities;
using RISEProject.Domain.Interfaces;
using System;

namespace RISEProject.Application.Services
{
    public class MessageService
    {
        private readonly IMessageProcessor _messageProcessor;

        public MessageService(IMessageProcessor messageProcessor)
        {
            _messageProcessor = messageProcessor;
        }

        public void HandleMessage(string messageContent)
        {
            var message = new Message(Guid.NewGuid().ToString(), messageContent);
            _messageProcessor.Process(message);
        }
    }
}
