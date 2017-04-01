using System.Data.Entity.ModelConfiguration;
using LearningCloud.Domain.Entities;

namespace LearningCloud.Infra.Data.EntityConfig
{
    public class AulaConfiguration : EntityTypeConfiguration<Aula>
    {
        public AulaConfiguration()
        {
            HasKey(aul => aul.Aula_Id);

            Property(aul => aul.Aula_Id)
               .IsRequired()
               .HasColumnName("aul_id");

            Property(aul => aul.Aula_Titulo)
                .IsRequired()
                .HasColumnName("aul_titulo")
                .HasMaxLength(200);

            Property(aul => aul.aul_tipoconteudo)
               .IsRequired()
               .HasColumnType("char")
               .HasMaxLength(1);

            Property(aul => aul.aul_descricao)
                .IsRequired()
                .HasMaxLength(8000);

            Property(aul => aul.aul_indroducao)
                .IsRequired()
                .HasMaxLength(8000);

            Property(aul => aul.aul_prerequisitos)
                .HasMaxLength(8000);           //     .HasColumnType("varchar(max)");
            
            //Property(aul => aul.aul_imagem)
            //     .HasMaxLength(250);

            Property(aul => aul.aul_status)
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(aul => aul.aul_tempovideo)
               .HasMaxLength(11);

            Property(aul => aul.aul_video)
                 .HasMaxLength(250);

            Property(aul => aul.aul_conteudoartigo)
                .IsMaxLength()
                .HasColumnType("varchar(max)");

            Property(aul => aul.aul_palavraschave)
                .HasMaxLength(8000);

            Property(aul => aul.Aula_DataCadastro)
                .IsRequired() 
                .HasColumnName("aul_datacadastro")
                .HasColumnType("datetime2");

            Property(aul => aul.Aula_DataAlteracao)
                .HasColumnName("aul_dataalteracao")
                .IsOptional()
                .HasColumnType("datetime2");

            HasRequired(aul => aul.aul_assinaturanivel)
                .WithMany()
                .HasForeignKey(aul => aul.aul_fk_assinaturanivel);

            ToTable("LearningCloud_Aula");
        }

    }
}
