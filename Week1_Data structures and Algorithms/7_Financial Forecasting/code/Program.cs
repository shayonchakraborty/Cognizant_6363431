using System;

class Program
{
    static void Main(string[] args)
    {
        double initialAmount = 1000.0;
        double growthRate = 0.05; 
        int years = 5;

        double forecastedValue = ForecastValue(initialAmount, growthRate, years);
        Console.WriteLine($"Forecasted value after {years} years: {forecastedValue:F2}");
    }

    static double ForecastValue(double amount, double rate, int years)
    {
        if (years == 0)
            return amount;
        return ForecastValue(amount * (1 + rate), rate, years - 1);
    }
}
