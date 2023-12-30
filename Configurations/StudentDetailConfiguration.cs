using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.Configurations
{
    public class StudentDetailConfiguration : IEntityTypeConfiguration<StudentDetail>
    {
        public void Configure(EntityTypeBuilder<StudentDetail> builder)
        {
            builder
                .Property(x=>x.PhoneNumber)
                .HasColumnName("Telefon Nömrəsi")
                .IsRequired(false);
        }
    }
}
