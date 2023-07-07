using Microsoft.EntityFrameworkCore;
using Smartwyre.DeveloperTest.Types;
using System.Linq;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    private readonly RebateContext dbContext;

    public RebateDataStore()
    {
        this.dbContext = new RebateContext();
    }

    /// <summary>
    /// Method to access database and retrieve a rebate
    /// </summary>
    /// <param name="rebateIdentifier"></param>
    /// <returns></returns>
    public async Task<Rebate> GetRebate(string rebateIdentifier)
    {
            var rebate = await dbContext.Rebate
                                          .Where(s => s.Identifier == rebateIdentifier)
                                          .SingleOrDefaultAsync();

            if (rebate != null)
                return rebate;

            return null;
    }

    /// <summary>
    /// Get Rebate account and update the rebateAmount from db
    /// </summary>
    /// <param name="account"></param>
    /// <param name="rebateAmount"></param>
    public async void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        var rebateCalc = new RebateCalculation()
        {
            Amount = rebateAmount,
            RebateIdentifier = account.Identifier,
            Identifier = "unique Identifier",
            IncentiveType = 0,
        };

        await dbContext.RebateCalculation.AddAsync(rebateCalc);
        dbContext.SaveChanges();

    }
}
