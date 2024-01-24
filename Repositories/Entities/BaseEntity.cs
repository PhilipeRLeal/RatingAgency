using Microsoft.EntityFrameworkCore;

namespace Repositories.Entities
{
    [PrimaryKey("Id")]
    public class BaseEntity : IBaseEntity
    {
        
        public int Id { get; set; }
    }
}
