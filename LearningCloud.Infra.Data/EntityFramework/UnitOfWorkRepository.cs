using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using LearningCloud.Domain.Interfaces.Repositories;
using LearningCloud.Infra.Data.Context;

namespace LearningCloud.Infra.Data.EntityFramework
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private DbContext _context;
        
        public void BeginTransactionUoW()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager<LearningCloudContext>>();
            _context = contextManager.GetContext;

        }

        public void CommitUoW()
        {
            _context.SaveChanges();
        }
    }
}
