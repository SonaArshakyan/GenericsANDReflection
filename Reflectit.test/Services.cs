using System;
using System.Collections.Generic;
using System.Text;
using GenericsANDTypeParametrs;

namespace Reflectit.test
{
    public interface ILogger { }
    public class SqlServerLogger : ILogger
    {
    }
    public interface IRepository<T> { }
    public class SqlRepository<T> : IRepository<T>
    {
        public SqlRepository(ILogger logger)
        {

        }
    }
    public class InvoiceService
    {
        public InvoiceService(IRepository<Customer> repository, ILogger logger)
        {

        }
    }
}
