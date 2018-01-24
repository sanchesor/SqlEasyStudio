using SqlEasyStudio.Domain;

namespace SqlEasyStudio.Application.Connections
{
    public class ConnectionLink
    {
        public ObjectExplorerItem Item { get; private set; }
        public IConnection Connection { get; private set; }

        public ConnectionLink(ObjectExplorerItem item, IConnection connection)
        {
            Item = item;
            Connection = connection;
        }
    }
}
