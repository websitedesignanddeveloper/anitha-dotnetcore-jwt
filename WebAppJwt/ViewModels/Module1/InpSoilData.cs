using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Collections.ObjectModel;

namespace WebAppJwt.ViewModels.Module1
{
    public class InpSoilData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        
        public Dictionary<string, string[]> DicSoilTypeClassParams = new Dictionary<string, string[]>
        {
            // ===================================================================================================================
            // 0: SubWeight, 1: MuL, 2: PhiS, 3: Cu, 4: nuS, 5: eS, 6: Ip, 7: OCR, 8: CL, 9: CV, 10: kStaticSoil
            // ===================================================================================================================
            {"VeryLooseSand", new string[11] {   "8.6",  "0.7", "25", "0", "0.35", "0.90", "0", "0", "9000", "10500", "250"}},
            {"LooseSand", new string[11] {       "9.1",  "0.7", "30", "0", "0.35", "0.70", "0", "0", "9000", "10500", "250"}},
            {"MediumDenseSand", new string[11] { "9.6",  "0.7", "35", "0", "0.35", "0.50", "0", "0", "12500", "14500", "530" }},
            {"DenseSand", new string[11] {       "10.1", "0.7", "40", "0", "0.35", "0.45", "0", "0", "18000", "21000", "1350" }},
            {"VeryDenseSand", new string[11] {   "10.6", "0.7", "45", "0", "0.35", "0.40", "0", "0", "18000", "21000", "1350" }},
            {"VerySoftClay", new string[11] {    "4.4",  "0.4", "0",  "5", "0.45", "2.00", "60", "1", "500", "600", "50" }},
            {"SoftClay", new string[11] {        "5.4",  "0.4", "0",  "17.5", "0.45", "1.75", "55", "1", "1200", "1400", "160" }},
            {"FirmClay", new string[11] {        "6.4",  "0.4", "0",  "35", "0.45", "1.50", "40", "1", "2600", "3000", "500" }},
            {"StiffClay", new string[11] {       "7.4",  "0.4", "0",  "70", "0.45", "1.25", "35", "1", "3900", "4500", "1000" }},
            {"VeryStiffClay", new string[11] {   "8.4",  "0.4", "0",  "140", "0.45", "1.00", "25", "1", "9500", "11000", "2000" }},
            {"HardClay", new string[11] {        "9.4",  "0.5", "0",  "280", "0.45", "0.75", "20", "1", "10500", "12000", "2600" }},
            {"VeryHardClay", new string[11] {    "10.4", "0.5", "0",  "560", "0.45", "0.50", "10", "1", "10500", "12000", "2600" }}
        };

        public Dictionary<int, string> DicIndxToSoilClass = new Dictionary<int, string>
        {
            {0, "VeryLooseSand" },
            {1, "LooseSand" },
            {2, "MediumDenseSand" },
            {3,"DenseSand" },
            {4, "VeryDenseSand" },
            {5,"VerySoftClay" },
            {6, "SoftClay" },
            {7, "FirmClay" },
            {8, "StiffClay" }, 
            {9, "VeryStiffClay" },
            {10, "HardClay" },
            {11, "VeryHardClay" },
            {12, "UserSand" },
            {13, "UserClay" }
        };

        public Dictionary<string, int> DicSoilClassToIndx = new Dictionary<string, int>
        {
            {"VeryLooseSand", 0 },
            {"LooseSand", 1 },
            { "MediumDenseSand", 2 },
            {"DenseSand", 3},
            {"VeryDenseSand", 4},
            {"VerySoftClay", 5 },
            {"SoftClay", 6},
            {"FirmClay" , 7},
            {"StiffClay" , 8},
            {"VeryStiffClay", 9},
            {"HardClay" , 10 },
            {"VeryHardClay" , 11},
            {"UserSand" , 12},
            {"UserClay" , 13}
        };

        private string _SoilType;
        public string SoilType
        {
            get { return _SoilType; }
            set
            {
                _SoilType = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SoilType"));
            }
        }

        private string _SoilTypeClass;
        public string SoilTypeClass
        {
            get { return _SoilTypeClass; }
            set
            {
                _SoilTypeClass = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SoilTypeClass"));
            }
        }

        private ObservableCollection<string> _soilStiffModels = new ObservableCollection<string>();
        public ObservableCollection<string> soilStiffModels
        {
            get { return _soilStiffModels; }
            set
            {
                _soilStiffModels = value;
                OnPropertyChanged(new PropertyChangedEventArgs("soilStiffModels"));
            }
        }

        
        private bool _IsSoilParamReadOnly = true;
        public bool IsSoilParamReadOnly
        {
            get { return _IsSoilParamReadOnly; }
            set
            {
                _IsSoilParamReadOnly = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsSoilParamReadOnly"));
            }
        }

        private bool _IsSoilTypeSand = true;
        public bool IsSoilTypeSand
        {
            get { return _IsSoilTypeSand; }
            set
            {
                _IsSoilTypeSand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsSoilTypeSand"));

                if (!IsStiffModelF105 && !IsSoilTypeSand)
                {
                    IsIpAndOCR_Enabeld = true;
                }
                else
                {
                    IsIpAndOCR_Enabeld = false;
                }
            }
        }

        private bool _IsStiffModelF105 = true;
        public bool IsStiffModelF105
        {
            get { return _IsStiffModelF105; }
            set
            {
                _IsStiffModelF105 = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsStiffModelF105"));

                if (!IsStiffModelF105 && !IsSoilTypeSand)
                {
                    IsIpAndOCR_Enabeld = true;
                }
                else
                {
                    IsIpAndOCR_Enabeld = false;
                }
            }
        }


        private bool _IsIpAndOCR_Enabeld = true;
        public bool IsIpAndOCR_Enabeld
        {
            get { return _IsIpAndOCR_Enabeld; }
            set
            {
                _IsIpAndOCR_Enabeld = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsIpAndOCR_Enabeld"));
            }
        }

        


        private int _CmbSoilTypeSelectedIndex = -1;
        public int CmbSoilTypeSelectedIndex
        {
            get { return _CmbSoilTypeSelectedIndex; }
            set
            {
                _CmbSoilTypeSelectedIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CmbSoilTypeSelectedIndex"));
                if (this.CmbSoilTypeSelectedIndex > 0)
                {
                    this.SoilTypeClass = this.DicIndxToSoilClass[CmbSoilTypeSelectedIndex];
                    if (this.CmbSoilTypeSelectedIndex < 5)
                    {
                        this.SoilType = "Sand";
                        IsSoilParamReadOnly = true;
                        IsSoilTypeSand = true;
                    }

                    if (this.CmbSoilTypeSelectedIndex > 4 && this.CmbSoilTypeSelectedIndex < 12)
                    {
                        this.SoilType = "Clay";
                        IsSoilParamReadOnly = true;
                        IsSoilTypeSand = false;
                    }

                    if (this.CmbSoilTypeSelectedIndex == 12)
                    {
                        this.SoilType = "Sand";
                        IsSoilParamReadOnly = false;
                        IsSoilTypeSand = true;
                    }

                    if (this.CmbSoilTypeSelectedIndex == 13)
                    {
                        this.SoilType = "Clay";
                        IsSoilParamReadOnly = false;
                        IsSoilTypeSand = false;
                    }

                    setSoilParams();
                }
            }
        }



        private string _cmbSoilStiffnessTipText = "DNV 1977: This soil model is adopted from Laterally loaded Piles.\n"+
            "It considers the effect of cover height of soil in the embankment\n" + 
            "on soil stiffness. \n\n" +
            "DNV-RP-F105: It adopts a simple estimation of soil stiffness.";
        public string cmbSoilStiffnessTipText
        {
            get { return _cmbSoilStiffnessTipText; }
            set
            {
                _cmbSoilStiffnessTipText = value;
                OnPropertyChanged(new PropertyChangedEventArgs("cmbSoilStiffnessTipText"));
            }
        }

        private string _SoilStiffModel;
        public string SoilStiffModel
        {
            get { return _SoilStiffModel; }
            set
            {
                _SoilStiffModel = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SoilStiffModel"));
            }
        }

        private int _SoilStiffModelSelectionIndex = -1;
        public int SoilStiffModelSelectionIndex
        {
            get { return _SoilStiffModelSelectionIndex; }
            set
            {
                _SoilStiffModelSelectionIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SoilStiffModelSelectionIndex"));

                if (SoilStiffModelSelectionIndex == 0)
                {
                    IsStiffModelF105 = false;
                }
                else
                {
                    IsStiffModelF105 = true;
                }
            }
        }

        private string _SoilSubWeight;
        public string SoilSubWeight
        {
            get { return _SoilSubWeight; }
            set
            {
                _SoilSubWeight = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SoilSubWeight"));
            }
        }

        private string _MuL;
        public string MuL
        {
            get { return _MuL; }
            set
            {
                _MuL = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MuL"));
            }
        }

        private string _fphi;
        public string fphi
        {
            get { return _fphi; }
            set
            {
                _fphi = value;
                OnPropertyChanged(new PropertyChangedEventArgs("fphi"));
            }
        }

        private string _fc;
        public string fc
        {
            get { return _fc; }
            set
            {
                _fc = value;
                OnPropertyChanged(new PropertyChangedEventArgs("fc"));
            }
        }

        //private string _BetaSoil;
        //public string BetaSoil
        //{
        //    get { return _BetaSoil; }
        //    set
        //    {
        //        _BetaSoil = value;
        //        OnPropertyChanged(new PropertyChangedEventArgs("BetaSoil"));
        //    }
        //}

        private string _FricAngle;
        public string FricAngle
        {
            get { return _FricAngle; }
            set
            {
                _FricAngle = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FricAngle"));
            }
        }

        private string _Cu;
        public string Cu
        {
            get { return _Cu; }
            set
            {
                _Cu = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Cu"));
            }
        }

        private string _NuSoil;
        public string NuSoil
        {
            get { return _NuSoil; }
            set
            {
                _NuSoil = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NuSoil"));
            }
        }

        private string _eSoil;
        public string eSoil
        {
            get { return _eSoil; }
            set
            {
                _eSoil = value;
                OnPropertyChanged(new PropertyChangedEventArgs("eSoil"));
            }
        }

        private string _Ip;
        public string Ip
        {
            get { return _Ip; }
            set
            {
                _Ip = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Ip"));
            }
        }

        private string _OCR;
        public string OCR
        {
            get { return _OCR; }
            set
            {
                _OCR = value;
                OnPropertyChanged(new PropertyChangedEventArgs("OCR"));
            }
        }

        private string _CL;
        public string CL
        {
            get { return _CL; }
            set
            {
                _CL = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CL"));
            }
        }

        private string _CV;
        public string CV
        {
            get { return _CV; }
            set
            {
                _CV = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CV"));
            }
        }


        #region Constructor

        public InpSoilData()
        {
            soilStiffModels.Add("DNV 1977 - Piles");
            soilStiffModels.Add("DNV-RP-F105 - Pipe on Seabed");
            //this.CmbSoilTypeSelectedIndex = 2;
        }

        #endregion



        #region Method

        public void setSoilParams()
        {
            // ===================================================================================================================
            // 0: SubWeight, 1: MuL, 2: PhiS, 3: Cu, 4: nuS, 5: eS, 6: Ip, 7: OCR, 8: CL, 9: CV, 10: kStaticSoil
            // ===================================================================================================================
            if (this.SoilTypeClass != "UserSand" && this.SoilTypeClass != "UserClay")          
            {
                this.SoilSubWeight = DicSoilTypeClassParams[this.SoilTypeClass][0];
                this.MuL = DicSoilTypeClassParams[this.SoilTypeClass][1];
                this.FricAngle = DicSoilTypeClassParams[this.SoilTypeClass][2];
                this.Cu = DicSoilTypeClassParams[this.SoilTypeClass][3];
                this.NuSoil = DicSoilTypeClassParams[this.SoilTypeClass][4];
                this.eSoil = DicSoilTypeClassParams[this.SoilTypeClass][5];
                this.Ip = DicSoilTypeClassParams[this.SoilTypeClass][6];
                this.OCR = DicSoilTypeClassParams[this.SoilTypeClass][7];
                this.CL = DicSoilTypeClassParams[this.SoilTypeClass][8];
                this.CV = DicSoilTypeClassParams[this.SoilTypeClass][9];
            }
        }

        #endregion
    }
}
