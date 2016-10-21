using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

/**
 * NOT IN USE
 */

namespace MotorInsuranceCalculator.ViewModels
{
    public class AddDriverViewModel : INotifyPropertyChanged
    {
        private Driver _driver;

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

        public AddDriverViewModel()
        {
            // Set commands
            _addCommand = new DelegateCommand(x =>
                Add());
            _cancelCommand = new DelegateCommand(x =>
                Cancel());

            // Initialise properties
            _driver = new Driver();
            _driver.Claims = new ObservableCollection<Claim>();
        }

        public string Name
        {
            get { return _driver.Name; }
            set
            {
                if (_driver.Name != value)
                {
                    _driver.Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public DateTime Dob
        {
            get { return _driver.Dob; }
            set
            {
                if (_driver.Dob != value)
                {
                    _driver.Dob = value;
                    NotifyPropertyChanged("Dob");
                }
            }
        }

        public Occupation Job
        {
            get { return _driver.Job; }
            set
            {
                if (_driver.Job != value)
                {
                    _driver.Job = value;
                    NotifyPropertyChanged("Job");
                }
            }
        }

        public void Add()
        {
            // Initialise job
            Job = new Occupation();

            // Check if driver is valid
            if (Dob != null && (Name != null || Name != "") && (Job.JobTitle != null || Job.JobTitle != ""))
            {
                PolicyViewModel.Instance.Drivers.Add(_driver);
            }
        }

        public void Cancel()
        {
            // Return to policy view
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
