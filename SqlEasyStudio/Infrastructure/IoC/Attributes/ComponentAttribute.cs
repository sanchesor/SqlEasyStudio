using SqlEasyStudio.Infrastructure.IoC.Container;
using System;

namespace SqlEasyStudio.Infrastructure.IoC.Attributes
{
    public class ComponentAttribute : Attribute
    {
        public LifeCycle LifeCycle { get; set; }

        public ComponentAttribute()
            : this(LifeCycle.Singleton)
        {
        }

        public ComponentAttribute(LifeCycle lifeCycle)
        {
        }
    }
}
