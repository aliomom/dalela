using NawafizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Data.Configuration
{
 public   class NeighborhoodConfigration : EntityTypeConfiguration<Neighborhood>
    {
        internal NeighborhoodConfigration()
        {
            ToTable("Neighborhood");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ArabicName)
                .HasColumnName("ArabicName")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsOptional();

            Property(x => x.EngName)
                .HasColumnName("EngName")
                 .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsOptional();

            Property(x => x.RussName)
                .HasColumnName("RussName")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsOptional();

            Property(x => x.PersianName)
                .HasColumnName("PersianName")
                .HasColumnType("nvarchar")
                 .HasMaxLength(256)
                .IsOptional();

            Property(x => x.FrenchName)
                .HasColumnName("FrenchName")
            .HasColumnType("nvarchar")
                 .HasMaxLength(256)
                .IsOptional();
     
            HasRequired(x => x.Region)
                   .WithMany(x => x.Neighborhoods)
                   .HasForeignKey(x => x.RegionId);

            HasMany(x => x.Branchs)
           .WithRequired(x => x.Neighborhood)
           .HasForeignKey(x => x.NeighborhoodId);



        }

    }
}
