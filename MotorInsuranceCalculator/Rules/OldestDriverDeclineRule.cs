using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class OldestDriverDeclineRule : IDeclineRule
    {
        public Result applyRule(Policy policy)
        {
            // Get age of oldest driver
            Driver oldest = Helper.getOldestDriver(policy.Drivers);
            int age = Helper.getAge(oldest.Dob, policy.StartDate);

            // Check driver is <=75
            if (age <= 75)
            {
                return new Result(true, "");
            }
            else
            {
                return new Result(false, oldest.Name + " is over 75 years old");
            }
        }
    }
}
