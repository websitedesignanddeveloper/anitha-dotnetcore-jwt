using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace River_X.Models.InterfaceDLL
{
    public static class ImpactAnalysis
    {
        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "impactPipeOnRiverBed", CallingConvention = CallingConvention.Cdecl)]
        public static extern void impactPipeOnRiverBed(ref double yieldStress, ref double WT, ref double Ds, ref double Uc, ref double impMassSteel, ref double PmaxSteel,
            ref double PmaxConc, ref double StrainEnergy);

        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "impactPipeOnRiverBedFromF107", CallingConvention = CallingConvention.Cdecl)]
        public static extern void impactPipeOnRiverBedFromF107(ref double yieldStress, ref double WT, ref double Ds, ref double Uc, ref double Y, ref double b, ref double h, ref double D, ref double x0, ref int ConcreteType, 
            ref double impMassSteel, ref double PmaxSteel, ref double impMassConc, ref double UE_Steel, ref double UE_Conc);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "analyticalStaticAnalysis_qPLoad", CallingConvention = CallingConvention.Cdecl)]
        public static extern void analyticalStaticAnalysis_qPLoad(ref double q, ref double P, ref double staticK, ref double Te, ref double Epipe, ref double Ipipe,
            ref double Apipe, ref double Lspan, ref double Lshoulder, ref double muAx, ref double Ra, ref int intOption,
    ref double a, ref double b, ref double Tnl, ref double Teff, ref double ymax, ref double yb, ref double Mm, ref double Mb, ref double ymaxP, ref double MbP, ref double MmP, ref double ybP,
     ref double ymaxq, ref double ybq, ref double Mmq, ref double Mbq, ref int isCalcOK);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "writeAnalyticalEmbk_qPLoad", CallingConvention = CallingConvention.Cdecl)]
        public static extern void writeAnalyticalEmbk_qPLoad(ref double a, ref double b, ref double staticK, ref double P, ref double MbP, ref double q, ref double Mbq, ref double Lspan,
            ref double Lshoulder, ref double Epipe, ref double Ipipe, ref double Teff, ref double nPoint, [Out] double[] x, [Out] double[] yx, [Out] double[] tx,
            [Out] double[] yxP, [Out] double[] txP, [Out] double[] yxq, [Out] double[] txq);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "writeAnalyticalExpose_qPLoad", CallingConvention = CallingConvention.Cdecl)]
        public static extern void writeAnalyticalExpose_qPLoad(ref double staticK, ref double P, ref double MbP, ref double q, ref double Mbq, ref double Lspan, ref double ybtot,
            ref double Epipe, ref double Ipipe, ref double Teff, ref double nPoint, [Out] double[] x, [Out] double[] yx, [Out] double[] tx, [Out] double[] Mx, [Out] double[] Qx,
            [Out] double[] yxP, [Out] double[] txP, [Out] double[] MxP, [Out] double[] QxP, [Out] double[] yxq, [Out] double[] txq, [Out] double[] Mxq, [Out] double[] Qxq);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "maxImpactScheme1", CallingConvention = CallingConvention.Cdecl)]
        public static extern void maxImpactScheme1(ref double Lspan, ref double Teff, ref double staticK, ref double Mbq, ref double Mmq, ref double Epipe, ref double Ipipe, ref double Apipe,
             ref double Dsteel, ref double SigmaP, ref double Uc, ref double Sy, ref double maxUE, ref double maxMass, ref double Pmax, ref double maxDelta);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "PmaxEstimateFromSxx", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PmaxEstimateFromSxx(ref double Lspan, ref double Teff, ref double staticK, ref double Mbq, ref double Mmq, ref double Epipe, ref double Ipipe,
            ref double Apipe, ref double Dsteel, ref double SigmaP, ref double Sy, ref double Pmax);

        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "PmaxEstimateFromSvon", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PmaxEstimateFromSvon(ref double Lspan, ref double Teff, ref double staticK, ref double Mbq, ref double Mmq, ref double Epipe, ref double Ipipe,
            ref double Apipe, ref double Dsteel, ref double SigmaP, ref double Sy, ref double Pmax);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "MaxImpactFromStrainEnergy", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MaxImpactFromStrainEnergy([In,Out] double[] yVec, [In,Out] double[] pVec, ref int nVec, ref double UFlow, ref double UE, ref double maxMass);

    }
}
