using AOP.Demo.Aspects;

namespace AOP.Demo.Logic
{
    public class CalculationService
    {
        [InspectionAspect]
        public decimal CalculateTaxes(decimal param)
        {
            return 23;
        }
    }
}
