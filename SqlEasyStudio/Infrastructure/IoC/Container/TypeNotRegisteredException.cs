using System;

namespace SqlEasyStudio.Infrastructure.IoC.Container
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException(string message)
            : base(message)
        {
        }
    }
}
