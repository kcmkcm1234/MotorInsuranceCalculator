using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Interfaces
{
    interface IPremiumCalculationRule
    {
        // Apply calculation to premium, return new premium
        double applyRule(Policy policy, double premium);
    }
}
