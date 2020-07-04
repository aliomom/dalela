using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using NawafizApp.Domain.Entities;

namespace NawafizApp.Data.Configuration
{
    internal class GalleryPhotoConfiguration: EntityTypeConfiguration<GalleryPhoto>
    {
        internal GalleryPhotoConfiguration()
        {
            ToTable("GalleryPhoto");
            HasKey(x => x.Id)
             .Property(x => x.Id)
             .HasColumnName("Id")
            .HasColumnType("int")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.photo)
                .HasColumnName("photo")
                .HasColumnType("varbinary(MAX)");
            HasRequired(x => x.Branch)
                .WithMany(x => x.GalleryPhotos)
                .HasForeignKey(x => x.BranchId);
        }
    }
}
