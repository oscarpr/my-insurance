using System;
using System.Collections.Generic;

namespace MyInsurance.Models
{
    public class CoverageType
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public List<PolicyCoverage> PolicyCoverages { get; set; }
    }
}
