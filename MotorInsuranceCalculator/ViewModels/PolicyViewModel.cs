using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MotorInsuranceCalculator.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MotorInsuranceCalculator.Interfaces;
using MotorInsuranceCalculator.Factories;
using MotorInsuranceCalculator.RuleSets;
using MotorInsuranceCalculator.Views;

namespace MotorInsuranceCalculator.ViewModels
{
    public class PolicyViewModel : INotifyPropertyChanged
    {
        private Policy _policy;

        private Driver _selectedDriver;
        private Claim _selectedClaim;

        private ICommand _removeDriverCommand;
        public ICommand RemoveDriverCommand
        {
            get { return _removeDriverCommand; }
        }

        private ICommand _removeClaimCommand;
        public ICommand RemoveClaimCommand
        {
            get { return _removeClaimCommand; }
        }

        private ICommand _addDriverCommand;
        public ICommand AddDriverCommand
        {
            get { return _addDriverCommand; }
        }

        private ICommand _addClaimCommand;
        public ICommand AddClaimCommand
        {
            get { return _addClaimCommand; }
        }

        private ICommand _evaluatePolicyCommand;
        public ICommand EvaluatePolicyCommand
        {
            get { return _evaluatePolicyCommand; }
        }

        public PolicyViewModel()
        {
            // Set commands
            _removeDriverCommand = new DelegateCommand(x => 
                RemoveDriver());
            _removeClaimCommand = new DelegateCommand(x =>
                RemoveClaim());
            _addDriverCommand = new DelegateCommand(x =>
                AddDriver());
            _addClaimCommand = new DelegateCommand(x =>
                AddClaim());
            _evaluatePolicyCommand = new DelegateCommand(x =>
                EvaluatePolicy());

            // Initialise properties
            _policy = new Policy();
            SelectedDriver = new Driver();
            Drivers = new ObservableCollection<Driver>();
            Claims = new ObservableCollection<Claim>();
            DriverName = "";
            DriverDob = DateTime.Today;
            DriverJob = "";
            
            // Set default date
            _policy.StartDate = DateTime.Today;
            ClaimDate = DateTime.Today;

        }

        public string DriverName { get; set; }
        public DateTime DriverDob { get; set; }
        public string DriverJob { get; set; }
        public DateTime ClaimDate { get; set; }

        public DateTime StartDate
        {
            get { return _policy.StartDate; }
            set
            {
                // Check if start date has changed
                if (_policy.StartDate != value)
                {
                    _policy.StartDate = value;
                    NotifyPropertyChanged("StartDate");
                }
            }
        }

        private string _output;
        public string Output
        {
            get { return _output; }
            set
            {
                if (_output != value)
                {
                    _output = value;
                    NotifyPropertyChanged("Output");
                }
            }
        }

        public ObservableCollection<Driver> Drivers
        {
            get { return _policy.Drivers; }
            set
            {
                if (_policy.Drivers != value)
                {
                    _policy.Drivers = value;
                    NotifyPropertyChanged("Drivers");
                }
            }
        }

        public double Premium
        {
            get { return _policy.Premium; }
            set
            {
                if (_policy.Premium != value)
                {
                    _policy.Premium = value;
                    NotifyPropertyChanged("Premium");
                }
            }
        }

        public Driver SelectedDriver
        {
            get { return _selectedDriver; }
            set
            {
                if (_selectedDriver != value)
                {
                    _selectedDriver = value;
                    NotifyPropertyChanged("SelectedDriver");
                }
            }
        }

        public ObservableCollection<Claim> Claims
        {
            get { return _selectedDriver.Claims; }
            set
            {
                if (_selectedDriver.Claims != value)
                {
                    _selectedDriver.Claims = value;
                    NotifyPropertyChanged("Claims");
                }
            }
        }

        public Claim SelectedClaim
        {
            get { return _selectedClaim; }
            set
            {
                if (_selectedClaim != value)
                {
                    _selectedClaim = value;
                    NotifyPropertyChanged("SelectedClaim");
                }
            }
        }

        public void RemoveDriver()
        {
            if (Drivers != null && SelectedDriver != null)
            {
                // Remove selected driver from drivers list
                Drivers.Remove(SelectedDriver);
                SelectedDriver = null;
            }
        }

        public void RemoveClaim()
        {
            if (SelectedDriver != null && Claims != null)
            {
                // Remove selected claim from selected driver
                Claims.Remove(SelectedClaim);
                SelectedClaim = null;
            }
        }

        public void AddDriver()
        {
            try
            {
                // Check data has been entered
                if (DriverDob != null && !DriverName.Equals("") && !DriverJob.Equals(""))
                {
                    if (Drivers.Count < 5)
                    {
                        // Create driver from inputs
                        Driver d = new Driver();
                        d.Name = DriverName;
                        d.Dob = DriverDob;
                        d.Claims = new ObservableCollection<Claim>();
                        OccupationEnum jobEnum;

                        // Set job enum based on user input
                        if (DriverJob.ToLower().Equals("chauffeur"))
                        {
                            jobEnum = OccupationEnum.CHAUFFEUR;
                        }
                        else if (DriverJob.ToLower().Equals("accountant"))
                        {
                            jobEnum = OccupationEnum.ACCOUNTANT;
                        }
                        else
                        {
                            jobEnum = OccupationEnum.OTHER;
                        }

                        // Set occupation
                        Occupation job = new Occupation
                        {
                            JobTitle = DriverJob,
                            JobEnum = jobEnum
                        };
                        d.Job = job;

                        // Add driver to list
                        Drivers.Add(d);
                        Output = DriverName + " added to policy";
                    }
                    else
                    {
                        // Output message
                        Output = "Policy cannot have more than 5 drivers";
                    }
                }
                else
                {
                    Output = "Please enter name and job of driver";
                }
            }
            catch (Exception ex)
            {
                Output = "An error has occurred. Please ensure that the driver data is correct and try again\n" + ex.Message;
            }
        }

        public void AddClaim()
        {
            try
            {
                // Check that a driver has been selected
                if (Drivers.Contains(SelectedDriver))
                {
                    if (Claims.Count < 5)
                    {
                        // Create new claim
                        Claim c = new Claim
                        {
                            Date = ClaimDate
                        };

                        // Add claim to selected driver
                        Claims.Add(c);
                    }
                    else
                    {
                        Output = "Driver cannot have more than 5 claims";
                    }
                }
                else
                {
                    Output = "Please select a driver to add a claim";
                }
            }
            catch (Exception ex)
            {
                Output = "An error has occurred. Please ensure that the claim data is correct and try again\n" + ex.Message;
            }
        }

        public void EvaluatePolicy()
        {
            // Make sure lists have been updated in view
            NotifyPropertyChanged("Drivers");
            NotifyPropertyChanged("Claims");

            // Check rules to see if policy is valid
            IDeclineFactory decline = new DeclineFactory();
            DeclineRuleSet declineRules = decline.create();
            Result result = declineRules.assessRules(_policy);
            if (result.isSuccess)
            {
                // Run rules to calculate premium
                ICalculationFactory calculate = new CalculationFactory();
                CalculationRuleSet rules = calculate.create();

                // Set total to premium
                Premium = rules.assessRules(_policy);
                Output = "Premium updated successfully";
            }
            else
            {
                Output = result.message;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /**
         * NOT IN USE
         */

        // Allows other ViewModels to access properties
        private static PolicyViewModel _instance = new PolicyViewModel();
        public static PolicyViewModel Instance
        {
            get { return _instance; }
        }
    }
}
