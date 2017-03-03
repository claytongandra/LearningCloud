using LearningCloud.Application.Interfaces;
using LearningCloud.Domain.Interfaces.Services;

namespace LearningCloud.Application.Services
{
    public class UsuarioAcessoAppService : IUsuarioAcessoAppService
    {
        private readonly IUsuarioAcessoService _usuarioAcessoService;

        public UsuarioAcessoAppService(IUsuarioAcessoService usuarioAcessoService)
        {
            _usuarioAcessoService = usuarioAcessoService;
        }

        public Domain.Entities.UsuarioAcesso GetAcessoByUsuarioId(string id)
        {
            return _usuarioAcessoService.GetAcessoByUsuarioId(id);
        }

        public string GetLoginByEmailOrUser(string login)
        {
            return _usuarioAcessoService.GetLoginByEmailOrUser(login);
        }
    }
}
