using LearningCloud.Domain.Entities;

namespace LearningCloud.Application.Interfaces
{
    public interface IUsuarioAcessoAppService
    {
        UsuarioAcesso GetAcessoByUsuarioId(string id);
        string GetLoginByEmailOrUser(string login);
    }
}
