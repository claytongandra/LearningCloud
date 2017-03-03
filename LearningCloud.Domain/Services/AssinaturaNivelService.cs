using System.Collections.Generic;
using LearningCloud.Domain.Entities;
using LearningCloud.Domain.Interfaces.Services;
using LearningCloud.Domain.Interfaces.Repositories;

namespace LearningCloud.Domain.Services
{
    public class AssinaturaNivelService : ServiceBase<AssinaturaNivel>, IAssinaturaNivelService
    {
        private readonly IAssinaturaNivelRepository _assinaturaNivelRepository;

        public AssinaturaNivelService(IAssinaturaNivelRepository assinaturaNivelRepository)
            : base(assinaturaNivelRepository)
        {
            _assinaturaNivelRepository = assinaturaNivelRepository;
        }

        public IEnumerable<AssinaturaNivel> GetByStatus(string status)
        {
            return _assinaturaNivelRepository.GetByStatus(status);
        }
    }
}
