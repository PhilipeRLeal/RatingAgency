namespace Repositories.Entities
{
    public class Rating: BaseEntity
    {
        public RateTypesEnum Rate { get; set; }

        public Rating() { }


    }
}