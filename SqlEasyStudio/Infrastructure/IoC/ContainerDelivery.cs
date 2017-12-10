using SqlEasyStudio.Infrastructure.IoC.Container;

namespace SqlEasyStudio.Infrastructure.IoC
{
    public static class ContainerDelivery
    {
        private static IContainer container;
        public static IContainer GetContainer()
        {
            if (container == null)
                container = new SimpleIocContainer();
            return container;
        }
    }
}
