﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WebAppJwt.Models.InterfaceDLL
{
    public static class MathFuncs
    {
        [DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "trapz", CallingConvention = CallingConvention.Cdecl)]
        public static extern void trapz([In,Out] double[] xVec, [In,Out] double[] yVec, ref int nVec, ref double integral);

    }
}
