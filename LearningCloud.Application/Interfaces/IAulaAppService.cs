using LearningCloud.Domain.Entities;

namespace LearningCloud.Application.Interfaces
{
    public interface IAulaAppService:IAppServiceBase<Aula>
    {
        void CreateAula(Aula aula);
        void UpdateAula(Aula aula);
        void RemoveAula(Aula aula);
        void ChangeStatusAula(Aula aula, string status);
    }
}
