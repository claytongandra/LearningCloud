using System.Data.Entity;
using LearningCloud.Domain.Entities;
using LearningCloud.Infra.Data.EntityConfig;

namespace LearningCloud.Infra.Data.Context
{
    class UsuarioLearningCloudContext : DbContext
    {
        public UsuarioLearningCloudContext()
            : base("LearningCloud")
        {
            
        }

        public DbSet<Usuario> LearningCloud_Usuario { get; set; }
        public DbSet<UsuarioAcesso> LearningCloud_UsuarioAcesso { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioAcessoConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
