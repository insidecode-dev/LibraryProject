using LibraryProject.Models.MetaDataTypes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    [ModelMetadataType(typeof(BookTypeMetaData))]
    public class BookTypes:BaseEntity
    {        
        public string Name { get; set; }
        //relational properties
        public List<Books>? Books { get; set; }           
    }
}
