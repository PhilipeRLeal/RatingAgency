using Data.Entities;
using System.Reflection;

namespace Business_Layer
{
    public abstract class AbsBaseEnum: IBaseEnum
    {
        public string Name { get; set; }

        public IEnumerable<T> GetDefaultRoles<T>() where T : class
        {

            Type thisType = this.GetType();
            var fields = thisType.GetFields(BindingFlags.Static | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                var value = field.GetValue(this) as T;
                if (value != null)
                {
                    yield return value;
                }
            }

        }
    }
}