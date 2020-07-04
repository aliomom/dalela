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
 public   class ClientOfferConfiguration : EntityTypeConfiguration<ClientOffer>
    {
        internal ClientOfferConfiguration()
        {
            ToTable("ClientOffer");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.title) 
                .HasColumnName("title")
                .HasColumnType("nvarchar")
                .IsOptional();
            Property(x => x.photo)
             .HasColumnName("photo")
             .HasColumnType("varbinary(MAX)").IsOptional();

            Property(x => x.details)
                .HasColumnName("details")
                 .HasColumnType("nvarchar")  
                .IsOptional();

            Property(x => x.Start)
                  .HasColumnName("Start")
                  .HasColumnType("date")
                  .IsRequired();

            Property(x => x.end)
                  .HasColumnName("end")
                  .HasColumnType("date")
                  .IsRequired();

            Property(x => x.Timeofpuplishing)
                 .HasColumnName("Timeofpuplishing")
                 .HasColumnType("time")
                 .IsRequired();

            Property(x => x.Dateofpuplishing)
                 .HasColumnName("Dateofpuplishing")
                 .HasColumnType("date")
                 .IsRequired();
            HasRequired(x => x.Branch)
             .WithMany(x => x.ClientOffers)
             .HasForeignKey(x => x.BranchId);





        }
    }
}
