using SqlEasyStudio.Domain;

namespace SqlEasyStudio.Domain.Repositories
{
    public interface IObjectExplorerRepository
    {
        ObjectExplorerTree Load();
    }
}
