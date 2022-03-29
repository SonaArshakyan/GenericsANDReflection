using System.Collections.Generic;

namespace GenericsANDTypeParametrs
{
    public interface IGetDataRepository<out T> //it enebales to return more derived types than  that specified by the generic parameter
    {
        T GetDataById();
        IEnumerable<T> GetData();
    }
}
