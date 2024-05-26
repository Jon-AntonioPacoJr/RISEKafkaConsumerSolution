using Confluent.Kafka;
using RISEProject.Application.Services;
using System;

namespace RISEProject.Infrastructure.KafkaConsumer
{
    public class KafkaConsumerService
    {
        private readonly MessageService _messageService;
        private readonly ConsumerConfig _config;
        private readonly string _topic;

        public KafkaConsumerService(MessageService messageService, string bootstrapServers, string topic, string groupId)
        {
            _messageService = messageService;
            _topic = topic;
            _config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        public void StartConsuming()
        {
            using (var consumer = new ConsumerBuilder<Ignore, string>(_config).Build())
            {
                consumer.Subscribe(_topic);

                try
                {
                    while (true)
                    {
                        var consumeResult = consumer.Consume();
                        _messageService.HandleMessage(consumeResult.Message.Value);
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            }
        }
    }
}
