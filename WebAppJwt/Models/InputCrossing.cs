using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppJwt.Models
{
    public partial class InputCrossing
    {
        public int CrossingId { get; set; }
        public int CaseFid { get; set; }
        public string MinTheta { get; set; }
        public string MinHeOnD { get; set; }
        public string MinZOnD { get; set; }
        public string MinDeltaOnD { get; set; }
        public string MinEOnD { get; set; }
        public string MaxEOnD { get; set; }
        public string NumEOnD { get; set; }
        public string MinL { get; set; }
        public string MaxL { get; set; }
        public string NumL { get; set; }
        public string IsLspanRange { get; set; }
        public string IsGapRange { get; set; }
    }
}
