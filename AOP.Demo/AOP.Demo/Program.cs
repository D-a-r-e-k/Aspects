using AOP.Demo.Logic;
using System;

namespace AOP.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            var service = new CalculationService();

            service.CalculateTaxes(22);
            service.Transfer("Jonas", "AC1", 2);
            //
            //service.Transfer("Hana", "AC2", 1);

            var store = new Store();
            ((ICountable)store).Inc();
            Console.WriteLine(((ICountable)store).GetCount());

            Console.ReadKey();
        }
    }
}
