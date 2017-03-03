using System.Data.Entity.ModelConfiguration;
using LearningCloud.Domain.Entities;

namespace LearningCloud.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(usu => usu.usu_id);

            Property(usu => usu.usu_id)
                .IsRequired()
                .HasMaxLength(128);

            Property(usu => usu.usu_nome)
                .IsRequired()
                .HasMaxLength(256);

            Property(usu => usu.usu_sobreNome)
                .IsRequired()
                .HasMaxLength(256);

            Property(usu => usu.usu_dataNascimento)
               //.IsRequired()
               .HasColumnType("datetime2");

            Property(usu => usu.usu_sexo)
                //.IsRequired()
               .HasColumnType("char")
               .HasMaxLength(1);

            Property(usu => usu.usu_nivel)
               .IsRequired();

            Property(usu => usu.usu_status)
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(usu => usu.usu_dataCadastro)
               .IsRequired()
               .HasColumnType("datetime2");

            ToTable("LearningCloud_Usuario");
        }
    }
}
