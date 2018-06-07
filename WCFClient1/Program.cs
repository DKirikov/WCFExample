using System;
using System.Linq;
using WCFClient1.ServiceReference1;

namespace WCFClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inside Program::Main");

            Service1Client client = new Service1Client();
            var callsCount = client.get_CallsCount();
            Console.WriteLine("CallsCount = " + callsCount.ToString());

            Test1 testObj = new Test1();
            testObj.name = args.Count() > 0 ? args[0] : "no name";
            string returnValue = client.SetTestObject(testObj);
            Console.WriteLine("Return value = " + returnValue);

            Console.ReadKey();
            client.Close();
        }
    }
}
