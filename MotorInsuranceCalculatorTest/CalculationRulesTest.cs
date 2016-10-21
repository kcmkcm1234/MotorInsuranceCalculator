using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorInsuranceCalculator.Models;
using MotorInsuranceCalculator.Rules;
using System.Collections.ObjectModel;
using MotorInsuranceCalculator;

namespace MotorInsuranceCalculatorTest
{
    [TestClass]
    public class CalculationRulesTest
    {
        private Policy policy;
        private Driver driver;

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
        }

        [TestMethod]
        public void TestStartPremiumAt500()
        {
            // Create valid data object
            Policy p = policy;
            double premium = 0;

            // Create instance of rule
            StartPremiumAt500Rule rule = new StartPremiumAt500Rule();

            double expectedResult = 500;
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestOccupationRuleChauffeur()
        {
            // Create valid data object
            Policy p = policy;
            Driver d = driver;
            d.Job.JobEnum = OccupationEnum.CHAUFFEUR;
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            OccupationRule rule = new OccupationRule();

            double expectedResult = premium + (premium * 0.1);
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestOccupationRuleAccountant()
        {
            // Create valid data object
            Policy p = policy;
            Driver d = driver;
            d.Job.JobEnum = OccupationEnum.ACCOUNTANT;
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            OccupationRule rule = new OccupationRule();

            double expectedResult = premium - (premium * 0.1);
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestOccupationRuleOther()
        {
            // Create valid data object
            Policy p = policy;
            Driver d = driver;
            d.Job.JobEnum = OccupationEnum.OTHER;
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            OccupationRule rule = new OccupationRule();

            double expectedResult = premium;
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestYoungestDriverPremiumRule21()
        {
            DateTime startDate = new DateTime(2021, 12, 1);
            DateTime driverDob = new DateTime(2000, 12, 1);

            // Create valid data object
            Policy p = policy;
            policy.StartDate = startDate;
            Driver d = driver;
            // Set driver age to exactly 21 years
            d.Dob = driverDob;
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            YoungestDriverPremiumRule rule = new YoungestDriverPremiumRule();

            double expectedResult = premium + (premium * 0.2);
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestYoungestDriverPremiumRule25()
        {
            DateTime startDate = new DateTime(2025, 12, 1);
            DateTime driverDob = new DateTime(2000, 12, 1);

            // Create valid data object
            Policy p = policy;
            policy.StartDate = startDate;
            Driver d = driver;
            // Set driver age to exactly 25 years
            d.Dob = driverDob;
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            YoungestDriverPremiumRule rule = new YoungestDriverPremiumRule();

            double expectedResult = premium + (premium * 0.2);
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestYoungestDriverPremiumRule26()
        {
            DateTime startDate = new DateTime(2026, 12, 1);
            DateTime driverDob = new DateTime(2000, 12, 1);

            // Create valid data object
            Policy p = policy;
            policy.StartDate = startDate;
            Driver d = driver;
            // Set driver age to exactly 26 years
            d.Dob = driverDob;
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            YoungestDriverPremiumRule rule = new YoungestDriverPremiumRule();

            double expectedResult = premium - (premium * 0.1);
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestYoungestDriverPremiumRule75()
        {
            DateTime startDate = new DateTime(2075, 12, 1);
            DateTime driverDob = new DateTime(2000, 12, 1);

            // Create valid data object
            Policy p = policy;
            policy.StartDate = startDate;
            Driver d = driver;
            // Set driver age to exactly 75 years
            d.Dob = driverDob;
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            YoungestDriverPremiumRule rule = new YoungestDriverPremiumRule();

            double expectedResult = premium - (premium * 0.1);
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestClaimsRuleWithin1Year()
        {
            DateTime startDate = new DateTime(2001, 12, 1);
            DateTime claimDate = new DateTime(2000, 12, 1);

            // Create valid data object
            Policy p = policy;
            policy.StartDate = startDate;
            Driver d = driver;
            d.Claims.Add(new Claim { Date = claimDate });
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            ClaimsRule rule = new ClaimsRule();

            double expectedResult = premium + (premium * 0.2);
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestClaimsRuleWithin2Year()
        {
            DateTime startDate = new DateTime(2002, 12, 1);
            DateTime claimDate = new DateTime(2000, 10, 1);

            // Create valid data object
            Policy p = policy;
            policy.StartDate = startDate;
            Driver d = driver;
            d.Claims.Add(new Claim { Date = claimDate });
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            ClaimsRule rule = new ClaimsRule();

            double expectedResult = premium + (premium * 0.1);
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestClaimsRuleWithin5Year()
        {
            DateTime startDate = new DateTime(2005, 12, 1);
            DateTime claimDate = new DateTime(2000, 10, 1);

            // Create valid data object
            Policy p = policy;
            policy.StartDate = startDate;
            Driver d = driver;
            d.Claims.Add(new Claim { Date = claimDate });
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            ClaimsRule rule = new ClaimsRule();

            double expectedResult = premium + (premium * 0.1);
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestClaimsRuleOver5Year()
        {
            DateTime startDate = new DateTime(2010, 12, 1);
            DateTime claimDate = new DateTime(2000, 10, 1);

            // Create valid data object
            Policy p = policy;
            policy.StartDate = startDate;
            Driver d = driver;
            d.Claims.Add(new Claim { Date = claimDate });
            p.Drivers.Add(d);
            double premium = 100;

            // Create instance of rule
            ClaimsRule rule = new ClaimsRule();

            double expectedResult = premium;
            double actualResult = rule.applyRule(policy, premium);

            // Compare results
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
