using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace River_X.Models.InterfaceDLL
{
    public static class StaticAnalysis
    {
        
        [DllImport("River_X_DLL.dll", EntryPoint = "analyticalStaticAnalysis", CallingConvention = CallingConvention.Cdecl)]
        public static extern void analyticalStaticAnalysis(ref double q, ref double staticK, ref double Te, ref double Epipe, ref double Ipipe, 
            ref double Apipe, ref double Lspan, ref double Lshoulder, ref double muAx, ref double Ra, ref int intOption,
    ref double a, ref double b, ref double Tnl, ref double Teff, ref double ymax, ref double yb, ref double Mm, ref double Mb, ref int isCalcOK);

        [DllImport("River_X_DLL.dll", EntryPoint = "mainStaticAnalysis", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mainStaticAnalysis(ref double q, ref double staticK, ref double Te, ref double Epipe, ref double Ipipe,
            ref double Apipe, ref double Lspan, ref double Lshoulder, ref double muAx, ref double Ra, ref int intOption,
    ref double a, ref double b, ref double Tnl, ref double Teff, ref double ymax, ref double yb, ref double Mm, ref double Mb, ref int isCalcOK);


        [DllImport("River_X_DLL.dll", EntryPoint = "writeAnalyticalEmbk", CallingConvention = CallingConvention.Cdecl)]
        public static extern void writeAnalyticalEmbk(ref double a, ref double b, ref double staticK, ref double q, ref double Lspan, 
            ref double Lshoulder, ref double Mb, ref double Epipe, ref double Ipipe, ref double Teff, ref int nPoint, [Out] double[] x, [Out] double[] yx, [Out] double[] tx);


        [DllImport("River_X_DLL.dll", EntryPoint = "writeAnalyticalExpose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void writeAnalyticalExpose(ref double staticK, ref double q, ref double Lspan, ref double yb, ref double Mb, 
            ref double Epipe, ref double Ipipe, ref double Teff, ref int nPoint, [Out] double[] x, [Out] double[] yx, [Out] double[] tx, [Out] double[] Mx, [Out] double[] Qx);


        [DllImport("River_X_DLL.dll", EntryPoint = "returnStresses", CallingConvention = CallingConvention.Cdecl)]
        public static extern void returnStresses(ref double Teff, ref double Mb, ref double Qv, ref double Apipe, ref double Ipipe,
            ref double Pi, ref double Po, ref double Din, ref double DSteel, ref double Sb, ref double St, ref double Sx, ref double Sy, ref double Txy, ref double Svon);


        [DllImport("River_X_DLL.dll", EntryPoint = "vonMisesStress2D", CallingConvention = CallingConvention.Cdecl)]
        public static extern void vonMisesStress2D(ref double St, ref double Sb, ref double Sy, ref double Txy, ref double Svm);


        [DllImport("River_X_DLL.dll", EntryPoint = "principalStress2D", CallingConvention = CallingConvention.Cdecl)]
        public static extern void principalStress2D(ref double Sx, ref double Sy, ref double Txy, ref double S1, ref double S2, ref double Theta);    


    }
}
