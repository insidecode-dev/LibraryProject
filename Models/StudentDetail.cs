using LibraryProject.Enums;

namespace LibraryProject.Models
{
    public class StudentDetail:BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string SchoolNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int StudentsID { get; set; }
        //relational property
        public Students Students { get; set; }
    }
}
