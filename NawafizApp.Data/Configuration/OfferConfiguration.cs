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
   public class OfferConfiguration : EntityTypeConfiguration<Offer>
    {
        internal OfferConfiguration()
        {
            ToTable("Offer");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);




        
            Property(x => x.Atitle)
            .HasColumnName("Atitle")
        .HasColumnType("nvarchar")

            .IsOptional();
            Property(x => x.Ftitle)
         .HasColumnName("Ftitle")
     .HasColumnType("nvarchar")

         .IsOptional();
            Property(x => x.Etitle)
         .HasColumnName("Etitle")
     .HasColumnType("nvarchar")

         .IsOptional();
            Property(x => x.Ptitle)
         .HasColumnName("Ptitle")
     .HasColumnType("nvarchar")

         .IsOptional();
            Property(x => x.Rtitle)
         .HasColumnName("Rtitle")
     .HasColumnType("nvarchar")

         .IsOptional();
            Property(x => x.Adetails)
       .HasColumnName("Adetails")
        .HasColumnType("nvarchar")

       .IsOptional();
            Property(x => x.Edetails)
   .HasColumnName("Edetails")
    .HasColumnType("nvarchar")

   .IsOptional();
            Property(x => x.Fdetails)
   .HasColumnName("Fdetails")
    .HasColumnType("nvarchar")

   .IsOptional();
            Property(x => x.Pdetails)
   .HasColumnName("Pdetails")
    .HasColumnType("nvarchar")

   .IsOptional();
            Property(x => x.Rdetails)
   .HasColumnName("Rdetails")
    .HasColumnType("nvarchar")

   .IsOptional();
            Property(x => x.phon1)
    .HasColumnName("phon1")
     .HasColumnType("nvarchar")

    .IsOptional();

            Property(x => x.phon2)
.HasColumnName("phon2")
.HasColumnType("nvarchar")

.IsOptional();
            Property(x => x.phon3)
.HasColumnName("phon3")
.HasColumnType("nvarchar")

.IsOptional();
            Property(x => x.phon4)
.HasColumnName("phon4")
.HasColumnType("nvarchar")

.IsOptional();
            Property(x => x.phon5)
.HasColumnName("phon5")
.HasColumnType("nvarchar")

.IsOptional();
            Property(x => x.phon6)
.HasColumnName("phon6")
.HasColumnType("nvarchar")

.IsOptional();
            Property(x => x.email)
.HasColumnName("email")
.HasColumnType("nvarchar")

.IsOptional();
            Property(x => x.faceLink)
.HasColumnName("faceLink")
.HasColumnType("nvarchar")

.IsOptional();
            Property(x => x.instaLink)
.HasColumnName("instaLink")
.HasColumnType("nvarchar")

.IsOptional();
            Property(x => x.Whatsphon)
.HasColumnName("Whatsphon")
.HasColumnType("nvarchar")

.IsOptional();
            Property(x => x.Start)
            .HasColumnName("Start")
            .HasColumnType("date")

            .IsOptional();

            Property(x => x.end)
           .HasColumnName("end")
           .HasColumnType("date")

           .IsOptional();
            Property(x => x.photo)
           .HasColumnName("photo")
           .HasColumnType("varbinary(MAX)").IsOptional();
            Property(x => x.photo1)
         .HasColumnName("photo1")
         .HasColumnType("varbinary(MAX)").IsOptional();
            Property(x => x.photo2)
         .HasColumnName("photo2")
         .HasColumnType("varbinary(MAX)").IsOptional();
            Property(x => x.photo3)
         .HasColumnName("photo3")
         .HasColumnType("varbinary(MAX)").IsOptional();
            Property(x => x.Timeofpuplishing)
                .HasColumnName("Timeofpuplishing")
                .HasColumnType("time")
                .IsRequired();

            Property(x => x.Dateofpuplishing)
                 .HasColumnName("Dateofpuplishing")
                 .HasColumnType("date")
                 .IsRequired();

            HasRequired(x => x.SubCategetoryOffers)
              .WithMany(x => x.Offers)
              .HasForeignKey(x => x.SubCategetoryOffersId);

       

        }
    }
}
