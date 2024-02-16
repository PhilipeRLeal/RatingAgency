
namespace Data.Entities
{
    public class Proposal: BaseEntity
    {

        public string Description { get; set; }

        public string Client { get; set; }

        public Rating Rating { get; set; }
    }
}
