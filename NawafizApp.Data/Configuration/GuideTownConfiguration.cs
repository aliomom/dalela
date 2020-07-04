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

    internal class GuideTownConfiguration : EntityTypeConfiguration<GuideTown>
    {
        internal GuideTownConfiguration()
        {
            ToTable("GuideTown");

            // Start add One-to-Many relationship
            HasMany<GuideTownDescription>(s => s.GuideTownDescriptions)
                    .WithRequired(s => s.GuideTown)
                    .HasForeignKey(s => s.TownId);

            HasRequired<GuideCity>(s => s.GuideCity)
                .WithMany(s => s.GuideTowns)
                .HasForeignKey(s => s.CityId);

            HasMany<GuideClassify>(s => s.GuideClassifieds)
                  .WithRequired(s => s.GuideTown)
                  .HasForeignKey(s => s.TownId);
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


            Property(x => x.Sort)
               .HasColumnName("Sort")
               .HasColumnType("int")
               .IsRequired();


            Property(x => x.Gps_Latitude)
                .HasColumnName("Gps_Latitude")
                .HasColumnType("nvarchar")
                .IsOptional()
                .HasMaxLength(20)
                ;
            Property(x => x.Gps_Longitude)
                .HasColumnName("Gps_Longitude")
                .HasColumnType("nvarchar")
                .IsOptional()
                .HasMaxLength(20)
                ;



        }
    }
}

