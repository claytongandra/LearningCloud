using System.Collections.Generic;
using LearningCloud.Domain.Entities;


namespace LearningCloud.Domain.Interfaces.Services
{
    public interface IAssinaturaNivelService : IServiceBase<AssinaturaNivel>
    {
        IEnumerable<AssinaturaNivel> GetByStatus(string status);
    }
}
