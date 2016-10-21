using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator
{
    public class Result
    {
        public bool isSuccess { get; set; }
        public String message { get; set; }

        public Result(bool isSuccess, String message)
        {
            this.isSuccess = isSuccess;
            this.message = message;
        }
    }
}
