namespace NawafizApp.Data.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NawafizApp.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NawafizApp.Data.ApplicationDbContext context)
        {
            context.Languages.AddOrUpdate(l => l.ArabicName,
                new Language() { Id = 1, ArabicName = "العربية", EnglishName = "Arabic", Code = "ar" },
                new Language() { Id = 2, ArabicName = "الانجليزية", EnglishName = "English", Code = "en" }
                );

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
        }
    }
}
