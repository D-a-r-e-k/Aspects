using AOP.Demo.Aspects;
using System;

namespace AOP.Demo.Logic
{
    public class CalculationService
    {
        [InspectionAspect]
        public decimal CalculateTaxes(decimal param)
        {
            return 23;
        }

        [AuthorizationAspect]
        public void Transfer(string user, string accountNo, int sum)
        {
            Console.WriteLine($"{user} {accountNo} {sum}");
        }
    }
}
