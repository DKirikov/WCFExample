using System;
using System.ServiceModel;

namespace WCFService1
{
    public class Test1
    {
        public object name;
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        private int callsCount = 0;
        private string lastName = "none";

        public int CallsCount
        {
            get
            {
                callsCount++;
                return callsCount;
            }
        }

        public String SetTestObject(Test1 testObject)
        {
            if (testObject.name is String)
            {
                string res = "last name: '" + lastName + "' new name: '" + (testObject.name as string) + "'";
                lastName = testObject.name as string;
                return res;
            }
            
            throw new Exception("testObject.name is not String");
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
