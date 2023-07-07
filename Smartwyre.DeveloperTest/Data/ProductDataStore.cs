using Microsoft.EntityFrameworkCore;
using Smartwyre.DeveloperTest.Types;
using System.Linq;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    private readonly RebateContext dbContext;

    public ProductDataStore()
    {
        this.dbContext = new RebateContext();
    }

    /// <summary>
    /// Method to access database and get a single Product
    /// </summary>
    /// <param name="productIdentifier"></param>
    /// <returns>Product</returns>
    public async Task<Product> GetProduct(string productIdentifier)
    {
            var product = await dbContext.Product
                                              .Where(s => s.Identifier == productIdentifier)
                                              .SingleOrDefaultAsync();
            return product;
    }
}
