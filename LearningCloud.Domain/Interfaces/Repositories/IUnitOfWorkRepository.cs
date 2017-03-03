

namespace LearningCloud.Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkRepository
    {
        void BeginTransactionUoW();

        void CommitUoW();
    }
}
