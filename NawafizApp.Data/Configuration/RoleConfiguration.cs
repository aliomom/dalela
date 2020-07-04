using NawafizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Data.Configuration
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        internal RoleConfiguration()
        {
            ToTable("Role");

            HasKey(x => x.RoleId)
                .Property(x => x.RoleId)
                .HasColumnName("RoleId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();
            Property(x => x.Addbranches)
        .HasColumnName("Addbranches")
        .HasColumnType("bit")
        .IsRequired();

            Property(x => x.Addnotifications)
            .HasColumnName("Addnotifications")
            .HasColumnType("bit")
            .IsRequired();
            Property(x => x.AddOffers)
            .HasColumnName("AddOffers")
            .HasColumnType("bit")
            .IsRequired();
            Property(x => x.numOfBranches)
         .HasColumnName("numOfBranches")
         .HasColumnType("int")
         .IsRequired();
            Property(x => x.AddCustomeNotifications)
         .HasColumnName("AddCustomeNotifications")
         .HasColumnType("bit")
         .IsRequired();
            Property(x => x.NumberOfImagesAddedToranches)
         .HasColumnName("NumberOfImagesAddedToranches")
         .HasColumnType("int")
         .IsRequired();
            Property(x => x.Numberofpictures)
           .HasColumnName("Numberofpictures")
           .HasColumnType("int")
           .IsRequired();

            HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .Map(x =>
                {
                    x.ToTable("UserRole");
                    x.MapLeftKey("RoleId");
                    x.MapRightKey("UserId");
                });
        }
    }
}
