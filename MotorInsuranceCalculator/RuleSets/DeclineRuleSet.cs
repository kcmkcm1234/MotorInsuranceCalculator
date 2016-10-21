using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.RuleSets
{
    class DeclineRuleSet
    {
        List<IDeclineRule> rules;

        public DeclineRuleSet(List<IDeclineRule> rules)
        {
            this.rules = rules;
        }

        public Result assessRules(Policy policy)
        {
            // Declare basic result
            Result result = new Result(true, "");

            foreach (IDeclineRule rule in rules)
            {
                // Apply each rule/calculation to premium in succession
                result = rule.applyRule(policy);
                if (result.isSuccess == false)
                    return result;
            }

            return result;
        }
    }
}
