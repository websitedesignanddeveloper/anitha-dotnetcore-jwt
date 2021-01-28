using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Data;

using River_X.Models;

namespace River_X.Models.InterfaceDLL
{
    public static class ECAAnalysis
    {

        /************************************************************************************************************
         * 
         * MAIN ECA ENTRY FUNCTION - PERFORMS THE WHOLE CALCULATION
         * 
         ************************************************************************************************************/

        //[DllImport(App.dllNameECA, EntryPoint = "MainEntry", CallingConvention = CallingConvention.Cdecl)]
        [DllImport("ECA_DLL.dll", EntryPoint = "MainEntry", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MainEntry([In] int[] InpIntVec, [In] double[] InpDoubleVec, ref int Inp_size_sigma_eps_curve, [In, Out] double[] Inp_sigma_Vec, [In, Out] double[] Inp_eps_Vec, ref int Inp_size_cyclic_sigma,
            [In] double[,] Inp_cyclic_sigma, [Out] double[] Lr_vec_Out, [Out] double[] Kr_vec_Out, [Out] double[] Lr_FCG_vec_Out, [Out] double[] Kr_FCG_vec_Out, ref int isCalcOk, ref int isCrackPassed,
            ref int numLinesFAD, ref int numLinesFCG, [In, Out] double[,] tableFCG, [In, Out]char[] Message);

        /************************************************************************************************************
         * 
         * INTERMEDIATE CALC FUNCTIONS
         * 
         ************************************************************************************************************/

        [DllImport("ECA_DLL.dll", EntryPoint = "Kmat_Calc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kmat_Calc(ref double CVN, ref double B, ref double Kmat);


        [DllImport("ECA_DLL.dll", EntryPoint = "Lrmax_calc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Lrmax_calc(ref double UTS, ref double YS, ref double Lrmax);


        [DllImport("ECA_DLL.dll", EntryPoint = "strainLuder", CallingConvention = CallingConvention.Cdecl)]
        public static extern void strainLuder(ref double YS, ref double eps_Luder_end, ref int isCalcOk, [In, Out]char[] Message);


        [DllImport("ECA_DLL.dll", EntryPoint = "getStrainVector", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getStrainVector(ref double E, ref double YS, ref double UTS, ref double eps_YS, ref double eps_UTS, ref double eps_Luder_end, ref int yieldDiscountuity, ref int Luder_plateau, 
                                                ref int eps_Luder_end_flag, ref int N_vec, [In, Out] double[] sigma_vec, [In, Out] double[] eps_vec);

        [DllImport("ECA_DLL.dll", EntryPoint = "ConstructStressStrainCurve", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ConstructStressStrainCurve(ref double E, ref double YS, ref double UTS, ref double eps_YS, ref double eps_UTS, ref double eps_Luder_end, ref int yieldDiscountuity,
                                                                ref int Luder_plateau, ref int eps_Luder_end_flag, ref int size_sigma_eps_curve, [In, Out] double[] sigma_vec, [In, Out] double[] eps_vec);


        [DllImport("ECA_DLL.dll", EntryPoint = "Kr_Luder_Calc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kr_Luder_Calc(ref double E, ref double YS, ref double eps_Luder_end, ref double Kr_Luder);


        [DllImport("ECA_DLL.dll", EntryPoint = "Kr_calc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Kr_calc(ref double Kl_P, ref double Kl_S, ref double Kmat, ref double Crack_height, ref double YS, ref double Lr, ref double Kr);


        [DllImport("ECA_DLL.dll", EntryPoint = "Lr_calc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Lr_calc(ref double sigma_ref, ref double YS, ref double Lr);


        /************************************************************************************************************
         * 
         * MAIN CALC FUNCTIONS
         * 
         ************************************************************************************************************/


        [DllImport("ECA_DLL.dll", EntryPoint = "failureAssessDiag", CallingConvention = CallingConvention.Cdecl)]
        public static extern void failureAssessDiag(ref int yieldDiscountuity, ref int FAD_option, ref double dlt_Lr, ref double E, ref double YS, ref double UTS, ref double eps_Luder_end, ref double Lrmax,
                                                    ref int N_sigma_vec, ref double sigma_Vec, ref double eps_vec, ref double Lr_vec, ref double fLr_vec, ref int isCalcOk, [In, Out] char[] Message);


        [DllImport("ECA_DLL.dll", EntryPoint = "SIF_externalSurfaceBreaking", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SIF_externalSurfaceBreaking(ref double Pm, ref double Pb, ref double Qm, ref double Qb, ref double wt, ref double OD, ref double Kmat, ref double Crack_height, ref double Crack_length,
                                                              ref double L_cap, ref double Kl, ref double Kl_p, ref double Kl_s, ref double Kl_a, ref double Kl_Pa, ref double Kl_sa, ref double Kl_c, ref double Kl_pc,
                                                              ref double Kl_sc, ref int isCalcOk, [In, Out] char[] Message);


        [DllImport("ECA_DLL.dll", EntryPoint = "SIF_internalSurfaceBreaking", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SIF_internalSurfaceBreaking(ref double Pm, ref double Pb, ref double Qm, ref double Qb, ref double wt, ref double OD, ref double Kmat, ref double Crack_height, ref double Crack_length,
                                                            ref double L_root, ref double Kl, ref double Kl_p, ref double Kl_s, ref double Kl_a, ref double Kl_Pa, ref double Kl_sa, ref double Kl_c, ref double Kl_pc,
                                                            ref double Kl_sc, ref int isCalcOk, [In, Out] char[] Message);


        [DllImport("ECA_DLL.dll", EntryPoint = "SIF_Embedded", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SIF_Embedded(ref double Pm, ref double Pb, ref double Qm, ref double Qb, ref double wt, ref double OD, ref double Kmat, ref double Crack_height, ref double Crack_length, 
                                            ref double Ligament, ref double Kl, ref double Kl_p, ref double Kl_s, ref double Kl_a, ref double Kl_Pa, ref double Kl_sa, ref double Kl_c, ref double Kl_pc, 
                                            ref double Kl_sc, ref int isCalcOk, [In, Out] char[] Message);


        [DllImport("ECA_DLL.dll", EntryPoint = "sigma_ref_surfaceBreaking", CallingConvention = CallingConvention.Cdecl)]
        public static extern void sigma_ref_surfaceBreaking(ref double Pm, ref double Pb, ref double wt, ref double OD, ref double Crack_height, ref double Crack_length, ref double sigma_ref, 
                                                        ref int isCalcOk, [In, Out] char[] Message);


        [DllImport("ECA_DLL.dll", EntryPoint = "sigma_ref_embedded", CallingConvention = CallingConvention.Cdecl)]
        public static extern void sigma_ref_embedded(ref double Pm, ref double Pb, ref double wt, ref double OD, ref double Crack_height, ref double Crack_length, ref double Ligament, ref double sigma_ref,
                                                        ref int isCalcOk, [In, Out] char[] Message);


        [DllImport("ECA_DLL.dll", EntryPoint = "check_Lr_Kr", CallingConvention = CallingConvention.Cdecl)]
        public static extern void check_Lr_Kr(ref int nVec, ref double Lr_vec, ref double Kr_vec, ref double Lr, ref double Kr, ref double Lrmax, [In, Out] char[] Check, ref int isCalcOk, [In, Out] char[] Message);


        public static double NominalStressToMembraneStress(double SCF, double Snom)
        {
            double Smemb = 0;

            Smemb = Snom;

            return Smemb;
        }

        public static double NominalStressToBendingStress(double SCF, double Snom)
        {
            double Sbend = 0;

            Sbend = Snom * (SCF - 1);

            return Sbend;
        }

    }
}
