namespace SalaryCalculator
{
    public class SalaryCalc
    {
        public static double CalculateNetSalary(double basicSalary)
        {
            if (basicSalary <= 0)
            {
                throw new ArgumentException("Basic salary must be greater than zero.");
            }

            double hra = 0.20 * basicSalary;
            double da = 0.10 * basicSalary;

            double pf = (basicSalary >= 15000) ? 0.12 * basicSalary : 0;

            double netSalary = basicSalary + hra + da - pf;
            return netSalary;
        }
    }
}
