using System.Collections.Generic;
using System.Linq;
using LearningCloud.Domain.Entities;
using LearningCloud.Domain.Interfaces.Repositories;

namespace LearningCloud.Infra.Data.Repositories
{
    public class AssinaturaNivelRepository : RepositoryBase<AssinaturaNivel>, IAssinaturaNivelRepository
    {
        public IEnumerable<AssinaturaNivel> GetByStatus(string status)
        {
            string[] arrayStatus = status.Split(',');

            return ContextDB.Set<AssinaturaNivel>().Where(a => arrayStatus.Contains(a.asn_status)).ToList();

        }
              
    }
}
