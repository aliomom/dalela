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
  public  class BranchConfiguration: EntityTypeConfiguration<Branch>
    {
        internal BranchConfiguration()
        {
            ToTable("Branch");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.branchArabicName)
                .HasColumnName("branchArabicName")
                .HasColumnType("nvarchar")
                
                .IsOptional();


            Property(x => x.branchEnglishName)
                .HasColumnName("branchEnglishName")
                 .HasColumnType("nvarchar")
              
                .IsOptional();

            Property(x => x.branchFrenchName)
                .HasColumnName("branchFrenchName")
                .HasColumnType("nvarchar")
               
                .IsOptional();

            Property(x => x.branchPersianName)
                .HasColumnName("branchPersianName")
                .HasColumnType("nvarchar")
                 
                .IsOptional();

            Property(x => x.branchRussName)
                .HasColumnName("branchRussName")
            .HasColumnType("nvarchar")
               
                .IsOptional();
            Property(x => x.email1)
             .HasColumnName("email1")
         .HasColumnType("nvarchar")
            
             .IsOptional();
            Property(x => x.email2)
            .HasColumnName("email2")
        .HasColumnType("nvarchar")
       
            .IsOptional();
                    Property(x => x.phone1)
               .HasColumnName("phone1")
           .HasColumnType("nvarchar")
               
               .IsOptional();
                    Property(x => x.phone2)
           .HasColumnName("phone2")
        .HasColumnType("nvarchar")
           
           .IsOptional();
                    Property(x => x.phone3)
        .HasColumnName("phone3")
        .HasColumnType("nvarchar")
      
        .IsOptional();
                    Property(x => x.outDays)
        .HasColumnName("outDays")
        .HasColumnType("nvarchar")
    
        .IsOptional();
            Property(x => x.latitude)
                      .HasColumnName("latitude")
                      .HasColumnType("decimal").HasPrecision(18, 10);


            Property(x => x.longtitude)
                   .HasColumnName("longtitude")
                   .HasColumnType("decimal").HasPrecision(18, 10);


            Property(x => x.StartActiveTime)
           .HasColumnName("StartActiveTime")
           .HasColumnType("time");


                    Property(x => x.EndActiveTime)
               .HasColumnName("EndActiveTime")
             .HasColumnType("time");
            Property(x => x.facebookLink)
            .HasColumnName("facebookLink")
            .HasColumnType("nvarchar")

            .IsOptional();

            Property(x => x.instaLink)
            .HasColumnName("instaLink")
            .HasColumnType("nvarchar")

            .IsOptional();

            HasRequired(x => x.Neighborhood)
              .WithMany(x => x.Branchs)
              .HasForeignKey(x => x.NeighborhoodId);


            HasMany(x => x.ClientOffers)
          .WithRequired(x => x.Branch)
           .HasForeignKey(x => x.BranchId);

            HasMany(x => x.Breaks)
                .WithRequired(x => x.Branch)
                .HasForeignKey(x => x.BranchId);
            HasRequired(x => x.ShopDal)
              .WithMany(x => x.Branchs)
              .HasForeignKey(x => x.ShopDalId);

            HasMany(x => x.GalleryPhotos)
                .WithRequired(x => x.Branch)
                .HasForeignKey(x => x.BranchId);
        }
    }
}
