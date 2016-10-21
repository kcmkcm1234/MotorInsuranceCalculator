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
    class DeclineFactory : IDeclineFactory
    {
        public DeclineRuleSet create()
        {
            // Create list of decline rules
            List<IDeclineRule> rules = new List<IDeclineRule>()
            {
                new InvalidStartDateRule(),
                new MinimumDriversRule(),
                new YoungestDriverDeclineRule(),
                new OldestDriverDeclineRule(),
                new ClaimsPerDriverDeclineRule(),
                new TotalClaimsDeclineRule()
            };

            // Return ruleset of decline rules
            return new DeclineRuleSet(rules);
        }
    }
}
