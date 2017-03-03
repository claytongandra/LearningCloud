using System.Collections.Generic;
using LearningCloud.Domain.Entities;

namespace LearningCloud.Application.Interfaces
{
    public interface IAssinaturaNivelAppService : IAppServiceBase<AssinaturaNivel>
    {
        IEnumerable<AssinaturaNivel> GetByStatusAssinaturaNivel(string status);
    }
}
