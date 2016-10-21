using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; // for INotifyPropertyChanged
using System.Collections.ObjectModel;

namespace MotorInsuranceCalculator.Models
{
    public class Policy
    {
        public DateTime StartDate { get; set; }
        public ObservableCollection<Driver> Drivers { get; set; }
        public double Premium { get; set; }
    }
}
