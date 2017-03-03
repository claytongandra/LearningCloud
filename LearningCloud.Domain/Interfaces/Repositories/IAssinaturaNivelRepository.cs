using System.Collections.Generic;
using LearningCloud.Domain.Entities;

namespace LearningCloud.Domain.Interfaces.Repositories
{
    public interface IAssinaturaNivelRepository: IRepositoryBase<AssinaturaNivel>
    {
        IEnumerable<AssinaturaNivel> GetByStatus(string status);
    }

}
