using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsANDTypeParametrs
{
    interface IRepository<T>: IGetDataRepository<T> , IWriteDataRepository<T>
    {
    }
    public class Repository<T> : IRepository<T>
    {
        public void AddData(T data)
        { 
            throw new NotImplementedException();
        }

        public void DeleteData(T data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetData()
        {
            throw new NotImplementedException();
        }

        public T GetDataById()
        {
            throw new NotImplementedException();
        }
    }

    public class GetDataRepository<T> : IGetDataRepository<T>
    {
        public IEnumerable<T> GetData()
        {
            throw new NotImplementedException();
        }

        public T GetDataById()
        {
            throw new NotImplementedException();
        }
    }
    public class WriteDataRepository<T> : IWriteDataRepository<T>
    {
        public void AddData(T data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(T data)
        {
            throw new NotImplementedException();
        }
    }
}
