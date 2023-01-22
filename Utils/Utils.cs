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

    public static void show(int val, string msg="")
    {
        Console.WriteLine($"{msg}{val}");
    }

    public static void show(float val, string msg="")
    {
        Console.WriteLine($"{msg}{val}");
    }

    public static void show(double val, string msg="")
    {
        Console.WriteLine($"{msg}{val}");
    }

    public static void show(string val, string msg="")
    {
        Console.WriteLine($"{msg}{val}");
    }
}