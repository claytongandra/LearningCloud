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
                    asn_descricao = "Assinatura Gratuita - Todos os usu�rio cadastrados atrav�s do site sem assinatura definida.",
                    asn_nivel = 10,
                    asn_status = "A"
                },
                new AssinaturaNivel()
                {
                    asn_id = 2,
                    asn_titulo = "Assinatura B�sica",
                    asn_descricao = "Assinatura B�sica - Usu�rios com acessos a conte�dos privilegiados",
                    asn_nivel = 20,
                    asn_status = "A"
                },
                new AssinaturaNivel()
                {
                    asn_id = 3,
                    asn_titulo = "Assinatura Premium",
                    asn_descricao = "Assinatura Premium - Usu�rios com acessos a todos os conte�dos",
                    asn_nivel = 30,
                    asn_status = "A"
                }
            );
        }
    }
}
