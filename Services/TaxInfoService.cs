using Cal_Tax_Api.Utils;
using Cal_Tax_Api.Models;
namespace Cal_Tax_Api.Services;

public static class TaxInfoService
{
    public static string TestingMethod()
    {
        return $"Util is also working with value '{Util.TestingMethod()}' YAHOOOOO~~~!!!!";
    }
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
        return GetTaxValuesForYearlyIncome(Util.GetYearlyIncome(monthlyIncome));
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

        return (Util.CalculatePercentage(taxableAmount, taxPercentage) + additionalTaxAmount) / 12;
    }

    public static double GetMonthlyIncomeAfterTax(double monthlyIncome)
    {
        return monthlyIncome - GetTaxAmountForMonthlyIncome(monthlyIncome);
    }

    public static double GetYearlyIncomeAfterTax(double yearlyIncome)
    {
        return 0.0;
    }

    public static TaxInfo GetAllTaxRelatedValues(double monthlyIncome)
    {
        // in the returned tuple,
        // Item1 ==> percentage of tax
        // Item2 ==> additional amount of tax
        // Item3 ==> taxable amount
        Tuple<double, double, double> taxValue = GetTaxValuesForMonthlyIncome(monthlyIncome);

        Dictionary<string, double> taxInfoDict = new Dictionary<string, double>();
        taxInfoDict.Add("taxPercentage", taxValue.Item1);
        taxInfoDict.Add("additionalTaxAmount", taxValue.Item2);
        taxInfoDict.Add("taxableAmount", taxValue.Item3);

        taxInfoDict.Add("yearlyIncome", Util.GetYearlyIncome(monthlyIncome));
        taxInfoDict.Add("yearlyTax", (Util.CalculatePercentage(
            taxInfoDict["taxableAmount"],
            taxInfoDict["taxPercentage"]) + taxInfoDict["additionalTaxAmount"]
            ));
        taxInfoDict.Add("yearlyIncomeAfterTax", taxInfoDict["yearlyIncome"] - taxInfoDict["yearlyTax"]);

        taxInfoDict.Add("monthlyIncome", monthlyIncome);
        taxInfoDict.Add("monthlyTax", taxInfoDict["yearlyTax"] / 12);
        taxInfoDict.Add("monthlyIncomeAfterTax", taxInfoDict["monthlyIncome"] - taxInfoDict["monthlyTax"]);

        TaxInfo taxInfo = new TaxInfo();

        taxInfo.TaxPercentage = taxValue.Item1;
        taxInfo.AdditionalTaxAmount = taxValue.Item2;
        taxInfo.TaxableAmount = taxValue.Item3;

        taxInfo.YearlyIncome = Util.GetYearlyIncome(monthlyIncome);
        taxInfo.YearlyTax = Util.CalculatePercentage(taxInfo.TaxableAmount, taxInfo.TaxPercentage) + taxInfo.AdditionalTaxAmount;
        taxInfo.YearlyIncomeAfterTax = taxInfo.YearlyIncome - taxInfo.YearlyTax;

        taxInfo.MonthlyIncome = monthlyIncome;
        taxInfo.MonthlyTax = taxInfo.YearlyTax / 12;
        taxInfo.MonthlyIncomeAfterTax = taxInfo.MonthlyIncome - taxInfo.MonthlyTax;

        return taxInfo;
    }
}
