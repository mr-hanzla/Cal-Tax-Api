
namespace Cal_Tax_Api.Services;

public static class TaxService
{
    public static string GetTaxInfo()
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
        return "null";
    }

    private static Tuple<double, double, double> GetTaxValuesForYearlyIncome(double yearlyIncome)
    {
        // Item1 ==> percentage of tax
        // Item2 ==> additional amount on income
        if (0 < yearlyIncome && yearlyIncome <= 600000)
            return Tuple.Create(0.0, 0.0, yearlyIncome - 0.0);
        else if (600000 < yearlyIncome && yearlyIncome <= 1200000)
            return Tuple.Create(2.5, 0.0, yearlyIncome - 600000.0);
        else if (1200000 < yearlyIncome && yearlyIncome <= 2400000.0)
            return Tuple.Create(12.5, 15000.0, yearlyIncome - 1200000.0);
        else if (2400000 < yearlyIncome && yearlyIncome <= 3600000)
            return Tuple.Create(20.0, 165000.0, yearlyIncome - 2400000.0);
        else if (3600000 < yearlyIncome && yearlyIncome <= 6000000)
            return Tuple.Create(25.0, 400000.0, yearlyIncome - 3600000.0);
        else if (6000000 < yearlyIncome && yearlyIncome <= 12000000)
            return Tuple.Create(32.5, 1005000.0, yearlyIncome - 6000000.0);
        else
            return Tuple.Create(35.0, 2955000.0, yearlyIncome - 12000000.0);
    }

    private static Tuple<double, double, double> GetTaxValuesForMonthlyIncome(double monthlyIncome)
    {
        return GetTaxValuesForYearlyIncome(GetYearlyIncome(monthlyIncome));
    }

    private static double CalculatePercentage(double val, double percentage)
    {
        return val * (percentage / 100);
    }

    public static double GetTaxAmountForMonthlyIncome(double monthlyIncome)
    {
        if (monthlyIncome < 0)
            return 0;
        // in the returned tuple,
        // Item1 ==> percentage of tax
        // Item2 ==> additional amount of tax
        // Item3 ==> taxable amount
        Tuple<double, double, double> taxValue = GetTaxValuesForMonthlyIncome(monthlyIncome);

        double taxPercentage = taxValue.Item1;
        double additionalTaxAmount = taxValue.Item2;
        double taxableAmount = taxValue.Item3;

        Console.WriteLine($"Returned Tuple: {taxValue}");

        return (CalculatePercentage(taxableAmount, taxPercentage) + additionalTaxAmount) / 12;
    }

    public static double GetMonthlyIncomeAfterTax(double monthlyIncome)
    {
        return monthlyIncome - GetTaxAmountForMonthlyIncome(monthlyIncome);
    }

    public static double GetYearlyIncomeAfterTax(double yearlyIncome)
    {
        return 0.0;
    }

    private static double GetYearlyIncome(double monthlyIncome)
    {
        return monthlyIncome * 12;
    }

    public static void GetAllTaxRelatedValues(double monthlyIncome)
    {
        // in the returned tuple,
        // Item1 ==> percentage of tax
        // Item2 ==> additional amount of tax
        // Item3 ==> taxable amount
        Tuple<double, double, double> taxValue = GetTaxValuesForMonthlyIncome(monthlyIncome);

        Dictionary<string, double> taxInfo = new Dictionary<string, double>();
        taxInfo.Add("taxPercentage", taxValue.Item1);
        taxInfo.Add("additionalTaxAmount", taxValue.Item2);
        taxInfo.Add("taxableAmount", taxValue.Item3);

        taxInfo.Add("yearlyIncome", GetYearlyIncome(monthlyIncome));
        taxInfo.Add("yearlyTax", (CalculatePercentage(taxableAmount, taxPercentage) + additionalTaxAmount));
        taxInfo.Add("yearlyIncomeAfterTax", taxInfo["yearlyIncome"] - taxInfo["yearlyTax"]);

        taxInfo.Add("monthlyIncome", monthlyIncome);
        taxInfo.Add("monthlyTax", taxInfo["yearlyTax"] / 12);
        taxInfo.Add("monthlyIncomeAfterTax", taxInfo["monthlyIncome"] - taxInfo["monthlyTax"]);
    }
}
