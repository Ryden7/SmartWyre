using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Helper;
using Smartwyre.DeveloperTest.Types;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly RebateDataStore rebateDataStore;
    private readonly ProductDataStore productDataStore;

    public RebateService()
    {
        rebateDataStore = new RebateDataStore();
        productDataStore = new ProductDataStore();
    }
    public async Task<CalculateRebateResult> Calculate(CalculateRebateRequest request)
    {
        var rebate = await rebateDataStore.GetRebate(request.RebateIdentifier);
        var product = await productDataStore.GetProduct(request.ProductIdentifier);

        var type = HelperFunctions.GetIncentiveTypeAsEnum(rebate);

        var result = new CalculateRebateResult();

        if (rebate == null || product == null)
        {
            result.Success = false;
            return result; ;
        }

        var rebateAmount = 0m;

        switch (rebate.Incentive)
        {
            case IncentiveType.FixedCashAmount:
                if (rebate == null)
                {
                    result.Success = false;
                }
                else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
                {
                    result.Success = false;
                }
                else if (rebate.Amount == 0)
                {
                    result.Success = false;
                }
                else
                {
                    rebateAmount = rebate.Amount;
                    result.Success = true;
                }
                break;

            case IncentiveType.FixedRateRebate:
                if (rebate == null)
                {
                    result.Success = false;
                }
                else if (product == null)
                {
                    result.Success = false;
                }
                else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
                {
                    result.Success = false;
                }
                else if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
                {
                    result.Success = false;
                }
                else
                {
                    rebateAmount += product.Price * rebate.Percentage * request.Volume;
                    result.Success = true;
                }
                break;

            case IncentiveType.AmountPerUom:
                if (rebate == null)
                {
                    result.Success = false;
                }
                else if (product == null)
                {
                    result.Success = false;
                }
                else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
                {
                    result.Success = false;
                }
                else if (rebate.Amount == 0 || request.Volume == 0)
                {
                    result.Success = false;
                }
                else
                {
                    rebateAmount += rebate.Amount * request.Volume;
                    result.Success = true;
                }
                break;
        }

        if (result.Success)
        {
            rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }
}
