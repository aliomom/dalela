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
   public class MainCategoryDalConfiguration: EntityTypeConfiguration<MainCategoryDal>
    {

        internal MainCategoryDalConfiguration()
        {
            ToTable("MainCategoryDal");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

          

           
            Property(x => x.num)
             .HasColumnName("num")
         .HasColumnType("int")
              
             .IsOptional();
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
            Property(x => x.icon)
           .HasColumnName("icon")
           .HasColumnType("varbinary(MAX)").IsOptional();
            Property(x => x.iconEn)
          .HasColumnName("iconEn")
          .HasColumnType("varbinary(MAX)").IsOptional();

            Property(x => x.iconFr)
        .HasColumnName("iconFr")
        .HasColumnType("varbinary(MAX)").IsOptional();
            Property(x => x.iconPersian)
        .HasColumnName("iconPersian")
        .HasColumnType("varbinary(MAX)").IsOptional();
            Property(x => x.iconRuss)
        .HasColumnName("iconRuss")
        .HasColumnType("varbinary(MAX)").IsOptional();
            HasMany(x => x.SubCategoryDals)
      .WithRequired(x => x.MainCategoryDal)
       .HasForeignKey(x => x.MainCategoryDalId);

        }
    }
}
