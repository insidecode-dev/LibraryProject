using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models.MetaDataTypes
{
    public class AuthorMetaData
    {
        [Required(ErrorMessage = "important")]
        [MaxLength(15, ErrorMessage = "max character size is 15")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "important")]
        [MaxLength(15, ErrorMessage = "max character size is 15")]
        public string LastName { get; set; }
    }
}
