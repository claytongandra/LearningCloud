using System.Collections.Generic;

namespace LearningCloud.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void BeginTransactionUoW();
        void ComitUoW();
        void Dispose();
    }
}
