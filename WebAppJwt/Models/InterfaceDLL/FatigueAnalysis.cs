using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace River_X.Models.InterfaceDLL
{
    public static class FatigueAnalysis
    {


        //[DllImport("River_X_DLL.dll", EntryPoint = "mainFatigue", CallingConvention = CallingConvention.Cdecl)]
        [DllImport("River_X_DLL.dll", EntryPoint = "mainFatigue", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mainFatigue(ref double me, ref double Lspan, ref double dynKL, ref double dynKV, ref double ymaxL, ref double ymaxV, ref double Teff, ref double kc, ref double Econc,
             ref double Iconc, ref double KBendPipe, ref double Uc, ref double thetaSpan, ref double eonD, ref double dtrench, ref double Iturb, ref double ODtotal, ref double Dsteel, ref double tSteel,
              ref double Epipe, ref double SCF, ref double C_SN, ref double m_SN, ref double zetaSoil_L, ref double zetaHydroL, ref double zetaSoil_V, ref double zetaHydroV, ref double zetaStrct, ref double rhoWater,
               ref double gamaFIL, ref double gamaFCF, ref double gamaOnIL, ref double gamaOnCF, ref double gamaS, ref double gamaK, ref double freqRatio, ref double CSF, ref double LeffIL, ref double f0IL, ref double VR_IL, ref double KsdIL,
               ref double VRonsetIL, ref double AYonD, ref double AmpIL, ref double S_IL, ref double Ncyc_IL, ref double FatLife_IL, ref double LeffCF, ref double f0CF, ref double VR_CF,
               ref double VRonsetCF, ref double AZonD, ref double AmpCF, ref double S_CF, ref double Ncyc_CF, ref double FatLife_CF, ref int isCalcOk);        


        [DllImport("River_X_DLL.dll", EntryPoint = "C4andC5", CallingConvention = CallingConvention.Cdecl)]
        public static extern void C4andC5(ref double Lspan, ref double Leff, ref double C4, ref double C5);


        [DllImport("River_X_DLL.dll", EntryPoint = "concreteStiffeningFactor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void concreteStiffeningFactor(ref double kc, ref double Ec, ref double Ic, ref double KBendPipe, ref double CSF);


        [DllImport("River_X_DLL.dll", EntryPoint = "betaCoeff", CallingConvention = CallingConvention.Cdecl)]
        public static extern void betaCoeff(ref double dynK, ref double Lspan, ref double CSF, ref double KBendPipe, ref double beta);


        [DllImport("River_X_DLL.dll", EntryPoint = "Leffective", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Leffective(ref double Lspan, ref double beta, ref double L);


        [DllImport("River_X_DLL.dll", EntryPoint = "eulerLoad", CallingConvention = CallingConvention.Cdecl)]
        public static extern void eulerLoad(ref double CSF, ref double Leff, ref double KBendPipe, ref double PE);


        [DllImport("River_X_DLL.dll", EntryPoint = "dampingEffect", CallingConvention = CallingConvention.Cdecl)]
        public static extern void dampingEffect(ref double me, ref double dampTot, ref double rhoWater, ref double ODtotal, ref double gamaK, ref double Ks, ref double Ksd, ref double Rk);


        [DllImport("River_X_DLL.dll", EntryPoint = "deflecF105", CallingConvention = CallingConvention.Cdecl)]
        public static extern void deflecF105(ref double q, ref double Leff, ref double CSF, ref double KBendPipe, ref double PE, ref double Teff, ref double ymax);


        [DllImport("River_X_DLL.dll", EntryPoint = "naturalFreq", CallingConvention = CallingConvention.Cdecl)]
        public static extern void naturalFreq(ref double me, ref double Leff, ref double CSF, ref double KBendPipe, ref double Teff, ref double ymax, ref double ODtotal, ref double PE, ref double f0);


        [DllImport("River_X_DLL.dll", EntryPoint = "reducedVelocity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void reducedVelocity(ref double gamaf, ref double Uc, ref double ODtotal, ref double fn, ref double VR);


        [DllImport("River_X_DLL.dll", EntryPoint = "onsetVeloIL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void onsetVeloIL(ref double gamaIL, ref double gamaf, ref double Ksd, ref double VonsetIL, ref double VRonsetIL);


        [DllImport("River_X_DLL.dll", EntryPoint = "constructInLineResponse", CallingConvention = CallingConvention.Cdecl)]
        public static extern void constructInLineResponse(ref double Ksd, ref double VRonsetIL, ref double thetaRel, ref double Iturb, [Out] double[] veloArr, [Out] double[] amplArr);

        [DllImport("River_X_DLL.dll", EntryPoint = "psiAlfaCurrIL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void psiAlfaCurrIL(ref double alfaC, ref double psiAlfaC);


        [DllImport("River_X_DLL.dll", EntryPoint = "psiProximity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void psiProximity(ref double Lspan, ref double Leff, ref double C4, ref double C5);


        [DllImport("River_X_DLL.dll", EntryPoint = "psiMass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void psiMass(ref double SG, ref double psiM);


        [DllImport("River_X_DLL.dll", EntryPoint = "psiAlfaCurrCF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void psiAlfaCurrCF(ref double alfaC, ref double psiAlfaC);


        [DllImport("River_X_DLL.dll", EntryPoint = "psiTrench", CallingConvention = CallingConvention.Cdecl)]
        public static extern void psiTrench(ref double dtrench, ref double egap, ref double ODtotal, ref double psiTren);


        [DllImport("River_X_DLL.dll", EntryPoint = "onsetVeloCF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void onsetVeloCF(ref double gamaCF, ref double gamaf, ref double psiProx, ref double psiTren, ref double VonsetCF, ref double VRonsetCF);


        [DllImport("River_X_DLL.dll", EntryPoint = "constructCrossFlowResponse", CallingConvention = CallingConvention.Cdecl)]
        public static extern void constructCrossFlowResponse(ref double freqRatio, ref double VRonsetCF, [Out] double[] veloArr, [Out] double[] amplArr);


        [DllImport("River_X_DLL.dll", EntryPoint = "unitStressAmp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void unitStressAmp(ref double Leff, ref double Lspan, ref double CSF, ref double ODtotal, ref double Dsteel, ref double tSteel, ref double Epipe, ref double Amp);


        [DllImport("River_X_DLL.dll", EntryPoint = "vivStressRange", CallingConvention = CallingConvention.Cdecl)]
        public static extern void vivStressRange(ref double SCF, ref double AmpStress, ref double AmpResp, ref double Coef, ref double gamaS, ref double stressRange);


        [DllImport("River_X_DLL.dll", EntryPoint = "returnCyclesToFailure", CallingConvention = CallingConvention.Cdecl)]
        public static extern void returnCyclesToFailure(ref double log10C, ref double m, ref double S, ref double N);


        [DllImport("River_X_DLL.dll", EntryPoint = "returnFatLife", CallingConvention = CallingConvention.Cdecl)]
        public static extern void returnFatLife(ref double f0, ref double Ncycle, ref double FatLife);        

    }
}
