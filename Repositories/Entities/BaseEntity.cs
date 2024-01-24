using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    [PrimaryKey("Id")]
    public class BaseEntity : IBaseEntity
    {
        
        public int Id { get; set; }
    }
}
