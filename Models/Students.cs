using LibraryProject.Enums;

namespace LibraryProject.Models
{
    public class Students:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SchoolNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string? PhoneNumber { get; set; }        
        //relational properties 
        public List<Operations> Operations { get; set; }
        public StudentDetail StudentDetail { get; set; }

    }
}
