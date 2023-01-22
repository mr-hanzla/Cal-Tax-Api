namespace Cal_Tax_Api.Utils;

public static class Util
{
    public static double CalculatePercentage(double val, double percentage)
    {
        return val * (percentage / 100);
    }

    public static double GetYearlyIncome(double monthlyIncome)
    {
        return monthlyIncome * 12;
    }

    public static double TestingMethod()
    {
        return 16516.51651;
    }
}