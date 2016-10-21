using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * NOT IN USE
 */

namespace MotorInsuranceCalculator.ViewModels
{
    public class MainViewModel
    {
        ObservableCollection<object> _children;

        public MainViewModel()
        {
            _children = new ObservableCollection<object>();
            _children.Add(new PolicyViewModel());
            _children.Add(new AddDriverViewModel());
            _children.Add(new AddClaimViewModel());
        }

        public ObservableCollection<object> Children
        {
            get { return _children; }
        }
    }
}
