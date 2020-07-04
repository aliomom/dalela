using NawafizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace NawafizApp.Data.Configuration
{
    internal class BreakConfiguration: EntityTypeConfiguration<Break>
    {
        internal BreakConfiguration()
        {
            ToTable("Break");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.start)
                .HasColumnName("start")
                .HasColumnType("time");
            Property(x => x.end)
                .HasColumnName("end")
                .HasColumnType("time");
            HasRequired(x => x.Branch
            ).WithMany(x => x.Breaks)
            .HasForeignKey(x => x.BranchId);
        }
    }
}
