using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Rules;
using MotorInsuranceCalculator.RuleSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Factories
{
    class CalculationFactory : ICalculationFactory
    {
        public CalculationRuleSet create()
        {
            // Create list of premium calculation rules
            List<IPremiumCalculationRule> rules = new List<IPremiumCalculationRule>()
            {
                new StartPremiumAt500Rule(),
                new OccupationRule(),
                new YoungestDriverPremiumRule(),
                new ClaimsRule()
            };

            // Return ruleset of calculation rules
            return new CalculationRuleSet(rules);
        }
    }
}
