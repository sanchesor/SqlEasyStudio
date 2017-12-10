using System;

namespace SqlEasyStudio.Infrastructure.IoC.Container
{
    public interface IContainer
    {
        void Register(Type typeToResolve, Type concrete);
        void Register(Type typeToResolve, Type concrete, LifeCycle lifeCycle);
        void Register<TTypeToResolve, TConcrete>();
        void Register<TTypeToResolve, TConcrete>(LifeCycle lifeCycle);
        TTypeToResolve Resolve<TTypeToResolve>();
        object Resolve(Type typeToResolve);
    }
}
