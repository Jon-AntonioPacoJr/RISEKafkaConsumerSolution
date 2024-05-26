using RISEProject.Domain.Interfaces;
using System;

namespace RISEProject.Infrastructure.KafkaProcessor
{
    public class KafkaMessageProcessor : IMessageProcessor
    {
        public void Process(Domain.Entities.Message message)
        {
            Console.WriteLine($"Processing with ID: {message.Id}, Content: {message.Content}");
        }
    }
}
