using LearningCloud.Domain.Entities;

namespace LearningCloud.Domain.Interfaces.Services
{
    public interface IUsuarioAcessoService
    {
        UsuarioAcesso GetAcessoByUsuarioId(string id);
        string GetLoginByEmailOrUser(string login);
    }
}
