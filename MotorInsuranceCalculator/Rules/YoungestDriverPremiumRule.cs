using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class YoungestDriverPremiumRule : IPremiumCalculationRule
    {
        public double applyRule(Policy policy, double premium)
        {
            // Get age of youngest driver
            Driver youngest = Helper.getYoungestDriver(policy.Drivers);
            int age = Helper.getAge(youngest.Dob, policy.StartDate);

            // Check age of youngest driver
            if (age >= 21 && age <= 25)
            {
                premium += premium * 0.2; // Increase by 20%
            }
            else if (age >= 26 && age <= 75)
            {
                premium -= premium * 0.1; // Decrease by 10%
            }

            // Return updated premium (to 2dp)
            return Math.Round(premium, 2);
        }
    }
}
