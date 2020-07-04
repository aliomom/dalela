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
  public  class ShopDalConfiguration : EntityTypeConfiguration<ShopDal>
    {
        internal ShopDalConfiguration()
        {
            ToTable("ShopDal");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ArabicName)
                .HasColumnName("ArabicName")
                .HasColumnType("nvarchar")
   
                .IsOptional();

            Property(x => x.EngName)
                .HasColumnName("EngName")
                 .HasColumnType("nvarchar")
            
                .IsOptional();

            Property(x => x.FrenchName)
                .HasColumnName("FrenchName")
                 .HasColumnType("nvarchar")
             
                .IsOptional();

            Property(x => x.PersianName)
                .HasColumnName("PersianName")
                .HasColumnType("nvarchar")
      
                .IsOptional();

            Property(x => x.RussName)
                .HasColumnName("RussName")
            .HasColumnType("nvarchar")
                .IsOptional();

            Property(x => x.ArabicinvesterName)
             .HasColumnName("ArabicinvesterName")
         .HasColumnType("nvarchar")
     
             .IsOptional();

            Property(x => x.EnginvesterName)
            .HasColumnName("EnginvesterName")
            .HasColumnType("nvarchar")
            
            .IsOptional();

            Property(x => x.FrenchinvesterName)
       .HasColumnName("FrenchinvesterName")
      .HasColumnType("nvarchar")
      
       .IsOptional();

               Property(x => x.PersianinvesterName)
             .HasColumnName("PersianinvesterName")
             .HasColumnType("nvarchar")
   
              .IsOptional();

            Property(x => x.RussinvesterName)
                .HasColumnName("RussinvesterName")
                .HasColumnType("nvarchar")

                .IsOptional();


            HasOptional(x => x.User)
                .WithMany(x => x.ShopDals)
                .HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            HasMany(x => x.Branchs)
                 .WithRequired(x => x.ShopDal)
                  .HasForeignKey(x => x.ShopDalId);

            HasRequired(x => x.SubCategoryDal)
             .WithMany(x => x.ShopDals)
             .HasForeignKey(x => x.SubCategoryDalId);
            HasMany(x => x.Followers)
                      .WithMany(x => x.ShopDals)
                      .Map(x =>
                      {

                          x.ToTable("Follower_ShopDal");
                          x.MapLeftKey("SId");
                          x.MapRightKey("FId");
                      });

        }
    }
}
