using Autofac; 
using TacitusLogger.Builders;

namespace TacitusLogger.DI.Autofac.Examples
{
    public class Registering
    {
        public void Registering_Logger_With_Autofac()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            // Registering TacitusLogger with Autofac as a singleton
            containerBuilder.TacitusLogger("logger1").ForAllLogs()
                                                     .Console()
                                                     .Add()
                                                     .BuildLogger();
            var container = containerBuilder.Build();

            // Using
            ILogger logger = container.Resolve<ILogger>();
        }
        public void Registering_Logger_With_Autofac2()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            // Registering TacitusLogger with Autofac as a singleton
            var loggerBuilder = containerBuilder.TacitusLogger("logger1");
            loggerBuilder.ForAllLogs()
                         .Console()
                         .Add()
                         .BuildLogger();

            var container = containerBuilder.Build();

            // Using
            ILogger logger = container.Resolve<ILogger>();
        }
    }
}
