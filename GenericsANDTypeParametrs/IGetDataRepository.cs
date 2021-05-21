using System.Collections.Generic;

namespace GenericsANDTypeParametrs
{
    public interface IGetDataRepository<out T> //  less derived
    {
        T GetDataById();
        IEnumerable<T> GetData();
    }
}
