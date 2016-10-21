using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MotorInsuranceCalculator.Models
{
    public class Driver
    {
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public Occupation Job { get; set; }

        public ObservableCollection<Claim> Claims { get; set; }
    }
}
