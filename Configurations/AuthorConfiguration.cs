using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LibraryProject.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Authors>
    {
        public void Configure(EntityTypeBuilder<Authors> builder)
        {
            builder
                .ToTable("Yazıçı");

            //sets a name to column in table 
            builder
                .Property(a => a.FirstName).HasColumnName("Ad");

            builder
                .Property(a => a.LastName)
                .HasColumnName("SoyAd");
        }
    }
}
