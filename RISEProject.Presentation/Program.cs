using RISEProject.Application.Services;
using RISEProject.Domain.Interfaces;
using RISEProject.Infrastructure.KafkaConsumer;
using RISEProject.Infrastructure.KafkaProcessor;

namespace RISEProject.Presentation
{
    static class Program
    {
        static void Main(string[] args)
        {
            IMessageProcessor messageProcessor = new KafkaMessageProcessor();
            MessageService messageService = new MessageService(messageProcessor);
            KafkaConsumerService kafkaConsumerService = new KafkaConsumerService(
                messageService,
                "localhost:9092",
                "ee-topic-name",
                "consumer-group"
            );

            kafkaConsumerService.StartConsuming();
        }
    }
}
