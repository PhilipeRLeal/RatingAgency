

namespace Data.Entities
{
    public class Insurance: BaseEntity
    {
        public Rating Rate { get; set; }

        public double Value { get; set; }
    }
}
