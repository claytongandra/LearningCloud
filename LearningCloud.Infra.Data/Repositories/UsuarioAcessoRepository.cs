using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using LearningCloud.Domain.Interfaces.Repositories;
using LearningCloud.Domain.Entities;
using LearningCloud.Infra.Data.Context;
using LearningCloud.Infra.Data.EntityFramework;


namespace LearningCloud.Infra.Data.Repositories
{
    public class UsuarioAcessoRepository : IUsuarioAcessoRepository
    {

        protected DbContext IdentityContextDB { get; private set; }

        public UsuarioAcessoRepository()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager<UsuarioLearningCloudContext>>();
            IdentityContextDB = contextManager.GetContext;
        }

        public Domain.Entities.UsuarioAcesso GetAcessoByUsuarioId(string id)
        {
            return IdentityContextDB.Set<UsuarioAcesso>().Find(id);
        }

        public string GetLoginByEmailOrUser(string login)
        {
            UsuarioAcesso retornoQueryUser = (from UserLogin in IdentityContextDB.Set<UsuarioAcesso>()
                                              where (UserLogin.uac_email == login || UserLogin.uac_userName == login)
                                              select UserLogin).SingleOrDefault();
            
            return retornoQueryUser.uac_userName;
        }

        public void Dispose()
        {
            IdentityContextDB.Dispose();
        }
    }
}
