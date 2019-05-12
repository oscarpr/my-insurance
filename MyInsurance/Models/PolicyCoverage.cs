using System;
namespace MyInsurance.Models
{
    public class PolicyCoverage
    {
        public int PolicyID { get; set; }
        public Policy Policy { get; set; }

        public int CoverageID { get; set; }
        public CoverageType Coverage { get; set; }
    }
}
