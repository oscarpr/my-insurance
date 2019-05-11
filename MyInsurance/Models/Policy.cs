using System;
using System.Collections.Generic;

namespace MyInsurance.Models
{
    public class Policy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Coverages { get; set; }
        public decimal Percentage { get; set; }
        public DateTime InitDate { get; set; }
        public double CoverageTime { get; set; }
        public double Price { get; set; }
        public string RiskType { get; set; }
    }
}
