using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator.Interfaces
{
    interface IDeclineRule
    {
        // Check if policy is valid
        Result applyRule(Policy policy);
    }
}
