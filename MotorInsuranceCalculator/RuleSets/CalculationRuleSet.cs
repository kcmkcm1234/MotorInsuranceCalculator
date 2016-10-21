using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.RuleSets
{
    class CalculationRuleSet
    {
        List<IPremiumCalculationRule> rules;

        public CalculationRuleSet(List<IPremiumCalculationRule> rules)
        {
            this.rules = rules;
        }

        public double assessRules(Policy policy)
        {
            // Initialise premium
            double premium = 0.0;

            foreach (IPremiumCalculationRule rule in rules)
            {
                // Apply each rule/calculation to premium in succession
                premium = rule.applyRule(policy, premium);
            }

            // Return final premium
            return premium;
        }
    }
}
