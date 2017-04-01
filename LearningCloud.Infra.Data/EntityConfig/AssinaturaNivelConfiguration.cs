using System.Data.Entity.ModelConfiguration;
using LearningCloud.Domain.Entities;

namespace LearningCloud.Infra.Data.EntityConfig
{
    public class AssinaturaNivelConfiguration : EntityTypeConfiguration<AssinaturaNivel>
    {
        public AssinaturaNivelConfiguration()
        {
            HasKey(asn => asn.AssinaturaNivel_Id);

            Property(asn => asn.AssinaturaNivel_Id)
              .IsRequired()
              .HasColumnName("asn_id");

            Property(asn => asn.asn_titulo)
                .IsRequired()
                .HasMaxLength(150);

            Property(asn => asn.asn_descricao)
                .IsRequired()
                .HasMaxLength(500);

            Property(asn => asn.asn_nivel)
                .IsRequired();

            Property(asn => asn.asn_status)
               .IsRequired()
               .HasColumnType("char")
               .HasMaxLength(1);

            ToTable("LearningCloud_AssinaturaNivel");
        }
    }
}
