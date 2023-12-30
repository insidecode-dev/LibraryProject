//using Microsoft.Build.Framework;
using LibraryProject.Models.MetaDataTypes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    [ModelMetadataType(typeof(AuthorMetaData))]
    public class Authors:BaseEntity
    {
        public string FirstName { get; set; }        
        public string LastName { get; set; }        
        //relational properties
        public List<Books>? Books { get; set; }
    }
}
