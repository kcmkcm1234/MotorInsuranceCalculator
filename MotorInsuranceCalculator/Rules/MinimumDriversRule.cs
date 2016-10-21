using MotorInsuranceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class MinimumDriversRule : IDeclineRule
    {
        public Result applyRule(Models.Policy policy)
        {
            // Check that policy has at least one driver
            if (policy.Drivers != null && policy.Drivers.Count > 0)
            {
                return new Result(true, "");
            }
            else
            {
                return new Result(false, "Policy must have at least one driver");
            }
        }
    }
}
