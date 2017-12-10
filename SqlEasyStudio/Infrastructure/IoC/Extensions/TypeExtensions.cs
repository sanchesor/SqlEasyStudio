using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.Infrastructure.IoC.Container;
using System;
using System.Linq;

namespace SqlEasyStudio.Infrastructure.IoC.Extensions
{
    public static class TypeExtensions
    {
        public static bool ShouldRegisterComponent(this Type type)
        {
            return (GetComponentAttribute(type) != null);
        }

        public static LifeCycle GetComponentLifestyle(this Type type)
        {
            return GetComponentAttribute(type).LifeCycle;
        }

        private static ComponentAttribute GetComponentAttribute(Type type)
        {
            return type.GetCustomAttributes(typeof(ComponentAttribute), true)
                .OfType<ComponentAttribute>()
                .FirstOrDefault();
        }
    }
}
