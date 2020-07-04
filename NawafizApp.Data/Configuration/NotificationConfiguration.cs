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
public    class NotificationConfiguration: EntityTypeConfiguration<Notification>
    {
        internal NotificationConfiguration()
        {
            ToTable("Notification");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.senderId)
            .HasColumnName("senderId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

            Property(x => x.title)
                .HasColumnName("title")
                 .HasColumnType("nvarchar")

                .IsOptional();
            Property(x => x.date)
              .HasColumnName("date")
               .HasColumnType("date")

              .IsOptional();
            Property(x => x.time)
                .HasColumnName("time")
                  .HasColumnType("time")

                .IsOptional();


            HasRequired(x => x.User)
                   .WithMany(x => x.Notifications)
                   .HasForeignKey(x => x.RevieverId);

           



        }
    }
}
