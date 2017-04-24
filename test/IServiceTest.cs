using Microsoft.Extensions.DependencyInjection.Scan;
using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    [ServiceRegisterDescriptor(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton)]
    public interface IServiceTest
    {
        void TestM();
    }

    public class ServiceTest : IServiceTest
    {
        public void TestM()
        {
            System.Console.WriteLine("servicetest imp");
        }
    }

    public class ServiceTest1:ServiceTest
    {

    }

    [ServiceRegisterDescriptor(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient,AllowMultipleImp =true)]
    public abstract class AbstractTest
    {
        public abstract void M();
    }

    public class AbstractImpTest: AbstractTest
    {
        public override void M()
        {
            System.Console.WriteLine("AbstractImpTest");
        }
    }

    public class AbImpTest1:AbstractImpTest
    {
        public override void M()
        {
            System.Console.WriteLine("AbImpTest1");
        }
    }

    public class AbImpTest2 : AbImpTest1
    {
        public override void M()
        {
            System.Console.WriteLine("AbImpTest2");
        }
    }

    [ServiceRegisterDescriptor(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped,AllowMultipleImp =true,GenericType =typeof(AbstractImpTest))]
    public interface IGenericTest<T>
    {
        
    }

    public class GenericTest<T>:IGenericTest<T>
    {

    }
}
