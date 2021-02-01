using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace River_X.Models.InterfaceDLL
{
    public static class IntermediateCalcs
    {

        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "mainIntermediateCalcs", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mainIntermediateCalcs(ref double Dsteel, ref double tsteel, ref double tcoat, ref double tconc, ref double Epipe, ref double rhoSteel, ref double rhoCoat, ref double rhoConc, ref double nuSteel, ref double alfaTemp, ref double surfRough,
                                    ref int soilType, ref int sandClass, ref int soilStiffModel, ref double gamaSoil, ref double nuSoil, ref double CuSoil, ref double eSoil, ref double IpSoil, ref double OCR, ref double muLat, ref double phiFric, ref double fPhi, ref double fcSoil, ref double CVer, ref double CLat,
                                    ref double rhoCont, ref double rhoWater, ref double g, ref double Tin, ref double Tout, ref double Pin, ref double Pa, ref double nuWater, ref double Tres,
                                    ref double qFlow, ref double Islope, ref int FlowModelOption, ref double FricCoeff, ref double safety_SC,
                                    ref double eonD, ref double ZuonD, ref double HeonD, ref double DelonD, ref double pipeAngle,
                                    ref double ODtotal, ref double Di, ref double Apipe, ref double Ipipe, ref double Iconc, ref double kBend, ref double kAx, ref double mSteel, ref double mCoat, ref double mConc, ref double mCont, ref double mTot, ref double mWater, ref double submergeWeight, ref double SG, ref double madded, ref double meff,
                                    ref double staticKV, ref double staticKL, ref double dynKV, ref double dynKL, ref double Rp, ref double Rf, ref double RH, ref double Rv, ref double muAx, ref double Ra,
                                    ref double Te, ref double qL, ref double qV, ref double thLoad, ref double qtot,
                                    ref double Uav_Flow, ref double Ustar, ref double Utop, ref double Uc, ref double hFlow, ref double z0, ref double Manning, ref double Chezy, ref double CDrag, ref double CLift, ref double FD, ref double FL,
                                    ref double Hcover, ref double Hbar, ref double egap, ref double dtrench);





        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "diameterCalc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void diameterCalc(ref double Dsteel, ref double tsteel, ref double tcoat, ref double tconc, ref double ODtotal, ref double Di, ref double Apipe, ref double Ipipe, ref double Iconc);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "pipeStiffness", CallingConvention = CallingConvention.Cdecl)]
        public static extern void pipeStiffness(ref double Epipe, ref double Apipe, ref double Ipipe, ref double kBend, ref double kAx);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "massCalc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void massCalc(ref double Dsteel, ref double tsteel, ref double tcoat, ref double tconc, ref double rhoSteel, ref double rhoCoat, ref double rhoConc, ref double rhoCont,
            ref double rhoWater, ref double g, ref double mSteel, ref double mCoat, ref double mConc, ref double mCont, ref double mTot, ref double mWater, ref double submergeWeight, ref double SG);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "addedMass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void addedMass(ref double eonD, ref double rhoWater, ref double ODtotal, ref double ma);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "initAxialTension", CallingConvention = CallingConvention.Cdecl)]
        public static extern void initAxialTension(ref double Tin, ref double Tout, ref double Pin, ref double Dsteel, ref double tsteel, ref double Epipe,
            ref double nuPipe, ref double alfaTemp, ref double Tres, ref double Te);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "flowVelocities", CallingConvention = CallingConvention.Cdecl)]
        public static extern void flowVelocities(ref double q, ref double Islope, ref double Chezy, ref double g, ref double eonD, ref double ODtotal, ref double h,
            ref double z0, ref double Uav_Flow, ref double Ustar, ref double Utop, ref double Uc);

        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "velocityProfile", CallingConvention = CallingConvention.Cdecl)]
        public static extern void velocityProfile(ref double Ustar, ref double z, ref double z0, ref double Uz);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "hydroForces", CallingConvention = CallingConvention.Cdecl)]
        public static extern void hydroForces(ref double Uc, ref double nuWater, ref double ODtotal, ref double eonD, ref double surfRough,
            ref double rhoWater, ref double safety_SC, ref double FD, ref double FL);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "returnDragCoef", CallingConvention = CallingConvention.Cdecl)]
        public static extern void returnDragCoef(ref double CD, ref double CL);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "Chezy2Manning", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Chezy2Manning(ref double Chezy, ref double Islope, ref double q, ref double Manning);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "Manning2Chezy", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Manning2Chezy(ref double Manning, ref double Islope, ref double q, ref double Chezy);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "lateralSoilResist", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lateralSoilResist(ref double soilType, ref double gamaSoil, ref double CuSoil, ref double muLat, ref double ODtotal, ref double ZuonD, ref double eonD, ref double subW,
           ref double FL, ref double Rp, ref double Rf, ref double RH, ref double Rv);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "returnAxialMu", CallingConvention = CallingConvention.Cdecl)]
        public static extern void returnAxialMu(ref double phiFric, ref double fPhi, ref double muAx);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "axialSoilResistFromPRCI", CallingConvention = CallingConvention.Cdecl)]
        public static extern void axialSoilResistFromPRCI(ref double soilType, ref double phiFric, ref double muAx, ref double Hcover, ref double OD, ref double gamaSoil,
            ref double gamaPipe, ref double Cu, ref double fc, ref double Ra);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "setSoilStiffnessFromF105", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setSoilStiffnessFromF105(ref double SG, ref double OD, ref double CV, ref double CL, ref double nuSoil, ref double dynKV, ref double dynKL);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "returnSandModulusFromPRCI", CallingConvention = CallingConvention.Cdecl)]
        public static extern void returnSandModulusFromPRCI(ref int sandClass, ref double Hbar, ref double Pa, ref double gamaSoil, ref double eSoil, ref double Ei, ref double GG);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "returnClayModulusFromPRCI", CallingConvention = CallingConvention.Cdecl)]
        public static extern void returnClayModulusFromPRCI(ref double Hbar, ref double Pa, ref double gamaSoil, ref double eSoil, ref double Ip, ref double Cu, ref double OCR,
            ref double Ei, ref double GG);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "setSoilStiffnessFromPRCI", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setSoilStiffnessFromPRCI(ref double Ei, ref double GG, ref double OD, ref double nuSoil,
            ref double staticKV, ref double staticKL, ref double dynKV, ref double dynKL);


        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "returnLoadonPipe", CallingConvention = CallingConvention.Cdecl)]
        public static extern void returnLoadonPipe(ref double RH, ref double Rv, ref double FD, ref double qL, ref double qV, ref double qtotal);

    }
}
