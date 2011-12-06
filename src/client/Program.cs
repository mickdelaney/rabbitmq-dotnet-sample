using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core;
using core.Messages;
using EasyNetQ;
using RabbitMQ.Client;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = "Administrator";
            var pass = "Password1";
            var vhost = "rabbit";
            var hostName = "mick-lt";


            var factory = new ConnectionFactory
            {
                //UserName = user,
                //Password = pass,
                //VirtualHost = vhost,
                //Protocol = Protocols.FromEnvironment(),
                //HostName = hostName,
                //Port = AmqpTcpEndpoint.UseDefaultPort
                Port = RabbitConfig.Web01Port
            };

            var conn = factory.CreateConnection();

            var connectionString = "host=localhost;port=5675;username=guest;password=guest";
            var bus = RabbitHutch.CreateBus(connectionString);
            bus.Subscribe<ContractorActivatedEvent>("CVParserSubscription", msg => System.Console.WriteLine(msg.EmailAddress));

            //ConnectionFactory factory = new ConnectionFactory();
            //factory.Uri = "amqp://user:pass@hostName:port/vhost";
            //IConnection conn = factory.CreateConnection();

            Console.Read();
        }
    }
}
