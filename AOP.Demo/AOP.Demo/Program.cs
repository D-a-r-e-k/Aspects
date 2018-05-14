using AOP.Demo.Logic;

namespace AOP.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            var service = new CalculationService();

            service.CalculateTaxes(22);
        }
    }
}
