using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    [PrimaryKey("Id")]
    public abstract class BaseEntity : IBaseEntity
    {
        
        public int Id { get; set; }
    }
}
