using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class ClaimsRule : IPremiumCalculationRule
    {
        public double applyRule(Policy policy, double premium)
        {
            // Iterate through each claim for each driver
            foreach (Driver driver in policy.Drivers)
            {
                foreach (Claim claim in driver.Claims)
                {
                    // Get age of claim
                    int age = Helper.getAge(claim.Date, policy.StartDate);

                    // Check age of claim
                    if (age <= 1)
                    {
                        premium += premium * 0.2; // Increase by 20%
                    }
                    else if (age >= 2 && age <= 5)
                    {
                        premium += premium * 0.1; // Increase by 10%
                    }
                }
            }

            // Return updated premium (to 2dp)
            return Math.Round(premium, 2);
        }
    }
}
