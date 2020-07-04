using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using NawafizApp.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace NawafizApp.Data.Configuration
{

    internal class GuideCityConfiguration : EntityTypeConfiguration<GuideCity>
    {
        internal GuideCityConfiguration()
        {
            ToTable("GuideCity");

            // Start add One-to-Many relationship
            HasMany<GuideCityDescription>(s => s.GuideCityDescriptions)
                    .WithRequired(s => s.GuideCity)
                    .HasForeignKey(s => s.CityId);

            HasMany<GuideTown>(s => s.GuideTowns)
                .WithRequired(s => s.GuideCity)
                .HasForeignKey(s => s.CityId);

            //HasMany<Classify>(s => s.Classifieds)
            //       .WithRequired(s => s.City)
            //       .HasForeignKey(s => s.CityId);


            // End add One-to-Many relationship

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(x => x.Sort)
                 .HasColumnName("Sort")
                  .HasColumnType("int")
                 .IsRequired();



        }
    }
}

