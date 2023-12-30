using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder
                .Property(a => a.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder
                .Property(a => a.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder
                .HasOne(x => x.StudentDetail)
                .WithOne(x => x.Students)
                .HasForeignKey<StudentDetail>(x => x.StudentsID);


        }
    }
}
