using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace WebAppJwt.ViewModels.Module1
{
    public class InpPipeData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public InpPipeData()
        {

        }

        // ==========================================================================
        // INPUT PARAMETERS
        // ==========================================================================

        private int _ConcreteTypeSelectedIndex = 0;
        public int ConcreteTypeSelectedIndex
        {
            get { return _ConcreteTypeSelectedIndex; }
            set
            {
                _ConcreteTypeSelectedIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ConcreteTypeSelectedIndex"));
            }
        }


        private string _CrushYConc;
        public string CrushYConc
        {
            get { return _CrushYConc; }
            set
            {
                _CrushYConc = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CrushYConc"));
            }
        }

        private string _BConc;
        public string BConc
        {
            get { return _BConc; }
            set
            {
                _BConc = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BConc"));
            }
        }

        private string _HConc;
        public string HConc
        {
            get { return _HConc; }
            set
            {
                _HConc = value;
                OnPropertyChanged(new PropertyChangedEventArgs("HConc"));
            }
        }

        private string _X0Conc;
        public string X0Conc
        {
            get { return _X0Conc; }
            set
            {
                _X0Conc = value;
                OnPropertyChanged(new PropertyChangedEventArgs("X0Conc"));
            }
        }


        private string _Ds;
        public string Ds
        {
            get { return _Ds; }
            set {
                _Ds = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Ds"));
            }
        }

        private string _WT;
        public string WT
        {
            get { return _WT; }
            set { _WT = value; OnPropertyChanged(new PropertyChangedEventArgs("WT")); }
        }

        private string _nu;
        public string nu
        {
            get { return _nu; }
            set { _nu = value; OnPropertyChanged(new PropertyChangedEventArgs("nu")); }
        }

        private string _E;
        public string E
        {
            get { return _E; }
            set { _E = value; OnPropertyChanged(new PropertyChangedEventArgs("E")); }
        }

        private string _rhoSteel;
        public string rhoSteel
        {
            get { return _rhoSteel; }
            set { _rhoSteel = value; OnPropertyChanged(new PropertyChangedEventArgs("rhoSteel")); }
        }

        private string _alfaT;
        public string alfaT
        {
            get { return _alfaT; }
            set { _alfaT = value; OnPropertyChanged(new PropertyChangedEventArgs("alfaT")); }
        }

        private string _tCoat;
        public string tCoat
        {
            get { return _tCoat; }
            set { _tCoat = value; OnPropertyChanged(new PropertyChangedEventArgs("tCoat")); }
        }

        private string _rhoCoat;
        public string rhoCoat
        {
            get { return _rhoCoat; }
            set { _rhoCoat = value; OnPropertyChanged(new PropertyChangedEventArgs("rhoCoat")); }
        }

        //private string _tCorr;
        //public string tCorr
        //{
        //    get { return _tCorr; }
        //    set { _tCorr = value; OnPropertyChanged(new PropertyChangedEventArgs("tCorr")); }
        //}

        //private string _rhoCorr;
        //public string rhoCorr
        //{
        //    get { return _rhoCorr; }
        //    set { _rhoCorr = value; OnPropertyChanged(new PropertyChangedEventArgs("rhoCorr")); }
        //}

        private string _tConc;
        public string tConc
        {
            get { return _tConc; }
            set { _tConc = value; OnPropertyChanged(new PropertyChangedEventArgs("tConc")); }
        }

        private string _rhoConc;
        public string rhoConc
        {
            get { return _rhoConc; }
            set { _rhoConc = value; OnPropertyChanged(new PropertyChangedEventArgs("rhoConc")); }
        }

        private string _fc;
        public string fc
        {
            get { return _fc; }
            set { _fc = value; OnPropertyChanged(new PropertyChangedEventArgs("fc")); }
        }

        private string _EConc;
        public string EConc
        {
            get { return _EConc; }
            set { _EConc = value; OnPropertyChanged(new PropertyChangedEventArgs("EConc")); }
        }

        private string _surfaceRoughness;
        public string surfaceRoughness
        {
            get { return _surfaceRoughness; }
            set { _surfaceRoughness = value; OnPropertyChanged(new PropertyChangedEventArgs("surfaceRoughness")); }
        }

        private string _AmpCD;
        public string AmpCD
        {
            get { return _AmpCD; }
            set { _AmpCD = value; OnPropertyChanged(new PropertyChangedEventArgs("AmpCD")); }
        }

        private string _AmpCL;
        public string AmpCL
        {
            get { return _AmpCL; }
            set { _AmpCL = value; OnPropertyChanged(new PropertyChangedEventArgs("AmpCL")); }
        }

        private string _YieldStress;
        public string YieldStress
        {
            get
            {
                return _YieldStress;
            }
            set
            {
                _YieldStress = value;
                OnPropertyChanged(new PropertyChangedEventArgs("YieldStress"));
            }
        }
        // ==========================================================================
        // INTERMEDIATE PARAMETERS
        // ==========================================================================

        //private string _Di;
        //public string Di
        //{
        //    get { return _Di; }
        //    set { _Di = value; OnPropertyChanged(new PropertyChangedEventArgs("Di")); }
        //}

        //private string _OD;
        //public string OD
        //{
        //    get { return _OD; }
        //    set { _OD = value; OnPropertyChanged(new PropertyChangedEventArgs("OD")); }
        //}

        //private string _pipeArea;
        //public string pipeArea
        //{
        //    get { return _pipeArea; }
        //    set { _pipeArea = value; OnPropertyChanged(new PropertyChangedEventArgs("pipeArea")); }
        //}

        //private string _pipeI;
        //public string pipeI
        //{
        //    get { return _pipeI; }
        //    set { _pipeI = value; OnPropertyChanged(new PropertyChangedEventArgs("pipeI")); }
        //}

        //private string _concI;
        //public string concI
        //{
        //    get { return _concI; }
        //    set { _concI = value; OnPropertyChanged(new PropertyChangedEventArgs("concI")); }
        //}

        //private string _pipeMass;
        //public string pipeMass
        //{
        //    get { return _pipeMass; }
        //    set { _pipeMass = value; OnPropertyChanged(new PropertyChangedEventArgs("pipeMass")); }
        //}

        //private string _addedMass;
        //public string addedMass
        //{
        //    get { return _addedMass; }
        //    set { _addedMass = value; OnPropertyChanged(new PropertyChangedEventArgs("addedMass")); }
        //}

        //private string _dryWeight;
        //public string dryWeight
        //{
        //    get { return _dryWeight; }
        //    set { _dryWeight = value; OnPropertyChanged(new PropertyChangedEventArgs("dryWeight")); }
        //}

        //private string _SubW;
        //public string SubW
        //{
        //    get { return _SubW; }
        //    set { _SubW = value; OnPropertyChanged(new PropertyChangedEventArgs("SubW")); }
        //}

        //private string _SG;
        //public string SG
        //{
        //    get { return _dryWeight; }
        //    set { _SG = value; OnPropertyChanged(new PropertyChangedEventArgs("SG")); }
        //}
    }
}
