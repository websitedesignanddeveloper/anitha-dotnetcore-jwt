using Microsoft.AspNetCore.Mvc;
using WebAppJwt.Models;
using WebAppJwt.Services_file;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebAppJwt.Models.InterfaceDLL;
using System.Runtime.InteropServices;

namespace WebAppJwt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class UsersController : ControllerBase
    {
        //[DllImport("River_X_DLL.dll", EntryPoint = "Kmat_Calc", CallingConvention = CallingConvention.Cdecl)]
        //[DllImport("Fortran_DLLs\\River_X_DLL.dll", EntryPoint = "mainFatigue", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void mainFatigue(ref double me, ref double Lspan, ref double dynKL, ref double dynKV, ref double ymaxL, ref double ymaxV, ref double Teff, ref double kc, ref double Econc,
        //     ref double Iconc, ref double KBendPipe, ref double Uc, ref double thetaSpan, ref double eonD, ref double dtrench, ref double Iturb, ref double ODtotal, ref double Dsteel, ref double tSteel,
        //      ref double Epipe, ref double SCF, ref double C_SN, ref double m_SN, ref double zetaSoil_L, ref double zetaHydroL, ref double zetaSoil_V, ref double zetaHydroV, ref double zetaStrct, ref double rhoWater,
        //       ref double gamaFIL, ref double gamaFCF, ref double gamaOnIL, ref double gamaOnCF, ref double gamaS, ref double gamaK, ref double freqRatio, ref double CSF, ref double LeffIL, ref double f0IL, ref double VR_IL, ref double KsdIL,
        //       ref double VRonsetIL, ref double AYonD, ref double AmpIL, ref double S_IL, ref double Ncyc_IL, ref double FatLife_IL, ref double LeffCF, ref double f0CF, ref double VR_CF,
        //       ref double VRonsetCF, ref double AZonD, ref double AmpCF, ref double S_CF, ref double Ncyc_CF, ref double FatLife_CF, ref int isCalcOk);

        private IUserService _userService;
        private readonly IConfiguration _config;
        private readonly IFlowlineDimService _flowlineDimService;
        public UsersController(IUserService userService, IConfiguration configuration, IFlowlineDimService flowlineDimService)
        {
            _userService = userService;
            _config = configuration;
            _flowlineDimService = flowlineDimService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

      
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPut("getSingleUser")]
        public Task<IActionResult> GetSingleUser(Object obj)
        {
            var singleUser =  obj;
            return  null;
        }
      
        [HttpGet("getNasaImageList")]
        public async Task<IActionResult> GetNasaImageList()
        {
            List<Images> ImgList = new List<Images>();
            
                try
                {
                    DateTime dt = DateTime.Now;
                    var searchDate = dt.ToString("yyyy-MM-dd");
                    HttpClient http = new HttpClient();
                    var NasaApi = http.GetAsync(_config["Url"] + searchDate + "&api_key=DNBMtukhKD83Xec4BhdOmn8YFly5W2VNK7y8mJwV").Result;
                    var result = await NasaApi.Content.ReadAsStringAsync();
                    Images jsonObj = JsonConvert.DeserializeObject<Images>(result);
                    var imgdata = new Images();
                    imgdata.date = searchDate;
                    imgdata.photos = jsonObj.photos;

                    ImgList.Add(imgdata);

                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ImgList });
                }
            return Ok(ImgList);
        }

        [HttpGet("getAllFlowLineDim")]
        public IActionResult GetAllFlowLineDim()
        {
            try
            {
                var itemsSold = _flowlineDimService.GetAllFlowLineDim();
                return Ok(itemsSold);
            }
            catch (Exception ex)
            {
                 return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpGet("getSimpleCalculation")]
        public IActionResult GetSimpleCalculation()
        {
            try
            {
                //var itemsSold = _flowlineDimService.GetAllFlowLineDim();
                //return Ok(itemsSold);

                //ECAAnalysis.Kmat_Calc(100.501,101.501,100.501);

                //IntermediateCalcs.mainIntermediateCalcs(12, 13);
                double val1 = 4.22, val2 = 6.65, val3=8.25 ;
                int val4 = 4;
                //Kmat_Calc(ref val1, ref val2, ref val3);

                //StaticAnalysis.analyticalStaticAnalysis(ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val4, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val4);

                //ECAAnalysis cs file

                //FatigueAnalysis cs file

                //FatigueAnalysis.mainFatigue(ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3,
                // ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val4);

                //ImpactAnalysis.impactPipeOnRiverBed(ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2);

                //if (Environment.Is64BitProcess)
                //{
                //    ImpactAnalysis.impactPipeOnRiverBedFromF107(ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val4, ref val2, ref val3, ref val1, ref val2, ref val3);
                //}

                if (Environment.Is64BitProcess)
                {
                    FatigueAnalysis.mainFatigue(ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3,
                     ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val3, ref val1, ref val2, ref val4);
                }
                return Ok(null);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.ToString() });
            }
        }

        
    }
}
