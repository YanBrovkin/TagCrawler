using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Ninject;

namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(configure =>
            {
                configure.Service<TagCrawlerService>(service =>
                {
                    service.ConstructUsingNinject();
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());;
                });
                //Setup Account that window service use to run.
                configure.RunAsNetworkService();
                configure.SetServiceName("TagCrawlerService");
                configure.SetDisplayName("TagCrawlerService");
                configure.SetDescription("TagCrawler - service for searching best tags");
            });
        }
    }
}
