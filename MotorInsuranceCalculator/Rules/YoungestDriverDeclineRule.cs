using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class YoungestDriverDeclineRule : IDeclineRule
    {
        public Result applyRule(Policy policy)
        {
            // Get age of youngest driver
            Driver youngest = Helper.getYoungestDriver(policy.Drivers);
            int age = Helper.getAge(youngest.Dob, policy.StartDate);

            // Check age is 21+ AT START OF POLICY
            if (age >= 21)
            {
                return new Result(true, "");
            }
            else
            {
                return new Result(false, youngest.Name + " is younger than 21");
            }
        }
    }
}
