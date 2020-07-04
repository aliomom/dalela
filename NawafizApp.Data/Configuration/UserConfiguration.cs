using NawafizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Data.Configuration
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        internal UserConfiguration()
        {
            ToTable("User");

            HasKey(x => x.UserId)
                .Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsOptional();

            Property(x => x.EmailConfirmed)
                .HasColumnName("EmailConfirmed")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.PhoneNumberConfirmed)
                .HasColumnName("PhoneNumberConfirmed")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.TwoFactorEnabled)
                .HasColumnName("TwoFactorEnabled")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.LockoutEndDateUtc)
                .HasColumnName("LockoutEndDateUtc")
                .HasColumnType("datetime")
                .HasPrecision(23)
                .IsOptional();

            Property(x => x.LockoutEnabled)
                .HasColumnName("LockoutEnabled")
                .HasColumnType("bit")
                .IsRequired();
            Property(x => x.hasToken)
               .HasColumnName("hasToken")
               .HasColumnType("bit")
               .IsRequired();
      
            Property(x => x.Addbranches)
            .HasColumnName("Addbranches")
            .HasColumnType("bit")
            .IsOptional();
            Property(x => x.AddCustomeNotifications)
       .HasColumnName("AddCustomeNotifications")
       .HasColumnType("bit")
       .IsOptional();

            Property(x => x.Addnotifications)
            .HasColumnName("Addnotifications")
            .HasColumnType("bit")
            .IsOptional();
            Property(x => x.AddOffers)
            .HasColumnName("AddOffers")
            .HasColumnType("bit")
            .IsOptional();
            Property(x => x.CreationDate)
              .HasColumnName("CreationDate")
              .HasColumnType("date")
              
              .IsRequired();
            Property(x => x.numOfBranches)
             .HasColumnName("numOfBranches")
             .HasColumnType("int")
             .IsOptional();
            Property(x => x.AccessFailedCount)
                .HasColumnName("AccessFailedCount")
                .HasColumnType("int")
                .IsRequired();
            Property(x => x.NumberOfImagesAddedToranches)
              .HasColumnName("NumberOfImagesAddedToranches")
              .HasColumnType("int")
              .IsOptional();
            Property(x => x.Numberofpictures)
           .HasColumnName("Numberofpictures")
           .HasColumnType("int")
           .IsOptional();
            Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.FullName)
                .HasColumnName("FullName")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .Map(x =>
                {
                    x.ToTable("UserRole");
                    x.MapLeftKey("UserId");
                    x.MapRightKey("RoleId");
                });
            HasMany(x => x.Favourites)
                .WithMany(x => x.Users)
                .Map(x =>
                {

                    x.ToTable("User_Favourite");
                    x.MapLeftKey("userId");
                    x.MapRightKey("favouritId");
                });
            HasMany(x => x.Claims)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);

            HasMany(x => x.Logins)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);


            HasMany(x => x.DeviceTokens)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);
            HasMany(x => x.Notifications)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.RevieverId);
            HasOptional(x => x.Follower)
                     .WithRequired(x => x.User);
            HasMany(x => x.ShopDals)
                .WithOptional(x => x.User)
                .HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
        }
    }
}
