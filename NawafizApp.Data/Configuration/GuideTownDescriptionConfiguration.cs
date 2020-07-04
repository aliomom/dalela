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

    internal class GuideTownDescriptionConfiguration : EntityTypeConfiguration<GuideTownDescription>
    {
        internal GuideTownDescriptionConfiguration()
        {
            ToTable("GuideTownDescription");

            // Start add One-to-Many relationship

            HasRequired<GuideTown>(s => s.GuideTown)
                 .WithMany(s => s.GuideTownDescriptions)
                 .HasForeignKey(s => s.TownId);

            HasRequired<Language>(s => s.Language)
            .WithMany(s => s.GuideTownDescriptions)
            .HasForeignKey(s => s.LanguageId);

            // End add One-to-Many relationship

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.TownId)
                .HasColumnName("TownId")
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
