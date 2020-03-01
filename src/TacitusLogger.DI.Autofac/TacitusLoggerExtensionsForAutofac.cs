using global::Autofac;
using TacitusLogger.Builders;

namespace TacitusLogger.DI.Autofac
{
    public static class TacitusLoggerExtensionsForAutofac
    {
        public static ILoggerBuilder TacitusLogger(this ContainerBuilder builder, string loggerName)
        {
            return new CustomizedLoggerBuilder(loggerName, null, (lg) => builder.RegisterInstance<ILogger>(lg).As<ILogger>());
        }
        public static ILoggerBuilder TacitusLogger(this ContainerBuilder builder)
        {
            return TacitusLogger(builder, null);
        }
    }
}
