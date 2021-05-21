using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsANDTypeParametrs
{
    //subscriber
    public delegate void Notify(string mess);

    //publisher
    public class RaiseEvenet
    {
        public event Notify CallStarted;
        public void CallMe(string mess)
        {
            CallStarted?.Invoke(mess);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {

            //List<string> strCollection = new List<string> { "1", "2" };
            //List<object> objCollection = strCollection;  // pretending it can be so  lets see what will happen =>
            //objCollection.Add(new Program());
            //string value = strCollection[2];

            //working with events
            dynamic obj = new ExpandoObject();
            obj.Test = "test";
            RaiseEvenet evenetClass = new RaiseEvenet();
            evenetClass.CallStarted += EvenetClass_ProcessCompleted;
            evenetClass.CallMe("Sona");
            Console.WriteLine(obj.Test);

            //Example of Covariance  <out T >
            IRepository<Employee> repository = new Repository<Employee>();
            IEnumerable<Person> personsList = repository.GetData();

            IRepository<Person> repositoryP = new Repository<Person>();
            repositoryP.AddData(new Employee());

            //Example of Contravariance <in T >
            Action<object> intact = Test;
            Action<string> strAct = intact;
            void Test(object i)
            {
            }
            intact(new object());
            strAct("test");
        }
        private static void EvenetClass_ProcessCompleted(string mess)
        {
            Console.WriteLine($"Hi {mess} i am your function. Thanks for calling me");
        }
    }


}
