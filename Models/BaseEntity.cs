using LibraryProject.Enums;
using Microsoft.Build.Framework;

namespace LibraryProject.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            DataStatus = DataStatus.Inserted;
        }
        
        public int ID { get; set; }
        //audit properties
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}   
