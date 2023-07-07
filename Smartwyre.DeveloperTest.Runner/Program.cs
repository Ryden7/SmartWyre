using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    async static Task Main(string[] args)
    {
        var rebateService = new RebateService();
        var calculateRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "test",
            RebateIdentifier = "test",
            Volume = 1
        };

        var result =  await Calculate(rebateService, calculateRequest);
    }

    public async static Task<CalculateRebateResult> Calculate (RebateService rebateService, CalculateRebateRequest calculateRequest)
    {
        var success = await rebateService.Calculate(calculateRequest);
        return success;

    }
}
