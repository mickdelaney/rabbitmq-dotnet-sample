using System;
using core;
using core.Messages;
using EasyNetQ;
using RabbitMQ.Client;
using Topshelf;

namespace server
{
    public class Program
    {
        static Host _host;

        static void Main(string[] args)
        {
            //_host = HostFactory.New(c =>
            //{
            //    c.SetServiceName("ElevateServices");
            //    c.SetDisplayName("ElevateServices");
            //    c.SetDescription("ElevateServices");
            //    c.RunAsPrompt()

            //    //c.BeforeStartingServices(s => {});

            //    c.Service<Publisher>(a =>
            //    {
            //        a.ConstructUsing(service => new Publisher());
            //        a.WhenStarted(o => o.Start());
            //        a.WhenStopped(o => o.Stop());
            //    });

            //});
            //_host.Run();

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
            Console.WriteLine(conn.IsOpen);
            //foreach (var host in conn.KnownHosts)
            //{
            //    Console.WriteLine("{0}@{1}", host.Port, host.HostName);
            //}                

            var connectionString = "host=localhost;port=5675;username=guest;password=guest";
            var bus = RabbitHutch.CreateBus(connectionString);
            
            //bus.Publish(new ContractorActivatedEvent(Guid.NewGuid(), "mickdelaney@gmail.com"));

            //ConnectionFactory factory = new ConnectionFactory();
            //factory.Uri = "amqp://user:pass@hostName:port/vhost";
            //IConnection conn = factory.CreateConnection();

            while (true)
            {
                Console.WriteLine("Send message: (type :q to quit)");
                var line = Console.ReadLine();
                if (line == ":q")
                {
                    break;
                }
                if (line == ":d")
                {
                }

                bus.Publish(new ContractorActivatedEvent(Guid.NewGuid(), line));
            }
        }
    }
}
