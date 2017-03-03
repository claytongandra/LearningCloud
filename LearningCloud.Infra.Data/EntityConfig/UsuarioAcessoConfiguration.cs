using System.Data.Entity.ModelConfiguration;
using LearningCloud.Domain.Entities;

namespace LearningCloud.Infra.Data.EntityConfig
{
    public class UsuarioAcessoConfiguration : EntityTypeConfiguration<UsuarioAcesso>
    {
        public UsuarioAcessoConfiguration()
        {
            HasKey(uac => uac.uac_id);

            ToTable("LearningCloud_UsuarioAcesso");
        }
    }
}
