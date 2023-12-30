using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LibraryProject.Configurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operations>
    {
        public void Configure(EntityTypeBuilder<Operations> builder)
        {
            // ignores this property from setting as column
            builder
                .Ignore("ID");

            //"StudentsID", "BooksID"
            builder
                .HasKey(a => new { a.StudentsID, a.BooksID });


            // relations
            //many-to-many

            // sets a name to table in Database
            builder
                .ToTable("Əməliyyatlar");

            builder
                .HasOne(a => a.Students)
                .WithMany(a => a.Operations)
                .HasForeignKey(a => a.StudentsID);

            builder
                .HasOne(a => a.Books)
                .WithMany(a => a.Operations)
                .HasForeignKey(a => a.BooksID);
        }
    }
}
