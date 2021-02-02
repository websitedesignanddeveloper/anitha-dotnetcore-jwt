using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Data;
using WebAppJwt.Models;
using WebAppJwt.ViewModels;

namespace WebAppJwt.ViewModels.Module1
{
    public class ViewModelModule1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        #region Property

        string paraCol = "Parameter";
        string valCol = "Value";
        string unitCol = "Unit";


        private bool _isSavePending = false;
        public bool isSavePending
        {
            get { return _isSavePending; }
            set
            {
                _isSavePending = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isSavePending"));
            }
        }

     

        private ViewSettingsModule1 _DisplaySettings = new ViewSettingsModule1();
        public ViewSettingsModule1 DisplaySettings
        {
            get { return _DisplaySettings; }
            set
            {
                _DisplaySettings = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DisplaySettings"));
            }
        }

        private ViewSettingsModule1 _StandardData = new ViewSettingsModule1();
        public ViewSettingsModule1 StandardData
        {
            get { return _StandardData; }
            set
            {
                _StandardData = value;
                OnPropertyChanged(new PropertyChangedEventArgs("StandardData"));
            }
        }

        private ValidateInputs _ValidateDataEntries = new ValidateInputs();
        public ValidateInputs ValidateDataEntries
        {
            get { return _ValidateDataEntries; }
            set
            {
                _ValidateDataEntries = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ValidateDataEntries"));
            }
        }

     

        private int _FlowModelSelectedIndex = 0;
        public int FlowModelSelectedIndex
        {
            get { return _FlowModelSelectedIndex; }
            set
            {
                _FlowModelSelectedIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FlowModelSelectedIndex"));
                if (FlowModelSelectedIndex == 0)
                {
                    this.DisplaySettings.RiverData.FlowModel = "Chezy";
                }
                else
                {
                    this.DisplaySettings.RiverData.FlowModel = "Manning";
                }
            }
        }

        private int _tabIndex;
        public int tabIndex
        {
            get { return _tabIndex; }
            set { _tabIndex = value; OnPropertyChanged(new PropertyChangedEventArgs("tabIndex")); }
        }

        #endregion Property


        #region Constructor

        public ViewModelModule1()
        {

        }

        #endregion


        #region Method

        public void refreshModule1(object sender)
        {
            

          
        }

        public void refreshModule1()
        {
            
        }


        public void setDefaultData()
        {
            // Set Default Values for Pipe
            // -----------------------------
            DisplaySettings.PipeData.Ds = "609.6";                                                                  // m
            DisplaySettings.PipeData.WT = "20.0";                                                                  // m
            DisplaySettings.PipeData.tCoat = "6.0";                                                                // m
            DisplaySettings.PipeData.tConc = "50";                                                                // [-]
            DisplaySettings.PipeData.surfaceRoughness = "0.01";                                                     // m
            DisplaySettings.PipeData.AmpCD = "1.0";
            DisplaySettings.PipeData.AmpCL = "1.0";

            DisplaySettings.PipeData.rhoSteel = "7850.0";                                                            // kg/m3
            DisplaySettings.PipeData.rhoCoat = "1300.0";                                                             // kg/m3
            DisplaySettings.PipeData.rhoConc = "2300.0";                                                             // kg/m3
            DisplaySettings.PipeData.E = "207000.0"; // (207.0 * Math.Pow(10, 9)).ToString();                                                  // Pa            
            DisplaySettings.PipeData.fc = "55.0";                                                                    // MPa
            DisplaySettings.PipeData.EConc = (10000.0 * Math.Pow(Convert.ToDouble(DisplaySettings.PipeData.fc), 0.3)).ToString();          // Pa
            DisplaySettings.PipeData.nu = "0.3";
            DisplaySettings.PipeData.alfaT = (1.16 / 100000 ).ToString();              // Math.Pow(10, -5)                                // C
            DisplaySettings.PipeData.YieldStress = "450.0";

            DisplaySettings.PipeData.ConcreteTypeSelectedIndex = 0;
            DisplaySettings.PipeData.CrushYConc = "160.0";
            DisplaySettings.PipeData.BConc = "300.0";
            DisplaySettings.PipeData.HConc = "20.0";
            DisplaySettings.PipeData.X0Conc = "10.0";

            // Set Default Values for Functional Data
            // ---------------------------------------
            DisplaySettings.FuncData.g = "9.81";
            DisplaySettings.FuncData.rhoContent = "120.0";
            DisplaySettings.FuncData.rhoWater = "1000.0";
            DisplaySettings.FuncData.Tin = "10.0";
            DisplaySettings.FuncData.Tout = "10.0";
            DisplaySettings.FuncData.Pin = "1.20";
            DisplaySettings.FuncData.Pout = "100.0";    //kPa
            DisplaySettings.FuncData.Tres = "0.0";

            // Set Default Values for River-Discharge Data
            // --------------------------------------------
            DisplaySettings.RiverData.FlowModel = "Chezy";
            DisplaySettings.RiverData.Coeff = "40.0";
            DisplaySettings.RiverData.Ip = "0.1";
            DisplaySettings.RiverData.NumEvents = "5";
            DisplaySettings.RiverData.qMin = "5.0";
            DisplaySettings.RiverData.qMax = "30.0";            

            // Set Default Values for River-Crossing Data
            // --------------------------------------------
            DisplaySettings.CrossData.minLspan = "10";
            DisplaySettings.CrossData.maxLspan = "40";
            DisplaySettings.CrossData.numLspan = "5";
            DisplaySettings.CrossData.minGap = "-1";
            DisplaySettings.CrossData.maxGap = "1";
            DisplaySettings.CrossData.numGap = "10";
            DisplaySettings.CrossData.minDelonD = "0";
            DisplaySettings.CrossData.minHeonD = "2";
            DisplaySettings.CrossData.minTheta = "90";
            DisplaySettings.CrossData.minZonD = "0";
            DisplaySettings.CrossData.isLspanRangeChecked = true;
            DisplaySettings.CrossData.isGapRangeChecked = true;

            DisplaySettings.RiverData.UpdateNumRowsDurationTable();

            // Set Default Values for Soil Data
            // -----------------------------------
            DisplaySettings.SoilData.CmbSoilTypeSelectedIndex = 2;
            DisplaySettings.SoilData.SoilStiffModelSelectionIndex = 0;
            DisplaySettings.SoilData.setSoilParams();
            DisplaySettings.SoilData.fc = "0.25";
            DisplaySettings.SoilData.fphi = "0.60";


            // Set Default Values for Fatigue Data
            // ------------------------------------
            DisplaySettings.FatData.SNClassSelectionIndex = 0;
            DisplaySettings.FatData.gamaIL = "1.4";
            DisplaySettings.FatData.gamaCF = "1.4";
            DisplaySettings.FatData.gamaS = "1.3";
            DisplaySettings.FatData.gamaF_IL = "1.1";
            DisplaySettings.FatData.gamaF_CF = "1.1";
            DisplaySettings.FatData.gamaK = "1.15";
            DisplaySettings.FatData.gamaOnIL = "1.20";
            DisplaySettings.FatData.gamaOnCF = "1.10";
            DisplaySettings.FatData.Iturb = "0.05";
            DisplaySettings.FatData.f0Ratio = "2.7";
            DisplaySettings.FatData.exposeYear = "1";
            DisplaySettings.FatData.kc = "0.25";
            DisplaySettings.FatData.SCF = "1.0";
            DisplaySettings.FatData.zetaSoilL = "0.015";
            DisplaySettings.FatData.zetaSoilV = "0.015";
            DisplaySettings.FatData.zetaHydroL = "0.0";
            DisplaySettings.FatData.zetaHydroV = "0.0";
            DisplaySettings.FatData.zetaStrct = "0.015";
            DisplaySettings.FatData.usageFactor = "0.3";

            // Set Default Values for ECA Data
            // ------------------------------------
            DisplaySettings.EcaData.eps_YS = "0.005";
            DisplaySettings.EcaData.UTS = "535.0";
            DisplaySettings.EcaData.eps_UTS = "0.080";
            DisplaySettings.EcaData.FracToughTypeSelectedIndex = 0;
            DisplaySettings.EcaData.Kmat = "6000.0";
            DisplaySettings.EcaData.CVN = "30.0";
            DisplaySettings.EcaData.isLuderPlateauChecked = true;
            DisplaySettings.EcaData.LuderStrainSelectionIndex = 0;
            DisplaySettings.EcaData.LuderEndStrain = "0.015";

            DisplaySettings.EcaData.CrackTypeSelectedIndx = 0;
            DisplaySettings.EcaData.FCGCSelectedIndx = 0;
            DisplaySettings.EcaData.CrackHeight = "4.0";
            DisplaySettings.EcaData.CrackLength = "20.0";
            DisplaySettings.EcaData.CrackLigament = "1.0";
            DisplaySettings.EcaData.CapLength = "17.0";
            DisplaySettings.EcaData.RootLength = "8.0";
            DisplaySettings.EcaData.hilo = "1.0";
            DisplaySettings.EcaData.LoadingEntrySelectionIndex = 0;


            DisplaySettings.EcaData.FADOptionSelectedIndex = 0;
            DisplaySettings.EcaData.StressStrainCurveSelectedIndex = 0;
            DisplaySettings.EcaData.isLrmaxUserDefined = false;
            DisplaySettings.EcaData.Lrmax = "1.19";

            DisplaySettings.EcaData.Pm = DisplaySettings.PipeData.YieldStress;
            DisplaySettings.EcaData.Pb = "0.0";
            DisplaySettings.EcaData.Qm = "0.0";
            DisplaySettings.EcaData.Qb = "0.0";
            DisplaySettings.EcaData.fillDefaultCyclicTable();

            // Checking the Unit Selection
            // ------------------------------------

          

            // Converting Display Data To Standard
            // ------------------------------------
         
        }


        public void ClearSettings()
        {
            DisplaySettings = new ViewSettingsModule1();
            StandardData = new ViewSettingsModule1();
        }


        #region Data Converter

        public void ConvertStandardToDisplay(ViewSettingsModule1 standard, ViewSettingsModule1 display)
        {
            //ViewSettingsModule1 tmp = new ViewSettingsModule1();
            //tmp.CopySettings(StandardData);
            //DisplaySettings = tmp;
           
        }

        public void ConvertDisplayToStandard(ViewSettingsModule1 display, ViewSettingsModule1 standard)
        {
            //ViewSettingsModule1 tmp = new ViewSettingsModule1();
            //tmp.CopySettings(DisplaySettings);
            //StandardData = tmp;
           
        }

        public void SI_To_English(ViewSettingsModule1 display)
        {
            
        }

        public void English_To_SI(ViewSettingsModule1 display)
        {
           
        }


        public bool isDisplayEqualToStandard(ViewSettingsModule1 display, ViewSettingsModule1 standard)
        {
            bool isEqual = true;
            ViewSettingsModule1 tmpStandard = new ViewSettingsModule1();
            display.CopySettingsTo(tmpStandard);

            ConvertDisplayToStandard(display, tmpStandard);

            double toler = 0.000001;
            double sum = 0;

            // Compare Standard and Display Pipe Data
            // ================================================

            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.Ds) - Convert.ToDouble(standard.PipeData.Ds));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.E) - Convert.ToDouble(standard.PipeData.E));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.EConc) - Convert.ToDouble(standard.PipeData.EConc));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.surfaceRoughness) - Convert.ToDouble(standard.PipeData.surfaceRoughness));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.tCoat) - Convert.ToDouble(standard.PipeData.tCoat));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.tConc) - Convert.ToDouble(standard.PipeData.tConc));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.WT) - Convert.ToDouble(standard.PipeData.WT));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.fc) - Convert.ToDouble(standard.PipeData.fc));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.rhoCoat) - Convert.ToDouble(standard.PipeData.rhoCoat));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.rhoConc) - Convert.ToDouble(standard.PipeData.rhoConc));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.rhoSteel) - Convert.ToDouble(standard.PipeData.rhoSteel));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.alfaT) - Convert.ToDouble(standard.PipeData.alfaT));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.nu) - Convert.ToDouble(standard.PipeData.nu));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.AmpCD) - Convert.ToDouble(standard.PipeData.AmpCD));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.AmpCL) - Convert.ToDouble(standard.PipeData.AmpCL));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.YieldStress) - Convert.ToDouble(standard.PipeData.YieldStress));

            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.ConcreteTypeSelectedIndex) - Convert.ToDouble(standard.PipeData.ConcreteTypeSelectedIndex));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.CrushYConc) - Convert.ToDouble(standard.PipeData.CrushYConc));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.BConc) - Convert.ToDouble(standard.PipeData.BConc));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.HConc) - Convert.ToDouble(standard.PipeData.HConc));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.PipeData.X0Conc) - Convert.ToDouble(standard.PipeData.X0Conc));

            // Compare Standard and Display Functional Data
            // ================================================
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FuncData.Pin) - Convert.ToDouble(standard.FuncData.Pin));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FuncData.Pout) - Convert.ToDouble(standard.FuncData.Pout));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FuncData.g) - Convert.ToDouble(standard.FuncData.g));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FuncData.rhoContent) - Convert.ToDouble(standard.FuncData.rhoContent));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FuncData.rhoWater) - Convert.ToDouble(standard.FuncData.rhoWater));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FuncData.Tin) - Convert.ToDouble(standard.FuncData.Tin));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FuncData.Tout) - Convert.ToDouble(standard.FuncData.Tout));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FuncData.Tres) - Convert.ToDouble(standard.FuncData.Tres));

            // Compare Standard and Display  River Data
            // ===========================================
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.RiverData.Coeff) - Convert.ToDouble(standard.RiverData.Coeff));

            if (tmpStandard.RiverData.FlowModel != standard.RiverData.FlowModel)
            {
                sum = sum + 1;
            }
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.RiverData.Ip) - Convert.ToDouble(standard.RiverData.Ip));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.RiverData.NumEvents) - Convert.ToDouble(standard.RiverData.NumEvents));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.RiverData.qMax) - Convert.ToDouble(standard.RiverData.qMax));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.RiverData.qMin) - Convert.ToDouble(standard.RiverData.qMin));

            int num1 = Convert.ToInt32(standard.RiverData.NumEvents);
            int num2 = Convert.ToInt32(tmpStandard.RiverData.NumEvents);

            if (num1 != num2)
            {
                sum = sum + 1;
            }
            else
            {
                for (int i = 0; i < num1; i++)
                {
                    foreach (DataColumn col in tmpStandard.RiverData.dtDuration.Columns)
                    {
                        sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.RiverData.dtDuration.Rows[i][col.ColumnName]) - Convert.ToDouble(standard.RiverData.dtDuration.Rows[i][col.ColumnName]));
                    }
                }
            }


            // Compare Standard and Display Crossing Data 
            // ===========================================
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.minLspan) - Convert.ToDouble(standard.CrossData.minLspan));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.maxLspan) - Convert.ToDouble(standard.CrossData.maxLspan));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.numLspan) - Convert.ToDouble(standard.CrossData.numLspan));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.minGap) - Convert.ToDouble(standard.CrossData.minGap));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.maxGap) - Convert.ToDouble(standard.CrossData.maxGap));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.numGap) - Convert.ToDouble(standard.CrossData.numGap));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.minDelonD) - Convert.ToDouble(standard.CrossData.minDelonD));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.minHeonD) - Convert.ToDouble(standard.CrossData.minHeonD));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.minTheta) - Convert.ToDouble(standard.CrossData.minTheta));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.CrossData.minZonD) - Convert.ToDouble(standard.CrossData.minZonD));
            sum = sum + Math.Abs(Convert.ToDouble(Convert.ToInt32(tmpStandard.CrossData.isGapRangeChecked)) - Convert.ToDouble(Convert.ToInt32(standard.CrossData.isGapRangeChecked)));
            sum = sum + Math.Abs(Convert.ToDouble(Convert.ToInt32(tmpStandard.CrossData.isLspanRangeChecked)) - Convert.ToDouble(Convert.ToInt32(standard.CrossData.isLspanRangeChecked)));

            // Compare Standard and Display Soil Data 
            // ===========================================
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.CL) - Convert.ToDouble(standard.SoilData.CL));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.CV) - Convert.ToDouble(standard.SoilData.CV));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.Cu) - Convert.ToDouble(standard.SoilData.Cu));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.eSoil) - Convert.ToDouble(standard.SoilData.eSoil));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.fc) - Convert.ToDouble(standard.SoilData.fc));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.fphi) - Convert.ToDouble(standard.SoilData.fphi));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.FricAngle) - Convert.ToDouble(standard.SoilData.FricAngle));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.Ip) - Convert.ToDouble(standard.SoilData.Ip));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.MuL) - Convert.ToDouble(standard.SoilData.MuL));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.NuSoil) - Convert.ToDouble(standard.SoilData.NuSoil));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.OCR) - Convert.ToDouble(standard.SoilData.OCR));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.SoilData.SoilSubWeight) - Convert.ToDouble(standard.SoilData.SoilSubWeight));
            sum = sum + Math.Abs(tmpStandard.SoilData.SoilStiffModelSelectionIndex - standard.SoilData.SoilStiffModelSelectionIndex);
            if (tmpStandard.SoilData.SoilTypeClass != standard.SoilData.SoilTypeClass)
            {
                sum = sum + 1;
            }
            if (tmpStandard.SoilData.SoilType != standard.SoilData.SoilType)
            {
                sum = sum + 1;
            }

            // CHECKING IF BASIC ENTRIES ARE ALTERED
            // =====================================
            double sumBasic = sum;
            if (sumBasic > toler)
            {
                DisplaySettings.isBasicEntryAltered = true;
            }

            // Compare Standard and Display Fatigue Data 
            // ===========================================
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.gamaIL) - Convert.ToDouble(standard.FatData.gamaIL));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.gamaCF) - Convert.ToDouble(standard.FatData.gamaCF));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.gamaS) - Convert.ToDouble(standard.FatData.gamaS));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.gamaF_IL) - Convert.ToDouble(standard.FatData.gamaF_IL));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.gamaF_CF) - Convert.ToDouble(standard.FatData.gamaF_CF));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.gamaK) - Convert.ToDouble(standard.FatData.gamaK));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.gamaOnIL) - Convert.ToDouble(standard.FatData.gamaOnIL));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.gamaOnCF) - Convert.ToDouble(standard.FatData.gamaOnCF));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.Iturb) - Convert.ToDouble(standard.FatData.Iturb));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.f0Ratio) - Convert.ToDouble(standard.FatData.f0Ratio));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.exposeYear) - Convert.ToDouble(standard.FatData.exposeYear));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.kc) - Convert.ToDouble(standard.FatData.kc));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.SCF) - Convert.ToDouble(standard.FatData.SCF));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.C_SN) - Convert.ToDouble(standard.FatData.C_SN));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.m_SN) - Convert.ToDouble(standard.FatData.m_SN));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.S0) - Convert.ToDouble(standard.FatData.S0));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.zetaSoilL) - Convert.ToDouble(standard.FatData.zetaSoilL));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.zetaSoilV) - Convert.ToDouble(standard.FatData.zetaSoilV));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.zetaHydroL) - Convert.ToDouble(standard.FatData.zetaHydroL));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.zetaHydroV) - Convert.ToDouble(standard.FatData.zetaHydroV));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.zetaStrct) - Convert.ToDouble(standard.FatData.zetaStrct));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.FatData.usageFactor) - Convert.ToDouble(standard.FatData.usageFactor));
            sum = sum + Math.Abs(tmpStandard.FatData.SNClassSelectionIndex - standard.FatData.SNClassSelectionIndex);

            // CHECKING IF FATIGUE ENTRIES ARE ALTERED
            // =======================================
            double sumFat = sum - sumBasic;
            if (sumFat > toler)
            {
                DisplaySettings.isFatigueEntryAltered = true;
            }

            // Compare Standard and Display ECA Data 
            // ===========================================
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.CapLength) - Convert.ToDouble(standard.EcaData.CapLength));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.CrackHeight) - Convert.ToDouble(standard.EcaData.CrackHeight));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.CrackLength) - Convert.ToDouble(standard.EcaData.CrackLength));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.CrackLigament) - Convert.ToDouble(standard.EcaData.CrackLigament));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.CrackTypeSelectedIndx) - Convert.ToDouble(standard.EcaData.CrackTypeSelectedIndx));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.CVN) - Convert.ToDouble(standard.EcaData.CVN));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.eps_UTS) - Convert.ToDouble(standard.EcaData.eps_UTS));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.eps_YS) - Convert.ToDouble(standard.EcaData.eps_YS));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.FADOptionSelectedIndex) - Convert.ToDouble(standard.EcaData.FADOptionSelectedIndex));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.FCGCSelectedIndx) - Convert.ToDouble(standard.EcaData.FCGCSelectedIndx));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.FracToughTypeSelectedIndex) - Convert.ToDouble(standard.EcaData.FracToughTypeSelectedIndex));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.hilo) - Convert.ToDouble(standard.EcaData.hilo));
            sum = sum + Math.Abs(Convert.ToDouble(Convert.ToInt32(tmpStandard.EcaData.isKmatEnabled)) - Convert.ToDouble(Convert.ToInt32(standard.EcaData.isKmatEnabled)));
            sum = sum + Math.Abs(Convert.ToDouble(Convert.ToInt32(tmpStandard.EcaData.isLrmaxUserDefined)) - Convert.ToDouble(Convert.ToInt32(standard.EcaData.isLrmaxUserDefined)));
            sum = sum + Math.Abs(Convert.ToDouble(Convert.ToInt32(tmpStandard.EcaData.isLuderEndStrainEnabled)) - Convert.ToDouble(Convert.ToInt32(standard.EcaData.isLuderEndStrainEnabled)));
            sum = sum + Math.Abs(Convert.ToDouble(Convert.ToInt32(tmpStandard.EcaData.isLuderPlateauChecked)) - Convert.ToDouble(Convert.ToInt32(standard.EcaData.isLuderPlateauChecked)));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.Kmat) - Convert.ToDouble(standard.EcaData.Kmat));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.Lrmax) - Convert.ToDouble(standard.EcaData.Lrmax));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.LuderEndStrain) - Convert.ToDouble(standard.EcaData.LuderEndStrain));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.LuderStrainSelectionIndex) - Convert.ToDouble(standard.EcaData.LuderStrainSelectionIndex));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.Pb) - Convert.ToDouble(standard.EcaData.Pb));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.Pm) - Convert.ToDouble(standard.EcaData.Pm));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.Qb) - Convert.ToDouble(standard.EcaData.Qb));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.Qm) - Convert.ToDouble(standard.EcaData.Qm));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.RootLength) - Convert.ToDouble(standard.EcaData.RootLength));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.UTS) - Convert.ToDouble(standard.EcaData.UTS));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.StressStrainCurveSelectedIndex) - Convert.ToDouble(standard.EcaData.StressStrainCurveSelectedIndex));
            sum = sum + Math.Abs(Convert.ToDouble(tmpStandard.EcaData.LoadingEntrySelectionIndex) - Convert.ToDouble(standard.EcaData.LoadingEntrySelectionIndex));

            //if (App.Module1_ViewModel.DisplaySettings.EcaData.IsCyclicTblStrctChanged)
            //{
            //    sum = sum + 1;
            //}

            //if (App.Module1_ViewModel.DisplaySettings.EcaData.isStressStrainAltered)
            //{
            //    sum = sum + 1;
            //}

            // CHECKING IF FATIGUE ENTRIES ARE ALTERED
            // =======================================
            double sumECA = sum - sumFat - sumBasic;
            if (sumECA > toler)
            {
                DisplaySettings.isECAEntryAltered = true;
            }

            // Checking if any data has been changed. 
            // ===========================================
            if (sum > toler)
            {
                isEqual = false;
            }

            return isEqual;
        }
       
        
        #endregion                     




        #endregion 


        #region Commands


        
        #endregion 
    }
}
