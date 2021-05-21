using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsANDTypeParametrs
{
    public class Person
    {
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
    public class Employee: Person
    {
        public int IdEmployee { get; set; }
        public decimal Salary { get; set; }
    }
    public class Customer
    {

    }

}
