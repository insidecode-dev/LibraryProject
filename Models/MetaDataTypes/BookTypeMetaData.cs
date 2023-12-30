using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models.MetaDataTypes
{    
    public class BookTypeMetaData
    {
        [Required(ErrorMessage = "important")]
        [MaxLength(15, ErrorMessage = "max xharacter size is 15")]
        public string Name { get; set; }
    }
}
