using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class TotalClaimsDeclineRule : IDeclineRule
    {
        public Result applyRule(Policy policy)
        {
            // Get total number of claims
            int claims = policy.Drivers.SelectMany(x => x.Claims).Count();

            // Check that claims is <=3
            if (claims <= 3)
            {
                return new Result(true, "");
            }
            else
            {
                return new Result(false, "Total number of claims cannot be greater than 3");
            }
        }
    }
}
