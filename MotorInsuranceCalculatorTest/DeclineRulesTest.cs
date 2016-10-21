using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorInsuranceCalculator.Models;
using System.Collections.ObjectModel;
using MotorInsuranceCalculator.Rules;

namespace MotorInsuranceCalculatorTest
{
    [TestClass]
    public class DeclineRulesTest
    {
        private Policy policy;
        private Driver driver;
        private Claim claim;

        [TestInitialize]
        public void SetUp()
        {
            policy = new Policy()
            {
                StartDate = new DateTime(),
                Drivers = new ObservableCollection<Driver>()
            };

            driver = new Driver()
            {
                Dob = new DateTime(),
                Claims = new ObservableCollection<Claim>(),
                Job = new Occupation()
            };

            claim = new Claim
            {
                Date = new DateTime()
            };
        }

        [TestMethod]
        public void TestInvalidStartDate()
        {
            // Create valid data object
            Policy p = policy;
            p.StartDate = DateTime.Today.AddDays(10);

            // Create instance of rule
            InvalidStartDateRule rule = new InvalidStartDateRule();

            bool expectedResult = true;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestInvalidStartDateFail()
        {
            // Create valid data object
            Policy p = policy;
            p.StartDate = DateTime.Today.AddDays(-10);

            // Create instance of rule
            InvalidStartDateRule rule = new InvalidStartDateRule();

            bool expectedResult = false;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestYoungestDriver()
        {
            DateTime startDate = new DateTime(2021, 12, 1);
            DateTime driverDob = new DateTime(2000, 12, 1);

            // Create valid data object
            Policy p = policy;
            p.StartDate = startDate;
            Driver d = driver;
            d.Dob = driverDob;
            policy.Drivers.Add(d);

            // Create instance of rule
            YoungestDriverDeclineRule rule = new YoungestDriverDeclineRule();

            bool expectedResult = true;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestYoungestDriverFail()
        {
            DateTime startDate = new DateTime(2021, 12, 1);
            DateTime driverDob = new DateTime(2000, 12, 31);

            // Create valid data object
            Policy p = policy;
            p.StartDate = startDate;
            Driver d = driver;
            d.Dob = driverDob;
            policy.Drivers.Add(d);

            // Create instance of rule
            YoungestDriverDeclineRule rule = new YoungestDriverDeclineRule();

            bool expectedResult = false;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestOldestDriver()
        {
            DateTime startDate = new DateTime(2075, 12, 1);
            DateTime driverDob = new DateTime(2000, 12, 31);

            // Create valid data object
            Policy p = policy;
            p.StartDate = startDate;
            Driver d = driver;
            d.Dob = driverDob;
            policy.Drivers.Add(d);

            // Create instance of rule
            OldestDriverDeclineRule rule = new OldestDriverDeclineRule();

            bool expectedResult = true;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestOldestDriverFail()
        {
            DateTime startDate = new DateTime(2076, 12, 1);
            DateTime driverDob = new DateTime(2000, 12, 1);

            // Create valid data object
            Policy p = policy;
            p.StartDate = startDate;
            Driver d = driver;
            d.Dob = driverDob;
            policy.Drivers.Add(d);

            // Create instance of rule
            OldestDriverDeclineRule rule = new OldestDriverDeclineRule();

            bool expectedResult = false;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestClaimsPerDriver()
        {
            int maxClaims = 2;

            // Create valid data object
            Policy p = policy;
            Driver d = driver;
            Claim c = claim;

            // Add max number of claims to list
            for (int i = 0; i < maxClaims; i++)
            {
                d.Claims.Add(c);
            }

            policy.Drivers.Add(d);

            // Create instance of rule
            ClaimsPerDriverDeclineRule rule = new ClaimsPerDriverDeclineRule();

            bool expectedResult = true;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestClaimsPerDriverFail()
        {
            int maxClaims = 2;

            // Create valid data object
            Policy p = policy;
            Driver d = driver;
            Claim c = claim;

            // Add more than max number of claims to list
            for (int i = 0; i < maxClaims+1; i++)
            {
                d.Claims.Add(c);
            }

            policy.Drivers.Add(d);

            // Create instance of rule
            ClaimsPerDriverDeclineRule rule = new ClaimsPerDriverDeclineRule();

            bool expectedResult = false;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestTotalClaims()
        {
            // Create valid data object
            Policy p = policy;
            Driver d1 = new Driver()
            {
                Dob = new DateTime(),
                Claims = new ObservableCollection<Claim>(),
                Job = new Occupation()
            };
            Driver d2 = new Driver()
            {
                Dob = new DateTime(),
                Claims = new ObservableCollection<Claim>(),
                Job = new Occupation()
            };
            Driver d3 = new Driver()
            {
                Dob = new DateTime(),
                Claims = new ObservableCollection<Claim>(),
                Job = new Occupation()
            };
            Claim c = claim;

            // Add claim to each driver
            d1.Claims.Add(c);
            d2.Claims.Add(c);
            d3.Claims.Add(c);

            policy.Drivers.Add(d1);
            policy.Drivers.Add(d2);
            policy.Drivers.Add(d3);

            // Create instance of rule
            TotalClaimsDeclineRule rule = new TotalClaimsDeclineRule();

            bool expectedResult = true;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestTotalClaimsFail()
        {
            // Create valid data object
            Policy p = policy;
            Driver d1 = new Driver()
            {
                Dob = new DateTime(),
                Claims = new ObservableCollection<Claim>(),
                Job = new Occupation()
            };
            Driver d2 = new Driver()
            {
                Dob = new DateTime(),
                Claims = new ObservableCollection<Claim>(),
                Job = new Occupation()
            };
            Driver d3 = new Driver()
            {
                Dob = new DateTime(),
                Claims = new ObservableCollection<Claim>(),
                Job = new Occupation()
            };
            Claim c = claim;

            // Add claim to each driver
            d1.Claims.Add(c);
            d2.Claims.Add(c);
            d3.Claims.Add(c);
            // Add extra claim to driver
            d3.Claims.Add(c);

            policy.Drivers.Add(d1);
            policy.Drivers.Add(d2);
            policy.Drivers.Add(d3);

            // Create instance of rule
            TotalClaimsDeclineRule rule = new TotalClaimsDeclineRule();

            bool expectedResult = false;
            bool actualResult = rule.applyRule(policy).isSuccess;

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
