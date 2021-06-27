using ComputerStore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerStore.RabbitMQ
{
    public class ComputerStoreDbListener : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IConfiguration _configuration;
        private readonly ComputerStoreHub _computerStoreHub;

        public ComputerStoreDbListener(IConfiguration configuration, ComputerStoreHub computerStoreHub)
        {
            _configuration = configuration;
            _computerStoreHub = computerStoreHub;
            InitializeRabbitMqListener();
        }

        private void InitializeRabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_configuration.GetConnectionString("RabbitMq"))
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _configuration["RabbitMq:DbChangesQueue"], durable: false, exclusive: false, autoDelete: false, arguments: null); // move "hello" to appsettings
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

                await _computerStoreHub.SendMessageAsync(content);
                Debug.WriteLine(content);

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_configuration["RabbitMq:DbChangesQueue"], false, consumer);

            return Task.CompletedTask;
        }
    }
}
