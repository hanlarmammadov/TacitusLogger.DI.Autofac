using Autofac;
using Autofac.Core.Registration;
using NUnit.Framework; 
using TacitusLogger.DI.Autofac;

namespace TacitusLogger.DI.AutofacDI.IntegrationTests
{
    [TestFixture]
    public class TacitusLoggerExtensionsForAutofacTests
    {
        [Test]
        public void When_Logger_Is_Not_Built_Autofac_Does_Not_Have_ILogger_Binding()
        {
            // Arrange
            ContainerBuilder containerBuilder = new ContainerBuilder();
            var loggerBuilder = containerBuilder.TacitusLogger("logger1");
            var container = containerBuilder.Build();

            // Assert
            Assert.Catch<ComponentNotRegisteredException>(() =>
            {
                container.Resolve<ILogger>();
            });
        }

        [Test]
        public void When_Logger_Is_Built_Autofac_Has_ILogger_Binding()
        {
            // Arrange
            ContainerBuilder containerBuilder = new ContainerBuilder();
            var loggerBuilder = containerBuilder.TacitusLogger("logger1");
            loggerBuilder.BuildLogger();
            var container = containerBuilder.Build();
     
            // Act 
            ILogger logger = container.Resolve<ILogger>();

            // Assert
            Assert.IsNotNull(logger);
            Assert.IsInstanceOf<Logger>(logger);
        }

        [Test]
        public void ILogger_Binding_Is_Singleton()
        {
            // Arrange
            ContainerBuilder containerBuilder = new ContainerBuilder();
            ILogger loggerFromBuilder = containerBuilder.TacitusLogger("logger1").BuildLogger(); 
            var container = containerBuilder.Build(); 

            // Act 
            ILogger loggerInstance1 = container.Resolve<ILogger>();
            ILogger loggerInstance2 = container.Resolve<ILogger>();
            ILogger loggerInstance3 = container.Resolve<ILogger>();

            // Assert
            Assert.AreEqual(loggerFromBuilder, loggerInstance1);
            Assert.AreEqual(loggerFromBuilder, loggerInstance2);
            Assert.AreEqual(loggerFromBuilder, loggerInstance3);
        }
    }
}
