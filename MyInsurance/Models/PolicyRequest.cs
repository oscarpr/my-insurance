using System;
using System.Collections.Generic;

namespace MyInsurance.Models
{
    public class PolicyRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
        public string InitDate { get; set; }
        public double CoverageTime { get; set; }
        public double Price { get; set; }
        public int RiskTypeID { get; set; }
        public RiskType RiskType { get; set; }
        public List<int> PolicyCoverage { get; set; }
    }
}
