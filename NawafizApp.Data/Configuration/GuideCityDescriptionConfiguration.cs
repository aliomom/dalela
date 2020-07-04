using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using NawafizApp.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Reflection.Emit;

namespace NawafizApp.Data.Configuration
{

    internal class GuideCityDescriptionConfiguration : EntityTypeConfiguration<GuideCityDescription>
    {
        internal GuideCityDescriptionConfiguration()
        {
            ToTable("GuideCityDescription");

            // Start add One-to-Many relationship

            HasRequired<GuideCity>(s => s.GuideCity)
                 .WithMany(s => s.GuideCityDescriptions)
                 .HasForeignKey(s => s.CityId);

            HasRequired<Language>(s => s.Language)
            .WithMany(s => s.GuideCityDescriptions)
            .HasForeignKey(s => s.LanguageId);

            // End add One-to-Many relationship

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CityId)
                .HasColumnName("CityId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.LanguageId)
                .HasColumnName("LanguageId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();


        }
    }
}

