
using ServicioAdministracionSedes.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ServicioAdministracionSedes.Messages{
   public class RabbitMqMessagePublisher : IMessagePublisher
    {
        private readonly ConnectionFactory _factory;

        public RabbitMqMessagePublisher(string rabbitMqConnectionString)
        {
            _factory = new ConnectionFactory() { Uri = new Uri(rabbitMqConnectionString) };
        }

        public async Task Publish(string queueName, SedeMessage sede)
        {
            // Usar CreateConnectionAsync() para obtener la conexión de manera asincrónica
            using var connection = await _factory.CreateConnectionAsync();
            
            // Crear el canal con CreateModel()
            using var channel = connection.CreateModel();

            // Configurar la cola
            channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            // Serializar el mensaje SedeMessage a JSON
            var message = JsonSerializer.Serialize(sede);
            var body = Encoding.UTF8.GetBytes(message);

            // Publicar el mensaje en la cola
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }
    }
    
}