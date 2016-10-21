using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class ClaimsPerDriverDeclineRule : IDeclineRule
    {
        public Result applyRule(Policy policy)
        {
            // Check for any drivers with >2 claims
            if (policy.Drivers.Any(x => x.Claims.Count > 2))
            {
                Driver driver = policy.Drivers.Where(x => x.Claims.Count > 2).First();
                return new Result(false, driver.Name + " has more than 2 claims");
            }
            else
            {
                return new Result(true, "");
            }
        }
    }
}
