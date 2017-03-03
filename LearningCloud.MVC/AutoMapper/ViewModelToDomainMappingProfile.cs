using AutoMapper;
using LearningCloud.Domain.Entities;
using LearningCloud.MVC.Areas.Admin.ViewModels;

namespace LearningCloud.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<AulaViewModel, Aula>();
          //  CreateMap<AssinaturaNivelViewModel, AssinaturaNivel>();

        }
    }
}