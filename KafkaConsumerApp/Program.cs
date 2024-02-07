using System;
using Confluent.Kafka;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "test-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe("sqlserver.dbo.SampleTable");

            try
            {
                while (true)
                {
                    var message = consumer.Consume();
                    Console.WriteLine($"Received message: {message.Value}");
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
        }
    }
}
