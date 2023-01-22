using Microsoft.AspNetCore.Mvc;
using Cal_Tax_Api.Services;
using Cal_Tax_Api.Models;
using Cal_Tax_Api.Utils;

namespace Cal_Tax_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxInfoController : ControllerBase
{
    public TaxInfoController() {}

    [HttpGet("2022/{monthlyIncome}")]
    public ActionResult<TaxInfo> GetTaxInfo(double monthlyIncome)
    {
        var taxInfo = TaxInfoService.GetAllTaxRelatedValues(monthlyIncome);
        return taxInfo;
    }
}
