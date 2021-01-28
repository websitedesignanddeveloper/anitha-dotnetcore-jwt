using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppJwt.Models
{
    public partial class Case
    {
        public int CaseId { get; set; }
        public string CaseName { get; set; }
        public string CaseStatus { get; set; }
        public string CaseDescription { get; set; }
        public string Unit { get; set; }
        public bool? IsModelAvail { get; set; }
        public bool? IsStaticAnalysisAvail { get; set; }
        public bool? IsFatigueAnalysisAvail { get; set; }
        public bool? IsEcaanalysisAvail { get; set; }
    }
}
