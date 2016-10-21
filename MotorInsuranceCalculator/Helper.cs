using MotorInsuranceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator
{
    static class Helper
    {
        public static int getAge(DateTime date, DateTime policyDate)
        {
            // Get base age by subtracting year
            int age = policyDate.Year - date.Year;

            // Account for months and days
            if (date.Month > policyDate.Month || (date.Month == policyDate.Month && date.Day > policyDate.Day))
            {
                age--;
            }

            return age;
        }

        public static Driver getYoungestDriver(ObservableCollection<Driver> drivers)
        {
            // Sort list in ascending order based on dob, select last driver in list
            Driver youngest = drivers.OrderBy(x => x.Dob).ToList().Last();

            return youngest;
        }

        public static Driver getOldestDriver(ObservableCollection<Driver> drivers)
        {
            // Sort list in ascending order based on dob, select first driver in list
            Driver oldest = drivers.OrderBy(x => x.Dob).ToList().First();

            return oldest;
        }
    }
}
