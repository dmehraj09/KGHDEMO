using ServiceStack.DataAnnotations;
using System;

namespace Backend.ServiceInterface.Models
{
    public abstract class BaseEntity
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string AddedDate { get; set; }
        public string ModifiedDate { get; set; }        
    }
}
