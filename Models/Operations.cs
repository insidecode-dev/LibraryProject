namespace LibraryProject.Models
{
    public class Operations:BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StudentsID { get; set; }
        public int BooksID { get; set; }
        //realtional prrperties
        public Students Students { get; set; }
        public Books Books { get; set; }
    }
}
