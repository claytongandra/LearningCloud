using SimpleInjector;
using Microsoft.Practices.ServiceLocation;

using CommonServiceLocator.SimpleInjectorAdapter;

using LearningCloud.Infra.Data.EntityFramework;
using LearningCloud.Infra.Data.Repositories;

using LearningCloud.Infra.CrossCutting.Identity.ContextIdentity;
using LearningCloud.Infra.CrossCutting.Identity.Models;
using LearningCloud.Infra.CrossCutting.Identity.Configuration;

using LearningCloud.Domain.Services;
using LearningCloud.Domain.Interfaces.Services;
using LearningCloud.Domain.Interfaces.Repositories;

using LearningCloud.Application.Services;
using LearningCloud.Application.Interfaces;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace LearningCloud.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {

            container.Register<IUnitOfWorkRepository, UnitOfWorkRepository>();
            
            container.RegisterPerWebRequest<IAulaRepository, AulaRepository>();
            container.RegisterPerWebRequest<IAulaAppService, AulaAppService>();
            container.RegisterPerWebRequest<IAulaService, AulaService>();

            container.RegisterPerWebRequest<IAssinaturaNivelRepository, AssinaturaNivelRepository>();
            container.RegisterPerWebRequest<IAssinaturaNivelAppService, AssinaturaNivelAppService>();
            container.RegisterPerWebRequest<IAssinaturaNivelService, AssinaturaNivelService>();
                                                                                    
            container.RegisterPerWebRequest<IUsuarioAcessoRepository, UsuarioAcessoRepository>();
            container.RegisterPerWebRequest<IUsuarioAcessoAppService, UsuarioAcessoAppService>();
            container.RegisterPerWebRequest<IUsuarioAcessoService, UsuarioAcessoService>();

            //*****  Registro de dependências para o Identity ******************************************************************************************
            container.RegisterPerWebRequest<ApplicationDbContext>();
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();
            
            //******************************************************************************************************************************************
            
            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);

        }

    }
}
