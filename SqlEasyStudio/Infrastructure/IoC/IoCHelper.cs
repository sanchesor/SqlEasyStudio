using System;
using System.Linq;
using System.Reflection;

namespace SqlEasyStudio.Infrastructure.IoC
{
    public static class IoCHelper
    {
        public static void TryInject<T>(object obj, object value)
        {
            var targetTypeInfo = obj.GetType().GetTypeInfo();
            var property = (from p in targetTypeInfo.DeclaredProperties
                            where p.PropertyType == typeof(T)
                            select p).SingleOrDefault();
            if (property != null)
            {
                property.SetValue(obj, value);
            }
        }

        public static object CreateInstance<T>(object[] args)
        {
            return CreateInstance(typeof(T), args);
        }

        public static object CreateInstance(Type type, object[] args)
        {
            var targetTypeInfo = type.GetTypeInfo();
            var types = (from o in args
                         select o.GetType())
                        .ToArray();
            var ctorInfo = targetTypeInfo.GetConstructor(types);
            if (ctorInfo != null)
            {
                return Activator.CreateInstance(type, args);
            }
            return Activator.CreateInstance(type);
        }
    }

}
