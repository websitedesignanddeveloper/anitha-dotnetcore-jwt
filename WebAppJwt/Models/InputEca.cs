using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppJwt.Models
{
    public partial class InputEca
    {
        public int EcaId { get; set; }
        public int CaseFid { get; set; }
        public string Fadoption { get; set; }
        public string CrackType { get; set; }
        public string CrackLen { get; set; }
        public string CrackH { get; set; }
        public string CrackLigament { get; set; }
        public string Uts { get; set; }
        public string EpsY { get; set; }
        public string EpsUts { get; set; }
        public string IsLuderPlateau { get; set; }
        public string Kmat { get; set; }
        public string Cvn { get; set; }
        public string FracToughType { get; set; }
        public string Fcgr { get; set; }
        public string SigmaEpsUserFlag { get; set; }
        public string Pm { get; set; }
        public string Pb { get; set; }
        public string Qm { get; set; }
        public string Qb { get; set; }
        public string CapLength { get; set; }
        public string RootLength { get; set; }
        public string HiLo { get; set; }
        public string LrmaxUserFlag { get; set; }
        public string Lrmax { get; set; }
        public string EpsLuderEndFlag { get; set; }
        public string EpsLuderEnd { get; set; }
        public string LoadingEntryType { get; set; }
    }
}
