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
public class StateConfiguration : EntityTypeConfiguration<State>
    {
        internal StateConfiguration()
        {
            ToTable("State");
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

            HasMany(x => x.Regions)
              .WithRequired(x => x.State)
               .HasForeignKey(x => x.StateId);






        }
    }
}
