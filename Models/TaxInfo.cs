namespace Cal_Tax_Api.Models;

public class TaxInfo
{
    public int Id { get; set; }
    public double TaxPercentage { get; set; }
    public double AdditionalTaxAmount { get; set; }
    public double TaxableAmount { get; set; }
    public double YearlyIncome { get; set; }
    public double YearlyTax { get; set; }
    public double YearlyIncomeAfterTax { get; set; }
    public double MonthlyIncome { get; set; }
    public double MonthlyTax { get; set; }
    public double MonthlyIncomeAfterTax { get; set; }
}
