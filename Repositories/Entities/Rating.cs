namespace Repositories.Entities
{
    public class Rating: BaseEntity
    {
        public RateTypes Rate { get; set; }

        public Rating() { }


    }
}