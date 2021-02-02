using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
//using System.Data.SQLite;
using System.Data;
//using LiveCharts;
//using LiveCharts.Wpf;
//using LiveCharts.Defaults;
using System.Windows;

using WebAppJwt.Models;
using WebAppJwt.Models.InterfaceDLL;


namespace WebAppJwt.ViewModels.Module1
{
    public class InpECAData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        #region Constructor
        public InpECAData()
        {
            Formatter = value => value.ToString("N2");
        }

        #endregion

        #region Properties

        public Func<double, string> Formatter { get; set; }

        /********************************************
         * 
         * ADDITIONAL MATERIAL PROPERTIES
         * 
         ********************************************/

        private string _UTS;
        public string UTS
        {
            get { return _UTS; }
            set
            {
                _UTS = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UTS"));
            }
        }

        private string _eps_YS;
        public string eps_YS
        {
            get { return _eps_YS; }
            set
            {
                _eps_YS = value;
                OnPropertyChanged(new PropertyChangedEventArgs("eps_YS"));
            }
        }

        private string _eps_UTS;
        public string eps_UTS
        {
            get { return _eps_UTS; }
            set
            {
                _eps_UTS = value;
                OnPropertyChanged(new PropertyChangedEventArgs("eps_UTS"));
            }
        }

        private int _FracToughTypeSelectedIndex;
        public int FracToughTypeSelectedIndex
        {
            get { return _FracToughTypeSelectedIndex; }
            set
            {
                _FracToughTypeSelectedIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FracToughTypeSelectedIndex"));

                if (_FracToughTypeSelectedIndex == 0)
                {
                    isKmatEnabled = true;
                }
                else
                {
                    isKmatEnabled = false;
                }
            }
        }

        private bool _isKmatEnabled = true;
        public bool isKmatEnabled
        {
            get { return _isKmatEnabled; }
            set
            {
                _isKmatEnabled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isKmatEnabled"));
            }
        }

        private string _Kmat;
        public string Kmat
        {
            get { return _Kmat; }
            set
            {
                _Kmat = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Kmat"));
            }
        }


        private string _CVN;
        public string CVN
        {
            get { return _CVN; }
            set
            {
                _CVN = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CVN"));
            }
        }

        private bool _isLuderPlateauChecked;
        public bool isLuderPlateauChecked
        {
            get { return _isLuderPlateauChecked; }
            set
            {
                _isLuderPlateauChecked = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isLuderPlateauChecked"));

                chkLuderEndEnability();
                //UpdateStressStrain();
            }
        }

        private int _LuderStrainSelectionIndex;
        public int LuderStrainSelectionIndex
        {
            get { return _LuderStrainSelectionIndex; }
            set
            {
                _LuderStrainSelectionIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LuderStrainSelectionIndex"));

                chkLuderEndEnability();
                //UpdateStressStrain();
            }
        }

        private string _LuderEndStrain;
        public string LuderEndStrain
        {
            get { return _LuderEndStrain; }
            set
            {
                _LuderEndStrain = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LuderEndStrain"));

                //UpdateStressStrain();
            }
        }

        private bool _isLuderEndStrainEnabled;
        public bool isLuderEndStrainEnabled
        {
            get { return _isLuderEndStrainEnabled; }
            set
            {
                _isLuderEndStrainEnabled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isLuderEndStrainEnabled"));

                //UpdateStressStrain();
            }
        }

        /********************************************
         * 
         * CRACK AND WELD SPECIFICATION
         * 
         ********************************************/

        private int _CrackTypeSelectedIndx;
        public int CrackTypeSelectedIndx
        {
            get { return _CrackTypeSelectedIndx; }
            set
            {
                _CrackTypeSelectedIndx = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CrackTypeSelectedIndx"));
            }
        }

        private int _FCGCSelectedIndx;
        public int FCGCSelectedIndx
        {
            get { return _FCGCSelectedIndx; }
            set
            {
                _FCGCSelectedIndx = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FCGCSelectedIndx"));
            }
        }

        private string _CrackHeight;
        public string CrackHeight
        {
            get { return _CrackHeight; }
            set
            {
                _CrackHeight = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CrackHeight"));
            }
        }

        private string _CrackLength;
        public string CrackLength
        {
            get { return _CrackLength; }
            set
            {
                _CrackLength = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CrackLength"));
            }
        }

        private string _CrackLigament;
        public string CrackLigament
        {
            get { return _CrackLigament; }
            set
            {
                _CrackLigament = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CrackLigament"));
            }
        }

        private string _CapLength;
        public string CapLength
        {
            get { return _CapLength; }
            set
            {
                _CapLength = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CapLength"));
            }
        }

        private string _RootLength;
        public string RootLength
        {
            get { return _RootLength; }
            set
            {
                _RootLength = value;
                OnPropertyChanged(new PropertyChangedEventArgs("RootLength"));
            }
        }

        private string _hilo;
        public string hilo
        {
            get { return _hilo; }
            set
            {
                _hilo = value;
                OnPropertyChanged(new PropertyChangedEventArgs("hilo"));
            }
        }

        /********************************************
        * 
        * FAD DIAGRAM
        * 
        ********************************************/

        private int _FADOptionSelectedIndex;
        public int FADOptionSelectedIndex
        {
            get { return _FADOptionSelectedIndex; }
            set
            {
                _FADOptionSelectedIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FADOptionSelectedIndex"));


            }
        }

        private string _Lrmax;
        public string Lrmax
        {
            get { return _Lrmax; }
            set
            {
                _Lrmax = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Lrmax"));
            }
        }

        private bool _isLrmaxUserDefined;
        public bool isLrmaxUserDefined
        {
            get { return _isLrmaxUserDefined; }
            set
            {
                _isLrmaxUserDefined = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isLrmaxUserDefined"));
            }
        }

        private bool _isStressStrainEnabled;
        public bool isStressStrainEnabled
        {
            get { return _isStressStrainEnabled; }
            set
            {
                _isStressStrainEnabled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isStressStrainEnabled"));
            }
        }

        private int _StressStrainCurveSelectedIndex;
        public int StressStrainCurveSelectedIndex
        {
            get { return _StressStrainCurveSelectedIndex; }
            set
            {
                _StressStrainCurveSelectedIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("StressStrainCurveSelectedIndex"));

                if (_StressStrainCurveSelectedIndex == 0)
                {
                    isLoadBtnEnabled = false;
                }
                else
                {
                    isLoadBtnEnabled = true;
                }
            }
        }

        private bool _isLoadBtnEnabled;
        public bool isLoadBtnEnabled
        {
            get { return _isLoadBtnEnabled; }
            set
            {
                _isLoadBtnEnabled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isLoadBtnEnabled"));
            }
        }

        private bool _isStressStrainAltered = false;
        public bool isStressStrainAltered
        {
            get { return _isStressStrainAltered; }
            set
            {
                _isStressStrainAltered = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isStressStrainAltered"));
            }
        }



        private DataTable _dtStressStrain = new DataTable();
        public DataTable dtStressStrain
        {
            get { return _dtStressStrain; }
            set
            {
                _dtStressStrain = value;
                OnPropertyChanged(new PropertyChangedEventArgs("dtStressStrain"));
            }
        }


        /********************************************
        * 
        * LOADING INFORMATION
        * 
        ********************************************/

        private string _Pm;
        public string Pm
        {
            get { return _Pm; }
            set
            {
                _Pm = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Pm"));
            }
        }

        private string _Pb;
        public string Pb
        {
            get { return _Pb; }
            set
            {
                _Pb = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Pb"));
            }
        }

        private string _Qm;
        public string Qm
        {
            get { return _Qm; }
            set
            {
                _Qm = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Qm"));
            }
        }

        private string _Qb;
        public string Qb
        {
            get { return _Qb; }
            set
            {
                _Qb = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Qb"));
            }
        }

        private DataTable _dtCyclicLoad = new DataTable();
        public DataTable dtCyclicLoad
        {
            get { return _dtCyclicLoad; }
            set
            {
                _dtCyclicLoad = value;
                OnPropertyChanged(new PropertyChangedEventArgs("dtCyclicLoad"));
            }
        }

        private bool _IsCyclicTblStrctChanged = false;
        public bool IsCyclicTblStrctChanged
        {
            get { return _IsCyclicTblStrctChanged; }
            set
            {
                _IsCyclicTblStrctChanged = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsCyclicTblStrctChanged"));
            }
        }

        private int _LoadingEntrySelectionIndex = -1;
        public int LoadingEntrySelectionIndex
        {
            get { return _LoadingEntrySelectionIndex; }
            set
            {
                _LoadingEntrySelectionIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LoadingEntrySelectionIndex"));

                if (LoadingEntrySelectionIndex == 1)
                {
                    IsLoadingUserDefined = true;
                }
                else
                {
                    IsLoadingUserDefined = false;
                }
            }
        }

        private bool _IsLoadingUserDefined = false;
        public bool IsLoadingUserDefined
        {
            get { return _IsLoadingUserDefined; }
            set
            {
                _IsLoadingUserDefined = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsLoadingUserDefined"));
            }
        }

        #endregion


        #region Methods

        void chkLuderEndEnability()
        {
            if (this.isLuderPlateauChecked && this.LuderStrainSelectionIndex == 1)
            {
                this.isLuderEndStrainEnabled = true;
            }
            else
            {
                this.isLuderEndStrainEnabled = false;
            }
        }

        public void fillDefaultCyclicTable()
        {
            addNewCyclicLoadRow("10000", "50.0", "2.0");
            addNewCyclicLoadRow("20000", "100.0", "3.0");
            addNewCyclicLoadRow("30000", "150.0", "8.0");
        }

        public void addNewCyclicLoadRow()
        {
            DataRow row;
            row = dtCyclicLoad.NewRow();
            dtCyclicLoad.Rows.Add(row);
        }

        public void addNewCyclicLoadRow(string NumCycle, string Pm, string Pb)
        {
            DataRow row;
            row = dtCyclicLoad.NewRow();
            dtCyclicLoad.Rows.Add(row);
        }

        public void deleteCyclicLoadRow(int i)
        {
            dtCyclicLoad.Rows[i].Delete();
        }

        public void UpdateStressStrain()
        {

        }

        void updateStressStrainChart(double[] ECA_Sigma_Vec, double[] ECA_Eps_Vec)
        {

        }

        public void UpdateFADChart()
        {

        }

        public void loadStressStrainCurve()
        {
        }
    }
    #endregion
}