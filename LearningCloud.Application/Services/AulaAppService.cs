using LearningCloud.Application.Interfaces;
using LearningCloud.Domain.Entities;
using LearningCloud.Domain.Interfaces.Services;

namespace LearningCloud.Application.Services
{
    public class AulaAppService : AppServiceBase<Aula>, IAulaAppService
    {
        private readonly IAulaService _aulaService;

        public AulaAppService(IAulaService aulaService)
            : base(aulaService)
        {
            _aulaService = aulaService;
        }

        public void CreateAula(Aula aula)
        {
            BeginTransactionUoW();
            _aulaService.Add(aula);
            ComitUoW();
        }

        public void UpdateAula(Aula aula)
        {
            BeginTransactionUoW();
            _aulaService.Update(aula);
            ComitUoW();

        }

        public void RemoveAula(Aula aula)
        {
            BeginTransactionUoW();
            _aulaService.Remove(aula);
            ComitUoW();
        }

        public void ChangeStatusAula(Aula aula, string status)
        {
            aula.aul_status = status;
            UpdateAula(aula);
        }
    }
}
