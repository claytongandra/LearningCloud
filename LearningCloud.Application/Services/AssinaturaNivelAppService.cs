using System.Collections.Generic;
using LearningCloud.Application.Interfaces;
using LearningCloud.Domain.Entities;
using LearningCloud.Domain.Interfaces.Services;

namespace LearningCloud.Application.Services
{
    public class AssinaturaNivelAppService : AppServiceBase<AssinaturaNivel>, IAssinaturaNivelAppService
    {
        private readonly IAssinaturaNivelService _assinaturaNivelService;

        public AssinaturaNivelAppService(IAssinaturaNivelService assinaturaNivelService)
            : base(assinaturaNivelService)
        {
            _assinaturaNivelService = assinaturaNivelService;
        }

        public IEnumerable<AssinaturaNivel> GetByStatusAssinaturaNivel(string status)
        {
            return _assinaturaNivelService.GetByStatus(status);
        }
    }
}
