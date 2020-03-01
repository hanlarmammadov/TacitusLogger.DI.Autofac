using Moq;
using NUnit.Framework;
using TacitusLogger.Builders;
using global::Autofac;
using TacitusLogger.DI.Autofac;
using System;
using Autofac.Core;

namespace TacitusLogger.DI.AutofacDI.UnitTests
{  
    [TestFixture]
    public class TacitusLoggerExtensionsForAutofacTests
    {
        [Test]
        public void TacitusLogger_Taking_Builder_And_LoggerName_When_Called_Sets_LoggerName()
        { 
            // Arrange 
            string loggerName = "logger1";

            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLoggerExtensionsForAutofac.TacitusLogger(new Mock<global::Autofac.ContainerBuilder>().Object, loggerName);

            // Assert 
            Assert.AreEqual(loggerName, loggerBuilder.LoggerName); 
        }

        [Test]
        public void TacitusLogger_Taking_Builder_And_LoggerName_When_Called_Calls_RegisterInstance_Of_ContainerBuilder()
        {
            // Arrange
            var ContainerBuilderMock = new Mock<global::Autofac.ContainerBuilder>(); 

            // Act
            var loggerBuilder = (CustomizedLoggerBuilder)TacitusLoggerExtensionsForAutofac.TacitusLogger(ContainerBuilderMock.Object, "logger1");

            // Assert  
            ContainerBuilderMock.Verify(x => x.RegisterCallback(It.IsAny<Action<IComponentRegistry>>()) , Times.Never);
            var logger = loggerBuilder.BuildLogger();
            ContainerBuilderMock.Verify(x => x.RegisterCallback(It.IsAny<Action<IComponentRegistry>>()), Times.Once);
        }
    }
}
