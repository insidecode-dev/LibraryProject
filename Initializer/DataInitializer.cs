using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Initializer
{
    public static class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            string password1 = BCrypt.Net.BCrypt.HashPassword("123");
            string password2 = BCrypt.Net.BCrypt.HashPassword("1234");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { ID = 1, UserName = "adminstrator", Password = password1, Role = Enums.Role.admin },
                new AppUser { ID = 2, UserName = "insidecode", Password = password2, Role = Enums.Role.user }
                );

            modelBuilder.Entity<Students>().HasData(
                 new Students { ID = 1, FirstName = "Turqut", LastName = "Mehdiyev", Gender = Enums.Gender.Man },
                 new Students { ID = 2, FirstName = "Hüseyin", LastName = "Aliyev", Gender = Enums.Gender.Man },
                 new Students { ID = 3, FirstName = "Səbinə", LastName = "Mirzoyeva", Gender = Enums.Gender.Woman }
                );

            modelBuilder.Entity<StudentDetail>().HasData(
                new StudentDetail { ID = 1, StudentsID = 1, SchoolNumber = "100", BirthDate = new DateTime(2005, 2, 2) },
                new StudentDetail { ID = 2, StudentsID = 2, SchoolNumber = "101", BirthDate = new DateTime(2006, 3, 17) },
                new StudentDetail { ID = 3, StudentsID = 3, SchoolNumber = "100", BirthDate = new DateTime(2005, 2, 2) }
                );
        }
    }
}
