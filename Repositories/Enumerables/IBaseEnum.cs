
namespace Business_Layer
{
    public interface IBaseEnum
    {
        string Name { get; set; }

        IEnumerable<T> GetDefaultRoles<T>() where T : class;
    }
}