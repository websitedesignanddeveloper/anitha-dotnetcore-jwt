using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAppJwt.ViewModels;
using WebAppJwt.Models;
using System.Data;

namespace WebAppJwt.ViewModels.Module1
{
    public class ValidateInputs
    {
        #region Constructor

        public ValidateInputs()
        {

        }

        #endregion

        #region Min-Max Ranges Dictionary

        static double tinyNumber = 0.000001;
        static double lowLargeVal = 9999;
        static double midLargeVal = 999999;
        static double highLargeVal = 9999999999;

        public Dictionary<string, double[]> paraMinMaxRange = new Dictionary<string, double[]>()
        {
            {EntryComponents.TxtBox.txtDs, new double[4] {75, 1500, 3, 59}},
            {EntryComponents.TxtBox.txtWT, new double[4] {0, 50, 0, 2}},
            {EntryComponents.TxtBox.txtTCoat, new double[4] {0, 200, 0, 8}},
            {EntryComponents.TxtBox.txtTConc, new double[4] {0, 1250, 0, 50}},
            {EntryComponents.TxtBox.txtSurfRough, new double[4] {0, 0.1, 0, 0.1 } },
            {EntryComponents.TxtBox.txtAmpCD, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtAmpCL, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtCrushYConc, new double[4] {0, highLargeVal, 0, highLargeVal}},
            {EntryComponents.TxtBox.txtBConc, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtHConc, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtX0Conc, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtRhoSteel, new double[4] { tinyNumber, 15000, tinyNumber, 1000}},
            {EntryComponents.TxtBox.txtRhoCoat, new double[4] { tinyNumber, 8000, tinyNumber, 500}},
            {EntryComponents.TxtBox.txtRhoConc, new double[4] { tinyNumber, 8000, tinyNumber, 500}},
            {EntryComponents.TxtBox.txtNu, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtE, new double[4] { tinyNumber, highLargeVal, tinyNumber, highLargeVal}},
            {EntryComponents.TxtBox.txtEConc, new double[4] { tinyNumber, highLargeVal, tinyNumber, highLargeVal}},
            {EntryComponents.TxtBox.txtAlfaT, new double[4] {0.000001, 0.001, 0.000001, 0.001}},
            {EntryComponents.TxtBox.txtSY, new double[4] {245, 675, 35500, 97900}},
            {EntryComponents.TxtBox.txtRhoWater, new double[4] { tinyNumber, 1250, tinyNumber, 50}},
            {EntryComponents.TxtBox.txtTout, new double[4] {-1500, 1500, -1500, 1500}},
            {EntryComponents.TxtBox.txtTin, new double[4] {-1500, 1500, -1500, 1500}},
            {EntryComponents.TxtBox.txtPout, new double[4] {-midLargeVal, midLargeVal, -midLargeVal, midLargeVal}},
            {EntryComponents.TxtBox.txtPin, new double[4] {-midLargeVal, midLargeVal, -midLargeVal, midLargeVal}},
            {EntryComponents.TxtBox.txtRhoCont, new double[4] { tinyNumber, 3000, tinyNumber, 200}},
            {EntryComponents.TxtBox.txtTres, new double[4] {-midLargeVal, midLargeVal, -midLargeVal, midLargeVal}},
            {EntryComponents.TxtBox.txtg, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtGamaSoil, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtMuL, new double[4] {0, 1, 0, 1 }},
            {EntryComponents.TxtBox.txtfphi, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtfc, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtFricAngle, new double[4] {0, 90, 0, 90}},
            {EntryComponents.TxtBox.txtCohesiveStrength, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtSoilNu, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtSoilVoidRatio, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtSoilPlasticityIndx, new double[4] {0, 100, 0, 100}},
            {EntryComponents.TxtBox.txtSoilOCR, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtSoilCL, new double[4] {0, 30000, 0, 131000}},
            {EntryComponents.TxtBox.txtSoilCV, new double[4] {0, 30000, 0, 131000}},
            {EntryComponents.TxtBox.txtEvents, new double[4] {2, 12, 2, 12}},
            {EntryComponents.TxtBox.txtqMin, new double[4] { tinyNumber, 100, tinyNumber, 1076}},
            {EntryComponents.TxtBox.txtqMax, new double[4] { tinyNumber, 100, tinyNumber, 1076}},
            {EntryComponents.TxtBox.txtFricCoeff, new double[4] { tinyNumber, lowLargeVal, tinyNumber, lowLargeVal}},
            {EntryComponents.TxtBox.txtIp, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtL_Min, new double[4] { tinyNumber, 150, tinyNumber, 492}},
            {EntryComponents.TxtBox.txtL_Max, new double[4] { tinyNumber, 150, tinyNumber, 492}},
            {EntryComponents.TxtBox.txteonD_Min, new double[4] {-1, 1, -1, 1}},
            {EntryComponents.TxtBox.txteonD_Max, new double[4] {-1, 1, -1, 1}},
            {EntryComponents.TxtBox.txtTheta_Min, new double[4] {0, 90, 0, 90}},
            {EntryComponents.TxtBox.txtTheta_Max, new double[4] {0, 90, 0, 90}},
            {EntryComponents.TxtBox.txtHeonD_Min, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtHeonD_Max, new double[4] {0, lowLargeVal, 0, lowLargeVal}},
            {EntryComponents.TxtBox.txtzonD_Min, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtzonD_Max, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtHeTrench_Min, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtHeTrench_Max, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtL_Num, new double[4] {1, 10, 1, 10}},
            {EntryComponents.TxtBox.txteonD_Num, new double[4] {1, 10, 1, 10}},
            {EntryComponents.TxtBox.txtThet_Num, new double[4] {1, 10, 1, 10}},
            {EntryComponents.TxtBox.txtHeonD_Num, new double[4] {1, 10, 1, 10}},
            {EntryComponents.TxtBox.txtzonD_Num, new double[4] {1, 10, 1, 10}},
            {EntryComponents.TxtBox.txtHeTrench_Num, new double[4] {1, 10, 1, 10}},
            {EntryComponents.TxtBox.txtGamaIL, new double[4] { tinyNumber, 10, tinyNumber, 10}},
            {EntryComponents.TxtBox.txtGamaCF, new double[4] { tinyNumber, 10, tinyNumber, 10}},
            {EntryComponents.TxtBox.txtGamaS, new double[4] { tinyNumber, 10, tinyNumber, 10}},
            {EntryComponents.TxtBox.txtGamaF_IL, new double[4] { tinyNumber, 10, tinyNumber, 10}},
            {EntryComponents.TxtBox.txtGamaF_CF, new double[4] { tinyNumber, 10, tinyNumber, 10}},
            {EntryComponents.TxtBox.txtGamaK, new double[4] { tinyNumber, 10, tinyNumber, 10}},
            {EntryComponents.TxtBox.txtGamaOnIL, new double[4] { tinyNumber, 10, tinyNumber, 10}},
            {EntryComponents.TxtBox.txtGamaOnCF, new double[4] { tinyNumber, 10, tinyNumber, 10}},
            {EntryComponents.TxtBox.txtZetaSoilL, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtZetaSoilV, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtZetaHydroL, new double[4] {0, 10, 0, 10}},
            {EntryComponents.TxtBox.txtZetaHydroV, new double[4] {0, 10, 0, 10}},
            {EntryComponents.TxtBox.txtZetaStrct, new double[4] {0, 10, 0, 10}},
            {EntryComponents.TxtBox.txtSCF, new double[4] {1, lowLargeVal, 1, lowLargeVal}},
            {EntryComponents.TxtBox.txtkc, new double[4] { tinyNumber, 10, tinyNumber, 10}},
            {EntryComponents.TxtBox.txtUsageFactor, new double[4] {0, 1, 0, 1}},
            {EntryComponents.TxtBox.txtIturb, new double[4] { tinyNumber, 1, tinyNumber, 1}},
            {EntryComponents.TxtBox.txtFreqRatio, new double[4] {1, 10, 1, 10}},
            {EntryComponents.TxtBox.txtExposedYear, new double[4] {tinyNumber, 100, tinyNumber, 100}},
            {EntryComponents.TxtBox.txtmSN, new double[4] {3, 4, 3, 4}},
            {EntryComponents.TxtBox.txtcSN, new double[4] {10, 15, 10, 15}},
            {EntryComponents.TxtBox.txtS0, new double[4] {tinyNumber, lowLargeVal, tinyNumber, lowLargeVal}},
            {EntryComponents.TxtBox.txtEpsY, new double[4] {tinyNumber, 0.01, tinyNumber, 0.01}},
            {EntryComponents.TxtBox.txtUTS, new double[4] {200, 850, 29000, 123282}},
            {EntryComponents.TxtBox.txtEpsUTS, new double[4] { tinyNumber, 0.2, tinyNumber, 0.01}},
            {EntryComponents.TxtBox.txtKmat, new double[4] {tinyNumber, lowLargeVal, tinyNumber, midLargeVal}},
            {EntryComponents.TxtBox.txtCVN, new double[4] {tinyNumber, lowLargeVal, tinyNumber, lowLargeVal}},
            {EntryComponents.TxtBox.txtEpsLuder, new double[4] {0.01, 0.04, 0.01, 0.04}},
            {EntryComponents.TxtBox.txtLrMax, new double[4] {1, 1.5, 1, 1.5}},
            //{EntryComponents.TxtBox.txtCrackHeight, new double[4] {tinyNumber, 0.85 * Convert.ToDouble(App.Module1_ViewModel.DisplaySettings.PipeData.WT), tinyNumber, 0.85 * Convert.ToDouble(App.Module1_ViewModel.DisplaySettings.PipeData.WT)}},
            //{EntryComponents.TxtBox.txtCrackLength, new double[4] { tinyNumber, 2.0 * Math.PI * Convert.ToDouble(App.Module1_ViewModel.DisplaySettings.PipeData.Ds), tinyNumber, 2.0 * Math.PI * Convert.ToDouble(App.Module1_ViewModel.DisplaySettings.PipeData.Ds)}},
            {EntryComponents.TxtBox.txtCrackLigament, new double[4] {tinyNumber, 3, tinyNumber, 3}},
            {EntryComponents.TxtBox.txtCapLength, new double[4] {5, 30, 0.2, 1.2 } },
            {EntryComponents.TxtBox.txtRootLength, new double[4] {1, 15, 0.04, 0.6}},
            {EntryComponents.TxtBox.txthilo, new double[4] {0.5, 1.5, 0.5, 1.5}},
            {EntryComponents.TxtBox.txtPm, new double[4] {0.0, lowLargeVal, 0.0, lowLargeVal}},
            {EntryComponents.TxtBox.txtPb, new double[4] {0.0, lowLargeVal, 0.0, lowLargeVal}},
            {EntryComponents.TxtBox.txtQm, new double[4] {0.0, lowLargeVal, 0.0, lowLargeVal}},
            {EntryComponents.TxtBox.txtQb, new double[4] {0.0, lowLargeVal, 0.0, lowLargeVal}}
        };

        public Dictionary<string, string> errMessageList = new Dictionary<string, string>()
        {
            {EntryComponents.TxtBox.txtDs, "Diameter of steel is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtWT, "Wall-thickness is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtTCoat, "Coating-thickness is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtTConc, "Concrete-thickness is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtSurfRough, "Surface roughness is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtAmpCD, "Drag amplification factor is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtAmpCL, "Lift amplification factor is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtCrushYConc,""},
            {EntryComponents.TxtBox.txtBConc, ""},
            {EntryComponents.TxtBox.txtHConc, ""},
            {EntryComponents.TxtBox.txtX0Conc, ""},
            {EntryComponents.TxtBox.txtRhoSteel, "Steel density is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtRhoCoat, "Coating density is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtRhoConc, "Concrete density is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtNu, "Poisson ratio is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtE, "Modulus of elasticity is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtEConc,"Concrete elasticity is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtAlfaT, "Coefficient of thermal expansion is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtSY, "Yield stress is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtRhoWater, "Water density is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtTout, "Outer (ambient) temperature is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtTin, "Inner (content) temperature is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtPout, "Outer (ambient) pressure is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtPin, "Inner (content) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtRhoCont, "Content density is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtTres, "Residual axial force is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtg, "Gravity acceleration is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtGamaSoil, "Submerge weight of soil is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtMuL, "Lateral friction coefficient of soil is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtfphi, "Axial skin friction coefficient (fᵩ) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtfc, "Axial skin friction coefficient (fc) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtFricAngle, "Angle of friction is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtCohesiveStrength, "Cohesive strength is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtSoilNu, "Poisson ratio of soil is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtSoilVoidRatio, "Void ratio of soil is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtSoilPlasticityIndx, "Plasticity index of soil is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtSoilOCR, "Overconsolidation ratio (OCR) of soil is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtSoilCL, "Lateral constant for dynamic soil stiffness is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtSoilCV, "Vertical constant for dynamic soil stiffness is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtEvents, "Number of events is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtqMin, "Lower bound for discharge value is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtqMax, "Upper bound for discharge value is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtFricCoeff, "Chezy/Manning coefficient is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtIp, "Gradient of riverbed is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtL_Min, "Lower bound of exposed length is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtL_Max, "Higher bound of exposed length is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txteonD_Min, "Lower bound of gap-ratio is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txteonD_Max, "Higher bound of gap-ratio is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtTheta_Min, "Pipe direction is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtTheta_Max, "Diameter of steel is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtHeonD_Min, "Cover height ratio of soil in embankment (He/D) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtHeonD_Max, "Diameter of steel is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtzonD_Min, "Soil height ratio in front of pipe is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtzonD_Max, "Diameter of steel is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtHeTrench_Min, "Height ratio of trench is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtHeTrench_Max, "Diameter of steel is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtL_Num, "Number of exposed lengths is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txteonD_Num, "Number of gap-ratios is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtThet_Num, "Diameter of steel is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtHeonD_Num, "Diameter of steel is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtzonD_Num, "Diameter of steel is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtHeTrench_Num, "Diameter of steel is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtGamaIL, "Safety factor (γ) in In-Line direction is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtGamaCF, "Safety factor (γ) in Cross-Flow direction is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtGamaS, "Safety factor on stress amplitude (γs) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtGamaF_IL, "Safety factor on natural frequency (γf) (In-Line) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtGamaF_CF, "Safety factor on natural frequency (γf) (Cross-Flow) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtGamaK, "Safety factor on stability parameter (γk) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtGamaOnIL, "Safety factor on onset value for in-line VR (γOn,IL) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtGamaOnCF, "Safety factor on onset value for cross-flow VR (γOn,CF) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtZetaSoilL, "Lateral soil damping coefficient is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtZetaSoilV, "Vertical soil damping coefficient is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtZetaHydroL, "Lateral hydrodynamic damping coefficient is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtZetaHydroV, "Vertical hydrodynamic damping coefficient is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtZetaStrct, "Structural damping coefficient is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtSCF, "Stress concentration factor is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtkc, "Slippage factor (kc) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtUsageFactor, "Usage factor is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtIturb, "Turbulence intensity factor is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtFreqRatio, "Frequency ratio is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtExposedYear, "Exposed duration is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtmSN, "Exponent of S-N curve is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtcSN, "Coefficient (Log10C) of S-N curve is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtS0, "Cut-off stress range is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtEpsY, "Yield strain is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtUTS, "Ultimate stress is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtEpsUTS, "Ultimate strain is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtKmat, "Material fracture toughness (Kmat) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtCVN, "Charpy value (CVN) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtEpsLuder, "Luder end strain is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtLrMax, "Lrmax value is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtCrackHeight, "Crack height is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtCrackLength, "Crack length is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtCrackLigament, "Crack ligament is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtCapLength, "Weld cap length is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtRootLength, "Weld root length is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txthilo, "Weld Hi/Lo is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtPm, "Primary membrane stress (Pm) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtPb, "Primary bending stress (Pb) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtQm, "Secondary membrane stress (Qm) is out of range!\n\n Previous value is substituted."},
            {EntryComponents.TxtBox.txtQb, "Secondary bending stress (Qb) is out of range!\n\n Previous value is substituted."}
        };


        #endregion


        #region Methods

        public void SetQuickHelpText(string inputLabel)
        {
           
            switch (inputLabel)
            {
                #region FLOWLINE DIMENSION ENTRIES

                case "txtDs":
                  
                    break;

                case "txtWT":
                  
                    break;

                case "txtTCoat":
                  
                    break;

                case "txtTConc":
                   
                    break;

                case "txtSurfRough":
                 
                    break;

                case "txtAmpCD":
                  
                    break;

                case "txtAmpCL":
                  
                    break;

                case "txtRhoSteel":
                  
                    break;

                case "txtRhoCoat":
                 
                    break;

                case "txtRhoConc":
                   
                    break;

                case "txtNu":
                   
                    break;

                case "txtE":
                   
                    break;

                case "txtEConc":
                  
                    break;

                case "txtAlfaT":
                   
                    break;

                case "txtSY":
                  
                    break;

                case "txtRhoWater":
                   
                    break;

                case "txtTout":
                   
                    break;

                case "txtTin":
                    
                    break;

                case "txtPout":
                    
                    break;

                case "txtPin":
                   
                    break;

                case "txtRhoCont":
                  
                    break;

                case "txtTres":
                   
                    break;

         


                #endregion


                #region FATIGUE-ENTRIES

                case "txtGamaIL":
                 
                    break;

                case "txtGamaCF":
                   
                    break;

                case "txtGamaS":
                
                    break;

              

                #endregion


                #region ECA

              
              

                    #endregion

            }
        }


        public bool entryHasError(string inputLabel, string inputValStr, ref string errMessage) //, ref string recoverVal)
        {
            bool hasError = false;
            double inpVal = Convert.ToDouble(inputValStr);

            int minIdx = 0;
            int maxIdx = 1;

            double minVal = 0;
            double maxVal = 0;

            return hasError;
        }


        public bool isOkToSaveCase(ref string errMessage)
        {
            /********************************************************************
             * 
             * NOTE: Here it is assumed that no single entry error exists. Checking
             * single entries is responsiblity of entryHasError. This method should
             * make sure that users cannot input errorneous values.
             * 
             ********************************************************************/

            bool isOk = true;

            return isOk;              
        }

        private bool minMaxHasError(string minStr, string maxStr)
        {
            double minVal = Convert.ToDouble(minStr);
            double maxVal = Convert.ToDouble(maxStr);

            if (maxVal < minVal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isStressStrainLoaded()
        {
          
            DataTable dt = new DataTable();
            string[] selections = new string[] { "*" };

          
          
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        #endregion
    }
}
