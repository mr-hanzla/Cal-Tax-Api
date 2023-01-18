
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
