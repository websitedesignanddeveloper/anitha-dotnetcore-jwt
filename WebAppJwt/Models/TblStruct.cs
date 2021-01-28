using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class TblStruct
    {
        public struct Case
        {
            public const string tblName = "CaseTbl";
            public const string ID = "CaseID";
            public const string CaseName = "CaseName";
            public const string CaseStatus = "CaseStatus";
            public const string CaseDescription = "CaseDescription";
            public const string Unit = "Unit";
            public const string isModelAvail = "isModelAvail";
            public const string isStaticAnalysisAvail = "isStaticAnalysisAvail";
            public const string isFatigueAnalysisAvail = "isFatigueAnalysisAvail";
            public const string isECAAnalysisAvail = "isECAAnalysisAvail";
        }
    }
}
