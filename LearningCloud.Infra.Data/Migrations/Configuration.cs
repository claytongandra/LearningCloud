namespace LearningCloud.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using LearningCloud.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.LearningCloudContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.LearningCloudContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.AssinaturaNivel.AddOrUpdate(
                asn => asn.asn_id,
                new AssinaturaNivel()
                {
                    asn_id = 1,
                    asn_titulo = "Assinatura Gratuita",
                    asn_descricao = "Assinatura Gratuita - Todos os usuário cadastrados através do site sem assinatura definida.",
                    asn_nivel = 10,
                    asn_status = "A"
                },
                new AssinaturaNivel()
                {
                    asn_id = 2,
                    asn_titulo = "Assinatura Básica",
                    asn_descricao = "Assinatura Básica - Usuários com acessos a conteúdos privilegiados",
                    asn_nivel = 20,
                    asn_status = "A"
                },
                new AssinaturaNivel()
                {
                    asn_id = 3,
                    asn_titulo = "Assinatura Premium",
                    asn_descricao = "Assinatura Premium - Usuários com acessos a todos os conteúdos",
                    asn_nivel = 30,
                    asn_status = "A"
                }
            );
        }
    }
}
