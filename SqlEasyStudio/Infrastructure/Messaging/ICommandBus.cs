namespace SqlEasyStudio.Infrastructure.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command);
    }
}
