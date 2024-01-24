using Repositories.Entities;

namespace Business_Layer
{
    public class BaseEnum: BaseEntity
    {

        public string Name { get; set; }

        public BaseEnum()
        {
        }

        public BaseEnum(string name)
        {
            Name = name;
        }

    }
}
