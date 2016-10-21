using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/**
 * NOT IN USE
 */

namespace MotorInsuranceCalculator.ViewModels
{
    public class AddClaimViewModel : INotifyPropertyChanged
    {
        private Claim _claim;

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand; }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }

        public AddClaimViewModel()
        {
            // Set commands
            _addCommand = new DelegateCommand(x =>
                Add());
            _cancelCommand = new DelegateCommand(x =>
                Cancel());

            // Initialise properties
            _claim = new Claim();
            Date = new DateTime();
        }

        public DateTime Date
        {
            get { return _claim.Date; }
            set
            {
                if (_claim.Date != value)
                {
                    _claim.Date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        public void Add()
        {
            // Add claim to claims list
            PolicyViewModel.Instance.SelectedDriver.Claims.Add(_claim);
        }

        public void Cancel()
        {
            // return to policy view
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
