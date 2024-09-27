using Confluent.Kafka;
using Newtonsoft.Json;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();

try
{
    while (true)
    {
        var response = await producer.ProduceAsync(
                        "LiteThinkingTestz",
                        new Message<Null, string>
                        {
                            Value = JsonConvert.SerializeObject(new Order("1234", 10000, "Cali"))
                        });
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}

public record Order(string OrderNumber, int Price, string City);