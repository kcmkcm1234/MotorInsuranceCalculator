using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class OccupationRule : IPremiumCalculationRule
    {
        public double applyRule(Policy policy, double premium)
        {
            // Check if any driver in list is a chauffeur
            if (policy.Drivers.Any(x => x.Job.JobEnum.Equals(OccupationEnum.CHAUFFEUR)))
            {
                // Increase premium by 10%
                premium += premium * 0.1;
            }
            else if (policy.Drivers.Any(x => x.Job.JobEnum.Equals(OccupationEnum.ACCOUNTANT)))
            {
                // Decrease premium by 10%
                premium -= premium * 0.1;
            }

            // Return updated premium (to 2dp)
            return Math.Round(premium, 2);
        }
    }
}
