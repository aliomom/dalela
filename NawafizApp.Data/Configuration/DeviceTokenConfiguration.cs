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
  public  class DeviceTokenConfiguration : EntityTypeConfiguration<DeviceToken>
    {
        internal DeviceTokenConfiguration()
        {
            ToTable("DeviceToken");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

          

            Property(x => x.DeviceId)
                .HasColumnName("DeviceId")
                 .HasColumnType("nvarchar")

                .IsOptional();

            HasRequired(x => x.User)
              .WithMany(x => x.DeviceTokens)
              .HasForeignKey(x => x.UserId);





        }
    }
}
