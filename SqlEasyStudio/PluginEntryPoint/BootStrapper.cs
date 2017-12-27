using SqlEasyStudio.Infrastructure.Extensions;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.IoC.Container;
using SqlEasyStudio.Infrastructure.IoC.Extensions;
using SqlEasyStudio.Infrastructure.Messaging;
using System.Linq;
using System.Reflection;

namespace SqlEasyStudio.PluginEntryPoint
{
    public static class BootStrapper
    {
        public static void RegisterComponents()
        {
            var container = ContainerDelivery.GetContainer();

            var components = (from t in Assembly.GetExecutingAssembly().GetTypes()
                              where t.ShouldRegisterComponent()
                              select t)
                             .ToArray();
            foreach (var component in components)
            {
                var interfaces = component.GetInterfaces();
                if (interfaces.Count() == 0)
                {
                    container.Register(component, component, component.GetComponentLifestyle());
                }
                else
                {
                    foreach (var interf in interfaces)
                        container.Register(interf, component, component.GetComponentLifestyle());
                }
            }
        }

        public static void RegisterCommandHandlers()
        {
            var container = ContainerDelivery.GetContainer();
            var assembly = Assembly.GetExecutingAssembly();
            var commandHandlers = assembly.GetAllTypesImplementingOpenGenericType(typeof(ICommandHandler<>));
            foreach (var commandHandler in commandHandlers)
            {
                var interfaceType = (from i in commandHandler.GetInterfaces()
                                     where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)
                                     select i).SingleOrDefault();
                if (interfaceType != null)
                {
                    container.Register(interfaceType, commandHandler, LifeCycle.Transient);
                }
            }
        }

    }
}
