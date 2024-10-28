namespace Proyecto_Expediente.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Proyecto_Expediente.Models.DBContextProject>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
          AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Proyecto_Expediente.Models.DBContextProject context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
