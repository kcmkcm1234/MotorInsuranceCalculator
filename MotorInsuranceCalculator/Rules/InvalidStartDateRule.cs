using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Rules
{
    public class InvalidStartDateRule : IDeclineRule
    {
        public Result applyRule(Policy policy)
        {
            // Check if policy start date occurs before current date
            if (policy.StartDate.CompareTo(DateTime.Now) < 0)
            {
                Result result = new Result(false, "Start date cannot occur before current date"); // Decline
                return result;
            }

            return new Result(true, "");
        }
    }
}
