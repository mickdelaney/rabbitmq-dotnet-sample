using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core;
using core.Messages;
using EasyNetQ;
using RabbitMQ.Client;
using Topshelf;

namespace rabbitmq_clustering
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cfg = HostFactory.New(c =>
            {

                c.SetServiceName("ElevateServices");
                c.SetDisplayName("ElevateServices");
                c.SetDescription("ElevateServices");

                //c.BeforeStartingServices(s => {});

                c.Service<Publisher>(a =>
                {
                    a.ConstructUsing(service => new Publisher());
                    a.WhenStarted(o => o.Start());
                    a.WhenStopped(o => o.Stop());
                });

            });

            var user = "Administrator";
            var pass = "Password1";
            var vhost = "web2";
            var hostName = "mick-lt";


            var factory = new ConnectionFactory
            {
                //UserName = user,
                //Password = pass,
                //VirtualHost = vhost,
                //Protocol = Protocols.FromEnvironment(),
                //HostName = hostName,
                //Port = AmqpTcpEndpoint.UseDefaultPort
                Port = RabbitConfig.Web02Port
            };

            var conn = factory.CreateConnection();


            var connectionString = "host=localhost;port=5675;username=guest;password=guest";
            var bus = RabbitHutch.CreateBus(connectionString);
            
            bus.Publish(new ContractorActivatedEvent(Guid.NewGuid(), "mickdelaney@gmail.com"));

            //ConnectionFactory factory = new ConnectionFactory();
            //factory.Uri = "amqp://user:pass@hostName:port/vhost";
            //IConnection conn = factory.CreateConnection();

            Console.Read();

        }
    }
}
