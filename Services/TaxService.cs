
namespace Cal_Tax_Api.Services;

public static class TaxService
{
    static double InputTax { get; set; }

    static TaxService()
    {

    }

    public static string? GetTaxInfo()
    {
        /*
                    [YEAR 2022-2023]
        1) salary <= 600,000                --> 0%
        2) 600,000 < salary <= 1,200,000    --> 2.5%
        3) 1,200,000 < salary <= 2,400,000  --> 15,000 + 12.5%
        4) 2,400,000 < salary <= 3,600,000  --> 165,000 + 20.0%
        5) 3,600,000 < salary <= 6,000,000  --> 400,000 + 25.0%
        6) 6,000,000 < salary <= 12,000,000 --> 1,005,000 + 32.5%
        7) 12,000,000 < salary              --> 2,955,000 + 35.0%
        */
        return null;
    }

    public static double GetPercentageValueForIncome(double monthlyIncome)
    {
        // monthlyIncome <= 600,000                --> 0%
        if (monthlyIncome <= 600000)
            return 0;
        // 600,000 < monthlyIncome <= 1,200,000    --> 2.5%
        else if (600000 < monthlyIncome && monthlyIncome <= 1200000)
            return 2.5;
        // 1,200,000 < monthlyIncome <= 2,400,000  --> 15,000 + 12.5%
        else if (1200000 < monthlyIncome && monthlyIncome <= 2400000)
            return 12.5;
        // 2,400,000 < monthlyIncome <= 3,600,000  --> 165,000 + 20.0%
        else if (2400000 < monthlyIncome && monthlyIncome <= 3600000)
            return 12.5;
        // 3,600,000 < monthlyIncome <= 6,000,000  --> 400,000 + 25.0%
        else if (3600000 < monthlyIncome && monthlyIncome <= 6000000)
            return 12.5;
        // 6,000,000 < monthlyIncome <= 12,000,000 --> 1,005,000 + 32.5%
        else if (6000000 < monthlyIncome && monthlyIncome <= 1005000)
            return 12.5;
        // 12,000,000 < monthlyIncome              --> 2,955,000 + 35.0%
        else
            return 35.0;
    }

    public static double CalculatePercentageValue(double val, double percentage)
    {
        if (percentage == 0)
            return val;
        return val * (percentage / 100);
    }

    public static double? GetMonthlyTaxAmount(double monthlyIncome)
    {
        if (monthlyIncome < 0)
            return null;
        return 0.0;
    }

    public static double GetMonthlyIncomeAfterTax(double monthlyIncome)
    {
        return 0.0;
    }

    public static double GetYearlyIncomeAfterTax(double yearlyIncome)
    {
        return 0.0;
    }

    public static double GetYearlyIncomeAmount(double monthlyIncome)
    {
        return monthlyIncome * 12;
    }
}
