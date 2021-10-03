using Autofac;
using mB.Db;
using mB.Loader.Services;
using mB.Loader.Services.Extractors;
using mB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Runner
{
    public static class App
    {
        private static IContainer services; 

        static App()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProductLoader>();
            builder.RegisterType<ProductExtractorFactory>();
            builder.RegisterType<ProductsService>();

            builder.Register<Context>(c =>
                new Context($"../../../../mB.Db/mB.db"));

            builder.RegisterType<ConsoleLogger>().As<ILogger>();

            builder.RegisterType<XmlProductExtractor>().As<IProductExtractor>();
            builder.RegisterType<CsvProductExtractor>().As<IProductExtractor>();

            services = builder.Build();
        }

        public static T Get<T>() => services.Resolve<T>();
    }


}
