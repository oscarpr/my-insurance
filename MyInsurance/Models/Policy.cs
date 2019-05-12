using System;
using System.Collections.Generic;

namespace MyInsurance.Models
{
    public class Policy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
        public DateTime InitDate { get; set; }
        public double CoverageTime { get; set; }
        public double Price { get; set; }
        public int RiskTypeID { get; set; }
        public RiskType RiskType { get; set; }
        public List<PolicyCoverage> PolicyCoverage { get; set; }

        public static Policy GetPolicyFromRequest(PolicyRequest policy)
        {
            try
            {
                List<PolicyCoverage> Coverages = new List<PolicyCoverage>(policy.PolicyCoverage.Count);
                string[] date = policy.InitDate.Split('/');
                DateTime initDate = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
                policy.PolicyCoverage.ForEach(Coverage =>
                {
                    Coverages.Add(new PolicyCoverage { CoverageID = Coverage });
                });
                return new Policy
                {
                    Name = policy.Name,
                    Description = policy.Description,
                    Percentage = policy.Percentage,
                    InitDate = initDate,
                    CoverageTime = policy.CoverageTime,
                    Price = policy.Price,
                    RiskTypeID = policy.RiskTypeID,
                    PolicyCoverage = Coverages
                };
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public static bool ValidPolicy(Policy policy)
        {
            bool response = false;
            response = ValidPercentage(policy.Percentage, policy.RiskTypeID);
            return response;
        }

        public static bool ValidPercentage(decimal percentaje, int riskTypeID)
        {
            return (percentaje < 50) || (riskTypeID != 4);
        }
    }
}
