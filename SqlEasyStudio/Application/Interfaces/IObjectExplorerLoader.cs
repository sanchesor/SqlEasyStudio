using SqlEasyStudio.Domain;

namespace SqlEasyStudio.Application.Interfaces
{
    public interface IObjectExplorerLoader
    {
        ObjectExplorerTree Load();
    }
}
