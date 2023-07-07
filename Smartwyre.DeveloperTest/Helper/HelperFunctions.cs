using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Helper
{
    public static class HelperFunctions
    {
        /// <summary>
        /// Retrieves Incetive type of Rebate
        /// </summary>
        /// <param name="rebate"></param>
        /// <returns></returns>
        public static IncentiveType GetIncentiveType(Rebate rebate)
        {
            return rebate.Incentive;
        }

        /// <summary>
        /// Receive Incentive Type as Enum (int)
        /// </summary>
        /// <param name="rebate"></param>
        /// <returns></returns>
        public static int GetIncentiveTypeAsEnum(Rebate rebate)
        {
            return (int)rebate.Incentive;
        }
    }
}
