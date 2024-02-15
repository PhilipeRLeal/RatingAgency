using Business_Layer;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("RateTypes")]
    public class RateEnumType: BaseEnumWithEntity
    {

        public RateEnumType(): base() { }

        public RateEnumType(string name) : base(name)
        {
            
        }
    }
}