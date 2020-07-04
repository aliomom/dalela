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
   public class FollowerConfiguration: EntityTypeConfiguration<Follower>
    {
        internal FollowerConfiguration()
        {
            ToTable("Follower");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(x => x.ShopDals)
                           .WithMany(x => x.Followers)
                           .Map(x =>
                           {

                               x.ToTable("Follower_ShopDal");
                               x.MapLeftKey("FId");
                               x.MapRightKey("SId");
                           });
            HasRequired(x => x.User)
                .WithOptional(x => x.Follower)
                ;
        }
    }
}
