using LearningCloud.Domain.Interfaces.Repositories;
using LearningCloud.Domain.Interfaces.Services;

namespace LearningCloud.Domain.Services
{
    public class UsuarioAcessoService : IUsuarioAcessoService
    {
        private readonly IUsuarioAcessoRepository _usuarioAcessoRepository;

        public UsuarioAcessoService(IUsuarioAcessoRepository usuarioAcessoRepository)
        {
            _usuarioAcessoRepository = usuarioAcessoRepository;
        }

        public Entities.UsuarioAcesso GetAcessoByUsuarioId(string id)
        {
            return _usuarioAcessoRepository.GetAcessoByUsuarioId(id);
        }

        public string GetLoginByEmailOrUser(string login)
        {
            return _usuarioAcessoRepository.GetLoginByEmailOrUser(login);
        }
    }
}
