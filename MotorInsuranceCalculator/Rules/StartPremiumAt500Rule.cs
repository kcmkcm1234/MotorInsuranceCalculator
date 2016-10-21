using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class StartPremiumAt500Rule : IPremiumCalculationRule
    {
        public double applyRule(Policy policy, double premium)
        {
            // Start premium at 500
            return 500.0;
        }
    }
}
