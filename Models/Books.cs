using System.Net;

namespace LibraryProject.Models
{
    public class Books:BaseEntity 
    {       
        public string Name { get; set; }
        public string PageCount { get; set; }
        public int AuthorsID { get; set; }
        public int BookTypesID { get; set; }
        //relational properties
        public Authors? Authors { get; set; }
        public BookTypes? BookTypes { get; set; }
        public List<Operations>? Operations { get; set; }
    }
}
