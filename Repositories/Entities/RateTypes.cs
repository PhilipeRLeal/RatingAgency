using Business_Layer;
using System.Xml.Linq;

namespace Repositories.Entities
{
    public class RateTypes: BaseEnum
    {
        public RateTypes(): base() { }

        public RateTypes(string name) : base(name)
        {
            
        }
    }
}