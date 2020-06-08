# TacitusLogger.DI.Autofac

> Extension for Autofac dependency injection container that helps to configure and add TacitusLogger as a singleton.
 
Dependencies:  
* NET Standard >= 1.3  
* Autofac >= 4.0.0  
* TacitusLogger >= 0.3.0  
  
> Attention: `TacitusLogger.DI.Autofac` is currently in **Alpha phase**. This means you should not use it in any production code.

## Installation

The NuGet <a href="https://www.nuget.org/packages/TacitusLogger.DI.Autofac" target="_blank">package</a>:

```powershell
PM> Install-Package TacitusLogger.DI.Autofac
```

## Examples

### Registering logger with Autofac
```cs
ContainerBuilder containerBuilder = new ContainerBuilder();
// Configuring and registering TacitusLogger with Autofac as a singleton
containerBuilder.TacitusLogger("logger1").ForAllLogs()
                                         .Console()
                                         .Add()
                                         .BuildLogger();
var container = containerBuilder.Build();

// Using
ILogger logger = container.Resolve<ILogger>();
```
Or:

```cs
ContainerBuilder containerBuilder = new ContainerBuilder();
// Configuring and registering TacitusLogger with Autofac as a singleton
var loggerBuilder = containerBuilder.TacitusLogger("logger1");
loggerBuilder.ForAllLogs()
             .Console()
             .Add()
             .BuildLogger();

var container = containerBuilder.Build();

// Using
ILogger logger = container.Resolve<ILogger>();
```
---
