using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.DTO
{
    public class AuthorDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
