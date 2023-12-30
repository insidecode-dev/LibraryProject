using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            //one-to-many
            builder
                .HasOne(a => a.Authors)
                .WithMany(a => a.Books)
                .HasForeignKey(a => a.AuthorsID);

            //one-to-many
            builder
                .HasOne(a => a.BookTypes)
                .WithMany(a => a.Books)
                .HasForeignKey(a => a.BookTypesID);
        }
    }
}