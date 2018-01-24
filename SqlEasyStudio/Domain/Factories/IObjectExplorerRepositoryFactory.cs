using SqlEasyStudio.Domain.Repositories;

namespace SqlEasyStudio.Domain.Factories
{
    public interface IObjectExplorerRepositoryFactory
    {
        IObjectExplorerRepository Create();
    }
}
