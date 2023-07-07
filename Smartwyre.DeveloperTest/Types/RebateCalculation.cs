using System.ComponentModel.DataAnnotations;

namespace Smartwyre.DeveloperTest.Types;

public class RebateCalculation
{
    [Key]
    public int Id { get; set; }
    public string Identifier { get; set; }
    public string RebateIdentifier { get; set; }
    public IncentiveType IncentiveType { get; set; }
    public decimal Amount { get; set; }
}
