using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LearningCloud.Infra.Data.EntityConfig;
using LearningCloud.Domain.Entities;


namespace LearningCloud.Infra.Data.Context
{
    public class LearningCloudContext : DbContext
    {
        public LearningCloudContext()
            : base("LearningCloud") //Nome da Base de Dados
        {
            bool instanceExists = System.Data.Entity.SqlServer.SqlProviderServices.Instance != null;
        }

        public DbSet<Aula> Aulas { get; set; }
        public DbSet<AssinaturaNivel> AssinaturaNivel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
              .Where(p => p.Name.Contains("_id"))
              .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
              .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
              .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AulaConfiguration());
            modelBuilder.Configurations.Add(new AssinaturaNivelConfiguration());

        }
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.State != EntityState.Deleted)
                {
                    string dataCadastro = null;
                    string dataAlteracao = null;

                    foreach (string o in entry.CurrentValues.PropertyNames)
                    {
                        var property = entry.Property(o);

                        if (property.Name.Contains("_datacadastro"))
                        {
                            dataCadastro = property.Name;
                        }
                        if (property.Name.Contains("_dataalteracao"))
                        {
                            dataAlteracao = property.Name.ToString();
                        }
                    }

                    if (entry.State == EntityState.Added)
                    {
                        if (dataCadastro != null)
                        {
                            entry.Property(dataCadastro).CurrentValue = DateTime.Now;
                        }
                        if (dataAlteracao != null)
                        {
                            entry.Property(dataAlteracao).CurrentValue = null;
                        }
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        if (dataCadastro != null)
                        {
                            entry.Property(dataCadastro).IsModified = false;
                        }
                        if (dataAlteracao != null)
                        {
                            entry.Property(dataAlteracao).CurrentValue = DateTime.Now;
                        }
                    }
                }
            }

            try
            {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            //return base.SaveChanges();
        }

    }
}
