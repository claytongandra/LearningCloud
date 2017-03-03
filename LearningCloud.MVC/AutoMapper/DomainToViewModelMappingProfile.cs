using AutoMapper;
using LearningCloud.Domain.Entities;
using LearningCloud.MVC.Areas.Admin.ViewModels;

namespace LearningCloud.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {

            CreateMap<Aula, AulaViewModel>();
           // CreateMap<AssinaturaNivel, AssinaturaNivelViewModel>();
                       
        }
    }
}