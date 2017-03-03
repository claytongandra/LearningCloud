using LearningCloud.Domain.Entities;
using LearningCloud.Domain.Interfaces.Repositories;
using LearningCloud.Domain.Interfaces.Services;

namespace LearningCloud.Domain.Services
{
    public class AulaService : ServiceBase<Aula>, IAulaService
    {
        private readonly IAulaRepository _aulaRepository;

        public AulaService(IAulaRepository aulaRepository)
            : base(aulaRepository)
        {
            _aulaRepository = aulaRepository;
        }
    }
}
