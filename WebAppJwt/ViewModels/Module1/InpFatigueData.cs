using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WebAppJwt.ViewModels.Module1
{
    public class InpFatigueData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public InpFatigueData()
        {

        }

        Dictionary<int, string[]> dicSNCurveClass = new Dictionary<int, string[]>
        {
            // =============================================================================
            // IMPORTANT NOTE: This pre-defined values are taken from DNV-1977 Appendix C
            // 1: C_SN (log10(a)), 2: m_SN, 3: S0
            // =============================================================================

            {0, new string[3] {"15.01", "4.0", "48" } },
            {1, new string[3] {"13.63", "3.5", "33" } },
            {2, new string[3] {"12.18", "3.0", "20" } },
            {3, new string[3] {"12.02", "3.0", "18" } },
            {4, new string[3] {"11.80", "3.0", "15" } },
            {5, new string[3] {"11.63", "3.0", "13" } },
            {6, new string[3] {"11.39", "3.0", "11" } },
            {7, new string[3] {"11.20", "3.0", "9.3" } },
            {8, new string[3] {"14.57", "4.1", "34" } }
        };

        private string _gamaIL;
        public string gamaIL
        {
            get { return _gamaIL; }
            set
            {
                _gamaIL = value;
                OnPropertyChanged(new PropertyChangedEventArgs("gamaIL"));
            }
        }

        private string _gamaCF;
        public string gamaCF
        {
            get { return _gamaCF; }
            set
            {
                _gamaCF = value;
                OnPropertyChanged(new PropertyChangedEventArgs("gamaCF"));
            }
        }

        private string _gamaS;
        public string gamaS
        {
            get { return _gamaS; }
            set
            {
                _gamaS = value;
                OnPropertyChanged(new PropertyChangedEventArgs("gamaS"));
            }
        }

        private string _gamaF_IL;
        public string gamaF_IL
        {
            get { return _gamaF_IL; }
            set
            {
                _gamaF_IL = value;
                OnPropertyChanged(new PropertyChangedEventArgs("gamaF_IL"));
            }
        }

        private string _gamaF_CF;
        public string gamaF_CF
        {
            get { return _gamaF_CF; }
            set
            {
                _gamaF_CF = value;
                OnPropertyChanged(new PropertyChangedEventArgs("gamaF_CF"));
            }
        }

        private string _gamaK;
        public string gamaK
        {
            get { return _gamaK; }
            set
            {
                _gamaK = value;
                OnPropertyChanged(new PropertyChangedEventArgs("gamaK"));
            }
        }

        private string _gamaOnIL;
        public string gamaOnIL
        {
            get { return _gamaOnIL; }
            set
            {
                _gamaOnIL = value;
                OnPropertyChanged(new PropertyChangedEventArgs("gamaOnIL"));
            }
        }

        private string _gamaOnCF;
        public string gamaOnCF
        {
            get { return _gamaOnCF; }
            set
            {
                _gamaOnCF = value;
                OnPropertyChanged(new PropertyChangedEventArgs("gamaOnCF"));
            }
        }

        private string _zetaSoilL;
        public string zetaSoilL
        {
            get { return _zetaSoilL; }
            set
            {
                _zetaSoilL = value;
                OnPropertyChanged(new PropertyChangedEventArgs("zetaSoilL"));
            }
        }

        private string _zetaSoilV;
        public string zetaSoilV
        {
            get { return _zetaSoilV; }
            set
            {
                _zetaSoilV = value;
                OnPropertyChanged(new PropertyChangedEventArgs("zetaSoilV"));
            }
        }

        private string _zetaHydroL;
        public string zetaHydroL
        {
            get { return _zetaHydroL; }
            set
            {
                _zetaHydroL = value;
                OnPropertyChanged(new PropertyChangedEventArgs("zetaHydroL"));
            }
        }

        private string _zetaHydroV;
        public string zetaHydroV
        {
            get { return _zetaHydroV; }
            set
            {
                _zetaHydroV = value;
                OnPropertyChanged(new PropertyChangedEventArgs("zetaHydroV"));
            }
        }

        private string _zetaStrct;
        public string zetaStrct
        {
            get { return _zetaStrct; }
            set
            {
                _zetaStrct = value;
                OnPropertyChanged(new PropertyChangedEventArgs("zetaStrct"));
            }
        }

        private string _SCF;
        public string SCF
        {
            get { return _SCF; }
            set
            {
                _SCF = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SCF"));
            }
        }

        private string _kc;
        public string kc
        {
            get { return _kc; }
            set
            {
                _kc = value;
                OnPropertyChanged(new PropertyChangedEventArgs("kc"));
            }
        }

        private string _Iturb;
        public string Iturb
        {
            get { return _Iturb; }
            set
            {
                _Iturb = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Iturb"));
            }
        }

        private string _f0Ratio;
        public string f0Ratio
        {
            get { return _f0Ratio; }
            set
            {
                _f0Ratio = value;
                OnPropertyChanged(new PropertyChangedEventArgs("f0Ratio"));
            }
        }

        private string _usageFactor;
        public string usageFactor
        {
            get { return _usageFactor; }
            set
            {
                _usageFactor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("usageFactor"));
            }
        }

        private string _exposeYear;
        public string exposeYear
        {
            get { return _exposeYear; }
            set
            {
                _exposeYear = value;
                OnPropertyChanged(new PropertyChangedEventArgs("exposeYear"));
            }
        }

        private string _m_SN;
        public string m_SN
        {
            get { return _m_SN; }
            set
            {
                _m_SN = value;
                OnPropertyChanged(new PropertyChangedEventArgs("m_SN"));
            }
        }

        private string _C_SN;
        public string C_SN
        {
            get { return _C_SN; }
            set
            {
                _C_SN = value;
                OnPropertyChanged(new PropertyChangedEventArgs("C_SN"));
            }
        }

        private string _S0;
        public string S0
        {
            get { return _S0; }
            set
            {
                _S0 = value;
                OnPropertyChanged(new PropertyChangedEventArgs("S0"));
            }
        }

        private bool _IsSNReadOnly;
        public bool IsSNReadOnly
        {
            get { return _IsSNReadOnly; }
            set
            {
                _IsSNReadOnly = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsSNReadOnly"));
            }
        }

        private int _SNClassSelectionIndex = -1;
        public int SNClassSelectionIndex
        {
            get { return _SNClassSelectionIndex; }
            set
            {
                _SNClassSelectionIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SNClassSelectionIndex"));

                if (SNClassSelectionIndex > -1 && SNClassSelectionIndex < 9)
                {
                    this.C_SN = this.dicSNCurveClass[SNClassSelectionIndex][0];
                    this.m_SN = this.dicSNCurveClass[SNClassSelectionIndex][1];
                    this.S0 = this.dicSNCurveClass[SNClassSelectionIndex][2];
                    this.IsSNReadOnly = true;
                }
                else
                {
                    this.IsSNReadOnly = false;
                }
            }
        }
    }
}
